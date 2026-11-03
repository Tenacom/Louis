// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis;

internal sealed class LocalActionDisposableTests
{
    [Test]
    public async Task Constructor_WithNullAction_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            using var disposable = new LocalActionDisposable(null!);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("onDispose");
    }

    [Test]
    public async Task Dispose_InvokesAction()
    {
        // A ref struct cannot live in an async method, so the act happens in a synchronous local function.
        static int Act()
        {
            var callCount = 0;
            var disposable = new LocalActionDisposable(() => callCount++);
            disposable.Dispose();
            return callCount;
        }

        await Assert.That(Act()).IsEqualTo(1);
    }

    [Test]
    public async Task Dispose_WhenCalledAgain_DoesNothing()
    {
        static int Act()
        {
            var callCount = 0;
            var disposable = new LocalActionDisposable(() => callCount++);
            disposable.Dispose();
            disposable.Dispose();
            return callCount;
        }

        await Assert.That(Act()).IsEqualTo(1);
    }
}
