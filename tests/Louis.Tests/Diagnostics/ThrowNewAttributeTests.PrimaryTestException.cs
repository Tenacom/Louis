// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

partial class ThrowNewAttributeTests
{
    // The class has a primary constructor alone, because its test is about the methods of that constructor.
#pragma warning disable CA1032 // Implement standard exception constructors
    [method: ThrowNew]
    private sealed partial class PrimaryTestException(string message) : Exception(message);
#pragma warning restore CA1032
}
