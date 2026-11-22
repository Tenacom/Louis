// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Louis.Diagnostics.Internal;

namespace Louis.Diagnostics;

// The optional parameter of each check is the name that the compiler supplies.
// The overloads of a check differ by the type of the checked argument, so a call that omits the name is not ambiguous.
#pragma warning disable RS0026 // Do not add multiple public overloads with optional parameters

/// <summary>
/// Provides methods to check the arguments of a method.
/// </summary>
/// <remarks>
/// <para>A check throws an exception if its argument is not valid.</para>
/// <para>A direct check, such as <c>NotNull</c>, returns the argument,
/// so that a check and an assignment fit in one expression.</para>
/// <para>The <c>Check</c> and <c>CheckNotNull</c> methods start a chain of checks on an argument,
/// and return a <see cref="Param{T}"/>.
/// For a span, <c>Check</c> returns a <see cref="ReadOnlySpanParam{T}"/> or a <see cref="SpanParam{T}"/>.
/// The <c>Value</c> property of each of these types ends the chain.</para>
/// <para>Every method takes the name of the parameter as its last argument.
/// If you omit it, the compiler supplies the expression passed as the argument to check.</para>
/// </remarks>
/// <example>
/// <para>The following code checks the arguments of a constructor:</para>
/// <code>
/// public Customer(string name, Address address)
/// {
///     Name = Param.NotNullOrWhiteSpace(name);
///     Address = Param.NotNull(address);
/// }
/// </code>
/// </example>
// The runtime honors StackTraceHiddenAttribute in the builds for .NET 6 and later alone.
// In the other builds the attribute is the type that PolySharp generates, which no runtime looks for.
// On older runtimes, StackTraceHiddenAttribute can only be detected by a custom stack trace formatter
// that looks for it by name.
[StackTraceHidden]
public static class Param
{
    /// <summary>
    /// Throws an <see cref="ArgumentNullException"/> if an argument is <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
    /// <param name="value">The argument to check.</param>
    /// <param name="name">The name of the parameter with which <paramref name="value"/> corresponds.
    /// If you omit this argument, the compiler supplies the expression passed as <paramref name="value"/>.</param>
    /// <returns>The value of <paramref name="value"/>, which is not <see langword="null"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T NotNull<T>(
        [ValidatedNotNull, NotNull] T? value,
        [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value is null)
        {
            ParamThrow.Null(name);
        }

        return value;
    }

    /// <summary>
    /// Throws an <see cref="ArgumentNullException"/> if an argument of a nullable value type is <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The underlying value type of <paramref name="value"/>.</typeparam>
    /// <param name="value">The argument to check.</param>
    /// <param name="name">The name of the parameter with which <paramref name="value"/> corresponds.
    /// If you omit this argument, the compiler supplies the expression passed as <paramref name="value"/>.</param>
    /// <returns>The underlying value of <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T NotNull<T>(
        [ValidatedNotNull, NotNull] T? value,
        [CallerArgumentExpression(nameof(value))] string name = "")
        where T : struct
    {
        if (!value.HasValue)
        {
            ParamThrow.Null(name);
        }

        return value.GetValueOrDefault();
    }

    /// <summary>
    /// Throws an exception if a string argument is <see langword="null"/> or empty.
    /// </summary>
    /// <param name="value">The argument to check.</param>
    /// <param name="name">The name of the parameter with which <paramref name="value"/> corresponds.
    /// If you omit this argument, the compiler supplies the expression passed as <paramref name="value"/>.</param>
    /// <returns>The value of <paramref name="value"/>, which is neither <see langword="null"/> nor empty.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> is the empty string.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string NotNullOrEmpty(
        [ValidatedNotNull, NotNull] string? value,
        [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value is null)
        {
            ParamThrow.Null(name);
        }

        if (value.Length == 0)
        {
            ParamThrow.Empty(name);
        }

        return value;
    }

    /// <summary>
    /// Throws an exception if a string argument is <see langword="null"/>, empty,
    /// or consists only of white-space characters.
    /// </summary>
    /// <param name="value">The argument to check.</param>
    /// <param name="name">The name of the parameter with which <paramref name="value"/> corresponds.
    /// If you omit this argument, the compiler supplies the expression passed as <paramref name="value"/>.</param>
    /// <returns>The value of <paramref name="value"/>, which holds at least one character
    /// that is not a white-space character.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> is the empty string,
    /// or consists only of white-space characters.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string NotNullOrWhiteSpace(
        [ValidatedNotNull, NotNull] string? value,
        [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value is null)
        {
            ParamThrow.Null(name);
        }

        if (value.AsSpan().IsWhiteSpace())
        {
            ParamThrow.WhiteSpace(name);
        }

        return value;
    }

    /// <summary>
    /// Throws an <see cref="ArgumentException"/> if a span of characters is empty.
    /// </summary>
    /// <param name="value">The argument to check.</param>
    /// <param name="name">The name of the parameter with which <paramref name="value"/> corresponds.
    /// If you omit this argument, the compiler supplies the expression passed as <paramref name="value"/>.</param>
    /// <returns>The value of <paramref name="value"/>, which is not empty.</returns>
    /// <exception cref="ArgumentException"><paramref name="value"/> is empty.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<char> NotEmpty(
        ReadOnlySpan<char> value,
        [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value.IsEmpty)
        {
            ParamThrow.Empty(name);
        }

        return value;
    }

    /// <summary>
    /// Throws an <see cref="ArgumentException"/> if a span of characters is empty,
    /// or consists only of white-space characters.
    /// </summary>
    /// <param name="value">The argument to check.</param>
    /// <param name="name">The name of the parameter with which <paramref name="value"/> corresponds.
    /// If you omit this argument, the compiler supplies the expression passed as <paramref name="value"/>.</param>
    /// <returns>The value of <paramref name="value"/>, which holds at least one character
    /// that is not a white-space character.</returns>
    /// <exception cref="ArgumentException"><paramref name="value"/> is empty,
    /// or consists only of white-space characters.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<char> NotWhiteSpace(
        ReadOnlySpan<char> value,
        [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value.IsWhiteSpace())
        {
            ParamThrow.WhiteSpace(name);
        }

        return value;
    }

    /// <summary>
    /// Starts a chain of checks on an argument.
    /// </summary>
    /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
    /// <param name="value">The argument to check.</param>
    /// <param name="name">The name of the parameter with which <paramref name="value"/> corresponds.
    /// If you omit this argument, the compiler supplies the expression passed as <paramref name="value"/>.</param>
    /// <returns>A <see cref="Param{T}"/> that holds <paramref name="value"/> and <paramref name="name"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Param<T> Check<T>(T value, [CallerArgumentExpression(nameof(value))] string name = "")
        => new(value, name);

    /// <summary>
    /// Starts a chain of checks on a read-only span argument.
    /// </summary>
    /// <typeparam name="T">The type of the items of <paramref name="value"/>.</typeparam>
    /// <param name="value">The argument to check.</param>
    /// <param name="name">The name of the parameter with which <paramref name="value"/> corresponds.
    /// If you omit this argument, the compiler supplies the expression passed as <paramref name="value"/>.</param>
    /// <returns>A <see cref="ReadOnlySpanParam{T}"/> that holds <paramref name="value"/> and <paramref name="name"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpanParam<T> Check<T>(
        ReadOnlySpan<T> value,
        [CallerArgumentExpression(nameof(value))] string name = "")
        => new(value, name);

    /// <summary>
    /// Starts a chain of checks on a span argument.
    /// </summary>
    /// <typeparam name="T">The type of the items of <paramref name="value"/>.</typeparam>
    /// <param name="value">The argument to check.</param>
    /// <param name="name">The name of the parameter with which <paramref name="value"/> corresponds.
    /// If you omit this argument, the compiler supplies the expression passed as <paramref name="value"/>.</param>
    /// <returns>A <see cref="SpanParam{T}"/> that holds <paramref name="value"/> and <paramref name="name"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SpanParam<T> Check<T>(Span<T> value, [CallerArgumentExpression(nameof(value))] string name = "")
        => new(value, name);

