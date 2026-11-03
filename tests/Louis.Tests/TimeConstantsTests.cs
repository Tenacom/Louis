// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis;

internal sealed class TimeConstantsTests
{
    // TimeSpan has no constant for a week.
    private static readonly TimeSpan OneWeek = TimeSpan.FromDays(7);

    [Test]
    public async Task TicksPerMillisecond_IsOneMillisecond()
        => await Assert.That(TimeSpan.FromTicks(TimeConstants.TicksPerMillisecond)).IsEqualTo(TimeSpan.FromMilliseconds(1));

    [Test]
    public async Task MillisecondsPerSecond_IsOneSecond()
        => await Assert.That(TimeSpan.FromMilliseconds(TimeConstants.MillisecondsPerSecond)).IsEqualTo(TimeSpan.FromSeconds(1));

    [Test]
    public async Task SecondsPerMinute_IsOneMinute()
        => await Assert.That(TimeSpan.FromSeconds(TimeConstants.SecondsPerMinute)).IsEqualTo(TimeSpan.FromMinutes(1));

    [Test]
    public async Task MinutesPerHour_IsOneHour()
        => await Assert.That(TimeSpan.FromMinutes(TimeConstants.MinutesPerHour)).IsEqualTo(TimeSpan.FromHours(1));

    [Test]
    public async Task HoursPerDay_IsOneDay()
        => await Assert.That(TimeSpan.FromHours(TimeConstants.HoursPerDay)).IsEqualTo(TimeSpan.FromDays(1));

    [Test]
    public async Task DaysPerWeek_IsOneWeek()
        => await Assert.That(TimeSpan.FromDays(TimeConstants.DaysPerWeek)).IsEqualTo(OneWeek);

    [Test]
    public async Task TicksPerSecond_IsOneSecond()
        => await Assert.That(TimeSpan.FromTicks(TimeConstants.TicksPerSecond)).IsEqualTo(TimeSpan.FromSeconds(1));

    [Test]
    public async Task TicksPerMinute_IsOneMinute()
        => await Assert.That(TimeSpan.FromTicks(TimeConstants.TicksPerMinute)).IsEqualTo(TimeSpan.FromMinutes(1));

    [Test]
    public async Task TicksPerHour_IsOneHour()
        => await Assert.That(TimeSpan.FromTicks(TimeConstants.TicksPerHour)).IsEqualTo(TimeSpan.FromHours(1));

    [Test]
    public async Task TicksPerDay_IsOneDay()
        => await Assert.That(TimeSpan.FromTicks(TimeConstants.TicksPerDay)).IsEqualTo(TimeSpan.FromDays(1));

    [Test]
    public async Task TicksPerWeek_IsOneWeek()
        => await Assert.That(TimeSpan.FromTicks(TimeConstants.TicksPerWeek)).IsEqualTo(OneWeek);

    [Test]
    public async Task MillisecondsPerMinute_IsOneMinute()
        => await Assert.That(TimeSpan.FromMilliseconds(TimeConstants.MillisecondsPerMinute)).IsEqualTo(TimeSpan.FromMinutes(1));

    [Test]
    public async Task MillisecondsPerHour_IsOneHour()
        => await Assert.That(TimeSpan.FromMilliseconds(TimeConstants.MillisecondsPerHour)).IsEqualTo(TimeSpan.FromHours(1));

    [Test]
    public async Task MillisecondsPerDay_IsOneDay()
        => await Assert.That(TimeSpan.FromMilliseconds(TimeConstants.MillisecondsPerDay)).IsEqualTo(TimeSpan.FromDays(1));

    [Test]
    public async Task MillisecondsPerWeek_IsOneWeek()
        => await Assert.That(TimeSpan.FromMilliseconds(TimeConstants.MillisecondsPerWeek)).IsEqualTo(OneWeek);

    [Test]
    public async Task SecondsPerHour_IsOneHour()
        => await Assert.That(TimeSpan.FromSeconds(TimeConstants.SecondsPerHour)).IsEqualTo(TimeSpan.FromHours(1));

    [Test]
    public async Task SecondsPerDay_IsOneDay()
        => await Assert.That(TimeSpan.FromSeconds(TimeConstants.SecondsPerDay)).IsEqualTo(TimeSpan.FromDays(1));

    [Test]
    public async Task SecondsPerWeek_IsOneWeek()
        => await Assert.That(TimeSpan.FromSeconds(TimeConstants.SecondsPerWeek)).IsEqualTo(OneWeek);

    [Test]
    public async Task MinutesPerDay_IsOneDay()
        => await Assert.That(TimeSpan.FromMinutes(TimeConstants.MinutesPerDay)).IsEqualTo(TimeSpan.FromDays(1));

    [Test]
    public async Task MinutesPerWeek_IsOneWeek()
        => await Assert.That(TimeSpan.FromMinutes(TimeConstants.MinutesPerWeek)).IsEqualTo(OneWeek);

    [Test]
    public async Task HoursPerWeek_IsOneWeek()
        => await Assert.That(TimeSpan.FromHours(TimeConstants.HoursPerWeek)).IsEqualTo(OneWeek);
}
