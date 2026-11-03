// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

internal sealed class DualDisposableItem : IDisposable, IAsyncDisposable
{
    public int DisposeCallCount { get; private set; }

    public int DisposeAsyncCallCount { get; private set; }

    public void Dispose() => DisposeCallCount++;

    public ValueTask DisposeAsync()
    {
        DisposeAsyncCallCount++;
        return default;
    }
}
