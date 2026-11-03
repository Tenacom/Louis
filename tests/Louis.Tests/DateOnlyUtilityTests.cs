// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET6_0_OR_GREATER

using Louis;

internal sealed class DateOnlyUtilityTests
{
    [Test]
    public async Task Today_ReturnsCurrentDate()
    {
        var before = DateOnly.FromDateTime(DateTime.Today);

        var result = DateOnlyUtility.Today;

        var after = DateOnly.FromDateTime(DateTime.Today);
        await Assert.That(result).IsBetween(before, after);
    }
}

#endif
