// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Text;

internal sealed class StringExtensionsGetLiteralLengthTests
{
    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Quoted))]
    public async Task GetQuotedLiteralLength_ReturnsLengthOfQuotedLiteral(string input, string literal)
    {
        await Assert.That(input.GetQuotedLiteralLength()).IsEqualTo(literal.Length);
    }

    [Test]
    public async Task GetQuotedLiteralLength_WithNullString_ReturnsLengthOfNull()
    {
        await Assert.That(((string?)null).GetQuotedLiteralLength()).IsEqualTo(4);
    }

    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Verbatim))]
    public async Task GetVerbatimLiteralLength_ReturnsLengthOfVerbatimLiteral(string input, string literal)
    {
        await Assert.That(input.GetVerbatimLiteralLength()).IsEqualTo(literal.Length);
    }

    [Test]
    public async Task GetVerbatimLiteralLength_WithNullString_ReturnsLengthOfNull()
    {
        await Assert.That(((string?)null).GetVerbatimLiteralLength()).IsEqualTo(4);
    }

    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Literal))]
    public async Task GetLiteralLength_ReturnsLengthOfLiteralOfGivenKind(
        string input,
        StringLiteralKind literalKind,
        string literal)
    {
        await Assert.That(input.GetLiteralLength(literalKind)).IsEqualTo(literal.Length);
    }

    [Test]
    [Arguments(StringLiteralKind.Quoted)]
    [Arguments(StringLiteralKind.Verbatim)]
    public async Task GetLiteralLength_WithNullString_ReturnsLengthOfNull(StringLiteralKind literalKind)
    {
        await Assert.That(((string?)null).GetLiteralLength(literalKind)).IsEqualTo(4);
    }

    [Test]
    [Arguments("abc")]
    [Arguments(null)]
    public async Task GetLiteralLength_WithUndefinedLiteralKind_ThrowsArgumentException(string? input)
    {
        void Act() => input.GetLiteralLength((StringLiteralKind)2);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("literalKind");
    }
}
