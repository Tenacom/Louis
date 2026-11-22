// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

internal sealed class ParamExtensionsStringSizesTests
{
    [Test]
    [Arguments("abc")]
    public async Task HasSizeEqualTo_WithStringOfThatSize_ReturnsSameParam(string text)
    {
        var param = Param.Check(text).HasSizeEqualTo(3);

        await Assert.That(param.Value).IsSameReferenceAs(text);
        await Assert.That(param.Name).IsEqualTo("text");
    }

    [Test]
    [Arguments("ab", 2)]
    [Arguments("abcd", 4)]
    public async Task HasSizeEqualTo_WithStringOfAnotherSize_ThrowsArgumentException(string text, int size)
    {
        static void Act(string text) => Param.Check(text).HasSizeEqualTo(3);

        await Assert.That(() => Act(text))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"text must have a size equal to 3, and its size is {size}.", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task HasSizeEqualTo_WithMessage_FormatsMessage()
    {
        static void Act(string text) => Param.Check(text).HasSizeEqualTo(3, "{0}|{1}|{2}|{3}");

        await Assert.That(() => Act("ab"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""text|"ab"|3|2""", StringComparison.Ordinal);
    }

    [Test]
    [Arguments("abc")]
    public async Task HasSizeEqualTo_WithOtherOfSameSize_ReturnsSameParam(string text)
    {
        var param = Param.Check(text).HasSizeEqualTo("xyz");

        await Assert.That(param.Value).IsSameReferenceAs(text);
        await Assert.That(param.Name).IsEqualTo("text");
    }

    [Test]
    [Arguments("ab", 2)]
    [Arguments("abcd", 4)]
    public async Task HasSizeEqualTo_WithOtherOfAnotherSize_ThrowsArgumentException(string text, int size)
    {
        static void Act(string text) => Param.Check(text).HasSizeEqualTo("xyz");

        await Assert.That(() => Act(text))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"text must have a size equal to 3, and its size is {size}.", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task HasSizeEqualTo_WithNullOther_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act(string text) => Param.Check(text).HasSizeEqualTo(null!);

        await Assert.That(() => Act("abc"))
            .ThrowsExactly<ArgumentNullException>()
            .WithParameterName("other");
    }

    [Test]
    public async Task HasSizeEqualTo_WithOtherAndMessage_FormatsMessage()
    {
        static void Act(string text) => Param.Check(text).HasSizeEqualTo("xyz", "{0}|{1}|{2}|{3}");

        await Assert.That(() => Act("ab"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""text|"ab"|3|2""", StringComparison.Ordinal);
    }

    [Test]
    [Arguments("ab")]
    [Arguments("abcd")]
    public async Task HasSizeNotEqualTo_WithStringOfAnotherSize_ReturnsSameParam(string text)
    {
        var param = Param.Check(text).HasSizeNotEqualTo(3);

        await Assert.That(param.Value).IsSameReferenceAs(text);
        await Assert.That(param.Name).IsEqualTo("text");
    }

    [Test]
    public async Task HasSizeNotEqualTo_WithStringOfThatSize_ThrowsArgumentException()
    {
        static void Act(string text) => Param.Check(text).HasSizeNotEqualTo(3);

        await Assert.That(() => Act("abc"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("text must not have a size equal to 3.", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task HasSizeNotEqualTo_WithMessage_FormatsMessage()
    {
        static void Act(string text) => Param.Check(text).HasSizeNotEqualTo(3, "{0}|{1}|{2}|{3}");

        await Assert.That(() => Act("abc"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""text|"abc"|3|3""", StringComparison.Ordinal);
    }

    [Test]
    [Arguments("abcd")]
    [Arguments("abcdef")]
    public async Task HasSizeGreaterThan_WithLongerString_ReturnsSameParam(string text)
    {
        var param = Param.Check(text).HasSizeGreaterThan(3);

        await Assert.That(param.Value).IsSameReferenceAs(text);
        await Assert.That(param.Name).IsEqualTo("text");
    }

    [Test]
    [Arguments("abc", 3)]
    [Arguments("ab", 2)]
    public async Task HasSizeGreaterThan_WithStringNotLonger_ThrowsArgumentException(string text, int size)
    {
        static void Act(string text) => Param.Check(text).HasSizeGreaterThan(3);

        await Assert.That(() => Act(text))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"text must have a size greater than 3, and its size is {size}.", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task HasSizeGreaterThan_WithMessage_FormatsMessage()
    {
        static void Act(string text) => Param.Check(text).HasSizeGreaterThan(3, "{0}|{1}|{2}|{3}");

        await Assert.That(() => Act("ab"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""text|"ab"|3|2""", StringComparison.Ordinal);
    }

    [Test]
    [Arguments("abc")]
    [Arguments("abcd")]
    public async Task HasSizeGreaterThanOrEqualTo_WithStringNotShorter_ReturnsSameParam(string text)
    {
        var param = Param.Check(text).HasSizeGreaterThanOrEqualTo(3);

        await Assert.That(param.Value).IsSameReferenceAs(text);
        await Assert.That(param.Name).IsEqualTo("text");
    }

    [Test]
    public async Task HasSizeGreaterThanOrEqualTo_WithShorterString_ThrowsArgumentException()
    {
        static void Act(string text) => Param.Check(text).HasSizeGreaterThanOrEqualTo(3);

        await Assert.That(() => Act("ab"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("text must have a size greater than or equal to 3, and its size is 2.", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task HasSizeGreaterThanOrEqualTo_WithMessage_FormatsMessage()
    {
        static void Act(string text) => Param.Check(text).HasSizeGreaterThanOrEqualTo(3, "{0}|{1}|{2}|{3}");

        await Assert.That(() => Act("ab"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""text|"ab"|3|2""", StringComparison.Ordinal);
    }

    [Test]
    [Arguments("ab")]
    [Arguments("")]
    public async Task HasSizeLessThan_WithShorterString_ReturnsSameParam(string text)
    {
        var param = Param.Check(text).HasSizeLessThan(3);

        await Assert.That(param.Value).IsSameReferenceAs(text);
        await Assert.That(param.Name).IsEqualTo("text");
    }

    [Test]
    [Arguments("abc", 3)]
    [Arguments("abcd", 4)]
    public async Task HasSizeLessThan_WithStringNotShorter_ThrowsArgumentException(string text, int size)
    {
        static void Act(string text) => Param.Check(text).HasSizeLessThan(3);

        await Assert.That(() => Act(text))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"text must have a size less than 3, and its size is {size}.", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task HasSizeLessThan_WithMessage_FormatsMessage()
    {
        static void Act(string text) => Param.Check(text).HasSizeLessThan(3, "{0}|{1}|{2}|{3}");

        await Assert.That(() => Act("abcd"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""text|"abcd"|3|4""", StringComparison.Ordinal);
    }

    [Test]
    [Arguments("abc")]
    [Arguments("ab")]
    public async Task HasSizeLessThanOrEqualTo_WithStringNotLonger_ReturnsSameParam(string text)
    {
        var param = Param.Check(text).HasSizeLessThanOrEqualTo(3);

        await Assert.That(param.Value).IsSameReferenceAs(text);
        await Assert.That(param.Name).IsEqualTo("text");
    }

    [Test]
    public async Task HasSizeLessThanOrEqualTo_WithLongerString_ThrowsArgumentException()
    {
        static void Act(string text) => Param.Check(text).HasSizeLessThanOrEqualTo(3);

        await Assert.That(() => Act("abcd"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("text must have a size less than or equal to 3, and its size is 4.", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task HasSizeLessThanOrEqualTo_WithMessage_FormatsMessage()
    {
        static void Act(string text) => Param.Check(text).HasSizeLessThanOrEqualTo(3, "{0}|{1}|{2}|{3}");

        await Assert.That(() => Act("abcd"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""text|"abcd"|3|4""", StringComparison.Ordinal);
    }

    [Test]
    [Arguments("abc")]
    [Arguments("ab")]
    public async Task HasSizeLessThanOrEqualTo_WithOtherNotShorter_ReturnsSameParam(string text)
    {
        var param = Param.Check(text).HasSizeLessThanOrEqualTo("xyz");

        await Assert.That(param.Value).IsSameReferenceAs(text);
        await Assert.That(param.Name).IsEqualTo("text");
    }

    [Test]
    public async Task HasSizeLessThanOrEqualTo_WithShorterOther_ThrowsArgumentException()
    {
        static void Act(string text) => Param.Check(text).HasSizeLessThanOrEqualTo("xyz");

        await Assert.That(() => Act("abcd"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("text must have a size less than or equal to 3, and its size is 4.", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task HasSizeLessThanOrEqualTo_WithNullOther_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act(string text) => Param.Check(text).HasSizeLessThanOrEqualTo(null!);

        await Assert.That(() => Act("abc"))
            .ThrowsExactly<ArgumentNullException>()
            .WithParameterName("other");
    }

    [Test]
    public async Task HasSizeLessThanOrEqualTo_WithOtherAndMessage_FormatsMessage()
    {
        static void Act(string text) => Param.Check(text).HasSizeLessThanOrEqualTo("xyz", "{0}|{1}|{2}|{3}");

        await Assert.That(() => Act("abcd"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""text|"abcd"|3|4""", StringComparison.Ordinal);
    }
}
