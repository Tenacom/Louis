// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Fluency;
using TUnit.Assertions.Enums;

internal sealed class FluentExtensionsIfNotNullTests
{
    [Test]
    [Arguments(5)]
    [Arguments(null)]
    public async Task IfNotNull_WithStructArgAndFluentAction_ReturnsResultOfThenWhenArgIsNotNull(int? arg)
    {
        var list = new List<int>();
        int[] expected = arg is { } value ? [value] : [];

        var result = list.IfNotNull(arg, (l, a) => [.. l, a]);

        await Assert.That(result).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task IfNotNull_WithStructArgAndFluentActionAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).IfNotNull((int?)5, (l, _) => l);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task IfNotNull_WithStructArgAndNullFluentAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().IfNotNull(5, (FluentAction<List<int>, int>)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("then");
    }

    [Test]
    [Arguments(5)]
    [Arguments(null)]
    public async Task IfNotNull_WithStructArgAndAction_CallsThenWhenArgIsNotNull(int? arg)
    {
        var list = new List<int>();
        int[] expected = arg is { } value ? [value] : [];

        var result = list.IfNotNull(arg, (l, a) => l.Add(a));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task IfNotNull_WithStructArgAndActionAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).IfNotNull((int?)5, (_, _) => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task IfNotNull_WithStructArgAndNullAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().IfNotNull(5, (Action<List<int>, int>)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("then");
    }

    [Test]
    [Arguments("x")]
    [Arguments(null)]
    public async Task IfNotNull_WithClassArgAndFluentAction_ReturnsResultOfThenWhenArgIsNotNull(string? arg)
    {
        var list = new List<string>();
        string[] expected = arg is null ? [] : [arg];

        var result = list.IfNotNull(arg, (l, a) => [.. l, a]);

        await Assert.That(result).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task IfNotNull_WithClassArgAndFluentActionAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<string>)null!).IfNotNull("x", (l, _) => l);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task IfNotNull_WithClassArgAndNullFluentAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<string>().IfNotNull("x", null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("then");
    }

    [Test]
    [Arguments("x")]
    [Arguments(null)]
    public async Task IfNotNull_WithClassArgAndAction_CallsThenWhenArgIsNotNull(string? arg)
    {
        var list = new List<string>();
        string[] expected = arg is null ? [] : [arg];

        var result = list.IfNotNull(arg, (l, a) => l.Add(a));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task IfNotNull_WithClassArgAndActionAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<string>)null!).IfNotNull("x", (_, _) => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task IfNotNull_WithClassArgAndNullAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<string>().IfNotNull("x", (Action<List<string>, string>)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("then");
    }
}
