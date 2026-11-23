// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Louis.Threading;

partial struct Deadline
{
    // The longest time a timer waits for, in milliseconds. Task.Delay of .NET Framework accepts no longer delay.
    internal const long MaxTimerMilliseconds = int.MaxValue;

    /// <summary>
    /// Asynchronously waits until this deadline expires.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that, when signaled, ends the wait.</param>
    /// <returns>A <see cref="Task"/> that completes when this deadline expires.</returns>
    /// <exception cref="OperationCanceledException"><paramref name="cancellationToken"/> was signaled
    /// before the wait ended.</exception>
    /// <remarks>
    /// <para>If this deadline has expired, the task is complete when this method returns.
    /// If this deadline never expires, the task completes only when <paramref name="cancellationToken"/> is signaled.</para>
    /// <para>This method waits on a timer of the clock, which it sets to a whole number of milliseconds.
    /// The task does not complete before this deadline expires.
    /// It can complete up to one millisecond later, or more when the timer is late.</para>
    /// <para>If <paramref name="cancellationToken"/> is signaled when this method is called, the task is canceled,
    /// even if this deadline has expired.</para>
    /// </remarks>
    public Task WaitAsync(CancellationToken cancellationToken = default)
        => cancellationToken.IsCancellationRequested ? Task.FromCanceled(cancellationToken)
            : _timeProvider is { } timeProvider ? WaitOnClockAsync(timeProvider, cancellationToken)
            : IsEternal ? Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken)
            : Task.CompletedTask;

    // Returns the milliseconds a timer waits for a remaining time, which is greater than zero.
    // Task.Delay and Task.WaitAsync truncate a time to a millisecond. This method rounds the remaining time up,
    // because a timer set to a shorter time fires before the instant of the deadline.
    internal static long GetTimerMilliseconds(TimeSpan remainingTime)
        => (long)DivideRoundingUp((ulong)remainingTime.Ticks, TimeSpan.TicksPerMillisecond);

    private async Task WaitOnClockAsync(TimeProvider timeProvider, CancellationToken cancellationToken)
    {
        // One delay may not be enough. A delay has a maximum, and nothing ties the timers of a TimeProvider
        // to its timestamps, so a timer can fire before the clock reaches the instant.
        for (var remainingTime = RemainingTime; remainingTime > TimeSpan.Zero; remainingTime = RemainingTime)
        {
            var milliseconds = Math.Min(GetTimerMilliseconds(remainingTime), MaxTimerMilliseconds);
            var delay = new TimeSpan(milliseconds * TimeSpan.TicksPerMillisecond);
#if NET8_0_OR_GREATER
            await Task.Delay(delay, timeProvider, cancellationToken).ConfigureAwait(false);
#else
            await timeProvider.Delay(delay, cancellationToken).ConfigureAwait(false);
#endif
        }
    }
}
