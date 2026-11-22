// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

/// <summary>
/// Holds the tests of the null arguments of the chain checks on a read-only list parameter.
/// <see cref="ParamCollectionChecksTests"/> holds the other tests of these checks.
/// </summary>
internal sealed class ParamExtensionsIReadOnlyListTests
{
    [Test]
    public async Task HasSizeEqualTo_WithNullOther_ThrowsArgumentNullException()
    {
        static void Act(int count)
        {
            IReadOnlyList<int> items = new int[count];

            // ! Null on purpose: testing null detection
            Param.Check(items).HasSizeEqualTo(null!);
        }

        await Assert.That(() => Act(3)).ThrowsExactly<ArgumentNullException>().WithParameterName("other");
    }

    [Test]
    public async Task HasSizeLessThanOrEqualTo_WithNullOther_ThrowsArgumentNullException()
    {
        static void Act(int count)
        {
            IReadOnlyList<int> items = new int[count];

            // ! Null on purpose: testing null detection
            Param.Check(items).HasSizeLessThanOrEqualTo(null!);
        }

        await Assert.That(() => Act(3)).ThrowsExactly<ArgumentNullException>().WithParameterName("other");
    }
}
