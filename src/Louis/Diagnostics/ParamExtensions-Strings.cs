// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using Louis.Diagnostics.Internal;

namespace Louis.Diagnostics;

// HasSizeEqualTo and HasSizeLessThanOrEqualTo have a form that takes a size and a form that takes a string,
// both with an optional message.
// The two forms differ by the type of their first argument, so a call that omits the message is not ambiguous.
#pragma warning disable RS0026 // Do not add multiple public overloads with optional parameters

partial class ParamExtensions
{
    /// <param name="this">The <see cref="Param{T}"/> that holds the string to check.</param>
    extension(Param<string?> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a string parameter
        /// is neither <see langword="null"/> nor empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// holds at least one character.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<string?> NullOrEmpty(string? message = null)
        {
            if (!string.IsNullOrEmpty(@this.Value))
            {
                ParamThrow.NotNullOrEmpty(@this.Name, @this.Value, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a string parameter
        /// holds a character that is not a white-space character.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// holds at least one character that is not a white-space character.</exception>
        /// <remarks>
        /// <para>The check passes if the value is <see langword="null"/>, empty,
        /// or consists only of white-space characters.</para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<string?> NullOrWhiteSpace(string? message = null)
        {
            if (!string.IsNullOrWhiteSpace(@this.Value))
            {
                ParamThrow.NotNullOrWhiteSpace(@this.Name, @this.Value, message);
            }

            return @this;
        }
    }

    /// <param name="this">The <see cref="Param{T}"/> that holds the string to check.</param>
    extension(Param<string> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a string parameter is not empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// holds at least one character.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<string> Empty(string? message = null)
        {
            if (@this.Value.Length != 0)
            {
                ParamThrow.NotEmpty(@this.Name, @this.Value, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a string parameter is empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/> is the empty string.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<string> NotEmpty(string? message = null)
        {
            if (@this.Value.Length == 0)
            {
                ParamThrow.Empty(@this.Name, @this.Value, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a string parameter
        /// holds a character that is not a white-space character.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// holds at least one character that is not a white-space character.</exception>
        /// <remarks>
        /// <para>The check passes if the value is empty, or consists only of white-space characters.</para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<string> WhiteSpace(string? message = null)
        {
            if (!@this.Value.AsSpan().IsWhiteSpace())
            {
                ParamThrow.NotWhiteSpace(@this.Name, @this.Value, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a string parameter is empty,
        /// or consists only of white-space characters.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/> is the empty string,
        /// or consists only of white-space characters.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<string> NotWhiteSpace(string? message = null)
        {
            if (@this.Value.AsSpan().IsWhiteSpace())
            {
                ParamThrow.WhiteSpace(@this.Name, @this.Value, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a string parameter
        /// does not have a specified length.
        /// </summary>
        /// <param name="size">The length that the value must have.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="size"/>, and <c>{3}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The length of the value of <paramref name="this"/>
        /// is not equal to <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<string> HasSizeEqualTo(int size, string? message = null)
        {
            if (@this.Value.Length != size)
            {
                ParamThrow.SizeNotEqualTo(@this.Name, @this.Value, size, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a string parameter
        /// does not have the same length as a specified string.
        /// </summary>
        /// <param name="other">The string whose length the value must have.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is the length of <paramref name="other"/>, and <c>{3}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">The length of the value of <paramref name="this"/>
        /// is not equal to the length of <paramref name="other"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<string> HasSizeEqualTo(string other, string? message = null)
        {
            Param.NotNull(other);
            if (@this.Value.Length != other.Length)
            {
                ParamThrow.SizeNotEqualTo(@this.Name, @this.Value, other.Length, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a string parameter has a specified length.
        /// </summary>
        /// <param name="size">The length that the value must not have.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="size"/>, and <c>{3}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The length of the value of <paramref name="this"/>
        /// is equal to <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<string> HasSizeNotEqualTo(int size, string? message = null)
        {
            if (@this.Value.Length == size)
            {
                ParamThrow.SizeEqualTo(@this.Name, @this.Value, size, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the length of the value of a string parameter
        /// is not greater than a specified value.
        /// </summary>
        /// <param name="size">The length to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="size"/>, and <c>{3}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The length of the value of <paramref name="this"/>
        /// is less than or equal to <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<string> HasSizeGreaterThan(int size, string? message = null)
        {
            if (@this.Value.Length <= size)
            {
                ParamThrow.SizeNotGreaterThan(@this.Name, @this.Value, size, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the length of the value of a string parameter
        /// is less than a specified value.
        /// </summary>
        /// <param name="size">The length to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="size"/>, and <c>{3}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The length of the value of <paramref name="this"/>
        /// is less than <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<string> HasSizeGreaterThanOrEqualTo(int size, string? message = null)
        {
            if (@this.Value.Length < size)
            {
                ParamThrow.SizeNotGreaterThanOrEqualTo(@this.Name, @this.Value, size, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the length of the value of a string parameter
        /// is not less than a specified value.
        /// </summary>
        /// <param name="size">The length to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="size"/>, and <c>{3}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The length of the value of <paramref name="this"/>
        /// is greater than or equal to <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<string> HasSizeLessThan(int size, string? message = null)
        {
            if (@this.Value.Length >= size)
            {
                ParamThrow.SizeNotLessThan(@this.Name, @this.Value, size, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the length of the value of a string parameter
        /// is greater than a specified value.
        /// </summary>
        /// <param name="size">The length to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="size"/>, and <c>{3}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The length of the value of <paramref name="this"/>
        /// is greater than <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<string> HasSizeLessThanOrEqualTo(int size, string? message = null)
        {
            if (@this.Value.Length > size)
            {
                ParamThrow.SizeNotLessThanOrEqualTo(@this.Name, @this.Value, size, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a string parameter
        /// is longer than a specified string.
        /// </summary>
        /// <param name="other">The string whose length to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is the length of <paramref name="other"/>, and <c>{3}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">The length of the value of <paramref name="this"/>
        /// is greater than the length of <paramref name="other"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<string> HasSizeLessThanOrEqualTo(string other, string? message = null)
        {
            Param.NotNull(other);
            if (@this.Value.Length > other.Length)
            {
                ParamThrow.SizeNotLessThanOrEqualTo(@this.Name, @this.Value, other.Length, @this.Value.Length, message);
            }

            return @this;
        }
    }

    /// <param name="this">The <see cref="Param{T}"/> that holds the index to check.</param>
    extension(Param<int> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is not the index of a character in a specified string.
        /// </summary>
        /// <param name="text">The string that the value must be an index in.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the length of <paramref name="text"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>The value of <paramref name="this"/> is less than zero.</para>
        /// <para>- or -</para>
        /// <para>The value of <paramref name="this"/> is greater than or equal to the length of <paramref name="text"/>.</para>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<int> InRangeFor(string text, string? message = null)
        {
            Param.NotNull(text);
            var isInRange = @this.Value >= 0 && @this.Value < text.Length;
            if (!isInRange)
            {
                ParamThrow.NotInRangeFor(@this.Name, @this.Value, text.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is the index of a character in a specified string.
        /// </summary>
        /// <param name="text">The string that the value must not be an index in.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the length of <paramref name="text"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The value of <paramref name="this"/>
        /// is greater than or equal to zero, and less than the length of <paramref name="text"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<int> NotInRangeFor(string text, string? message = null)
        {
            Param.NotNull(text);
            var isInRange = @this.Value >= 0 && @this.Value < text.Length;
            if (isInRange)
            {
                ParamThrow.InRangeFor(@this.Name, @this.Value, text.Length, message);
            }

            return @this;
        }
    }
}
