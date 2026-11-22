// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Louis.Diagnostics.Internal;

// Each method holds a throw statement alone, so that the JIT compiler inlines a check and leaves the throw out of line.
// A method is named after the condition that makes a check fail: NotNull serves the check named Null.
// The runtime honors StackTraceHiddenAttribute in the builds for .NET 6 and later alone.
// In the other builds the attribute is the type that PolySharp generates, which no runtime looks for.
// On older runtimes, StackTraceHiddenAttribute can only be detected by a custom stack trace formatter
// that looks for it by name.
[StackTraceHidden]
internal static class ParamThrow
{
    private const string NotAssignableToMessage = "{0} ({1}) must be assignable to type {2}.";

    [DoesNotReturn]
    public static void Null(string name) => throw new ArgumentNullException(name, $"{name} cannot be null.");

    [DoesNotReturn]
    public static void Empty(string name) => throw new ArgumentException($"{name} cannot be empty.", name);

    [DoesNotReturn]
    public static void WhiteSpace(string name)
        => throw new ArgumentException($"{name} cannot be empty or consist only of white-space characters.", name);

    [DoesNotReturn]
    public static void Argument(string name, string message) => throw new ArgumentException(message, name);

    [DoesNotReturn]
    public static void NotNull<T>(string name, T value, string? message)
        => throw new ArgumentException(Format(message, "{0} ({1}) must be null.", name, value), name);

    [DoesNotReturn]
    public static void NotOfType<T>(string name, T value, Type type, string? message)
        => throw new ArgumentException(Format(message, "{0} ({1}) must be of type {2}.", name, value, type), name);

    [DoesNotReturn]
    public static void OfType<T>(string name, T value, Type type, string? message)
        => throw new ArgumentException(Format(message, "{0} ({1}) must not be of type {2}.", name, value, type), name);

    [DoesNotReturn]
    public static void NotAssignableTo<T>(string name, T value, Type type, string? message)
        => throw new ArgumentException(Format(message, NotAssignableToMessage, name, value, type), name);

    // The return type lets a check that changes the type of the chain end with a call to this method.
    [DoesNotReturn]
    public static Param<TTarget> NotAssignableTo<TTarget>(string name, object value, string? message)
        => throw new ArgumentException(Format(message, NotAssignableToMessage, name, value, typeof(TTarget)), name);

    [DoesNotReturn]
    public static void AssignableTo<T>(string name, T value, Type type, string? message)
        => throw new ArgumentException(
            Format(message, "{0} ({1}) must not be assignable to type {2}.", name, value, type),
            name);

    [DoesNotReturn]
    public static void NotReferenceEqualTo<T>(string name, T value, T target, string? message)
        => throw new ArgumentException(Format(message, "{0} ({1}) must be the same instance as {2}.", name, value, target), name);

    [DoesNotReturn]
    public static void ReferenceEqualTo<T>(string name, T value, T target, string? message)
        => throw new ArgumentException(
            Format(message, "{0} ({1}) must not be the same instance as {2}.", name, value, target),
            name);

    [DoesNotReturn]
    public static void NotTrue(string name, string? message)
        => throw new ArgumentException(Format(message, "{0} must be true.", name, false), name);

    [DoesNotReturn]
    public static void NotFalse(string name, string? message)
        => throw new ArgumentException(Format(message, "{0} must be false.", name, true), name);

    [DoesNotReturn]
    public static void Invalid<T>(string name, T value, string? message)
        => throw new ArgumentException(Format(message, "{0} ({1}) is not valid.", name, value), name);

    [DoesNotReturn]
    public static void NotDefault<T>(string name, T value, string? message)
        => throw new ArgumentException(Format(message, "{0} ({1}) must be the default value of its type.", name, value), name);

    [DoesNotReturn]
    public static void Default<T>(string name, T value, string? message)
        => throw new ArgumentException(Format(message, "{0} must not be the default value of its type.", name, value), name);

    [DoesNotReturn]
    public static void NotEqualTo<T>(string name, T value, T target, string? message)
        => throw new ArgumentException(Format(message, "{0} ({1}) must be equal to {2}.", name, value, target), name);

    [DoesNotReturn]
    public static void EqualTo<T>(string name, T value, T target, string? message)
        => throw new ArgumentException(Format(message, "{0} must not be equal to {2}.", name, value, target), name);

