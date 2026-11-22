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
        where T : struct, IEquatable<T>
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter is not the default value of its type.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// is not equal to the default value of <typeparamref name="T"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> Default(string? message = null)
        {
            if (!@this.Value.Equals(default))
            {
                ParamThrow.NotDefault(@this.Name, @this.Value, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter is the default value of its type.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// is equal to the default value of <typeparamref name="T"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> NotDefault(string? message = null)
        {
            if (@this.Value.Equals(default))
            {
                ParamThrow.Default(@this.Name, @this.Value, message);
            }

            return @this;
        }
    }

    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <param name="this">The <see cref="Param{T}"/> that holds the value to check.</param>
    extension<T>(Param<T> @this)
        where T : IEquatable<T>
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter is not equal to a specified value.
        /// </summary>
        /// <param name="target">The value to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is <paramref name="target"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// is not equal to <paramref name="target"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> EqualTo(T target, string? message = null)
        {
            if (!@this.Value.Equals(target))
            {
                ParamThrow.NotEqualTo(@this.Name, @this.Value, target, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter is equal to a specified value.
        /// </summary>
        /// <param name="target">The value to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is <paramref name="target"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// is equal to <paramref name="target"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> NotEqualTo(T target, string? message = null)
        {
            if (@this.Value.Equals(target))
            {
                ParamThrow.EqualTo(@this.Name, @this.Value, target, message);
            }

            return @this;
        }
    }

    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <param name="this">The <see cref="Param{T}"/> that holds the value to check.</param>
    extension<T>(Param<T> @this)
        where T : unmanaged
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter does not have the same bytes
        /// as a specified value.
        /// </summary>
        /// <param name="target">The value to compare with.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is <paramref name="target"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// and <paramref name="target"/> differ by at least one byte.</exception>
        /// <remarks>
        /// <para>The comparison covers every byte of the two values, the padding bytes of a structure included.</para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> BitwiseEqualTo(T target, string? message = null)
        {
            if (!BitwiseEquals(@this.Value, target))
            {
                ParamThrow.NotBitwiseEqualTo(@this.Name, @this.Value, target, message);
            }

            return @this;
        }
    }
}
