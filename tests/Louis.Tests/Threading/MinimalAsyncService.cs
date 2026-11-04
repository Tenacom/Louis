// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;

// An AsyncService that overrides ExecuteAsync alone, as the simplest subclass a consumer writes does.
// A run of it reaches the default SetupAsync, TeardownAsync, and log hooks of AsyncService.
internal sealed class MinimalAsyncService : AsyncService
{
    private readonly TaskCompletionSource<bool> _executeEntered = new(TaskCreationOptions.RunContinuationsAsynchronously);

    public Task ExecuteEntered => _executeEntered.Task;

    // ExecuteAsync waits for this gate, or for the cancellation of its token, whichever comes first.
    public TaskCompletionSource<bool> ExecuteGate { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
#if NETSTANDARD2_1 || NETCOREAPP
        // CancellationTokenRegistration has no DisposeAsync before .NET Standard 2.1
        await
#endif
        using var registration = cancellationToken.Register(() => _ = ExecuteGate.TrySetCanceled(cancellationToken));
        _executeEntered.SetResult(true);
        _ = await ExecuteGate.Task;
    }
}
