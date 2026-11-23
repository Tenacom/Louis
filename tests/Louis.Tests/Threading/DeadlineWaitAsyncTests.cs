// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;
using Microsoft.Extensions.Time.Testing;

[Timeout(10_000)]
internal sealed class DeadlineWaitAsyncTests
{
    [Test]
    public async Task WaitAsync_OnExpired_ReturnsACompletedTask(CancellationToken cancellationToken)
    {
        var task = Deadline.Expired.WaitAsync(cancellationToken);

        await Assert.That(task.Status).IsEqualTo(TaskStatus.RanToCompletion);
    }

    // Each row: the seconds to the deadline, and the seconds the clock advances before the call.
    [Test]
    [Arguments(0, 0)]
    [Arguments(5, 5)]
    [Arguments(5, 8)]
    public async Task WaitAsync_OnADeadlineThatHasExpiredOnAClock_ReturnsACompletedTask(
        int seconds,
        int elapsedSeconds,
        CancellationToken cancellationToken)
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(seconds), clock);
        clock.Advance(TimeSpan.FromSeconds(elapsedSeconds));

        var task = deadline.WaitAsync(cancellationToken);

        await Assert.That(task.Status).IsEqualTo(TaskStatus.RanToCompletion);
    }

    [Test]
    public async Task WaitAsync_CompletesWhenTheClockReachesTheInstant(CancellationToken cancellationToken)
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);

        var task = deadline.WaitAsync(cancellationToken);

        await Assert.That(task.IsCompleted).IsFalse();

        clock.Advance(TimeSpan.FromMilliseconds(4_999));

        await Assert.That(task.IsCompleted).IsFalse();

        clock.Advance(TimeSpan.FromMilliseconds(1));
        await task;
    }

    // Each row: the ticks to the deadline, and the milliseconds after which the wait ends.
    [Test]
    [Arguments(1L, 1)]
    [Arguments(9_999L, 1)]
    [Arguments(10_000L, 1)]
    [Arguments(10_001L, 2)]
    [Arguments(50_000L, 5)]
    public async Task WaitAsync_RoundsTheRemainingTimeUpToAMillisecond(
        long ticks,
        int expectedMilliseconds,
        CancellationToken cancellationToken)
    {
        var oneTick = new TimeSpan(1);
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(new TimeSpan(ticks), clock);

        var task = deadline.WaitAsync(cancellationToken);
        clock.Advance(TimeSpan.FromMilliseconds(expectedMilliseconds) - oneTick);

        await Assert.That(task.IsCompleted).IsFalse();

        clock.Advance(oneTick);
        await task;
    }

    [Test]
    public async Task WaitAsync_WithMoreTimeRemainingThanOneDelayCovers_CompletesWhenTheClockReachesTheInstant(
        CancellationToken cancellationToken)
    {
        var longestDelay = TimeSpan.FromMilliseconds(int.MaxValue);
        var duration = TimeSpan.FromDays(60);
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(duration, clock);

        var task = deadline.WaitAsync(cancellationToken);
        clock.Advance(longestDelay);

        await Assert.That(task.IsCompleted).IsFalse();

        clock.Advance(duration - longestDelay);
        await task;
    }

    [Test]
    public async Task WaitAsync_WhenATimerFiresBeforeTheClockReachesTheInstant_KeepsWaiting(
        CancellationToken cancellationToken)
    {
        // Advance fires the timers of this clock, and does not move its timestamp.
        var clock = new TestTimeProvider(TimeSpan.TicksPerSecond);
        var duration = TimeSpan.FromSeconds(5);
        var deadline = Deadline.SetIn(duration, clock);

        var task = deadline.WaitAsync(cancellationToken);
        clock.Advance(duration);

        await Assert.That(task.IsCompleted).IsFalse();

        clock.Timestamp = duration.Ticks;
        clock.Advance(duration);
        await task;
    }

    [Test]
    public async Task WaitAsync_OnEternal_CompletesOnlyWhenTheTokenIsCanceled(CancellationToken cancellationToken)
    {
        using var tokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

        var task = Deadline.Eternal.WaitAsync(tokenSource.Token);

        await Assert.That(task.IsCompleted).IsFalse();

        await CancelAsync(tokenSource);

        _ = await Assert.That(() => task).Throws<OperationCanceledException>();
        await Assert.That(task.IsCanceled).IsTrue();
    }

    [Test]
    public async Task WaitAsync_WhenTheTokenIsCanceledBeforeTheDeadlineExpires_ThrowsOperationCanceledException(
        CancellationToken cancellationToken)
    {
        using var tokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);

        var task = deadline.WaitAsync(tokenSource.Token);
        clock.Advance(TimeSpan.FromSeconds(3));

        await Assert.That(task.IsCompleted).IsFalse();

        await CancelAsync(tokenSource);

        _ = await Assert.That(() => task).Throws<OperationCanceledException>();
        await Assert.That(task.IsCanceled).IsTrue();
    }

    [Test]
    public async Task WaitAsync_WithACanceledToken_ReturnsACanceledTask(CancellationToken cancellationToken)
    {
        var clock = new FakeTimeProvider();
        var canceledToken = new CancellationToken(canceled: true);

        var taskOnEternal = Deadline.Eternal.WaitAsync(canceledToken);
        var taskOnClock = Deadline.SetIn(TimeSpan.FromSeconds(5), clock).WaitAsync(canceledToken);

        await Assert.That(taskOnEternal.IsCanceled).IsTrue();
        await Assert.That(taskOnClock.IsCanceled).IsTrue();
    }

    [Test]
    public async Task WaitAsync_OnAnExpiredDeadline_WithACanceledToken_ReturnsACanceledTask(
        CancellationToken cancellationToken)
    {
        var clock = new FakeTimeProvider();
        var canceledToken = new CancellationToken(canceled: true);

        var taskOnExpired = Deadline.Expired.WaitAsync(canceledToken);
        var taskOnClock = Deadline.SetIn(TimeSpan.Zero, clock).WaitAsync(canceledToken);

        await Assert.That(taskOnExpired.IsCanceled).IsTrue();
        await Assert.That(taskOnClock.IsCanceled).IsTrue();
    }

    private static Task CancelAsync(CancellationTokenSource tokenSource)
    {
#if NETFRAMEWORK
        // .NET Framework has no CancellationTokenSource.CancelAsync.
        tokenSource.Cancel();
        return Task.CompletedTask;
#else
        return tokenSource.CancelAsync();
#endif
    }
}
