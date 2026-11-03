// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Text;

internal sealed class StringExtensionsToLiteralTests
{
    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Quoted))]
    public async Task ToQuotedLiteral_ReturnsQuotedLiteral(string input, string expected)
    {
        await Assert.That(input.ToQuotedLiteral()).IsEqualTo(expected);
    }

    [Test]
    public async Task ToQuotedLiteral_WithNullString_ReturnsNullWithoutQuotes()
    {
        await Assert.That(((string?)null).ToQuotedLiteral()).IsEqualTo("null");
    }

    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Verbatim))]
    public async Task ToVerbatimLiteral_ReturnsVerbatimLiteral(string input, string expected)
    {
        await Assert.That(input.ToVerbatimLiteral()).IsEqualTo(expected);
    }

    [Test]
    public async Task ToVerbatimLiteral_WithNullString_ReturnsNullWithoutQuotes()
    {
        await Assert.That(((string?)null).ToVerbatimLiteral()).IsEqualTo("null");
    }

    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Literal))]
    public async Task ToLiteral_ReturnsLiteralOfGivenKind(string input, StringLiteralKind literalKind, string expected)
    {
        await Assert.That(input.ToLiteral(literalKind)).IsEqualTo(expected);
    }

    [Test]
    [Arguments(StringLiteralKind.Quoted)]
    [Arguments(StringLiteralKind.Verbatim)]
    public async Task ToLiteral_WithNullString_ReturnsNullWithoutQuotes(StringLiteralKind literalKind)
    {
        await Assert.That(((string?)null).ToLiteral(literalKind)).IsEqualTo("null");
    }

    [Test]
    [Arguments("abc")]
    [Arguments(null)]
    public async Task ToLiteral_WithUndefinedLiteralKind_ThrowsArgumentException(string? input)
    {
        void Act() => input.ToLiteral((StringLiteralKind)2);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("literalKind");
    }
}
