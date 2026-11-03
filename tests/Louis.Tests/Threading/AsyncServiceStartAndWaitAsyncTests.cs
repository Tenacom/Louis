// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;
using TUnit.Assertions.Enums;

#pragma warning disable CA1849 // Call async methods when in an async method - CancelAsync does not exist on .NET Framework
[Timeout(10_000)]
internal sealed class AsyncServiceStartAndWaitAsyncTests : AsyncServiceTestsBase
{
    [Test]
    public async Task StartAndWaitAsync_ReturnsAfterSetupCompletes(CancellationToken cancellationToken)
    {
        var startTask = Service.StartAndWaitAsync(cancellationToken);
        await Service.SetupEntered;

        await Assert.That(startTask.IsCompleted).IsFalse();

        Service.SetupGate.SetResult(true);
        var setupResult = await startTask;

        await Assert.That(setupResult).IsEqualTo(AsyncServiceSetupResult.Successful);
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Running);
    }

    [Test]
    public async Task StartAndWaitAsync_WhenSetupReturnsFalse_ReturnsUnsuccessful(CancellationToken cancellationToken)
    {
        Service.SetupGate.SetResult(false);

        var setupResult = await Service.StartAndWaitAsync(cancellationToken);

        await Assert.That(setupResult).IsEqualTo(AsyncServiceSetupResult.Unsuccessful);
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
    }

    [Test]
    public async Task StartAndWaitAsync_WhenSetupThrows_ReturnsFaulted(CancellationToken cancellationToken)
    {
        var exception = new InvalidOperationException("Setup failed.");
        Service.SetupGate.SetException(exception);

        var setupResult = await Service.StartAndWaitAsync(cancellationToken);

        await Assert.That(setupResult).IsEqualTo(AsyncServiceSetupResult.Faulted);
        await Assert.That(Service.SetupException).IsSameReferenceAs(exception);
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
    }

    [Test]
    public async Task StartAndWaitAsync_WithTokenCanceledDuringSetup_ReturnsCanceled(
        CancellationToken cancellationToken)
    {
        using var tokenSource = new CancellationTokenSource();
        var startTask = Service.StartAndWaitAsync(tokenSource.Token);
        await Service.SetupEntered;

        tokenSource.Cancel();
        Service.SetupGate.SetException(new OperationCanceledException(Service.SetupToken));
        var setupResult = await startTask;

        await Assert.That(setupResult).IsEqualTo(AsyncServiceSetupResult.Canceled);
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
    }

    [Test]
    public async Task StartAndWaitAsync_AfterStopBeforeStart_ReturnsNotStarted(CancellationToken cancellationToken)
    {
        _ = Service.Stop();

        var setupResult = await Service.StartAndWaitAsync(cancellationToken);

        await Assert.That(setupResult).IsEqualTo(AsyncServiceSetupResult.NotStarted);
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        string[] expectedCalls = ["LogStateChanged(Created, Stopped)", "LogStopRequested(Created, Stopped, False)"];
        await Assert.That(Service.Calls).IsEquivalentTo(expectedCalls, CollectionOrdering.Matching);
    }

    [Test]
    public async Task StartAndWaitAsync_WhenAlreadyStarted_ThrowsInvalidOperationException(
        CancellationToken cancellationToken)
    {
        var startTask = Service.StartAndWaitAsync(cancellationToken);
        await Service.SetupEntered;

        void Act() => _ = Service.StartAndWaitAsync(cancellationToken);

        _ = Assert.Throws<InvalidOperationException>(Act);
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Starting);

        Service.SetupGate.SetResult(false);
        _ = await startTask;
    }

    [Test]
    public async Task StartAndWaitAsync_AfterDispose_ThrowsObjectDisposedException(CancellationToken cancellationToken)
    {
        await Service.DisposeAsync();

        void Act() => _ = Service.StartAndWaitAsync(cancellationToken);

        _ = Assert.Throws<ObjectDisposedException>(Act);
    }
}

#pragma warning restore CA1849 // Call async methods when in an async method
