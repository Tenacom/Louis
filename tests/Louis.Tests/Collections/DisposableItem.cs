// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

/// <summary>
/// An <see cref="IDisposable"/> that counts the calls to <see cref="Dispose"/>,
/// and throws the given exception from each of them.
/// </summary>
internal sealed class DisposableItem(Exception? exception = null) : IDisposable
{
    public int DisposeCallCount { get; private set; }

    public void Dispose()
    {
        DisposeCallCount++;
        if (exception is not null)
        {
            throw exception;
        }
    }
}
