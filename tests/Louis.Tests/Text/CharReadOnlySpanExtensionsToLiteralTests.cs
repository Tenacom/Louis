// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Text;

internal sealed class CharReadOnlySpanExtensionsToLiteralTests
{
    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Quoted))]
    public async Task ToQuotedLiteral_ReturnsQuotedLiteral(string input, string expected)
    {
        await Assert.That(input.AsSpan().ToQuotedLiteral()).IsEqualTo(expected);
    }

    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Verbatim))]
    public async Task ToVerbatimLiteral_ReturnsVerbatimLiteral(string input, string expected)
    {
        await Assert.That(input.AsSpan().ToVerbatimLiteral()).IsEqualTo(expected);
    }

    [Test]
    [MethodDataSource(typeof(StringLiteralRows), nameof(StringLiteralRows.Literal))]
    public async Task ToLiteral_ReturnsLiteralOfGivenKind(string input, StringLiteralKind literalKind, string expected)
    {
        await Assert.That(input.AsSpan().ToLiteral(literalKind)).IsEqualTo(expected);
    }

    [Test]
    public async Task ToLiteral_WithUndefinedLiteralKind_ThrowsArgumentException()
    {
        static void Act() => "abc".AsSpan().ToLiteral((StringLiteralKind)2);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("literalKind");
    }
}
