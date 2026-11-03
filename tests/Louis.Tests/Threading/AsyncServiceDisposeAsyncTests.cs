// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;
using TUnit.Assertions.Enums;

[Timeout(10_000)]
internal sealed class AsyncServiceDisposeAsyncTests : AsyncServiceTestsBase
{
    [Test]
    public async Task DisposeAsync_BeforeStart_DisposesResources(CancellationToken cancellationToken)
    {
        await Service.DisposeAsync();

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Disposed);
        await Assert.That(Service.DisposeResourcesCalls).IsEqualTo(1);
        var setupResult = await Service.WaitUntilStartedAsync();
        await Assert.That(setupResult).IsEqualTo(AsyncServiceSetupResult.NotStarted);
        await Assert.That(Service.WaitUntilStoppedAsync().IsCompleted).IsTrue();
        await Assert.That(Service.DoneToken.IsCancellationRequested).IsTrue();
        string[] expectedCalls = [
            "LogStateChanged(Created, Stopped)",
            "LogStopRequested(Created, Stopped, False)",
            "DisposeResourcesAsync",
        ];
        await Assert.That(Service.Calls).IsEquivalentTo(expectedCalls, CollectionOrdering.Matching);
    }

    [Test]
    public async Task DisposeAsync_WhileRunning_StopsServiceAndWaitsForIt(CancellationToken cancellationToken)
    {
        Service.SetupGate.SetResult(true);
        var runTask = Service.RunAsync(cancellationToken);
        await Service.ExecuteEntered;

        var disposeTask = Service.DisposeAsync().AsTask();

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Disposed);
        await Assert.That(Service.ExecuteToken.IsCancellationRequested).IsTrue();
        await Assert.That(Service.Calls).Contains("LogStopRequested(Running, Running, True)");

        Service.ExecuteGate.SetException(new OperationCanceledException(Service.ExecuteToken));
        await Service.TeardownEntered;

        await Assert.That(disposeTask.IsCompleted).IsFalse();
        await Assert.That(Service.DisposeResourcesCalls).IsEqualTo(0);

        Service.TeardownGate.SetResult(true);
        await disposeTask;

        await Assert.That(Service.DisposeResourcesCalls).IsEqualTo(1);
        await Assert.That(Service.Calls).Contains("LogTeardownCompleted");
        await runTask;
    }

    [Test]
    public async Task DisposeAsync_Twice_DisposesResourcesOnce(CancellationToken cancellationToken)
    {
        await Service.DisposeAsync();
        await Service.DisposeAsync();

        await Assert.That(Service.DisposeResourcesCalls).IsEqualTo(1);
    }
}
