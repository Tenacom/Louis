// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Text;
using Louis.Text;

internal sealed class StringBuilderExtensionsAppendClippedLiteralTests
{
    [Test]
    [Arguments("abcdefghij", StringLiteralKind.Quoted, 3, 4, "\"abcdefghij\"")]
    [Arguments("abcdefghij", StringLiteralKind.Quoted, 3, 3, "\"abc...hij\"")]
    [Arguments("abcdefghij", StringLiteralKind.Verbatim, 3, 3, "@\"abc...hij\"")]
    public async Task AppendClippedLiteral_WithString_AppendsLiteralClippedWithThreeDots(
        string input,
        StringLiteralKind literalKind,
        int headLength,
        int tailLength,
        string expected)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendClippedLiteral(literalKind, input, headLength, tailLength);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("x" + expected);
    }

    [Test]
    [Arguments(StringLiteralKind.Quoted)]
    [Arguments(StringLiteralKind.Verbatim)]
    public async Task AppendClippedLiteral_WithNullString_AppendsNullWithoutQuotes(StringLiteralKind literalKind)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendClippedLiteral(literalKind, (string?)null, 3, 3);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("xnull");
    }

    [Test]
    [MethodDataSource(typeof(ClippedStringLiteralRows), nameof(ClippedStringLiteralRows.Literal))]
    public async Task AppendClippedLiteral_WithStringAndUseUnicodeEllipsis_AppendsClippedLiteralOfGivenKind(
        string input,
        StringLiteralKind literalKind,
        int headLength,
        int tailLength,
        bool useUnicodeEllipsis,
        string expected)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendClippedLiteral(literalKind, input, headLength, tailLength, useUnicodeEllipsis);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("x" + expected);
    }

    [Test]
    [Arguments(StringLiteralKind.Quoted)]
    [Arguments(StringLiteralKind.Verbatim)]
    public async Task AppendClippedLiteral_WithNullStringAndUseUnicodeEllipsis_AppendsNullWithoutQuotes(
        StringLiteralKind literalKind)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendClippedLiteral(literalKind, (string?)null, 3, 3, true);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("xnull");
    }

    [Test]
    [Arguments("abcdefghij", StringLiteralKind.Quoted, 3, 4, "\"abcdefghij\"")]
    [Arguments("abcdefghij", StringLiteralKind.Quoted, 3, 3, "\"abc...hij\"")]
    [Arguments("abcdefghij", StringLiteralKind.Verbatim, 3, 3, "@\"abc...hij\"")]
    public async Task AppendClippedLiteral_WithSpan_AppendsLiteralClippedWithThreeDots(
        string input,
        StringLiteralKind literalKind,
        int headLength,
        int tailLength,
        string expected)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendClippedLiteral(literalKind, input.AsSpan(), headLength, tailLength);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("x" + expected);
    }

    [Test]
    [MethodDataSource(typeof(ClippedStringLiteralRows), nameof(ClippedStringLiteralRows.Literal))]
    public async Task AppendClippedLiteral_WithSpanAndUseUnicodeEllipsis_AppendsClippedLiteralOfGivenKind(
        string input,
        StringLiteralKind literalKind,
        int headLength,
        int tailLength,
        bool useUnicodeEllipsis,
        string expected)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendClippedLiteral(literalKind, input.AsSpan(), headLength, tailLength, useUnicodeEllipsis);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("x" + expected);
    }

    [Test]
    public async Task AppendClippedLiteral_WithNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        StringBuilder builder = null!;
        var kind = StringLiteralKind.Quoted;
        void ActWithString() => builder.AppendClippedLiteral(kind, "abc", 3, 3);
        void ActWithStringAndUseUnicodeEllipsis() => builder.AppendClippedLiteral(kind, "abc", 3, 3, true);
        void ActWithSpan() => builder.AppendClippedLiteral(kind, "abc".AsSpan(), 3, 3);
        void ActWithSpanAndUseUnicodeEllipsis() => builder.AppendClippedLiteral(kind, "abc".AsSpan(), 3, 3, true);

        await Assert.That(ActWithString).Throws<ArgumentNullException>().WithParameterName("this");
        await Assert.That(ActWithStringAndUseUnicodeEllipsis).Throws<ArgumentNullException>().WithParameterName("this");
        await Assert.That(ActWithSpan).Throws<ArgumentNullException>().WithParameterName("this");
        await Assert.That(ActWithSpanAndUseUnicodeEllipsis).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task AppendClippedLiteral_WithUndefinedLiteralKind_ThrowsArgumentException()
    {
        var builder = new StringBuilder();
        var kind = (StringLiteralKind)2;
        void ActWithString() => builder.AppendClippedLiteral(kind, "abc", 3, 3);
        void ActWithStringAndUseUnicodeEllipsis() => builder.AppendClippedLiteral(kind, "abc", 3, 3, true);
        void ActWithSpan() => builder.AppendClippedLiteral(kind, "abc".AsSpan(), 3, 3);
        void ActWithSpanAndUseUnicodeEllipsis() => builder.AppendClippedLiteral(kind, "abc".AsSpan(), 3, 3, true);

        await Assert.That(ActWithString).Throws<ArgumentException>().WithParameterName("literalKind");
        await Assert.That(ActWithStringAndUseUnicodeEllipsis).Throws<ArgumentException>().WithParameterName("literalKind");
        await Assert.That(ActWithSpan).Throws<ArgumentException>().WithParameterName("literalKind");
        await Assert.That(ActWithSpanAndUseUnicodeEllipsis).Throws<ArgumentException>().WithParameterName("literalKind");
    }

    [Test]
    [Arguments(-1, 0, "headLength")]
    [Arguments(0, -1, "tailLength")]
    public async Task AppendClippedLiteral_WithNegativeLength_ThrowsArgumentOutOfRangeException(
        int headLength,
        int tailLength,
        string paramName)
    {
        var builder = new StringBuilder();
        var kind = StringLiteralKind.Quoted;
        void ActWithString() => builder.AppendClippedLiteral(kind, "abc", headLength, tailLength);
        void ActWithStringAndUseUnicodeEllipsis() => builder.AppendClippedLiteral(kind, "abc", headLength, tailLength, true);
        void ActWithSpan() => builder.AppendClippedLiteral(kind, "abc".AsSpan(), headLength, tailLength);
        void ActWithSpanAndUseUnicodeEllipsis() => builder.AppendClippedLiteral(kind, "abc".AsSpan(), headLength, tailLength, true);

        await Assert.That(ActWithString).Throws<ArgumentOutOfRangeException>().WithParameterName(paramName);
        await Assert.That(ActWithStringAndUseUnicodeEllipsis).Throws<ArgumentOutOfRangeException>().WithParameterName(paramName);
        await Assert.That(ActWithSpan).Throws<ArgumentOutOfRangeException>().WithParameterName(paramName);
        await Assert.That(ActWithSpanAndUseUnicodeEllipsis).Throws<ArgumentOutOfRangeException>().WithParameterName(paramName);
    }
}
