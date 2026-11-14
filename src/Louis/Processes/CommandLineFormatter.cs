// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET5_0_OR_GREATER

using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Diagnostics;

namespace Louis.Processes;

/// <summary>
/// <para>Formats the executable and the arguments of a process as one command line, for display.</para>
/// <para>This type is not available in the <c>netstandard</c> and .NET Framework builds of Louis,
/// as <see cref="ProcessRunner"/> is not.</para>
/// </summary>
public static class CommandLineFormatter
{
    /// <summary>
    /// Formats an executable and its arguments as one command line, for display.
    /// </summary>
    /// <param name="executable">The name or the path of the program.</param>
    /// <param name="arguments">The arguments of the program.</param>
    /// <returns>The executable, then each argument, separated by spaces.</returns>
    /// <exception cref="ArgumentNullException">
    /// <para><paramref name="executable"/> is <see langword="null"/>.</para>
    /// <para>- or -</para>
    /// <para><paramref name="arguments"/> is <see langword="null"/>.</para>
    /// </exception>
    /// <exception cref="ArgumentException"><paramref name="arguments"/> holds a <see langword="null"/> item.</exception>
    /// <remarks>
    /// <para>An item that is empty, or that holds a space, a tab, or a double quote, is enclosed in double quotes,
    /// and each double quote in it is preceded by a backslash. Any other item is shown as it is.</para>
    /// <para>The result is meant to be read by a person. No shell and no program is guaranteed to split it
    /// back into the same items, because the rules for that differ between operating systems.</para>
    /// </remarks>
    public static string Format(string executable, IEnumerable<string> arguments)
    {
        Guard.IsNotNull(executable);
        Guard.IsNotNull(arguments);

        var result = new StringBuilder();
        AppendItem(result, executable);
        foreach (var argument in arguments)
        {
            if (argument is null)
            {
                throw new ArgumentException("An argument of a process cannot be null.", nameof(arguments));
            }

            _ = result.Append(' ');
            AppendItem(result, argument);
        }

        return result.ToString();
    }

    private static void AppendItem(StringBuilder result, string item)
    {
        var needsQuotes = item.Length == 0 || item.AsSpan().IndexOfAny(' ', '\t', '"') >= 0;
        if (!needsQuotes)
        {
            _ = result.Append(item);
            return;
        }

        _ = result.Append('"').Append(item.Replace("\"", "\\\"", StringComparison.Ordinal)).Append('"');
    }
}

#endif
