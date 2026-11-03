// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;
using TUnit.Assertions.Enums;

[Timeout(10_000)]
internal sealed class AsyncServiceStartTests : AsyncServiceTestsBase
{
    [Test]
    public async Task Start_ReturnsBeforeSetupCompletes(CancellationToken cancellationToken)
    {
        Service.Start(cancellationToken);

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Starting);
        await Service.SetupEntered;
        await Assert.That(Service.WaitUntilStartedAsync().IsCompleted).IsFalse();

        Service.SetupGate.SetResult(true);
        Service.ExecuteGate.SetResult(true);
        Service.TeardownGate.SetResult(true);
        await Service.WaitUntilStoppedAsync();

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        await Assert.That(Service.Calls).Contains("LogTeardownCompleted");
    }

    [Test]
    public async Task Start_WhenSetupThrows_StopsWithFaultedResult(CancellationToken cancellationToken)
    {
        var exception = new InvalidOperationException("Setup failed.");
        Service.SetupGate.SetException(exception);

        Service.Start(cancellationToken);
        await Service.WaitUntilStoppedAsync();

        var setupResult = await Service.WaitUntilStartedAsync();
        await Assert.That(setupResult).IsEqualTo(AsyncServiceSetupResult.Faulted);
        await Assert.That(Service.SetupException).IsSameReferenceAs(exception);
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
    }

    [Test]
    public async Task Start_WhenExecutionAndTeardownThrow_StopsService(CancellationToken cancellationToken)
    {
        var executionException = new InvalidOperationException("Execution failed.");
        var teardownException = new InvalidOperationException("Teardown failed.");
        Service.SetupGate.SetResult(true);
        Service.ExecuteGate.SetException(executionException);
        Service.TeardownGate.SetException(teardownException);

        Service.Start(cancellationToken);
        await Service.WaitUntilStoppedAsync();

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        await Assert.That(Service.ExecuteException).IsSameReferenceAs(executionException);
        await Assert.That(Service.TeardownException).IsSameReferenceAs(teardownException);
    }

    [Test]
    public async Task Start_WhenAlreadyStarted_ThrowsInvalidOperationException(CancellationToken cancellationToken)
    {
        Service.Start(cancellationToken);
        await Service.SetupEntered;

        void Act() => Service.Start(cancellationToken);

        _ = Assert.Throws<InvalidOperationException>(Act);
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Starting);

        Service.SetupGate.SetResult(false);
        await Service.WaitUntilStoppedAsync();
    }

    [Test]
    public async Task Start_AfterStopBeforeStart_DoesNothing(CancellationToken cancellationToken)
    {
        _ = Service.Stop();

        Service.Start(cancellationToken);

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        var setupResult = await Service.WaitUntilStartedAsync();
        await Assert.That(setupResult).IsEqualTo(AsyncServiceSetupResult.NotStarted);
        string[] expectedCalls = ["LogStateChanged(Created, Stopped)", "LogStopRequested(Created, Stopped, False)"];
        await Assert.That(Service.Calls).IsEquivalentTo(expectedCalls, CollectionOrdering.Matching);
    }

    [Test]
    public async Task Start_AfterDispose_ThrowsObjectDisposedException(CancellationToken cancellationToken)
    {
        await Service.DisposeAsync();

        void Act() => Service.Start(cancellationToken);

        _ = Assert.Throws<ObjectDisposedException>(Act);
    }
}
