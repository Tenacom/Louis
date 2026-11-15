// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Text;

internal sealed class LineClippingTests
{
    private const string Text = "a\nb\nc\nd";

    [Test]
    public async Task Default_DescribesAnEmptyText()
    {
        await Assert.That(default(LineClipping)).IsEqualTo(string.Empty.ComputeLineClipping(1, 1));
    }

    [Test]
    public async Task Equals_WithSameRangesAndLineCounts_ReturnsTrue()
    {
        var a = Text.ComputeLineClipping(1, 1);
        var b = Text.ComputeLineClipping(1, 1);

        await Assert.That(a.Equals(b)).IsTrue();
        await Assert.That(a.Equals((object)b)).IsTrue();
        await Assert.That(a == b).IsTrue();
        await Assert.That(a != b).IsFalse();
        await Assert.That(a.GetHashCode()).IsEqualTo(b.GetHashCode());
    }

    [Test]
    [Arguments("a\nb\nc\nd", 2, 1)]
    [Arguments("a\nb\nc\nd", 1, 2)]
    [Arguments("a\nb\nc\nd", 1, 0)]
    [Arguments("a\nb\nc\nd", 0, 1)]
    [Arguments("a\nb\nc\nd\ne", 1, 1)]
    public async Task Equals_WithDifferentRangeOrLineCount_ReturnsFalse(string otherText, int headLines, int tailLines)
    {
        var a = Text.ComputeLineClipping(1, 1);
        var b = otherText.ComputeLineClipping(headLines, tailLines);

        await Assert.That(a.Equals(b)).IsFalse();
        await Assert.That(a.Equals((object)b)).IsFalse();
        await Assert.That(a == b).IsFalse();
        await Assert.That(a != b).IsTrue();
    }

    [Test]
    public async Task Equals_WithObjectOfAnotherType_ReturnsFalse()
    {
        var a = Text.ComputeLineClipping(1, 1);
        object other = Text;

        await Assert.That(a.Equals(other)).IsFalse();
        await Assert.That(a.Equals(null)).IsFalse();
    }
}
