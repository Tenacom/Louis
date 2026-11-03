// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Concurrent;
using Louis.Threading;

// An AsyncService whose phases wait on gates a test completes, and that records every phase and hook call.
internal sealed class TestAsyncService : AsyncService
{
    private readonly TaskCompletionSource<bool> _setupEntered = new(TaskCreationOptions.RunContinuationsAsynchronously);
    private readonly TaskCompletionSource<bool> _executeEntered = new(TaskCreationOptions.RunContinuationsAsynchronously);
    private readonly TaskCompletionSource<bool> _teardownEntered = new(TaskCreationOptions.RunContinuationsAsynchronously);
    private int _disposeResourcesCalls;

    // Each phase completes its "entered" task, then waits for its gate.
    // A gate completed before the phase runs lets the phase through at once.
    public Task SetupEntered => _setupEntered.Task;

    public Task ExecuteEntered => _executeEntered.Task;

    public Task TeardownEntered => _teardownEntered.Task;

    public TaskCompletionSource<bool> SetupGate { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

    public TaskCompletionSource<bool> ExecuteGate { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

    public TaskCompletionSource<bool> TeardownGate { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

    // The tokens SetupAsync and ExecuteAsync received.
    public CancellationToken SetupToken { get; private set; }

    public CancellationToken ExecuteToken { get; private set; }

    // The phases and the hooks, in call order. A hook with arguments records them in parentheses.
    public ConcurrentQueue<string> Calls { get; } = new();

    public Exception? SetupException { get; private set; }

    public Exception? ExecuteException { get; private set; }

    public Exception? TeardownException { get; private set; }

    public int DisposeResourcesCalls => Volatile.Read(ref _disposeResourcesCalls);

    // Completes every gate a test may still hold, so that a disposal does not wait forever.
    public void ReleaseGates()
    {
        _ = SetupGate.TrySetCanceled();
        _ = ExecuteGate.TrySetCanceled();
        _ = TeardownGate.TrySetResult(true);
    }

    protected override async ValueTask<bool> SetupAsync(CancellationToken cancellationToken)
    {
        Calls.Enqueue(nameof(SetupAsync));
        SetupToken = cancellationToken;
        _setupEntered.SetResult(true);
        return await SetupGate.Task;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        Calls.Enqueue(nameof(ExecuteAsync));
        ExecuteToken = cancellationToken;
        _executeEntered.SetResult(true);
        _ = await ExecuteGate.Task;
    }

    protected override async ValueTask TeardownAsync()
    {
        Calls.Enqueue(nameof(TeardownAsync));
        _teardownEntered.SetResult(true);
        _ = await TeardownGate.Task;
    }

    protected override ValueTask DisposeResourcesAsync()
    {
        Calls.Enqueue(nameof(DisposeResourcesAsync));
        _ = Interlocked.Increment(ref _disposeResourcesCalls);
        return default;
    }

    protected override void LogStateChanged(AsyncServiceState oldState, AsyncServiceState newState)
        => Calls.Enqueue($"{nameof(LogStateChanged)}({oldState}, {newState})");

    protected override void LogBeforeSetup() => Calls.Enqueue(nameof(LogBeforeSetup));

    protected override void LogSetupCompleted(bool success) => Calls.Enqueue($"{nameof(LogSetupCompleted)}({success})");

    protected override void LogSetupCanceled() => Calls.Enqueue(nameof(LogSetupCanceled));

    protected override void LogSetupFailed(Exception exception)
    {
        SetupException = exception;
        Calls.Enqueue(nameof(LogSetupFailed));
    }

    protected override void LogBeforeExecute() => Calls.Enqueue(nameof(LogBeforeExecute));

    protected override void LogExecuteCompleted() => Calls.Enqueue(nameof(LogExecuteCompleted));

    protected override void LogExecuteCanceled() => Calls.Enqueue(nameof(LogExecuteCanceled));

    protected override void LogExecuteFailed(Exception exception)
    {
        ExecuteException = exception;
        Calls.Enqueue(nameof(LogExecuteFailed));
    }

    protected override void LogBeforeTeardown() => Calls.Enqueue(nameof(LogBeforeTeardown));

    protected override void LogTeardownCompleted() => Calls.Enqueue(nameof(LogTeardownCompleted));

    protected override void LogTeardownFailed(Exception exception)
    {
        TeardownException = exception;
        Calls.Enqueue(nameof(LogTeardownFailed));
    }

    protected override void LogStopRequested(
        AsyncServiceState previousState,
        AsyncServiceState currentState,
        bool result)
        => Calls.Enqueue($"{nameof(LogStopRequested)}({previousState}, {currentState}, {result})");
}
