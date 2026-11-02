// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET6_0_OR_GREATER

using System;

namespace Louis;

/// <summary>
/// <para>Provides utility methods to work with <see cref="DateOnly"/>.</para>
/// <para>This type is only available on .NET 6.0 and greater.</para>
/// </summary>
public static class DateOnlyUtility
{
    /// <summary>
    /// Gets a <see cref="DateOnly"/> instance whose value represents the current date.
    /// </summary>
    public static DateOnly Today => DateOnly.FromDateTime(DateTime.Today);
}

#endif
