// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;
using Microsoft.Extensions.Time.Testing;

internal sealed class DeadlineSetAfterSetBeforeTests
{
    private const long InfiniteTicks = -TimeSpan.TicksPerMillisecond;

    [Test]
    public async Task SetAfter_WithPositiveDuration_AddsTheDurationToTheInstant()
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);

        var result = Deadline.SetAfter(deadline, TimeSpan.FromSeconds(3));

        await Assert.That(result.TimeProvider).IsSameReferenceAs(clock);
        await Assert.That(result.HasExpired).IsFalse();
        await Assert.That(result.RemainingTime).IsEqualTo(TimeSpan.FromSeconds(8));
        await Assert.That(result).IsEqualTo(Deadline.SetIn(TimeSpan.FromSeconds(8), clock));
    }

    // Each row: the seconds the clock advances before the call, and the seconds that remain on the new deadline.
    [Test]
    [Arguments(2, 6)]
    [Arguments(5, 3)]
    [Arguments(7, 1)]
    [Arguments(8, 0)]
    [Arguments(10, 0)]
    public async Task SetAfter_AfterTheClockAdvances_AddsTheDurationToTheInstant(
        int elapsedSeconds,
        int expectedSeconds)
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);
        clock.Advance(TimeSpan.FromSeconds(elapsedSeconds));

        var result = Deadline.SetAfter(deadline, TimeSpan.FromSeconds(3));

        await Assert.That(result.HasExpired).IsEqualTo(expectedSeconds == 0);
        await Assert.That(result.RemainingTime).IsEqualTo(TimeSpan.FromSeconds(expectedSeconds));
    }

    [Test]
    public async Task SetAfter_WithZeroDuration_ReturnsTheDeadline()
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);

        var result = Deadline.SetAfter(deadline, TimeSpan.Zero);

        await Assert.That(result).IsEqualTo(deadline);
    }

    [Test]
    public async Task SetAfter_WithInfiniteDuration_ReturnsEternal()
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);

        var result = Deadline.SetAfter(deadline, Timeout.InfiniteTimeSpan);

        await Assert.That(result).IsEqualTo(Deadline.Eternal);
    }

    [Test]
    [Arguments(-1L)]
    [Arguments(-9_999L)]
    [Arguments(-10_001L)]
    [Arguments(long.MinValue)]
    public async Task SetAfter_WithNegativeDuration_ThrowsArgumentOutOfRangeException(long ticks)
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);

        void Act() => Deadline.SetAfter(deadline, new TimeSpan(ticks));

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName("duration");
    }

    [Test]
    [Arguments(0L)]
    [Arguments(50_000_000L)]
    [Arguments(long.MaxValue)]
    [Arguments(InfiniteTicks)]
    public async Task SetAfter_OnEternal_ReturnsEternal(long ticks)
    {
        var result = Deadline.SetAfter(Deadline.Eternal, new TimeSpan(ticks));

        await Assert.That(result).IsEqualTo(Deadline.Eternal);
    }

    [Test]
    [Arguments(0L)]
    [Arguments(50_000_000L)]
    [Arguments(long.MaxValue)]
    [Arguments(InfiniteTicks)]
    public async Task SetAfter_OnExpired_ReturnsExpired(long ticks)
    {
        var result = Deadline.SetAfter(Deadline.Expired, new TimeSpan(ticks));

        await Assert.That(result).IsEqualTo(Deadline.Expired);
    }

    [Test]
    public async Task SetAfter_OnEternalOrExpired_WithNegativeDuration_ThrowsArgumentOutOfRangeException()
    {
        static void ActOnEternal() => Deadline.SetAfter(Deadline.Eternal, TimeSpan.FromSeconds(-5));
        static void ActOnExpired() => Deadline.SetAfter(Deadline.Expired, TimeSpan.FromSeconds(-5));

        await Assert.That(ActOnEternal).Throws<ArgumentOutOfRangeException>().WithParameterName("duration");
        await Assert.That(ActOnExpired).Throws<ArgumentOutOfRangeException>().WithParameterName("duration");
    }

    // Each row: the timestamp frequency of the clock, the timestamp of the deadline, a duration in ticks,
    // and the timestamp of the new deadline.
    [Test]
    [Arguments(10_000_000L, 0L, 1L, 1L)]
    [Arguments(1_000L, 0L, 10_000L, 1L)]
    [Arguments(1_000L, 0L, 10_001L, 2L)]
    [Arguments(1_000_000_000L, 5L, 1L, 105L)]
    [Arguments(3L, -10L, 10_000_001L, -6L)]
    [Arguments(10_000_000L, long.MaxValue - 1, 1L, long.MaxValue)]
    [Arguments(10_000_000L, long.MinValue, long.MaxValue, -1L)]
    [Arguments(20_000_000L, long.MinValue, long.MaxValue, long.MaxValue - 1)]
    public async Task SetAfter_RoundsTheDurationUpToTheUnitsOfTheClock(
        long frequency,
        long timestamp,
        long ticks,
        long expectedTimestamp)
    {
        var clock = new TestTimeProvider(frequency) { Timestamp = timestamp };
        var deadline = Deadline.SetIn(TimeSpan.Zero, clock);

        var result = Deadline.SetAfter(deadline, new TimeSpan(ticks));

        clock.Timestamp = expectedTimestamp;
        await Assert.That(result).IsEqualTo(Deadline.SetIn(TimeSpan.Zero, clock));
    }

    // Each row: the timestamp frequency of the clock, the timestamp of the deadline, and a duration in ticks.
    [Test]
    [Arguments(10_000_000L, long.MaxValue, 1L)]
    [Arguments(10_000_000L, 1L, long.MaxValue)]
    [Arguments(1_000_000_000L, 0L, long.MaxValue)]
    [Arguments(long.MaxValue, 0L, long.MaxValue)]
    public async Task SetAfter_WithInstantBeyondTheTimestampsOfTheClock_ReturnsEternal(
        long frequency,
        long timestamp,
        long ticks)
    {
        var clock = new TestTimeProvider(frequency) { Timestamp = timestamp };
        var deadline = Deadline.SetIn(TimeSpan.Zero, clock);

        var result = Deadline.SetAfter(deadline, new TimeSpan(ticks));

        await Assert.That(result).IsEqualTo(Deadline.Eternal);
    }

    [Test]
    public async Task SetBefore_WithPositiveDuration_SubtractsTheDurationFromTheInstant()
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);

        var result = Deadline.SetBefore(deadline, TimeSpan.FromSeconds(3));

        await Assert.That(result.TimeProvider).IsSameReferenceAs(clock);
        await Assert.That(result.HasExpired).IsFalse();
        await Assert.That(result.RemainingTime).IsEqualTo(TimeSpan.FromSeconds(2));
        await Assert.That(result).IsEqualTo(Deadline.SetIn(TimeSpan.FromSeconds(2), clock));
    }

    // Each row: the seconds the clock advances before the call, and the seconds that remain on the new deadline.
    [Test]
    [Arguments(1, 1)]
    [Arguments(2, 0)]
    [Arguments(4, 0)]
    [Arguments(10, 0)]
    public async Task SetBefore_AfterTheClockAdvances_SubtractsTheDurationFromTheInstant(
        int elapsedSeconds,
        int expectedSeconds)
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);
        clock.Advance(TimeSpan.FromSeconds(elapsedSeconds));

        var result = Deadline.SetBefore(deadline, TimeSpan.FromSeconds(3));

        await Assert.That(result.HasExpired).IsEqualTo(expectedSeconds == 0);
        await Assert.That(result.RemainingTime).IsEqualTo(TimeSpan.FromSeconds(expectedSeconds));
    }

    [Test]
    [Arguments(5)]
    [Arguments(8)]
    public async Task SetBefore_WithInstantNotInTheFuture_ReturnsAnExpiredDeadlineOnTheClock(int seconds)
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);

        var result = Deadline.SetBefore(deadline, TimeSpan.FromSeconds(seconds));

        await Assert.That(result.HasExpired).IsTrue();
        await Assert.That(result.RemainingTime).IsEqualTo(TimeSpan.Zero);
        await Assert.That(result.TimeProvider).IsSameReferenceAs(clock);
        await Assert.That(result).IsNotEqualTo(Deadline.Expired);
    }

    [Test]
    public async Task SetBefore_WithZeroDuration_ReturnsTheDeadline()
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);

        var result = Deadline.SetBefore(deadline, TimeSpan.Zero);

        await Assert.That(result).IsEqualTo(deadline);
    }

    [Test]
    public async Task SetBefore_WithInfiniteDuration_ReturnsExpired()
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);

        var result = Deadline.SetBefore(deadline, Timeout.InfiniteTimeSpan);

        await Assert.That(result).IsEqualTo(Deadline.Expired);
    }

    [Test]
    [Arguments(-1L)]
    [Arguments(-9_999L)]
    [Arguments(-10_001L)]
    [Arguments(long.MinValue)]
    public async Task SetBefore_WithNegativeDuration_ThrowsArgumentOutOfRangeException(long ticks)
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);

        void Act() => Deadline.SetBefore(deadline, new TimeSpan(ticks));

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName("duration");
    }

    [Test]
    [Arguments(0L)]
    [Arguments(50_000_000L)]
    [Arguments(long.MaxValue)]
    [Arguments(InfiniteTicks)]
    public async Task SetBefore_OnEternal_ReturnsEternal(long ticks)
    {
        var result = Deadline.SetBefore(Deadline.Eternal, new TimeSpan(ticks));

        await Assert.That(result).IsEqualTo(Deadline.Eternal);
    }

    [Test]
    [Arguments(0L)]
    [Arguments(50_000_000L)]
    [Arguments(long.MaxValue)]
    [Arguments(InfiniteTicks)]
    public async Task SetBefore_OnExpired_ReturnsExpired(long ticks)
    {
        var result = Deadline.SetBefore(Deadline.Expired, new TimeSpan(ticks));

        await Assert.That(result).IsEqualTo(Deadline.Expired);
    }

    [Test]
    public async Task SetBefore_OnEternalOrExpired_WithNegativeDuration_ThrowsArgumentOutOfRangeException()
    {
        static void ActOnEternal() => Deadline.SetBefore(Deadline.Eternal, TimeSpan.FromSeconds(-5));
        static void ActOnExpired() => Deadline.SetBefore(Deadline.Expired, TimeSpan.FromSeconds(-5));

        await Assert.That(ActOnEternal).Throws<ArgumentOutOfRangeException>().WithParameterName("duration");
        await Assert.That(ActOnExpired).Throws<ArgumentOutOfRangeException>().WithParameterName("duration");
    }

    // Each row: the timestamp frequency of the clock, the timestamp of the deadline, a duration in ticks,
    // and the timestamp of the new deadline.
    [Test]
    [Arguments(10_000_000L, 0L, 1L, -1L)]
    [Arguments(1_000L, 0L, 10_000L, -1L)]
    [Arguments(1_000L, 0L, 10_001L, -2L)]
    [Arguments(1_000_000_000L, 5L, 1L, -95L)]
    [Arguments(3L, 10L, 10_000_001L, 6L)]
    [Arguments(10_000_000L, long.MinValue + 1, 1L, long.MinValue)]
    [Arguments(10_000_000L, long.MaxValue, long.MaxValue, 0L)]
    [Arguments(20_000_000L, long.MaxValue, long.MaxValue, long.MinValue + 1)]
    public async Task SetBefore_RoundsTheDurationUpToTheUnitsOfTheClock(
        long frequency,
        long timestamp,
        long ticks,
        long expectedTimestamp)
    {
        var clock = new TestTimeProvider(frequency) { Timestamp = timestamp };
        var deadline = Deadline.SetIn(TimeSpan.Zero, clock);

        var result = Deadline.SetBefore(deadline, new TimeSpan(ticks));

        clock.Timestamp = expectedTimestamp;
        await Assert.That(result).IsEqualTo(Deadline.SetIn(TimeSpan.Zero, clock));
    }

    // Each row: the timestamp frequency of the clock, the timestamp of the deadline, and a duration in ticks.
    [Test]
    [Arguments(10_000_000L, long.MinValue, 1L)]
    [Arguments(10_000_000L, -2L, long.MaxValue)]
    [Arguments(1_000_000_000L, 0L, long.MaxValue)]
    [Arguments(long.MaxValue, 0L, long.MaxValue)]
    public async Task SetBefore_WithInstantBeyondTheTimestampsOfTheClock_ReturnsExpired(
        long frequency,
        long timestamp,
        long ticks)
    {
        var clock = new TestTimeProvider(frequency) { Timestamp = timestamp };
        var deadline = Deadline.SetIn(TimeSpan.Zero, clock);

        var result = Deadline.SetBefore(deadline, new TimeSpan(ticks));

        await Assert.That(result).IsEqualTo(Deadline.Expired);
    }

    // Each row: the timestamp frequency of the clock, and a duration in ticks.
    [Test]
    [Arguments(10_000_000L, 50_000_000L)]
    [Arguments(3L, 10_000_001L)]
    [Arguments(25_000_003L, 3L)]
    public async Task SetBefore_OnTheResultOfSetAfter_WithTheSameDuration_ReturnsTheFirstDeadline(
        long frequency,
        long ticks)
    {
        var clock = new TestTimeProvider(frequency);
        var deadline = Deadline.SetIn(TimeSpan.Zero, clock);
        var duration = new TimeSpan(ticks);

        var result = Deadline.SetBefore(Deadline.SetAfter(deadline, duration), duration);

        await Assert.That(result).IsEqualTo(deadline);
    }
}
