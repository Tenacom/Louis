// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Louis.Diagnostics.Internal;

namespace Louis.Diagnostics;

// InRangeFor and NotInRangeFor have one form for each type of collection, all with an optional message.
// The forms differ by the type of their first argument, which every call passes,
// so the optional message causes no ambiguity.
#pragma warning disable RS0026 // Do not add multiple public overloads with optional parameters

// A list implements ICollection<T> and IReadOnlyCollection<T>. Without a form for List<T>,
// a call that passes a list is ambiguous between the forms for the two interfaces.
#pragma warning disable CA1002 // Do not expose generic lists

partial class ParamExtensions
{
    /// <param name="this">The <see cref="Param{T}"/> that holds the index to check.</param>
    extension(Param<int> @this)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is not the index of an item in a specified array.
        /// </summary>
        /// <typeparam name="T">The type of the items of <paramref name="array"/>.</typeparam>
        /// <param name="array">The array that the value must be an index in.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the length of <paramref name="array"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="array"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>The value of <paramref name="this"/> is less than zero.</para>
        /// <para>- or -</para>
        /// <para>The value of <paramref name="this"/> is greater than or equal to
        /// the length of <paramref name="array"/>.</para>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<int> InRangeFor<T>(T[] array, string? message = null)
        {
            Param.NotNull(array);
            var isInRange = @this.Value >= 0 && @this.Value < array.Length;
            if (!isInRange)
            {
                ParamThrow.NotInRangeFor(@this.Name, @this.Value, array.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is the index of an item in a specified array.
        /// </summary>
        /// <typeparam name="T">The type of the items of <paramref name="array"/>.</typeparam>
        /// <param name="array">The array that the value must not be an index in.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the length of <paramref name="array"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="array"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The value of <paramref name="this"/>
        /// is greater than or equal to zero, and less than the length of <paramref name="array"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<int> NotInRangeFor<T>(T[] array, string? message = null)
        {
            Param.NotNull(array);
            var isInRange = @this.Value >= 0 && @this.Value < array.Length;
            if (isInRange)
            {
                ParamThrow.InRangeFor(@this.Name, @this.Value, array.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is not the index of an item in a specified <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items of <paramref name="list"/>.</typeparam>
        /// <param name="list">The <see cref="List{T}"/> that the value must be an index in.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the number of items of <paramref name="list"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>The value of <paramref name="this"/> is less than zero.</para>
        /// <para>- or -</para>
        /// <para>The value of <paramref name="this"/> is greater than or equal to
        /// the number of items of <paramref name="list"/>.</para>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<int> InRangeFor<T>(List<T> list, string? message = null)
        {
            Param.NotNull(list);
            var isInRange = @this.Value >= 0 && @this.Value < list.Count;
            if (!isInRange)
            {
                ParamThrow.NotInRangeFor(@this.Name, @this.Value, list.Count, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is the index of an item in a specified <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items of <paramref name="list"/>.</typeparam>
        /// <param name="list">The <see cref="List{T}"/> that the value must not be an index in.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the number of items of <paramref name="list"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The value of <paramref name="this"/>
        /// is greater than or equal to zero, and less than the number of items of <paramref name="list"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<int> NotInRangeFor<T>(List<T> list, string? message = null)
        {
            Param.NotNull(list);
            var isInRange = @this.Value >= 0 && @this.Value < list.Count;
            if (isInRange)
            {
                ParamThrow.InRangeFor(@this.Name, @this.Value, list.Count, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is not the index of an item in a specified collection.
        /// </summary>
        /// <typeparam name="T">The type of the items of <paramref name="collection"/>.</typeparam>
        /// <param name="collection">The collection that the value must be an index in.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the number of items of <paramref name="collection"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>The value of <paramref name="this"/> is less than zero.</para>
        /// <para>- or -</para>
        /// <para>The value of <paramref name="this"/> is greater than or equal to
        /// the number of items of <paramref name="collection"/>.</para>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<int> InRangeFor<T>(ICollection<T> collection, string? message = null)
        {
            Param.NotNull(collection);
            var isInRange = @this.Value >= 0 && @this.Value < collection.Count;
            if (!isInRange)
            {
                ParamThrow.NotInRangeFor(@this.Name, @this.Value, collection.Count, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is the index of an item in a specified collection.
        /// </summary>
        /// <typeparam name="T">The type of the items of <paramref name="collection"/>.</typeparam>
        /// <param name="collection">The collection that the value must not be an index in.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the number of items of <paramref name="collection"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The value of <paramref name="this"/>
        /// is greater than or equal to zero, and less than the number of items of <paramref name="collection"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<int> NotInRangeFor<T>(ICollection<T> collection, string? message = null)
        {
            Param.NotNull(collection);
            var isInRange = @this.Value >= 0 && @this.Value < collection.Count;
            if (isInRange)
            {
                ParamThrow.InRangeFor(@this.Name, @this.Value, collection.Count, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is not the index of an item in a specified read-only collection.
        /// </summary>
        /// <typeparam name="T">The type of the items of <paramref name="collection"/>.</typeparam>
        /// <param name="collection">The read-only collection that the value must be an index in.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the number of items of <paramref name="collection"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>The value of <paramref name="this"/> is less than zero.</para>
        /// <para>- or -</para>
        /// <para>The value of <paramref name="this"/> is greater than or equal to
        /// the number of items of <paramref name="collection"/>.</para>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<int> InRangeFor<T>(IReadOnlyCollection<T> collection, string? message = null)
        {
            Param.NotNull(collection);
            var isInRange = @this.Value >= 0 && @this.Value < collection.Count;
            if (!isInRange)
            {
                ParamThrow.NotInRangeFor(@this.Name, @this.Value, collection.Count, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is the index of an item in a specified read-only collection.
        /// </summary>
        /// <typeparam name="T">The type of the items of <paramref name="collection"/>.</typeparam>
        /// <param name="collection">The read-only collection that the value must not be an index in.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the number of items of <paramref name="collection"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The value of <paramref name="this"/>
        /// is greater than or equal to zero, and less than the number of items of <paramref name="collection"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<int> NotInRangeFor<T>(IReadOnlyCollection<T> collection, string? message = null)
        {
            Param.NotNull(collection);
            var isInRange = @this.Value >= 0 && @this.Value < collection.Count;
            if (isInRange)
            {
                ParamThrow.InRangeFor(@this.Name, @this.Value, collection.Count, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is not the index of an item in a specified <see cref="Memory{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items of <paramref name="memory"/>.</typeparam>
        /// <param name="memory">The <see cref="Memory{T}"/> that the value must be an index in.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the length of <paramref name="memory"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>The value of <paramref name="this"/> is less than zero.</para>
        /// <para>- or -</para>
        /// <para>The value of <paramref name="this"/> is greater than or equal to
        /// the length of <paramref name="memory"/>.</para>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<int> InRangeFor<T>(Memory<T> memory, string? message = null)
        {
            var isInRange = @this.Value >= 0 && @this.Value < memory.Length;
            if (!isInRange)
            {
                ParamThrow.NotInRangeFor(@this.Name, @this.Value, memory.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is the index of an item in a specified <see cref="Memory{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items of <paramref name="memory"/>.</typeparam>
        /// <param name="memory">The <see cref="Memory{T}"/> that the value must not be an index in.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the length of <paramref name="memory"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The value of <paramref name="this"/>
        /// is greater than or equal to zero, and less than the length of <paramref name="memory"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<int> NotInRangeFor<T>(Memory<T> memory, string? message = null)
        {
            var isInRange = @this.Value >= 0 && @this.Value < memory.Length;
            if (isInRange)
            {
                ParamThrow.InRangeFor(@this.Name, @this.Value, memory.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is not the index of an item in a specified <see cref="ReadOnlyMemory{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items of <paramref name="memory"/>.</typeparam>
        /// <param name="memory">The <see cref="ReadOnlyMemory{T}"/> that the value must be an index in.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the length of <paramref name="memory"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>The value of <paramref name="this"/> is less than zero.</para>
        /// <para>- or -</para>
        /// <para>The value of <paramref name="this"/> is greater than or equal to
        /// the length of <paramref name="memory"/>.</para>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<int> InRangeFor<T>(ReadOnlyMemory<T> memory, string? message = null)
        {
            var isInRange = @this.Value >= 0 && @this.Value < memory.Length;
            if (!isInRange)
            {
                ParamThrow.NotInRangeFor(@this.Name, @this.Value, memory.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is the index of an item in a specified <see cref="ReadOnlyMemory{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items of <paramref name="memory"/>.</typeparam>
        /// <param name="memory">The <see cref="ReadOnlyMemory{T}"/> that the value must not be an index in.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the length of <paramref name="memory"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The value of <paramref name="this"/>
        /// is greater than or equal to zero, and less than the length of <paramref name="memory"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<int> NotInRangeFor<T>(ReadOnlyMemory<T> memory, string? message = null)
        {
            var isInRange = @this.Value >= 0 && @this.Value < memory.Length;
            if (isInRange)
            {
                ParamThrow.InRangeFor(@this.Name, @this.Value, memory.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is not the index of an item in a specified read-only span.
        /// </summary>
        /// <typeparam name="T">The type of the items of <paramref name="span"/>.</typeparam>
        /// <param name="span">The read-only span that the value must be an index in.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the length of <paramref name="span"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>The value of <paramref name="this"/> is less than zero.</para>
        /// <para>- or -</para>
        /// <para>The value of <paramref name="this"/> is greater than or equal to
        /// the length of <paramref name="span"/>.</para>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<int> InRangeFor<T>(ReadOnlySpan<T> span, string? message = null)
        {
            var isInRange = @this.Value >= 0 && @this.Value < span.Length;
            if (!isInRange)
            {
                ParamThrow.NotInRangeFor(@this.Name, @this.Value, span.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is the index of an item in a specified read-only span.
        /// </summary>
        /// <typeparam name="T">The type of the items of <paramref name="span"/>.</typeparam>
        /// <param name="span">The read-only span that the value must not be an index in.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the length of <paramref name="span"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The value of <paramref name="this"/>
        /// is greater than or equal to zero, and less than the length of <paramref name="span"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<int> NotInRangeFor<T>(ReadOnlySpan<T> span, string? message = null)
        {
            var isInRange = @this.Value >= 0 && @this.Value < span.Length;
            if (isInRange)
            {
                ParamThrow.InRangeFor(@this.Name, @this.Value, span.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is not the index of an item in a specified span.
        /// </summary>
        /// <typeparam name="T">The type of the items of <paramref name="span"/>.</typeparam>
        /// <param name="span">The span that the value must be an index in.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the length of <paramref name="span"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>The value of <paramref name="this"/> is less than zero.</para>
        /// <para>- or -</para>
        /// <para>The value of <paramref name="this"/> is greater than or equal to
        /// the length of <paramref name="span"/>.</para>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<int> InRangeFor<T>(Span<T> span, string? message = null)
        {
            var isInRange = @this.Value >= 0 && @this.Value < span.Length;
            if (!isInRange)
            {
                ParamThrow.NotInRangeFor(@this.Name, @this.Value, span.Length, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of a parameter
        /// is the index of an item in a specified span.
        /// </summary>
        /// <typeparam name="T">The type of the items of <paramref name="span"/>.</typeparam>
        /// <param name="span">The span that the value must not be an index in.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the length of <paramref name="span"/>.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The value of <paramref name="this"/>
        /// is greater than or equal to zero, and less than the length of <paramref name="span"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<int> NotInRangeFor<T>(Span<T> span, string? message = null)
        {
            var isInRange = @this.Value >= 0 && @this.Value < span.Length;
            if (isInRange)
            {
                ParamThrow.InRangeFor(@this.Name, @this.Value, span.Length, message);
            }

            return @this;
        }
    }
}
