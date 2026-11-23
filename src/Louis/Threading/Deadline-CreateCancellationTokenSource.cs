// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Threading;
#if !NET8_0_OR_GREATER
using System.Threading.Tasks;
#endif

namespace Louis.Threading;

partial struct Deadline
{
    /// <summary>
    /// Creates a <see cref="CancellationTokenSource"/> that is canceled when this deadline expires.
    /// </summary>
    /// <returns>A new <see cref="CancellationTokenSource"/>, which the caller disposes.</returns>
    /// <remarks>
    /// <para>Use this method to pass this deadline to a member that takes a <see cref="CancellationToken"/> alone.
    /// To also cancel the operation when another token is signaled, link the two tokens
    /// with <see cref="CancellationTokenSource.CreateLinkedTokenSource(CancellationToken, CancellationToken)"/>.</para>
    /// <para>If this deadline has expired, the source is canceled when this method returns.
    /// If this deadline never expires, this method starts no timer, and only the caller cancels the source.</para>
    /// <para>This method sets a timer of the clock to a whole number of milliseconds.
    /// The timer can fire up to one millisecond after this deadline expires, or more when it is late.</para>
    /// <para>If more than <see cref="int.MaxValue"/> milliseconds, about 24.8 days, remain until this deadline expires,
    /// this method starts no timer. The source is then not canceled when this deadline expires.</para>
    /// </remarks>
    public CancellationTokenSource CreateCancellationTokenSource()
    {
        var timeout = GetTimeout();
        if (timeout == Timeout.InfiniteTimeSpan)
        {
            return new();
        }

        if (timeout == TimeSpan.Zero)
        {
            // With a delay of zero, the constructor of .NET Framework starts a timer,
            // which cancels the source on the thread pool, after the constructor returns.
            var source = new CancellationTokenSource();
            source.Cancel();
            return source;
        }

#if NET8_0_OR_GREATER
        return new(timeout, TimeProvider);
#else
        return TimeProvider.CreateCancellationTokenSource(timeout);
#endif
    }

    // Returns the timeout that sets a timer of the clock to fire when this deadline expires:
    // the remaining time, rounded up to a millisecond; TimeSpan.Zero for a deadline that has expired;
    // Timeout.InfiniteTimeSpan for a deadline that never expires, and for more than MaxTimerMilliseconds remaining.
    internal TimeSpan GetTimeout()
    {
        var remainingTime = RemainingTime;
        if (remainingTime <= TimeSpan.Zero)
        {
            // TimeSpan.Zero, or Timeout.InfiniteTimeSpan.
            return remainingTime;
        }

        var milliseconds = GetTimerMilliseconds(remainingTime);
        return milliseconds <= MaxTimerMilliseconds
            ? new(milliseconds * TimeSpan.TicksPerMillisecond)
            : Timeout.InfiniteTimeSpan;
    }
}
