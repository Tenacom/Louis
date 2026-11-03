// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

internal sealed class TestDisposable : IDisposable
{
    public int DisposeCallCount { get; private set; }

    public void Dispose() => DisposeCallCount++;
}
