// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Louis.Diagnostics.Internal;

namespace Louis.Diagnostics;

partial class ParamExtensions
{
    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <param name="this">The <see cref="Param{T}"/> that holds the task to check.</param>
    // The status of a task can change at any time.
    // Each check reads the status once, so that the message of the exception holds the status that failed the check.
    extension<T>(Param<T> @this)
        where T : Task
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a task parameter is not completed.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the status of the task.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The status of the value of <paramref name="this"/>
        /// is not <see cref="TaskStatus.RanToCompletion"/>, <see cref="TaskStatus.Faulted"/>,
        /// or <see cref="TaskStatus.Canceled"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> Completed(string? message = null)
        {
            var status = @this.Value.Status;
            if (status is not (TaskStatus.RanToCompletion or TaskStatus.Faulted or TaskStatus.Canceled))
            {
                ParamThrow.NotCompleted(@this.Name, @this.Value, status, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a task parameter is completed.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the status of the task.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The status of the value of <paramref name="this"/>
        /// is <see cref="TaskStatus.RanToCompletion"/>, <see cref="TaskStatus.Faulted"/>,
        /// or <see cref="TaskStatus.Canceled"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> NotCompleted(string? message = null)
        {
            var status = @this.Value.Status;
            if (status is TaskStatus.RanToCompletion or TaskStatus.Faulted or TaskStatus.Canceled)
            {
                ParamThrow.Completed(@this.Name, @this.Value, status, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a task parameter is not completed successfully.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the status of the task.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The status of the value of <paramref name="this"/>
        /// is not <see cref="TaskStatus.RanToCompletion"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> CompletedSuccessfully(string? message = null)
        {
            var status = @this.Value.Status;
            if (status is not TaskStatus.RanToCompletion)
            {
                ParamThrow.NotCompletedSuccessfully(@this.Name, @this.Value, status, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a task parameter is completed successfully.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the status of the task.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The status of the value of <paramref name="this"/>
        /// is <see cref="TaskStatus.RanToCompletion"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> NotCompletedSuccessfully(string? message = null)
        {
            var status = @this.Value.Status;
            if (status is TaskStatus.RanToCompletion)
            {
                ParamThrow.CompletedSuccessfully(@this.Name, @this.Value, status, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a task parameter is not faulted.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the status of the task.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The status of the value of <paramref name="this"/>
        /// is not <see cref="TaskStatus.Faulted"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> Faulted(string? message = null)
        {
            var status = @this.Value.Status;
            if (status is not TaskStatus.Faulted)
            {
                ParamThrow.NotFaulted(@this.Name, @this.Value, status, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a task parameter is faulted.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the status of the task.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The status of the value of <paramref name="this"/>
        /// is <see cref="TaskStatus.Faulted"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> NotFaulted(string? message = null)
        {
            var status = @this.Value.Status;
            if (status is TaskStatus.Faulted)
            {
                ParamThrow.Faulted(@this.Name, @this.Value, status, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a task parameter is not canceled.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the status of the task.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The status of the value of <paramref name="this"/>
        /// is not <see cref="TaskStatus.Canceled"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> Canceled(string? message = null)
        {
            var status = @this.Value.Status;
            if (status is not TaskStatus.Canceled)
            {
                ParamThrow.NotCanceled(@this.Name, @this.Value, status, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a task parameter is canceled.
        /// </summary>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// and <c>{2}</c> is the status of the task.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The status of the value of <paramref name="this"/>
        /// is <see cref="TaskStatus.Canceled"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> NotCanceled(string? message = null)
        {
            var status = @this.Value.Status;
            if (status is TaskStatus.Canceled)
            {
                ParamThrow.Canceled(@this.Name, @this.Value, status, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a task parameter does not have a specified status.
        /// </summary>
        /// <param name="status">The status that the task must have.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="status"/>, and <c>{3}</c> is the status of the task.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The status of the value of <paramref name="this"/>
        /// is not <paramref name="status"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> HasStatusEqualTo(TaskStatus status, string? message = null)
        {
            var actualStatus = @this.Value.Status;
            if (actualStatus != status)
            {
                ParamThrow.StatusNotEqualTo(@this.Name, @this.Value, status, actualStatus, message);
            }

            return @this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of a task parameter has a specified status.
        /// </summary>
        /// <param name="status">The status that the task must not have.</param>
        /// <param name="message">A composite format string for the message of the exception,
        /// or <see langword="null"/> to use the default message.
        /// The format item <c>{0}</c> is the name of the parameter, <c>{1}</c> is its value,
        /// <c>{2}</c> is <paramref name="status"/>, and <c>{3}</c> is the status of the task.</param>
        /// <returns><paramref name="this"/>, for the next check of the chain.</returns>
        /// <exception cref="ArgumentException">The status of the value of <paramref name="this"/>
        /// is <paramref name="status"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<T> HasStatusNotEqualTo(TaskStatus status, string? message = null)
        {
            var actualStatus = @this.Value.Status;
            if (actualStatus == status)
            {
                ParamThrow.StatusEqualTo(@this.Name, @this.Value, status, actualStatus, message);
            }

            return @this;
        }
    }
}
