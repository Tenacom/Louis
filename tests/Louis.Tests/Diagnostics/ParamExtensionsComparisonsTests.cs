// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

internal sealed class ParamExtensionsComparisonsTests
{
    [Test]
    [Arguments(9)]
    [Arguments(-10)]
    public async Task LessThan_WithLesserValue_ReturnsSameParam(int number)
    {
        var param = Param.Check(number).LessThan(10);

        await Assert.That(param.Value).IsEqualTo(number);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    [Arguments(10)]
    [Arguments(11)]
    public async Task LessThan_WithValueNotLesser_ThrowsArgumentOutOfRangeException(int number)
    {
        static void Act(int number) => Param.Check(number).LessThan(10);

        await Assert.That(() => Act(number))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining($"number ({number}) must be less than 10.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    public async Task LessThan_WithMessage_FormatsMessage()
    {
        static void Act(int number) => Param.Check(number).LessThan(10, "{0}: {1} is not below {2}.");

        await Assert.That(() => Act(10))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining("number: 10 is not below 10.", StringComparison.Ordinal);
    }

    [Test]
    [Arguments(9)]
    [Arguments(10)]
    public async Task LessThanOrEqualTo_WithValueNotGreater_ReturnsSameParam(int number)
    {
        var param = Param.Check(number).LessThanOrEqualTo(10);

        await Assert.That(param.Value).IsEqualTo(number);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    public async Task LessThanOrEqualTo_WithGreaterValue_ThrowsArgumentOutOfRangeException()
    {
        static void Act(int number) => Param.Check(number).LessThanOrEqualTo(10);

        await Assert.That(() => Act(11))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining("number (11) must be less than or equal to 10.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    public async Task LessThanOrEqualTo_WithMessage_FormatsMessage()
    {
        static void Act(int number) => Param.Check(number).LessThanOrEqualTo(10, "{0}: {1} is above {2}.");

        await Assert.That(() => Act(11))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining("number: 11 is above 10.", StringComparison.Ordinal);
    }

    [Test]
    [Arguments(11)]
    [Arguments(100)]
    public async Task GreaterThan_WithGreaterValue_ReturnsSameParam(int number)
    {
        var param = Param.Check(number).GreaterThan(10);

        await Assert.That(param.Value).IsEqualTo(number);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    [Arguments(10)]
    [Arguments(9)]
    public async Task GreaterThan_WithValueNotGreater_ThrowsArgumentOutOfRangeException(int number)
    {
        static void Act(int number) => Param.Check(number).GreaterThan(10);

        await Assert.That(() => Act(number))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining($"number ({number}) must be greater than 10.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    public async Task GreaterThan_WithMessage_FormatsMessage()
    {
        static void Act(int number) => Param.Check(number).GreaterThan(10, "{0}: {1} is not above {2}.");

        await Assert.That(() => Act(10))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining("number: 10 is not above 10.", StringComparison.Ordinal);
    }

    [Test]
    [Arguments(10)]
    [Arguments(11)]
    public async Task GreaterThanOrEqualTo_WithValueNotLesser_ReturnsSameParam(int number)
    {
        var param = Param.Check(number).GreaterThanOrEqualTo(10);

        await Assert.That(param.Value).IsEqualTo(number);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    public async Task GreaterThanOrEqualTo_WithLesserValue_ThrowsArgumentOutOfRangeException()
    {
        static void Act(int number) => Param.Check(number).GreaterThanOrEqualTo(10);

        await Assert.That(() => Act(9))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining("number (9) must be greater than or equal to 10.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    public async Task GreaterThanOrEqualTo_WithMessage_FormatsMessage()
    {
        static void Act(int number) => Param.Check(number).GreaterThanOrEqualTo(10, "{0}: {1} is below {2}.");

        await Assert.That(() => Act(9))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining("number: 9 is below 10.", StringComparison.Ordinal);
    }

    [Test]
    public async Task Comparison_WithReferenceType_UsesComparableOfType()
    {
        static Param<string> Check(string text) => Param.Check(text).GreaterThan("a").LessThan("c");

        var param = Check("b");

        await Assert.That(param.Value).IsEqualTo("b");
        await Assert.That(param.Name).IsEqualTo("text");
    }

    [Test]
    public async Task Comparison_InChain_FailsOnFirstCheckNotPassed()
    {
        static void Act(TimeSpan timeout) => Param.Check(timeout).GreaterThan(TimeSpan.Zero).LessThan(TimeSpan.FromMinutes(1));

        await Assert.That(() => Act(TimeSpan.FromMinutes(2)))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining("timeout (00:02:00) must be less than 00:01:00.", StringComparison.Ordinal)
            .And.WithParameterName("timeout");
    }
}
