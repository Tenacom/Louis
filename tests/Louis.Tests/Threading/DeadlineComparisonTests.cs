// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;
using Microsoft.Extensions.Time.Testing;

internal sealed class DeadlineComparisonTests
{
    // Each row: the seconds to the first deadline, the seconds to the second deadline,
    // the seconds the clock advances before the call, and the sign of the result.
    [Test]
    [Arguments(5, 8, 0, -1)]
    [Arguments(8, 5, 0, 1)]
    [Arguments(5, 5, 0, 0)]
    [Arguments(5, 8, 6, -1)]
    [Arguments(5, 8, 10, -1)]
    [Arguments(8, 5, 10, 1)]
    [Arguments(5, 5, 10, 0)]
    public async Task Compare_OnOneClock_ComparesTheInstants(
        int firstSeconds,
        int secondSeconds,
        int elapsedSeconds,
        int expectedSign)
    {
        var clock = new FakeTimeProvider();
        var first = Deadline.SetIn(TimeSpan.FromSeconds(firstSeconds), clock);
        var second = Deadline.SetIn(TimeSpan.FromSeconds(secondSeconds), clock);
        clock.Advance(TimeSpan.FromSeconds(elapsedSeconds));

        var result = Deadline.Compare(first, second);

        await Assert.That(Math.Sign(result)).IsEqualTo(expectedSign);
    }

    [Test]
    public async Task Compare_OnOneClock_WithInstantsFurtherApartThanInt64MaxValue_ComparesTheInstants()
    {
        var clock = new TestTimeProvider(TimeSpan.TicksPerSecond) { Timestamp = long.MinValue };
        var first = Deadline.SetIn(TimeSpan.Zero, clock);
        clock.Timestamp = long.MaxValue;
        var second = Deadline.SetIn(TimeSpan.Zero, clock);

        await Assert.That(Deadline.Compare(first, second)).IsLessThan(0);
        await Assert.That(Deadline.Compare(second, first)).IsGreaterThan(0);
    }

    // Each row: the seconds to the first deadline, the seconds its clock advances before the call,
    // the seconds to the second deadline, the seconds its clock advances before the call, and the sign of the result.
    [Test]
    [Arguments(5, 0, 8, 0, -1)]
    [Arguments(8, 0, 5, 0, 1)]
    [Arguments(5, 0, 5, 0, 0)]
    [Arguments(5, 0, 8, 4, 1)]
    [Arguments(8, 3, 5, 0, 0)]
    [Arguments(5, 5, 8, 0, -1)]
    [Arguments(5, 0, 8, 8, 1)]
    public async Task Compare_OnTwoClocks_ComparesTheRemainingTimes(
        int firstSeconds,
        int firstElapsedSeconds,
        int secondSeconds,
        int secondElapsedSeconds,
        int expectedSign)
    {
        var firstClock = new FakeTimeProvider();
        var secondClock = new FakeTimeProvider();
        var first = Deadline.SetIn(TimeSpan.FromSeconds(firstSeconds), firstClock);
        var second = Deadline.SetIn(TimeSpan.FromSeconds(secondSeconds), secondClock);
        firstClock.Advance(TimeSpan.FromSeconds(firstElapsedSeconds));
        secondClock.Advance(TimeSpan.FromSeconds(secondElapsedSeconds));

        var result = Deadline.Compare(first, second);

        await Assert.That(Math.Sign(result)).IsEqualTo(expectedSign);
    }

    [Test]
    public async Task Compare_OnTwoClocks_WithTheSameRemainingTime_ReturnsZeroForDeadlinesThatAreNotEqual()
    {
        var first = Deadline.SetIn(TimeSpan.FromSeconds(5), new FakeTimeProvider());
        var second = Deadline.SetIn(TimeSpan.FromSeconds(5), new FakeTimeProvider());

        var result = Deadline.Compare(first, second);

        await Assert.That(result).IsEqualTo(0);
        await Assert.That(first).IsNotEqualTo(second);
    }

