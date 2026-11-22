// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

namespace Louis.Diagnostics;

/// <summary>
/// Holds the value and the name of a span parameter, for a chain of checks.
/// </summary>
/// <typeparam name="T">The type of the items of the span.</typeparam>
/// <remarks>
/// <para><see cref="Param.Check{T}(Span{T}, string)"/> starts a chain of checks, and returns an instance of this type.
/// <see cref="SpanParamExtensions"/> provides the checks.
/// The <see cref="Value"/> property ends the chain.</para>
/// </remarks>
public readonly ref struct SpanParam<T>
{
    internal SpanParam(Span<T> value, string name)
    {
        Value = value;
        Name = name;
    }

    /// <summary>
    /// Gets the value of the parameter.
    /// </summary>
    public Span<T> Value { get; }

    /// <summary>
    /// Gets the name of the parameter.
    /// </summary>
    public string Name { get; }
}
