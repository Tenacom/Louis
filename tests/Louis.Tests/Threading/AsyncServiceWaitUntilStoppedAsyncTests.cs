// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;

[Timeout(10_000)]
internal sealed class AsyncServiceWaitUntilStoppedAsyncTests : AsyncServiceTestsBase
{
    [Test]
    public async Task WaitUntilStoppedAsync_BeforeStart_ReturnsPendingTask(CancellationToken cancellationToken)
    {
        var stoppedTask = Service.WaitUntilStoppedAsync();

        await Assert.That(stoppedTask.IsCompleted).IsFalse();
    }

    [Test]
    public async Task WaitUntilStoppedAsync_WhenServiceStops_Completes(CancellationToken cancellationToken)
    {
        var stoppedTask = Service.WaitUntilStoppedAsync();
        Service.SetupGate.SetResult(true);
        Service.ExecuteGate.SetResult(true);
        var runTask = Service.RunAsync(cancellationToken);
        await Service.TeardownEntered;

        await Assert.That(stoppedTask.IsCompleted).IsFalse();

        Service.TeardownGate.SetResult(true);
        await stoppedTask;

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        await runTask;
    }
}