    [Test]
    public async Task Compare_OnTwoClocks_AfterBothDeadlinesExpire_ReturnsZero()
    {
        var firstClock = new FakeTimeProvider();
        var secondClock = new FakeTimeProvider();
        var first = Deadline.SetIn(TimeSpan.FromSeconds(5), firstClock);
        var second = Deadline.SetIn(TimeSpan.FromSeconds(8), secondClock);
        firstClock.Advance(TimeSpan.FromSeconds(20));
        secondClock.Advance(TimeSpan.FromSeconds(10));

        var result = Deadline.Compare(first, second);

        await Assert.That(result).IsEqualTo(0);
    }

    // Each row: the timestamp frequency of the first clock, the ticks to the first deadline,
    // the timestamp frequency of the second clock, the ticks to the second deadline, and the sign of the result.
    [Test]
    [Arguments(1_000L, 10_000L, 1_000_000_000L, 10_000L, 0)]
    [Arguments(1_000L, 10_001L, 1_000_000_000L, 10_001L, 1)]
    [Arguments(1_000_000_000L, 1L, 10_000_000L, 1L, 0)]
    [Arguments(3L, 1L, 10_000_000L, 3_333_334L, 0)]
    [Arguments(3L, 1L, 10_000_000L, 3_333_335L, -1)]
    public async Task Compare_OnTwoClocksWithDifferentFrequencies_ComparesTheRemainingTimes(
        long firstFrequency,
        long firstTicks,
        long secondFrequency,
        long secondTicks,
        int expectedSign)
    {
        var first = Deadline.SetIn(new TimeSpan(firstTicks), new TestTimeProvider(firstFrequency));
        var second = Deadline.SetIn(new TimeSpan(secondTicks), new TestTimeProvider(secondFrequency));

        var result = Deadline.Compare(first, second);

        await Assert.That(Math.Sign(result)).IsEqualTo(expectedSign);
    }

    [Test]
    public async Task Compare_WithEternal_ReportsEternalAsLaterThanEveryOtherDeadline()
    {
        var clock = new FakeTimeProvider();
        var distantClock = new TestTimeProvider(TimeSpan.TicksPerSecond) { Timestamp = long.MaxValue };
        var distant = Deadline.SetIn(TimeSpan.Zero, distantClock);
        distantClock.Timestamp = long.MinValue;
        Deadline[] others =
        [
            Deadline.SetIn(TimeSpan.FromSeconds(5), clock),
            Deadline.SetIn(TimeSpan.Zero, clock),
            distant,
            Deadline.Expired,
        ];

        await Assert.That(distant.RemainingTime).IsEqualTo(TimeSpan.MaxValue);
        foreach (var other in others)
        {
            await Assert.That(Deadline.Compare(Deadline.Eternal, other)).IsGreaterThan(0);
            await Assert.That(Deadline.Compare(other, Deadline.Eternal)).IsLessThan(0);
        }

        await Assert.That(Deadline.Compare(Deadline.Eternal, Deadline.Eternal)).IsEqualTo(0);
    }

    [Test]
    public async Task Compare_WithExpired_ReportsExpiredAsEarlierThanEveryOtherDeadline()
    {
        var clock = new FakeTimeProvider();
        Deadline[] others =
        [
            Deadline.SetIn(TimeSpan.FromSeconds(5), clock),
            Deadline.SetIn(TimeSpan.Zero, clock),
            Deadline.SetBefore(Deadline.SetIn(TimeSpan.Zero, clock), TimeSpan.FromSeconds(5)),
            Deadline.Eternal,
        ];

        foreach (var other in others)
        {
            await Assert.That(Deadline.Compare(Deadline.Expired, other)).IsLessThan(0);
            await Assert.That(Deadline.Compare(other, Deadline.Expired)).IsGreaterThan(0);
        }

        await Assert.That(Deadline.Compare(Deadline.Expired, Deadline.Expired)).IsEqualTo(0);
    }

    [Test]
    [MatrixDataSource]
    public async Task EarliestOf_WithTwoDeadlines_ReturnsTheOneThatExpiresFirst(
        [Matrix(false, true)] bool onTwoClocks,
        [Matrix(0, 1)] int earliestIndex)
    {
        var deadlines = SetDeadlines(2, onTwoClocks, earliestIndex, 5);

        var result = Deadline.EarliestOf(deadlines[0], deadlines[1]);

        await Assert.That(result).IsEqualTo(deadlines[earliestIndex]);
    }

