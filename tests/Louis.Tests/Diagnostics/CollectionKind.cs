// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

/// <summary>
/// Names the types of collection that have chain checks.
/// </summary>
internal enum CollectionKind
{
    /// <summary>
    /// An array.
    /// </summary>
    Array,

    /// <summary>
    /// A <see cref="List{T}"/>.
    /// </summary>
    List,

    /// <summary>
    /// An <see cref="IList{T}"/>.
    /// </summary>
    IList,

    /// <summary>
    /// An <see cref="IReadOnlyList{T}"/>.
    /// </summary>
    IReadOnlyList,

    /// <summary>
    /// An <see cref="ICollection{T}"/>.
    /// </summary>
    ICollection,

    /// <summary>
    /// An <see cref="IReadOnlyCollection{T}"/>.
    /// </summary>
    IReadOnlyCollection,

    /// <summary>
    /// A <see cref="Memory{T}"/>.
    /// </summary>
    Memory,

    /// <summary>
    /// A <see cref="ReadOnlyMemory{T}"/>.
    /// </summary>
    ReadOnlyMemory,

    /// <summary>
    /// A <see cref="ReadOnlySpan{T}"/>.
    /// </summary>
    ReadOnlySpan,

    /// <summary>
    /// A <see cref="Span{T}"/>.
    /// </summary>
    Span,
}
