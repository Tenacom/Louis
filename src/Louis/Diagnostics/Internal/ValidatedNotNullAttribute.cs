// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if !NET6_0_OR_GREATER

using System;

namespace Louis.Diagnostics.Internal;

/// <summary>
/// Marks a parameter that the method validates as not <see langword="null"/>,
/// so that CA1062 does not report the callers of the method for using the argument without a check.
/// CA1062 matches the attribute by name, in any namespace.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter)]
internal sealed class ValidatedNotNullAttribute : Attribute;

#endif
