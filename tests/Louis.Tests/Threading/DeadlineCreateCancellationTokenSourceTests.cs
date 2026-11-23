// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;
using Microsoft.Extensions.Time.Testing;

internal sealed class DeadlineCreateCancellationTokenSourceTests
{
    [Test]
    public async Task CreateCancellationTokenSource_OnEternal_ReturnsASourceThatIsNotCanceled()
    {
        using var source = Deadline.Eternal.CreateCancellationTokenSource();

        await Assert.That(source.IsCancellationRequested).IsFalse();
    }

    [Test]
    public async Task CreateCancellationTokenSource_OnExpired_ReturnsACanceledSource()
    {
        using var source = Deadline.Expired.CreateCancellationTokenSource();

        await Assert.That(source.IsCancellationRequested).IsTrue();
    }

    // Each row: the seconds to the deadline, and the seconds the clock advances before the call.
    [Test]
    [Arguments(0, 0)]
    [Arguments(5, 5)]
    [Arguments(5, 8)]
    public async Task CreateCancellationTokenSource_OnADeadlineThatHasExpiredOnAClock_ReturnsACanceledSource(
        int seconds,
        int elapsedSeconds)
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(seconds), clock);
        clock.Advance(TimeSpan.FromSeconds(elapsedSeconds));

        using var source = deadline.CreateCancellationTokenSource();

        await Assert.That(source.IsCancellationRequested).IsTrue();
    }

    [Test]
    public async Task CreateCancellationTokenSource_ReturnsASourceThatIsCanceledWhenTheClockReachesTheInstant()
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);

        using var source = deadline.CreateCancellationTokenSource();

        await Assert.That(source.IsCancellationRequested).IsFalse();

        clock.Advance(TimeSpan.FromMilliseconds(4_999));

        await Assert.That(source.IsCancellationRequested).IsFalse();

        clock.Advance(TimeSpan.FromMilliseconds(1));

        await Assert.That(source.IsCancellationRequested).IsTrue();
    }

    // Each row: the ticks to the deadline, and the milliseconds after which the source is canceled.
    [Test]
    [Arguments(1L, 1)]
    [Arguments(9_999L, 1)]
    [Arguments(10_000L, 1)]
    [Arguments(10_001L, 2)]
    [Arguments(50_000L, 5)]
    public async Task CreateCancellationTokenSource_RoundsTheRemainingTimeUpToAMillisecond(
        long ticks,
        int expectedMilliseconds)
    {
        var oneTick = new TimeSpan(1);
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(new TimeSpan(ticks), clock);

        using var source = deadline.CreateCancellationTokenSource();
        clock.Advance(TimeSpan.FromMilliseconds(expectedMilliseconds) - oneTick);

        await Assert.That(source.IsCancellationRequested).IsFalse();

        clock.Advance(oneTick);

        await Assert.That(source.IsCancellationRequested).IsTrue();
    }

    [Test]
    public async Task CreateCancellationTokenSource_WithInt32MaxValueMillisecondsRemaining_StartsATimer()
    {
        var duration = TimeSpan.FromMilliseconds(int.MaxValue);
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(duration, clock);

        using var source = deadline.CreateCancellationTokenSource();

        await Assert.That(source.IsCancellationRequested).IsFalse();

        clock.Advance(duration);

        await Assert.That(source.IsCancellationRequested).IsTrue();
    }

    [Test]
    public async Task CreateCancellationTokenSource_WithMoreThanInt32MaxValueMillisecondsRemaining_StartsNoTimer()
    {
        var duration = TimeSpan.FromMilliseconds(int.MaxValue) + new TimeSpan(1);
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(duration, clock);

        using var source = deadline.CreateCancellationTokenSource();
        clock.Advance(TimeSpan.FromDays(60));

        await Assert.That(deadline.HasExpired).IsTrue();
        await Assert.That(source.IsCancellationRequested).IsFalse();
    }

    [Test]
    public async Task CreateCancellationTokenSource_ReturnsANewSourceAtEachCall()
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);

        using var first = deadline.CreateCancellationTokenSource();
        using var second = deadline.CreateCancellationTokenSource();

        await Assert.That(second).IsNotSameReferenceAs(first);
    }
}
