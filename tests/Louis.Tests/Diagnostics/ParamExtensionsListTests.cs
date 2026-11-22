// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

/// <summary>
/// Holds the tests of the null arguments of the chain checks on a <see cref="List{T}"/> parameter.
/// <see cref="ParamCollectionChecksTests"/> holds the other tests of these checks.
/// </summary>
internal sealed class ParamExtensionsListTests
{
    [Test]
    public async Task HasSizeEqualTo_WithNullOther_ThrowsArgumentNullException()
    {
        static void Act(int count)
        {
            var items = new List<int>(new int[count]);

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
            var items = new List<int>(new int[count]);

            // ! Null on purpose: testing null detection
            Param.Check(items).HasSizeLessThanOrEqualTo(null!);
        }

        await Assert.That(() => Act(3)).ThrowsExactly<ArgumentNullException>().WithParameterName("other");
    }

    [Test]
    public async Task InRangeFor_WithNullList_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act(int index) => Param.Check(index).InRangeFor((List<int>)null!);

        await Assert.That(() => Act(0)).ThrowsExactly<ArgumentNullException>().WithParameterName("list");
    }

    [Test]
    public async Task NotInRangeFor_WithNullList_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act(int index) => Param.Check(index).NotInRangeFor((List<int>)null!);

        await Assert.That(() => Act(0)).ThrowsExactly<ArgumentNullException>().WithParameterName("list");
    }
}
