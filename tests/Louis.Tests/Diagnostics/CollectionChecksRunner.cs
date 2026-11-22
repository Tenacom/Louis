// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

/// <summary>
/// Runs the chain checks for one type of collection, for <see cref="ParamCollectionChecksTests"/>.
/// </summary>
/// <remarks>
/// Each method runs one check. A method whose name ends with <c>Other</c> runs the form of the check
/// that takes another collection. The collection to check has <c>count</c> items, and its parameter is named <c>items</c>.
/// The index to check is in a parameter named <c>index</c>.
/// </remarks>
internal abstract class CollectionChecksRunner
{
    /// <summary>
    /// Returns the runner of the checks for a type of collection.
    /// </summary>
    public static CollectionChecksRunner For(CollectionKind kind)
        => kind switch {
            CollectionKind.Array => new ArrayChecksRunner(),
            CollectionKind.List => new ListChecksRunner(),
            CollectionKind.IList => new ListInterfaceChecksRunner(),
            CollectionKind.IReadOnlyList => new ReadOnlyListInterfaceChecksRunner(),
            CollectionKind.ICollection => new CollectionInterfaceChecksRunner(),
            CollectionKind.IReadOnlyCollection => new ReadOnlyCollectionInterfaceChecksRunner(),
            CollectionKind.Memory => new MemoryChecksRunner(),
            CollectionKind.ReadOnlyMemory => new ReadOnlyMemoryChecksRunner(),
            CollectionKind.ReadOnlySpan => new ReadOnlySpanChecksRunner(),
            CollectionKind.Span => new SpanChecksRunner(),
            _ => throw new ArgumentOutOfRangeException(nameof(kind), kind, "The value is not a kind of collection."),
        };

    /// <summary>
    /// Returns the text that the format item <c>{1}</c> of a message gives for the collection to check.
    /// </summary>
    public abstract string GetValueText(int count);

    public abstract CheckOutcome Empty(int count, string? message);

    public abstract CheckOutcome NotEmpty(int count, string? message);

    public abstract CheckOutcome HasSizeEqualTo(int count, int size, string? message);

    public abstract CheckOutcome HasSizeEqualToOther(int count, int otherCount, string? message);

    public abstract CheckOutcome HasSizeNotEqualTo(int count, int size, string? message);

    public abstract CheckOutcome HasSizeGreaterThan(int count, int size, string? message);

    public abstract CheckOutcome HasSizeGreaterThanOrEqualTo(int count, int size, string? message);

    public abstract CheckOutcome HasSizeLessThan(int count, int size, string? message);

    public abstract CheckOutcome HasSizeLessThanOrEqualTo(int count, int size, string? message);

    public abstract CheckOutcome HasSizeLessThanOrEqualToOther(int count, int otherCount, string? message);

    public abstract Param<int> InRangeFor(int index, int count, string? message);

    public abstract Param<int> NotInRangeFor(int index, int count, string? message);
}
