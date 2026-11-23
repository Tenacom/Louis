// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Reflection;
using Louis.Diagnostics;

// The source generator of Louis adds the ThrowNew methods of InvalidCastExceptionExtensions and of RankExceptionExtensions
// when the compiler builds this project.
internal sealed class ThrowNewForAttributeTests
{
    [Test]
    public async Task Attribute_HoldsTheExceptionType()
    {
        var attribute = await Assert.That(typeof(InvalidCastExceptionExtensions).GetCustomAttribute<ThrowNewForAttribute>()).IsNotNull();

        await Assert.That(attribute.ExceptionType).IsEqualTo(typeof(InvalidCastException));
        await Assert.That(attribute.Public).IsFalse();
    }

    [Test]
    public async Task Attribute_HoldsTheValueOfPublic()
    {
        var attribute = await Assert.That(typeof(RankExceptionExtensions).GetCustomAttribute<ThrowNewForAttribute>()).IsNotNull();

        await Assert.That(attribute.ExceptionType).IsEqualTo(typeof(RankException));
        await Assert.That(attribute.Public).IsTrue();
    }

    [Test]
    public async Task Methods_AreInternal_UnlessPublicIsTrue()
    {
        const BindingFlags anyStatic = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
        var internalMethods = GetThrowNewMethods(typeof(InvalidCastExceptionExtensions));
        var publicMethods = GetThrowNewMethods(typeof(RankExceptionExtensions));

        static MethodInfo[] GetThrowNewMethods(Type type)
            => [.. type.GetMethods(anyStatic).Where(static method => method.Name == "ThrowNew")];

        await Assert.That(internalMethods).IsNotEmpty();
        await Assert.That(internalMethods).ContainsOnly(static method => method.IsAssembly);
        await Assert.That(publicMethods).IsNotEmpty();
        await Assert.That(publicMethods).ContainsOnly(static method => method.IsPublic);
    }

    [Test]
    public async Task ThrowNew_WithoutArguments_ThrowsExceptionOfTheNamedType()
    {
        static void Act() => InvalidCastException.ThrowNew();

        await Assert.That(Act).ThrowsExactly<InvalidCastException>();
    }

    [Test]
    public async Task ThrowNew_PassesItsArgumentsToTheConstructor()
    {
        var innerException = new InvalidOperationException();

        void Act() => RankException.ThrowNew("Something failed.", innerException);

        var exception = Assert.Throws<RankException>(Act);
        await Assert.That(exception.Message).IsEqualTo("Something failed.");
        await Assert.That(exception.InnerException).IsSameReferenceAs(innerException);
    }

    [Test]
    public async Task ThrowNewWithTypeArgument_ThrowsWhereTheCodeNeedsAnExpression()
    {
        static int GetValue(int? value) => value ?? InvalidCastException.ThrowNew<int>("No value.");

        await Assert.That(GetValue(1)).IsEqualTo(1);
        await Assert.That(() => GetValue(null)).ThrowsExactly<InvalidCastException>().WithMessage("No value.", StringComparison.Ordinal);
    }
}
