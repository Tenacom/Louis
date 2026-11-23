// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

partial class ThrowNewAttributeTests
{
    [method: ThrowNew]
    private sealed partial class PrimaryTestException(string message) : Exception(message);
}
