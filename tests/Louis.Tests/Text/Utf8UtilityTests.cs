// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Text;

internal sealed class Utf8UtilityTests
{
    // The surrogate pair of U+1F600
    private const string HighSurrogate = "\uD83D";
    private const string LowSurrogate = "\uDE00";

    // The surrogate pair of U+10FFFF, the last code point
    private const string LastHighSurrogate = "\uDBFF";
    private const string LastLowSurrogate = "\uDFFF";

    // U+E000, the first character after the surrogate range
    private const string FirstCharAfterSurrogates = "\xE000";

    public static IEnumerable<(string Input, int MaxBytes, int Expected)> MaxCharsRows()
        =>
        [
            // No bytes available, or nothing to encode
            ("abc", 0, 0),
            (string.Empty, 5, 0),

            // One-byte characters: an exact fit, one byte short, and one byte to spare
            ("abc", 3, 3),
            ("abc", 2, 2),
            ("abc", 4, 3),

            // Two-byte characters
            ("éé", 4, 2),
            ("éé", 3, 1),

            // Three-byte characters
            ("€€", 6, 2),
            ("€€", 5, 1),

            // A surrogate pair, taken as two characters or not at all
            (HighSurrogate + LowSurrogate, 4, 2),
            (HighSurrogate + LowSurrogate, 3, 0),

            // A high surrogate at the end, encoded as the three-byte replacement character
            ("a" + HighSurrogate, 4, 2),
            ("a" + HighSurrogate, 3, 1),

            // A high surrogate followed by anything but a low surrogate, encoded as the replacement character
            (HighSurrogate + "a", 4, 2),
            (HighSurrogate + "a", 3, 1),
            (HighSurrogate + "a", 2, 0),
            (HighSurrogate + "é", 2, 0),
            (HighSurrogate + "€", 2, 0),
            (HighSurrogate + FirstCharAfterSurrogates, 6, 2),
            (HighSurrogate + FirstCharAfterSurrogates, 5, 1),
            (HighSurrogate + HighSurrogate, 6, 2),
            (HighSurrogate + HighSurrogate, 2, 0),

            // A low surrogate without a high surrogate before it, encoded as the replacement character
            (LowSurrogate, 3, 1),
            (LowSurrogate, 2, 0),

            // The last code point, whose low surrogate is U+DFFF
            (LastHighSurrogate + LastLowSurrogate, 4, 2),
            (LastHighSurrogate + LastLowSurrogate, 3, 0),
        ];

    [Test]
    public async Task Utf8NoBomEncoding_IsUtf8WithoutPreamble()
    {
        await Assert.That(Utf8Utility.Utf8NoBomEncoding.WebName).IsEqualTo("utf-8");
        await Assert.That(Utf8Utility.Utf8NoBomEncoding.GetPreamble()).IsEmpty();
    }

    [Test]
    [MethodDataSource(nameof(MaxCharsRows))]
    public async Task GetMaxCharsInBytes_WithString_ReturnsCharsThatFit(string input, int maxBytes, int expected)
    {
        await Assert.That(Utf8Utility.GetMaxCharsInBytes(input, maxBytes)).IsEqualTo(expected);
    }

    [Test]
    [MethodDataSource(nameof(MaxCharsRows))]
    public async Task GetMaxCharsInBytes_WithSpan_ReturnsCharsThatFit(string input, int maxBytes, int expected)
    {
        await Assert.That(Utf8Utility.GetMaxCharsInBytes(input.AsSpan(), maxBytes)).IsEqualTo(expected);
    }

    [Test]
    public async Task GetMaxCharsInBytes_WithNullString_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => Utf8Utility.GetMaxCharsInBytes((string)null!, 10);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("str");
    }

    [Test]
    public async Task GetMaxCharsInBytes_WithStringAndNegativeMaxBytes_ThrowsArgumentOutOfRangeException()
    {
        static void Act() => Utf8Utility.GetMaxCharsInBytes("abc", -1);

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName("maxBytes");
    }

    [Test]
    public async Task GetMaxCharsInBytes_WithSpanAndNegativeMaxBytes_ThrowsArgumentOutOfRangeException()
    {
        static void Act() => Utf8Utility.GetMaxCharsInBytes("abc".AsSpan(), -1);

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName("maxBytes");
    }
}