    [DoesNotReturn]
    public static void NotBitwiseEqualTo<T>(string name, T value, T target, string? message)
        => throw new ArgumentException(Format(message, "{0} ({1}) must be a bitwise match for {2}.", name, value, target), name);

    [DoesNotReturn]
    public static void NotLessThan<T>(string name, T value, T threshold, string? message)
        => throw new ArgumentOutOfRangeException(
            name,
            value,
            Format(message, "{0} ({1}) must be less than {2}.", name, value, threshold));

    [DoesNotReturn]
    public static void NotLessThanOrEqualTo<T>(string name, T value, T threshold, string? message)
        => throw new ArgumentOutOfRangeException(
            name,
            value,
            Format(message, "{0} ({1}) must be less than or equal to {2}.", name, value, threshold));

    [DoesNotReturn]
    public static void NotGreaterThan<T>(string name, T value, T threshold, string? message)
        => throw new ArgumentOutOfRangeException(
            name,
            value,
            Format(message, "{0} ({1}) must be greater than {2}.", name, value, threshold));

    [DoesNotReturn]
    public static void NotGreaterThanOrEqualTo<T>(string name, T value, T threshold, string? message)
        => throw new ArgumentOutOfRangeException(
            name,
            value,
            Format(message, "{0} ({1}) must be greater than or equal to {2}.", name, value, threshold));

    [DoesNotReturn]
    public static void NotInRange<T>(string name, T value, T minimum, T maximum, string? message)
        => throw new ArgumentOutOfRangeException(
            name,
            value,
            Format(message, "{0} ({1}) must be greater than or equal to {2}, and less than {3}.", name, value, minimum, maximum));

    [DoesNotReturn]
    public static void InRange<T>(string name, T value, T minimum, T maximum, string? message)
        => throw new ArgumentOutOfRangeException(
            name,
            value,
            Format(message, "{0} ({1}) must be less than {2}, or greater than or equal to {3}.", name, value, minimum, maximum));

    [DoesNotReturn]
    public static void NotBetween<T>(string name, T value, T minimum, T maximum, string? message)
        => throw new ArgumentOutOfRangeException(
            name,
            value,
            Format(message, "{0} ({1}) must be greater than {2}, and less than {3}.", name, value, minimum, maximum));

    [DoesNotReturn]
    public static void Between<T>(string name, T value, T minimum, T maximum, string? message)
        => throw new ArgumentOutOfRangeException(
            name,
            value,
            Format(
                message,
                "{0} ({1}) must be less than or equal to {2}, or greater than or equal to {3}.",
                name,
                value,
                minimum,
                maximum));

    [DoesNotReturn]
    public static void NotBetweenOrEqualTo<T>(string name, T value, T minimum, T maximum, string? message)
        => throw new ArgumentOutOfRangeException(
            name,
            value,
            Format(
                message,
                "{0} ({1}) must be greater than or equal to {2}, and less than or equal to {3}.",
                name,
                value,
                minimum,
                maximum));

    [DoesNotReturn]
    public static void BetweenOrEqualTo<T>(string name, T value, T minimum, T maximum, string? message)
        => throw new ArgumentOutOfRangeException(
            name,
            value,
            Format(message, "{0} ({1}) must be less than {2}, or greater than {3}.", name, value, minimum, maximum));

    [DoesNotReturn]
    public static void NotCloseTo<T, TDelta>(string name, T value, T target, TDelta delta, string? message)
        => throw new ArgumentException(Format(message, "{0} ({1}) must be within {3} of {2}.", name, value, target, delta), name);

    [DoesNotReturn]
    public static void CloseTo<T, TDelta>(string name, T value, T target, TDelta delta, string? message)
        => throw new ArgumentException(
            Format(message, "{0} ({1}) must not be within {3} of {2}.", name, value, target, delta),
            name);

    // {0} is the name of the parameter. The values follow, from {1} on, as ExceptionHelper.FormatObject formats them.
    // A message that is not a valid composite format string is used as it is.
    private static string Format(string? message, string defaultMessage, string name, params object?[] values)
    {
        var format = message ?? defaultMessage;
        var args = new object[values.Length + 1];
        args[0] = name;
        for (var i = 0; i < values.Length; i++)
        {
            args[i + 1] = ExceptionHelper.FormatObject(values[i]);
        }

        try
        {
            return string.Format(CultureInfo.InvariantCulture, format, args);
        }
        catch (FormatException)
        {
            return format;
        }
    }
}
