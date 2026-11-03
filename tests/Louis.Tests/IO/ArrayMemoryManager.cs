// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Buffers;
using System.Runtime.InteropServices;

/// <summary>
/// A <see cref="MemoryManager{T}"/> over a byte array that does not expose the array,
/// so that <see cref="MemoryMarshal.TryGetArray{T}(ReadOnlyMemory{T}, out ArraySegment{T})"/> fails on its memory,
/// as it does on memory that no array backs.
/// </summary>
internal sealed class ArrayMemoryManager(byte[] array) : MemoryManager<byte>
{
    public override Span<byte> GetSpan() => array;

    public override MemoryHandle Pin(int elementIndex = 0) => throw new NotSupportedException();

    public override void Unpin()
    {
    }

    protected override void Dispose(bool disposing)
    {
    }
}
