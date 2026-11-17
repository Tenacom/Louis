// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

namespace Louis.Text;

/// <summary>
/// Describes the replacement of a range of characters of a text with another text,
/// as the <c>ApplyEdits</c> methods apply it.
/// </summary>
/// <remarks>
/// <para>An edit whose <see cref="Length"/> is 0 is an insertion: it puts <see cref="Text"/>
/// before the character at <see cref="Start"/>, or at the end of the text when <see cref="Start"/> is the length of the text.
/// An edit whose <see cref="Text"/> is empty is a deletion.</para>
/// <para>A <see cref="TextEdit"/> accepts any value of <see cref="Start"/> and <see cref="Length"/>.
/// The <c>ApplyEdits</c> methods check both against the text they are called on.</para>
/// <para>The default value is the insertion of an empty text at index 0, which changes no text.</para>
/// </remarks>
/// <seealso cref="StringExtensions.ApplyEdits"/>
/// <seealso cref="CharReadOnlySpanExtensions.ApplyEdits"/>
public readonly struct TextEdit : IEquatable<TextEdit>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TextEdit"/> struct.
    /// </summary>
    /// <param name="start">The index, in the text, of the first character to replace.</param>
    /// <param name="length">The number of characters to replace.</param>
    /// <param name="text">The text that replaces the characters.</param>
    public TextEdit(int start, int length, string text)
    {
        Start = start;
        Length = length;
        Text = text;
    }

    /// <summary>
    /// Gets the index of the first character to replace.
    /// </summary>
    /// <value>
    /// An index in the text before any edit is applied to it.
    /// </value>
    public int Start { get; init; }

    /// <summary>
    /// Gets the number of characters to replace.
    /// </summary>
    /// <value>
    /// The number of characters to replace, which is 0 for an insertion.
    /// </value>
    public int Length { get; init; }

    /// <summary>
    /// Gets the text that replaces the characters.
    /// </summary>
    /// <value>
    /// The text that replaces the characters, which is empty for a deletion.
    /// This property never returns <see langword="null"/>: the default value has an empty text.
    /// </value>
    public string Text
    {
        get => field ?? string.Empty;
        init;
    }

    /// <summary>
    /// Determines whether two specified <see cref="TextEdit"/> values are equal.
    /// </summary>
    /// <param name="a">The first value to compare.</param>
    /// <param name="b">The second value to compare.</param>
    /// <returns><see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> have the same <see cref="Start"/>,
    /// the same <see cref="Length"/>, and the same <see cref="Text"/>; otherwise, <see langword="false"/>.</returns>
    public static bool operator ==(TextEdit a, TextEdit b) => a.Equals(b);

    /// <summary>
    /// Determines whether two specified <see cref="TextEdit"/> values are different.
    /// </summary>
    /// <param name="a">The first value to compare.</param>
    /// <param name="b">The second value to compare.</param>
    /// <returns><see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> differ in <see cref="Start"/>,
    /// in <see cref="Length"/>, or in <see cref="Text"/>; otherwise, <see langword="false"/>.</returns>
    public static bool operator !=(TextEdit a, TextEdit b) => !a.Equals(b);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TextEdit other && Equals(other);

    /// <summary>
    /// Determines whether this edit and a specified edit are equal.
    /// </summary>
    /// <param name="other">The edit to compare with this edit.</param>
    /// <returns><see langword="true"/> if the two edits have the same <see cref="Start"/>, the same <see cref="Length"/>,
    /// and the same <see cref="Text"/>, compared by ordinal; otherwise, <see langword="false"/>.</returns>
    public bool Equals(TextEdit other) => (Start, Length, Text).Equals((other.Start, other.Length, other.Text));

    /// <inheritdoc/>
    public override int GetHashCode() => (Start, Length, Text).GetHashCode();
}
