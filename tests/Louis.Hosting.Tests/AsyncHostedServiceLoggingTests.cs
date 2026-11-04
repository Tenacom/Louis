// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Microsoft.Extensions.Logging;
using TUnit.Assertions.Enums;

// The log hooks of AsyncService are sealed in AsyncHostedService, so these tests check what the logger receives.
// The event ids are numbers on purpose: they are the contract a log reader sees.
[Timeout(10_000)]
internal sealed class AsyncHostedServiceLoggingTests : AsyncHostedServiceTestsBase
{
    [Test]
    public async Task StartAsync_ThenStopAsync_LogsEveryPhase(CancellationToken cancellationToken)
    {
        Service.SetupGate.SetResult(true);
        Service.TeardownGate.SetResult(true);
        await Service.StartAsync(cancellationToken);
        await Service.ExecuteEntered;

        var stopTask = Service.StopAsync(cancellationToken);

        await Assert.That(Service.ExecuteToken.IsCancellationRequested).IsTrue();

        Service.ExecuteGate.SetException(new OperationCanceledException(Service.ExecuteToken));
        await stopTask;

        LogEntry[] expectedEntries = [
            new(15, LogLevel.Trace, "Hosted service starting"),
            new(1, LogLevel.Trace, "Service state Created -> Starting"),
            new(2, LogLevel.Trace, "Starting setup phase"),
            new(3, LogLevel.Trace, "Setup phase completed successfully"),
            new(1, LogLevel.Trace, "Service state Starting -> Running"),
            new(7, LogLevel.Trace, "Starting service execution"),
            new(16, LogLevel.Trace, "Hosted service stopping"),
            new(14, LogLevel.Information, "Stop requested while service running (Running)"),
            new(9, LogLevel.Warning, "Service execution was canceled"),
            new(1, LogLevel.Trace, "Service state Running -> Stopping"),
            new(11, LogLevel.Trace, "Starting teardown phase"),
            new(12, LogLevel.Trace, "Teardown phase completed"),
            new(1, LogLevel.Trace, "Service state Stopping -> Stopped"),
        ];
        await Assert.That(Logger.Entries).IsEquivalentTo(expectedEntries, CollectionOrdering.Matching);
    }

    [Test]
    public async Task StartAsync_WhenExecutionCompletes_LogsExecuteCompletedAndTeardown(
        CancellationToken cancellationToken)
    {
        Service.SetupGate.SetResult(true);
        Service.TeardownGate.SetResult(true);
        await Service.StartAsync(cancellationToken);
        await Service.ExecuteEntered;

        Service.ExecuteGate.SetResult(true);
        await Service.WaitUntilStoppedAsync();

        LogEntry[] expectedEntries = [
            new(15, LogLevel.Trace, "Hosted service starting"),
            new(1, LogLevel.Trace, "Service state Created -> Starting"),
            new(2, LogLevel.Trace, "Starting setup phase"),
            new(3, LogLevel.Trace, "Setup phase completed successfully"),
            new(1, LogLevel.Trace, "Service state Starting -> Running"),
            new(7, LogLevel.Trace, "Starting service execution"),
            new(8, LogLevel.Trace, "Service execution completed"),
            new(1, LogLevel.Trace, "Service state Running -> Stopping"),
            new(11, LogLevel.Trace, "Starting teardown phase"),
            new(12, LogLevel.Trace, "Teardown phase completed"),
            new(1, LogLevel.Trace, "Service state Stopping -> Stopped"),
        ];
        await Assert.That(Logger.Entries).IsEquivalentTo(expectedEntries, CollectionOrdering.Matching);
    }

    [Test]
    public async Task StartAsync_WhenSetupReturnsFalse_LogsSetupNotSuccessful(CancellationToken cancellationToken)
    {
        Service.FailOnSetupUnsuccessfulValue = false;
        Service.SetupGate.SetResult(false);

        await Service.StartAsync(cancellationToken);

        LogEntry[] expectedEntries = [
            new(15, LogLevel.Trace, "Hosted service starting"),
            new(1, LogLevel.Trace, "Service state Created -> Starting"),
            new(2, LogLevel.Trace, "Starting setup phase"),
            new(4, LogLevel.Warning, "Setup phase completed unsuccessfully"),
            new(1, LogLevel.Trace, "Service state Starting -> Stopped"),
        ];
        await Assert.That(Logger.Entries).IsEquivalentTo(expectedEntries, CollectionOrdering.Matching);
    }

