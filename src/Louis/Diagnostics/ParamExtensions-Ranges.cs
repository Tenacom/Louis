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
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter is outside a range
        /// that includes its lower bound and excludes its upper bound.
        /// </summary>
        /// <param name="minimum">The inclusive lower bound of the range.</param>
        /// <param name="maximum">The exclusive upper bound of the range.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="minimum"/>, and <c>{3}</c> is <paramref name="maximum"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>The value of <paramref name="this"/> is less than <paramref name="minimum"/>.</para>
        /// <para>- or -</para>
        /// <para>The value of <paramref name="this"/> is greater than or equal to <paramref name="maximum"/>.</para>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> InRange(T minimum, T maximum, string? message = null)
        {
            var isInRange = @this.Value.CompareTo(minimum) >= 0 && @this.Value.CompareTo(maximum) < 0;
            if (!isInRange)
            {
                ParamThrow.NotInRange(@this.Name, @this.Value, minimum, maximum, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter is inside a range
        /// that includes its lower bound and excludes its upper bound.
        /// </summary>
        /// <param name="minimum">The inclusive lower bound of the range.</param>
        /// <param name="maximum">The exclusive upper bound of the range.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="minimum"/>, and <c>{3}</c> is <paramref name="maximum"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The value of <paramref name="this"/>
        /// is greater than or equal to <paramref name="minimum"/>, and less than <paramref name="maximum"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> NotInRange(T minimum, T maximum, string? message = null)
        {
            var isInRange = @this.Value.CompareTo(minimum) >= 0 && @this.Value.CompareTo(maximum) < 0;
            if (isInRange)
            {
                ParamThrow.InRange(@this.Name, @this.Value, minimum, maximum, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter is not between two values,
        /// both excluded.
        /// </summary>
        /// <param name="minimum">The exclusive lower bound of the range.</param>
        /// <param name="maximum">The exclusive upper bound of the range.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="minimum"/>, and <c>{3}</c> is <paramref name="maximum"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>The value of <paramref name="this"/> is less than or equal to <paramref name="minimum"/>.</para>
        /// <para>- or -</para>
        /// <para>The value of <paramref name="this"/> is greater than or equal to <paramref name="maximum"/>.</para>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> Between(T minimum, T maximum, string? message = null)
        {
            var isBetween = @this.Value.CompareTo(minimum) > 0 && @this.Value.CompareTo(maximum) < 0;
            if (!isBetween)
            {
                ParamThrow.NotBetween(@this.Name, @this.Value, minimum, maximum, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter is between two values,
        /// both excluded.
        /// </summary>
        /// <param name="minimum">The exclusive lower bound of the range.</param>
        /// <param name="maximum">The exclusive upper bound of the range.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="minimum"/>, and <c>{3}</c> is <paramref name="maximum"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The value of <paramref name="this"/>
        /// is greater than <paramref name="minimum"/>, and less than <paramref name="maximum"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> NotBetween(T minimum, T maximum, string? message = null)
        {
            var isBetween = @this.Value.CompareTo(minimum) > 0 && @this.Value.CompareTo(maximum) < 0;
            if (isBetween)
            {
                ParamThrow.Between(@this.Name, @this.Value, minimum, maximum, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter is not between two values,
        /// both included.
        /// </summary>
        /// <param name="minimum">The inclusive lower bound of the range.</param>
        /// <param name="maximum">The inclusive upper bound of the range.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="minimum"/>, and <c>{3}</c> is <paramref name="maximum"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>The value of <paramref name="this"/> is less than <paramref name="minimum"/>.</para>
        /// <para>- or -</para>
        /// <para>The value of <paramref name="this"/> is greater than <paramref name="maximum"/>.</para>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> BetweenOrEqualTo(T minimum, T maximum, string? message = null)
        {
            var isBetween = @this.Value.CompareTo(minimum) >= 0 && @this.Value.CompareTo(maximum) <= 0;
            if (!isBetween)
            {
                ParamThrow.NotBetweenOrEqualTo(@this.Name, @this.Value, minimum, maximum, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter is between two values,
        /// both included.
        /// </summary>
        /// <param name="minimum">The inclusive lower bound of the range.</param>
        /// <param name="maximum">The inclusive upper bound of the range.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="minimum"/>, and <c>{3}</c> is <paramref name="maximum"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The value of <paramref name="this"/>
        /// is greater than or equal to <paramref name="minimum"/>, and less than or equal to <paramref name="maximum"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> NotBetweenOrEqualTo(T minimum, T maximum, string? message = null)
        {
            var isBetween = @this.Value.CompareTo(minimum) >= 0 && @this.Value.CompareTo(maximum) <= 0;
            if (isBetween)
            {
                ParamThrow.BetweenOrEqualTo(@this.Name, @this.Value, minimum, maximum, message);
            }

            return @this;
        }
    }
}
