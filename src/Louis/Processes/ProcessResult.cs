// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET8_0_OR_GREATER

using System;
using Louis.Diagnostics;

namespace Louis.Processes;

/// <summary>
/// <para>Describes the outcome of a run of <see cref="IProcessRunner.RunAsync"/>.</para>
/// <para>This type is not available in the <c>netstandard</c> and .NET Framework builds of Louis,
/// as <see cref="ProcessRunner"/> is not.</para>
/// </summary>
public sealed class ProcessResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProcessResult"/> class.
    /// </summary>
    /// <param name="commandLine">The command line of the process, for display.</param>
    /// <param name="exitCode">The exit code of the process.</param>
    /// <param name="standardOutput">The text the process wrote to its standard output.</param>
    /// <param name="standardError">The text the process wrote to its standard error.</param>
    /// <param name="elapsed">The time the run took.</param>
    /// <exception cref="ArgumentNullException">
    /// <para><paramref name="commandLine"/> is <see langword="null"/>.</para>
    /// <para>- or -</para>
    /// <para><paramref name="standardOutput"/> is <see langword="null"/>.</para>
    /// <para>- or -</para>
    /// <para><paramref name="standardError"/> is <see langword="null"/>.</para>
    /// </exception>
    public ProcessResult(
        string commandLine,
        int exitCode,
        string standardOutput,
        string standardError,
        TimeSpan elapsed)
    {
        CommandLine = Param.NotNull(commandLine);
        ExitCode = exitCode;
        StandardOutput = Param.NotNull(standardOutput);
        StandardError = Param.NotNull(standardError);
        Elapsed = elapsed;
    }

    /// <summary>
    /// Gets the command line of the process, for display.
    /// </summary>
    /// <value>
    /// The executable and the arguments of the run, as <see cref="CommandLineFormatter.Format"/> shows them.
    /// </value>
    public string CommandLine { get; }

    /// <summary>
    /// Gets the exit code of the process.
    /// </summary>
    public int ExitCode { get; }

    /// <summary>
    /// Gets the text the process wrote to its standard output.
    /// </summary>
    /// <value>
    /// An empty string when <see cref="ProcessRunOptions.InheritStandardStreams"/> is <see langword="true"/>;
    /// otherwise, every line the process wrote, each followed by <see cref="Environment.NewLine"/>,
    /// whatever line terminator the process wrote.
    /// </value>
    public string StandardOutput { get; }

    /// <summary>
    /// Gets the text the process wrote to its standard error.
    /// </summary>
    /// <value>
    /// An empty string when <see cref="ProcessRunOptions.InheritStandardStreams"/> is <see langword="true"/>;
    /// otherwise, every line the process wrote, each followed by <see cref="Environment.NewLine"/>,
    /// whatever line terminator the process wrote.
    /// </value>
    public string StandardError { get; }

    /// <summary>
    /// Gets the time the run took.
    /// </summary>
    /// <value>
    /// The time from just before the process started to just after it exited.
    /// </value>
    public TimeSpan Elapsed { get; }
}

#endif