    [Test]
    [MatrixDataSource]
    public async Task EarliestOf_WithThreeDeadlines_ReturnsTheOneThatExpiresFirst(
        [Matrix(false, true)] bool onTwoClocks,
        [Matrix(0, 1, 2)] int earliestIndex)
    {
        var deadlines = SetDeadlines(3, onTwoClocks, earliestIndex, 5);

        var result = Deadline.EarliestOf(deadlines[0], deadlines[1], deadlines[2]);

        await Assert.That(result).IsEqualTo(deadlines[earliestIndex]);
    }

    [Test]
    [MatrixDataSource]
    public async Task EarliestOf_WithFourDeadlines_ReturnsTheOneThatExpiresFirst(
        [Matrix(false, true)] bool onTwoClocks,
        [Matrix(0, 1, 2, 3)] int earliestIndex)
    {
        var deadlines = SetDeadlines(4, onTwoClocks, earliestIndex, 5);

        var result = Deadline.EarliestOf(deadlines[0], deadlines[1], deadlines[2], deadlines[3]);

        await Assert.That(result).IsEqualTo(deadlines[earliestIndex]);
    }

    [Test]
    [MatrixDataSource]
    public async Task EarliestOf_WithFiveDeadlines_ReturnsTheOneThatExpiresFirst(
        [Matrix(false, true)] bool onTwoClocks,
        [Matrix(0, 1, 2, 3, 4)] int earliestIndex)
    {
        var deadlines = SetDeadlines(5, onTwoClocks, earliestIndex, 5);

        var result = Deadline.EarliestOf(deadlines[0], deadlines[1], deadlines[2], deadlines[3], deadlines[4]);

        await Assert.That(result).IsEqualTo(deadlines[earliestIndex]);
    }

    [Test]
    [MatrixDataSource]
    public async Task EarliestOf_WithSequence_ReturnsTheDeadlineThatExpiresFirst(
        [Matrix(false, true)] bool onTwoClocks,
        [Matrix(0, 3, 6)] int earliestIndex)
    {
        var deadlines = SetDeadlines(7, onTwoClocks, earliestIndex, 5);

        var result = Deadline.EarliestOf(deadlines.Select(x => x));

        await Assert.That(result).IsEqualTo(deadlines[earliestIndex]);
    }

    [Test]
    public async Task EarliestOf_WithDeadlinesThatCompareAsEqual_ReturnsTheFirst()
    {
        var a = Deadline.SetIn(TimeSpan.FromSeconds(5), new FakeTimeProvider());
        var b = Deadline.SetIn(TimeSpan.FromSeconds(5), new FakeTimeProvider());
        var c = Deadline.SetIn(TimeSpan.FromSeconds(5), new FakeTimeProvider());
        var d = Deadline.SetIn(TimeSpan.FromSeconds(5), new FakeTimeProvider());
        var e = Deadline.SetIn(TimeSpan.FromSeconds(5), new FakeTimeProvider());
        IEnumerable<Deadline> sequence = [e, d, c, b, a];

        await Assert.That(Deadline.EarliestOf(a, b)).IsEqualTo(a);
        await Assert.That(Deadline.EarliestOf(b, a)).IsEqualTo(b);
        await Assert.That(Deadline.EarliestOf(b, a, c)).IsEqualTo(b);
        await Assert.That(Deadline.EarliestOf(c, b, a, d)).IsEqualTo(c);
        await Assert.That(Deadline.EarliestOf(d, c, b, a, e)).IsEqualTo(d);
        await Assert.That(Deadline.EarliestOf(sequence)).IsEqualTo(e);
    }

