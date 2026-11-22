// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

namespace Louis;

/// <summary>
/// Represents the method that defines a set of criteria and determines whether a read-only span meets those criteria.
/// </summary>
/// <typeparam name="T">The type of the items of the span.</typeparam>
/// <param name="span">The read-only span to compare against the criteria.</param>
/// <returns><see langword="true"/> if <paramref name="span"/> meets the criteria; otherwise, <see langword="false"/>.</returns>
public delegate bool ReadOnlySpanPredicate<T>(ReadOnlySpan<T> span);
