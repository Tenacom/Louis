// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Fluency;
using TUnit.Assertions.Enums;

internal sealed class FluentExtensionsIfNotNullOrEmptyTests
{
    [Test]
    [Arguments("x")]
    [Arguments("")]
    [Arguments(null)]
    public async Task IfNotNullOrEmpty_WithFluentAction_ReturnsResultOfThenWhenArgIsNotNullOrEmpty(string? arg)
    {
        var list = new List<string>();
        string[] expected = arg is { Length: > 0 } ? [arg] : [];

        var result = list.IfNotNullOrEmpty(arg, (l, a) => [.. l, a]);

        await Assert.That(result).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task IfNotNullOrEmpty_WithFluentActionAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<string>)null!).IfNotNullOrEmpty("x", (l, _) => l);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task IfNotNullOrEmpty_WithNullFluentAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<string>().IfNotNullOrEmpty("x", (FluentAction<List<string>, string>)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("then");
    }

    [Test]
    [Arguments("x")]
    [Arguments("")]
    [Arguments(null)]
    public async Task IfNotNullOrEmpty_WithAction_CallsThenWhenArgIsNotNullOrEmpty(string? arg)
    {
        var list = new List<string>();
        string[] expected = arg is { Length: > 0 } ? [arg] : [];

        var result = list.IfNotNullOrEmpty(arg, (l, a) => l.Add(a));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task IfNotNullOrEmpty_WithActionAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<string>)null!).IfNotNullOrEmpty("x", (_, _) => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task IfNotNullOrEmpty_WithNullAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<string>().IfNotNullOrEmpty("x", (Action<List<string>, string>)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("then");
    }
}
