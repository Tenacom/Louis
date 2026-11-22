// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using Louis.Diagnostics.Internal;

namespace Louis.Diagnostics;

// Each HasSize check has one form for each type of collection, all with an optional message.
// HasSizeEqualTo and HasSizeLessThanOrEqualTo also have a form that takes a size and a form that takes a collection.
// The forms differ by the type of the receiver or of the first argument, so a call that omits the message
// is not ambiguous.
#pragma warning disable RS0026 // Do not add multiple public overloads with optional parameters

partial class ParamExtensions
{
    /// <typeparam name="T">The type of the items of the <see cref="ReadOnlyMemory{T}"/>.</typeparam>
    /// <param name="this">The <see cref="Param{T}"/> that holds the <see cref="ReadOnlyMemory{T}"/> to check.</param>
    extension<T>(Param<ReadOnlyMemory<T>> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a <see cref="ReadOnlyMemory{T}"/> parameter
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
        public Param<ReadOnlyMemory<T>> HasSizeEqualTo(int size, string? message = null)
        {
            if (@this.Value.Length != size)
            {
                ParamThrow.SizeNotEqualTo(@this.Name, @this.Value, size, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a <see cref="ReadOnlyMemory{T}"/> parameter
        /// does not have the same length as a specified <see cref="ReadOnlyMemory{T}"/>.
        /// </summary>
        /// <param name="other">The <see cref="ReadOnlyMemory{T}"/> whose length the value must have.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is the length of <paramref name="other"/>, and <c>{3}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The length of the value of <paramref name="this"/>
        /// is not equal to the length of <paramref name="other"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<ReadOnlyMemory<T>> HasSizeEqualTo(ReadOnlyMemory<T> other, string? message = null)
        {
            if (@this.Value.Length != other.Length)
            {
                ParamThrow.SizeNotEqualTo(@this.Name, @this.Value, other.Length, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a <see cref="ReadOnlyMemory{T}"/> parameter
        /// has a specified length.
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
        public Param<ReadOnlyMemory<T>> HasSizeNotEqualTo(int size, string? message = null)
        {
            if (@this.Value.Length == size)
            {
                ParamThrow.SizeEqualTo(@this.Name, @this.Value, size, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the length of the value of a <see cref="ReadOnlyMemory{T}"/> parameter
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
        public Param<ReadOnlyMemory<T>> HasSizeGreaterThan(int size, string? message = null)
        {
            if (@this.Value.Length <= size)
            {
                ParamThrow.SizeNotGreaterThan(@this.Name, @this.Value, size, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the length of the value of a <see cref="ReadOnlyMemory{T}"/> parameter
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
        public Param<ReadOnlyMemory<T>> HasSizeGreaterThanOrEqualTo(int size, string? message = null)
        {
            if (@this.Value.Length < size)
            {
                ParamThrow.SizeNotGreaterThanOrEqualTo(@this.Name, @this.Value, size, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the length of the value of a <see cref="ReadOnlyMemory{T}"/> parameter
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
        public Param<ReadOnlyMemory<T>> HasSizeLessThan(int size, string? message = null)
        {
            if (@this.Value.Length >= size)
            {
                ParamThrow.SizeNotLessThan(@this.Name, @this.Value, size, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the length of the value of a <see cref="ReadOnlyMemory{T}"/> parameter
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
        public Param<ReadOnlyMemory<T>> HasSizeLessThanOrEqualTo(int size, string? message = null)
        {
            if (@this.Value.Length > size)
            {
                ParamThrow.SizeNotLessThanOrEqualTo(@this.Name, @this.Value, size, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a <see cref="ReadOnlyMemory{T}"/> parameter
        /// is longer than a specified <see cref="ReadOnlyMemory{T}"/>.
        /// </summary>
        /// <param name="other">The <see cref="ReadOnlyMemory{T}"/> whose length to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is the length of <paramref name="other"/>, and <c>{3}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The length of the value of <paramref name="this"/>
        /// is greater than the length of <paramref name="other"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<ReadOnlyMemory<T>> HasSizeLessThanOrEqualTo(ReadOnlyMemory<T> other, string? message = null)
        {
            if (@this.Value.Length > other.Length)
            {
                ParamThrow.SizeNotLessThanOrEqualTo(@this.Name, @this.Value, other.Length, @this.Value.Length, message);
            }

            return @this;
        }
    }
}
