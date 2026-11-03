// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis;

internal sealed class ActionDisposableTests
{
    [Test]
    public async Task Constructor_WithNullAction_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            using var disposable = new ActionDisposable(null!);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("onDispose");
    }

    [Test]
    public async Task Dispose_InvokesAction()
    {
        var callCount = 0;
        var disposable = new ActionDisposable(() => callCount++);

        disposable.Dispose();

        await Assert.That(callCount).IsEqualTo(1);
    }

    [Test]
    public async Task Dispose_WhenCalledAgain_DoesNothing()
    {
        var callCount = 0;
        var disposable = new ActionDisposable(() => callCount++);
        disposable.Dispose();

        disposable.Dispose();

        await Assert.That(callCount).IsEqualTo(1);
    }
}
