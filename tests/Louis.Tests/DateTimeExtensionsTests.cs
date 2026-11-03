// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis;

internal sealed class DateTimeExtensionsTests
{
    [Test]
    [Arguments(DateTimeKind.Unspecified)]
    [Arguments(DateTimeKind.Utc)]
    [Arguments(DateTimeKind.Local)]
    public async Task GetEndOfDay_ReturnsLastTickOfDayWithSameKind(DateTimeKind kind)
    {
        var dateTime = new DateTime(2024, 1, 3, 15, 30, 45, kind);

        var result = dateTime.GetEndOfDay();

        await Assert.That(result).IsEqualTo(new DateTime(2024, 1, 4).AddTicks(-1));
        await Assert.That(result.Kind).IsEqualTo(kind);
    }

    [Test]
    [Arguments(2023, 2, 28)]
    [Arguments(2024, 2, 29)]
    [Arguments(2024, 4, 30)]
    [Arguments(2024, 1, 31)]
    public async Task GetStartOfMonth_ReturnsMidnightOnFirstDayOfMonth(int year, int month, int daysInMonth)
    {
        var dateTime = new DateTime(year, month, daysInMonth, 15, 30, 45);

        await Assert.That(dateTime.GetStartOfMonth()).IsEqualTo(new DateTime(year, month, 1));
    }

    [Test]
    [Arguments(2023, 2, 28)]
    [Arguments(2024, 2, 29)]
    [Arguments(2024, 4, 30)]
    [Arguments(2024, 1, 31)]
    public async Task GetLastDayOfMonth_ReturnsMidnightOnLastDayOfMonth(int year, int month, int daysInMonth)
    {
        var dateTime = new DateTime(year, month, 1, 15, 30, 45);

        await Assert.That(dateTime.GetLastDayOfMonth()).IsEqualTo(new DateTime(year, month, daysInMonth));
    }

    [Test]
    [Arguments(2023, 2, 28)]
    [Arguments(2024, 2, 29)]
    [Arguments(2024, 4, 30)]
    [Arguments(2024, 1, 31)]
    public async Task GetEndOfMonth_ReturnsLastTickOfLastDayOfMonth(int year, int month, int daysInMonth)
    {
        var dateTime = new DateTime(year, month, 1, 15, 30, 45);

        await Assert.That(dateTime.GetEndOfMonth()).IsEqualTo(new DateTime(year, month, daysInMonth).AddDays(1).AddTicks(-1));
    }
}
