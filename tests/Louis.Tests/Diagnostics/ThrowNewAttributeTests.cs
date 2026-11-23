// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Reflection;
#if NET6_0_OR_GREATER
using System.Runtime.CompilerServices;
#endif
using Louis.Diagnostics;

// The source generator of Louis adds the ThrowNew methods of TestException when the compiler builds this project.
internal sealed partial class ThrowNewAttributeTests
{
    [Test]
    public async Task Attribute_IsOnTheConstructor()
    {
        var constructor = typeof(TestException).GetConstructor(Type.EmptyTypes);

        var attribute = constructor?.GetCustomAttribute<ThrowNewAttribute>();

        await Assert.That(attribute).IsNotNull();
    }

    [Test]
    public async Task ThrowNew_WithoutArguments_ThrowsExceptionOfTheClass()
    {
        static void Act() => TestException.ThrowNew();

        await Assert.That(Act).ThrowsExactly<TestException>();
    }

    [Test]
    public async Task ThrowNew_PassesItsArgumentsToTheConstructor()
    {
        var innerException = new InvalidOperationException();

        void Act() => TestException.ThrowNew("Something failed.", innerException);

        var exception = Assert.Throws<TestException>(Act);
        await Assert.That(exception.Message).IsEqualTo("Something failed.");
        await Assert.That(exception.InnerException).IsSameReferenceAs(innerException);
    }

    [Test]
    public async Task ThrowNewWithTypeArgument_ThrowsWhereTheCodeNeedsAnExpression()
    {
        static int GetValue(int? value) => value ?? TestException.ThrowNew<int>("No value.");

        await Assert.That(GetValue(1)).IsEqualTo(1);
        await Assert.That(() => GetValue(null)).ThrowsExactly<TestException>().WithMessage("No value.", StringComparison.Ordinal);
    }

#if NET6_0_OR_GREATER
    // The generated methods have StackTraceHiddenAttribute, which the runtime honors in .NET 6 and later.
    [Test]
    public async Task ThrowNew_IsNotInTheStackTrace()
    {
        // No optimization, so that the JIT compiler does not inline the call, and the stack trace has a frame of this method.
        [MethodImpl(MethodImplOptions.NoOptimization)]
        static void Act() => TestException.ThrowNew("Something failed.");

        var exception = Assert.Throws<TestException>(Act);

        var stackTrace = await Assert.That(exception.StackTrace).IsNotNull();
        await Assert.That(stackTrace).DoesNotContain("ThrowNew(");
    }
#endif
}
