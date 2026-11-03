// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Fluency;
using TUnit.Assertions.Enums;

internal sealed class FluentExtensionsIfElseTests
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task IfElse_WithFluentActions_ReturnsResultOfSelectedAction(bool condition)
    {
        var list = new List<int>();
        int[] expected = condition ? [1] : [2];

        var result = list.IfElse(condition, l => [.. l, 1], l => [.. l, 2]);

        await Assert.That(result).IsNotSameReferenceAs(list);
        await Assert.That(result).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task IfElse_WithFluentActionsAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).IfElse(true, l => l, l => l);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task IfElse_WithNullThenFluentAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().IfElse(true, (FluentAction<List<int>>)null!, l => l);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("then");
    }

    [Test]
    public async Task IfElse_WithNullElseFluentAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().IfElse(true, l => l, (FluentAction<List<int>>)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("else");
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task IfElse_WithActions_CallsSelectedAction(bool condition)
    {
        var list = new List<int>();
        int[] expected = condition ? [1] : [2];

        var result = list.IfElse(condition, l => l.Add(1), l => l.Add(2));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task IfElse_WithActionsAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).IfElse(true, _ => { }, _ => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task IfElse_WithNullThenAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().IfElse(true, (Action<List<int>>)null!, _ => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("then");
    }

    [Test]
    public async Task IfElse_WithNullElseAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().IfElse(true, _ => { }, (Action<List<int>>)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("else");
    }
}
