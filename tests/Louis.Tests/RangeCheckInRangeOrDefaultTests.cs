// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis;

internal sealed class RangeCheckInRangeOrDefaultTests
{
    [Test]
    [Arguments(0, -1)]
    [Arguments(1, 1)]
    [Arguments(5, 5)]
    [Arguments(10, 10)]
    [Arguments(11, -1)]
    public async Task InRangeOrDefault_WithInt32_ReturnsValueOrDefaultValue(int value, int expected)
    {
        await Assert.That(RangeCheck.InRangeOrDefault(value, 1, 10, -1)).IsEqualTo(expected);
    }

    [Test]
    public async Task InRangeOrDefault_WithInt32AndMinGreaterThanMax_ThrowsArgumentException()
    {
        static void Act() => RangeCheck.InRangeOrDefault(5, 10, 1, -1);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("min");
    }

    [Test]
    [Arguments(0, -1)]
    [Arguments(1, 1)]
    [Arguments(5, 5)]
    [Arguments(10, 10)]
    [Arguments(11, -1)]
    public async Task InRangeOrDefault_WithInt32AndComparer_ReturnsValueOrDefaultValue(int value, int expected)
    {
        await Assert.That(RangeCheck.InRangeOrDefault(value, 10, 1, -1, ReverseComparer<int>.Instance)).IsEqualTo(expected);
    }

    [Test]
    public async Task InRangeOrDefault_WithInt32AndComparerAndMinGreaterThanMax_ThrowsArgumentException()
    {
        static void Act() => RangeCheck.InRangeOrDefault(5, 1, 10, -1, ReverseComparer<int>.Instance);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("min");
    }

    [Test]
    public async Task InRangeOrDefault_WithInt32AndNullComparer_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => RangeCheck.InRangeOrDefault(5, 1, 10, -1, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("comparer");
    }

    [Test]
    [Arguments("a", "z")]
    [Arguments("b", "b")]
    [Arguments("c", "c")]
    [Arguments("d", "d")]
    [Arguments("e", "z")]
    public async Task InRangeOrDefault_WithString_ReturnsValueOrDefaultValue(string value, string expected)
    {
        await Assert.That(RangeCheck.InRangeOrDefault(value, "b", "d", "z", acceptNull: false)).IsEqualTo(expected);
    }

    [Test]
    [Arguments(true, null)]
    [Arguments(false, "z")]
    public async Task InRangeOrDefault_WithNullString_ReturnsNullOrDefaultValue(bool acceptNull, string? expected)
    {
        await Assert.That(RangeCheck.InRangeOrDefault(null, "b", "d", "z", acceptNull)).IsEqualTo(expected);
    }

    [Test]
    [Arguments("c")]
    [Arguments(null)]
    public async Task InRangeOrDefault_WithStringAndMinGreaterThanMax_ThrowsArgumentException(string? value)
    {
        void Act() => RangeCheck.InRangeOrDefault(value, "d", "b", "z", acceptNull: true);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("min");
    }

    [Test]
    [Arguments("a", "z")]
    [Arguments("b", "b")]
    [Arguments("c", "c")]
    [Arguments("d", "d")]
    [Arguments("e", "z")]
    public async Task InRangeOrDefault_WithStringAndComparer_ReturnsValueOrDefaultValue(string value, string expected)
    {
        var result = RangeCheck.InRangeOrDefault(value, "d", "b", "z", acceptNull: false, ReverseComparer<string>.Instance);

        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    [Arguments(true, null)]
    [Arguments(false, "z")]
    public async Task InRangeOrDefault_WithNullStringAndComparer_ReturnsNullOrDefaultValue(
        bool acceptNull,
        string? expected)
    {
        var result = RangeCheck.InRangeOrDefault(null, "d", "b", "z", acceptNull, ReverseComparer<string>.Instance);

        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    [Arguments("c")]
    [Arguments(null)]
    public async Task InRangeOrDefault_WithStringAndComparerAndMinGreaterThanMax_ThrowsArgumentException(string? value)
    {
        void Act() => RangeCheck.InRangeOrDefault(value, "b", "d", "z", acceptNull: true, ReverseComparer<string>.Instance);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("min");
    }

    [Test]
    [Arguments("c")]
    [Arguments(null)]
    public async Task InRangeOrDefault_WithStringAndNullComparer_ThrowsArgumentNullException(string? value)
    {
        // ! Null on purpose: testing null detection
        void Act() => RangeCheck.InRangeOrDefault(value, "b", "d", "z", acceptNull: true, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("comparer");
    }

    [Test]
    [Arguments(0, -1)]
    [Arguments(1, 1)]
    [Arguments(5, 5)]
    [Arguments(10, 10)]
    [Arguments(11, -1)]
    public async Task InRangeOrDefault_WithNullableInt32_ReturnsValueOrDefaultValue(int? value, int? expected)
    {
        await Assert.That(RangeCheck.InRangeOrDefault(value, 1, 10, -1, acceptNull: false)).IsEqualTo(expected);
    }

    [Test]
    [Arguments(true, null)]
    [Arguments(false, -1)]
    public async Task InRangeOrDefault_WithNullInt32_ReturnsNullOrDefaultValue(bool acceptNull, int? expected)
    {
        await Assert.That(RangeCheck.InRangeOrDefault(null, 1, 10, -1, acceptNull)).IsEqualTo(expected);
    }

    [Test]
    [Arguments(5)]
    [Arguments(null)]
    public async Task InRangeOrDefault_WithNullableInt32AndMinGreaterThanMax_ThrowsArgumentException(int? value)
    {
        void Act() => RangeCheck.InRangeOrDefault(value, 10, 1, -1, acceptNull: true);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("min");
    }

    [Test]
    [Arguments(0, -1)]
    [Arguments(1, 1)]
    [Arguments(5, 5)]
    [Arguments(10, 10)]
    [Arguments(11, -1)]
    public async Task InRangeOrDefault_WithNullableInt32AndComparer_ReturnsValueOrDefaultValue(
        int? value,
        int? expected)
    {
        var result = RangeCheck.InRangeOrDefault(value, 10, 1, -1, acceptNull: false, ReverseComparer<int>.Instance);

        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    [Arguments(true, null)]
    [Arguments(false, -1)]
    public async Task InRangeOrDefault_WithNullInt32AndComparer_ReturnsNullOrDefaultValue(
        bool acceptNull,
        int? expected)
    {
        var result = RangeCheck.InRangeOrDefault(null, 10, 1, -1, acceptNull, ReverseComparer<int>.Instance);

        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    [Arguments(5)]
    [Arguments(null)]
    public async Task InRangeOrDefault_WithNullableInt32AndComparerAndMinGreaterThanMax_ThrowsArgumentException(
        int? value)
    {
        void Act() => RangeCheck.InRangeOrDefault(value, 1, 10, -1, acceptNull: true, ReverseComparer<int>.Instance);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("min");
    }

    [Test]
    [Arguments(5)]
    [Arguments(null)]
    public async Task InRangeOrDefault_WithNullableInt32AndNullComparer_ThrowsArgumentNullException(int? value)
    {
        // ! Null on purpose: testing null detection
        void Act() => RangeCheck.InRangeOrDefault(value, 1, 10, -1, acceptNull: true, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("comparer");
    }
}
