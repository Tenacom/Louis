// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis;

internal sealed class RangeCheckVerifyTests
{
    [Test]
    [Arguments(0, false)]
    [Arguments(1, true)]
    [Arguments(5, true)]
    [Arguments(10, true)]
    [Arguments(11, false)]
    public async Task Verify_WithInt32_ReturnsWhetherValueIsInRange(int value, bool expected)
    {
        await Assert.That(RangeCheck.Verify(value, 1, 10)).IsEqualTo(expected);
    }

    [Test]
    public async Task Verify_WithInt32AndMinGreaterThanMax_ThrowsArgumentException()
    {
        static void Act() => RangeCheck.Verify(5, 10, 1);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("min");
    }

    [Test]
    [Arguments(0, false)]
    [Arguments(1, true)]
    [Arguments(5, true)]
    [Arguments(10, true)]
    [Arguments(11, false)]
    public async Task Verify_WithInt32AndComparer_ReturnsWhetherValueIsInRange(int value, bool expected)
    {
        await Assert.That(RangeCheck.Verify(value, 10, 1, ReverseComparer<int>.Instance)).IsEqualTo(expected);
    }

    [Test]
    public async Task Verify_WithInt32AndComparerAndMinGreaterThanMax_ThrowsArgumentException()
    {
        static void Act() => RangeCheck.Verify(5, 1, 10, ReverseComparer<int>.Instance);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("min");
    }

    [Test]
    public async Task Verify_WithInt32AndNullComparer_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => RangeCheck.Verify(5, 1, 10, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("comparer");
    }

    [Test]
    [Arguments("a", false)]
    [Arguments("b", true)]
    [Arguments("c", true)]
    [Arguments("d", true)]
    [Arguments("e", false)]
    public async Task Verify_WithString_ReturnsWhetherValueIsInRange(string value, bool expected)
    {
        await Assert.That(RangeCheck.Verify(value, "b", "d", acceptNull: false)).IsEqualTo(expected);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task Verify_WithNullString_ReturnsAcceptNull(bool acceptNull)
    {
        await Assert.That(RangeCheck.Verify(null, "b", "d", acceptNull)).IsEqualTo(acceptNull);
    }

    [Test]
    [Arguments("c")]
    [Arguments(null)]
    public async Task Verify_WithStringAndMinGreaterThanMax_ThrowsArgumentException(string? value)
    {
        void Act() => RangeCheck.Verify(value, "d", "b", acceptNull: true);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("min");
    }

    [Test]
    [Arguments("a", false)]
    [Arguments("b", true)]
    [Arguments("c", true)]
    [Arguments("d", true)]
    [Arguments("e", false)]
    public async Task Verify_WithStringAndComparer_ReturnsWhetherValueIsInRange(string value, bool expected)
    {
        var result = RangeCheck.Verify(value, "d", "b", acceptNull: false, ReverseComparer<string>.Instance);

        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task Verify_WithNullStringAndComparer_ReturnsAcceptNull(bool acceptNull)
    {
        var result = RangeCheck.Verify(null, "d", "b", acceptNull, ReverseComparer<string>.Instance);

        await Assert.That(result).IsEqualTo(acceptNull);
    }

    [Test]
    [Arguments("c")]
    [Arguments(null)]
    public async Task Verify_WithStringAndComparerAndMinGreaterThanMax_ThrowsArgumentException(string? value)
    {
        void Act() => RangeCheck.Verify(value, "b", "d", acceptNull: true, ReverseComparer<string>.Instance);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("min");
    }

    [Test]
    [Arguments("c")]
    [Arguments(null)]
    public async Task Verify_WithStringAndNullComparer_ThrowsArgumentNullException(string? value)
    {
        // ! Null on purpose: testing null detection
        void Act() => RangeCheck.Verify(value, "b", "d", acceptNull: true, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("comparer");
    }

    [Test]
    [Arguments(0, false)]
    [Arguments(1, true)]
    [Arguments(5, true)]
    [Arguments(10, true)]
    [Arguments(11, false)]
    public async Task Verify_WithNullableInt32_ReturnsWhetherValueIsInRange(int? value, bool expected)
    {
        await Assert.That(RangeCheck.Verify(value, 1, 10, acceptNull: false)).IsEqualTo(expected);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task Verify_WithNullInt32_ReturnsAcceptNull(bool acceptNull)
    {
        await Assert.That(RangeCheck.Verify(null, 1, 10, acceptNull)).IsEqualTo(acceptNull);
    }

    [Test]
    [Arguments(5)]
    [Arguments(null)]
    public async Task Verify_WithNullableInt32AndMinGreaterThanMax_ThrowsArgumentException(int? value)
    {
        void Act() => RangeCheck.Verify(value, 10, 1, acceptNull: true);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("min");
    }

    [Test]
    [Arguments(0, false)]
    [Arguments(1, true)]
    [Arguments(5, true)]
    [Arguments(10, true)]
    [Arguments(11, false)]
    public async Task Verify_WithNullableInt32AndComparer_ReturnsWhetherValueIsInRange(int? value, bool expected)
    {
        var result = RangeCheck.Verify(value, 10, 1, acceptNull: false, ReverseComparer<int>.Instance);

        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task Verify_WithNullInt32AndComparer_ReturnsAcceptNull(bool acceptNull)
    {
        var result = RangeCheck.Verify(null, 10, 1, acceptNull, ReverseComparer<int>.Instance);

        await Assert.That(result).IsEqualTo(acceptNull);
    }

    [Test]
    [Arguments(5)]
    [Arguments(null)]
    public async Task Verify_WithNullableInt32AndComparerAndMinGreaterThanMax_ThrowsArgumentException(int? value)
    {
        void Act() => RangeCheck.Verify(value, 1, 10, acceptNull: true, ReverseComparer<int>.Instance);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("min");
    }

    [Test]
    [Arguments(5)]
    [Arguments(null)]
    public async Task Verify_WithNullableInt32AndNullComparer_ThrowsArgumentNullException(int? value)
    {
        // ! Null on purpose: testing null detection
        void Act() => RangeCheck.Verify(value, 1, 10, acceptNull: true, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("comparer");
    }
}
