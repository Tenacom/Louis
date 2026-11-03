// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis;

internal sealed class RangeCheckClampOrNullTests
{
    [Test]
    [Arguments("a", "b")]
    [Arguments("b", "b")]
    [Arguments("c", "c")]
    [Arguments("d", "d")]
    [Arguments("e", "d")]
    public async Task ClampOrNull_WithString_ReturnsClampedValue(string value, string expected)
    {
        await Assert.That(RangeCheck.ClampOrNull(value, "b", "d")).IsEqualTo(expected);
    }

    [Test]
    public async Task ClampOrNull_WithNullString_ReturnsNull()
    {
        await Assert.That(RangeCheck.ClampOrNull(null, "b", "d")).IsNull();
    }

    [Test]
    [Arguments("c")]
    [Arguments(null)]
    public async Task ClampOrNull_WithStringAndMinGreaterThanMax_ThrowsArgumentException(string? value)
    {
        void Act() => RangeCheck.ClampOrNull(value, "d", "b");

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("min");
    }

    [Test]
    [Arguments("a", "b")]
    [Arguments("b", "b")]
    [Arguments("c", "c")]
    [Arguments("d", "d")]
    [Arguments("e", "d")]
    public async Task ClampOrNull_WithStringAndComparer_ReturnsClampedValue(string value, string expected)
    {
        await Assert.That(RangeCheck.ClampOrNull(value, "d", "b", ReverseComparer<string>.Instance)).IsEqualTo(expected);
    }

    [Test]
    public async Task ClampOrNull_WithNullStringAndComparer_ReturnsNull()
    {
        await Assert.That(RangeCheck.ClampOrNull(null, "d", "b", ReverseComparer<string>.Instance)).IsNull();
    }

    [Test]
    [Arguments("c")]
    [Arguments(null)]
    public async Task ClampOrNull_WithStringAndComparerAndMinGreaterThanMax_ThrowsArgumentException(string? value)
    {
        void Act() => RangeCheck.ClampOrNull(value, "b", "d", ReverseComparer<string>.Instance);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("min");
    }

    [Test]
    [Arguments("c")]
    [Arguments(null)]
    public async Task ClampOrNull_WithStringAndNullComparer_ThrowsArgumentNullException(string? value)
    {
        // ! Null on purpose: testing null detection
        void Act() => RangeCheck.ClampOrNull(value, "b", "d", null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("comparer");
    }

    [Test]
    [Arguments(0, 1)]
    [Arguments(1, 1)]
    [Arguments(5, 5)]
    [Arguments(10, 10)]
    [Arguments(11, 10)]
    public async Task ClampOrNull_WithNullableInt32_ReturnsClampedValue(int? value, int? expected)
    {
        await Assert.That(RangeCheck.ClampOrNull(value, 1, 10)).IsEqualTo(expected);
    }

    [Test]
    public async Task ClampOrNull_WithNullInt32_ReturnsNull()
    {
        await Assert.That(RangeCheck.ClampOrNull(null, 1, 10)).IsNull();
    }

    [Test]
    [Arguments(5)]
    [Arguments(null)]
    public async Task ClampOrNull_WithNullableInt32AndMinGreaterThanMax_ThrowsArgumentException(int? value)
    {
        void Act() => RangeCheck.ClampOrNull(value, 10, 1);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("min");
    }

    [Test]
    [Arguments(0, 1)]
    [Arguments(1, 1)]
    [Arguments(5, 5)]
    [Arguments(10, 10)]
    [Arguments(11, 10)]
    public async Task ClampOrNull_WithNullableInt32AndComparer_ReturnsClampedValue(int? value, int? expected)
    {
        await Assert.That(RangeCheck.ClampOrNull(value, 10, 1, ReverseComparer<int>.Instance)).IsEqualTo(expected);
    }

    [Test]
    public async Task ClampOrNull_WithNullInt32AndComparer_ReturnsNull()
    {
        await Assert.That(RangeCheck.ClampOrNull(null, 10, 1, ReverseComparer<int>.Instance)).IsNull();
    }

    [Test]
    [Arguments(5)]
    [Arguments(null)]
    public async Task ClampOrNull_WithNullableInt32AndComparerAndMinGreaterThanMax_ThrowsArgumentException(int? value)
    {
        void Act() => RangeCheck.ClampOrNull(value, 1, 10, ReverseComparer<int>.Instance);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("min");
    }

    [Test]
    [Arguments(5)]
    [Arguments(null)]
    public async Task ClampOrNull_WithNullableInt32AndNullComparer_ThrowsArgumentNullException(int? value)
    {
        // ! Null on purpose: testing null detection
        void Act() => RangeCheck.ClampOrNull(value, 1, 10, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("comparer");
    }
}
