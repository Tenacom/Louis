// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;

[Timeout(10_000)]
internal sealed class AsyncHostedServiceStopAsyncTests : AsyncHostedServiceTestsBase
{
    [Test]
    public async Task StopAsync_WhileRunning_StopsServiceAndWaitsForIt(CancellationToken cancellationToken)
    {
        Service.SetupGate.SetResult(true);
        await Service.StartAsync(cancellationToken);
        await Service.ExecuteEntered;

        var stopTask = Service.StopAsync(cancellationToken);

        await Assert.That(Service.ExecuteToken.IsCancellationRequested).IsTrue();

        Service.ExecuteGate.SetException(new OperationCanceledException(Service.ExecuteToken));
        await Service.TeardownEntered;

        await Assert.That(stopTask.IsCompleted).IsFalse();

        Service.TeardownGate.SetResult(true);
        await stopTask;

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
    }

    [Test]
    public async Task StopAsync_WithTokenCanceledWhileServiceKeepsRunning_Returns(CancellationToken cancellationToken)
    {
        using var tokenSource = new CancellationTokenSource();
        Service.SetupGate.SetResult(true);
        await Service.StartAsync(cancellationToken);
        await Service.ExecuteEntered;

        var stopTask = Service.StopAsync(tokenSource.Token);

        await Assert.That(Service.ExecuteToken.IsCancellationRequested).IsTrue();
        await Assert.That(stopTask.IsCompleted).IsFalse();

#if NETFRAMEWORK
        // On .NET Framework, CancelAsync does not exist, so we use Cancel() instead.
        tokenSource.Cancel();
#else
        await tokenSource.CancelAsync();
#endif
        await stopTask;

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Running);
    }

    [Test]
    public async Task StopAsync_BeforeStart_PreventsStart(CancellationToken cancellationToken)
    {
        await Service.StopAsync(cancellationToken);

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        var setupResult = await Service.WaitUntilStartedAsync();
        await Assert.That(setupResult).IsEqualTo(AsyncServiceSetupResult.NotStarted);
    }

    [Test]
    public async Task StopAsync_AfterServiceStopped_Completes(CancellationToken cancellationToken)
    {
        Service.SetupGate.SetResult(true);
        Service.ExecuteGate.SetResult(true);
        Service.TeardownGate.SetResult(true);
        await Service.StartAsync(cancellationToken);
        await Service.WaitUntilStoppedAsync();

        await Service.StopAsync(cancellationToken);

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
    }

    [Test]
    public async Task StopAsync_AfterDispose_Completes(CancellationToken cancellationToken)
    {
        await Service.DisposeAsync();

        await Service.StopAsync(cancellationToken);

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Disposed);
    }
}

#pragma warning restore CA1849 // Call async methods when in an async method
