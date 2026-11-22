// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

/// <summary>
/// Holds the tests of the checks that <see cref="SpanParamExtensions"/> alone has.
/// <see cref="ParamCollectionChecksTests"/> holds the other tests of these checks.
/// </summary>
internal sealed class SpanParamExtensionsTests
{
    [Test]
    public async Task Checked_WithSatisfiedPredicate_ReturnsSameParam()
    {
        static CheckOutcome Check(int count)
        {
            Span<int> items = new int[count];
            var param = Param.Check(items).Checked(static span => span.Length % 2 == 0);
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
            Span<int> items = new int[count];
            Param.Check(items).Checked(static span => span.Length % 2 == 0);
        }

        await Assert.That(() => Act(3))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""items ("System.Span<Int32>[3]") is not valid.""", StringComparison.Ordinal)
            .And.WithParameterName("items");
    }

    [Test]
    public async Task Checked_WithMessage_FormatsMessage()
    {
        static void Act(int count)
        {
            Span<int> items = new int[count];
            Param.Check(items).Checked(static span => span.Length % 2 == 0, "{0} is {1}, and must hold pairs.");
        }

        await Assert.That(() => Act(3))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""items is "System.Span<Int32>[3]", and must hold pairs.""", StringComparison.Ordinal);
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

            Span<int> items = new int[count];
            _ = Param.Check(items).Checked(Record);
            return received;
        }

        await Assert.That(Check(3)).IsEqualTo(3);
    }

    [Test]
    public async Task Checked_WithNullPredicate_ThrowsArgumentNullException()
    {
        static void Act(int count)
        {
            Span<int> items = new int[count];

            // ! Null on purpose: testing null detection
            Param.Check(items).Checked(null!);
        }

        await Assert.That(() => Act(3)).ThrowsExactly<ArgumentNullException>().WithParameterName("predicate");
    }

    [Test]
    [Arguments("")]
    [Arguments(" \t\r\n")]
    public async Task WhiteSpace_WithNoVisibleCharacter_ReturnsSameParam(string source)
    {
        static CheckOutcome Check(string source)
        {
            Span<char> text = source.ToCharArray();
            var param = Param.Check(text).WhiteSpace();
            return new(param.Value == text, param.Name);
        }

        var outcome = Check(source);

        await Assert.That(outcome.SameValue).IsTrue();
        await Assert.That(outcome.Name).IsEqualTo("text");
    }

    [Test]
    [Arguments("abc")]
    [Arguments(" a ")]
    public async Task WhiteSpace_WithVisibleCharacter_ThrowsArgumentException(string source)
    {
        static void Act(string source)
        {
            Span<char> text = source.ToCharArray();
            Param.Check(text).WhiteSpace();
        }

        var expectedMessage = $"""text ("{source}") must be empty or consist only of white-space characters.""";
        await Assert.That(() => Act(source))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining(expectedMessage, StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task WhiteSpace_WithMessage_FormatsMessage()
    {
        static void Act(string source)
        {
            Span<char> text = source.ToCharArray();
            Param.Check(text).WhiteSpace("{0} is {1}, and must be blank.");
        }

        await Assert.That(() => Act("abc"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""text is "abc", and must be blank.""", StringComparison.Ordinal);
    }

    [Test]
    [Arguments("abc")]
    [Arguments(" a ")]
    public async Task NotWhiteSpace_WithVisibleCharacter_ReturnsSameParam(string source)
    {
        static CheckOutcome Check(string source)
        {
            Span<char> text = source.ToCharArray();
            var param = Param.Check(text).NotWhiteSpace();
            return new(param.Value == text, param.Name);
        }

        var outcome = Check(source);

        await Assert.That(outcome.SameValue).IsTrue();
        await Assert.That(outcome.Name).IsEqualTo("text");
    }

    [Test]
    [Arguments("")]
    [Arguments(" \t\r\n")]
    public async Task NotWhiteSpace_WithNoVisibleCharacter_ThrowsArgumentException(string source)
    {
        static void Act(string source)
        {
            Span<char> text = source.ToCharArray();
            Param.Check(text).NotWhiteSpace();
        }

        await Assert.That(() => Act(source))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("text cannot be empty or consist only of white-space characters.", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task NotWhiteSpace_WithMessage_FormatsMessage()
    {
        static void Act(string source)
        {
            Span<char> text = source.ToCharArray();
            Param.Check(text).NotWhiteSpace("{0} is {1}, and must not be blank.");
        }

        await Assert.That(() => Act(" "))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""text is " ", and must not be blank.""", StringComparison.Ordinal);
    }
}
