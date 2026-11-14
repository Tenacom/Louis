// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using CommunityToolkit.Diagnostics;

namespace Louis.Text;

partial class CharReadOnlySpanExtensions
{
    /// <summary>
    /// Finds the first and the last lines of a span of characters, and counts the lines between them.
    /// </summary>
    /// <param name="this">The <see cref="ReadOnlySpan{T}">ReadOnlySpan&lt;char&gt;</see>
    /// on which this method is called.</param>
    /// <param name="headLines">The number of lines to keep at the start of the span, when the span is clipped.</param>
    /// <param name="tailLines">The number of lines to keep at the end of the span, when the span is clipped.</param>
    /// <returns>A <see cref="ClippedLines"/> value, whose ranges refer to <paramref name="this"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para><paramref name="headLines"/> is less than 0.</para>
    /// <para>- or -</para>
    /// <para><paramref name="tailLines"/> is less than 0.</para>
    /// </exception>
    /// <remarks>
    /// <para>A line ends at a line feed (<c>\n</c>), at a carriage return (<c>\r</c>), at a carriage return
    /// immediately followed by a line feed (<c>\r\n</c>), or at the end of the span,
    /// as in <see cref="System.IO.TextReader.ReadLine"/>.
    /// A line terminator at the end of the span starts no line, and an empty span has no lines.</para>
    /// <para>A span of more than <paramref name="headLines"/> + <paramref name="tailLines"/> + 1 lines is clipped:
    /// <see cref="ClippedLines.Head"/> holds its first <paramref name="headLines"/> lines,
    /// and <see cref="ClippedLines.Tail"/> its last <paramref name="tailLines"/> lines.</para>
    /// <para>A span of at most that many lines is not clipped: <see cref="ClippedLines.Head"/> holds all of its lines,
    /// and <see cref="ClippedLines.Tail"/> is empty. No span is clipped by a single line,
    /// because a caller usually shows one line in place of the omitted lines.</para>
    /// <para>This method copies no characters and allocates no memory.</para>
    /// </remarks>
    /// <seealso cref="StringExtensions.ClipLines"/>
    public static ClippedLines ClipLines(this ReadOnlySpan<char> @this, int headLines, int tailLines)
    {
        Guard.IsGreaterThanOrEqualTo(headLines, 0);
        Guard.IsGreaterThanOrEqualTo(tailLines, 0);

        var headEnd = 0;
        var headLineCount = 0;
        while (headLineCount < headLines && headEnd < @this.Length)
        {
            headEnd += FindEndOfFirstLine(@this[headEnd..]);
            headLineCount++;
        }

        var tailStart = @this.Length;
        var tailLineCount = 0;
        while (tailLineCount < tailLines && tailStart > headEnd)
        {
            tailStart = headEnd + FindStartOfLastLine(@this[headEnd..tailStart]);
            tailLineCount++;
        }

        var omittedLines = @this[headEnd..tailStart];
        var omittedLineCount = 0;
        while (!omittedLines.IsEmpty)
        {
            omittedLines = omittedLines[FindEndOfFirstLine(omittedLines)..];
            omittedLineCount++;
        }

        // A caller shows one line in place of the omitted lines, so omitting a single line gains nothing.
        if (omittedLineCount <= 1)
        {
            var lineCount = headLineCount + omittedLineCount + tailLineCount;
            return new(new(0, @this.Length), new(@this.Length, @this.Length), lineCount, 0, 0);
        }

        return new(new(0, headEnd), new(tailStart, @this.Length), headLineCount, tailLineCount, omittedLineCount);
    }
}
