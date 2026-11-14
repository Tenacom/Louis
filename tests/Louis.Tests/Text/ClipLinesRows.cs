// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Text;
using ClipLinesRow = (
    string Input,
    int HeadLines,
    int TailLines,
    (string Head, string Tail, int HeadLineCount, int TailLineCount, int OmittedLineCount) Expected);

/// <summary>
/// Holds the inputs that drive the tests of the <c>ClipLines</c> methods of <see cref="StringExtensions"/>
/// and <see cref="CharReadOnlySpanExtensions"/>. The expected values of each row are the text of the head,
/// which is at the start of the input, the text of the tail, which is at the end of the input, and the three line counts.
/// The expected values are a tuple of their own, because the test framework does not unpack a row of eight values
/// on .NET Framework.
/// </summary>
internal static class ClipLinesRows
{
    public static IEnumerable<ClipLinesRow> All() => [
        // An empty text has no lines.
        (string.Empty, 2, 2, (string.Empty, string.Empty, 0, 0, 0)),

        // A line terminator at the end of the text starts no line.
        ("a", 2, 2, ("a", string.Empty, 1, 0, 0)),
        ("a\n", 2, 2, ("a\n", string.Empty, 1, 0, 0)),
        ("\n", 2, 2, ("\n", string.Empty, 1, 0, 0)),

        // A text of at most headLines + tailLines + 1 lines is not clipped: the head holds all of its lines.
        ("a\nb\nc", 2, 2, ("a\nb\nc", string.Empty, 3, 0, 0)),
        ("a\nb\nc\nd", 2, 2, ("a\nb\nc\nd", string.Empty, 4, 0, 0)),
        ("a\nb\nc\nd\ne", 2, 2, ("a\nb\nc\nd\ne", string.Empty, 5, 0, 0)),
        ("a\nb\nc\nd\ne\n", 2, 2, ("a\nb\nc\nd\ne\n", string.Empty, 5, 0, 0)),
        ("a", 0, 0, ("a", string.Empty, 1, 0, 0)),
        ("a\nb\nc", 0, 2, ("a\nb\nc", string.Empty, 3, 0, 0)),
        ("a\nb\nc", 2, 0, ("a\nb\nc", string.Empty, 3, 0, 0)),

        // A text of more lines is clipped.
        ("a\nb\nc\nd\ne\nf", 2, 2, ("a\nb\n", "e\nf", 2, 2, 2)),
        ("a\nb\nc\nd\ne\nf\n", 2, 2, ("a\nb\n", "e\nf\n", 2, 2, 2)),
        ("a\nb\nc\nd\ne\nf\ng", 1, 2, ("a\n", "f\ng", 1, 2, 4)),

        // A head or a tail of no lines is an empty range, at the start or at the end of the text.
        ("a\nb\nc\nd", 0, 2, (string.Empty, "c\nd", 0, 2, 2)),
        ("a\nb\nc\nd", 2, 0, ("a\nb\n", string.Empty, 2, 0, 2)),
        ("a\nb", 0, 0, (string.Empty, string.Empty, 0, 0, 2)),

        // A head and a tail of int.MaxValue lines do not overflow.
        ("a\nb\nc", int.MaxValue, int.MaxValue, ("a\nb\nc", string.Empty, 3, 0, 0)),
        ("a\nb\nc", 0, int.MaxValue, ("a\nb\nc", string.Empty, 3, 0, 0)),

        // A line ends at '\r', at '\n', or at "\r\n".
        ("a\rb\rc\rd\re", 1, 1, ("a\r", "e", 1, 1, 3)),
        ("a\r\nb\r\nc\r\nd\r\n", 1, 1, ("a\r\n", "d\r\n", 1, 1, 2)),
        ("a\nb\r\nc\rd", 1, 1, ("a\n", "d", 1, 1, 2)),

        // "\n\r" is two line terminators, and "\r\r\n" is a '\r' followed by a "\r\n".
        ("a\n\rb", 0, 1, (string.Empty, "b", 0, 1, 2)),
        ("a\r\r\nb", 0, 1, (string.Empty, "b", 0, 1, 2)),
        ("a\nb\n\rc", 0, 2, (string.Empty, "\rc", 0, 2, 2)),
        ("a\rb\r\r\nc", 0, 2, (string.Empty, "\r\nc", 0, 2, 2)),

        // An empty line is a line.
        ("\n\n\n\n", 1, 1, ("\n", "\n", 1, 1, 2)),
        ("\r\n\r\n\r\n\r\n", 1, 1, ("\r\n", "\r\n", 1, 1, 2)),
        ("a\n\n\n", 0, 1, (string.Empty, "\n", 0, 1, 2)),
    ];
}
