// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;

#pragma warning disable CA1849 // Call async methods when in an async method - CancelAsync does not exist on .NET Framework
[Timeout(10_000)]
internal sealed class AsyncHostedServiceStartAsyncTests : AsyncHostedServiceTestsBase
{
    [Test]
    public async Task StartAsync_WhenSetupSucceeds_Completes(CancellationToken cancellationToken)
    {
        Service.SetupGate.SetResult(true);

        await Service.StartAsync(cancellationToken);

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Running);
    }

    [Test]
    public async Task StartAsync_WhenStoppedBeforeStart_ThrowsInvalidOperationException(
        CancellationToken cancellationToken)
    {
        _ = Service.Stop();

        await Assert.That(() => Service.StartAsync(cancellationToken))
            .Throws<InvalidOperationException>()
            .WithMessage("Service start failed (NotStarted).", StringComparison.Ordinal);

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
    }

    [Test]
    public async Task StartAsync_WhenStoppedBeforeStartAndFailOnSetupNotStartedIsFalse_Completes(
        CancellationToken cancellationToken)
    {
        Service.FailOnSetupNotStartedValue = false;
        _ = Service.Stop();

        await Service.StartAsync(cancellationToken);

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
    }

    [Test]
    public async Task StartAsync_WhenSetupReturnsFalse_ThrowsInvalidOperationException(
        CancellationToken cancellationToken)
    {
        Service.SetupGate.SetResult(false);

        await Assert.That(() => Service.StartAsync(cancellationToken))
            .Throws<InvalidOperationException>()
            .WithMessage("Service start failed (Unsuccessful).", StringComparison.Ordinal);

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
    }

    [Test]
    public async Task StartAsync_WhenSetupReturnsFalseAndFailOnSetupUnsuccessfulIsFalse_Completes(
        CancellationToken cancellationToken)
    {
        Service.FailOnSetupUnsuccessfulValue = false;
        Service.SetupGate.SetResult(false);

        await Service.StartAsync(cancellationToken);

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
    }

    [Test]
    public async Task StartAsync_WithTokenCanceledDuringSetup_ThrowsOperationCanceledException(
        CancellationToken cancellationToken)
    {
        using var tokenSource = new CancellationTokenSource();
        var startTask = Service.StartAsync(tokenSource.Token);
        await Service.SetupEntered;

        tokenSource.Cancel();

        await Assert.That(Service.SetupToken.IsCancellationRequested).IsTrue();

        Service.SetupGate.SetException(new OperationCanceledException(Service.SetupToken));
        var thrown = await Assert.That(() => startTask).Throws<OperationCanceledException>();

        var exception = await Assert.That(thrown).IsNotNull();
        await Assert.That(exception.CancellationToken).IsEqualTo(tokenSource.Token);
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
    }

    [Test]
    public async Task StartAsync_WhenStoppedDuringSetup_ThrowsOperationCanceledException(
        CancellationToken cancellationToken)
    {
        var startTask = Service.StartAsync(cancellationToken);
        await Service.SetupEntered;

        _ = Service.Stop();

        await Assert.That(Service.SetupToken.IsCancellationRequested).IsTrue();

        Service.SetupGate.SetException(new OperationCanceledException(Service.SetupToken));

        _ = await Assert.That(() => startTask).Throws<OperationCanceledException>();
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
    }

    [Test]
    public async Task StartAsync_WhenSetupThrows_ThrowsSetupException(CancellationToken cancellationToken)
    {
        var exception = new InvalidOperationException("Setup failed.");
        Service.SetupGate.SetException(exception);

        var thrown = await Assert.That(() => Service.StartAsync(cancellationToken)).Throws<InvalidOperationException>();

        await Assert.That(thrown).IsSameReferenceAs(exception);
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
    }

    [Test]
    public async Task StartAsync_WhenAlreadyStarted_ThrowsInvalidOperationException(CancellationToken cancellationToken)
    {
        var startTask = Service.StartAsync(cancellationToken);
        await Service.SetupEntered;

        _ = await Assert.That(() => Service.StartAsync(cancellationToken)).Throws<InvalidOperationException>();
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Starting);

        Service.SetupGate.SetResult(true);
        await startTask;
    }

    [Test]
    public async Task StartAsync_AfterDispose_ThrowsObjectDisposedException(CancellationToken cancellationToken)
    {
        await Service.DisposeAsync();

        _ = await Assert.That(() => Service.StartAsync(cancellationToken)).Throws<ObjectDisposedException>();
    }

    [Test]
    public async Task StartAsync_WithMinimalAsyncHostedServiceWhenStoppedBeforeStart_ThrowsInvalidOperationException(
        CancellationToken cancellationToken)
    {
        await using var service = new MinimalAsyncHostedService(Logger, setupResult: true);
        _ = service.Stop();

        await Assert.That(() => service.StartAsync(cancellationToken))
            .Throws<InvalidOperationException>()
            .WithMessage("Service start failed (NotStarted).", StringComparison.Ordinal);
    }

    [Test]
    public async Task StartAsync_WithMinimalAsyncHostedServiceWhenSetupReturnsFalse_ThrowsInvalidOperationException(
        CancellationToken cancellationToken)
    {
        await using var service = new MinimalAsyncHostedService(Logger, setupResult: false);

        await Assert.That(() => service.StartAsync(cancellationToken))
            .Throws<InvalidOperationException>()
            .WithMessage("Service start failed (Unsuccessful).", StringComparison.Ordinal);
    }
}

#pragma warning restore CA1849 // Call async methods when in an async method
