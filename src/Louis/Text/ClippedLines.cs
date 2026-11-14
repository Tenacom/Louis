// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

namespace Louis.Text;

/// <summary>
/// Describes the first and the last lines of a text, as the <c>ClipLines</c> methods find them,
/// with the number of lines between them.
/// </summary>
/// <remarks>
/// <para><see cref="Head"/> and <see cref="Tail"/> are ranges of the text that <c>ClipLines</c> was called on.
/// Each range includes the line terminators of its lines, as they appear in the text.</para>
/// <para>When <see cref="OmittedLineCount"/> is 0, the text is not clipped: <see cref="Head"/> covers the whole text,
/// and <see cref="Tail"/> is an empty range at the end of the text.
/// <see cref="OmittedLineCount"/> is never 1, because <c>ClipLines</c> does not clip a text by a single line.</para>
/// <para>The default value describes an empty text.</para>
/// </remarks>
/// <seealso cref="StringExtensions.ClipLines"/>
/// <seealso cref="CharReadOnlySpanExtensions.ClipLines"/>
public readonly struct ClippedLines : IEquatable<ClippedLines>
{
    internal ClippedLines(Range head, Range tail, int headLineCount, int tailLineCount, int omittedLineCount)
    {
        Head = head;
        Tail = tail;
        HeadLineCount = headLineCount;
        TailLineCount = tailLineCount;
        OmittedLineCount = omittedLineCount;
    }

    /// <summary>
    /// Gets the range of the first lines of the text.
    /// </summary>
    /// <value>
    /// A range that starts at the start of the text and holds <see cref="HeadLineCount"/> lines.
    /// Both of its indexes count from the start of the text.
    /// </value>
    public Range Head { get; }

    /// <summary>
    /// Gets the range of the last lines of the text.
    /// </summary>
    /// <value>
    /// A range that ends at the end of the text and holds <see cref="TailLineCount"/> lines.
    /// Both of its indexes count from the start of the text.
    /// </value>
    public Range Tail { get; }

    /// <summary>
    /// Gets the number of lines in <see cref="Head"/>.
    /// </summary>
    /// <value>
    /// The <c>headLines</c> parameter of <c>ClipLines</c> when the text is clipped;
    /// otherwise, the number of lines of the text.
    /// </value>
    public int HeadLineCount { get; }

    /// <summary>
    /// Gets the number of lines in <see cref="Tail"/>.
    /// </summary>
    /// <value>
    /// The <c>tailLines</c> parameter of <c>ClipLines</c> when the text is clipped;
    /// otherwise, 0.
    /// </value>
    public int TailLineCount { get; }

    /// <summary>
    /// Gets the number of lines of the text that are neither in <see cref="Head"/> nor in <see cref="Tail"/>.
    /// </summary>
    /// <value>
    /// The number of lines between the end of <see cref="Head"/> and the start of <see cref="Tail"/>,
    /// which is 0 when the text is not clipped, and at least 2 when it is.
    /// </value>
    public int OmittedLineCount { get; }

    /// <summary>
    /// Determines whether two specified <see cref="ClippedLines"/> values are equal.
    /// </summary>
    /// <param name="a">The first value to compare.</param>
    /// <param name="b">The second value to compare.</param>
    /// <returns><see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> have the same ranges and the same line counts;
    /// otherwise, <see langword="false"/>.</returns>
    public static bool operator ==(ClippedLines a, ClippedLines b) => a.Equals(b);

    /// <summary>
    /// Determines whether two specified <see cref="ClippedLines"/> values are different.
    /// </summary>
    /// <param name="a">The first value to compare.</param>
    /// <param name="b">The second value to compare.</param>
    /// <returns><see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> differ in a range or in a line count;
    /// otherwise, <see langword="false"/>.</returns>
    public static bool operator !=(ClippedLines a, ClippedLines b) => !a.Equals(b);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ClippedLines other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ClippedLines other)
        => (Head, Tail, HeadLineCount, TailLineCount, OmittedLineCount)
            .Equals((other.Head, other.Tail, other.HeadLineCount, other.TailLineCount, other.OmittedLineCount));

    /// <inheritdoc/>
    public override int GetHashCode() => (Head, Tail, HeadLineCount, TailLineCount, OmittedLineCount).GetHashCode();
}
