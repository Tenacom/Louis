// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

[Timeout(10_000)]
internal sealed class AsyncServiceDoneTokenTests : AsyncServiceTestsBase
{
    [Test]
    public async Task DoneToken_BeforeStart_IsNotCanceled(CancellationToken cancellationToken)
    {
        await Assert.That(Service.DoneToken.IsCancellationRequested).IsFalse();
    }

    [Test]
    public async Task DoneToken_WhenSetupFails_IsCanceled(CancellationToken cancellationToken)
    {
        var doneToken = Service.DoneToken;
        Service.SetupGate.SetResult(false);

        await Service.RunAsync(cancellationToken);

        await Assert.That(doneToken.IsCancellationRequested).IsTrue();
    }

    [Test]
    public async Task DoneToken_AfterStopBeforeStart_IsCanceled(CancellationToken cancellationToken)
    {
        var doneToken = Service.DoneToken;

        _ = Service.Stop();

        await Assert.That(doneToken.IsCancellationRequested).IsTrue();
    }

    [Test]
    public async Task DoneToken_AfterDispose_IsCanceled(CancellationToken cancellationToken)
    {
        await Service.DisposeAsync();

        await Assert.That(Service.DoneToken.IsCancellationRequested).IsTrue();
    }
}
