// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Text;

internal sealed class CharReadOnlySpanExtensionsGetLiteralLengthTests
{
    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Quoted))]
    public async Task GetQuotedLiteralLength_ReturnsLengthOfQuotedLiteral(string input, string literal)
    {
        await Assert.That(input.AsSpan().GetQuotedLiteralLength()).IsEqualTo(literal.Length);
    }

    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Verbatim))]
    public async Task GetVerbatimLiteralLength_ReturnsLengthOfVerbatimLiteral(string input, string literal)
    {
        await Assert.That(input.AsSpan().GetVerbatimLiteralLength()).IsEqualTo(literal.Length);
    }

    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Literal))]
    public async Task GetLiteralLength_ReturnsLengthOfLiteralOfGivenKind(
        string input,
        StringLiteralKind literalKind,
        string literal)
    {
        await Assert.That(input.AsSpan().GetLiteralLength(literalKind)).IsEqualTo(literal.Length);
    }

    [Test]
    public async Task GetLiteralLength_WithUndefinedLiteralKind_ThrowsArgumentException()
    {
        static void Act() => "abc".AsSpan().GetLiteralLength((StringLiteralKind)2);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("literalKind");
    }
}
