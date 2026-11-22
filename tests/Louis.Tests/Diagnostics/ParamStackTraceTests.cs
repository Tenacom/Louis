// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET6_0_OR_GREATER

using System.Runtime.CompilerServices;
using Louis.Diagnostics;

// Param, and the class that throws, have StackTraceHiddenAttribute in every build of Louis.
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
}

#endif
