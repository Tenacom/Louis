// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET9_0_OR_GREATER

using System.Runtime.CompilerServices;

namespace Louis.Diagnostics;

/// <summary>
/// Holds the value and the name of a parameter whose type can be a ref struct, for a chain of checks.
/// </summary>
/// <typeparam name="T">The type of the parameter.</typeparam>
/// <remarks>
/// <para><see cref="Param.CheckRef{T}(T, string)"/> starts a chain of checks, and returns an instance of this type.
/// <see cref="RefParamExtensions"/> provides the checks.
/// The <see cref="Value"/> property ends the chain.</para>
/// <para>This type is not available in the <c>netstandard</c> and .NET Framework builds of Louis,
/// because their BCL has no <see cref="RuntimeFeature.ByRefLikeGenerics"/>.</para>
/// </remarks>
public readonly ref struct RefParam<T>
    where T : allows ref struct
{
    internal RefParam(T value, string name)
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

#endif
