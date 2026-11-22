// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Louis.Diagnostics;

partial class ParamExtensions
{
    private static bool BitwiseEquals<T>(T value, T target)
        where T : unmanaged
    {
        Span<T> values = stackalloc T[] { value, target };
        var bytes = MemoryMarshal.AsBytes(values);
        var size = bytes.Length / 2;
        return bytes[..size].SequenceEqual(bytes[size..]);
    }

    // The unsigned subtraction wraps around, and gives the distance also when the signed one would overflow.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint Distance(int value, int target)
        => unchecked(value >= target ? (uint)value - (uint)target : (uint)target - (uint)value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong Distance(long value, long target)
        => unchecked(value >= target ? (ulong)value - (ulong)target : (ulong)target - (ulong)value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static nuint Distance(nint value, nint target)
        => unchecked(value >= target ? (nuint)value - (nuint)target : (nuint)target - (nuint)value);
}
