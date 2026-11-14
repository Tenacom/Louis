// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Text;

internal sealed class StringExtensionsComputeLiteralLengthTests
{
    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Quoted))]
    public async Task ComputeQuotedLiteralLength_ReturnsLengthOfQuotedLiteral(string input, string literal)
    {
        await Assert.That(input.ComputeQuotedLiteralLength()).IsEqualTo(literal.Length);
    }

    [Test]
    public async Task ComputeQuotedLiteralLength_WithNullString_ReturnsLengthOfNull()
    {
        await Assert.That(((string?)null).ComputeQuotedLiteralLength()).IsEqualTo(4);
    }

    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Verbatim))]
    public async Task ComputeVerbatimLiteralLength_ReturnsLengthOfVerbatimLiteral(string input, string literal)
    {
        await Assert.That(input.ComputeVerbatimLiteralLength()).IsEqualTo(literal.Length);
    }

    [Test]
    public async Task ComputeVerbatimLiteralLength_WithNullString_ReturnsLengthOfNull()
    {
        await Assert.That(((string?)null).ComputeVerbatimLiteralLength()).IsEqualTo(4);
    }

    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Literal))]
    public async Task ComputeLiteralLength_ReturnsLengthOfLiteralOfGivenKind(
        string input,
        StringLiteralKind literalKind,
        string literal)
    {
        await Assert.That(input.ComputeLiteralLength(literalKind)).IsEqualTo(literal.Length);
    }

    [Test]
    [Arguments(StringLiteralKind.Quoted)]
    [Arguments(StringLiteralKind.Verbatim)]
    public async Task ComputeLiteralLength_WithNullString_ReturnsLengthOfNull(StringLiteralKind literalKind)
    {
        await Assert.That(((string?)null).ComputeLiteralLength(literalKind)).IsEqualTo(4);
    }

    [Test]
    [Arguments("abc")]
    [Arguments(null)]
    public async Task ComputeLiteralLength_WithUndefinedLiteralKind_ThrowsArgumentException(string? input)
    {
        void Act() => input.ComputeLiteralLength((StringLiteralKind)2);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("literalKind");
    }
}
