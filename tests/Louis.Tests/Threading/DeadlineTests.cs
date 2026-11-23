// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;
using Microsoft.Extensions.Time.Testing;

internal sealed class DeadlineTests
{
    [Test]
    public async Task Eternal_NeverExpires()
    {
        var deadline = Deadline.Eternal;

        await Assert.That(deadline.IsEternal).IsTrue();
        await Assert.That(deadline.HasExpired).IsFalse();
        await Assert.That(deadline.RemainingTime).IsEqualTo(Timeout.InfiniteTimeSpan);
        await Assert.That(deadline.TimeProvider).IsSameReferenceAs(TimeProvider.System);
    }

    [Test]
    public async Task Default_IsEternal()
    {
        var deadline = default(Deadline);

        await Assert.That(deadline.IsEternal).IsTrue();
        await Assert.That(deadline).IsEqualTo(Deadline.Eternal);
        await Assert.That(deadline.GetHashCode()).IsEqualTo(Deadline.Eternal.GetHashCode());
    }

    [Test]
    public async Task Expired_HasExpired()
    {
        var deadline = Deadline.Expired;

        await Assert.That(deadline.IsEternal).IsFalse();
        await Assert.That(deadline.HasExpired).IsTrue();
        await Assert.That(deadline.RemainingTime).IsEqualTo(TimeSpan.Zero);
        await Assert.That(deadline.TimeProvider).IsSameReferenceAs(TimeProvider.System);
    }

    [Test]
    public async Task SetIn_WithPositiveDuration_ExpiresWhenTheClockReachesTheInstant()
    {
        var clock = new FakeTimeProvider();

        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);

        await Assert.That(deadline.TimeProvider).IsSameReferenceAs(clock);
        await Assert.That(deadline.IsEternal).IsFalse();
        await Assert.That(deadline.HasExpired).IsFalse();
        await Assert.That(deadline.RemainingTime).IsEqualTo(TimeSpan.FromSeconds(5));

        clock.Advance(TimeSpan.FromSeconds(3));

        await Assert.That(deadline.HasExpired).IsFalse();
        await Assert.That(deadline.RemainingTime).IsEqualTo(TimeSpan.FromSeconds(2));

        clock.Advance(TimeSpan.FromSeconds(2));

        await Assert.That(deadline.HasExpired).IsTrue();
        await Assert.That(deadline.RemainingTime).IsEqualTo(TimeSpan.Zero);

        clock.Advance(TimeSpan.FromSeconds(1));

