// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
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
    /// <typeparam name="T">The type of the items of the list.</typeparam>
    /// <param name="this">The <see cref="Param{T}"/> that holds the list to check.</param>
    extension<T>(Param<IList<T>> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a list parameter
        /// does not have a specified number of items.
        /// </summary>
        /// <param name="size">The number of items that the value must have.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="size"/>, and <c>{3}</c> is the number of items of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The number of items of the value of <paramref name="this"/>
        /// is not equal to <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<IList<T>> HasSizeEqualTo(int size, string? message = null)
        {
            if (@this.Value.Count != size)
            {
                ParamThrow.SizeNotEqualTo(@this.Name, @this.Value, size, @this.Value.Count, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a list parameter
        /// does not have the same number of items as a specified collection.
        /// </summary>
        /// <param name="other">The collection whose number of items the value must have.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is the number of items of <paramref name="other"/>, and <c>{3}</c> is the number of items of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">The number of items of the value of <paramref name="this"/>
        /// is not equal to the number of items of <paramref name="other"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<IList<T>> HasSizeEqualTo(ICollection<T> other, string? message = null)
        {
            Param.NotNull(other);
            if (@this.Value.Count != other.Count)
            {
                ParamThrow.SizeNotEqualTo(@this.Name, @this.Value, other.Count, @this.Value.Count, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a list parameter
        /// has a specified number of items.
        /// </summary>
        /// <param name="size">The number of items that the value must not have.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="size"/>, and <c>{3}</c> is the number of items of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The number of items of the value of <paramref name="this"/>
        /// is equal to <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<IList<T>> HasSizeNotEqualTo(int size, string? message = null)
        {
            if (@this.Value.Count == size)
            {
                ParamThrow.SizeEqualTo(@this.Name, @this.Value, size, @this.Value.Count, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the number of items of the value of a list parameter
        /// is not greater than a specified value.
        /// </summary>
        /// <param name="size">The number of items to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="size"/>, and <c>{3}</c> is the number of items of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The number of items of the value of <paramref name="this"/>
        /// is less than or equal to <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<IList<T>> HasSizeGreaterThan(int size, string? message = null)
        {
            if (@this.Value.Count <= size)
            {
                ParamThrow.SizeNotGreaterThan(@this.Name, @this.Value, size, @this.Value.Count, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the number of items of the value of a list parameter
        /// is less than a specified value.
        /// </summary>
        /// <param name="size">The number of items to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="size"/>, and <c>{3}</c> is the number of items of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The number of items of the value of <paramref name="this"/>
        /// is less than <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<IList<T>> HasSizeGreaterThanOrEqualTo(int size, string? message = null)
        {
            if (@this.Value.Count < size)
            {
                ParamThrow.SizeNotGreaterThanOrEqualTo(@this.Name, @this.Value, size, @this.Value.Count, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the number of items of the value of a list parameter
        /// is not less than a specified value.
        /// </summary>
        /// <param name="size">The number of items to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="size"/>, and <c>{3}</c> is the number of items of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The number of items of the value of <paramref name="this"/>
        /// is greater than or equal to <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<IList<T>> HasSizeLessThan(int size, string? message = null)
        {
            if (@this.Value.Count >= size)
            {
                ParamThrow.SizeNotLessThan(@this.Name, @this.Value, size, @this.Value.Count, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the number of items of the value of a list parameter
        /// is greater than a specified value.
        /// </summary>
        /// <param name="size">The number of items to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="size"/>, and <c>{3}</c> is the number of items of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The number of items of the value of <paramref name="this"/>
        /// is greater than <paramref name="size"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<IList<T>> HasSizeLessThanOrEqualTo(int size, string? message = null)
        {
            if (@this.Value.Count > size)
            {
                ParamThrow.SizeNotLessThanOrEqualTo(@this.Name, @this.Value, size, @this.Value.Count, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a list parameter
        /// holds more items than a specified collection.
        /// </summary>
        /// <param name="other">The collection whose number of items to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is the number of items of <paramref name="other"/>, and <c>{3}</c> is the number of items of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">The number of items of the value of <paramref name="this"/>
        /// is greater than the number of items of <paramref name="other"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<IList<T>> HasSizeLessThanOrEqualTo(ICollection<T> other, string? message = null)
        {
            Param.NotNull(other);
            if (@this.Value.Count > other.Count)
            {
                ParamThrow.SizeNotLessThanOrEqualTo(@this.Name, @this.Value, other.Count, @this.Value.Count, message);
            }

            return @this;
        }
    }
}
