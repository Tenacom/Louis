// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Fluency;
using TUnit.Assertions.Enums;

internal sealed class FluentExtensionsForEachTests
{
    [Test]
    public async Task ForEach_WithEnumerableAndFluentAction_PassesEachResultToNextCall()
    {
        var list = new List<int>();
        IEnumerable<int> items = [10, 20, 30];

        var result = list.ForEach(items, (l, item) => [.. l, item]);

        await Assert.That(result).IsNotSameReferenceAs(list);
        await Assert.That(result).IsEquivalentTo([10, 20, 30], CollectionOrdering.Matching);
    }

    [Test]
    public async Task ForEach_WithEnumerableAndFluentActionAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).ForEach(Enumerable.Empty<int>(), (l, _) => l);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task ForEach_WithEnumerableAndNullFluentAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().ForEach(Enumerable.Empty<int>(), (FluentAction<List<int>, int>)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("action");
    }

    [Test]
    public async Task ForEach_WithNullEnumerableAndFluentAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().ForEach((IEnumerable<int>)null!, (l, _) => l);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("sequence");
    }

    [Test]
    public async Task ForEach_WithEnumerableAndAction_CallsActionForEachElementAndReturnsThis()
    {
        var list = new List<int>();
        IEnumerable<int> items = [10, 20, 30];

        var result = list.ForEach(items, (l, item) => l.Add(item));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo([10, 20, 30], CollectionOrdering.Matching);
    }

    [Test]
    public async Task ForEach_WithEnumerableAndActionAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).ForEach(Enumerable.Empty<int>(), (_, _) => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task ForEach_WithEnumerableAndNullAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().ForEach(Enumerable.Empty<int>(), (Action<List<int>, int>)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("action");
    }

    [Test]
    public async Task ForEach_WithNullEnumerableAndAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().ForEach((IEnumerable<int>)null!, (_, _) => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("sequence");
    }

    [Test]
    public async Task ForEach_WithEnumerableAndIndexedFluentAction_PassesEachResultToNextCallWithIndex()
    {
        var list = new List<int>();
        IEnumerable<int> items = [10, 20, 30];

        var result = list.ForEach(items, (l, item, index) => [.. l, item, index]);

        await Assert.That(result).IsNotSameReferenceAs(list);
        await Assert.That(result).IsEquivalentTo([10, 0, 20, 1, 30, 2], CollectionOrdering.Matching);
    }

    [Test]
    public async Task ForEach_WithEnumerableAndIndexedFluentActionAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).ForEach(Enumerable.Empty<int>(), (l, _, _) => l);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task ForEach_WithEnumerableAndNullIndexedFluentAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().ForEach(Enumerable.Empty<int>(), (FluentAction<List<int>, int, int>)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("action");
    }

    [Test]
    public async Task ForEach_WithNullEnumerableAndIndexedFluentAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().ForEach((IEnumerable<int>)null!, (l, _, _) => l);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("sequence");
    }

    [Test]
    public async Task ForEach_WithEnumerableAndIndexedAction_CallsActionForEachElementWithIndex()
    {
        var list = new List<int>();
        IEnumerable<int> items = [10, 20, 30];

        var result = list.ForEach(items, (l, item, index) => l.AddRange([item, index]));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo([10, 0, 20, 1, 30, 2], CollectionOrdering.Matching);
    }

    [Test]
    public async Task ForEach_WithEnumerableAndIndexedActionAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).ForEach(Enumerable.Empty<int>(), (_, _, _) => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task ForEach_WithEnumerableAndNullIndexedAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().ForEach(Enumerable.Empty<int>(), (Action<List<int>, int, int>)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("action");
    }

    [Test]
    public async Task ForEach_WithNullEnumerableAndIndexedAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().ForEach((IEnumerable<int>)null!, (_, _, _) => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("sequence");
    }

    [Test]
    public async Task ForEach_WithSpanAndFluentAction_PassesEachResultToNextCall()
    {
        var list = new List<int>();
        ReadOnlySpan<int> items = [10, 20, 30];

        var result = list.ForEach(items, (l, item) => [.. l, item]);

        await Assert.That(result).IsNotSameReferenceAs(list);
        await Assert.That(result).IsEquivalentTo([10, 20, 30], CollectionOrdering.Matching);
    }

    [Test]
    public async Task ForEach_WithSpanAndFluentActionAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).ForEach(ReadOnlySpan<int>.Empty, (l, _) => l);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task ForEach_WithSpanAndNullFluentAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().ForEach(ReadOnlySpan<int>.Empty, (FluentAction<List<int>, int>)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("action");
    }

    [Test]
    public async Task ForEach_WithSpanAndAction_CallsActionForEachElementAndReturnsThis()
    {
        var list = new List<int>();
        ReadOnlySpan<int> items = [10, 20, 30];

        var result = list.ForEach(items, (l, item) => l.Add(item));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo([10, 20, 30], CollectionOrdering.Matching);
    }

    [Test]
    public async Task ForEach_WithSpanAndActionAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).ForEach(ReadOnlySpan<int>.Empty, (_, _) => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task ForEach_WithSpanAndNullAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().ForEach(ReadOnlySpan<int>.Empty, (Action<List<int>, int>)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("action");
    }

    [Test]
    public async Task ForEach_WithSpanAndIndexedFluentAction_PassesEachResultToNextCallWithIndex()
    {
        var list = new List<int>();
        ReadOnlySpan<int> items = [10, 20, 30];

        var result = list.ForEach(items, (l, item, index) => [.. l, item, index]);

        await Assert.That(result).IsNotSameReferenceAs(list);
        await Assert.That(result).IsEquivalentTo([10, 0, 20, 1, 30, 2], CollectionOrdering.Matching);
    }

    [Test]
    public async Task ForEach_WithSpanAndIndexedFluentActionAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).ForEach(ReadOnlySpan<int>.Empty, (l, _, _) => l);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task ForEach_WithSpanAndNullIndexedFluentAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().ForEach(ReadOnlySpan<int>.Empty, (FluentAction<List<int>, int, int>)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("action");
    }

    [Test]
    public async Task ForEach_WithSpanAndIndexedAction_CallsActionForEachElementWithIndex()
    {
        var list = new List<int>();
        ReadOnlySpan<int> items = [10, 20, 30];

        var result = list.ForEach(items, (l, item, index) => l.AddRange([item, index]));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo([10, 0, 20, 1, 30, 2], CollectionOrdering.Matching);
    }

    [Test]
    public async Task ForEach_WithSpanAndIndexedActionAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).ForEach(ReadOnlySpan<int>.Empty, (_, _, _) => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task ForEach_WithSpanAndNullIndexedAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().ForEach(ReadOnlySpan<int>.Empty, (Action<List<int>, int, int>)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("action");
    }
}
