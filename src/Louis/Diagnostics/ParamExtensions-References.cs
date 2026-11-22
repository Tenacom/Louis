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
        where T : class
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter is not a specified instance.
        /// </summary>
        /// <param name="target">The instance that the value must be.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is <paramref name="target"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// is not the same instance as <paramref name="target"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> ReferenceEqualTo(T target, string? message = null)
        {
            if (!ReferenceEquals(@this.Value, target))
            {
                ParamThrow.NotReferenceEqualTo(@this.Name, @this.Value, target, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter is a specified instance.
        /// </summary>
        /// <param name="target">The instance that the value must not be.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is <paramref name="target"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// is the same instance as <paramref name="target"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> ReferenceNotEqualTo(T target, string? message = null)
        {
            if (ReferenceEquals(@this.Value, target))
            {
                ParamThrow.ReferenceEqualTo(@this.Name, @this.Value, target, message);
            }

            return @this;
        }
    }
}
