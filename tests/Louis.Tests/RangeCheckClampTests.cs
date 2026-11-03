// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis;

internal sealed class RangeCheckClampTests
{
    [Test]
    [Arguments(0, 1)]
    [Arguments(1, 1)]
    [Arguments(5, 5)]
    [Arguments(10, 10)]
    [Arguments(11, 10)]
    public async Task Clamp_WithInt32_ReturnsClampedValue(int value, int expected)
    {
        await Assert.That(RangeCheck.Clamp(value, 1, 10)).IsEqualTo(expected);
    }

    [Test]
    public async Task Clamp_WithInt32AndMinGreaterThanMax_ThrowsArgumentException()
    {
        static void Act() => RangeCheck.Clamp(5, 10, 1);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("min");
    }

    [Test]
    [Arguments(0, 1)]
    [Arguments(1, 1)]
    [Arguments(5, 5)]
    [Arguments(10, 10)]
    [Arguments(11, 10)]
    public async Task Clamp_WithInt32AndComparer_ReturnsClampedValue(int value, int expected)
    {
        await Assert.That(RangeCheck.Clamp(value, 10, 1, ReverseComparer<int>.Instance)).IsEqualTo(expected);
    }

    [Test]
    public async Task Clamp_WithInt32AndComparerAndMinGreaterThanMax_ThrowsArgumentException()
    {
        static void Act() => RangeCheck.Clamp(5, 1, 10, ReverseComparer<int>.Instance);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("min");
    }

    [Test]
    public async Task Clamp_WithInt32AndNullComparer_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => RangeCheck.Clamp(5, 1, 10, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("comparer");
    }
}
