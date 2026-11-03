// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

/// <summary>
/// An <see cref="IAsyncDisposable"/> whose <see cref="DisposeAsync"/> yields before it completes,
/// so that the <see cref="ValueTask"/> it returns is pending when the caller receives it.
/// It counts the calls, and faults with the given exception instead of completing.
/// </summary>
internal sealed class AsyncDisposableItem(Exception? exception = null) : IAsyncDisposable
{
    public int DisposeAsyncCallCount { get; private set; }

    public bool DisposeAsyncCompleted { get; private set; }

    public async ValueTask DisposeAsync()
    {
        DisposeAsyncCallCount++;
        await Task.Yield();
        if (exception is not null)
        {
            throw exception;
        }

        DisposeAsyncCompleted = true;
    }
}
