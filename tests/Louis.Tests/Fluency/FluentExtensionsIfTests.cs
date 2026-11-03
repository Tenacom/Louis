// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Fluency;
using TUnit.Assertions.Enums;

internal sealed class FluentExtensionsIfTests
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task If_WithFluentAction_ReturnsResultOfThenWhenConditionIsTrue(bool condition)
    {
        var list = new List<int>();
        int[] expected = condition ? [0] : [];

        var result = list.If(condition, l => [.. l, 0]);

        await Assert.That(result).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task If_WithFluentActionAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).If(true, l => l);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task If_WithNullFluentAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().If(true, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("then");
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task If_WithAction_CallsThenWhenConditionIsTrue(bool condition)
    {
        var list = new List<int>();
        int[] expected = condition ? [0] : [];

        var result = list.If(condition, l => l.Add(0));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task If_WithActionAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).If(true, _ => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task If_WithNullAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().If(true, (Action<List<int>>)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("then");
    }
}
