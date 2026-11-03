// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Globalization;
using Louis;

internal sealed class DateTimeExtensionsGetEndOfWeekTests
{
    // Wednesday 2024-01-03, in the afternoon, so that a result at the last tick proves that the time of day is dropped.
    private static readonly DateTime WednesdayAfternoon = new DateTime(2024, 1, 3, 15, 30, 45);

    [Test]
    [Arguments(DayOfWeek.Sunday, 2024, 1, 6)]
    [Arguments(DayOfWeek.Monday, 2024, 1, 7)]
    [Arguments(DayOfWeek.Tuesday, 2024, 1, 8)]
    [Arguments(DayOfWeek.Wednesday, 2024, 1, 9)]
    [Arguments(DayOfWeek.Thursday, 2024, 1, 3)]
    [Arguments(DayOfWeek.Friday, 2024, 1, 4)]
    [Arguments(DayOfWeek.Saturday, 2024, 1, 5)]
    public async Task GetEndOfWeek_WithFirstDayOfWeek_ReturnsLastTickOfLastDayOfWeek(
        DayOfWeek firstDayOfWeek,
        int year,
        int month,
        int day)
    {
        var expected = new DateTime(year, month, day).AddDays(1).AddTicks(-1);

        await Assert.That(WednesdayAfternoon.GetEndOfWeek(firstDayOfWeek)).IsEqualTo(expected);
    }

    [Test]
    public async Task GetEndOfWeek_WithNullCulture_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => WednesdayAfternoon.GetEndOfWeek((CultureInfo)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("culture");
    }

    [Test]
    public async Task GetEndOfWeek_WithCulture_UsesFirstDayOfWeekOfCulture()
    {
        var culture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Thursday;

        await Assert.That(WednesdayAfternoon.GetEndOfWeek(culture)).IsEqualTo(new DateTime(2024, 1, 4).AddTicks(-1));
    }

    [Test]
    public async Task GetEndOfWeek_WithNullDateTimeFormat_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => WednesdayAfternoon.GetEndOfWeek((DateTimeFormatInfo)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("dateTimeFormat");
    }

    [Test]
    public async Task GetEndOfWeek_WithDateTimeFormat_UsesFirstDayOfWeekOfDateTimeFormat()
    {
        var dateTimeFormat = (DateTimeFormatInfo)DateTimeFormatInfo.InvariantInfo.Clone();
        dateTimeFormat.FirstDayOfWeek = DayOfWeek.Thursday;

        await Assert.That(WednesdayAfternoon.GetEndOfWeek(dateTimeFormat)).IsEqualTo(new DateTime(2024, 1, 4).AddTicks(-1));
    }

    [Test]
    [NotInParallel]
    public async Task GetEndOfWeek_WithoutCulture_UsesCurrentCulture()
    {
        var culture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Thursday;
        var previousCulture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = culture;
        DateTime result;
        try
        {
#pragma warning disable CA1304 // Specify CultureInfo - the current-culture overload is the method under test
            result = WednesdayAfternoon.GetEndOfWeek();
#pragma warning restore CA1304 // Specify CultureInfo
        }
        finally
        {
            CultureInfo.CurrentCulture = previousCulture;
        }

        await Assert.That(result).IsEqualTo(new DateTime(2024, 1, 4).AddTicks(-1));
    }
}
