// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

// Every test uses the bounds 10 and 20.
internal sealed class ParamExtensionsRangesTests
{
    private const string Message = "{0}: {1}, {2}, {3}";

    [Test]
    [Arguments(10)]
    [Arguments(15)]
    [Arguments(19)]
    public async Task InRange_WithValueInside_ReturnsSameParam(int number)
    {
        var param = Param.Check(number).InRange(10, 20);

        await Assert.That(param.Value).IsEqualTo(number);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    [Arguments(9)]
    [Arguments(20)]
    [Arguments(21)]
    public async Task InRange_WithValueOutside_ThrowsArgumentOutOfRangeException(int number)
    {
        static void Act(int number) => Param.Check(number).InRange(10, 20);

        await Assert.That(() => Act(number))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining(
                $"number ({number}) must be greater than or equal to 10, and less than 20.",
                StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    [Arguments(9)]
    [Arguments(20)]
    [Arguments(21)]
    public async Task NotInRange_WithValueOutside_ReturnsSameParam(int number)
    {
        var param = Param.Check(number).NotInRange(10, 20);

        await Assert.That(param.Value).IsEqualTo(number);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    [Arguments(10)]
    [Arguments(15)]
    [Arguments(19)]
    public async Task NotInRange_WithValueInside_ThrowsArgumentOutOfRangeException(int number)
    {
        static void Act(int number) => Param.Check(number).NotInRange(10, 20);

        await Assert.That(() => Act(number))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining(
                $"number ({number}) must be less than 10, or greater than or equal to 20.",
                StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    [Arguments(11)]
    [Arguments(15)]
    [Arguments(19)]
    public async Task Between_WithValueInside_ReturnsSameParam(int number)
    {
        var param = Param.Check(number).Between(10, 20);

        await Assert.That(param.Value).IsEqualTo(number);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    [Arguments(9)]
    [Arguments(10)]
    [Arguments(20)]
    [Arguments(21)]
    public async Task Between_WithValueOutside_ThrowsArgumentOutOfRangeException(int number)
    {
        static void Act(int number) => Param.Check(number).Between(10, 20);

        await Assert.That(() => Act(number))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining($"number ({number}) must be greater than 10, and less than 20.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    [Arguments(9)]
    [Arguments(10)]
    [Arguments(20)]
    [Arguments(21)]
    public async Task NotBetween_WithValueOutside_ReturnsSameParam(int number)
    {
        var param = Param.Check(number).NotBetween(10, 20);

        await Assert.That(param.Value).IsEqualTo(number);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    [Arguments(11)]
    [Arguments(15)]
    [Arguments(19)]
    public async Task NotBetween_WithValueInside_ThrowsArgumentOutOfRangeException(int number)
    {
        static void Act(int number) => Param.Check(number).NotBetween(10, 20);

        await Assert.That(() => Act(number))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining(
                $"number ({number}) must be less than or equal to 10, or greater than or equal to 20.",
                StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    [Arguments(10)]
    [Arguments(15)]
    [Arguments(20)]
    public async Task BetweenOrEqualTo_WithValueInside_ReturnsSameParam(int number)
    {
        var param = Param.Check(number).BetweenOrEqualTo(10, 20);

        await Assert.That(param.Value).IsEqualTo(number);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    [Arguments(9)]
    [Arguments(21)]
    public async Task BetweenOrEqualTo_WithValueOutside_ThrowsArgumentOutOfRangeException(int number)
    {
        static void Act(int number) => Param.Check(number).BetweenOrEqualTo(10, 20);

        await Assert.That(() => Act(number))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining(
                $"number ({number}) must be greater than or equal to 10, and less than or equal to 20.",
                StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    [Arguments(9)]
    [Arguments(21)]
    public async Task NotBetweenOrEqualTo_WithValueOutside_ReturnsSameParam(int number)
    {
        var param = Param.Check(number).NotBetweenOrEqualTo(10, 20);

        await Assert.That(param.Value).IsEqualTo(number);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    [Arguments(10)]
    [Arguments(15)]
    [Arguments(20)]
    public async Task NotBetweenOrEqualTo_WithValueInside_ThrowsArgumentOutOfRangeException(int number)
    {
        static void Act(int number) => Param.Check(number).NotBetweenOrEqualTo(10, 20);

        await Assert.That(() => Act(number))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining($"number ({number}) must be less than 10, or greater than 20.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    public async Task RangeCheck_WithMessage_FormatsMessage()
    {
        static void ActInRange(int number) => Param.Check(number).InRange(10, 20, Message);
        static void ActBetween(int number) => Param.Check(number).Between(10, 20, Message);
        static void ActBetweenOrEqualTo(int number) => Param.Check(number).BetweenOrEqualTo(10, 20, Message);

        await AssertMessage(() => ActInRange(30), "number: 30, 10, 20");
        await AssertMessage(() => ActBetween(30), "number: 30, 10, 20");
        await AssertMessage(() => ActBetweenOrEqualTo(30), "number: 30, 10, 20");
    }

    [Test]
    public async Task NegatedRangeCheck_WithMessage_FormatsMessage()
    {
        static void ActNotInRange(int number) => Param.Check(number).NotInRange(10, 20, Message);
        static void ActNotBetween(int number) => Param.Check(number).NotBetween(10, 20, Message);
        static void ActNotBetweenOrEqualTo(int number) => Param.Check(number).NotBetweenOrEqualTo(10, 20, Message);

        await AssertMessage(() => ActNotInRange(15), "number: 15, 10, 20");
        await AssertMessage(() => ActNotBetween(15), "number: 15, 10, 20");
        await AssertMessage(() => ActNotBetweenOrEqualTo(15), "number: 15, 10, 20");
    }

    private static async Task AssertMessage(Action act, string expected)
        => await Assert.That(act)
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining(expected, StringComparison.Ordinal);
}