        await Assert.That(deadline.HasExpired).IsTrue();
        await Assert.That(deadline.RemainingTime).IsEqualTo(TimeSpan.Zero);
    }

    [Test]
    public async Task SetIn_WithZeroDuration_ReturnsAnExpiredDeadlineOnTheClock()
    {
        var clock = new FakeTimeProvider();

        var deadline = Deadline.SetIn(TimeSpan.Zero, clock);

        await Assert.That(deadline.HasExpired).IsTrue();
        await Assert.That(deadline.RemainingTime).IsEqualTo(TimeSpan.Zero);
        await Assert.That(deadline.TimeProvider).IsSameReferenceAs(clock);
        await Assert.That(deadline).IsNotEqualTo(Deadline.Expired);
    }

    [Test]
    public async Task SetIn_WithInfiniteDuration_ReturnsEternal()
    {
        var clock = new FakeTimeProvider();

        var deadline = Deadline.SetIn(Timeout.InfiniteTimeSpan, clock);

        await Assert.That(deadline).IsEqualTo(Deadline.Eternal);
    }

    [Test]
    [Arguments(-1L)]
    [Arguments(-9_999L)]
    [Arguments(-10_001L)]
    [Arguments(long.MinValue)]
    public async Task SetIn_WithNegativeDuration_ThrowsArgumentOutOfRangeException(long ticks)
    {
        var clock = new FakeTimeProvider();

        void Act() => Deadline.SetIn(new TimeSpan(ticks), clock);

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName("duration");
    }

    [Test]
    public async Task SetIn_WithNullTimeProvider_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            Deadline.SetIn(TimeSpan.Zero, null!);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("timeProvider");
    }

    [Test]
    [Arguments(0L)]
    [Arguments(-1L)]
    public async Task SetIn_WithTimestampFrequencyNotPositive_ThrowsArgumentException(long frequency)
    {
        var clock = new TestTimeProvider(frequency);

        void Act() => Deadline.SetIn(TimeSpan.FromSeconds(5), clock);

        await Assert.That(Act).ThrowsExactly<ArgumentException>().WithParameterName("timeProvider");
    }

    [Test]
    public async Task SetIn_WithoutTimeProvider_SetsTheDeadlineOnTheSystemClock()
    {
        var deadline = Deadline.SetIn(TimeSpan.FromDays(1));

        var remainingTime = deadline.RemainingTime;
        await Assert.That(deadline.TimeProvider).IsSameReferenceAs(TimeProvider.System);
        await Assert.That(deadline.HasExpired).IsFalse();
        await Assert.That(remainingTime).IsGreaterThan(TimeSpan.FromHours(23));
        await Assert.That(remainingTime).IsLessThan(TimeSpan.FromHours(25));
    }

    [Test]
    public async Task SetIn_WithoutTimeProvider_FollowsTheRulesOfATimeout()
    {
        static void Act() => Deadline.SetIn(TimeSpan.FromTicks(-1));

        await Assert.That(Deadline.SetIn(TimeSpan.Zero).HasExpired).IsTrue();
        await Assert.That(Deadline.SetIn(Timeout.InfiniteTimeSpan)).IsEqualTo(Deadline.Eternal);
        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName("duration");
    }

    // Each row: the timestamp frequency of the clock, a duration in ticks, and the same duration in units of the clock.
    [Test]
    [Arguments(10_000_000L, 1L, 1L)]
    [Arguments(10_000_000L, long.MaxValue, long.MaxValue)]
    [Arguments(1_000L, 1L, 1L)]
    [Arguments(1_000L, 10_000L, 1L)]
    [Arguments(1_000L, 10_001L, 2L)]
    [Arguments(1_000_000_000L, 1L, 100L)]
    [Arguments(3L, 10_000_001L, 4L)]
    [Arguments(25_000_003L, 3L, 8L)]
    [Arguments(long.MaxValue, 1L, 922_337_203_686L)]
    public async Task SetIn_RoundsTheDurationUpToTheUnitsOfTheClock(long frequency, long ticks, long expectedUnits)
    {
        var clock = new TestTimeProvider(frequency);

        var deadline = Deadline.SetIn(new TimeSpan(ticks), clock);

        clock.Timestamp = expectedUnits - 1;
        await Assert.That(deadline.HasExpired).IsFalse();

        clock.Timestamp = expectedUnits;
        await Assert.That(deadline.HasExpired).IsTrue();
    }

    // Each row: the timestamp frequency of the clock, its timestamp at the call, and a duration in ticks.
    [Test]
    [Arguments(10_000_000L, 1L, long.MaxValue)]
    [Arguments(10_000_000L, long.MaxValue, 1L)]
    [Arguments(1_000_000_000L, 0L, long.MaxValue)]
    [Arguments(long.MaxValue, 0L, long.MaxValue)]
    public async Task SetIn_WithInstantBeyondTheTimestampsOfTheClock_ReturnsEternal(
        long frequency,
        long timestamp,
        long ticks)
    {
        var clock = new TestTimeProvider(frequency) { Timestamp = timestamp };

        var deadline = Deadline.SetIn(new TimeSpan(ticks), clock);

        await Assert.That(deadline).IsEqualTo(Deadline.Eternal);
    }

    [Test]
    public async Task SetAt_WithFutureInstant_ExpiresWhenTheClockReachesTheInstant()
    {
        var clock = new FakeTimeProvider();
        var instant = clock.GetUtcNow() + TimeSpan.FromSeconds(5);

        var deadline = Deadline.SetAt(instant, clock);

        await Assert.That(deadline.TimeProvider).IsSameReferenceAs(clock);
        await Assert.That(deadline.IsEternal).IsFalse();
        await Assert.That(deadline.HasExpired).IsFalse();
        await Assert.That(deadline.RemainingTime).IsEqualTo(TimeSpan.FromSeconds(5));

        clock.SetUtcNow(instant);

        await Assert.That(deadline.HasExpired).IsTrue();
        await Assert.That(deadline.RemainingTime).IsEqualTo(TimeSpan.Zero);
    }

    [Test]
    public async Task SetAt_WithInstantAtAnotherOffset_ReturnsTheSameDeadline()
    {
        var clock = new FakeTimeProvider();
        var instant = clock.GetUtcNow() + TimeSpan.FromSeconds(5);

        var deadline = Deadline.SetAt(instant.ToOffset(TimeSpan.FromHours(1)), clock);

        await Assert.That(deadline).IsEqualTo(Deadline.SetAt(instant, clock));
    }

    [Test]
    [Arguments(0)]
    [Arguments(-5)]
    public async Task SetAt_WithInstantNotInTheFuture_ReturnsAnExpiredDeadlineOnTheClock(int seconds)
    {
        var clock = new FakeTimeProvider();
        var instant = clock.GetUtcNow() + TimeSpan.FromSeconds(seconds);

        var deadline = Deadline.SetAt(instant, clock);

        await Assert.That(deadline.HasExpired).IsTrue();
        await Assert.That(deadline.RemainingTime).IsEqualTo(TimeSpan.Zero);
        await Assert.That(deadline.TimeProvider).IsSameReferenceAs(clock);
        await Assert.That(deadline).IsNotEqualTo(Deadline.Expired);
    }

    [Test]
    public async Task SetAt_WhenTheDateOfTheClockChangesLater_KeepsTheRemainingTime()
    {
        var clock = new TestTimeProvider(TimeSpan.TicksPerSecond);
        var deadline = Deadline.SetAt(clock.GetUtcNow() + TimeSpan.FromSeconds(5), clock);

        clock.AdjustTime(clock.GetUtcNow() + TimeSpan.FromHours(1));

        await Assert.That(deadline.HasExpired).IsFalse();
        await Assert.That(deadline.RemainingTime).IsEqualTo(TimeSpan.FromSeconds(5));
    }

    [Test]
    public async Task SetAt_WithFutureInstantBeyondTheTimestampsOfTheClock_ReturnsEternal()
    {
        var clock = new TestTimeProvider(1_000_000_000);

        var deadline = Deadline.SetAt(DateTimeOffset.MaxValue, clock);

        await Assert.That(deadline).IsEqualTo(Deadline.Eternal);
    }

    [Test]
    public async Task SetAt_WithPastInstantBeyondTheTimestampsOfTheClock_ReturnsExpired()
    {
        var clock = new TestTimeProvider(1_000_000_000);

        var deadline = Deadline.SetAt(DateTimeOffset.MinValue, clock);

        await Assert.That(deadline).IsEqualTo(Deadline.Expired);
    }

    [Test]
    public async Task SetAt_WithNullTimeProvider_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            Deadline.SetAt(DateTimeOffset.MinValue, null!);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("timeProvider");
    }

    [Test]
    [Arguments(0L)]
    [Arguments(-1L)]
    public async Task SetAt_WithTimestampFrequencyNotPositive_ThrowsArgumentException(long frequency)
    {
        var clock = new TestTimeProvider(frequency);

        void Act() => Deadline.SetAt(clock.GetUtcNow(), clock);

        await Assert.That(Act).ThrowsExactly<ArgumentException>().WithParameterName("timeProvider");
    }

    [Test]
    public async Task SetAt_WithoutTimeProvider_SetsTheDeadlineOnTheSystemClock()
    {
        var deadline = Deadline.SetAt(DateTimeOffset.UtcNow + TimeSpan.FromDays(1));

        var remainingTime = deadline.RemainingTime;
        await Assert.That(deadline.TimeProvider).IsSameReferenceAs(TimeProvider.System);
        await Assert.That(deadline.HasExpired).IsFalse();
        await Assert.That(remainingTime).IsGreaterThan(TimeSpan.FromHours(23));
        await Assert.That(remainingTime).IsLessThan(TimeSpan.FromHours(25));
    }

    [Test]
    public async Task SetAt_WithoutTimeProvider_WithPastInstant_ReturnsAnExpiredDeadline()
    {
        var deadline = Deadline.SetAt(DateTimeOffset.UtcNow - TimeSpan.FromDays(1));

        await Assert.That(deadline.HasExpired).IsTrue();
    }

    // Each row: the timestamp frequency of the clock, the time that remains in units of the clock, and the same time in ticks.
    [Test]
    [Arguments(10_000_000L, 1L, 1L)]
    [Arguments(1_000_000_000L, 1L, 1L)]
    [Arguments(1_000_000_000L, 100L, 1L)]
    [Arguments(1_000_000_000L, 101L, 2L)]
    [Arguments(1_000L, 1L, 10_000L)]
    [Arguments(3L, 1L, 3_333_334L)]
    [Arguments(3L, 4L, 13_333_334L)]
    [Arguments(10_000_000_000_000L, 1L, 1L)]
    [Arguments(10_000_000_000_000L, 5_000_000_000_000L, 5_000_000L)]
    [Arguments(10_000_000_000_000L, 5_000_000_000_001L, 5_000_001L)]
    [Arguments(long.MaxValue, long.MaxValue - 1, 10_000_000L)]
    public async Task RemainingTime_RoundsTheTimeUpToATick(long frequency, long units, long expectedTicks)
    {
        var clock = new TestTimeProvider(frequency) { Timestamp = units };
        var deadline = Deadline.SetIn(TimeSpan.Zero, clock);

        clock.Timestamp = 0;

        await Assert.That(deadline.HasExpired).IsFalse();
        await Assert.That(deadline.RemainingTime).IsEqualTo(new TimeSpan(expectedTicks));
    }

    // Each row: the timestamp frequency of the clock, the timestamp of the deadline, the timestamp of the clock,
    // and the time that remains in ticks.
    [Test]
    [Arguments(long.MaxValue, long.MaxValue, long.MinValue, 20_000_001L)]
    [Arguments(10_000_000L, long.MaxValue, 0L, long.MaxValue)]
    [Arguments(10_000_000L, long.MaxValue, -1L, long.MaxValue)]
    [Arguments(10_000_000L, long.MaxValue, long.MinValue, long.MaxValue)]
    [Arguments(1L, long.MaxValue, 0L, long.MaxValue)]
    public async Task RemainingTime_WithDistantInstant_IsAtMostTimeSpanMaxValue(
        long frequency,
        long instant,
        long now,
        long expectedTicks)
    {
        var clock = new TestTimeProvider(frequency) { Timestamp = instant };
        var deadline = Deadline.SetIn(TimeSpan.Zero, clock);

        clock.Timestamp = now;

        await Assert.That(deadline.HasExpired).IsFalse();
        await Assert.That(deadline.RemainingTime).IsEqualTo(new TimeSpan(expectedTicks));
    }

    [Test]
    public async Task ThrowIfExpired_BeforeTheDeadlineExpires_DoesNotThrow()
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);

        void Act() => deadline.ThrowIfExpired();

        await Assert.That(Act).ThrowsNothing();
    }

    [Test]
    public async Task ThrowIfExpired_AfterTheDeadlineExpires_ThrowsTimeoutException()
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);
        clock.Advance(TimeSpan.FromSeconds(5));

        void Act() => deadline.ThrowIfExpired();

        await Assert.That(Act).ThrowsExactly<TimeoutException>();
    }

    [Test]
    public async Task ThrowIfExpired_OnEternal_DoesNotThrow()
    {
        static void Act() => Deadline.Eternal.ThrowIfExpired();

        await Assert.That(Act).ThrowsNothing();
    }

    [Test]
    public async Task ThrowIfExpired_OnExpired_ThrowsTimeoutException()
    {
        static void Act() => Deadline.Expired.ThrowIfExpired();

        await Assert.That(Act).ThrowsExactly<TimeoutException>();
    }

    [Test]
    public async Task ToString_OnEternal_ReturnsEternal()
    {
        var result = Deadline.Eternal.ToString();

        await Assert.That(result).IsEqualTo("Eternal");
    }

    [Test]
    public async Task ToString_OnExpired_ReturnsExpired()
    {
        var result = Deadline.Expired.ToString();

        await Assert.That(result).IsEqualTo("Expired");
    }

    [Test]
    public async Task ToString_BeforeTheDeadlineExpires_ReturnsTheRemainingTime()
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromMilliseconds(3_723_500), clock);

        var result = deadline.ToString();

        await Assert.That(result).IsEqualTo("01:02:03.5000000");
    }

    [Test]
    public async Task ToString_AfterTheDeadlineExpires_ReturnsExpired()
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);
        clock.Advance(TimeSpan.FromSeconds(5));

        var result = deadline.ToString();

        await Assert.That(result).IsEqualTo("Expired");
    }

    [Test]
    public async Task Equals_WithSameClockAndInstant_ReturnsTrue()
    {
        var clock = new FakeTimeProvider();
        var a = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);
        var b = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);

        await Assert.That(a.Equals(b)).IsTrue();
        await Assert.That(a.Equals((object)b)).IsTrue();
        await Assert.That(a == b).IsTrue();
        await Assert.That(a != b).IsFalse();
        await Assert.That(a.GetHashCode()).IsEqualTo(b.GetHashCode());
    }

    [Test]
    public async Task Equals_WithDifferentInstant_ReturnsFalse()
    {
        var clock = new FakeTimeProvider();
        var a = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);
        var b = Deadline.SetIn(TimeSpan.FromSeconds(6), clock);

        await Assert.That(a.Equals(b)).IsFalse();
        await Assert.That(a.Equals((object)b)).IsFalse();
        await Assert.That(a == b).IsFalse();
        await Assert.That(a != b).IsTrue();
    }

    [Test]
    public async Task Equals_WithDifferentClock_ReturnsFalse()
    {
        var a = Deadline.SetIn(TimeSpan.FromSeconds(5), new FakeTimeProvider());
        var b = Deadline.SetIn(TimeSpan.FromSeconds(5), new FakeTimeProvider());

        await Assert.That(a.Equals(b)).IsFalse();
        await Assert.That(a.Equals((object)b)).IsFalse();
        await Assert.That(a == b).IsFalse();
        await Assert.That(a != b).IsTrue();
    }

    [Test]
    public async Task Equals_OnExpired_WithExpired_ReturnsTrue()
    {
        var a = Deadline.Expired;
        var b = Deadline.Expired;

        await Assert.That(a.Equals(b)).IsTrue();
        await Assert.That(a.Equals((object)b)).IsTrue();
        await Assert.That(a == b).IsTrue();
        await Assert.That(a != b).IsFalse();
        await Assert.That(a.GetHashCode()).IsEqualTo(b.GetHashCode());
    }

    [Test]
    public async Task Equals_OnExpired_WithEternal_ReturnsFalse()
    {
        var a = Deadline.Expired;
        var b = Deadline.Eternal;

        await Assert.That(a.Equals(b)).IsFalse();
        await Assert.That(a.Equals((object)b)).IsFalse();
        await Assert.That(a == b).IsFalse();
        await Assert.That(a != b).IsTrue();
    }

    [Test]
    public async Task Equals_WithObjectOfAnotherType_ReturnsFalse()
    {
        var a = Deadline.Expired;
        object other = TimeSpan.Zero;

        await Assert.That(a.Equals(other)).IsFalse();
        await Assert.That(a.Equals(null)).IsFalse();
    }
}
