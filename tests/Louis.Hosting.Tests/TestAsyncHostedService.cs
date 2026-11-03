// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Hosting;
using Microsoft.Extensions.Logging;

// An AsyncHostedService whose phases wait on gates a test completes.
// The log hooks are sealed in AsyncHostedService, so the logger passed to the constructor is the record of the calls.
internal sealed class TestAsyncHostedService(ILogger logger) : AsyncHostedService(logger)
{
    private readonly TaskCompletionSource<bool> _setupEntered = new(TaskCreationOptions.RunContinuationsAsynchronously);
    private readonly TaskCompletionSource<bool> _executeEntered = new(TaskCreationOptions.RunContinuationsAsynchronously);
    private readonly TaskCompletionSource<bool> _teardownEntered = new(TaskCreationOptions.RunContinuationsAsynchronously);

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

    // The values the two FailOnSetup* overrides return. A test sets them before StartAsync.
    public bool FailOnSetupNotStartedValue { get; set; } = true;

    public bool FailOnSetupUnsuccessfulValue { get; set; } = true;

    protected override bool FailOnSetupNotStarted => FailOnSetupNotStartedValue;

    protected override bool FailOnSetupUnsuccessful => FailOnSetupUnsuccessfulValue;

    // Completes every gate a test may still hold, so that a disposal does not wait forever.
    public void ReleaseGates()
    {
        _ = SetupGate.TrySetCanceled();
        _ = ExecuteGate.TrySetCanceled();
        _ = TeardownGate.TrySetResult(true);
    }

    protected override async ValueTask<bool> SetupAsync(CancellationToken cancellationToken)
    {
        SetupToken = cancellationToken;
        _setupEntered.SetResult(true);
        return await SetupGate.Task;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        ExecuteToken = cancellationToken;
        _executeEntered.SetResult(true);
        _ = await ExecuteGate.Task;
    }

    protected override async ValueTask TeardownAsync()
    {
        _teardownEntered.SetResult(true);
        _ = await TeardownGate.Task;
    }
}
