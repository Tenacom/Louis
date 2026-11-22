// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using Louis.Diagnostics.Internal;

namespace Louis.Diagnostics;

// Each check has one overload per numeric type, all with an optional message.
// The overloads differ by the type of the receiver, so a call that omits the message is not ambiguous.
#pragma warning disable RS0026 // Do not add multiple public overloads with optional parameters

// The distance between two integers of a signed type fits the unsigned type of the same size alone.
// A check with such a distance as a parameter is therefore not CLS-compliant.
partial class ParamExtensions
{
    /// <param name="this">The <see cref="Param{T}"/> that holds the value to check.</param>
    extension(Param<int> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter
        /// is farther from a specified value than a specified distance.
        /// </summary>
        /// <param name="target">The value to compare with.</param>
        /// <param name="delta">The maximum distance between the value of the parameter and <paramref name="target"/>.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="target"/>, and <c>{3}</c> is <paramref name="delta"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The distance between the value of <paramref name="this"/>
        /// and <paramref name="target"/> is greater than <paramref name="delta"/>.</exception>
        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<int> CloseTo(int target, uint delta, string? message = null)
        {
            if (Distance(@this.Value, target) > delta)
            {
                ParamThrow.NotCloseTo(@this.Name, @this.Value, target, delta, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter
        /// is within a specified distance of a specified value.
        /// </summary>
        /// <param name="target">The value to compare with.</param>
        /// <param name="delta">The distance between the value of the parameter and <paramref name="target"/>
        /// that the value must exceed.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="target"/>, and <c>{3}</c> is <paramref name="delta"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The distance between the value of <paramref name="this"/>
        /// and <paramref name="target"/> is less than or equal to <paramref name="delta"/>.</exception>
        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<int> NotCloseTo(int target, uint delta, string? message = null)
        {
            if (Distance(@this.Value, target) <= delta)
            {
                ParamThrow.CloseTo(@this.Name, @this.Value, target, delta, message);
            }

            return @this;
        }
    }

    /// <param name="this">The <see cref="Param{T}"/> that holds the value to check.</param>
    extension(Param<long> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter
        /// is farther from a specified value than a specified distance.
        /// </summary>
        /// <param name="target">The value to compare with.</param>
        /// <param name="delta">The maximum distance between the value of the parameter and <paramref name="target"/>.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="target"/>, and <c>{3}</c> is <paramref name="delta"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The distance between the value of <paramref name="this"/>
        /// and <paramref name="target"/> is greater than <paramref name="delta"/>.</exception>
        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<long> CloseTo(long target, ulong delta, string? message = null)
        {
            if (Distance(@this.Value, target) > delta)
            {
                ParamThrow.NotCloseTo(@this.Name, @this.Value, target, delta, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter
        /// is within a specified distance of a specified value.
        /// </summary>
        /// <param name="target">The value to compare with.</param>
        /// <param name="delta">The distance between the value of the parameter and <paramref name="target"/>
        /// that the value must exceed.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="target"/>, and <c>{3}</c> is <paramref name="delta"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The distance between the value of <paramref name="this"/>
        /// and <paramref name="target"/> is less than or equal to <paramref name="delta"/>.</exception>
        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<long> NotCloseTo(long target, ulong delta, string? message = null)
        {
            if (Distance(@this.Value, target) <= delta)
            {
                ParamThrow.CloseTo(@this.Name, @this.Value, target, delta, message);
            }

            return @this;
        }
    }

    /// <param name="this">The <see cref="Param{T}"/> that holds the value to check.</param>
    extension(Param<nint> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter
        /// is farther from a specified value than a specified distance.
        /// </summary>
        /// <param name="target">The value to compare with.</param>
        /// <param name="delta">The maximum distance between the value of the parameter and <paramref name="target"/>.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="target"/>, and <c>{3}</c> is <paramref name="delta"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The distance between the value of <paramref name="this"/>
        /// and <paramref name="target"/> is greater than <paramref name="delta"/>.</exception>
        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<nint> CloseTo(nint target, nuint delta, string? message = null)
        {
            if (Distance(@this.Value, target) > delta)
            {
                ParamThrow.NotCloseTo(@this.Name, @this.Value, target, delta, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter
        /// is within a specified distance of a specified value.
        /// </summary>
        /// <param name="target">The value to compare with.</param>
        /// <param name="delta">The distance between the value of the parameter and <paramref name="target"/>
        /// that the value must exceed.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="target"/>, and <c>{3}</c> is <paramref name="delta"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The distance between the value of <paramref name="this"/>
        /// and <paramref name="target"/> is less than or equal to <paramref name="delta"/>.</exception>
        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<nint> NotCloseTo(nint target, nuint delta, string? message = null)
        {
            if (Distance(@this.Value, target) <= delta)
            {
                ParamThrow.CloseTo(@this.Name, @this.Value, target, delta, message);
            }

            return @this;
        }
    }

    /// <param name="this">The <see cref="Param{T}"/> that holds the value to check.</param>
    extension(Param<float> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter
        /// is farther from a specified value than a specified distance.
        /// </summary>
        /// <param name="target">The value to compare with.</param>
        /// <param name="delta">The maximum distance between the value of the parameter and <paramref name="target"/>.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="target"/>, and <c>{3}</c> is <paramref name="delta"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">
        /// <para>The distance between the value of <paramref name="this"/> and <paramref name="target"/>
        /// is greater than <paramref name="delta"/>.</para>
        /// <para>- or -</para>
        /// <para>The value of <paramref name="this"/>, <paramref name="target"/>, or <paramref name="delta"/>
        /// is <see cref="float.NaN"/>.</para>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<float> CloseTo(float target, float delta, string? message = null)
        {
            // A comparison with NaN is false, so the check states the condition to pass, and fails on NaN.
            var isClose = Math.Abs(@this.Value - target) <= delta;
            if (!isClose)
            {
                ParamThrow.NotCloseTo(@this.Name, @this.Value, target, delta, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter
        /// is within a specified distance of a specified value.
        /// </summary>
        /// <param name="target">The value to compare with.</param>
        /// <param name="delta">The distance between the value of the parameter and <paramref name="target"/>
        /// that the value must exceed.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="target"/>, and <c>{3}</c> is <paramref name="delta"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">
        /// <para>The distance between the value of <paramref name="this"/> and <paramref name="target"/>
        /// is less than or equal to <paramref name="delta"/>.</para>
        /// <para>- or -</para>
        /// <para>The value of <paramref name="this"/>, <paramref name="target"/>, or <paramref name="delta"/>
        /// is <see cref="float.NaN"/>.</para>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<float> NotCloseTo(float target, float delta, string? message = null)
        {
            // A comparison with NaN is false, so the check states the condition to pass, and fails on NaN.
            var isFar = Math.Abs(@this.Value - target) > delta;
            if (!isFar)
            {
                ParamThrow.CloseTo(@this.Name, @this.Value, target, delta, message);
            }

            return @this;
        }
    }

    /// <param name="this">The <see cref="Param{T}"/> that holds the value to check.</param>
    extension(Param<double> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter
        /// is farther from a specified value than a specified distance.
        /// </summary>
        /// <param name="target">The value to compare with.</param>
        /// <param name="delta">The maximum distance between the value of the parameter and <paramref name="target"/>.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="target"/>, and <c>{3}</c> is <paramref name="delta"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">
        /// <para>The distance between the value of <paramref name="this"/> and <paramref name="target"/>
        /// is greater than <paramref name="delta"/>.</para>
        /// <para>- or -</para>
        /// <para>The value of <paramref name="this"/>, <paramref name="target"/>, or <paramref name="delta"/>
        /// is <see cref="double.NaN"/>.</para>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<double> CloseTo(double target, double delta, string? message = null)
        {
            // A comparison with NaN is false, so the check states the condition to pass, and fails on NaN.
            var isClose = Math.Abs(@this.Value - target) <= delta;
            if (!isClose)
            {
                ParamThrow.NotCloseTo(@this.Name, @this.Value, target, delta, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter
        /// is within a specified distance of a specified value.
        /// </summary>
        /// <param name="target">The value to compare with.</param>
        /// <param name="delta">The distance between the value of the parameter and <paramref name="target"/>
        /// that the value must exceed.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="target"/>, and <c>{3}</c> is <paramref name="delta"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">
        /// <para>The distance between the value of <paramref name="this"/> and <paramref name="target"/>
        /// is less than or equal to <paramref name="delta"/>.</para>
        /// <para>- or -</para>
        /// <para>The value of <paramref name="this"/>, <paramref name="target"/>, or <paramref name="delta"/>
        /// is <see cref="double.NaN"/>.</para>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<double> NotCloseTo(double target, double delta, string? message = null)
        {
            // A comparison with NaN is false, so the check states the condition to pass, and fails on NaN.
            var isFar = Math.Abs(@this.Value - target) > delta;
            if (!isFar)
            {
                ParamThrow.CloseTo(@this.Name, @this.Value, target, delta, message);
            }

            return @this;
        }
    }
}
