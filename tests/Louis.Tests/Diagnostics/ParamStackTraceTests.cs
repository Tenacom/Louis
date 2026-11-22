// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET6_0_OR_GREATER

using System.Runtime.CompilerServices;
using Louis.Diagnostics;

// Param, ParamExtensions, and the class that throws, have StackTraceHiddenAttribute in every build of Louis.
// The runtime honors the attribute in the builds for .NET 6 and later alone.
internal sealed class ParamStackTraceTests
{
    [Test]
    public async Task FailedCheck_HidesCheckAndThrowMethodFromStackTrace()
    {
        // No optimization, so that the JIT compiler does not inline Param.NotNull, and the check has a frame of its own.
        [MethodImpl(MethodImplOptions.NoOptimization)]
        static void Act(string? text) => Param.NotNull(text);

        var exception = Assert.Throws<ArgumentNullException>(() => Act(null));

        var stackTrace = await Assert.That(exception.StackTrace).IsNotNull();
        await Assert.That(stackTrace).DoesNotContain("ParamThrow");
        await Assert.That(stackTrace).DoesNotContain("Param.NotNull");
    }

    [Test]
    public async Task FailedChainCheck_HidesCheckAndThrowMethodFromStackTrace()
    {
        // No optimization, so that the JIT compiler does not inline the chain check, and the check has a frame of its own.
        [MethodImpl(MethodImplOptions.NoOptimization)]
        static void Act(int number) => Param.Check(number).GreaterThan(0);

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Act(0));

        var stackTrace = await Assert.That(exception.StackTrace).IsNotNull();
        await Assert.That(stackTrace).DoesNotContain("ParamThrow");
        await Assert.That(stackTrace).DoesNotContain("ParamExtensions");
    }

    [Test]
    public async Task FailedReadOnlySpanCheck_HidesCheckAndThrowMethodFromStackTrace()
    {
        // No optimization, so that the JIT compiler does not inline the chain check, and the check has a frame of its own.
        [MethodImpl(MethodImplOptions.NoOptimization)]
        static void Act()
        {
            ReadOnlySpan<int> items = [];
            Param.Check(items).NotEmpty();
        }

        var exception = Assert.Throws<ArgumentException>(Act);

        var stackTrace = await Assert.That(exception.StackTrace).IsNotNull();
        await Assert.That(stackTrace).DoesNotContain("ParamThrow");
        await Assert.That(stackTrace).DoesNotContain("ReadOnlySpanParamExtensions");
    }

    [Test]
    public async Task FailedSpanCheck_HidesCheckAndThrowMethodFromStackTrace()
    {
        // No optimization, so that the JIT compiler does not inline the chain check, and the check has a frame of its own.
        [MethodImpl(MethodImplOptions.NoOptimization)]
        static void Act()
        {
            Span<int> items = [];
            Param.Check(items).NotEmpty();
        }

        var exception = Assert.Throws<ArgumentException>(Act);

        var stackTrace = await Assert.That(exception.StackTrace).IsNotNull();
        await Assert.That(stackTrace).DoesNotContain("ParamThrow");
        await Assert.That(stackTrace).DoesNotContain("SpanParamExtensions");
    }

#if NET9_0_OR_GREATER
    [Test]
    public async Task FailedRefParamCheck_HidesCheckAndThrowMethodFromStackTrace()
    {
        // No optimization, so that the JIT compiler does not inline the chain check, and the check has a frame of its own.
        [MethodImpl(MethodImplOptions.NoOptimization)]
        static void Act()
        {
            ReadOnlySpan<int> items = [];
            Param.CheckRef(items).Checked(static span => !span.IsEmpty);
        }

        var exception = Assert.Throws<ArgumentException>(Act);

        var stackTrace = await Assert.That(exception.StackTrace).IsNotNull();
        await Assert.That(stackTrace).DoesNotContain("ParamThrow");
        await Assert.That(stackTrace).DoesNotContain("RefParamExtensions");
    }
#endif
}

#endif
