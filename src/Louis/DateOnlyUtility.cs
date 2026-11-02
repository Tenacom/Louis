// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET6_0_OR_GREATER

using System;

namespace Louis;

/// <summary>
/// <para>Provides utility methods to work with <see cref="DateOnly"/>.</para>
/// <para>This type is not available in the <c>netstandard</c> and .NET Framework builds of Louis,
/// because their BCL has no <see cref="DateOnly"/>.</para>
/// </summary>
public static class DateOnlyUtility
{
    /// <summary>
    /// Gets a <see cref="DateOnly"/> instance whose value represents the current date.
    /// </summary>
    public static DateOnly Today => DateOnly.FromDateTime(DateTime.Today);
}

#endif
