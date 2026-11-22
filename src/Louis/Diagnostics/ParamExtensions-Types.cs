// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using Louis.Diagnostics.Internal;

namespace Louis.Diagnostics;

// Each check has a form that takes a Type and a form that takes a type argument, both with an optional message.
// The two forms differ by the argument that names the type, so a call that omits the message is not ambiguous.
#pragma warning disable RS0026 // Do not add multiple public overloads with optional parameters

partial class ParamExtensions
{
    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <param name="this">The <see cref="Param{T}"/> that holds the value to check.</param>
    extension<T>(Param<T> @this)
        where T : notnull
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter is not of a specified type.
        /// </summary>
        /// <param name="type">The type that the value must have. A type that derives from it does not pass the check.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is <paramref name="type"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">The type of the value of <paramref name="this"/>
        /// is not <paramref name="type"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> OfType(Type type, string? message = null)
        {
            Param.NotNull(type);
            if (@this.Value.GetType() != type)
            {
                ParamThrow.NotOfType(@this.Name, @this.Value, type, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter is of a specified type.
        /// </summary>
        /// <param name="type">The type that the value must not have. A type that derives from it passes the check.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is <paramref name="type"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">The type of the value of <paramref name="this"/>
        /// is <paramref name="type"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> NotOfType(Type type, string? message = null)
        {
            Param.NotNull(type);
            if (@this.Value.GetType() == type)
            {
                ParamThrow.OfType(@this.Name, @this.Value, type, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter cannot be assigned to a specified type.
        /// </summary>
        /// <param name="type">The type that the value must be assignable to.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is <paramref name="type"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// is not an instance of <paramref name="type"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> AssignableTo(Type type, string? message = null)
        {
            Param.NotNull(type);
            if (!type.IsInstanceOfType(@this.Value))
            {
                ParamThrow.NotAssignableTo(@this.Name, @this.Value, type, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter can be assigned to a specified type.
        /// </summary>
        /// <param name="type">The type that the value must not be assignable to.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is <paramref name="type"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// is an instance of <paramref name="type"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> NotAssignableTo(Type type, string? message = null)
        {
            Param.NotNull(type);
            if (type.IsInstanceOfType(@this.Value))
            {
                ParamThrow.AssignableTo(@this.Name, @this.Value, type, message);
            }

            return @this;
        }
    }

    /// <param name="this">The <see cref="Param{T}"/> that holds the value to check.</param>
    extension(Param<object> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter is not of a specified type,
        /// and continues the chain with that type.
        /// </summary>
        /// <typeparam name="TTarget">The type that the value must have.
        /// A type that derives from it does not pass the check.</typeparam>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is <typeparamref name="TTarget"/>.</param>
        /// <returns>A <see cref="Param{T}"/> that holds the value of <paramref name="this"/>,
        /// as a <typeparamref name="TTarget"/>, and its name.</returns>
        /// <exception cref="ArgumentException">The type of the value of <paramref name="this"/>
        /// is not <typeparamref name="TTarget"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<TTarget> OfType<TTarget>(string? message = null)
            where TTarget : notnull
        {
            if (@this.Value.GetType() != typeof(TTarget))
            {
                ParamThrow.NotOfType(@this.Name, @this.Value, typeof(TTarget), message);
            }

            return new((TTarget)@this.Value, @this.Name);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter is of a specified type.
        /// </summary>
        /// <typeparam name="TTarget">The type that the value must not have.
        /// A type that derives from it passes the check.</typeparam>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is <typeparamref name="TTarget"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The type of the value of <paramref name="this"/>
        /// is <typeparamref name="TTarget"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<object> NotOfType<TTarget>(string? message = null)
            where TTarget : notnull
        {
            if (@this.Value.GetType() == typeof(TTarget))
            {
                ParamThrow.OfType(@this.Name, @this.Value, typeof(TTarget), message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter cannot be assigned to a specified type,
        /// and continues the chain with that type.
        /// </summary>
        /// <typeparam name="TTarget">The type that the value must be assignable to.</typeparam>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is <typeparamref name="TTarget"/>.</param>
        /// <returns>A <see cref="Param{T}"/> that holds the value of <paramref name="this"/>,
        /// as a <typeparamref name="TTarget"/>, and its name.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// is not an instance of <typeparamref name="TTarget"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<TTarget> AssignableTo<TTarget>(string? message = null)
            where TTarget : notnull
        {
            if (@this.Value is TTarget target)
            {
                return new(target, @this.Name);
            }

            return ParamThrow.NotAssignableTo<TTarget>(@this.Name, @this.Value, message);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a parameter can be assigned to a specified type.
        /// </summary>
        /// <typeparam name="TTarget">The type that the value must not be assignable to.</typeparam>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is <typeparamref name="TTarget"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// is an instance of <typeparamref name="TTarget"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<object> NotAssignableTo<TTarget>(string? message = null)
            where TTarget : notnull
        {
            if (@this.Value is TTarget)
            {
                ParamThrow.AssignableTo(@this.Name, @this.Value, typeof(TTarget), message);
            }

            return @this;
        }
    }
}
