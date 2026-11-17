// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Text;

internal sealed class TextEditTests
{
    [Test]
    public async Task Constructor_SetsTheProperties()
    {
        var edit = new TextEdit(1, 2, "abc");

        await Assert.That(edit.Start).IsEqualTo(1);
        await Assert.That(edit.Length).IsEqualTo(2);
        await Assert.That(edit.Text).IsEqualTo("abc");
    }

    [Test]
    public async Task Initializer_SetsTheProperties()
    {
        var edit = new TextEdit(1, 2, "abc") with { Start = 3, Length = 4, Text = "def" };

        await Assert.That(edit).IsEqualTo(new TextEdit(3, 4, "def"));
    }

    [Test]
    public async Task Default_IsAnInsertionOfAnEmptyTextAtIndexZero()
    {
        var edit = default(TextEdit);

        await Assert.That(edit.Text).IsEqualTo(string.Empty);
        await Assert.That(edit).IsEqualTo(new TextEdit(0, 0, string.Empty));
        await Assert.That(edit.GetHashCode()).IsEqualTo(new TextEdit(0, 0, string.Empty).GetHashCode());
    }

    [Test]
    public async Task Text_WithNullText_ReturnsAnEmptyString()
    {
        // ! Null on purpose: testing null detection
        var edit = new TextEdit(1, 2, null!);

        await Assert.That(edit.Text).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task Equals_WithSameStartLengthAndText_ReturnsTrue()
    {
        var a = new TextEdit(1, 2, "abc");
        var b = new TextEdit(1, 2, new string("abc".ToCharArray()));

        await Assert.That(a.Equals(b)).IsTrue();
        await Assert.That(a.Equals((object)b)).IsTrue();
        await Assert.That(a == b).IsTrue();
        await Assert.That(a != b).IsFalse();
        await Assert.That(a.GetHashCode()).IsEqualTo(b.GetHashCode());
    }

    [Test]
    [Arguments(0, 2, "abc")]
    [Arguments(1, 3, "abc")]
    [Arguments(1, 2, "abd")]
    [Arguments(1, 2, "ABC")]
    public async Task Equals_WithDifferentStartLengthOrText_ReturnsFalse(int start, int length, string text)
    {
        var a = new TextEdit(1, 2, "abc");
        var b = new TextEdit(start, length, text);

        await Assert.That(a.Equals(b)).IsFalse();
        await Assert.That(a.Equals((object)b)).IsFalse();
        await Assert.That(a == b).IsFalse();
        await Assert.That(a != b).IsTrue();
    }

    [Test]
    public async Task Equals_WithObjectOfAnotherType_ReturnsFalse()
    {
        var a = new TextEdit(1, 2, "abc");
        object other = "abc";

        await Assert.That(a.Equals(other)).IsFalse();
        await Assert.That(a.Equals(null)).IsFalse();
    }
}
