// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Text;

internal sealed class CharReadOnlySpanExtensionsToClippedLiteralTests
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
        var result = input.AsSpan().ToClippedQuotedLiteral(headLength, tailLength, useUnicodeEllipsis);

        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task ToClippedQuotedLiteral_WithDefaultEllipsis_UsesThreeDots()
    {
        await Assert.That("abcdefghij".AsSpan().ToClippedQuotedLiteral(3, 3)).IsEqualTo("\"abc...hij\"");
    }

    [Test]
    [Arguments(-1, 0, "headLength")]
    [Arguments(0, -1, "tailLength")]
    public async Task ToClippedQuotedLiteral_WithNegativeLength_ThrowsArgumentOutOfRangeException(
        int headLength,
        int tailLength,
        string paramName)
    {
        void Act() => "abc".AsSpan().ToClippedQuotedLiteral(headLength, tailLength);

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
        var result = input.AsSpan().ToClippedVerbatimLiteral(headLength, tailLength, useUnicodeEllipsis);

        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task ToClippedVerbatimLiteral_WithDefaultEllipsis_UsesThreeDots()
    {
        await Assert.That("abcdefghij".AsSpan().ToClippedVerbatimLiteral(3, 3)).IsEqualTo("@\"abc...hij\"");
    }

    [Test]
    [Arguments(-1, 0, "headLength")]
    [Arguments(0, -1, "tailLength")]
    public async Task ToClippedVerbatimLiteral_WithNegativeLength_ThrowsArgumentOutOfRangeException(
        int headLength,
        int tailLength,
        string paramName)
    {
        void Act() => "abc".AsSpan().ToClippedVerbatimLiteral(headLength, tailLength);

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
        var result = input.AsSpan().ToClippedLiteral(literalKind, headLength, tailLength, useUnicodeEllipsis);

        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task ToClippedLiteral_WithDefaultEllipsis_UsesThreeDots()
    {
        var result = "abcdefghij".AsSpan().ToClippedLiteral(StringLiteralKind.Verbatim, 3, 3);

        await Assert.That(result).IsEqualTo("@\"abc...hij\"");
    }

    [Test]
    public async Task ToClippedLiteral_WithUndefinedLiteralKind_ThrowsArgumentException()
    {
        static void Act() => "abc".AsSpan().ToClippedLiteral((StringLiteralKind)2, 3, 3);

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
        void Act() => "abc".AsSpan().ToClippedLiteral(StringLiteralKind.Quoted, headLength, tailLength);

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName(paramName);
    }
}
