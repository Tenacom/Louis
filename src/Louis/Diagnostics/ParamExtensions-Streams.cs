// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.IO;
using System.Runtime.CompilerServices;
using Louis.Diagnostics.Internal;

namespace Louis.Diagnostics;

partial class ParamExtensions
{
    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <param name="this">The <see cref="Param{T}"/> that holds the stream to check.</param>
    extension<T>(Param<T> @this)
        where T : Stream
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a stream parameter does not support reading.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The <see cref="Stream.CanRead"/> property
        /// of the value of <paramref name="this"/> is <see langword="false"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> CanRead(string? message = null)
        {
            if (!@this.Value.CanRead)
            {
                ParamThrow.CannotRead(@this.Name, @this.Value, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a stream parameter does not support writing.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The <see cref="Stream.CanWrite"/> property
        /// of the value of <paramref name="this"/> is <see langword="false"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> CanWrite(string? message = null)
        {
            if (!@this.Value.CanWrite)
            {
                ParamThrow.CannotWrite(@this.Name, @this.Value, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a stream parameter does not support seeking.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The <see cref="Stream.CanSeek"/> property
        /// of the value of <paramref name="this"/> is <see langword="false"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> CanSeek(string? message = null)
        {
            if (!@this.Value.CanSeek)
            {
                ParamThrow.CannotSeek(@this.Name, @this.Value, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a stream parameter is not at its start position.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the position of the stream.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The <see cref="Stream.Position"/> property
        /// of the value of <paramref name="this"/> is not zero.</exception>
        /// <exception cref="NotSupportedException">The value of <paramref name="this"/> does not support seeking.</exception>
        /// <exception cref="ObjectDisposedException">The value of <paramref name="this"/> is closed.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> AtStartPosition(string? message = null)
        {
            var position = @this.Value.Position;
            if (position != 0)
            {
                ParamThrow.NotAtStartPosition(@this.Name, @this.Value, position, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a stream parameter is not at its end position.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is the position of the stream, and <c>{3}</c> is the length of the stream.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The <see cref="Stream.Position"/> property
        /// of the value of <paramref name="this"/> is not equal to its <see cref="Stream.Length"/> property.</exception>
        /// <exception cref="NotSupportedException">The value of <paramref name="this"/> does not support seeking.</exception>
        /// <exception cref="ObjectDisposedException">The value of <paramref name="this"/> is closed.</exception>
        /// <remarks>
        /// <para>A stream that passes this check can be appended to without overwriting any of its data.</para>
        /// <para>Some streams accept a position after their end. Such a position does not pass the check.</para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> AtEndPosition(string? message = null)
        {
            var position = @this.Value.Position;
            var length = @this.Value.Length;
            if (position != length)
            {
                ParamThrow.NotAtEndPosition(@this.Name, @this.Value, position, length, message);
            }

            return @this;
        }
    }
}
