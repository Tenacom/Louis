// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Fluency;
using TUnit.Assertions.Enums;

internal sealed class FluentExtensionsInvokeIfTests
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task InvokeIf_WithNoArguments_CallsActionWhenConditionIsTrue(bool condition)
    {
        var list = new List<int>();
        int[] expected = condition ? [0] : [];

        var result = list.InvokeIf(condition, l => l.Add(0));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task InvokeIf_WithNoArgumentsAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).InvokeIf(true, _ => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task InvokeIf_WithNoArgumentsAndNullAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().InvokeIf(true, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("action");
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task InvokeIf_WithOneArgument_CallsActionWhenConditionIsTrue(bool condition)
    {
        var list = new List<int>();
        int[] expected = condition ? [1] : [];

        var result = list.InvokeIf(condition, 1, (l, a1) => l.Add(a1));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task InvokeIf_WithOneArgumentAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).InvokeIf(true, 1, (_, _) => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task InvokeIf_WithOneArgumentAndNullAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().InvokeIf(true, 1, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("action");
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task InvokeIf_WithTwoArguments_CallsActionWhenConditionIsTrue(bool condition)
    {
        var list = new List<int>();
        int[] expected = condition ? [1, 2] : [];

        var result = list.InvokeIf(condition, 1, 2, (l, a1, a2) => l.AddRange([a1, a2]));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task InvokeIf_WithTwoArgumentsAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).InvokeIf(true, 1, 2, (_, _, _) => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task InvokeIf_WithTwoArgumentsAndNullAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().InvokeIf(true, 1, 2, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("action");
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task InvokeIf_WithThreeArguments_CallsActionWhenConditionIsTrue(bool condition)
    {
        var list = new List<int>();
        int[] expected = condition ? [1, 2, 3] : [];

        var result = list.InvokeIf(condition, 1, 2, 3, (l, a1, a2, a3) => l.AddRange([a1, a2, a3]));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task InvokeIf_WithThreeArgumentsAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).InvokeIf(true, 1, 2, 3, (_, _, _, _) => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task InvokeIf_WithThreeArgumentsAndNullAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().InvokeIf(true, 1, 2, 3, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("action");
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task InvokeIf_WithFourArguments_CallsActionWhenConditionIsTrue(bool condition)
    {
        var list = new List<int>();
        int[] expected = condition ? [1, 2, 3, 4] : [];

        var result = list.InvokeIf(condition, 1, 2, 3, 4, (l, a1, a2, a3, a4) => l.AddRange([a1, a2, a3, a4]));

        await Assert.That(result).IsSameReferenceAs(list);
        await Assert.That(list).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task InvokeIf_WithFourArgumentsAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((List<int>)null!).InvokeIf(true, 1, 2, 3, 4, (_, _, _, _, _) => { });

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task InvokeIf_WithFourArgumentsAndNullAction_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new List<int>().InvokeIf(true, 1, 2, 3, 4, null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("action");
    }
}
