// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Collections;
using TUnit.Assertions.Enums;

internal sealed class EnumerableExtensionsWhereNotNullTests
{
    [Test]
    public async Task WhereNotNull_WithNullEnumerableOfClass_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((IEnumerable<string?>)null!).WhereNotNull();

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task WhereNotNull_WithClass_ReturnsItemsThatAreNotNull()
    {
        string?[] items = ["a", null, "b", null, "c"];

        var result = items.WhereNotNull();

        await Assert.That(result).IsEquivalentTo(["a", "b", "c"], CollectionOrdering.Matching);
    }

    [Test]
    public async Task WhereNotNull_WithClass_DefersExecution()
    {
        var items = new RecordingEnumerable<string?>(["a", null]);

        var result = items.WhereNotNull();

        await Assert.That(items.GetEnumeratorCallCount).IsEqualTo(0);
        _ = result.ToList();
        await Assert.That(items.GetEnumeratorCallCount).IsEqualTo(1);
    }

    [Test]
    public async Task WhereNotNull_WithNullEnumerableOfStruct_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((IEnumerable<int?>)null!).WhereNotNull();

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task WhereNotNull_WithStruct_ReturnsValuesOfItemsThatAreNotNull()
    {
        int?[] items = [1, null, 2, null, 3];

        var result = items.WhereNotNull();

        await Assert.That(result).IsEquivalentTo([1, 2, 3], CollectionOrdering.Matching);
    }

    [Test]
    public async Task WhereNotNull_WithStruct_DefersExecution()
    {
        var items = new RecordingEnumerable<int?>([1, null]);

        var result = items.WhereNotNull();

        await Assert.That(items.GetEnumeratorCallCount).IsEqualTo(0);
        _ = result.ToList();
        await Assert.That(items.GetEnumeratorCallCount).IsEqualTo(1);
    }
}
