// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET9_0_OR_GREATER

using Louis.Diagnostics;

internal sealed class RefParamExtensionsTests
{
    [Test]
    public async Task Checked_WithSatisfiedPredicate_ReturnsSameParam()
    {
        static CheckOutcome Check(int count)
        {
            ReadOnlySpan<int> items = new int[count];
            var param = Param.CheckRef(items).Checked(static span => span.Length % 2 == 0);
            return new(param.Value == items, param.Name);
        }

        var outcome = Check(4);

        await Assert.That(outcome.SameValue).IsTrue();
        await Assert.That(outcome.Name).IsEqualTo("items");
    }

    [Test]
    public async Task Checked_WithUnsatisfiedPredicate_ThrowsArgumentException()
    {
        static void Act(int count)
        {
            ReadOnlySpan<int> items = new int[count];
            Param.CheckRef(items).Checked(static span => span.Length % 2 == 0);
        }

        await Assert.That(() => Act(3))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("items is not valid.", StringComparison.Ordinal)
            .And.WithParameterName("items");
    }

    [Test]
    public async Task Checked_WithMessage_FormatsMessage()
    {
        static void Act(int count)
        {
            ReadOnlySpan<int> items = new int[count];
            Param.CheckRef(items).Checked(static span => span.Length % 2 == 0, "{0} must hold pairs.");
        }

        await Assert.That(() => Act(3))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("items must hold pairs.", StringComparison.Ordinal)
            .And.WithParameterName("items");
    }

    [Test]
    public async Task Checked_PassesValueToPredicate()
    {
        static int Check(int count)
        {
            var received = -1;
            bool Record(ReadOnlySpan<int> span)
            {
                received = span.Length;
                return true;
            }

            ReadOnlySpan<int> items = new int[count];
            _ = Param.CheckRef(items).Checked(Record);
            return received;
        }

        await Assert.That(Check(3)).IsEqualTo(3);
    }

    [Test]
    public async Task Checked_WithNullPredicate_ThrowsArgumentNullException()
    {
        static void Act(int count)
        {
            ReadOnlySpan<int> items = new int[count];

            // ! Null on purpose: testing null detection
            Param.CheckRef(items).Checked(null!);
        }

        await Assert.That(() => Act(3)).ThrowsExactly<ArgumentNullException>().WithParameterName("predicate");
    }
}

#endif
