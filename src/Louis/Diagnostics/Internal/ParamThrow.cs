// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Louis.Diagnostics.Internal;

// Each method holds a throw statement alone, so that the JIT compiler inlines a check and leaves the throw out of line.
// The runtime honors StackTraceHiddenAttribute in the builds for .NET 6 and later alone.
// In the other builds the attribute is the type that PolySharp generates, which no runtime looks for.
// On older runtimes, StackTraceHiddenAttribute can only be detected by a custom stack trace formatter
// that looks for it by name.
[StackTraceHidden]
internal static class ParamThrow
{
    [DoesNotReturn]
    public static void Null(string name) => throw new ArgumentNullException(name, $"{name} cannot be null.");

    [DoesNotReturn]
    public static void Empty(string name) => throw new ArgumentException($"{name} cannot be empty.", name);

    [DoesNotReturn]
    public static void WhiteSpace(string name)
        => throw new ArgumentException($"{name} cannot be empty or consist only of white-space characters.", name);
}
