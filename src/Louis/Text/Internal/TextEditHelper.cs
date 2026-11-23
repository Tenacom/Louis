// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Louis.Diagnostics;

namespace Louis.Text.Internal;

internal static class TextEditHelper
{
    // Returns the edits in the order Apply takes them, after checking them against a text of the given length.
    // The order is by start. At one start, the insertions come first, so that an inserted text precedes
    // the text that replaces the characters after it. OrderBy and ThenBy keep the order of the insertions at one start.
    public static TextEdit[] SortAndCheck(
        IEnumerable<TextEdit> edits,
        int textLength,
        [CallerArgumentExpression(nameof(edits))] string name = "")
    {
        TextEdit[] sortedEdits = [.. edits.OrderBy(static edit => edit.Start).ThenBy(static edit => edit.Length == 0 ? 0 : 1)];
        var previousEnd = 0;
        foreach (var edit in sortedEdits)
        {
            // The subtraction cannot overflow, because the pattern leaves a start that is not negative.
            var isInsideText = edit is { Start: >= 0, Length: >= 0 } && edit.Length <= textLength - edit.Start;
            if (!isInsideText)
            {
                ArgumentOutOfRangeException.ThrowNew(
                    name,
                    FormattableString.Invariant(
                        $"The edit of {edit.Length} characters at index {edit.Start} is outside a text of {textLength} characters."));
            }

            if (edit.Start < previousEnd)
            {
                ArgumentException.ThrowNew(
                    FormattableString.Invariant(
                        $"The edit of {edit.Length} characters at index {edit.Start} overlaps an edit that ends at index {previousEnd}."),
                    name);
            }

            previousEnd = edit.Start + edit.Length;
        }

        return sortedEdits;
    }

    // Applies the edits that SortAndCheck returned for a text of the same length.
    public static string Apply(ReadOnlySpan<char> text, TextEdit[] sortedEdits)
    {
        var resultLength = text.Length;
        foreach (var edit in sortedEdits)
        {
            resultLength = checked(resultLength + edit.Text.Length - edit.Length);
        }

        var result = new char[resultLength];
        var destination = result.AsSpan();
        var position = 0;
        foreach (var edit in sortedEdits)
        {
            destination = CopyAndAdvance(text[position..edit.Start], destination);
            destination = CopyAndAdvance(edit.Text.AsSpan(), destination);
            position = edit.Start + edit.Length;
        }

        text[position..].CopyTo(destination);
        return new(result);
    }

    // Copies the source to the start of the destination, and returns the rest of the destination.
    private static Span<char> CopyAndAdvance(ReadOnlySpan<char> source, Span<char> destination)
    {
        source.CopyTo(destination);
        return destination[source.Length..];
    }
}
