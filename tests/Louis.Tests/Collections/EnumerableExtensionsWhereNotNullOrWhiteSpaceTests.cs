// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Collections;
using TUnit.Assertions.Enums;

internal sealed class EnumerableExtensionsWhereNotNullOrWhiteSpaceTests
{
    [Test]
    public async Task WhereNotNullOrWhiteSpace_WithNullEnumerable_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((IEnumerable<string?>)null!).WhereNotNullOrWhiteSpace();

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task WhereNotNullOrWhiteSpace_ReturnsItemsThatAreNeitherNullNorWhiteSpace()
    {
        string?[] items = ["a", null, string.Empty, " ", "\t\n", "b"];

        var result = items.WhereNotNullOrWhiteSpace();

        await Assert.That(result).IsEquivalentTo(["a", "b"], CollectionOrdering.Matching);
    }

    [Test]
    public async Task WhereNotNullOrWhiteSpace_DefersExecution()
    {
        var items = new RecordingEnumerable<string?>(["a", null]);

        var result = items.WhereNotNullOrWhiteSpace();

        await Assert.That(items.GetEnumeratorCallCount).IsEqualTo(0);
        _ = result.ToList();
        await Assert.That(items.GetEnumeratorCallCount).IsEqualTo(1);
    }
}
