// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

/// <summary>
/// Holds the tests that the chain checks for the types of collection share.
/// Each test runs once for each <see cref="CollectionKind"/>, on the checks for that type of collection.
/// </summary>
[Arguments(CollectionKind.Array)]
[Arguments(CollectionKind.List)]
[Arguments(CollectionKind.IList)]
[Arguments(CollectionKind.IReadOnlyList)]
[Arguments(CollectionKind.ICollection)]
[Arguments(CollectionKind.IReadOnlyCollection)]
[Arguments(CollectionKind.Memory)]
[Arguments(CollectionKind.ReadOnlyMemory)]
[Arguments(CollectionKind.ReadOnlySpan)]
[Arguments(CollectionKind.Span)]
internal sealed class ParamCollectionChecksTests(CollectionKind kind)
{
    private readonly CollectionChecksRunner _runner = CollectionChecksRunner.For(kind);

    [Test]
    public async Task Empty_WithEmptyCollection_ReturnsSameParam()
    {
        var outcome = _runner.Empty(0, null);

        await Assert.That(outcome.SameValue).IsTrue();
        await Assert.That(outcome.Name).IsEqualTo("items");
    }

    [Test]
    [Arguments(1)]
    [Arguments(3)]
    public async Task Empty_WithItems_ThrowsArgumentException(int count)
    {
        await Assert.That(() => _runner.Empty(count, null))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"items must be empty, and its size is {count}.", StringComparison.Ordinal)
            .And.WithParameterName("items");
    }

    [Test]
    public async Task Empty_WithMessage_FormatsMessage()
    {
        await Assert.That(() => _runner.Empty(2, "{0}|{1}|{2}"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"items|{_runner.GetValueText(2)}|2", StringComparison.Ordinal);
    }

    [Test]
    [Arguments(1)]
    [Arguments(3)]
    public async Task NotEmpty_WithItems_ReturnsSameParam(int count)
    {
        var outcome = _runner.NotEmpty(count, null);

        await Assert.That(outcome.SameValue).IsTrue();
        await Assert.That(outcome.Name).IsEqualTo("items");
    }

    [Test]
    public async Task NotEmpty_WithEmptyCollection_ThrowsArgumentException()
    {
        await Assert.That(() => _runner.NotEmpty(0, null))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("items cannot be empty.", StringComparison.Ordinal)
            .And.WithParameterName("items");
    }

    [Test]
    public async Task NotEmpty_WithMessage_FormatsMessage()
    {
        await Assert.That(() => _runner.NotEmpty(0, "{0}|{1}"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"items|{_runner.GetValueText(0)}", StringComparison.Ordinal);
    }

    [Test]
    public async Task HasSizeEqualTo_WithCollectionOfThatSize_ReturnsSameParam()
    {
        var outcome = _runner.HasSizeEqualTo(3, 3, null);

        await Assert.That(outcome.SameValue).IsTrue();
        await Assert.That(outcome.Name).IsEqualTo("items");
    }

    [Test]
    [Arguments(2)]
    [Arguments(4)]
    public async Task HasSizeEqualTo_WithCollectionOfAnotherSize_ThrowsArgumentException(int count)
    {
        await Assert.That(() => _runner.HasSizeEqualTo(count, 3, null))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"items must have a size equal to 3, and its size is {count}.", StringComparison.Ordinal)
            .And.WithParameterName("items");
    }

    [Test]
    public async Task HasSizeEqualTo_WithMessage_FormatsMessage()
    {
        await Assert.That(() => _runner.HasSizeEqualTo(2, 3, "{0}|{1}|{2}|{3}"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"items|{_runner.GetValueText(2)}|3|2", StringComparison.Ordinal);
    }

    [Test]
    public async Task HasSizeEqualTo_WithOtherOfSameSize_ReturnsSameParam()
    {
        var outcome = _runner.HasSizeEqualToOther(3, 3, null);

        await Assert.That(outcome.SameValue).IsTrue();
        await Assert.That(outcome.Name).IsEqualTo("items");
    }

    [Test]
    [Arguments(2)]
    [Arguments(4)]
    public async Task HasSizeEqualTo_WithOtherOfAnotherSize_ThrowsArgumentException(int count)
    {
        await Assert.That(() => _runner.HasSizeEqualToOther(count, 3, null))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"items must have a size equal to 3, and its size is {count}.", StringComparison.Ordinal)
            .And.WithParameterName("items");
    }

    [Test]
    public async Task HasSizeEqualTo_WithOtherAndMessage_FormatsMessage()
    {
        await Assert.That(() => _runner.HasSizeEqualToOther(2, 3, "{0}|{1}|{2}|{3}"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"items|{_runner.GetValueText(2)}|3|2", StringComparison.Ordinal);
    }

    [Test]
    [Arguments(2)]
    [Arguments(4)]
    public async Task HasSizeNotEqualTo_WithCollectionOfAnotherSize_ReturnsSameParam(int count)
    {
        var outcome = _runner.HasSizeNotEqualTo(count, 3, null);

        await Assert.That(outcome.SameValue).IsTrue();
        await Assert.That(outcome.Name).IsEqualTo("items");
    }

    [Test]
    public async Task HasSizeNotEqualTo_WithCollectionOfThatSize_ThrowsArgumentException()
    {
        await Assert.That(() => _runner.HasSizeNotEqualTo(3, 3, null))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("items must not have a size equal to 3.", StringComparison.Ordinal)
            .And.WithParameterName("items");
    }

    [Test]
    public async Task HasSizeNotEqualTo_WithMessage_FormatsMessage()
    {
        await Assert.That(() => _runner.HasSizeNotEqualTo(3, 3, "{0}|{1}|{2}|{3}"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"items|{_runner.GetValueText(3)}|3|3", StringComparison.Ordinal);
    }

    [Test]
    [Arguments(4)]
    [Arguments(6)]
    public async Task HasSizeGreaterThan_WithLargerCollection_ReturnsSameParam(int count)
    {
        var outcome = _runner.HasSizeGreaterThan(count, 3, null);

        await Assert.That(outcome.SameValue).IsTrue();
        await Assert.That(outcome.Name).IsEqualTo("items");
    }

    [Test]
    [Arguments(3)]
    [Arguments(2)]
    public async Task HasSizeGreaterThan_WithCollectionNotLarger_ThrowsArgumentException(int count)
    {
        await Assert.That(() => _runner.HasSizeGreaterThan(count, 3, null))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"items must have a size greater than 3, and its size is {count}.", StringComparison.Ordinal)
            .And.WithParameterName("items");
    }

    [Test]
    public async Task HasSizeGreaterThan_WithMessage_FormatsMessage()
    {
        await Assert.That(() => _runner.HasSizeGreaterThan(2, 3, "{0}|{1}|{2}|{3}"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"items|{_runner.GetValueText(2)}|3|2", StringComparison.Ordinal);
    }

    [Test]
    [Arguments(3)]
    [Arguments(4)]
    public async Task HasSizeGreaterThanOrEqualTo_WithCollectionNotSmaller_ReturnsSameParam(int count)
    {
        var outcome = _runner.HasSizeGreaterThanOrEqualTo(count, 3, null);

        await Assert.That(outcome.SameValue).IsTrue();
        await Assert.That(outcome.Name).IsEqualTo("items");
    }

    [Test]
    public async Task HasSizeGreaterThanOrEqualTo_WithSmallerCollection_ThrowsArgumentException()
    {
        await Assert.That(() => _runner.HasSizeGreaterThanOrEqualTo(2, 3, null))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("items must have a size greater than or equal to 3, and its size is 2.", StringComparison.Ordinal)
            .And.WithParameterName("items");
    }

    [Test]
    public async Task HasSizeGreaterThanOrEqualTo_WithMessage_FormatsMessage()
    {
        await Assert.That(() => _runner.HasSizeGreaterThanOrEqualTo(2, 3, "{0}|{1}|{2}|{3}"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"items|{_runner.GetValueText(2)}|3|2", StringComparison.Ordinal);
    }

    [Test]
    [Arguments(2)]
    [Arguments(0)]
    public async Task HasSizeLessThan_WithSmallerCollection_ReturnsSameParam(int count)
    {
        var outcome = _runner.HasSizeLessThan(count, 3, null);

        await Assert.That(outcome.SameValue).IsTrue();
        await Assert.That(outcome.Name).IsEqualTo("items");
    }

    [Test]
    [Arguments(3)]
    [Arguments(4)]
    public async Task HasSizeLessThan_WithCollectionNotSmaller_ThrowsArgumentException(int count)
    {
        await Assert.That(() => _runner.HasSizeLessThan(count, 3, null))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"items must have a size less than 3, and its size is {count}.", StringComparison.Ordinal)
            .And.WithParameterName("items");
    }

    [Test]
    public async Task HasSizeLessThan_WithMessage_FormatsMessage()
    {
        await Assert.That(() => _runner.HasSizeLessThan(4, 3, "{0}|{1}|{2}|{3}"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"items|{_runner.GetValueText(4)}|3|4", StringComparison.Ordinal);
    }

    [Test]
    [Arguments(3)]
    [Arguments(2)]
    public async Task HasSizeLessThanOrEqualTo_WithCollectionNotLarger_ReturnsSameParam(int count)
    {
        var outcome = _runner.HasSizeLessThanOrEqualTo(count, 3, null);

        await Assert.That(outcome.SameValue).IsTrue();
        await Assert.That(outcome.Name).IsEqualTo("items");
    }

    [Test]
    public async Task HasSizeLessThanOrEqualTo_WithLargerCollection_ThrowsArgumentException()
    {
        await Assert.That(() => _runner.HasSizeLessThanOrEqualTo(4, 3, null))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("items must have a size less than or equal to 3, and its size is 4.", StringComparison.Ordinal)
            .And.WithParameterName("items");
    }

    [Test]
    public async Task HasSizeLessThanOrEqualTo_WithMessage_FormatsMessage()
    {
        await Assert.That(() => _runner.HasSizeLessThanOrEqualTo(4, 3, "{0}|{1}|{2}|{3}"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"items|{_runner.GetValueText(4)}|3|4", StringComparison.Ordinal);
    }

    [Test]
    [Arguments(3)]
    [Arguments(2)]
    public async Task HasSizeLessThanOrEqualTo_WithOtherNotSmaller_ReturnsSameParam(int count)
    {
        var outcome = _runner.HasSizeLessThanOrEqualToOther(count, 3, null);

        await Assert.That(outcome.SameValue).IsTrue();
        await Assert.That(outcome.Name).IsEqualTo("items");
    }

    [Test]
    public async Task HasSizeLessThanOrEqualTo_WithSmallerOther_ThrowsArgumentException()
    {
        await Assert.That(() => _runner.HasSizeLessThanOrEqualToOther(4, 3, null))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("items must have a size less than or equal to 3, and its size is 4.", StringComparison.Ordinal)
            .And.WithParameterName("items");
    }

    [Test]
    public async Task HasSizeLessThanOrEqualTo_WithOtherAndMessage_FormatsMessage()
    {
        await Assert.That(() => _runner.HasSizeLessThanOrEqualToOther(4, 3, "{0}|{1}|{2}|{3}"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"items|{_runner.GetValueText(4)}|3|4", StringComparison.Ordinal);
    }

    [Test]
    [Arguments(0)]
    [Arguments(2)]
    public async Task InRangeFor_WithIndexInCollection_ReturnsSameParam(int index)
    {
        var param = _runner.InRangeFor(index, 3, null);

        await Assert.That(param.Value).IsEqualTo(index);
        await Assert.That(param.Name).IsEqualTo("index");
    }

    [Test]
    [Arguments(-1)]
    [Arguments(3)]
    [Arguments(100)]
    public async Task InRangeFor_WithIndexOutsideCollection_ThrowsArgumentOutOfRangeException(int index)
    {
        await Assert.That(() => _runner.InRangeFor(index, 3, null))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining($"index ({index}) must be greater than or equal to 0, and less than 3.", StringComparison.Ordinal)
            .And.WithParameterName("index");
    }

    [Test]
    public async Task InRangeFor_WithEmptyCollection_ThrowsArgumentOutOfRangeException()
    {
        await Assert.That(() => _runner.InRangeFor(0, 0, null))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining("index (0) must be greater than or equal to 0, and less than 0.", StringComparison.Ordinal)
            .And.WithParameterName("index");
    }

    [Test]
    public async Task InRangeFor_WithMessage_FormatsMessage()
    {
        await Assert.That(() => _runner.InRangeFor(3, 3, "{0}|{1}|{2}"))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining("index|3|3", StringComparison.Ordinal);
    }

    [Test]
    public async Task InRangeFor_WhenFailed_SetsActualValue()
    {
        void Act() => _runner.InRangeFor(3, 3, null);

        var exception = Assert.Throws<ArgumentOutOfRangeException>(Act);

        await Assert.That(exception.ActualValue).IsEqualTo(3);
    }

    [Test]
    [Arguments(-1)]
    [Arguments(3)]
    [Arguments(100)]
    public async Task NotInRangeFor_WithIndexOutsideCollection_ReturnsSameParam(int index)
    {
        var param = _runner.NotInRangeFor(index, 3, null);

        await Assert.That(param.Value).IsEqualTo(index);
        await Assert.That(param.Name).IsEqualTo("index");
    }

    [Test]
    public async Task NotInRangeFor_WithEmptyCollection_ReturnsSameParam()
    {
        var param = _runner.NotInRangeFor(0, 0, null);

        await Assert.That(param.Value).IsEqualTo(0);
        await Assert.That(param.Name).IsEqualTo("index");
    }

    [Test]
    [Arguments(0)]
    [Arguments(2)]
    public async Task NotInRangeFor_WithIndexInCollection_ThrowsArgumentOutOfRangeException(int index)
    {
        await Assert.That(() => _runner.NotInRangeFor(index, 3, null))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining($"index ({index}) must be less than 0, or greater than or equal to 3.", StringComparison.Ordinal)
            .And.WithParameterName("index");
    }

    [Test]
    public async Task NotInRangeFor_WithMessage_FormatsMessage()
    {
        await Assert.That(() => _runner.NotInRangeFor(1, 3, "{0}|{1}|{2}"))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining("index|1|3", StringComparison.Ordinal);
    }
}
