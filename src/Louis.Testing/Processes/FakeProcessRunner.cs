// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Louis.Processes;

/// <summary>
/// A test double of <see cref="IProcessRunner"/> that starts no process:
/// it records each run, and returns the outcome that a callback provides.
/// </summary>
/// <remarks>
/// <para><see cref="Runs"/> lists the recorded runs. <see cref="OnRun"/> provides the outcome of each run.
/// Without it, every run succeeds and has no output.</para>
/// <para>The fake treats the outcome of a run as <see cref="ProcessRunner"/> treats the outcome of a child,
/// so that the code under test sees the same behavior from both:</para>
/// <list type="bullet">
/// <item><description>When <see cref="ProcessRunOptions.InheritStandardStreams"/> is <see langword="false"/>, the fake calls
/// <see cref="ProcessRunOptions.OnStandardOutputLine"/> once per line of the standard output,
/// then <see cref="ProcessRunOptions.OnStandardErrorLine"/> once per line of the standard error.
/// Each text of the <see cref="ProcessResult"/> holds every line, followed by <see cref="Environment.NewLine"/>,
/// whatever line terminator <see cref="OnRun"/> wrote.</description></item>
/// <item><description>When <see cref="ProcessRunOptions.InheritStandardStreams"/> is <see langword="true"/>,
/// the fake calls neither callback, and both texts of the <see cref="ProcessResult"/> are empty.</description></item>
/// <item><description>When the exit code is not 0 and <see cref="ProcessRunOptions.ThrowOnNonZeroExitCode"/>
/// is <see langword="true"/>, <see cref="RunAsync"/> throws a <see cref="ProcessFailedException"/>.</description></item>
/// <item><description>When the <see cref="CancellationToken"/> of a run is signaled, <see cref="RunAsync"/> throws
/// an <see cref="OperationCanceledException"/>. A token that is signaled when the run starts stands for a child
/// that never started, and the fake does not record the run. A token that <see cref="OnRun"/> or a line callback signals
/// stands for a child that was killed.</description></item>
/// <item><description>When <see cref="OnRun"/> or a line callback throws an exception, <see cref="RunAsync"/> throws
/// the same exception. An exception of <see cref="OnRun"/> stands for a child that cannot start.</description></item>
/// </list>
/// <para>The fake reads nothing from <see cref="ProcessRunOptions.StandardInput"/>, and makes no use of
/// <see cref="ProcessRunOptions.Environment"/>, <see cref="ProcessRunOptions.WorkingDirectory"/>,
/// and <see cref="ProcessRunOptions.OutputEncoding"/>. A test finds them in the <see cref="FakeProcessRun.Options"/>
/// of the recorded run.</para>
/// <para>A run ends before <see cref="RunAsync"/> returns, and the fake calls every callback from the calling thread.
/// One instance can serve any number of runs at the same time.</para>
/// </remarks>
public sealed class FakeProcessRunner : IProcessRunner
{
    private readonly Lock _runsLock = new();
    private readonly List<FakeProcessRun> _runs = [];

    /// <summary>
    /// Gets the runs that the fake recorded, in the order they started.
    /// </summary>
    /// <value>
    /// A copy of the list of runs, which later runs do not change.
    /// </value>
    public IReadOnlyList<FakeProcessRun> Runs
    {
        get
        {
            lock (_runsLock)
            {
                return [.. _runs];
            }
        }
    }

    /// <summary>
    /// Gets the callback that provides the outcome of each run.
    /// </summary>
    /// <value>
    /// A callback, or <see langword="null"/> for none. The default is <see langword="null"/>.
    /// </value>
    /// <remarks>
    /// <para>The callback receives the executable, the arguments, and the options of the run,
    /// as <see cref="FakeProcessRun"/> holds them, and returns the outcome of the child it stands for:
    /// the exit code, and the text the child writes to each stream.</para>
    /// <para>With <see langword="null"/>, the outcome of every run has the exit code 0, two empty texts,
    /// the command line that <see cref="CommandLineFormatter.Format"/> returns, and an elapsed time of zero.</para>
    /// </remarks>
    public Func<string, IReadOnlyList<string>, ProcessRunOptions, ProcessResult>? OnRun { get; init; }

    /// <inheritdoc/>
    public Task<ProcessResult> RunAsync(
        string executable,
        IEnumerable<string> arguments,
        ProcessRunOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(executable);
        ArgumentNullException.ThrowIfNull(arguments);

        // Enumerate the arguments once, as ProcessRunner does. A null argument throws here, as it does there.
        string[] argumentArray = [.. arguments];
        var commandLine = CommandLineFormatter.Format(executable, argumentArray);
        var run = new FakeProcessRun(executable, argumentArray, options ?? new ProcessRunOptions());
        return RunCoreAsync(run, commandLine, cancellationToken);
    }

    private static (string StandardOutput, string StandardError) ReplayStreams(
        ProcessResult outcome,
        ProcessRunOptions options,
        CancellationToken cancellationToken)
    {
        var standardOutput = ReplayLines(outcome.StandardOutput, options.OnStandardOutputLine, cancellationToken);
        var standardError = ReplayLines(outcome.StandardError, options.OnStandardErrorLine, cancellationToken);
        return (standardOutput, standardError);
    }

    // Splits a text into lines as the StreamReader of ProcessRunner does, and ends every line with Environment.NewLine.
    private static string ReplayLines(string text, Action<string>? onLine, CancellationToken cancellationToken)
    {
        var result = new StringBuilder();
        using var reader = new StringReader(text);
        while (reader.ReadLine() is { } line)
        {
            _ = result.AppendLine(line);
            onLine?.Invoke(line);
            cancellationToken.ThrowIfCancellationRequested();
        }

        return result.ToString();
    }

    // The method awaits nothing. It is async so that its task holds an exception or a cancellation,
    // as the task of ProcessRunner does.
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    private async Task<ProcessResult> RunCoreAsync(FakeProcessRun run, string commandLine, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        cancellationToken.ThrowIfCancellationRequested();
        lock (_runsLock)
        {
            _runs.Add(run);
        }

        var options = run.Options;
        var outcome = OnRun is { } onRun
            ? onRun(run.Executable, run.Arguments, options)
            : new ProcessResult(commandLine, 0, string.Empty, string.Empty, TimeSpan.Zero);

        // A callback that signals the token stands for a cancellation while the child runs.
        cancellationToken.ThrowIfCancellationRequested();
        var (standardOutput, standardError) = options.InheritStandardStreams
            ? (string.Empty, string.Empty)
            : ReplayStreams(outcome, options, cancellationToken);

        var result = new ProcessResult(outcome.CommandLine, outcome.ExitCode, standardOutput, standardError, outcome.Elapsed);
        if (result.ExitCode != 0 && options.ThrowOnNonZeroExitCode)
        {
            throw new ProcessFailedException(result);
        }

        return result;
    }
}
