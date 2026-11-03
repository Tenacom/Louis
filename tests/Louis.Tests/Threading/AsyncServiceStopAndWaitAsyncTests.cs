// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;

[Timeout(10_000)]
internal sealed class AsyncServiceStopAndWaitAsyncTests : AsyncServiceTestsBase
{
    [Test]
    public async Task StopAndWaitAsync_BeforeStart_PreventsStartAndReturnsFalse(CancellationToken cancellationToken)
    {
        var result = await Service.StopAndWaitAsync();

        await Assert.That(result).IsFalse();
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        var setupResult = await Service.WaitUntilStartedAsync();
        await Assert.That(setupResult).IsEqualTo(AsyncServiceSetupResult.NotStarted);
        await Assert.That(Service.Calls).Contains("LogStopRequested(Created, Stopped, False)");
    }

    [Test]
    public async Task StopAndWaitAsync_DuringSetup_WaitsForStopAndReturnsTrue(CancellationToken cancellationToken)
    {
        var runTask = Service.RunAsync(cancellationToken);
        await Service.SetupEntered;

        var stopTask = Service.StopAndWaitAsync();

        await Assert.That(Service.SetupToken.IsCancellationRequested).IsTrue();
        await Assert.That(stopTask.IsCompleted).IsFalse();

        Service.SetupGate.SetException(new OperationCanceledException(Service.SetupToken));
        var result = await stopTask;

        await Assert.That(result).IsTrue();
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        await runTask;
    }

    [Test]
    public async Task StopAndWaitAsync_DuringExecution_WaitsForStopAndReturnsTrue(CancellationToken cancellationToken)
    {
        Service.SetupGate.SetResult(true);
        var runTask = Service.RunAsync(cancellationToken);
        await Service.ExecuteEntered;

        var stopTask = Service.StopAndWaitAsync();

        await Assert.That(Service.ExecuteToken.IsCancellationRequested).IsTrue();

        Service.ExecuteGate.SetException(new OperationCanceledException(Service.ExecuteToken));
        await Service.TeardownEntered;

        await Assert.That(stopTask.IsCompleted).IsFalse();

        Service.TeardownGate.SetResult(true);
        var result = await stopTask;

        await Assert.That(result).IsTrue();
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        await runTask;
    }

    [Test]
    public async Task StopAndWaitAsync_DuringTeardown_WaitsForStopAndReturnsTrue(CancellationToken cancellationToken)
    {
        Service.SetupGate.SetResult(true);
        Service.ExecuteGate.SetResult(true);
        var runTask = Service.RunAsync(cancellationToken);
        await Service.TeardownEntered;

        var stopTask = Service.StopAndWaitAsync();

        await Assert.That(stopTask.IsCompleted).IsFalse();

        Service.TeardownGate.SetResult(true);
        var result = await stopTask;

        await Assert.That(result).IsTrue();
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        await runTask;
    }

    [Test]
    public async Task StopAndWaitAsync_AfterServiceStopped_ReturnsFalse(CancellationToken cancellationToken)
    {
        Service.SetupGate.SetResult(true);
        Service.ExecuteGate.SetResult(true);
        Service.TeardownGate.SetResult(true);
        await Service.RunAsync(cancellationToken);

        var result = await Service.StopAndWaitAsync();

        await Assert.That(result).IsFalse();
        await Assert.That(Service.Calls).Contains("LogStopRequested(Stopped, Stopped, False)");
    }

    [Test]
    public async Task StopAndWaitAsync_AfterDispose_ReturnsFalse(CancellationToken cancellationToken)
    {
        await Service.DisposeAsync();

        var result = await Service.StopAndWaitAsync();

        await Assert.That(result).IsFalse();
        await Assert.That(Service.Calls).Contains("LogStopRequested(Disposed, Disposed, False)");
    }
}
