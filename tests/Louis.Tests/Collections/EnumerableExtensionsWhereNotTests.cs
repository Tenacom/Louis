// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Collections;
using TUnit.Assertions.Enums;

internal sealed class EnumerableExtensionsWhereNotTests
{
    [Test]
    public async Task WhereNot_WithNullEnumerable_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((IEnumerable<int>)null!).WhereNot(x => x > 1);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task WhereNot_WithNullPredicate_ThrowsArgumentNullException()
    {
        int[] items = [1, 2, 3];

        // ! Null on purpose: testing null detection
        void Act() => items.WhereNot(null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("predicate");
    }

    [Test]
    public async Task WhereNot_ReturnsItemsThatDoNotSatisfyPredicate()
    {
        int[] items = [1, 2, 3, 4, 5];

        var result = items.WhereNot(x => x % 2 == 0);

        await Assert.That(result).IsEquivalentTo([1, 3, 5], CollectionOrdering.Matching);
    }

    [Test]
    public async Task WhereNot_DefersExecution()
    {
        var items = new RecordingEnumerable<int>([1, 2, 3]);

        var result = items.WhereNot(x => x > 1);

        await Assert.That(items.GetEnumeratorCallCount).IsEqualTo(0);
        _ = result.ToList();
        await Assert.That(items.GetEnumeratorCallCount).IsEqualTo(1);
    }
}
