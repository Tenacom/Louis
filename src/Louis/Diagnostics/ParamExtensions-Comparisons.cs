// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using Louis.Diagnostics.Internal;

namespace Louis.Diagnostics;

partial class ParamExtensions
{
    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <param name="this">The <see cref="Param{T}"/> that holds the value to check.</param>
    extension<T>(Param<T> @this)
        where T : IComparable<T>
    {
        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is not less than a specified value.
        /// </summary>
        /// <param name="threshold">The value to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is <paramref name="threshold"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The value of <paramref name="this"/>
        /// is greater than or equal to <paramref name="threshold"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> LessThan(T threshold, string? message = null)
        {
            if (@this.Value.CompareTo(threshold) >= 0)
            {
                ParamThrow.NotLessThan(@this.Name, @this.Value, threshold, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is greater than a specified value.
        /// </summary>
        /// <param name="threshold">The value to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is <paramref name="threshold"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The value of <paramref name="this"/>
        /// is greater than <paramref name="threshold"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> LessThanOrEqualTo(T threshold, string? message = null)
        {
            if (@this.Value.CompareTo(threshold) > 0)
            {
                ParamThrow.NotLessThanOrEqualTo(@this.Name, @this.Value, threshold, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is not greater than a specified value.
        /// </summary>
        /// <param name="threshold">The value to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is <paramref name="threshold"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The value of <paramref name="this"/>
        /// is less than or equal to <paramref name="threshold"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> GreaterThan(T threshold, string? message = null)
        {
            if (@this.Value.CompareTo(threshold) <= 0)
            {
                ParamThrow.NotGreaterThan(@this.Name, @this.Value, threshold, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is less than a specified value.
        /// </summary>
        /// <param name="threshold">The value to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is <paramref name="threshold"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The value of <paramref name="this"/>
        /// is less than <paramref name="threshold"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> GreaterThanOrEqualTo(T threshold, string? message = null)
        {
            if (@this.Value.CompareTo(threshold) < 0)
            {
                ParamThrow.NotGreaterThanOrEqualTo(@this.Name, @this.Value, threshold, message);
            }

            return @this;
        }
    }
}
