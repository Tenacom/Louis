// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

namespace Louis.Text;

partial class StringExtensions
{
    /// <summary>
    /// Finds the first and the last lines of a string, and counts the lines between them.
    /// </summary>
    /// <param name="this">The <see langword="string"/> on which this method is called.
    /// A <see langword="null"/> string has no lines, as an empty string.</param>
    /// <param name="headLines">The number of lines to keep at the start of the string, when the string is clipped.</param>
    /// <param name="tailLines">The number of lines to keep at the end of the string, when the string is clipped.</param>
    /// <returns>A <see cref="ClippedLines"/> value, whose ranges refer to <paramref name="this"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para><paramref name="headLines"/> is less than 0.</para>
    /// <para>- or -</para>
    /// <para><paramref name="tailLines"/> is less than 0.</para>
    /// </exception>
    /// <remarks>
    /// <para>A line ends at a line feed (<c>\n</c>), at a carriage return (<c>\r</c>), at a carriage return
    /// immediately followed by a line feed (<c>\r\n</c>), or at the end of the string,
    /// as in <see cref="System.IO.TextReader.ReadLine"/>.
    /// A line terminator at the end of the string starts no line, and an empty string has no lines.</para>
    /// <para>A string of more than <paramref name="headLines"/> + <paramref name="tailLines"/> + 1 lines is clipped:
    /// <see cref="ClippedLines.Head"/> holds its first <paramref name="headLines"/> lines,
    /// and <see cref="ClippedLines.Tail"/> its last <paramref name="tailLines"/> lines.</para>
    /// <para>A string of at most that many lines is not clipped: <see cref="ClippedLines.Head"/> holds all of its lines,
    /// and <see cref="ClippedLines.Tail"/> is empty. No string is clipped by a single line,
    /// because a caller usually shows one line in place of the omitted lines.</para>
    /// <para>This method copies no characters and allocates no memory.</para>
    /// </remarks>
    /// <seealso cref="CharReadOnlySpanExtensions.ClipLines"/>
    public static ClippedLines ClipLines(this string? @this, int headLines, int tailLines)
        => @this.AsSpan().ClipLines(headLines, tailLines);
}
