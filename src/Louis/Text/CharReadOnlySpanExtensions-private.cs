// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

namespace Louis.Text;

partial class CharReadOnlySpanExtensions
{
    // Returns the index just past the first line of a non-empty text, line terminator included.
    private static int FindEndOfFirstLine(ReadOnlySpan<char> text)
    {
        var terminatorIndex = text.IndexOfAny('\r', '\n');
        return terminatorIndex < 0 ? text.Length
            : text[terminatorIndex..] is ['\r', '\n', ..] ? terminatorIndex + 2
            : terminatorIndex + 1;
    }

    // Returns the index of the first character of the last line of a non-empty text.
    // The text must end where a line ends: at its line terminator, or at the end of the whole text.
    // A '\n' that follows a '\r' is always the second character of one line terminator,
    // so a backward scan finds the same lines as a forward scan.
    private static int FindStartOfLastLine(ReadOnlySpan<char> text)
    {
        var terminatorLength = text is [.., '\r', '\n'] ? 2
            : text is [.., '\r' or '\n'] ? 1
            : 0;

        return text[..^terminatorLength].LastIndexOfAny('\r', '\n') + 1;
    }
}
