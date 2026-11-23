// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Threading;

namespace Louis.Threading;

partial class TaskExtensions
{
    // Returns the timeout that Task.WaitAsync takes, on the clock of a deadline, to give up when the deadline expires.
    private static TimeSpan GetTimeout(Deadline deadline)
    {
        var remainingTime = deadline.RemainingTime;
        if (remainingTime <= TimeSpan.Zero)
        {
            // TimeSpan.Zero for a deadline that has expired, or Timeout.InfiniteTimeSpan for one that never expires.
            // Task.WaitAsync takes both as they are.
            return remainingTime;
        }

        var milliseconds = Deadline.GetTimerMilliseconds(remainingTime);
        return milliseconds <= Deadline.MaxTimerMilliseconds
            ? new(milliseconds * TimeSpan.TicksPerMillisecond)
            : Timeout.InfiniteTimeSpan;
    }
}
