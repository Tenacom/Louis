// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Text;
using Louis.Text;

internal sealed class CharReadOnlySpanExtensionsApplyEditsTests
{
    [Test]
    [MethodDataSource(typeof(TextEditRows), nameof(TextEditRows.Applied))]
    public async Task ApplyEdits_ReturnsTheEditedText(string input, TextEdit[] edits, string expected)
    {
        await Assert.That(input.AsSpan().ApplyEdits(edits)).IsEqualTo(expected);
    }

    [Test]
    public async Task ApplyEdits_OnEveryTripleOfEdits_AgreesWithAModelOfTheRules()
    {
        const string Text = "abc";
        var failures = new List<string>();
        foreach (var first in BuildEdits(Text.Length, "X"))
        {
            foreach (var second in BuildEdits(Text.Length, "Y"))
            {
                foreach (var third in BuildEdits(Text.Length, "Z"))
                {
                    TextEdit[] edits = [first, second, third];
                    var expected = ApplyByTheRules(Text, edits);
                    var actual = ApplyOrNull(Text, edits);
                    if (actual != expected)
                    {
                        var description = string.Join(", ", edits.Select(static edit => (edit.Start, edit.Length, edit.Text)));
                        failures.Add($"{description}: expected {expected.ToQuotedLiteral()}, got {actual.ToQuotedLiteral()}");
                    }
                }
            }
        }

        await Assert.That(failures).IsEmpty();
    }

    [Test]
    [MethodDataSource(typeof(TextEditRows), nameof(TextEditRows.Overlapping))]
    public async Task ApplyEdits_WithOverlappingEdits_ThrowsArgumentException(string input, TextEdit[] edits)
    {
        void Act() => input.AsSpan().ApplyEdits(edits);

        await Assert.That(Act).ThrowsExactly<ArgumentException>().WithParameterName("edits");
    }

    [Test]
    [MethodDataSource(typeof(TextEditRows), nameof(TextEditRows.OutsideText))]
    public async Task ApplyEdits_WithEditOutsideText_ThrowsArgumentOutOfRangeException(string input, TextEdit[] edits)
    {
        void Act() => input.AsSpan().ApplyEdits(edits);

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName("edits");
    }

    [Test]
    public async Task ApplyEdits_WithNullEdits_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            "abc".AsSpan().ApplyEdits(null!);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("edits");
    }

    // Returns every edit inside a text of the given length, once as a deletion or an empty insertion,
    // and once with the given text.
    private static List<TextEdit> BuildEdits(int textLength, string text)
    {
        var edits = new List<TextEdit>();
        for (var start = 0; start <= textLength; start++)
        {
            for (var length = 0; length <= textLength - start; length++)
            {
                edits.AddRange([new(start, length, string.Empty), new(start, length, text)]);
            }
        }

        return edits;
    }

    private static string? ApplyOrNull(string text, TextEdit[] edits)
    {
        try
        {
            return text.AsSpan().ApplyEdits(edits);
        }
        catch (ArgumentException)
        {
            return null;
        }
    }

    // Returns the text after the edits, or null when two edits overlap.
    // The method states the rules of ApplyEdits one character at a time, with no sorting.
    private static string? ApplyByTheRules(string text, TextEdit[] edits)
    {
        for (var i = 0; i < edits.Length; i++)
        {
            for (var j = i + 1; j < edits.Length; j++)
            {
                if (Overlap(edits[i], edits[j]))
                {
                    return null;
                }
            }
        }

        var result = new StringBuilder();
        var nextPosition = 0;
        while (nextPosition <= text.Length)
        {
            var position = nextPosition;
            foreach (var insertion in edits.Where(edit => edit.Length == 0 && edit.Start == position))
            {
                _ = result.Append(insertion.Text);
            }

            // At most one edit replaces the character at a position, because no two edits overlap.
            if (edits.Where(edit => edit.Length > 0 && edit.Start == position).ToArray() is [var replacement])
            {
                _ = result.Append(replacement.Text);
                nextPosition = position + replacement.Length;
            }
            else
            {
                if (position < text.Length)
                {
                    _ = result.Append(text[position]);
                }

                nextPosition = position + 1;
            }
        }

        return result.ToString();
    }

    // Two insertions never overlap, and IsBetweenReplacedCharacters is false for them, because neither replaces a character.
    private static bool Overlap(TextEdit a, TextEdit b)
        => a.Length == 0 ? IsBetweenReplacedCharacters(a.Start, b)
            : b.Length == 0 ? IsBetweenReplacedCharacters(b.Start, a)
            : a.Start < b.Start + b.Length && b.Start < a.Start + a.Length;

    private static bool IsBetweenReplacedCharacters(int index, TextEdit edit)
        => index > edit.Start && index < edit.Start + edit.Length;
}
