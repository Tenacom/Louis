// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Louis.Diagnostics;

namespace Louis.Threading;

partial struct Deadline
{
    /// <summary>
    /// Returns the deadline that expires first in a sequence of deadlines.
    /// </summary>
    /// <param name="deadlines">The deadlines to compare.</param>
    /// <returns>The deadline in <paramref name="deadlines"/> that expires first,
    /// or <see cref="Eternal"/> if <paramref name="deadlines"/> is empty.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="deadlines"/> is <see langword="null"/>.</exception>
    /// <remarks>
    /// <para>This method orders deadlines as <see cref="Compare"/> does.
    /// Of the deadlines that <see cref="Compare"/> reports as expiring together, it returns the first in the sequence.</para>
    /// </remarks>
    public static Deadline EarliestOf(params IEnumerable<Deadline> deadlines)
    {
        Param.NotNull(deadlines);
        var result = Eternal;
        foreach (var deadline in deadlines)
        {
            result = EarliestOf(result, deadline);
        }

        return result;
    }

    /// <summary>
    /// Returns the one of four deadlines that expires first.
    /// </summary>
    /// <param name="first">The first deadline to compare.</param>
    /// <param name="second">The second deadline to compare.</param>
    /// <param name="third">The third deadline to compare.</param>
    /// <param name="fourth">The fourth deadline to compare.</param>
    /// <returns>The parameter that expires first.</returns>
    /// <remarks>
    /// <para>This method orders deadlines as <see cref="Compare"/> does.
    /// Of the deadlines that <see cref="Compare"/> reports as expiring together, it returns the first parameter.</para>
    /// </remarks>
    public static Deadline EarliestOf(Deadline first, Deadline second, Deadline third, Deadline fourth)
        => EarliestOf(EarliestOf(first, second, third), fourth);

    /// <summary>
    /// Returns the one of three deadlines that expires first.
    /// </summary>
    /// <param name="first">The first deadline to compare.</param>
    /// <param name="second">The second deadline to compare.</param>
    /// <param name="third">The third deadline to compare.</param>
    /// <returns>The parameter that expires first.</returns>
    /// <remarks>
    /// <para>This method orders deadlines as <see cref="Compare"/> does.
    /// Of the deadlines that <see cref="Compare"/> reports as expiring together, it returns the first parameter.</para>
    /// </remarks>
    public static Deadline EarliestOf(Deadline first, Deadline second, Deadline third)
        => EarliestOf(EarliestOf(first, second), third);

    /// <summary>
    /// Returns the one of two deadlines that expires first.
    /// </summary>
    /// <param name="first">The first deadline to compare.</param>
    /// <param name="second">The second deadline to compare.</param>
    /// <returns>The parameter that expires first.</returns>
    /// <remarks>
    /// <para>This method orders deadlines as <see cref="Compare"/> does.
    /// If <see cref="Compare"/> reports the two deadlines as expiring together,
    /// this method returns <paramref name="first"/>.</para>
    /// </remarks>
    public static Deadline EarliestOf(Deadline first, Deadline second) => Compare(second, first) < 0 ? second : first;
}
