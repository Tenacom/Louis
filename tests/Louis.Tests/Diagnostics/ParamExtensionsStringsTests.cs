// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

internal sealed class ParamExtensionsStringsTests
{
    [Test]
    [Arguments(null)]
    [Arguments("")]
    public async Task NullOrEmpty_WithNullOrEmptyString_ReturnsSameParam(string? text)
    {
        var param = Param.Check(text).NullOrEmpty();

        await Assert.That(param.Value).IsEqualTo(text);
        await Assert.That(param.Name).IsEqualTo("text");
    }

    [Test]
    [Arguments("abc")]
    [Arguments(" ")]
    public async Task NullOrEmpty_WithStringNotEmpty_ThrowsArgumentException(string text)
    {
        static void Act(string? text) => Param.Check(text).NullOrEmpty();

        await Assert.That(() => Act(text))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"""text ("{text}") must be null or empty.""", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task NullOrEmpty_WithMessage_FormatsMessage()
    {
        static void Act(string? text) => Param.Check(text).NullOrEmpty("{0} is {1}, and must be absent.");

        await Assert.That(() => Act("abc"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""text is "abc", and must be absent.""", StringComparison.Ordinal);
    }

    [Test]
    [Arguments(null)]
    [Arguments("")]
    [Arguments(" ")]
    [Arguments(" \t\r\n")]
    public async Task NullOrWhiteSpace_WithNoVisibleCharacter_ReturnsSameParam(string? text)
    {
        var param = Param.Check(text).NullOrWhiteSpace();

        await Assert.That(param.Value).IsEqualTo(text);
        await Assert.That(param.Name).IsEqualTo("text");
    }

    [Test]
    [Arguments("abc")]
    [Arguments(" a ")]
    public async Task NullOrWhiteSpace_WithVisibleCharacter_ThrowsArgumentException(string text)
    {
        static void Act(string? text) => Param.Check(text).NullOrWhiteSpace();

        var expectedMessage = $"""text ("{text}") must be null, empty, or consist only of white-space characters.""";
        await Assert.That(() => Act(text))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining(expectedMessage, StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task NullOrWhiteSpace_WithMessage_FormatsMessage()
    {
        static void Act(string? text) => Param.Check(text).NullOrWhiteSpace("{0} is {1}, and must be blank.");

        await Assert.That(() => Act("abc"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""text is "abc", and must be blank.""", StringComparison.Ordinal);
    }

    [Test]
    [Arguments("")]
    public async Task Empty_WithEmptyString_ReturnsSameParam(string text)
    {
        var param = Param.Check(text).Empty();

        await Assert.That(param.Value).IsSameReferenceAs(text);
        await Assert.That(param.Name).IsEqualTo("text");
    }

    [Test]
    [Arguments("abc")]
    [Arguments(" ")]
    public async Task Empty_WithStringNotEmpty_ThrowsArgumentException(string text)
    {
        static void Act(string text) => Param.Check(text).Empty();

        await Assert.That(() => Act(text))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"""text ("{text}") must be empty.""", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task Empty_WithMessage_FormatsMessage()
    {
        static void Act(string text) => Param.Check(text).Empty("{0} is {1}, and must hold nothing.");

        await Assert.That(() => Act("abc"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""text is "abc", and must hold nothing.""", StringComparison.Ordinal);
    }

    [Test]
    [Arguments("abc")]
    [Arguments(" ")]
    public async Task NotEmpty_WithStringNotEmpty_ReturnsSameParam(string text)
    {
        var param = Param.Check(text).NotEmpty();

        await Assert.That(param.Value).IsSameReferenceAs(text);
        await Assert.That(param.Name).IsEqualTo("text");
    }

    [Test]
    public async Task NotEmpty_WithEmptyString_ThrowsArgumentException()
    {
        static void Act(string text) => Param.Check(text).NotEmpty();

        await Assert.That(() => Act(string.Empty))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("text cannot be empty.", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task NotEmpty_WithMessage_FormatsMessage()
    {
        static void Act(string text) => Param.Check(text).NotEmpty("{0} is {1}, and must hold something.");

        await Assert.That(() => Act(string.Empty))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""text is "", and must hold something.""", StringComparison.Ordinal);
    }

    [Test]
    public async Task NotEmpty_AfterCheckNotNull_ReturnsValue()
    {
        static string Check(string? text) => Param.CheckNotNull(text).NotEmpty().Value;

        var result = Check("abc");

        await Assert.That(result).IsEqualTo("abc");
    }

    [Test]
    [Arguments("")]
    [Arguments(" ")]
    [Arguments(" \t\r\n")]
    public async Task WhiteSpace_WithNoVisibleCharacter_ReturnsSameParam(string text)
    {
        var param = Param.Check(text).WhiteSpace();

        await Assert.That(param.Value).IsSameReferenceAs(text);
        await Assert.That(param.Name).IsEqualTo("text");
    }

    [Test]
    [Arguments("abc")]
    [Arguments(" a ")]
    public async Task WhiteSpace_WithVisibleCharacter_ThrowsArgumentException(string text)
    {
        static void Act(string text) => Param.Check(text).WhiteSpace();

        var expectedMessage = $"""text ("{text}") must be empty or consist only of white-space characters.""";
        await Assert.That(() => Act(text))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining(expectedMessage, StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task WhiteSpace_WithMessage_FormatsMessage()
    {
        static void Act(string text) => Param.Check(text).WhiteSpace("{0} is {1}, and must be blank.");

        await Assert.That(() => Act("abc"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""text is "abc", and must be blank.""", StringComparison.Ordinal);
    }

    [Test]
    [Arguments("abc")]
    [Arguments(" a ")]
    public async Task NotWhiteSpace_WithVisibleCharacter_ReturnsSameParam(string text)
    {
        var param = Param.Check(text).NotWhiteSpace();

        await Assert.That(param.Value).IsSameReferenceAs(text);
        await Assert.That(param.Name).IsEqualTo("text");
    }

    [Test]
    [Arguments("")]
    [Arguments(" ")]
    [Arguments(" \t\r\n")]
    public async Task NotWhiteSpace_WithNoVisibleCharacter_ThrowsArgumentException(string text)
    {
        static void Act(string text) => Param.Check(text).NotWhiteSpace();

        await Assert.That(() => Act(text))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("text cannot be empty or consist only of white-space characters.", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task NotWhiteSpace_WithMessage_FormatsMessage()
    {
        static void Act(string text) => Param.Check(text).NotWhiteSpace("{0} is {1}, and must not be blank.");

        await Assert.That(() => Act(" "))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""text is " ", and must not be blank.""", StringComparison.Ordinal);
    }
}
