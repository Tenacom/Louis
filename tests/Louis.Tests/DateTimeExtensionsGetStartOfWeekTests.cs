// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Globalization;
using Louis;

internal sealed class DateTimeExtensionsGetStartOfWeekTests
{
    // Wednesday 2024-01-03, in the afternoon, so that a result at midnight proves that the time of day is dropped.
    private static readonly DateTime WednesdayAfternoon = new DateTime(2024, 1, 3, 15, 30, 45);

    [Test]
    [Arguments(DayOfWeek.Sunday, 2023, 12, 31)]
    [Arguments(DayOfWeek.Monday, 2024, 1, 1)]
    [Arguments(DayOfWeek.Tuesday, 2024, 1, 2)]
    [Arguments(DayOfWeek.Wednesday, 2024, 1, 3)]
    [Arguments(DayOfWeek.Thursday, 2023, 12, 28)]
    [Arguments(DayOfWeek.Friday, 2023, 12, 29)]
    [Arguments(DayOfWeek.Saturday, 2023, 12, 30)]
    public async Task GetStartOfWeek_WithFirstDayOfWeek_ReturnsMidnightOnFirstDayOfWeek(
        DayOfWeek firstDayOfWeek,
        int year,
        int month,
        int day)
    {
        await Assert.That(WednesdayAfternoon.GetStartOfWeek(firstDayOfWeek)).IsEqualTo(new DateTime(year, month, day));
    }

    [Test]
    public async Task GetStartOfWeek_WithNullCulture_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => WednesdayAfternoon.GetStartOfWeek((CultureInfo)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("culture");
    }

    [Test]
    public async Task GetStartOfWeek_WithCulture_UsesFirstDayOfWeekOfCulture()
    {
        var culture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Thursday;

        await Assert.That(WednesdayAfternoon.GetStartOfWeek(culture)).IsEqualTo(new DateTime(2023, 12, 28));
    }

    [Test]
    public async Task GetStartOfWeek_WithNullDateTimeFormat_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => WednesdayAfternoon.GetStartOfWeek((DateTimeFormatInfo)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("dateTimeFormat");
    }

    [Test]
    public async Task GetStartOfWeek_WithDateTimeFormat_UsesFirstDayOfWeekOfDateTimeFormat()
    {
        var dateTimeFormat = (DateTimeFormatInfo)DateTimeFormatInfo.InvariantInfo.Clone();
        dateTimeFormat.FirstDayOfWeek = DayOfWeek.Thursday;

        await Assert.That(WednesdayAfternoon.GetStartOfWeek(dateTimeFormat)).IsEqualTo(new DateTime(2023, 12, 28));
    }

    [Test]
    [NotInParallel]
    public async Task GetStartOfWeek_WithoutCulture_UsesCurrentCulture()
    {
        var culture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Thursday;
        var previousCulture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = culture;
        DateTime result;
        try
        {
#pragma warning disable CA1304 // Specify CultureInfo - the current-culture overload is the method under test
            result = WednesdayAfternoon.GetStartOfWeek();
#pragma warning restore CA1304 // Specify CultureInfo
        }
        finally
        {
            CultureInfo.CurrentCulture = previousCulture;
        }

        await Assert.That(result).IsEqualTo(new DateTime(2023, 12, 28));
    }
}
