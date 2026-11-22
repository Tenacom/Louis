// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Louis.Diagnostics.Internal;

namespace Louis.Diagnostics;

// Empty and NotEmpty have one form for each type of collection, all with an optional message.
// The forms differ by the type of the receiver, so a call that omits the message is not ambiguous.
#pragma warning disable RS0026 // Do not add multiple public overloads with optional parameters

partial class ParamExtensions
{
    /// <typeparam name="T">The type of the items of the array.</typeparam>
    /// <param name="this">The <see cref="Param{T}"/> that holds the array to check.</param>
    extension<T>(Param<T[]> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of an array parameter is not empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// holds at least one item.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T[]> Empty(string? message = null)
        {
            if (@this.Value.Length != 0)
            {
                ParamThrow.CollectionNotEmpty(@this.Name, @this.Value, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of an array parameter is empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/> holds no item.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T[]> NotEmpty(string? message = null)
        {
            if (@this.Value.Length == 0)
            {
                ParamThrow.Empty(@this.Name, @this.Value, message);
            }

            return @this;
        }
    }

    /// <typeparam name="T">The type of the items of the <see cref="List{T}"/>.</typeparam>
    /// <param name="this">The <see cref="Param{T}"/> that holds the <see cref="List{T}"/> to check.</param>
    extension<T>(Param<List<T>> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a <see cref="List{T}"/> parameter is not empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the number of items of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// holds at least one item.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<List<T>> Empty(string? message = null)
        {
            if (@this.Value.Count != 0)
            {
                ParamThrow.CollectionNotEmpty(@this.Name, @this.Value, @this.Value.Count, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a <see cref="List{T}"/> parameter is empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/> holds no item.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<List<T>> NotEmpty(string? message = null)
        {
            if (@this.Value.Count == 0)
            {
                ParamThrow.Empty(@this.Name, @this.Value, message);
            }

            return @this;
        }
    }

    /// <typeparam name="T">The type of the items of the list.</typeparam>
    /// <param name="this">The <see cref="Param{T}"/> that holds the list to check.</param>
    extension<T>(Param<IList<T>> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a list parameter is not empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the number of items of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// holds at least one item.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<IList<T>> Empty(string? message = null)
        {
            if (@this.Value.Count != 0)
            {
                ParamThrow.CollectionNotEmpty(@this.Name, @this.Value, @this.Value.Count, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a list parameter is empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/> holds no item.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<IList<T>> NotEmpty(string? message = null)
        {
            if (@this.Value.Count == 0)
            {
                ParamThrow.Empty(@this.Name, @this.Value, message);
            }

            return @this;
        }
    }

    /// <typeparam name="T">The type of the items of the read-only list.</typeparam>
    /// <param name="this">The <see cref="Param{T}"/> that holds the read-only list to check.</param>
    extension<T>(Param<IReadOnlyList<T>> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a read-only list parameter is not empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the number of items of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// holds at least one item.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<IReadOnlyList<T>> Empty(string? message = null)
        {
            if (@this.Value.Count != 0)
            {
                ParamThrow.CollectionNotEmpty(@this.Name, @this.Value, @this.Value.Count, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a read-only list parameter is empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/> holds no item.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<IReadOnlyList<T>> NotEmpty(string? message = null)
        {
            if (@this.Value.Count == 0)
            {
                ParamThrow.Empty(@this.Name, @this.Value, message);
            }

            return @this;
        }
    }

    /// <typeparam name="T">The type of the items of the collection.</typeparam>
    /// <param name="this">The <see cref="Param{T}"/> that holds the collection to check.</param>
    extension<T>(Param<ICollection<T>> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a collection parameter is not empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the number of items of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// holds at least one item.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<ICollection<T>> Empty(string? message = null)
        {
            if (@this.Value.Count != 0)
            {
                ParamThrow.CollectionNotEmpty(@this.Name, @this.Value, @this.Value.Count, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a collection parameter is empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/> holds no item.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<ICollection<T>> NotEmpty(string? message = null)
        {
            if (@this.Value.Count == 0)
            {
                ParamThrow.Empty(@this.Name, @this.Value, message);
            }

            return @this;
        }
    }

    /// <typeparam name="T">The type of the items of the read-only collection.</typeparam>
    /// <param name="this">The <see cref="Param{T}"/> that holds the read-only collection to check.</param>
    extension<T>(Param<IReadOnlyCollection<T>> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a read-only collection parameter is not empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the number of items of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// holds at least one item.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<IReadOnlyCollection<T>> Empty(string? message = null)
        {
            if (@this.Value.Count != 0)
            {
                ParamThrow.CollectionNotEmpty(@this.Name, @this.Value, @this.Value.Count, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a read-only collection parameter is empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/> holds no item.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<IReadOnlyCollection<T>> NotEmpty(string? message = null)
        {
            if (@this.Value.Count == 0)
            {
                ParamThrow.Empty(@this.Name, @this.Value, message);
            }

            return @this;
        }
    }

    /// <typeparam name="T">The type of the items of the <see cref="Memory{T}"/>.</typeparam>
    /// <param name="this">The <see cref="Param{T}"/> that holds the <see cref="Memory{T}"/> to check.</param>
    extension<T>(Param<Memory<T>> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a <see cref="Memory{T}"/> parameter is not empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// holds at least one item.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<Memory<T>> Empty(string? message = null)
        {
            if (@this.Value.Length != 0)
            {
                ParamThrow.CollectionNotEmpty(@this.Name, @this.Value, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a <see cref="Memory{T}"/> parameter is empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/> holds no item.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<Memory<T>> NotEmpty(string? message = null)
        {
            if (@this.Value.Length == 0)
            {
                ParamThrow.Empty(@this.Name, @this.Value, message);
            }

            return @this;
        }
    }

    /// <typeparam name="T">The type of the items of the <see cref="ReadOnlyMemory{T}"/>.</typeparam>
    /// <param name="this">The <see cref="Param{T}"/> that holds the <see cref="ReadOnlyMemory{T}"/> to check.</param>
    extension<T>(Param<ReadOnlyMemory<T>> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a <see cref="ReadOnlyMemory{T}"/> parameter is not empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the length of the value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/>
        /// holds at least one item.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<ReadOnlyMemory<T>> Empty(string? message = null)
        {
            if (@this.Value.Length != 0)
            {
                ParamThrow.CollectionNotEmpty(@this.Name, @this.Value, @this.Value.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a <see cref="ReadOnlyMemory{T}"/> parameter is empty.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The value of <paramref name="this"/> holds no item.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<ReadOnlyMemory<T>> NotEmpty(string? message = null)
        {
            if (@this.Value.Length == 0)
            {
                ParamThrow.Empty(@this.Name, @this.Value, message);
            }

            return @this;
        }
    }
}
