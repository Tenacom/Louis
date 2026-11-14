// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET5_0_OR_GREATER

using System;
using System.Globalization;
using CommunityToolkit.Diagnostics;

namespace Louis.Processes;

/// <summary>
/// <para>The exception that <see cref="IProcessRunner.RunAsync"/> throws when a process exits with a code other than 0
/// and <see cref="ProcessRunOptions.ThrowOnNonZeroExitCode"/> is <see langword="true"/>.</para>
/// <para>This type is not available in the <c>netstandard</c> and .NET Framework builds of Louis,
/// as <see cref="ProcessRunner"/> is not.</para>
/// </summary>
/// <remarks>
/// <para>The message of the exception names the exit code and the command line, and nothing else.
/// <see cref="Result"/> holds the whole text of both streams, for a caller that wants to show more.</para>
/// </remarks>
#pragma warning disable CA1032 // Implement standard exception constructors - The exception always carries a ProcessResult.
public class ProcessFailedException : Exception
#pragma warning restore CA1032 // Implement standard exception constructors
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProcessFailedException"/> class.
    /// </summary>
    /// <param name="result">The outcome of the run.</param>
    /// <exception cref="ArgumentNullException"><paramref name="result"/> is <see langword="null"/>.</exception>
    public ProcessFailedException(ProcessResult result)
        : base(FormatMessage(result))
    {
        Result = result;
    }

    /// <summary>
    /// Gets the outcome of the run.
    /// </summary>
    public ProcessResult Result { get; }

    private static string FormatMessage(ProcessResult result)
    {
        Guard.IsNotNull(result);

        var exitCode = result.ExitCode.ToString(CultureInfo.InvariantCulture);
        return $"Process exited with code {exitCode}: {result.CommandLine}";
    }
}

#endif
