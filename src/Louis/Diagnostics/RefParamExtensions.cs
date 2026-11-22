// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET9_0_OR_GREATER

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Louis.Diagnostics.Internal;

namespace Louis.Diagnostics;

/// <summary>
/// Provides the checks of a chain that starts with <see cref="Param.CheckRef{T}(T, string)"/>.
/// </summary>
/// <remarks>
/// <para>A check throws an exception if the value of the parameter is not valid.
/// Otherwise, it returns a <see cref="RefParam{T}"/>, so that another check can follow.</para>
/// <para>Every check takes an optional message for the exception it throws.
/// The message is a composite format string, as the remarks of <see cref="ParamExtensions"/> describe it.
/// The format item <c>{0}</c> is the name of the parameter.
/// The value has no format item, because a ref struct cannot be converted to an object.</para>
/// <para>This type is not available in the <c>netstandard</c> and .NET Framework builds of Louis,
/// because their BCL has no <see cref="RuntimeFeature.ByRefLikeGenerics"/>.</para>
/// </remarks>
// The runtime honors StackTraceHiddenAttribute in the builds for .NET 6 and later alone.
// In the other builds the attribute is the type that PolySharp generates, which no runtime looks for.
// On older runtimes, StackTraceHiddenAttribute can only be detected by a custom stack trace formatter
// that looks for it by name.
[StackTraceHidden]
public static class RefParamExtensions
{
    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <param name="this">The <see cref="RefParam{T}"/> that holds the value to check.</param>
    extension<T>(RefParam<T> @this)
        where T : allows ref struct
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter does not satisfy a condition.
        /// </summary>
        /// <param name="predicate">A function to test the value for a condition.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="predicate"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="predicate"/> returns <see langword="false"/>
        /// for the value of <paramref name="this"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RefParam<T> Checked(Func<T, bool> predicate, string? message = null)
        {
            Param.NotNull(predicate);
            if (!predicate(@this.Value))
            {
                ParamThrow.Invalid(@this.Name, message);
            }

            return @this;
        }
    }
}

#endif
