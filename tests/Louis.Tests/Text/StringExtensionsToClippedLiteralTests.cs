// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Text;

internal sealed class StringExtensionsToClippedLiteralTests
{
    [Test]
    [MethodDataSource(typeof(ClippedStringLiteralRows), nameof(ClippedStringLiteralRows.Quoted))]
    public async Task ToClippedQuotedLiteral_ReturnsClippedQuotedLiteral(
        string input,
        int headLength,
        int tailLength,
        bool useUnicodeEllipsis,
        string expected)
    {
        await Assert.That(input.ToClippedQuotedLiteral(headLength, tailLength, useUnicodeEllipsis)).IsEqualTo(expected);
    }

    [Test]
    public async Task ToClippedQuotedLiteral_WithDefaultEllipsis_UsesThreeDots()
    {
        await Assert.That("abcdefghij".ToClippedQuotedLiteral(3, 3)).IsEqualTo("\"abc...hij\"");
    }

    [Test]
    public async Task ToClippedQuotedLiteral_WithNullString_ReturnsNullWithoutQuotes()
    {
        await Assert.That(((string?)null).ToClippedQuotedLiteral(3, 3)).IsEqualTo("null");
    }

    [Test]
    [Arguments(-1, 0, "headLength")]
    [Arguments(0, -1, "tailLength")]
    public async Task ToClippedQuotedLiteral_WithNegativeLength_ThrowsArgumentOutOfRangeException(
        int headLength,
        int tailLength,
        string paramName)
    {
        void Act() => "abc".ToClippedQuotedLiteral(headLength, tailLength);

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName(paramName);
    }

    [Test]
    [MethodDataSource(typeof(ClippedStringLiteralRows), nameof(ClippedStringLiteralRows.Verbatim))]
    public async Task ToClippedVerbatimLiteral_ReturnsClippedVerbatimLiteral(
        string input,
        int headLength,
        int tailLength,
        bool useUnicodeEllipsis,
        string expected)
    {
        await Assert.That(input.ToClippedVerbatimLiteral(headLength, tailLength, useUnicodeEllipsis)).IsEqualTo(expected);
    }

    [Test]
    public async Task ToClippedVerbatimLiteral_WithDefaultEllipsis_UsesThreeDots()
    {
        await Assert.That("abcdefghij".ToClippedVerbatimLiteral(3, 3)).IsEqualTo("@\"abc...hij\"");
    }

    [Test]
    public async Task ToClippedVerbatimLiteral_WithNullString_ReturnsNullWithoutQuotes()
    {
        await Assert.That(((string?)null).ToClippedVerbatimLiteral(3, 3)).IsEqualTo("null");
    }

    [Test]
    [Arguments(-1, 0, "headLength")]
    [Arguments(0, -1, "tailLength")]
    public async Task ToClippedVerbatimLiteral_WithNegativeLength_ThrowsArgumentOutOfRangeException(
        int headLength,
        int tailLength,
        string paramName)
    {
        void Act() => "abc".ToClippedVerbatimLiteral(headLength, tailLength);

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName(paramName);
    }

    [Test]
    [MethodDataSource(typeof(ClippedStringLiteralRows), nameof(ClippedStringLiteralRows.Literal))]
    public async Task ToClippedLiteral_ReturnsClippedLiteralOfGivenKind(
        string input,
        StringLiteralKind literalKind,
        int headLength,
        int tailLength,
        bool useUnicodeEllipsis,
        string expected)
    {
        var result = input.ToClippedLiteral(literalKind, headLength, tailLength, useUnicodeEllipsis);

        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task ToClippedLiteral_WithDefaultEllipsis_UsesThreeDots()
    {
        await Assert.That("abcdefghij".ToClippedLiteral(StringLiteralKind.Verbatim, 3, 3)).IsEqualTo("@\"abc...hij\"");
    }

    [Test]
    [Arguments(StringLiteralKind.Quoted)]
    [Arguments(StringLiteralKind.Verbatim)]
    public async Task ToClippedLiteral_WithNullString_ReturnsNullWithoutQuotes(StringLiteralKind literalKind)
    {
        await Assert.That(((string?)null).ToClippedLiteral(literalKind, 3, 3)).IsEqualTo("null");
    }

    [Test]
    [Arguments("abc")]
    [Arguments(null)]
    public async Task ToClippedLiteral_WithUndefinedLiteralKind_ThrowsArgumentException(string? input)
    {
        void Act() => input.ToClippedLiteral((StringLiteralKind)2, 3, 3);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("literalKind");
    }

    [Test]
    [Arguments(-1, 0, "headLength")]
    [Arguments(0, -1, "tailLength")]
    public async Task ToClippedLiteral_WithNegativeLength_ThrowsArgumentOutOfRangeException(
        int headLength,
        int tailLength,
        string paramName)
    {
        void Act() => "abc".ToClippedLiteral(StringLiteralKind.Quoted, headLength, tailLength);

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName(paramName);
    }
}
