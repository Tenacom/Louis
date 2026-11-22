// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using Louis.Diagnostics.Internal;

namespace Louis.Diagnostics;

// In the builds for .NET 6 and later, each check has a second overload, which takes an interpolated string.
// The compiler passes an interpolated string to that overload, and any other message to the overload in this file,
// so no call can bind to both.
#pragma warning disable RS0027 // API with optional parameter(s) should have the most parameters amongst its public overloads

partial class ParamExtensions
{
    /// <param name="this">The <see cref="Param{T}"/> that holds the value to check.</param>
    extension(Param<bool> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a Boolean parameter is <see langword="false"/>.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/> is <see langword="false"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<bool> True(string? message = null)
        {
            if (!@this.Value)
            {
                ParamThrow.NotTrue(@this.Name, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a Boolean parameter is <see langword="true"/>.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/> is <see langword="true"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<bool> False(string? message = null)
        {
            if (@this.Value)
            {
                ParamThrow.NotFalse(@this.Name, message);
            }

            return @this;
        }
    }
}
