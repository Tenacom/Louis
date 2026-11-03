// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Diagnostics;
using Louis.Hosting.Internal;
using Louis.Threading;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Louis.Hosting;

/// <summary>
/// Subclasses <see cref="AsyncService"/>, providing support for logging and implementing <see cref="IHostedService"/>.
/// </summary>
public abstract partial class AsyncHostedService : AsyncService, IHostedService
{
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="AsyncHostedService"/> class.
    /// </summary>
    /// <param name="logger">An <see cref="ILogger"/> to use for logging.</param>
    protected AsyncHostedService(ILogger logger)
    {
        Guard.IsNotNull(logger);
        _logger = logger;
    }

    /// <summary>
    /// Gets a value indicating whether <see cref="StartAsync"/> will fail if
    /// the result of <see cref="AsyncService.StartAndWaitAsync"/> is <see cref="AsyncServiceSetupResult.NotStarted"/>.
    /// </summary>
    protected virtual bool FailOnSetupNotStarted => true;

    /// <summary>
    /// Gets a value indicating whether <see cref="StartAsync"/> will fail if
    /// the result of <see cref="AsyncService.StartAndWaitAsync"/> is <see cref="AsyncServiceSetupResult.Unsuccessful"/>.
    /// </summary>
    protected virtual bool FailOnSetupUnsuccessful => true;

