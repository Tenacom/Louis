// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET6_0_OR_GREATER

using Louis;

internal sealed class DateOnlyExtensionsTests
{
    [Test]
    [Arguments(2023, 2, 28)]
    [Arguments(2024, 2, 29)]
    [Arguments(2024, 4, 30)]
    [Arguments(2024, 1, 31)]
    public async Task GetStartOfMonth_ReturnsFirstDayOfMonth(int year, int month, int daysInMonth)
    {
        var date = new DateOnly(year, month, daysInMonth);

        await Assert.That(date.GetStartOfMonth()).IsEqualTo(new DateOnly(year, month, 1));
    }

    [Test]
    [Arguments(2023, 2, 28)]
    [Arguments(2024, 2, 29)]
    [Arguments(2024, 4, 30)]
    [Arguments(2024, 1, 31)]
    public async Task GetEndOfMonth_ReturnsLastDayOfMonth(int year, int month, int daysInMonth)
    {
        var date = new DateOnly(year, month, 1);

        await Assert.That(date.GetEndOfMonth()).IsEqualTo(new DateOnly(year, month, daysInMonth));
    }
}

#endif
