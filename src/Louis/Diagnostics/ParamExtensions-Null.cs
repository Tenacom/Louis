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
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter is not <see langword="null"/>.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/> is not <see langword="null"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> Null(string? message = null)
        {
            if (@this.Value is not null)
            {
                ParamThrow.NotNull(@this.Name, @this.Value, message);
            }

            return @this;
        }
    }
}
