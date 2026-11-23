// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Louis.Diagnostics.Internal;

namespace Louis.Diagnostics;

// HasSizeEqualTo and HasSizeLessThanOrEqualTo have a form that takes a size and a form that takes a span,
// both with an optional message.
// The two forms differ by the type of their first argument, so a call that omits the message is not ambiguous.
#pragma warning disable RS0026 // Do not add multiple public overloads with optional parameters

/// <summary>
/// Provides the checks of a chain that starts with <see cref="Param.Check{T}(Span{T}, string)"/>.
/// </summary>
/// <remarks>
/// <para>A check throws an exception if the value of the parameter is not valid.
/// Otherwise, it returns a <see cref="SpanParam{T}"/>, so that another check can follow.</para>
/// <para>Every check takes an optional message for the exception it throws.
/// The message is a composite format string, as the remarks of <see cref="ParamExtensions"/> describe it.
/// A span cannot be converted to an object, so the format item <c>{1}</c> is the text of the span,
/// as its <see cref="Span{T}.ToString"/> method returns it.
/// The text of a span of characters holds the characters.
/// The text of any other span holds the name of its type and its length.</para>
/// </remarks>
// The runtime honors StackTraceHiddenAttribute in the builds for .NET 6 and later alone.
// In the other builds the attribute is the type that src/Louis/Polyfills declares, which no runtime looks for.
// On older runtimes, StackTraceHiddenAttribute can only be detected by a custom stack trace formatter
// that looks for it by name.
[StackTraceHidden]
public static class SpanParamExtensions
{
    /// <typeparam name="T">The type of the items of the span.</typeparam>
    /// <param name="this">The <see cref="SpanParam{T}"/> that holds the span to check.</param>
    extension<T>(SpanParam<T> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a span parameter is not empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its text,
        /// and <c>{2}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// holds at least one item.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SpanParam<T> Empty(string? message = null)
        {
            if (@this.Value.Length != 0)
            {
                ParamThrow.CollectionNotEmpty(@this.Name, @this.Value.ToString(), @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a span parameter is empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its text.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/> holds no item.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SpanParam<T> NotEmpty(string? message = null)
        {
            if (@this.Value.Length == 0)
            {
                ParamThrow.Empty(@this.Name, @this.Value.ToString(), message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a span parameter
        /// does not have a specified length.
        /// </summary>
        /// <param name="size">The length that the value must have.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its text,
        /// <c>{2}</c> is <paramref name="size"/>, and <c>{3}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The length of the value of <paramref name="this"/>
        /// is not equal to <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SpanParam<T> HasSizeEqualTo(int size, string? message = null)
        {
            if (@this.Value.Length != size)
            {
                ParamThrow.SizeNotEqualTo(@this.Name, @this.Value.ToString(), size, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a span parameter
        /// does not have the same length as a specified read-only span.
        /// </summary>
        /// <param name="other">The read-only span whose length the value must have.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its text,
        /// <c>{2}</c> is the length of <paramref name="other"/>, and <c>{3}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The length of the value of <paramref name="this"/>
        /// is not equal to the length of <paramref name="other"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SpanParam<T> HasSizeEqualTo(ReadOnlySpan<T> other, string? message = null)
        {
            if (@this.Value.Length != other.Length)
            {
                ParamThrow.SizeNotEqualTo(@this.Name, @this.Value.ToString(), other.Length, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a span parameter
        /// has a specified length.
        /// </summary>
        /// <param name="size">The length that the value must not have.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its text,
        /// <c>{2}</c> is <paramref name="size"/>, and <c>{3}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The length of the value of <paramref name="this"/>
        /// is equal to <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SpanParam<T> HasSizeNotEqualTo(int size, string? message = null)
        {
            if (@this.Value.Length == size)
            {
                ParamThrow.SizeEqualTo(@this.Name, @this.Value.ToString(), size, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the length of the value of a span parameter
        /// is not greater than a specified value.
        /// </summary>
        /// <param name="size">The length to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its text,
        /// <c>{2}</c> is <paramref name="size"/>, and <c>{3}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The length of the value of <paramref name="this"/>
        /// is less than or equal to <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SpanParam<T> HasSizeGreaterThan(int size, string? message = null)
        {
            if (@this.Value.Length <= size)
            {
                ParamThrow.SizeNotGreaterThan(@this.Name, @this.Value.ToString(), size, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the length of the value of a span parameter
        /// is less than a specified value.
        /// </summary>
        /// <param name="size">The length to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its text,
        /// <c>{2}</c> is <paramref name="size"/>, and <c>{3}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The length of the value of <paramref name="this"/>
        /// is less than <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SpanParam<T> HasSizeGreaterThanOrEqualTo(int size, string? message = null)
        {
            if (@this.Value.Length < size)
            {
                ParamThrow.SizeNotGreaterThanOrEqualTo(@this.Name, @this.Value.ToString(), size, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the length of the value of a span parameter
        /// is not less than a specified value.
        /// </summary>
        /// <param name="size">The length to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its text,
        /// <c>{2}</c> is <paramref name="size"/>, and <c>{3}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The length of the value of <paramref name="this"/>
        /// is greater than or equal to <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SpanParam<T> HasSizeLessThan(int size, string? message = null)
        {
            if (@this.Value.Length >= size)
            {
                ParamThrow.SizeNotLessThan(@this.Name, @this.Value.ToString(), size, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the length of the value of a span parameter
        /// is greater than a specified value.
        /// </summary>
        /// <param name="size">The length to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its text,
        /// <c>{2}</c> is <paramref name="size"/>, and <c>{3}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The length of the value of <paramref name="this"/>
        /// is greater than <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SpanParam<T> HasSizeLessThanOrEqualTo(int size, string? message = null)
        {
            if (@this.Value.Length > size)
            {
                ParamThrow.SizeNotLessThanOrEqualTo(@this.Name, @this.Value.ToString(), size, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a span parameter
        /// is longer than a specified read-only span.
        /// </summary>
        /// <param name="other">The read-only span whose length to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its text,
        /// <c>{2}</c> is the length of <paramref name="other"/>, and <c>{3}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The length of the value of <paramref name="this"/>
        /// is greater than the length of <paramref name="other"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SpanParam<T> HasSizeLessThanOrEqualTo(ReadOnlySpan<T> other, string? message = null)
        {
            if (@this.Value.Length > other.Length)
            {
                ParamThrow.SizeNotLessThanOrEqualTo(@this.Name, @this.Value.ToString(), other.Length, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a span parameter does not satisfy a condition.
        /// </summary>
        /// <param name="predicate">A function to test the value for a condition.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its text.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="predicate"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="predicate"/> returns <see langword="false"/>
        /// for the value of <paramref name="this"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SpanParam<T> Checked(ReadOnlySpanPredicate<T> predicate, string? message = null)
        {
            Param.NotNull(predicate);
            if (!predicate(@this.Value))
            {
                ParamThrow.Invalid(@this.Name, @this.Value.ToString(), message);
            }

            return @this;
        }
    }

    /// <param name="this">The <see cref="SpanParam{T}"/> that holds the span of characters to check.</param>
    extension(SpanParam<char> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter that is a span of characters
        /// holds a character that is not a white-space character.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its text.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// holds at least one character that is not a white-space character.</exception>
        /// <remarks>
        /// <para>The check passes if the value is empty, or consists only of white-space characters.</para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SpanParam<char> WhiteSpace(string? message = null)
        {
            if (!@this.Value.IsWhiteSpace())
            {
                ParamThrow.NotWhiteSpace(@this.Name, @this.Value.ToString(), message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter that is a span of characters
        /// is empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its text.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/> is empty,
        /// or consists only of white-space characters.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SpanParam<char> NotWhiteSpace(string? message = null)
        {
            if (@this.Value.IsWhiteSpace())
            {
                ParamThrow.WhiteSpace(@this.Name, @this.Value.ToString(), message);
            }

            return @this;
        }
    }
}