    [Test]
    public async Task EarliestOf_WithEternalOrExpired_OrdersThemAsCompareDoes()
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);
        var expiredOnClock = Deadline.SetIn(TimeSpan.Zero, clock);

        await Assert.That(Deadline.EarliestOf(deadline, Deadline.Eternal)).IsEqualTo(deadline);
        await Assert.That(Deadline.EarliestOf(Deadline.Eternal, deadline)).IsEqualTo(deadline);
        await Assert.That(Deadline.EarliestOf(expiredOnClock, Deadline.Expired)).IsEqualTo(Deadline.Expired);
        await Assert.That(Deadline.EarliestOf(Deadline.Expired, expiredOnClock)).IsEqualTo(Deadline.Expired);
        await Assert.That(Deadline.EarliestOf(Deadline.Eternal, Deadline.Eternal)).IsEqualTo(Deadline.Eternal);
    }

    [Test]
    public async Task EarliestOf_WithOneDeadline_ReturnsTheDeadline()
    {
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), new FakeTimeProvider());

        await Assert.That(Deadline.EarliestOf(deadline)).IsEqualTo(deadline);
        await Assert.That(Deadline.EarliestOf(Deadline.Eternal)).IsEqualTo(Deadline.Eternal);
        await Assert.That(Deadline.EarliestOf(Deadline.Expired)).IsEqualTo(Deadline.Expired);
    }

    [Test]
    public async Task EarliestOf_WithEmptySequence_ReturnsEternal()
    {
        await Assert.That(Deadline.EarliestOf()).IsEqualTo(Deadline.Eternal);
        await Assert.That(Deadline.EarliestOf([])).IsEqualTo(Deadline.Eternal);
    }

    [Test]
    public async Task EarliestOf_WithNullSequence_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            Deadline.EarliestOf(null!);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("deadlines");
    }

    [Test]
    [MatrixDataSource]
    public async Task LatestOf_WithTwoDeadlines_ReturnsTheOneThatExpiresLast(
        [Matrix(false, true)] bool onTwoClocks,
        [Matrix(0, 1)] int latestIndex)
    {
        var deadlines = SetDeadlines(2, onTwoClocks, latestIndex, 60);

        var result = Deadline.LatestOf(deadlines[0], deadlines[1]);

        await Assert.That(result).IsEqualTo(deadlines[latestIndex]);
    }

    [Test]
    [MatrixDataSource]
    public async Task LatestOf_WithThreeDeadlines_ReturnsTheOneThatExpiresLast(
        [Matrix(false, true)] bool onTwoClocks,
        [Matrix(0, 1, 2)] int latestIndex)
    {
        var deadlines = SetDeadlines(3, onTwoClocks, latestIndex, 60);

        var result = Deadline.LatestOf(deadlines[0], deadlines[1], deadlines[2]);

        await Assert.That(result).IsEqualTo(deadlines[latestIndex]);
    }

    [Test]
    [MatrixDataSource]
    public async Task LatestOf_WithFourDeadlines_ReturnsTheOneThatExpiresLast(
        [Matrix(false, true)] bool onTwoClocks,
        [Matrix(0, 1, 2, 3)] int latestIndex)
    {
        var deadlines = SetDeadlines(4, onTwoClocks, latestIndex, 60);

        var result = Deadline.LatestOf(deadlines[0], deadlines[1], deadlines[2], deadlines[3]);

        await Assert.That(result).IsEqualTo(deadlines[latestIndex]);
    }

    [Test]
    [MatrixDataSource]
    public async Task LatestOf_WithFiveDeadlines_ReturnsTheOneThatExpiresLast(
        [Matrix(false, true)] bool onTwoClocks,
        [Matrix(0, 1, 2, 3, 4)] int latestIndex)
    {
        var deadlines = SetDeadlines(5, onTwoClocks, latestIndex, 60);

        var result = Deadline.LatestOf(deadlines[0], deadlines[1], deadlines[2], deadlines[3], deadlines[4]);

        await Assert.That(result).IsEqualTo(deadlines[latestIndex]);
    }

    [Test]
    [MatrixDataSource]
    public async Task LatestOf_WithSequence_ReturnsTheDeadlineThatExpiresLast(
        [Matrix(false, true)] bool onTwoClocks,
        [Matrix(0, 3, 6)] int latestIndex)
    {
        var deadlines = SetDeadlines(7, onTwoClocks, latestIndex, 60);

        var result = Deadline.LatestOf(deadlines.Select(x => x));

        await Assert.That(result).IsEqualTo(deadlines[latestIndex]);
    }

    [Test]
    public async Task LatestOf_WithDeadlinesThatCompareAsEqual_ReturnsTheFirst()
    {
        var a = Deadline.SetIn(TimeSpan.FromSeconds(5), new FakeTimeProvider());
        var b = Deadline.SetIn(TimeSpan.FromSeconds(5), new FakeTimeProvider());
        var c = Deadline.SetIn(TimeSpan.FromSeconds(5), new FakeTimeProvider());
        var d = Deadline.SetIn(TimeSpan.FromSeconds(5), new FakeTimeProvider());
        var e = Deadline.SetIn(TimeSpan.FromSeconds(5), new FakeTimeProvider());
        IEnumerable<Deadline> sequence = [e, d, c, b, a];

        await Assert.That(Deadline.LatestOf(a, b)).IsEqualTo(a);
        await Assert.That(Deadline.LatestOf(b, a)).IsEqualTo(b);
        await Assert.That(Deadline.LatestOf(b, a, c)).IsEqualTo(b);
        await Assert.That(Deadline.LatestOf(c, b, a, d)).IsEqualTo(c);
        await Assert.That(Deadline.LatestOf(d, c, b, a, e)).IsEqualTo(d);
        await Assert.That(Deadline.LatestOf(sequence)).IsEqualTo(e);
    }

    [Test]
    public async Task LatestOf_WithEternalOrExpired_OrdersThemAsCompareDoes()
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);
        var expiredOnClock = Deadline.SetIn(TimeSpan.Zero, clock);

        await Assert.That(Deadline.LatestOf(deadline, Deadline.Eternal)).IsEqualTo(Deadline.Eternal);
        await Assert.That(Deadline.LatestOf(Deadline.Eternal, deadline)).IsEqualTo(Deadline.Eternal);
        await Assert.That(Deadline.LatestOf(expiredOnClock, Deadline.Expired)).IsEqualTo(expiredOnClock);
        await Assert.That(Deadline.LatestOf(Deadline.Expired, expiredOnClock)).IsEqualTo(expiredOnClock);
        await Assert.That(Deadline.LatestOf(Deadline.Expired, Deadline.Expired)).IsEqualTo(Deadline.Expired);
    }

    [Test]
    public async Task LatestOf_WithOneDeadline_ReturnsTheDeadline()
    {
        var deadline = Deadline.SetIn(TimeSpan.Zero, new FakeTimeProvider());

        await Assert.That(Deadline.LatestOf(deadline)).IsEqualTo(deadline);
        await Assert.That(Deadline.LatestOf(Deadline.Eternal)).IsEqualTo(Deadline.Eternal);
        await Assert.That(Deadline.LatestOf(Deadline.Expired)).IsEqualTo(Deadline.Expired);
    }

    [Test]
    public async Task LatestOf_WithEmptySequence_ReturnsExpired()
    {
        await Assert.That(Deadline.LatestOf()).IsEqualTo(Deadline.Expired);
        await Assert.That(Deadline.LatestOf([])).IsEqualTo(Deadline.Expired);
    }

    [Test]
    public async Task LatestOf_WithNullSequence_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            Deadline.LatestOf(null!);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("deadlines");
    }

    // Returns deadlines that expire 10 seconds from the call, 11 seconds, and so on, except the deadline at index,
    // which expires in the given seconds. With onTwoClocks, the deadlines at odd indexes are on a second clock.
    private static Deadline[] SetDeadlines(int count, bool onTwoClocks, int index, int seconds)
    {
        var clock = new FakeTimeProvider();
        var otherClock = onTwoClocks ? new FakeTimeProvider() : clock;
        return [.. Enumerable.Range(0, count).Select(SetDeadline)];

        Deadline SetDeadline(int i)
            => Deadline.SetIn(TimeSpan.FromSeconds(i == index ? seconds : 10 + i), i % 2 == 0 ? clock : otherClock);
    }
}
