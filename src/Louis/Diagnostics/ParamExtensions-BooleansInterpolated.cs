// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET6_0_OR_GREATER

using System;
using System.Runtime.CompilerServices;
using System.Text;
using Louis.Diagnostics.Internal;
using Louis.Text;

namespace Louis.Diagnostics;

// A handler is a mutable struct, and ToStringAndClear resets it. A check takes the handler by reference,
// as Debug.Assert and StringBuilder.Append do, so that ToStringAndClear resets the handler the compiler built, not a copy.
#pragma warning disable CA1045 // Do not pass types by reference

partial class ParamExtensions
{
    /// <param name="this">The <see cref="Param{T}"/> that holds the value to check.</param>
    extension(Param<bool> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a Boolean parameter is <see langword="false"/>,
        /// with an interpolated string as the message of the exception.
        /// </summary>
        /// <param name="message">The interpolated string to use as the message of the exception.
        /// It is formatted only if the check fails, and it is not processed as a composite format string.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/> is <see langword="false"/>.</exception>
        /// <remarks>
        /// <para>This method is not available in the <c>netstandard</c> and .NET Framework builds of Louis,
        /// because their BCL has no <see cref="StringBuilder.AppendInterpolatedStringHandler"/>.</para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<bool> True(
            [InterpolatedStringHandlerArgument(nameof(@this))] ref FalseConditionInterpolatedStringHandler message)
        {
            if (!@this.Value)
            {
                ParamThrow.Argument(@this.Name, message.ToStringAndClear());
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a Boolean parameter is <see langword="true"/>,
        /// with an interpolated string as the message of the exception.
        /// </summary>
        /// <param name="message">The interpolated string to use as the message of the exception.
        /// It is formatted only if the check fails, and it is not processed as a composite format string.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/> is <see langword="true"/>.</exception>
        /// <remarks>
        /// <para>This method is not available in the <c>netstandard</c> and .NET Framework builds of Louis,
        /// because their BCL has no <see cref="StringBuilder.AppendInterpolatedStringHandler"/>.</para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<bool> False(
            [InterpolatedStringHandlerArgument(nameof(@this))] ref TrueConditionInterpolatedStringHandler message)
        {
            if (@this.Value)
            {
                ParamThrow.Argument(@this.Name, message.ToStringAndClear());
            }

            return @this;
        }
    }
}

#endif