    /// <inheritdoc/>
    /// <exception cref="InvalidOperationException">
    /// <para>The service has already been started.</para>
    /// <para>The result of <see cref="AsyncService.StartAndWaitAsync"/> is <see cref="AsyncServiceSetupResult.NotStarted"/>
    /// and <see cref="FailOnSetupNotStarted"/> is <see langword="true"/>.</para>
    /// <para>The result of <see cref="AsyncService.StartAndWaitAsync"/> is <see cref="AsyncServiceSetupResult.Unsuccessful"/>
    /// and <see cref="FailOnSetupUnsuccessful"/> is <see langword="true"/>.</para>
    /// </exception>
    /// <exception cref="OperationCanceledException">
    /// The setup phase was canceled, either through <paramref name="cancellationToken"/> or by a stop request.
    /// </exception>
    /// <remarks>
    /// <para>If <see cref="AsyncService.SetupAsync"/> throws an exception, this method throws the same exception.</para>
    /// </remarks>
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        LogHostedServiceStarting();
        var setupResult = await StartAndWaitAsync(cancellationToken).ConfigureAwait(false);
        switch (setupResult)
        {
            case AsyncServiceSetupResult.Successful:
            case AsyncServiceSetupResult.NotStarted when !FailOnSetupNotStarted:
            case AsyncServiceSetupResult.Unsuccessful when !FailOnSetupUnsuccessful:
                break;
            case AsyncServiceSetupResult.Canceled:
                ThrowHelper.ThrowOperationCanceledException("Service start was canceled.", cancellationToken);
                break;
            default:
                ThrowHelper.ThrowInvalidOperationException($"Service start failed ({setupResult}).");
                break;
        }
    }

    /// <inheritdoc/>
    /// <remarks>
    /// <para>This method requests the service to stop, then waits until either the service has stopped
    /// or <paramref name="cancellationToken"/> is canceled, whichever comes first.</para>
    /// </remarks>
    public async Task StopAsync(CancellationToken cancellationToken)
    {
        LogHostedServiceStopping();
        _ = await Task.WhenAny(StopAndWaitAsync(), Task.Delay(Timeout.Infinite, cancellationToken)).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [LoggerMessage(
        eventId: EventIds.AsyncHostedService.StateChanged,
        level: LogLevel.Trace,
        message: "Service state {oldState} -> {newState}")]
    protected sealed override partial void LogStateChanged(AsyncServiceState oldState, AsyncServiceState newState);

    /// <inheritdoc/>
    [LoggerMessage(
        eventId: EventIds.AsyncHostedService.BeforeSetup,
        level: LogLevel.Trace,
        message: "Starting setup phase")]
    protected sealed override partial void LogBeforeSetup();

    /// <inheritdoc/>
    protected sealed override void LogSetupCompleted(bool success)
    {
        if (success)
        {
            LogSetupSuccessful();
        }
        else
        {
            LogSetupNotSuccessful();
        }
    }

    /// <inheritdoc/>
    [LoggerMessage(
        eventId: EventIds.AsyncHostedService.SetupCanceled,
        level: LogLevel.Warning,
        message: "Service execution was canceled during setup phase")]
    protected sealed override partial void LogSetupCanceled();

    /// <inheritdoc/>
    [LoggerMessage(
        eventId: EventIds.AsyncHostedService.SetupFailed,
        level: LogLevel.Error,
        message: "Service setup phase failed")]
    protected sealed override partial void LogSetupFailed(Exception exception);

    /// <inheritdoc/>
    [LoggerMessage(
        eventId: EventIds.AsyncHostedService.BeforeExecute,
        level: LogLevel.Trace,
        message: "Starting service execution")]
    protected sealed override partial void LogBeforeExecute();

    /// <inheritdoc/>
    [LoggerMessage(
        eventId: EventIds.AsyncHostedService.ExecuteCompleted,
        level: LogLevel.Trace,
        message: "Service execution completed")]
    protected sealed override partial void LogExecuteCompleted();

    /// <inheritdoc/>
    [LoggerMessage(
        eventId: EventIds.AsyncHostedService.ExecuteCanceled,
        level: LogLevel.Warning,
        message: "Service execution was canceled")]
    protected sealed override partial void LogExecuteCanceled();

    /// <inheritdoc/>
    [LoggerMessage(
        eventId: EventIds.AsyncHostedService.ExecuteFailed,
        level: LogLevel.Error,
        message: "Service execution failed")]
    protected sealed override partial void LogExecuteFailed(Exception exception);

    /// <inheritdoc/>
    [LoggerMessage(
        eventId: EventIds.AsyncHostedService.BeforeTeardown,
        level: LogLevel.Trace,
        message: "Starting teardown phase")]
    protected sealed override partial void LogBeforeTeardown();

    /// <inheritdoc/>
    [LoggerMessage(
        eventId: EventIds.AsyncHostedService.TeardownCompleted,
        level: LogLevel.Trace,
        message: "Teardown phase completed")]
    protected sealed override partial void LogTeardownCompleted();

    /// <inheritdoc/>
    [LoggerMessage(
        eventId: EventIds.AsyncHostedService.TeardownFailed,
        level: LogLevel.Error,
        message: "Service teardown phase failed")]
    protected sealed override partial void LogTeardownFailed(Exception exception);

    /// <inheritdoc/>
    protected sealed override void LogStopRequested(
        AsyncServiceState previousState,
        AsyncServiceState currentState,
        bool result)
        => LogStopRequestedCore(previousState, result ? "running" : "not running");

    [LoggerMessage(
        eventId: EventIds.AsyncHostedService.StopRequested,
        level: LogLevel.Information,
        message: "Stop requested while service {running} ({previousState})")]
    private partial void LogStopRequestedCore(AsyncServiceState previousState, string running);

    [LoggerMessage(
        eventId: EventIds.AsyncHostedService.HostedServiceStarting,
        level: LogLevel.Trace,
        message: "Hosted service starting")]
    private partial void LogHostedServiceStarting();

    [LoggerMessage(
        eventId: EventIds.AsyncHostedService.HostedServiceStopping,
        level: LogLevel.Trace,
        message: "Hosted service stopping")]
    private partial void LogHostedServiceStopping();

    [LoggerMessage(
        eventId: EventIds.AsyncHostedService.SetupSuccessful,
        level: LogLevel.Trace,
        message: "Setup phase completed successfully")]
    private partial void LogSetupSuccessful();

    [LoggerMessage(
        eventId: EventIds.AsyncHostedService.SetupNotSuccessful,
        level: LogLevel.Warning,
        message: "Setup phase completed unsuccessfully")]
    private partial void LogSetupNotSuccessful();
}
