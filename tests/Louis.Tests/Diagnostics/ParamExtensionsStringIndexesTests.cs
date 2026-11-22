// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

internal sealed class ParamExtensionsStringIndexesTests
{
    [Test]
    [Arguments(0)]
    [Arguments(2)]
    public async Task InRangeFor_WithIndexInString_ReturnsSameParam(int index)
    {
        var param = Param.Check(index).InRangeFor("abc");

        await Assert.That(param.Value).IsEqualTo(index);
        await Assert.That(param.Name).IsEqualTo("index");
    }

    [Test]
    [Arguments(3)]
    [Arguments(100)]
    public async Task InRangeFor_WithIndexAfterString_ThrowsArgumentOutOfRangeException(int index)
    {
        static void Act(int index) => Param.Check(index).InRangeFor("abc");

        await Assert.That(() => Act(index))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining($"index ({index}) must be greater than or equal to 0, and less than 3.", StringComparison.Ordinal)
            .And.WithParameterName("index");
    }

    [Test]
    public async Task InRangeFor_WithNegativeIndex_ThrowsArgumentOutOfRangeException()
    {
        static void Act(int index) => Param.Check(index).InRangeFor("abc");

        await Assert.That(() => Act(-1))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining("index (-1) must be greater than or equal to 0, and less than 3.", StringComparison.Ordinal)
            .And.WithParameterName("index");
    }

    [Test]
    public async Task InRangeFor_WithEmptyString_ThrowsArgumentOutOfRangeException()
    {
        static void Act(int index) => Param.Check(index).InRangeFor(string.Empty);

        await Assert.That(() => Act(0))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining("index (0) must be greater than or equal to 0, and less than 0.", StringComparison.Ordinal)
            .And.WithParameterName("index");
    }

    [Test]
    public async Task InRangeFor_WithNullString_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act(int index) => Param.Check(index).InRangeFor(null!);

        await Assert.That(() => Act(0))
            .ThrowsExactly<ArgumentNullException>()
            .WithParameterName("text");
    }

    [Test]
    public async Task InRangeFor_WithMessage_FormatsMessage()
    {
        static void Act(int index) => Param.Check(index).InRangeFor("abc", "{0}|{1}|{2}");

        await Assert.That(() => Act(3))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining("index|3|3", StringComparison.Ordinal);
    }

    [Test]
    public async Task InRangeFor_WhenFailed_SetsActualValue()
    {
        static void Act(int index) => Param.Check(index).InRangeFor("abc");

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Act(3));

        await Assert.That(exception.ActualValue).IsEqualTo(3);
    }

    [Test]
    [Arguments(-1)]
    [Arguments(3)]
    [Arguments(100)]
    public async Task NotInRangeFor_WithIndexOutsideString_ReturnsSameParam(int index)
    {
        var param = Param.Check(index).NotInRangeFor("abc");

        await Assert.That(param.Value).IsEqualTo(index);
        await Assert.That(param.Name).IsEqualTo("index");
    }

    [Test]
    public async Task NotInRangeFor_WithEmptyString_ReturnsSameParam()
    {
        static Param<int> Check(int index) => Param.Check(index).NotInRangeFor(string.Empty);

        var param = Check(0);

        await Assert.That(param.Value).IsEqualTo(0);
        await Assert.That(param.Name).IsEqualTo("index");
    }

    [Test]
    [Arguments(0)]
    [Arguments(2)]
    public async Task NotInRangeFor_WithIndexInString_ThrowsArgumentOutOfRangeException(int index)
    {
        static void Act(int index) => Param.Check(index).NotInRangeFor("abc");

        await Assert.That(() => Act(index))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining($"index ({index}) must be less than 0, or greater than or equal to 3.", StringComparison.Ordinal)
            .And.WithParameterName("index");
    }

    [Test]
    public async Task NotInRangeFor_WithNullString_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act(int index) => Param.Check(index).NotInRangeFor(null!);

        await Assert.That(() => Act(0))
            .ThrowsExactly<ArgumentNullException>()
            .WithParameterName("text");
    }

    [Test]
    public async Task NotInRangeFor_WithMessage_FormatsMessage()
    {
        static void Act(int index) => Param.Check(index).NotInRangeFor("abc", "{0}|{1}|{2}");

        await Assert.That(() => Act(1))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining("index|1|3", StringComparison.Ordinal);
    }
}
