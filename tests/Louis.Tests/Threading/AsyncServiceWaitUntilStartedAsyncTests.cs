// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;

[Timeout(10_000)]
internal sealed class AsyncServiceWaitUntilStartedAsyncTests : AsyncServiceTestsBase
{
    [Test]
    public async Task WaitUntilStartedAsync_BeforeStart_ReturnsPendingTask(CancellationToken cancellationToken)
    {
        var startedTask = Service.WaitUntilStartedAsync();

        await Assert.That(startedTask.IsCompleted).IsFalse();
    }

    [Test]
    public async Task WaitUntilStartedAsync_WhenSetupCompletes_ReturnsSetupResult(CancellationToken cancellationToken)
    {
        var startedTask = Service.WaitUntilStartedAsync();
        var runTask = Service.RunAsync(cancellationToken);
        await Service.SetupEntered;

        await Assert.That(startedTask.IsCompleted).IsFalse();

        Service.SetupGate.SetResult(true);
        var setupResult = await startedTask;

        await Assert.That(setupResult).IsEqualTo(AsyncServiceSetupResult.Successful);

        Service.ExecuteGate.SetResult(true);
        Service.TeardownGate.SetResult(true);
        await runTask;
    }
}
