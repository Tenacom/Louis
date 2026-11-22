// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace Louis.Diagnostics;

#pragma warning disable CA1815 // Override equals and operator equals on value types - They would never be used anyway

/// <summary>
/// Holds the value and the name of a parameter, for a chain of checks.
/// </summary>
/// <typeparam name="T">The type of the parameter.</typeparam>
/// <remarks>
/// <para><see cref="Param.Check{T}(T, string)"/> and the <c>CheckNotNull</c> methods of <see cref="Param"/>
/// start a chain of checks, and return an instance of this type.
/// The <see cref="Value"/> property ends the chain.</para>
/// </remarks>
public readonly struct Param<T>
{
    internal Param(T value, string name)
    {
        Value = value;
        Name = name;
    }

    /// <summary>
    /// Gets the value of the parameter.
    /// </summary>
    public T Value { get; }

    /// <summary>
    /// Gets the name of the parameter.
    /// </summary>
    public string Name { get; }
}
