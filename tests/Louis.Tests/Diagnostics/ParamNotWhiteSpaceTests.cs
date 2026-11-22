// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

internal sealed class ParamNotWhiteSpaceTests
{
    [Test]
    [Arguments("")]
    [Arguments(" ")]
    [Arguments(" \t\r\n")]
    public async Task NotWhiteSpace_WithNoVisibleCharacter_ThrowsArgumentException(string source)
    {
        await Assert.That(() => ReturnsSameSpan(source))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("text cannot be empty or consist only of white-space characters.", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    [Arguments("abc")]
    [Arguments(" a ")]
    public async Task NotWhiteSpace_WithVisibleCharacter_ReturnsSameSpan(string source)
    {
        await Assert.That(ReturnsSameSpan(source)).IsTrue();
    }

    private static bool ReturnsSameSpan(string source)
    {
        var text = source.AsSpan();
        return Param.NotWhiteSpace(text) == text;
    }
}
