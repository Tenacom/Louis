// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

internal sealed class ParamNotNullOrWhiteSpaceTests
{
    [Test]
    public async Task NotNullOrWhiteSpace_WithNull_ThrowsArgumentNullException()
    {
        await Assert.That(() => Act(null))
            .Throws<ArgumentNullException>()
            .WithMessageContaining("text cannot be null.", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    [Arguments("")]
    [Arguments(" ")]
    [Arguments(" \t\r\n")]
    public async Task NotNullOrWhiteSpace_WithNoVisibleCharacter_ThrowsArgumentException(string value)
    {
        await Assert.That(() => Act(value))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("text cannot be empty or consist only of white-space characters.", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    [Arguments("abc")]
    [Arguments(" a ")]
    public async Task NotNullOrWhiteSpace_WithVisibleCharacter_ReturnsSameInstance(string text)
    {
        var result = Param.NotNullOrWhiteSpace(text);

        await Assert.That(result).IsSameReferenceAs(text);
    }

    private static void Act(string? text) => Param.NotNullOrWhiteSpace(text);
}
