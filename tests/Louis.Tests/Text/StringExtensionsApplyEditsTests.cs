// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Text;

internal sealed class StringExtensionsApplyEditsTests
{
    [Test]
    [MethodDataSource(typeof(TextEditRows), nameof(TextEditRows.Applied))]
    public async Task ApplyEdits_ReturnsTheEditedText(string input, TextEdit[] edits, string expected)
    {
        await Assert.That(input.ApplyEdits(edits)).IsEqualTo(expected);
    }

    [Test]
    public async Task ApplyEdits_WithNoEdits_ReturnsTheSameString()
    {
        var input = new string('a', 3);

        await Assert.That(input.ApplyEdits([])).IsSameReferenceAs(input);
    }

    [Test]
    public async Task ApplyEdits_WithLazySequence_EnumeratesItOnce()
    {
        var enumerationCount = 0;

        IEnumerable<TextEdit> GetEdits()
        {
            enumerationCount++;
            yield return new(3, 0, "Y");
            yield return new(0, 1, "X");
        }

        await Assert.That("abc".ApplyEdits(GetEdits())).IsEqualTo("XbcY");
        await Assert.That(enumerationCount).IsEqualTo(1);
    }

    [Test]
    [MethodDataSource(typeof(TextEditRows), nameof(TextEditRows.Overlapping))]
    public async Task ApplyEdits_WithOverlappingEdits_ThrowsArgumentException(string input, TextEdit[] edits)
    {
        void Act() => input.ApplyEdits(edits);

        await Assert.That(Act).ThrowsExactly<ArgumentException>().WithParameterName("edits");
    }

    [Test]
    [MethodDataSource(typeof(TextEditRows), nameof(TextEditRows.OutsideText))]
    public async Task ApplyEdits_WithEditOutsideText_ThrowsArgumentOutOfRangeException(string input, TextEdit[] edits)
    {
        void Act() => input.ApplyEdits(edits);

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName("edits");
    }

    [Test]
    public async Task ApplyEdits_WithNullThis_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            StringExtensions.ApplyEdits(null!, []);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task ApplyEdits_WithNullEdits_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            "abc".ApplyEdits(null!);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("edits");
    }
}
