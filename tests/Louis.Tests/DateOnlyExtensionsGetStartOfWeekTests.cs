// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET6_0_OR_GREATER

using System.Globalization;
using Louis;

internal sealed class DateOnlyExtensionsGetStartOfWeekTests
{
    // Wednesday 2024-01-03.
    private static readonly DateOnly Wednesday = new DateOnly(2024, 1, 3);

    [Test]
    [Arguments(DayOfWeek.Sunday, 2023, 12, 31)]
    [Arguments(DayOfWeek.Monday, 2024, 1, 1)]
    [Arguments(DayOfWeek.Tuesday, 2024, 1, 2)]
    [Arguments(DayOfWeek.Wednesday, 2024, 1, 3)]
    [Arguments(DayOfWeek.Thursday, 2023, 12, 28)]
    [Arguments(DayOfWeek.Friday, 2023, 12, 29)]
    [Arguments(DayOfWeek.Saturday, 2023, 12, 30)]
    public async Task GetStartOfWeek_WithFirstDayOfWeek_ReturnsFirstDayOfWeek(
        DayOfWeek firstDayOfWeek,
        int year,
        int month,
        int day)
    {
        await Assert.That(Wednesday.GetStartOfWeek(firstDayOfWeek)).IsEqualTo(new DateOnly(year, month, day));
    }

    [Test]
    public async Task GetStartOfWeek_WithNullCulture_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => Wednesday.GetStartOfWeek((CultureInfo)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("culture");
    }

    [Test]
    public async Task GetStartOfWeek_WithCulture_UsesFirstDayOfWeekOfCulture()
    {
        var culture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Thursday;

        await Assert.That(Wednesday.GetStartOfWeek(culture)).IsEqualTo(new DateOnly(2023, 12, 28));
    }

    [Test]
    public async Task GetStartOfWeek_WithNullDateTimeFormat_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => Wednesday.GetStartOfWeek((DateTimeFormatInfo)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("dateTimeFormat");
    }

    [Test]
    public async Task GetStartOfWeek_WithDateTimeFormat_UsesFirstDayOfWeekOfDateTimeFormat()
    {
        var dateTimeFormat = (DateTimeFormatInfo)DateTimeFormatInfo.InvariantInfo.Clone();
        dateTimeFormat.FirstDayOfWeek = DayOfWeek.Thursday;

        await Assert.That(Wednesday.GetStartOfWeek(dateTimeFormat)).IsEqualTo(new DateOnly(2023, 12, 28));
    }

    [Test]
    [NotInParallel]
    public async Task GetStartOfWeek_WithoutCulture_UsesCurrentCulture()
    {
        var culture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Thursday;
        var previousCulture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = culture;
        DateOnly result;
        try
        {
#pragma warning disable CA1304 // Specify CultureInfo - the current-culture overload is the method under test
            result = Wednesday.GetStartOfWeek();
#pragma warning restore CA1304 // Specify CultureInfo
        }
        finally
        {
            CultureInfo.CurrentCulture = previousCulture;
        }

        await Assert.That(result).IsEqualTo(new DateOnly(2023, 12, 28));
    }
}

#endif
