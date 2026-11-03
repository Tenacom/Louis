// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

/// <summary>
/// Compares values in the reverse of their default order.
/// A range that is valid under this comparer is invalid under the default comparer,
/// so a result that this comparer produces proves that the method under test uses it.
/// </summary>
/// <typeparam name="T">The type of the values being compared.</typeparam>
internal sealed class ReverseComparer<T> : IComparer<T>
{
    public static ReverseComparer<T> Instance { get; } = new();

    // IComparer<T> accepts null arguments, and so does Comparer<T?>.Default.
    public int Compare(T? x, T? y) => Comparer<T?>.Default.Compare(y, x);
}
