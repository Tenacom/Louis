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
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter does not satisfy a condition.
        /// </summary>
        /// <param name="predicate">A function to test the value for a condition.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="predicate"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="predicate"/> returns <see langword="false"/>
        /// for the value of <paramref name="this"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> Checked(Func<T, bool> predicate, string? message = null)
        {
            Param.NotNull(predicate);
            if (!predicate(@this.Value))
            {
                ParamThrow.Invalid(@this.Name, @this.Value, message);
            }

            return @this;
        }
    }
}
