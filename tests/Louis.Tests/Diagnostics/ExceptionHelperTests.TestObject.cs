// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

partial class ExceptionHelperTests
{
    private sealed class TestObject(Func<string?> plainText)
    {
        public override string? ToString() => plainText();
    }
}
