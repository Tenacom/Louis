// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Fluency;
using TUnit.Assertions.Enums;

internal sealed class FluentExtensionsSwitchTests
{
    [Test]
    [Arguments("a", 1)]
    [Arguments("b", null)]
    [Arguments("z", null)]
    public async Task Switch_WithFluentActionCases_ReturnsResultOfFirstMatchingAction(string value, int? expected)
    {
        var list = new List<int>();
        int[] expectedItems = expected is { } item ? [item] : [];

        var result = list.Switch(
            value,
            ("a", l => [.. l, 1]),
            ("b", null),
            ("a", l => [.. l, 2]),
            ("b", l => [.. l, 3]));

        await Assert.That(result).IsEquivalentTo(expectedItems, CollectionOrdering.Matching);
    }

    [Test]
    public async Task Switch_WithFluentActionCasesAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).Switch("a", ("a", l => l));

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task Switch_WithNullFluentActionCases_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            (string Comparand, FluentAction<List<int>>? Action)[] cases = null!;
            new List<int>().Switch("a", cases);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("cases");
    }

    [Test]
    [Arguments("A", 1)]
    [Arguments("B", null)]
    [Arguments("z", null)]
    public async Task Switch_WithComparerAndFluentActionCases_ReturnsResultOfFirstMatchingAction(string value, int? expected)
    {
        var list = new List<int>();
        int[] expectedItems = expected is { } item ? [item] : [];

        var result = list.Switch(
            StringComparer.OrdinalIgnoreCase,
            value,
            ("a", l => [.. l, 1]),
            ("b", null),
            ("a", l => [.. l, 2]),
            ("b", l => [.. l, 3]));

        await Assert.That(result).IsEquivalentTo(expectedItems, CollectionOrdering.Matching);
    }

    [Test]
    public async Task Switch_WithComparerAndFluentActionCasesAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).Switch(StringComparer.Ordinal, "a", ("a", l => l));

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task Switch_WithNullComparerAndFluentActionCases_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            IEqualityComparer<string> comparer = null!;
            new List<int>().Switch(comparer, "a", ("a", l => l));
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("comparer");
    }

    [Test]
    public async Task Switch_WithComparerAndNullFluentActionCases_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            (string Comparand, FluentAction<List<int>>? Action)[] cases = null!;
            new List<int>().Switch(StringComparer.Ordinal, "a", cases);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("cases");
    }

    [Test]
    [Arguments("a", 1)]
    [Arguments("b", null)]
    [Arguments("z", null)]
    public async Task Switch_WithActionCases_CallsFirstMatchingAction(string value, int? expected)
    {
        var list = new List<int>();
        int[] expectedItems = expected is { } item ? [item] : [];

        var result = list.Switch(
            value,
            ("a", l => l.Add(1)),
            ("b", null),
            ("a", l => l.Add(2)),
            ("b", l => l.Add(3)));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo(expectedItems, CollectionOrdering.Matching);
    }

    [Test]
    public async Task Switch_WithActionCasesAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).Switch("a", ("a", _ => { }));

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task Switch_WithNullActionCases_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            (string Comparand, Action<List<int>>? Action)[] cases = null!;
            new List<int>().Switch("a", cases);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("cases");
    }

    [Test]
    [Arguments("A", 1)]
    [Arguments("B", null)]
    [Arguments("z", null)]
    public async Task Switch_WithComparerAndActionCases_CallsFirstMatchingAction(string value, int? expected)
    {
        var list = new List<int>();
        int[] expectedItems = expected is { } item ? [item] : [];

        var result = list.Switch(
            StringComparer.OrdinalIgnoreCase,
            value,
            ("a", l => l.Add(1)),
            ("b", null),
            ("a", l => l.Add(2)),
            ("b", l => l.Add(3)));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo(expectedItems, CollectionOrdering.Matching);
    }

    [Test]
    public async Task Switch_WithComparerAndActionCasesAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).Switch(StringComparer.Ordinal, "a", ("a", _ => { }));

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task Switch_WithNullComparerAndActionCases_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            IEqualityComparer<string> comparer = null!;
            new List<int>().Switch(comparer, "a", ("a", _ => { }));
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("comparer");
    }

    [Test]
    public async Task Switch_WithComparerAndNullActionCases_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            (string Comparand, Action<List<int>>? Action)[] cases = null!;
            new List<int>().Switch(StringComparer.Ordinal, "a", cases);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("cases");
    }

    [Test]
    [Arguments("a", 1)]
    [Arguments("b", null)]
    [Arguments("z", 0)]
    public async Task Switch_WithDefaultAndFluentActionCases_ReturnsResultOfFirstMatchingActionOrDefault(string value, int? expected)
    {
        var list = new List<int>();
        int[] expectedItems = expected is { } item ? [item] : [];

        var result = list.Switch(
            value,
            l => [.. l, 0],
            ("a", l => [.. l, 1]),
            ("b", null),
            ("a", l => [.. l, 2]),
            ("b", l => [.. l, 3]));

        await Assert.That(result).IsEquivalentTo(expectedItems, CollectionOrdering.Matching);
    }

    [Test]
    public async Task Switch_WithDefaultAndFluentActionCasesAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).Switch("a", l => l, ("a", l => l));

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task Switch_WithDefaultAndNullFluentActionCases_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            (string Comparand, FluentAction<List<int>>? Action)[] cases = null!;
            new List<int>().Switch("a", l => l, cases);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("cases");
    }

    [Test]
    [Arguments("A", 1)]
    [Arguments("B", null)]
    [Arguments("z", 0)]
    public async Task Switch_WithComparerAndDefaultAndFluentActionCases_ReturnsResultOfFirstMatchingActionOrDefault(
        string value,
        int? expected)
    {
        var list = new List<int>();
        int[] expectedItems = expected is { } item ? [item] : [];

        var result = list.Switch(
            StringComparer.OrdinalIgnoreCase,
            value,
            l => [.. l, 0],
            ("a", l => [.. l, 1]),
            ("b", null),
            ("a", l => [.. l, 2]),
            ("b", l => [.. l, 3]));

        await Assert.That(result).IsEquivalentTo(expectedItems, CollectionOrdering.Matching);
    }

    [Test]
    public async Task Switch_WithComparerAndDefaultAndFluentActionCasesAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).Switch(StringComparer.Ordinal, "a", l => l, ("a", l => l));

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task Switch_WithNullComparerAndDefaultAndFluentActionCases_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            IEqualityComparer<string> comparer = null!;
            new List<int>().Switch(comparer, "a", l => l, ("a", l => l));
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("comparer");
    }

    [Test]
    public async Task Switch_WithComparerAndDefaultAndNullFluentActionCases_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            (string Comparand, FluentAction<List<int>>? Action)[] cases = null!;
            new List<int>().Switch(StringComparer.Ordinal, "a", l => l, cases);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("cases");
    }

    [Test]
    [Arguments("a", 1)]
    [Arguments("b", null)]
    [Arguments("z", 0)]
    public async Task Switch_WithDefaultAndActionCases_CallsFirstMatchingActionOrDefault(string value, int? expected)
    {
        var list = new List<int>();
        int[] expectedItems = expected is { } item ? [item] : [];

        var result = list.Switch(
            value,
            l =>
            {
                l.Add(0);
                return l;
            },
            ("a", l => l.Add(1)),
            ("b", null),
            ("a", l => l.Add(2)),
            ("b", l => l.Add(3)));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo(expectedItems, CollectionOrdering.Matching);
    }

    [Test]
    public async Task Switch_WithDefaultAndActionCasesAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).Switch("a", l => l, ("a", _ => { }));

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task Switch_WithDefaultAndNullActionCases_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            (string Comparand, Action<List<int>>? Action)[] cases = null!;
            new List<int>().Switch("a", l => l, cases);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("cases");
    }

    [Test]
    [Arguments("A", 1)]
    [Arguments("B", null)]
    [Arguments("z", 0)]
    public async Task Switch_WithComparerAndDefaultAndActionCases_CallsFirstMatchingActionOrDefault(string value, int? expected)
    {
        var list = new List<int>();
        int[] expectedItems = expected is { } item ? [item] : [];

        var result = list.Switch(
            StringComparer.OrdinalIgnoreCase,
            value,
            l =>
            {
                l.Add(0);
                return l;
            },
            ("a", l => l.Add(1)),
            ("b", null),
            ("a", l => l.Add(2)),
            ("b", l => l.Add(3)));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo(expectedItems, CollectionOrdering.Matching);
    }

    [Test]
    public async Task Switch_WithComparerAndDefaultAndActionCasesAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).Switch(StringComparer.Ordinal, "a", l => l, ("a", _ => { }));

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task Switch_WithNullComparerAndDefaultAndActionCases_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            IEqualityComparer<string> comparer = null!;
            new List<int>().Switch(comparer, "a", l => l, ("a", _ => { }));
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("comparer");
    }

    [Test]
    public async Task Switch_WithComparerAndDefaultAndNullActionCases_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            (string Comparand, Action<List<int>>? Action)[] cases = null!;
            new List<int>().Switch(StringComparer.Ordinal, "a", l => l, cases);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("cases");
    }
}