#if NET9_0_OR_GREATER
    /// <summary>
    /// Starts a chain of checks on an argument whose type can be a ref struct.
    /// </summary>
    /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
    /// <param name="value">The argument to check.</param>
    /// <param name="name">The name of the parameter with which <paramref name="value"/> corresponds.
    /// If you omit this argument, the compiler supplies the expression passed as <paramref name="value"/>.</param>
    /// <returns>A <see cref="RefParam{T}"/> that holds <paramref name="value"/> and <paramref name="name"/>.</returns>
    /// <remarks>
    /// <para>This method is not available in the <c>netstandard</c> and .NET Framework builds of Louis,
    /// because their BCL has no <see cref="RuntimeFeature.ByRefLikeGenerics"/>.</para>
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static RefParam<T> CheckRef<T>(T value, [CallerArgumentExpression(nameof(value))] string name = "")
        where T : allows ref struct
        => new(value, name);
#endif

    /// <summary>
    /// Starts a chain of checks on an argument that must not be <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
    /// <param name="value">The argument to check.</param>
    /// <param name="name">The name of the parameter with which <paramref name="value"/> corresponds.
    /// If you omit this argument, the compiler supplies the expression passed as <paramref name="value"/>.</param>
    /// <returns>A <see cref="Param{T}"/> that holds <paramref name="value"/> and <paramref name="name"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Param<T> CheckNotNull<T>(
        [ValidatedNotNull, NotNull] T? value,
        [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value is null)
        {
            ParamThrow.Null(name);
        }

        return new(value, name);
    }

    /// <summary>
    /// Starts a chain of checks on an argument of a nullable value type that must not be <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The underlying value type of <paramref name="value"/>.</typeparam>
    /// <param name="value">The argument to check.</param>
    /// <param name="name">The name of the parameter with which <paramref name="value"/> corresponds.
    /// If you omit this argument, the compiler supplies the expression passed as <paramref name="value"/>.</param>
    /// <returns>A <see cref="Param{T}"/> that holds the underlying value of <paramref name="value"/>,
    /// and <paramref name="name"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Param<T> CheckNotNull<T>(
        [ValidatedNotNull, NotNull] T? value,
        [CallerArgumentExpression(nameof(value))] string name = "")
        where T : struct
    {
        if (!value.HasValue)
        {
            ParamThrow.Null(name);
        }

        return new(value.GetValueOrDefault(), name);
    }
}
