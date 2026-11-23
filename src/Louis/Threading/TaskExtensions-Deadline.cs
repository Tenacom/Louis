// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Louis.Diagnostics;

namespace Louis.Threading;

// WaitAsync has one overload per type of task, each with an optional cancellation token.
// The overloads differ by the type of the receiver, so a call that omits the token is not ambiguous.
#pragma warning disable RS0026 // Do not add multiple public overloads with optional parameters

partial class TaskExtensions
{
    /// <param name="this">The task to wait for.</param>
    extension(Task @this)
    {
        /// <summary>
        /// Asynchronously waits for this task to complete, until a specified deadline expires.
        /// </summary>
        /// <param name="deadline">The deadline at which the wait gives up.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> that, when signaled, ends the wait.</param>
        /// <returns>A <see cref="Task"/> that represents the wait, and completes as <paramref name="this"/> does.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="this"/> is <see langword="null"/>.</exception>
        /// <exception cref="TimeoutException"><paramref name="deadline"/> expired
        /// before <paramref name="this"/> completed.</exception>
        /// <exception cref="OperationCanceledException"><paramref name="cancellationToken"/> was signaled
        /// before the wait ended.</exception>
        /// <remarks>
        /// <para>This method behaves as <c>Task.WaitAsync</c> does with the <see cref="Deadline.RemainingTime"/>
        /// of <paramref name="deadline"/> as its timeout, on the clock of <paramref name="deadline"/>.
        /// When the wait ends with a <see cref="TimeoutException"/> or an <see cref="OperationCanceledException"/>,
        /// <paramref name="this"/> keeps running.</para>
        /// <para>If <paramref name="this"/> is complete when this method is called, so is the returned task,
        /// even if <paramref name="deadline"/> has expired or <paramref name="cancellationToken"/> is signaled.
        /// Otherwise, if <paramref name="cancellationToken"/> is signaled when this method is called,
        /// the returned task is canceled, even if <paramref name="deadline"/> has expired.</para>
        /// <para>This method waits on a timer of the clock, which it sets to a whole number of milliseconds.
        /// The timer can fire up to one millisecond after <paramref name="deadline"/> expires, or more when it is late.</para>
        /// <para>If more than <see cref="int.MaxValue"/> milliseconds, about 24.8 days, remain
        /// until <paramref name="deadline"/> expires, this method starts no timer.
        /// The wait then ends only when <paramref name="this"/> completes
        /// or <paramref name="cancellationToken"/> is signaled.</para>
        /// </remarks>
        public Task WaitAsync(Deadline deadline, CancellationToken cancellationToken = default)
        {
            Param.NotNull(@this, nameof(@this));
            return @this.WaitAsync(GetTimeout(deadline), deadline.TimeProvider, cancellationToken);
        }
    }

    /// <typeparam name="TResult">The type of the result of <paramref name="this"/>.</typeparam>
    /// <param name="this">The task to wait for.</param>
    extension<TResult>(Task<TResult> @this)
    {
        /// <summary>
        /// Asynchronously waits for this task to complete, until a specified deadline expires.
        /// </summary>
        /// <param name="deadline">The deadline at which the wait gives up.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> that, when signaled, ends the wait.</param>
        /// <returns>A <see cref="Task{TResult}"/> that represents the wait, and completes as <paramref name="this"/> does,
        /// with the same result.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="this"/> is <see langword="null"/>.</exception>
        /// <exception cref="TimeoutException"><paramref name="deadline"/> expired
        /// before <paramref name="this"/> completed.</exception>
        /// <exception cref="OperationCanceledException"><paramref name="cancellationToken"/> was signaled
        /// before the wait ended.</exception>
        /// <remarks>
        /// <para>This method behaves as <c>Task.WaitAsync</c> does with the <see cref="Deadline.RemainingTime"/>
        /// of <paramref name="deadline"/> as its timeout, on the clock of <paramref name="deadline"/>.
        /// When the wait ends with a <see cref="TimeoutException"/> or an <see cref="OperationCanceledException"/>,
        /// <paramref name="this"/> keeps running.</para>
        /// <para>If <paramref name="this"/> is complete when this method is called, so is the returned task,
        /// even if <paramref name="deadline"/> has expired or <paramref name="cancellationToken"/> is signaled.
        /// Otherwise, if <paramref name="cancellationToken"/> is signaled when this method is called,
        /// the returned task is canceled, even if <paramref name="deadline"/> has expired.</para>
        /// <para>This method waits on a timer of the clock, which it sets to a whole number of milliseconds.
        /// The timer can fire up to one millisecond after <paramref name="deadline"/> expires, or more when it is late.</para>
        /// <para>If more than <see cref="int.MaxValue"/> milliseconds, about 24.8 days, remain
        /// until <paramref name="deadline"/> expires, this method starts no timer.
        /// The wait then ends only when <paramref name="this"/> completes
        /// or <paramref name="cancellationToken"/> is signaled.</para>
        /// </remarks>
        public Task<TResult> WaitAsync(Deadline deadline, CancellationToken cancellationToken = default)
        {
            Param.NotNull(@this, nameof(@this));
            return @this.WaitAsync(GetTimeout(deadline), deadline.TimeProvider, cancellationToken);
        }
    }
}
