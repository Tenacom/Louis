// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Text;
using Louis.IO;

/// <summary>
/// Holds the inputs that drive the tests of <see cref="TextFileUtility"/>. Each encoding is a function,
/// because the test framework wants a new instance for each test.
/// </summary>
internal static class TextFileSamples
{
    // A text with characters that take one, two, and three bytes in UTF-8.
    public const string Text = "Perché no? 100 €";

    private const char ReplacementCharacter = (char)0xFFFD;

    // The bytes of "a", then a byte that is not valid in UTF-8, then the bytes of "b".
    public static byte[] InvalidUtf8 => [(byte)'a', 0xFF, (byte)'b'];

    // The text that InvalidUtf8 gives through an encoding that replaces invalid bytes.
    public static string InvalidUtf8Replaced => $"a{ReplacementCharacter}b";

    // The encodings whose byte order mark a read recognizes.
    public static IEnumerable<Func<Encoding>> EncodingsWithByteOrderMark() => [
        () => new UTF8Encoding(encoderShouldEmitUTF8Identifier: true),
        () => new UnicodeEncoding(bigEndian: false, byteOrderMark: true),
        () => new UnicodeEncoding(bigEndian: true, byteOrderMark: true),
        () => new UTF32Encoding(bigEndian: false, byteOrderMark: true),
        () => new UTF32Encoding(bigEndian: true, byteOrderMark: true),
    ];

    // The encodings above, and the default fallback encoding of a read.
    public static IEnumerable<Func<Encoding>> Encodings() => [
        .. EncodingsWithByteOrderMark(),
        () => new UTF8Encoding(encoderShouldEmitUTF8Identifier: false),
    ];

    // The bytes of a file that holds a text in an encoding, after the byte order mark of the encoding, if any.
    public static byte[] GetBytes(string text, Encoding encoding)
        => [.. encoding.GetPreamble(), .. encoding.GetBytes(text)];
}
