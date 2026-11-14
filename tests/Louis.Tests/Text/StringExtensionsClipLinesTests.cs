// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Text;

internal sealed class StringExtensionsClipLinesTests
{
    [Test]
    [MethodDataSource(typeof(ClipLinesRows), nameof(ClipLinesRows.All))]
    public async Task ClipLines_ReturnsRangesAndLineCounts(
        string input,
        int headLines,
        int tailLines,
        (string Head, string Tail, int HeadLineCount, int TailLineCount, int OmittedLineCount) expected)
    {
        var result = input.ClipLines(headLines, tailLines);

        await Assert.That(result.Head).IsEqualTo(new Range(0, expected.Head.Length));
        await Assert.That(result.Tail).IsEqualTo(new Range(input.Length - expected.Tail.Length, input.Length));
        await Assert.That(input[result.Head]).IsEqualTo(expected.Head);
        await Assert.That(input[result.Tail]).IsEqualTo(expected.Tail);
        await Assert.That(result.HeadLineCount).IsEqualTo(expected.HeadLineCount);
        await Assert.That(result.TailLineCount).IsEqualTo(expected.TailLineCount);
        await Assert.That(result.OmittedLineCount).IsEqualTo(expected.OmittedLineCount);
    }

    [Test]
    public async Task ClipLines_WithNullString_ReturnsDefault()
    {
        await Assert.That(((string?)null).ClipLines(2, 2)).IsEqualTo(default(ClippedLines));
    }

    [Test]
    [Arguments(-1, 0, "headLines")]
    [Arguments(0, -1, "tailLines")]
    public async Task ClipLines_WithNegativeLineCount_ThrowsArgumentOutOfRangeException(
        int headLines,
        int tailLines,
        string paramName)
    {
        void Act() => "abc".ClipLines(headLines, tailLines);

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName(paramName);
    }
}
