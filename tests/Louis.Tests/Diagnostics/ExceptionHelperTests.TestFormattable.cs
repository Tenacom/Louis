// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

partial class ExceptionHelperTests
{
    private sealed class TestFormattable(Func<string?, IFormatProvider?, string> formatter, Func<string?> plainText) : IFormattable
    {
        public string ToString(string? format, IFormatProvider? formatProvider) => formatter(format, formatProvider);

        public override string? ToString() => plainText();
    }
}
