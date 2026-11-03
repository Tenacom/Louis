// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

internal sealed class TestAsyncDisposable : IAsyncDisposable
{
    public int DisposeAsyncCallCount { get; private set; }

    public bool DisposeAsyncCompleted { get; private set; }

    public async ValueTask DisposeAsync()
    {
        DisposeAsyncCallCount++;
        await Task.Yield();
        DisposeAsyncCompleted = true;
    }
}
