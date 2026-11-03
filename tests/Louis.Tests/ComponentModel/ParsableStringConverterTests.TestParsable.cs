// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET7_0_OR_GREATER

using System.Diagnostics.CodeAnalysis;

partial class ParsableStringConverterTests
{
    // The tests convert instances to strings alone, so parsing never fails.
    private sealed class TestParsable(string? text) : IParsable<TestParsable>
    {
        public static TestParsable Parse(string s, IFormatProvider? provider) => new(s);

        public static bool TryParse(
            [NotNullWhen(true)] string? s,
            IFormatProvider? provider,
            [MaybeNullWhen(false)] out TestParsable result)
        {
            result = new TestParsable(s);
            return true;
        }

        public override string? ToString() => text;
    }
}

#endif
