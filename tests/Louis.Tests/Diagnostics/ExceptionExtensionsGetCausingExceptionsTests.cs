// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections;
using Louis.Diagnostics;
using TUnit.Assertions.Enums;

internal sealed class ExceptionExtensionsGetCausingExceptionsTests
{
    [Test]
    public async Task GetCausingExceptions_WithNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((Exception)null!).GetCausingExceptions();

        var exception = Assert.Throws<ArgumentNullException>(Act);
        await Assert.That(exception.ParamName).IsEqualTo("this");
    }

    [Test]
    public async Task GetCausingExceptions_WithPlainException_YieldsItself()
    {
        var exception = new InvalidOperationException();
        Exception[] expected = [exception];

        await Assert.That(exception.GetCausingExceptions()).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task GetCausingExceptions_WithChain_YieldsInnermostFirstAndItselfLast()
    {
        var inner = new InvalidOperationException("inner");
        var middle = new InvalidOperationException("middle", inner);
        var outer = new InvalidOperationException("outer", middle);
        Exception[] expected = [inner, middle, outer];

        await Assert.That(outer.GetCausingExceptions()).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task GetCausingExceptions_WithAggregateException_YieldsInnerExceptionsAndSkipsIt()
    {
        var first = new InvalidOperationException("first");
        var second = new InvalidOperationException("second");
        var aggregate = new AggregateException(first, second);
        Exception[] expected = [first, second];

        await Assert.That(aggregate.GetCausingExceptions()).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task GetCausingExceptions_WithNestedAggregateException_FlattensIt()
    {
        var first = new InvalidOperationException("first");
        var second = new InvalidOperationException("second");
        var third = new InvalidOperationException("third");
        var aggregate = new AggregateException(first, new AggregateException(second, third));
        Exception[] expected = [first, second, third];

        await Assert.That(aggregate.GetCausingExceptions()).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task GetCausingExceptions_WithAggregateExceptionAsInnerException_FlattensIt()
    {
        var first = new InvalidOperationException("first");
        var second = new InvalidOperationException("second");
        var outer = new InvalidOperationException("outer", new AggregateException(first, second));
        Exception[] expected = [first, second, outer];

        await Assert.That(outer.GetCausingExceptions()).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task GetCausingExceptions_WithChainInsideAggregateException_YieldsChain()
    {
        var inner = new InvalidOperationException("inner");
        var middle = new InvalidOperationException("middle", inner);
        var aggregate = new AggregateException(middle);
        Exception[] expected = [inner, middle];

        await Assert.That(aggregate.GetCausingExceptions()).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task GetCausingExceptions_EnumeratedTwice_YieldsSameSequence()
    {
        var inner = new InvalidOperationException("inner");
        var outer = new InvalidOperationException("outer", inner);
        var causingExceptions = outer.GetCausingExceptions();

#pragma warning disable CA1851 // Possible multiple enumerations of IEnumerable collection - the second enumeration is the point of the test
        // ReSharper disable PossibleMultipleEnumeration // the second enumeration is the point of the test
        var firstPass = causingExceptions.ToList();
        var secondPass = causingExceptions.ToList();

        // ReSharper restore PossibleMultipleEnumeration
#pragma warning restore CA1851 // Possible multiple enumerations of IEnumerable collection

        await Assert.That(secondPass).IsEquivalentTo(firstPass, CollectionOrdering.Matching);
    }

    [Test]
    public async Task GetCausingExceptions_EnumeratedThroughIEnumerable_YieldsSameSequence()
    {
        var inner = new InvalidOperationException("inner");
        var outer = new InvalidOperationException("outer", inner);
        object[] expected = [inner, outer];
        IEnumerable nonGeneric = outer.GetCausingExceptions();

        // foreach over an IEnumerable calls the non-generic GetEnumerator.
        // Cast<object> would use the generic one, because IEnumerable<Exception> is an IEnumerable<object> by covariance.
        var actual = new List<object>();
        foreach (var item in nonGeneric)
        {
            actual.Add(item);
        }

        await Assert.That(actual).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }
}
