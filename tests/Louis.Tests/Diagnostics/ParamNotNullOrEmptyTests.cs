// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

internal sealed class ParamNotNullOrEmptyTests
{
    [Test]
    public async Task NotNullOrEmpty_WithNull_ThrowsArgumentNullException()
    {
        await Assert.That(() => Act(null))
            .Throws<ArgumentNullException>()
            .WithMessageContaining("text cannot be null.", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task NotNullOrEmpty_WithEmptyString_ThrowsArgumentException()
    {
        await Assert.That(() => Act(string.Empty))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("text cannot be empty.", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    [Arguments("abc")]
    [Arguments(" \t\r\n")]
    public async Task NotNullOrEmpty_WithCharacters_ReturnsSameInstance(string text)
    {
        var result = Param.NotNullOrEmpty(text);

        await Assert.That(result).IsSameReferenceAs(text);
    }

    private static void Act(string? text) => Param.NotNullOrEmpty(text);
}
