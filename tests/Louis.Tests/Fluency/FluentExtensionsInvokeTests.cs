// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Fluency;
using TUnit.Assertions.Enums;

internal sealed class FluentExtensionsInvokeTests
{
    [Test]
    public async Task Invoke_WithNoArguments_CallsActionAndReturnsThis()
    {
        var list = new List<int>();

        var result = list.Invoke(l => l.Add(0));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo([0], CollectionOrdering.Matching);
    }

    [Test]
    public async Task Invoke_WithNoArgumentsAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).Invoke(_ => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task Invoke_WithNoArgumentsAndNullAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().Invoke(null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("action");
    }

    [Test]
    public async Task Invoke_WithOneArgument_CallsActionAndReturnsThis()
    {
        var list = new List<int>();

        var result = list.Invoke(1, (l, a1) => l.Add(a1));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo([1], CollectionOrdering.Matching);
    }

    [Test]
    public async Task Invoke_WithOneArgumentAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).Invoke(1, (_, _) => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task Invoke_WithOneArgumentAndNullAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().Invoke(1, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("action");
    }

    [Test]
    public async Task Invoke_WithTwoArguments_CallsActionAndReturnsThis()
    {
        var list = new List<int>();

        var result = list.Invoke(1, 2, (l, a1, a2) => l.AddRange([a1, a2]));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo([1, 2], CollectionOrdering.Matching);
    }

    [Test]
    public async Task Invoke_WithTwoArgumentsAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).Invoke(1, 2, (_, _, _) => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task Invoke_WithTwoArgumentsAndNullAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().Invoke(1, 2, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("action");
    }

    [Test]
    public async Task Invoke_WithThreeArguments_CallsActionAndReturnsThis()
    {
        var list = new List<int>();

        var result = list.Invoke(1, 2, 3, (l, a1, a2, a3) => l.AddRange([a1, a2, a3]));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo([1, 2, 3], CollectionOrdering.Matching);
    }

    [Test]
    public async Task Invoke_WithThreeArgumentsAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).Invoke(1, 2, 3, (_, _, _, _) => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task Invoke_WithThreeArgumentsAndNullAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().Invoke(1, 2, 3, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("action");
    }

    [Test]
    public async Task Invoke_WithFourArguments_CallsActionAndReturnsThis()
    {
        var list = new List<int>();

        var result = list.Invoke(1, 2, 3, 4, (l, a1, a2, a3, a4) => l.AddRange([a1, a2, a3, a4]));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo([1, 2, 3, 4], CollectionOrdering.Matching);
    }

    [Test]
    public async Task Invoke_WithFourArgumentsAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).Invoke(1, 2, 3, 4, (_, _, _, _, _) => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task Invoke_WithFourArgumentsAndNullAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().Invoke(1, 2, 3, 4, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("action");
    }
}
