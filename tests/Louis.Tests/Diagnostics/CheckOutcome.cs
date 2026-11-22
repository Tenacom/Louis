// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

/// <summary>
/// Describes what a chain check returned, for a test that cannot hold the return value.
/// A value that holds a span cannot cross an <see langword="await"/>.
/// </summary>
/// <param name="SameValue"><see langword="true"/> if the check returned the value it received;
/// otherwise, <see langword="false"/>.</param>
/// <param name="Name">The name of the parameter that the check returned.</param>
internal readonly record struct CheckOutcome(bool SameValue, string Name);
