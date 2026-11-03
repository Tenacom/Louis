// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections;

/// <summary>
/// Wraps a sequence and counts the calls to <see cref="IEnumerable{T}.GetEnumerator"/>,
/// so that a test can tell whether a method enumerated the sequence.
/// </summary>
/// <typeparam name="T">The type of the elements of the sequence.</typeparam>
internal sealed class RecordingEnumerable<T>(IEnumerable<T> items) : IEnumerable<T>
{
    public int GetEnumeratorCallCount { get; private set; }

    public IEnumerator<T> GetEnumerator()
    {
        GetEnumeratorCallCount++;
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
