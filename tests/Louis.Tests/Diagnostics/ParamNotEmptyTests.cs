// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

internal sealed class ParamNotEmptyTests
{
    [Test]
    public async Task NotEmpty_WithEmptySpan_ThrowsArgumentException()
    {
        await Assert.That(() => ReturnsSameSpan(string.Empty))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("text cannot be empty.", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    [Arguments("abc")]
    [Arguments(" \t\r\n")]
    public async Task NotEmpty_WithCharacters_ReturnsSameSpan(string source)
    {
        await Assert.That(ReturnsSameSpan(source)).IsTrue();
    }

    private static bool ReturnsSameSpan(string source)
    {
        var text = source.AsSpan();
        return Param.NotEmpty(text) == text;
    }
}
