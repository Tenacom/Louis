// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;
using TUnit.Assertions.Enums;

internal sealed class ExceptionExtensionsAnyCausingExceptionTests
{
    [Test]
    public async Task AnyCausingException_WithNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((Exception)null!).AnyCausingException(_ => true);

        var exception = Assert.Throws<ArgumentNullException>(Act);
        await Assert.That(exception.ParamName).IsEqualTo("this");
    }

    [Test]
    public async Task AnyCausingException_WithNullPredicate_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new InvalidOperationException().AnyCausingException(null!);

        var exception = Assert.Throws<ArgumentNullException>(Act);
        await Assert.That(exception.ParamName).IsEqualTo("predicate");
    }

    [Test]
    public async Task AnyCausingException_WithNoMatch_TestsEveryCausingExceptionInOrderAndReturnsFalse()
    {
        var inner = new InvalidOperationException("inner");
        var middle = new InvalidOperationException("middle", inner);
        var outer = new InvalidOperationException("outer", middle);
        Exception[] expected = [inner, middle, outer];
        var seen = new List<Exception>();

        var result = outer.AnyCausingException(RecordAndContinue);

        await Assert.That(result).IsFalse();
        await Assert.That(seen).IsEquivalentTo(expected, CollectionOrdering.Matching);

        bool RecordAndContinue(Exception e)
        {
            seen.Add(e);
            return false;
        }
    }

    [Test]
    public async Task AnyCausingException_WithAggregateException_TestsInnerExceptionsAndSkipsIt()
    {
        var first = new InvalidOperationException("first");
        var second = new InvalidOperationException("second");
        var aggregate = new AggregateException(first, second);
        Exception[] expected = [first, second];
        var seen = new List<Exception>();

        var result = aggregate.AnyCausingException(RecordAndContinue);

        await Assert.That(result).IsFalse();
        await Assert.That(seen).IsEquivalentTo(expected, CollectionOrdering.Matching);

        bool RecordAndContinue(Exception e)
        {
            seen.Add(e);
            return false;
        }
    }

    [Test]
    public async Task AnyCausingException_WithMatch_StopsAtFirstMatchAndReturnsTrue()
    {
        var inner = new InvalidOperationException("inner");
        var middle = new InvalidOperationException("middle", inner);
        var outer = new InvalidOperationException("outer", middle);
        Exception[] expected = [inner, middle];
        var seen = new List<Exception>();

        var result = outer.AnyCausingException(RecordAndStopAtMiddle);

        await Assert.That(result).IsTrue();
        await Assert.That(seen).IsEquivalentTo(expected, CollectionOrdering.Matching);

        bool RecordAndStopAtMiddle(Exception e)
        {
            seen.Add(e);
            return ReferenceEquals(e, middle);
        }
    }
}
