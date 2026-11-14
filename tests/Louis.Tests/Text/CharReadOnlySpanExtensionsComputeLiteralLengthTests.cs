// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Text;

internal sealed class CharReadOnlySpanExtensionsComputeLiteralLengthTests
{
    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Quoted))]
    public async Task ComputeQuotedLiteralLength_ReturnsLengthOfQuotedLiteral(string input, string literal)
    {
        await Assert.That(input.AsSpan().ComputeQuotedLiteralLength()).IsEqualTo(literal.Length);
    }

    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Verbatim))]
    public async Task ComputeVerbatimLiteralLength_ReturnsLengthOfVerbatimLiteral(string input, string literal)
    {
        await Assert.That(input.AsSpan().ComputeVerbatimLiteralLength()).IsEqualTo(literal.Length);
    }

    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Literal))]
    public async Task ComputeLiteralLength_ReturnsLengthOfLiteralOfGivenKind(
        string input,
        StringLiteralKind literalKind,
        string literal)
    {
        await Assert.That(input.AsSpan().ComputeLiteralLength(literalKind)).IsEqualTo(literal.Length);
    }

    [Test]
    public async Task ComputeLiteralLength_WithUndefinedLiteralKind_ThrowsArgumentException()
    {
        static void Act() => "abc".AsSpan().ComputeLiteralLength((StringLiteralKind)2);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("literalKind");
    }
}
