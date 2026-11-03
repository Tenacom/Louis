// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Fluency;
using TUnit.Assertions.Enums;

internal sealed class FluentExtensionsChainTests
{
    [Test]
    public async Task Chain_WithNoArguments_ReturnsResultOfFunc()
    {
        var list = new List<int>();

        var result = list.Chain(l => [.. l, 0]);

        await Assert.That(result).IsNotSameReferenceAs(list);
        await Assert.That(result).IsEquivalentTo([0], CollectionOrdering.Matching);
    }

    [Test]
    public async Task Chain_WithNoArgumentsAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).Chain(l => l);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task Chain_WithNoArgumentsAndNullFunc_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().Chain(null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("func");
    }

    [Test]
    public async Task Chain_WithOneArgument_ReturnsResultOfFunc()
    {
        var list = new List<int>();

        var result = list.Chain(1, (l, a1) => [.. l, a1]);

        await Assert.That(result).IsNotSameReferenceAs(list);
        await Assert.That(result).IsEquivalentTo([1], CollectionOrdering.Matching);
    }

    [Test]
    public async Task Chain_WithOneArgumentAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).Chain(1, (l, _) => l);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task Chain_WithOneArgumentAndNullFunc_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().Chain(1, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("func");
    }

    [Test]
    public async Task Chain_WithTwoArguments_ReturnsResultOfFunc()
    {
        var list = new List<int>();

        var result = list.Chain(1, 2, (l, a1, a2) => [.. l, a1, a2]);

        await Assert.That(result).IsNotSameReferenceAs(list);
        await Assert.That(result).IsEquivalentTo([1, 2], CollectionOrdering.Matching);
    }

    [Test]
    public async Task Chain_WithTwoArgumentsAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).Chain(1, 2, (l, _, _) => l);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task Chain_WithTwoArgumentsAndNullFunc_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().Chain(1, 2, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("func");
    }

    [Test]
    public async Task Chain_WithThreeArguments_ReturnsResultOfFunc()
    {
        var list = new List<int>();

        var result = list.Chain(1, 2, 3, (l, a1, a2, a3) => [.. l, a1, a2, a3]);

        await Assert.That(result).IsNotSameReferenceAs(list);
        await Assert.That(result).IsEquivalentTo([1, 2, 3], CollectionOrdering.Matching);
    }

    [Test]
    public async Task Chain_WithThreeArgumentsAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).Chain(1, 2, 3, (l, _, _, _) => l);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task Chain_WithThreeArgumentsAndNullFunc_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().Chain(1, 2, 3, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("func");
    }

    [Test]
    public async Task Chain_WithFourArguments_ReturnsResultOfFunc()
    {
        var list = new List<int>();

        var result = list.Chain(1, 2, 3, 4, (l, a1, a2, a3, a4) => [.. l, a1, a2, a3, a4]);

        await Assert.That(result).IsNotSameReferenceAs(list);
        await Assert.That(result).IsEquivalentTo([1, 2, 3, 4], CollectionOrdering.Matching);
    }

    [Test]
    public async Task Chain_WithFourArgumentsAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).Chain(1, 2, 3, 4, (l, _, _, _, _) => l);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task Chain_WithFourArgumentsAndNullFunc_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().Chain(1, 2, 3, 4, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("func");
    }
}
