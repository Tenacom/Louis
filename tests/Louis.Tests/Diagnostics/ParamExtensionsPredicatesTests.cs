// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

internal sealed class ParamExtensionsPredicatesTests
{
    [Test]
    public async Task Checked_WithSatisfiedPredicate_ReturnsSameParam()
    {
        static Param<int> Check(int number) => Param.Check(number).Checked(static n => n % 2 == 0);

        var param = Check(42);

        await Assert.That(param.Value).IsEqualTo(42);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    public async Task Checked_WithUnsatisfiedPredicate_ThrowsArgumentException()
    {
        static void Act(int number) => Param.Check(number).Checked(static n => n % 2 == 0);

        await Assert.That(() => Act(43))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("number (43) is not valid.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    public async Task Checked_WithMessage_FormatsMessage()
    {
        static void Act(int number) => Param.Check(number).Checked(static n => n % 2 == 0, "{0} must be even, and {1} is odd.");

        await Assert.That(() => Act(43))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("number must be even, and 43 is odd.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    public async Task Checked_PassesValueToPredicate()
    {
        Version? received = null;
        bool Record(Version value)
        {
            received = value;
            return true;
        }

        var version = new Version(1, 2);

        _ = Param.Check(version).Checked(Record);

        await Assert.That(received).IsSameReferenceAs(version);
    }

    [Test]
    public async Task Checked_WithNullPredicate_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act(int number) => Param.Check(number).Checked(null!);

        await Assert.That(() => Act(42)).Throws<ArgumentNullException>().WithParameterName("predicate");
    }
}
