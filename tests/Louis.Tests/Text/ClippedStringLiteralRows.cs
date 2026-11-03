// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Text;
using ClippedCase = (string Input, int HeadLength, int TailLength, bool UseUnicodeEllipsis, string Expected);
using ClippedLiteralCase = (
    string Input,
    Louis.Text.StringLiteralKind LiteralKind,
    int HeadLength,
    int TailLength,
    bool UseUnicodeEllipsis,
    string Expected);
using ClippedRow = (string Input, int HeadLength, int TailLength, bool UseUnicodeEllipsis, string QuotedBody, string VerbatimBody);

/// <summary>
/// Holds the inputs that drive the tests of the clipped literal methods of <see cref="StringExtensions"/>,
/// <see cref="CharReadOnlySpanExtensions"/>, and <see cref="StringBuilderExtensions"/>,
/// with the content of the quoted and verbatim literal of each. The accessors add the delimiters.
/// A string is clipped when it is longer than the sum of the head length, the tail length,
/// and the length of the ellipsis, which is 3 for <c>...</c> and 1 for <c>…</c>.
/// </summary>
internal static class ClippedStringLiteralRows
{
    private static readonly ClippedRow[] Rows =
    [
        // "abcdefghij" has 10 characters.
        ("abcdefghij", 3, 4, false, "abcdefghij", "abcdefghij"),
        ("abcdefghij", 3, 3, false, "abc...hij", "abc...hij"),
        ("abcdefghij", 4, 5, true, "abcdefghij", "abcdefghij"),
        ("abcdefghij", 4, 4, true, "abcd…ghij", "abcd…ghij"),
        ("abcdefghij", 0, 3, false, "...hij", "...hij"),
        ("abcdefghij", 3, 0, false, "abc...", "abc..."),
        ("abcdefghij", 0, 0, false, "...", "..."),
        ("abcdefghij", 0, 0, true, "…", "…"),

        // A head and tail whose sum reaches int.MaxValue leave the string whole.
        ("abcdefghij", int.MaxValue, 0, false, "abcdefghij", "abcdefghij"),
        ("abcdefghij", int.MaxValue, int.MaxValue, false, "abcdefghij", "abcdefghij"),

        // The head and the tail are escaped after clipping.
        ("\"abcdefgh\"", 1, 1, false, "\\\"...\\\"", "\"\"...\"\""),
        ("\tabcdefgh\n", 1, 1, true, "\\t…\\n", "\t…\n"),
    ];

    public static IEnumerable<ClippedCase> Quoted()
        => Rows.Select(r => (r.Input, r.HeadLength, r.TailLength, r.UseUnicodeEllipsis, AsQuoted(r.QuotedBody)));

    public static IEnumerable<ClippedCase> Verbatim()
        => Rows.Select(r => (r.Input, r.HeadLength, r.TailLength, r.UseUnicodeEllipsis, AsVerbatim(r.VerbatimBody)));

    public static IEnumerable<ClippedLiteralCase> Literal()
    {
        foreach (var (input, headLength, tailLength, useUnicodeEllipsis, quotedBody, verbatimBody) in Rows)
        {
            yield return (input, StringLiteralKind.Quoted, headLength, tailLength, useUnicodeEllipsis, AsQuoted(quotedBody));
            yield return (input, StringLiteralKind.Verbatim, headLength, tailLength, useUnicodeEllipsis, AsVerbatim(verbatimBody));
        }
    }

    private static string AsQuoted(string body) => "\"" + body + "\"";

    private static string AsVerbatim(string body) => "@\"" + body + "\"";
}