    [Test]
    public async Task StartAsync_WithTokenCanceledDuringSetup_LogsSetupCanceled(CancellationToken cancellationToken)
    {
        using var tokenSource = new CancellationTokenSource();
        var startTask = Service.StartAsync(tokenSource.Token);
        await Service.SetupEntered;

#if NETFRAMEWORK
        // On .NET Framework, CancelAsync does not exist, so we use Cancel() instead.
        tokenSource.Cancel();
#else
        await tokenSource.CancelAsync();
#endif
        Service.SetupGate.SetException(new OperationCanceledException(Service.SetupToken));

        _ = await Assert.That(() => startTask).Throws<OperationCanceledException>();
        LogEntry[] expectedEntries = [
            new(15, LogLevel.Trace, "Hosted service starting"),
            new(1, LogLevel.Trace, "Service state Created -> Starting"),
            new(2, LogLevel.Trace, "Starting setup phase"),
            new(5, LogLevel.Warning, "Service execution was canceled during setup phase"),
            new(1, LogLevel.Trace, "Service state Starting -> Stopped"),
        ];
        await Assert.That(Logger.Entries).IsEquivalentTo(expectedEntries, CollectionOrdering.Matching);
    }

    [Test]
    public async Task StartAsync_WhenSetupThrows_LogsSetupFailedWithException(CancellationToken cancellationToken)
    {
        var exception = new InvalidOperationException("Setup failed.");
        Service.SetupGate.SetException(exception);

        _ = await Assert.That(() => Service.StartAsync(cancellationToken)).Throws<InvalidOperationException>();
        LogEntry[] expectedEntries = [
            new(15, LogLevel.Trace, "Hosted service starting"),
            new(1, LogLevel.Trace, "Service state Created -> Starting"),
            new(2, LogLevel.Trace, "Starting setup phase"),
            new(6, LogLevel.Error, "Service setup phase failed", exception),
            new(1, LogLevel.Trace, "Service state Starting -> Stopped"),
        ];
        await Assert.That(Logger.Entries).IsEquivalentTo(expectedEntries, CollectionOrdering.Matching);
    }

    [Test]
    public async Task StartAsync_WhenExecutionThrows_LogsExecuteFailedWithException(CancellationToken cancellationToken)
    {
        var exception = new InvalidOperationException("Execution failed.");
        Service.SetupGate.SetResult(true);
        Service.TeardownGate.SetResult(true);
        await Service.StartAsync(cancellationToken);
        await Service.ExecuteEntered;

        Service.ExecuteGate.SetException(exception);
        await Service.WaitUntilStoppedAsync();

        LogEntry[] expectedEntries = [
            new(15, LogLevel.Trace, "Hosted service starting"),
            new(1, LogLevel.Trace, "Service state Created -> Starting"),
            new(2, LogLevel.Trace, "Starting setup phase"),
            new(3, LogLevel.Trace, "Setup phase completed successfully"),
            new(1, LogLevel.Trace, "Service state Starting -> Running"),
            new(7, LogLevel.Trace, "Starting service execution"),
            new(10, LogLevel.Error, "Service execution failed", exception),
            new(1, LogLevel.Trace, "Service state Running -> Stopping"),
            new(11, LogLevel.Trace, "Starting teardown phase"),
            new(12, LogLevel.Trace, "Teardown phase completed"),
            new(1, LogLevel.Trace, "Service state Stopping -> Stopped"),
        ];
        await Assert.That(Logger.Entries).IsEquivalentTo(expectedEntries, CollectionOrdering.Matching);
    }

    [Test]
    public async Task StartAsync_WhenTeardownThrows_LogsTeardownFailedWithException(CancellationToken cancellationToken)
    {
        var exception = new InvalidOperationException("Teardown failed.");
        Service.SetupGate.SetResult(true);
        Service.ExecuteGate.SetResult(true);
        Service.TeardownGate.SetException(exception);

        await Service.StartAsync(cancellationToken);
        await Service.WaitUntilStoppedAsync();

        LogEntry[] expectedEntries = [
            new(15, LogLevel.Trace, "Hosted service starting"),
            new(1, LogLevel.Trace, "Service state Created -> Starting"),
            new(2, LogLevel.Trace, "Starting setup phase"),
            new(3, LogLevel.Trace, "Setup phase completed successfully"),
            new(1, LogLevel.Trace, "Service state Starting -> Running"),
            new(7, LogLevel.Trace, "Starting service execution"),
            new(8, LogLevel.Trace, "Service execution completed"),
            new(1, LogLevel.Trace, "Service state Running -> Stopping"),
            new(11, LogLevel.Trace, "Starting teardown phase"),
            new(13, LogLevel.Error, "Service teardown phase failed", exception),
            new(1, LogLevel.Trace, "Service state Stopping -> Stopped"),
        ];
        await Assert.That(Logger.Entries).IsEquivalentTo(expectedEntries, CollectionOrdering.Matching);
    }

    [Test]
    public async Task StopAsync_BeforeStart_LogsStopRequestWhileNotRunning(CancellationToken cancellationToken)
    {
        await Service.StopAsync(cancellationToken);

        LogEntry[] expectedEntries = [
            new(16, LogLevel.Trace, "Hosted service stopping"),
            new(1, LogLevel.Trace, "Service state Created -> Stopped"),
            new(14, LogLevel.Information, "Stop requested while service not running (Created)"),
        ];
        await Assert.That(Logger.Entries).IsEquivalentTo(expectedEntries, CollectionOrdering.Matching);
    }
}

#pragma warning restore CA1849 // Call async methods when in an async method
