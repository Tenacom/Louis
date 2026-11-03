// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Text;
using LiteralRow = (string Input, string QuotedBody, string VerbatimBody);

/// <summary>
/// Holds the inputs that drive the tests of the literal methods of <see cref="StringExtensions"/>,
/// <see cref="CharReadOnlySpanExtensions"/>, and <see cref="StringBuilderExtensions"/>,
/// with the content of the quoted and verbatim literal of each. The accessors add the delimiters.
/// </summary>
internal static class StringLiteralRows
{
    private static readonly LiteralRow[] Rows =
    [
        (string.Empty, string.Empty, string.Empty),
        ("abc", "abc", "abc"),

        // The named escapes
        ("\0", "\\0", "\0"),
        ("\a", "\\a", "\a"),
        ("\b", "\\b", "\b"),
        ("\t", "\\t", "\t"),
        ("\n", "\\n", "\n"),
        ("\v", "\\v", "\v"),
        ("\f", "\\f", "\f"),
        ("\r", "\\r", "\r"),
        ("\"", "\\\"", "\"\""),
        ("\\", "\\\\", "\\"),

        // DEL and a C0 control character
        ("\x7F", "\\u007F", "\x7F"),
        ("\x1B", "\\u001B", "\x1B"),

        // A control character followed by a hex digit, which a \x escape would take as its own
        ("\x0001a", "\\u0001a", "\x0001a"),

        // Non-ASCII letters and symbols, kept as they are
        ("é", "é", "é"),
        ("€", "€", "€"),

        // A no-break space and a combining mark, escaped
        ("\xA0", "\\u00A0", "\xA0"),
        ("e\x0301", "e\\u0301", "e\x0301"),

        // A surrogate pair, escaped as two characters
        ("\U0001F600", "\\uD83D\\uDE00", "\U0001F600"),

        ("say \"hi\"\n", "say \\\"hi\\\"\\n", "say \"\"hi\"\"\n"),
    ];

    public static IEnumerable<(string Input, string Expected)> Quoted()
        => Rows.Select(r => (r.Input, AsQuoted(r.QuotedBody)));

    public static IEnumerable<(string Input, string Expected)> Verbatim()
        => Rows.Select(r => (r.Input, AsVerbatim(r.VerbatimBody)));

    public static IEnumerable<(string Input, StringLiteralKind LiteralKind, string Expected)> Literal()
    {
        foreach (var (input, quotedBody, verbatimBody) in Rows)
        {
            yield return (input, StringLiteralKind.Quoted, AsQuoted(quotedBody));
            yield return (input, StringLiteralKind.Verbatim, AsVerbatim(verbatimBody));
        }
    }

    private static string AsQuoted(string body) => "\"" + body + "\"";

    private static string AsVerbatim(string body) => "@\"" + body + "\"";
}
