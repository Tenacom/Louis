// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET7_0_OR_GREATER

using System.Diagnostics.CodeAnalysis;

partial class AddToTypeDescriptorTests
{
    // The test registers the type alone, so parsing never fails.
    private sealed class TestParsable : IParsable<TestParsable>
    {
        public static TestParsable Parse(string s, IFormatProvider? provider) => new();

        public static bool TryParse(
            [NotNullWhen(true)] string? s,
            IFormatProvider? provider,
            [MaybeNullWhen(false)] out TestParsable result)
        {
            result = new TestParsable();
            return true;
        }
    }
}

#endif
