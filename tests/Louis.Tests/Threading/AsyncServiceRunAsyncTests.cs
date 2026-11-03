// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;
using TUnit.Assertions.Enums;

#pragma warning disable CA1849 // Call async methods when in an async method - CancelAsync does not exist on .NET Framework
[Timeout(10_000)]
internal sealed class AsyncServiceRunAsyncTests : AsyncServiceTestsBase
{
    [Test]
    public async Task RunAsync_RunsSetupExecutionAndTeardownInOrder(CancellationToken cancellationToken)
    {
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Created);

        var runTask = Service.RunAsync(cancellationToken);
        await Service.SetupEntered;

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Starting);
        await Assert.That(Service.WaitUntilStartedAsync().IsCompleted).IsFalse();
        await Assert.That(Service.DoneToken.IsCancellationRequested).IsFalse();

        Service.SetupGate.SetResult(true);
        await Service.ExecuteEntered;

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Running);
        var setupResult = await Service.WaitUntilStartedAsync();
        await Assert.That(setupResult).IsEqualTo(AsyncServiceSetupResult.Successful);
        await Assert.That(Service.WaitUntilStoppedAsync().IsCompleted).IsFalse();
        await Assert.That(Service.DoneToken.IsCancellationRequested).IsFalse();

        Service.ExecuteGate.SetResult(true);
        await Service.TeardownEntered;

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopping);
        await Assert.That(Service.DoneToken.IsCancellationRequested).IsTrue();
        await Assert.That(runTask.IsCompleted).IsFalse();

        Service.TeardownGate.SetResult(true);
        await runTask;

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        await Assert.That(Service.WaitUntilStoppedAsync().IsCompleted).IsTrue();
        string[] expectedCalls = [
            "LogStateChanged(Created, Starting)",
            "LogBeforeSetup",
            "SetupAsync",
            "LogSetupCompleted(True)",
            "LogStateChanged(Starting, Running)",
            "LogBeforeExecute",
            "ExecuteAsync",
            "LogExecuteCompleted",
            "LogStateChanged(Running, Stopping)",
            "LogBeforeTeardown",
            "TeardownAsync",
            "LogTeardownCompleted",
            "LogStateChanged(Stopping, Stopped)",
        ];
        await Assert.That(Service.Calls).IsEquivalentTo(expectedCalls, CollectionOrdering.Matching);
    }

    [Test]
    public async Task RunAsync_WhenSetupReturnsFalse_StopsWithoutExecuting(CancellationToken cancellationToken)
    {
        Service.SetupGate.SetResult(false);

        await Service.RunAsync(cancellationToken);

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        var setupResult = await Service.WaitUntilStartedAsync();
        await Assert.That(setupResult).IsEqualTo(AsyncServiceSetupResult.Unsuccessful);
        await Assert.That(Service.WaitUntilStoppedAsync().IsCompleted).IsTrue();
        await Assert.That(Service.DoneToken.IsCancellationRequested).IsTrue();
        string[] expectedCalls = [
            "LogStateChanged(Created, Starting)",
            "LogBeforeSetup",
            "SetupAsync",
            "LogSetupCompleted(False)",
            "LogStateChanged(Starting, Stopped)",
        ];
        await Assert.That(Service.Calls).IsEquivalentTo(expectedCalls, CollectionOrdering.Matching);
    }

    [Test]
    public async Task RunAsync_WhenSetupThrows_ThrowsSetupException(CancellationToken cancellationToken)
    {
        var exception = new InvalidOperationException("Setup failed.");
        Service.SetupGate.SetException(exception);

        var thrown = await Assert.That(() => Service.RunAsync(cancellationToken)).Throws<InvalidOperationException>();

        await Assert.That(thrown).IsSameReferenceAs(exception);
        await Assert.That(Service.SetupException).IsSameReferenceAs(exception);
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        var setupResult = await Service.WaitUntilStartedAsync();
        await Assert.That(setupResult).IsEqualTo(AsyncServiceSetupResult.Faulted);
        await Assert.That(Service.WaitUntilStoppedAsync().IsCompleted).IsTrue();
        await Assert.That(Service.DoneToken.IsCancellationRequested).IsTrue();
        string[] expectedCalls = [
            "LogStateChanged(Created, Starting)",
            "LogBeforeSetup",
            "SetupAsync",
            "LogSetupFailed",
            "LogStateChanged(Starting, Stopped)",
        ];
        await Assert.That(Service.Calls).IsEquivalentTo(expectedCalls, CollectionOrdering.Matching);
    }

    [Test]
    public async Task RunAsync_WhenSetupThrowsOperationCanceledExceptionWithoutStopRequest_ThrowsIt(
        CancellationToken cancellationToken)
    {
        var exception = new OperationCanceledException();
        Service.SetupGate.SetException(exception);

        var thrown = await Assert.That(() => Service.RunAsync(cancellationToken)).Throws<OperationCanceledException>();

        await Assert.That(thrown).IsSameReferenceAs(exception);
        await Assert.That(Service.SetupException).IsSameReferenceAs(exception);
        var setupResult = await Service.WaitUntilStartedAsync();
        await Assert.That(setupResult).IsEqualTo(AsyncServiceSetupResult.Faulted);
        await Assert.That(Service.Calls).Contains("LogSetupFailed");
    }

    [Test]
    public async Task RunAsync_WithTokenCanceledDuringSetup_StopsWithCanceledResult(CancellationToken cancellationToken)
    {
        using var tokenSource = new CancellationTokenSource();
        var runTask = Service.RunAsync(tokenSource.Token);
        await Service.SetupEntered;

        tokenSource.Cancel();

        await Assert.That(Service.SetupToken.IsCancellationRequested).IsTrue();

        Service.SetupGate.SetException(new OperationCanceledException(Service.SetupToken));
        await runTask;

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        var setupResult = await Service.WaitUntilStartedAsync();
        await Assert.That(setupResult).IsEqualTo(AsyncServiceSetupResult.Canceled);
        await Assert.That(Service.DoneToken.IsCancellationRequested).IsTrue();
        string[] expectedCalls = [
            "LogStateChanged(Created, Starting)",
            "LogBeforeSetup",
            "SetupAsync",
            "LogSetupCanceled",
            "LogStateChanged(Starting, Stopped)",
        ];
        await Assert.That(Service.Calls).IsEquivalentTo(expectedCalls, CollectionOrdering.Matching);
    }

    [Test]
    public async Task RunAsync_WithCanceledToken_SkipsSetup(CancellationToken cancellationToken)
    {
        await Service.RunAsync(new CancellationToken(canceled: true));

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        var setupResult = await Service.WaitUntilStartedAsync();
        await Assert.That(setupResult).IsEqualTo(AsyncServiceSetupResult.Canceled);
        string[] expectedCalls = [
            "LogStateChanged(Created, Starting)",
            "LogSetupCanceled",
            "LogStateChanged(Starting, Stopped)",
        ];
        await Assert.That(Service.Calls).IsEquivalentTo(expectedCalls, CollectionOrdering.Matching);
    }

    [Test]
    public async Task RunAsync_WithTokenCanceledDuringExecution_StopsService(CancellationToken cancellationToken)
    {
        using var tokenSource = new CancellationTokenSource();
        Service.SetupGate.SetResult(true);
        Service.TeardownGate.SetResult(true);
        var runTask = Service.RunAsync(tokenSource.Token);
        await Service.ExecuteEntered;

        tokenSource.Cancel();

        await Assert.That(Service.ExecuteToken.IsCancellationRequested).IsTrue();

        Service.ExecuteGate.SetException(new OperationCanceledException(Service.ExecuteToken));
        await runTask;

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        string[] expectedCalls = [
            "LogStateChanged(Created, Starting)",
            "LogBeforeSetup",
            "SetupAsync",
            "LogSetupCompleted(True)",
            "LogStateChanged(Starting, Running)",
            "LogBeforeExecute",
            "ExecuteAsync",
            "LogExecuteCanceled",
            "LogStateChanged(Running, Stopping)",
            "LogBeforeTeardown",
            "TeardownAsync",
            "LogTeardownCompleted",
            "LogStateChanged(Stopping, Stopped)",
        ];
        await Assert.That(Service.Calls).IsEquivalentTo(expectedCalls, CollectionOrdering.Matching);
    }

    [Test]
    public async Task RunAsync_WhenExecutionReturnsAfterCancellation_CountsItAsCanceled(
        CancellationToken cancellationToken)
    {
        using var tokenSource = new CancellationTokenSource();
        Service.SetupGate.SetResult(true);
        Service.TeardownGate.SetResult(true);
        var runTask = Service.RunAsync(tokenSource.Token);
        await Service.ExecuteEntered;

        tokenSource.Cancel();
        Service.ExecuteGate.SetResult(true);
        await runTask;

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        await Assert.That(Service.Calls).Contains("LogExecuteCanceled");
        await Assert.That(Service.Calls).DoesNotContain("LogExecuteCompleted");
        await Assert.That(Service.Calls).Contains("LogTeardownCompleted");
    }

    [Test]
    public async Task RunAsync_WhenExecutionThrows_RunsTeardownAndThrowsExecutionException(
        CancellationToken cancellationToken)
    {
        var exception = new InvalidOperationException("Execution failed.");
        Service.SetupGate.SetResult(true);
        Service.ExecuteGate.SetException(exception);
        Service.TeardownGate.SetResult(true);

        var thrown = await Assert.That(() => Service.RunAsync(cancellationToken)).Throws<InvalidOperationException>();

        await Assert.That(thrown).IsSameReferenceAs(exception);
        await Assert.That(Service.ExecuteException).IsSameReferenceAs(exception);
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        await Assert.That(Service.DoneToken.IsCancellationRequested).IsTrue();
        string[] expectedCalls = [
            "LogStateChanged(Created, Starting)",
            "LogBeforeSetup",
            "SetupAsync",
            "LogSetupCompleted(True)",
            "LogStateChanged(Starting, Running)",
            "LogBeforeExecute",
            "ExecuteAsync",
            "LogExecuteFailed",
            "LogStateChanged(Running, Stopping)",
            "LogBeforeTeardown",
            "TeardownAsync",
            "LogTeardownCompleted",
            "LogStateChanged(Stopping, Stopped)",
        ];
        await Assert.That(Service.Calls).IsEquivalentTo(expectedCalls, CollectionOrdering.Matching);
    }

    [Test]
    public async Task RunAsync_WhenExecutionAndTeardownThrow_ThrowsAggregateException(
        CancellationToken cancellationToken)
    {
        var executionException = new InvalidOperationException("Execution failed.");
        var teardownException = new InvalidOperationException("Teardown failed.");
        Service.SetupGate.SetResult(true);
        Service.ExecuteGate.SetException(executionException);
        Service.TeardownGate.SetException(teardownException);

        var thrown = await Assert.That(() => Service.RunAsync(cancellationToken)).Throws<AggregateException>();

        var aggregateException = await Assert.That(thrown).IsNotNull();
        Exception[] expectedInnerExceptions = [executionException, teardownException];
        await Assert.That(aggregateException.InnerExceptions).IsEquivalentTo(expectedInnerExceptions, CollectionOrdering.Matching);
        await Assert.That(Service.ExecuteException).IsSameReferenceAs(executionException);
        await Assert.That(Service.TeardownException).IsSameReferenceAs(teardownException);
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        await Assert.That(Service.Calls).Contains("LogTeardownFailed");
    }

    [Test]
    public async Task RunAsync_WhenTeardownThrows_ThrowsTeardownException(CancellationToken cancellationToken)
    {
        var exception = new InvalidOperationException("Teardown failed.");
        Service.SetupGate.SetResult(true);
        Service.ExecuteGate.SetResult(true);
        Service.TeardownGate.SetException(exception);

        var thrown = await Assert.That(() => Service.RunAsync(cancellationToken)).Throws<InvalidOperationException>();

        await Assert.That(thrown).IsSameReferenceAs(exception);
        await Assert.That(Service.TeardownException).IsSameReferenceAs(exception);
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        await Assert.That(Service.WaitUntilStoppedAsync().IsCompleted).IsTrue();
        await Assert.That(Service.Calls).Contains("LogTeardownFailed");
    }

    [Test]
    public async Task RunAsync_WhenAlreadyStarted_ThrowsInvalidOperationException(CancellationToken cancellationToken)
    {
        var runTask = Service.RunAsync(cancellationToken);
        await Service.SetupEntered;

        void Act() => _ = Service.RunAsync(cancellationToken);

        _ = Assert.Throws<InvalidOperationException>(Act);
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Starting);

        Service.SetupGate.SetResult(false);
        await runTask;
    }

    [Test]
    public async Task RunAsync_AfterServiceStopped_ThrowsInvalidOperationException(CancellationToken cancellationToken)
    {
        Service.SetupGate.SetResult(true);
        Service.ExecuteGate.SetResult(true);
        Service.TeardownGate.SetResult(true);
        await Service.RunAsync(cancellationToken);

        void Act() => _ = Service.RunAsync(cancellationToken);

        _ = Assert.Throws<InvalidOperationException>(Act);
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
    }

    [Test]
    public async Task RunAsync_AfterStopBeforeStart_ReturnsCompletedTask(CancellationToken cancellationToken)
    {
        _ = Service.Stop();

        var runTask = Service.RunAsync(cancellationToken);

        await Assert.That(runTask.Status).IsEqualTo(TaskStatus.RanToCompletion);
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        string[] expectedCalls = ["LogStateChanged(Created, Stopped)", "LogStopRequested(Created, Stopped, False)"];
        await Assert.That(Service.Calls).IsEquivalentTo(expectedCalls, CollectionOrdering.Matching);
    }

    [Test]
    public async Task RunAsync_AfterDispose_ThrowsObjectDisposedException(CancellationToken cancellationToken)
    {
        await Service.DisposeAsync();

        void Act() => _ = Service.RunAsync(cancellationToken);

        _ = Assert.Throws<ObjectDisposedException>(Act);
    }
}

#pragma warning restore CA1849 // Call async methods when in an async method
