// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Text;
using Louis.Text;

internal sealed class StringBuilderExtensionsAppendLiteralTests
{
    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Quoted))]
    public async Task AppendQuotedLiteral_WithString_AppendsQuotedLiteral(string input, string expected)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendQuotedLiteral(input);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("x" + expected);
    }

    [Test]
    public async Task AppendQuotedLiteral_WithNullString_AppendsNullWithoutQuotes()
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendQuotedLiteral((string?)null);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("xnull");
    }

    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Quoted))]
    public async Task AppendQuotedLiteral_WithSpan_AppendsQuotedLiteral(string input, string expected)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendQuotedLiteral(input.AsSpan());

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("x" + expected);
    }

    [Test]
    public async Task AppendQuotedLiteral_WithNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        StringBuilder builder = null!;
        void ActWithString() => builder.AppendQuotedLiteral("abc");
        void ActWithSpan() => builder.AppendQuotedLiteral("abc".AsSpan());

        await Assert.That(ActWithString).Throws<ArgumentNullException>().WithParameterName("this");
        await Assert.That(ActWithSpan).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Verbatim))]
    public async Task AppendVerbatimLiteral_WithString_AppendsVerbatimLiteral(string input, string expected)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendVerbatimLiteral(input);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("x" + expected);
    }

    [Test]
    public async Task AppendVerbatimLiteral_WithNullString_AppendsNullWithoutQuotes()
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendVerbatimLiteral((string?)null);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("xnull");
    }

    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Verbatim))]
    public async Task AppendVerbatimLiteral_WithSpan_AppendsVerbatimLiteral(string input, string expected)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendVerbatimLiteral(input.AsSpan());

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("x" + expected);
    }

    [Test]
    public async Task AppendVerbatimLiteral_WithNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        StringBuilder builder = null!;
        void ActWithString() => builder.AppendVerbatimLiteral("abc");
        void ActWithSpan() => builder.AppendVerbatimLiteral("abc".AsSpan());

        await Assert.That(ActWithString).Throws<ArgumentNullException>().WithParameterName("this");
        await Assert.That(ActWithSpan).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Literal))]
    public async Task AppendLiteral_WithString_AppendsLiteralOfGivenKind(
        string input,
        StringLiteralKind literalKind,
        string expected)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendLiteral(literalKind, input);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("x" + expected);
    }

    [Test]
    [Arguments(StringLiteralKind.Quoted)]
    [Arguments(StringLiteralKind.Verbatim)]
    public async Task AppendLiteral_WithNullString_AppendsNullWithoutQuotes(StringLiteralKind literalKind)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendLiteral(literalKind, (string?)null);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("xnull");
    }

    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Literal))]
    public async Task AppendLiteral_WithSpan_AppendsLiteralOfGivenKind(
        string input,
        StringLiteralKind literalKind,
        string expected)
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendLiteral(literalKind, input.AsSpan());

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("x" + expected);
    }

    [Test]
    public async Task AppendLiteral_WithNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        StringBuilder builder = null!;
        void ActWithString() => builder.AppendLiteral(StringLiteralKind.Quoted, "abc");
        void ActWithSpan() => builder.AppendLiteral(StringLiteralKind.Quoted, "abc".AsSpan());

        await Assert.That(ActWithString).Throws<ArgumentNullException>().WithParameterName("this");
        await Assert.That(ActWithSpan).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    [Arguments("abc")]
    [Arguments(null)]
    public async Task AppendLiteral_WithUndefinedLiteralKind_ThrowsArgumentException(string? input)
    {
        var builder = new StringBuilder();
        void ActWithString() => builder.AppendLiteral((StringLiteralKind)2, input);
        void ActWithSpan() => builder.AppendLiteral((StringLiteralKind)2, "abc".AsSpan());

        await Assert.That(ActWithString).Throws<ArgumentException>().WithParameterName("literalKind");
        await Assert.That(ActWithSpan).Throws<ArgumentException>().WithParameterName("literalKind");
    }
}
