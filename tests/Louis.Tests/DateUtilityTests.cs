// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Globalization;
using Louis;

internal sealed class DateUtilityTests
{
    [Test]
    [Arguments(DayOfWeek.Sunday, DayOfWeek.Sunday, 0)]
    [Arguments(DayOfWeek.Monday, DayOfWeek.Monday, 0)]
    [Arguments(DayOfWeek.Saturday, DayOfWeek.Saturday, 0)]
    [Arguments(DayOfWeek.Monday, DayOfWeek.Sunday, 1)]
    [Arguments(DayOfWeek.Tuesday, DayOfWeek.Monday, 1)]
    [Arguments(DayOfWeek.Sunday, DayOfWeek.Saturday, 1)]
    [Arguments(DayOfWeek.Saturday, DayOfWeek.Sunday, 6)]
    [Arguments(DayOfWeek.Sunday, DayOfWeek.Monday, 6)]
    [Arguments(DayOfWeek.Friday, DayOfWeek.Saturday, 6)]
    [Arguments(DayOfWeek.Wednesday, DayOfWeek.Sunday, 3)]
    [Arguments(DayOfWeek.Wednesday, DayOfWeek.Monday, 2)]
    [Arguments(DayOfWeek.Thursday, DayOfWeek.Monday, 3)]
    [Arguments(DayOfWeek.Monday, DayOfWeek.Thursday, 4)]
    public async Task GetDaysFromStartOfWeek_WithFirstDayOfWeek_ReturnsDaysBetween(
        DayOfWeek today,
        DayOfWeek firstDayOfWeek,
        int expected)
    {
        await Assert.That(DateUtility.GetDaysFromStartOfWeek(today, firstDayOfWeek)).IsEqualTo(expected);
    }

    [Test]
    public async Task GetDaysFromStartOfWeek_WithNullCulture_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => DateUtility.GetDaysFromStartOfWeek(DayOfWeek.Friday, (CultureInfo)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("culture");
    }

    [Test]
    public async Task GetDaysFromStartOfWeek_WithCulture_UsesFirstDayOfWeekOfCulture()
    {
        var culture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Wednesday;

        await Assert.That(DateUtility.GetDaysFromStartOfWeek(DayOfWeek.Friday, culture)).IsEqualTo(2);
    }

    [Test]
    public async Task GetDaysFromStartOfWeek_WithNullDateTimeFormat_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => DateUtility.GetDaysFromStartOfWeek(DayOfWeek.Friday, (DateTimeFormatInfo)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("dateTimeFormat");
    }

    [Test]
    public async Task GetDaysFromStartOfWeek_WithDateTimeFormat_UsesFirstDayOfWeekOfDateTimeFormat()
    {
        var dateTimeFormat = (DateTimeFormatInfo)DateTimeFormatInfo.InvariantInfo.Clone();
        dateTimeFormat.FirstDayOfWeek = DayOfWeek.Wednesday;

        await Assert.That(DateUtility.GetDaysFromStartOfWeek(DayOfWeek.Friday, dateTimeFormat)).IsEqualTo(2);
    }

    [Test]
    [NotInParallel]
    public async Task GetDaysFromStartOfWeek_WithoutCulture_UsesCurrentCulture()
    {
        var culture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Wednesday;
        var previousCulture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = culture;
        int result;
        try
        {
#pragma warning disable CA1304 // Specify CultureInfo - the current-culture overload is the method under test
            result = DateUtility.GetDaysFromStartOfWeek(DayOfWeek.Friday);
#pragma warning restore CA1304 // Specify CultureInfo
        }
        finally
        {
            CultureInfo.CurrentCulture = previousCulture;
        }

        await Assert.That(result).IsEqualTo(2);
    }
}
