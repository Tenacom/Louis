// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Collections;
using TUnit.Assertions.Enums;

internal sealed class EnumerableExtensionsWhereNotNullOrEmptyTests
{
    [Test]
    public async Task WhereNotNullOrEmpty_WithNullEnumerable_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((IEnumerable<string?>)null!).WhereNotNullOrEmpty();

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task WhereNotNullOrEmpty_ReturnsItemsThatAreNeitherNullNorEmpty()
    {
        string?[] items = ["a", null, string.Empty, " ", "b"];

        var result = items.WhereNotNullOrEmpty();

        await Assert.That(result).IsEquivalentTo(["a", " ", "b"], CollectionOrdering.Matching);
    }

    [Test]
    public async Task WhereNotNullOrEmpty_DefersExecution()
    {
        var items = new RecordingEnumerable<string?>(["a", null]);

        var result = items.WhereNotNullOrEmpty();

        await Assert.That(items.GetEnumeratorCallCount).IsEqualTo(0);
        _ = result.ToList();
        await Assert.That(items.GetEnumeratorCallCount).IsEqualTo(1);
    }
}
