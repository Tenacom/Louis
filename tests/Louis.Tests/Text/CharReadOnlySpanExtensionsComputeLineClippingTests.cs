// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Text;

internal sealed class CharReadOnlySpanExtensionsComputeLineClippingTests
{
    [Test]
    [MethodDataSource(typeof(LineClippingRows), nameof(LineClippingRows.All))]
    public async Task ComputeLineClipping_ReturnsRangesAndLineCounts(
        string input,
        int headLines,
        int tailLines,
        (string Head, string Tail, int HeadLineCount, int TailLineCount, int OmittedLineCount) expected)
    {
        var result = input.AsSpan().ComputeLineClipping(headLines, tailLines);

        await Assert.That(result.Head).IsEqualTo(new Range(0, expected.Head.Length));
        await Assert.That(result.Tail).IsEqualTo(new Range(input.Length - expected.Tail.Length, input.Length));
        await Assert.That(input[result.Head]).IsEqualTo(expected.Head);
        await Assert.That(input[result.Tail]).IsEqualTo(expected.Tail);
        await Assert.That(result.HeadLineCount).IsEqualTo(expected.HeadLineCount);
        await Assert.That(result.TailLineCount).IsEqualTo(expected.TailLineCount);
        await Assert.That(result.OmittedLineCount).IsEqualTo(expected.OmittedLineCount);
    }

    [Test]
    public async Task ComputeLineClipping_OnEveryShortText_FindsTheLinesOfAForwardScan()
    {
        const int MaxLines = 4;
        var failures = new List<string>();
        foreach (var text in BuildShortTexts(maxLength: 6))
        {
            var boundaries = FindLineBoundaries(text);
            var lineCount = boundaries.Count - 1;
            if (lineCount != CountLinesRead(text))
            {
                failures.Add($"{text.ToQuotedLiteral()}: the forward scan and ReadLine disagree");
            }

            for (var headLines = 0; headLines <= MaxLines; headLines++)
            {
                for (var tailLines = 0; tailLines <= MaxLines; tailLines++)
                {
                    var isClipped = lineCount > headLines + tailLines + 1;
                    var headLineCount = isClipped ? headLines : lineCount;
                    var tailLineCount = isClipped ? tailLines : 0;
                    var expected = (
                        new Range(0, boundaries[headLineCount]),
                        new Range(boundaries[lineCount - tailLineCount], text.Length),
                        headLineCount,
                        tailLineCount,
                        lineCount - headLineCount - tailLineCount);

                    var result = text.AsSpan().ComputeLineClipping(headLines, tailLines);
                    var actual = (result.Head, result.Tail, result.HeadLineCount, result.TailLineCount, result.OmittedLineCount);
                    if (!actual.Equals(expected))
                    {
                        failures.Add($"{text.ToQuotedLiteral()}, {headLines}, {tailLines}: expected {expected}, got {actual}");
                    }
                }
            }
        }

        await Assert.That(failures).IsEmpty();
    }

    [Test]
    [Arguments(-1, 0, "headLines")]
    [Arguments(0, -1, "tailLines")]
    public async Task ComputeLineClipping_WithNegativeLineCount_ThrowsArgumentOutOfRangeException(
        int headLines,
        int tailLines,
        string paramName)
    {
        void Act() => "abc".AsSpan().ComputeLineClipping(headLines, tailLines);

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName(paramName);
    }

    // Returns every text of at most maxLength characters, each of them a letter, a '\r', or a '\n'.
    private static List<string> BuildShortTexts(int maxLength)
    {
        List<string> texts = [string.Empty];
        for (var i = 0; i < texts.Count; i++)
        {
            if (texts[i].Length < maxLength)
            {
                texts.AddRange([texts[i] + "a", texts[i] + "\r", texts[i] + "\n"]);
            }
        }

        return texts;
    }

    // Returns the start of the text, then the index just past each of its lines, line terminator included.
    private static List<int> FindLineBoundaries(string text)
    {
        List<int> boundaries = [0];
        for (var i = 0; i < text.Length; i++)
        {
            var isLastCharacter = i == text.Length - 1;
            var isCarriageReturnOfCrLf = text[i] == '\r' && !isLastCharacter && text[i + 1] == '\n';
            var isEndOfLine = !isCarriageReturnOfCrLf && (text[i] is '\r' or '\n' || isLastCharacter);
            if (isEndOfLine)
            {
                boundaries.Add(i + 1);
            }
        }

        return boundaries;
    }

    private static int CountLinesRead(string text)
    {
        using var reader = new StringReader(text);
        var count = 0;
        while (reader.ReadLine() is not null)
        {
            count++;
        }

        return count;
    }
}
