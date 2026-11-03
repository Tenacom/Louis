// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Text;
using Louis.Text;

internal sealed class StringBuilderExtensionsAppendClippedQuotedLiteralTests
{
    [Test]
    [Arguments("abcdefghij", 3, 4, "\"abcdefghij\"")]
    [Arguments("abcdefghij", 3, 3, "\"abc...hij\"")]
    public async Task AppendClippedQuotedLiteral_WithString_AppendsLiteralClippedWithThreeDots(
        string input,
        int headLength,
        int tailLength,
        string expected)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendClippedQuotedLiteral(input, headLength, tailLength);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("x" + expected);
    }

    [Test]
    public async Task AppendClippedQuotedLiteral_WithNullString_AppendsNullWithoutQuotes()
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendClippedQuotedLiteral(null, 3, 3);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("xnull");
    }

    [Test]
    [MethodDataSource(typeof(ClippedStringLiteralRows), nameof(ClippedStringLiteralRows.Quoted))]
    public async Task AppendClippedQuotedLiteral_WithStringAndUseUnicodeEllipsis_AppendsClippedQuotedLiteral(
        string input,
        int headLength,
        int tailLength,
        bool useUnicodeEllipsis,
        string expected)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendClippedQuotedLiteral(input, headLength, tailLength, useUnicodeEllipsis);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("x" + expected);
    }

    [Test]
    public async Task AppendClippedQuotedLiteral_WithNullStringAndUseUnicodeEllipsis_AppendsNullWithoutQuotes()
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendClippedQuotedLiteral(null, 3, 3, true);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("xnull");
    }

    [Test]
    [Arguments("abcdefghij", 3, 4, "\"abcdefghij\"")]
    [Arguments("abcdefghij", 3, 3, "\"abc...hij\"")]
    public async Task AppendClippedQuotedLiteral_WithSpan_AppendsLiteralClippedWithThreeDots(
        string input,
        int headLength,
        int tailLength,
        string expected)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendClippedQuotedLiteral(input.AsSpan(), headLength, tailLength);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("x" + expected);
    }

    [Test]
    [MethodDataSource(typeof(ClippedStringLiteralRows), nameof(ClippedStringLiteralRows.Quoted))]
    public async Task AppendClippedQuotedLiteral_WithSpanAndUseUnicodeEllipsis_AppendsClippedQuotedLiteral(
        string input,
        int headLength,
        int tailLength,
        bool useUnicodeEllipsis,
        string expected)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendClippedQuotedLiteral(input.AsSpan(), headLength, tailLength, useUnicodeEllipsis);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("x" + expected);
    }

    [Test]
    public async Task AppendClippedQuotedLiteral_WithNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        StringBuilder builder = null!;
        void ActWithString() => builder.AppendClippedQuotedLiteral("abc", 3, 3);
        void ActWithStringAndUseUnicodeEllipsis() => builder.AppendClippedQuotedLiteral("abc", 3, 3, true);
        void ActWithSpan() => builder.AppendClippedQuotedLiteral("abc".AsSpan(), 3, 3);
        void ActWithSpanAndUseUnicodeEllipsis() => builder.AppendClippedQuotedLiteral("abc".AsSpan(), 3, 3, true);

        await Assert.That(ActWithString).Throws<ArgumentNullException>().WithParameterName("this");
        await Assert.That(ActWithStringAndUseUnicodeEllipsis).Throws<ArgumentNullException>().WithParameterName("this");
        await Assert.That(ActWithSpan).Throws<ArgumentNullException>().WithParameterName("this");
        await Assert.That(ActWithSpanAndUseUnicodeEllipsis).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    [Arguments(-1, 0, "headLength")]
    [Arguments(0, -1, "tailLength")]
    public async Task AppendClippedQuotedLiteral_WithNegativeLength_ThrowsArgumentOutOfRangeException(
        int headLength,
        int tailLength,
        string paramName)
    {
        var builder = new StringBuilder();
        void ActWithString() => builder.AppendClippedQuotedLiteral("abc", headLength, tailLength);
        void ActWithStringAndUseUnicodeEllipsis() => builder.AppendClippedQuotedLiteral("abc", headLength, tailLength, true);
        void ActWithSpan() => builder.AppendClippedQuotedLiteral("abc".AsSpan(), headLength, tailLength);
        void ActWithSpanAndUseUnicodeEllipsis() => builder.AppendClippedQuotedLiteral("abc".AsSpan(), headLength, tailLength, true);

        await Assert.That(ActWithString).Throws<ArgumentOutOfRangeException>().WithParameterName(paramName);
        await Assert.That(ActWithStringAndUseUnicodeEllipsis).Throws<ArgumentOutOfRangeException>().WithParameterName(paramName);
        await Assert.That(ActWithSpan).Throws<ArgumentOutOfRangeException>().WithParameterName(paramName);
        await Assert.That(ActWithSpanAndUseUnicodeEllipsis).Throws<ArgumentOutOfRangeException>().WithParameterName(paramName);
    }
}
