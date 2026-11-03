// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Text;
using Louis.Text;

internal sealed class StringBuilderExtensionsAppendClippedVerbatimLiteralTests
{
    [Test]
    [Arguments("abcdefghij", 3, 4, "@\"abcdefghij\"")]
    [Arguments("abcdefghij", 3, 3, "@\"abc...hij\"")]
    public async Task AppendClippedVerbatimLiteral_WithString_AppendsLiteralClippedWithThreeDots(
        string input,
        int headLength,
        int tailLength,
        string expected)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendClippedVerbatimLiteral(input, headLength, tailLength);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("x" + expected);
    }

    [Test]
    public async Task AppendClippedVerbatimLiteral_WithNullString_AppendsNullWithoutQuotes()
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendClippedVerbatimLiteral(null, 3, 3);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("xnull");
    }

    [Test]
    [MethodDataSource(typeof(ClippedStringLiteralRows), nameof(ClippedStringLiteralRows.Verbatim))]
    public async Task AppendClippedVerbatimLiteral_WithStringAndUseUnicodeEllipsis_AppendsClippedVerbatimLiteral(
        string input,
        int headLength,
        int tailLength,
        bool useUnicodeEllipsis,
        string expected)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendClippedVerbatimLiteral(input, headLength, tailLength, useUnicodeEllipsis);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("x" + expected);
    }

    [Test]
    public async Task AppendClippedVerbatimLiteral_WithNullStringAndUseUnicodeEllipsis_AppendsNullWithoutQuotes()
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendClippedVerbatimLiteral(null, 3, 3, true);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("xnull");
    }

    [Test]
    [Arguments("abcdefghij", 3, 4, "@\"abcdefghij\"")]
    [Arguments("abcdefghij", 3, 3, "@\"abc...hij\"")]
    public async Task AppendClippedVerbatimLiteral_WithSpan_AppendsLiteralClippedWithThreeDots(
        string input,
        int headLength,
        int tailLength,
        string expected)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendClippedVerbatimLiteral(input.AsSpan(), headLength, tailLength);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("x" + expected);
    }

    [Test]
    [MethodDataSource(typeof(ClippedStringLiteralRows), nameof(ClippedStringLiteralRows.Verbatim))]
    public async Task AppendClippedVerbatimLiteral_WithSpanAndUseUnicodeEllipsis_AppendsClippedVerbatimLiteral(
        string input,
        int headLength,
        int tailLength,
        bool useUnicodeEllipsis,
        string expected)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendClippedVerbatimLiteral(input.AsSpan(), headLength, tailLength, useUnicodeEllipsis);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("x" + expected);
    }

    [Test]
    public async Task AppendClippedVerbatimLiteral_WithNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        StringBuilder builder = null!;
        void ActWithString() => builder.AppendClippedVerbatimLiteral("abc", 3, 3);
        void ActWithStringAndUseUnicodeEllipsis() => builder.AppendClippedVerbatimLiteral("abc", 3, 3, true);
        void ActWithSpan() => builder.AppendClippedVerbatimLiteral("abc".AsSpan(), 3, 3);
        void ActWithSpanAndUseUnicodeEllipsis() => builder.AppendClippedVerbatimLiteral("abc".AsSpan(), 3, 3, true);

        await Assert.That(ActWithString).Throws<ArgumentNullException>().WithParameterName("this");
        await Assert.That(ActWithStringAndUseUnicodeEllipsis).Throws<ArgumentNullException>().WithParameterName("this");
        await Assert.That(ActWithSpan).Throws<ArgumentNullException>().WithParameterName("this");
        await Assert.That(ActWithSpanAndUseUnicodeEllipsis).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    [Arguments(-1, 0, "headLength")]
    [Arguments(0, -1, "tailLength")]
    public async Task AppendClippedVerbatimLiteral_WithNegativeLength_ThrowsArgumentOutOfRangeException(
        int headLength,
        int tailLength,
        string paramName)
    {
        var builder = new StringBuilder();
        void ActWithString() => builder.AppendClippedVerbatimLiteral("abc", headLength, tailLength);
        void ActWithStringAndUseUnicodeEllipsis() => builder.AppendClippedVerbatimLiteral("abc", headLength, tailLength, true);
        void ActWithSpan() => builder.AppendClippedVerbatimLiteral("abc".AsSpan(), headLength, tailLength);
        void ActWithSpanAndUseUnicodeEllipsis() => builder.AppendClippedVerbatimLiteral("abc".AsSpan(), headLength, tailLength, true);

        await Assert.That(ActWithString).Throws<ArgumentOutOfRangeException>().WithParameterName(paramName);
        await Assert.That(ActWithStringAndUseUnicodeEllipsis).Throws<ArgumentOutOfRangeException>().WithParameterName(paramName);
        await Assert.That(ActWithSpan).Throws<ArgumentOutOfRangeException>().WithParameterName(paramName);
        await Assert.That(ActWithSpanAndUseUnicodeEllipsis).Throws<ArgumentOutOfRangeException>().WithParameterName(paramName);
    }
}
