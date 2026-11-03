// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET6_0_OR_GREATER

using System.Globalization;
using Louis;

internal sealed class DateOnlyExtensionsGetEndOfWeekTests
{
    // Wednesday 2024-01-03.
    private static readonly DateOnly Wednesday = new DateOnly(2024, 1, 3);

    [Test]
    [Arguments(DayOfWeek.Sunday, 2024, 1, 6)]
    [Arguments(DayOfWeek.Monday, 2024, 1, 7)]
    [Arguments(DayOfWeek.Tuesday, 2024, 1, 8)]
    [Arguments(DayOfWeek.Wednesday, 2024, 1, 9)]
    [Arguments(DayOfWeek.Thursday, 2024, 1, 3)]
    [Arguments(DayOfWeek.Friday, 2024, 1, 4)]
    [Arguments(DayOfWeek.Saturday, 2024, 1, 5)]
    public async Task GetEndOfWeek_WithFirstDayOfWeek_ReturnsLastDayOfWeek(
        DayOfWeek firstDayOfWeek,
        int year,
        int month,
        int day)
    {
        await Assert.That(Wednesday.GetEndOfWeek(firstDayOfWeek)).IsEqualTo(new DateOnly(year, month, day));
    }

    [Test]
    public async Task GetEndOfWeek_WithNullCulture_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => Wednesday.GetEndOfWeek((CultureInfo)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("culture");
    }

    [Test]
    public async Task GetEndOfWeek_WithCulture_UsesFirstDayOfWeekOfCulture()
    {
        var culture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Thursday;

        await Assert.That(Wednesday.GetEndOfWeek(culture)).IsEqualTo(new DateOnly(2024, 1, 3));
    }

    [Test]
    public async Task GetEndOfWeek_WithNullDateTimeFormat_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => Wednesday.GetEndOfWeek((DateTimeFormatInfo)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("dateTimeFormat");
    }

    [Test]
    public async Task GetEndOfWeek_WithDateTimeFormat_UsesFirstDayOfWeekOfDateTimeFormat()
    {
        var dateTimeFormat = (DateTimeFormatInfo)DateTimeFormatInfo.InvariantInfo.Clone();
        dateTimeFormat.FirstDayOfWeek = DayOfWeek.Thursday;

        await Assert.That(Wednesday.GetEndOfWeek(dateTimeFormat)).IsEqualTo(new DateOnly(2024, 1, 3));
    }

    [Test]
    [NotInParallel]
    public async Task GetEndOfWeek_WithoutCulture_UsesCurrentCulture()
    {
        var culture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Thursday;
        var previousCulture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = culture;
        DateOnly result;
        try
        {
#pragma warning disable CA1304 // Specify CultureInfo - the current-culture overload is the method under test
            result = Wednesday.GetEndOfWeek();
#pragma warning restore CA1304 // Specify CultureInfo
        }
        finally
        {
            CultureInfo.CurrentCulture = previousCulture;
        }

        await Assert.That(result).IsEqualTo(new DateOnly(2024, 1, 3));
    }
}

#endif
