// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Text;
using AppliedRow = (string Input, Louis.Text.TextEdit[] Edits, string Expected);
using RejectedRow = (string Input, Louis.Text.TextEdit[] Edits);

/// <summary>
/// Holds the inputs that drive the tests of the <c>ApplyEdits</c> methods of <see cref="StringExtensions"/>
/// and <see cref="CharReadOnlySpanExtensions"/>. Each row is a function, because the test framework wants
/// a new array of edits for each test.
/// </summary>
internal static class TextEditRows
{
    public static IEnumerable<Func<AppliedRow>> Applied() => [
        // No edit leaves the text as it is.
        () => (string.Empty, [], string.Empty),
        () => ("abc", [], "abc"),
        () => ("abc", [default], "abc"),

        // One edit replaces its characters with a text of any length.
        () => ("abcdef", [new(2, 2, "XY")], "abXYef"),
        () => ("abcdef", [new(2, 2, "WXYZ")], "abWXYZef"),
        () => ("abcdef", [new(2, 2, "X")], "abXef"),
        () => ("abcdef", [new(0, 2, "X")], "Xcdef"),
        () => ("abcdef", [new(4, 2, "X")], "abcdX"),
        () => ("abc", [new(0, 3, "xyz")], "xyz"),
        () => ("abc", [new(1, 1, "b")], "abc"),

        // An insertion replaces no character.
        () => ("abc", [new(0, 0, "X")], "Xabc"),
        () => ("abc", [new(1, 0, "X")], "aXbc"),
        () => ("abc", [new(3, 0, "X")], "abcX"),
        () => (string.Empty, [new(0, 0, "X")], "X"),

        // A deletion has an empty text.
        () => ("abcdef", [new(1, 3, string.Empty)], "aef"),
        () => ("abc", [new(0, 3, string.Empty)], string.Empty),

        // Several edits give the same result in any order.
        () => ("0123456789", [new(1, 1, "a"), new(4, 2, "bcd"), new(8, 1, string.Empty)], "0a23bcd679"),
        () => ("0123456789", [new(8, 1, string.Empty), new(4, 2, "bcd"), new(1, 1, "a")], "0a23bcd679"),
        () => ("0123456789", [new(4, 2, "bcd"), new(8, 1, string.Empty), new(1, 1, "a")], "0a23bcd679"),

        // An edit may start where another one ends.
        () => ("abcdef", [new(0, 2, "X"), new(2, 2, "Y"), new(4, 2, "Z")], "XYZ"),
        () => ("abcdef", [new(4, 2, "Z"), new(0, 2, "X"), new(2, 2, "Y")], "XYZ"),

        // The texts of two insertions at one index keep the order of the edits.
        () => ("abc", [new(1, 0, "X"), new(1, 0, "Y")], "aXYbc"),
        () => ("abc", [new(1, 0, "Y"), new(1, 0, "X")], "aYXbc"),
        () => ("abc", [new(3, 0, "X"), new(0, 0, "W"), new(3, 0, "Y")], "WabcXY"),

        // An insertion at the first character that another edit replaces precedes the replacing text.
        () => ("abcdef", [new(2, 0, "X"), new(2, 2, "Y")], "abXYef"),
        () => ("abcdef", [new(2, 2, "Y"), new(2, 0, "X")], "abXYef"),
        () => ("abcdef", [new(2, 0, "X"), new(2, 2, "Y"), new(2, 0, "Z")], "abXZYef"),
        () => ("abcdef", [new(2, 2, string.Empty), new(2, 0, "X")], "abXef"),

        // An insertion just after the last character that another edit replaces follows the replacing text.
        () => ("abcdef", [new(4, 0, "X"), new(2, 2, "Y")], "abYXef"),
        () => ("abcdef", [new(2, 2, "Y"), new(4, 0, "X")], "abYXef"),
    ];

    public static IEnumerable<Func<RejectedRow>> Overlapping() => [
        // Two edits replace one character.
        () => ("abcdef", [new(1, 3, "X"), new(3, 2, "Y")]),
        () => ("abcdef", [new(3, 2, "Y"), new(1, 3, "X")]),
        () => ("abcdef", [new(1, 2, "X"), new(1, 2, "Y")]),
        () => ("abcdef", [new(1, 1, "X"), new(1, 2, "Y")]),
        () => ("abcdef", [new(0, 6, "X"), new(2, 1, "Y")]),
        () => ("abcdef", [new(1, 2, string.Empty), new(1, 2, string.Empty)]),

        // An insertion falls between two characters that another edit replaces.
        () => ("abcdef", [new(1, 3, "X"), new(2, 0, "Y")]),
        () => ("abcdef", [new(2, 0, "Y"), new(1, 3, "X")]),

        // The overlapping edits are not the first two by start.
        () => ("abcdef", [new(0, 1, "X"), new(2, 2, "Y"), new(3, 2, "Z")]),
    ];

    public static IEnumerable<Func<RejectedRow>> OutsideText() => [
        () => ("abc", [new(-1, 0, "X")]),
        () => ("abc", [new(-1, 2, "X")]),
        () => ("abc", [new(int.MinValue, 0, "X")]),
        () => ("abc", [new(0, -1, "X")]),
        () => ("abc", [new(4, 0, "X")]),
        () => ("abc", [new(int.MaxValue, 1, "X")]),
        () => ("abc", [new(2, 2, "X")]),
        () => ("abc", [new(3, 1, "X")]),
        () => ("abc", [new(1, int.MaxValue, "X")]),
        () => (string.Empty, [new(0, 1, "X")]),

        // An edit outside the text follows edits inside it.
        () => ("abc", [new(0, 1, "X"), new(1, 1, "Y"), new(2, 2, "Z")]),
    ];
}
