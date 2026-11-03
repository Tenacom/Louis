// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Runtime.CompilerServices;
using Louis.Diagnostics;

internal sealed class ExceptionExtensionsRethrowTests
{
    [Test]
    public async Task Rethrow_WithNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((Exception)null!).Rethrow();

        var exception = Assert.Throws<ArgumentNullException>(Act);
        await Assert.That(exception.ParamName).IsEqualTo("this");
    }

    [Test]
    public async Task Rethrow_ThrowsSameInstance()
    {
        var exception = new InvalidOperationException();

        var thrown = Assert.Throws<InvalidOperationException>(exception.Rethrow);

        await Assert.That(thrown).IsSameReferenceAs(exception);
    }

    [Test]
    public async Task Rethrow_KeepsOriginalThrowSiteInStackTrace()
    {
        var thrown = Assert.Throws<InvalidOperationException>(RethrowCaught);

        await Assert.That(thrown.StackTrace).Contains(nameof(ThrowFromNamedMethod));

        static void RethrowCaught()
        {
            try
            {
                ThrowFromNamedMethod();
            }
            catch (InvalidOperationException e)
            {
                e.Rethrow();
            }
        }

        // No inlining, so that the method keeps a frame of its own in Release builds.
        [MethodImpl(MethodImplOptions.NoInlining)]
        static void ThrowFromNamedMethod() => throw new InvalidOperationException("Thrown from a named method.");
    }
}
