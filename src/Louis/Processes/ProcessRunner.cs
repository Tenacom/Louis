// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET8_0_OR_GREATER

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Diagnostics;

namespace Louis.Processes;

/// <summary>
/// <para>Runs a child process with the <see cref="Process"/> class, waits for it to exit, and returns its outcome.</para>
/// <para>This type is not available in the <c>netstandard</c> and .NET Framework builds of Louis,
/// because their BCL has no <see cref="Process.WaitForExitAsync"/>.</para>
/// </summary>
/// <remarks>
/// <para>An instance has no state, so one instance can serve a whole program, and any number of runs at the same time.</para>
/// <para>A run has one of two modes, which <see cref="ProcessRunOptions.InheritStandardStreams"/> selects.
/// In capture mode, the default, the runner redirects the standard streams of the child.
/// In inherited mode, the child shares the standard streams of the current process.</para>
/// <para>In capture mode, the runner reads the standard output and the standard error of the child
/// line by line, both at the same time, so that the child never blocks on a full pipe.
/// The run ends when the child has exited and both streams have ended.
/// A process that the child started, and that still holds one of the streams, delays the end of the run.
/// The child gets no console window, even when the current process has no console.</para>
/// <para>In inherited mode, the runner reads nothing.
/// While the child runs, the runner keeps Ctrl-C from ending the current process: the child receives the same Ctrl-C
/// and decides how to shut down, and the runner returns its exit code.
/// Inherited mode is of no use in a program without a console.</para>
/// <para>When the <see cref="CancellationToken"/> of a run is signaled before the run ends,
/// the runner throws an <see cref="OperationCanceledException"/>.
/// When the child is still running, the runner first kills it, and every process it started.
/// When the child has exited, the runner kills nothing, and stops waiting for the streams to end.</para>
/// <para>A child that cannot start throws what <see cref="Process.Start()"/> throws,
/// usually a <see cref="System.ComponentModel.Win32Exception"/>.</para>
/// </remarks>
/// <seealso cref="ProcessRunOptions"/>
public sealed class ProcessRunner : IProcessRunner
{
    private const int StandardInputBufferSize = 16 * 1024;

    private static readonly ConsoleCancelEventHandler KeepCurrentProcessRunningHandler = KeepCurrentProcessRunning;

    /// <inheritdoc/>
    public Task<ProcessResult> RunAsync(
        string executable,
        IEnumerable<string> arguments,
        ProcessRunOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        Guard.IsNotNull(executable);
        Guard.IsNotNull(arguments);

        // Enumerate the arguments once, so that the command line and the child get the same ones.
        string[] argumentArray = [.. arguments];
        var commandLine = CommandLineFormatter.Format(executable, argumentArray);
        return RunCoreAsync(executable, argumentArray, commandLine, options ?? new ProcessRunOptions(), cancellationToken);
    }

    private static async Task<ProcessResult> RunCoreAsync(
        string executable,
        string[] arguments,
        string commandLine,
        ProcessRunOptions options,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        using var process = new Process();
        process.StartInfo = CreateStartInfo(executable, arguments, options);
        var stopwatch = Stopwatch.StartNew();
        var (standardOutput, standardError) = options.InheritStandardStreams
            ? await RunInheritedAsync(process, cancellationToken).ConfigureAwait(false)
            : await RunCapturedAsync(process, options, cancellationToken).ConfigureAwait(false);

        var result = new ProcessResult(commandLine, process.ExitCode, standardOutput, standardError, stopwatch.Elapsed);
        if (result.ExitCode != 0 && options.ThrowOnNonZeroExitCode)
        {
            throw new ProcessFailedException(result);
        }

        return result;
    }

    private static ProcessStartInfo CreateStartInfo(string executable, string[] arguments, ProcessRunOptions options)
    {
        var workingDirectory = options.WorkingDirectory ?? string.Empty;
        var startInfo = new ProcessStartInfo(executable) { UseShellExecute = false, WorkingDirectory = workingDirectory };
        foreach (var argument in arguments)
        {
            startInfo.ArgumentList.Add(argument);
        }

        if (options.Environment is not null)
        {
            foreach (var (name, value) in options.Environment)
            {
                if (value is null)
                {
                    _ = startInfo.Environment.Remove(name);
                }
                else
                {
                    startInfo.Environment[name] = value;
                }
            }
        }

        if (options.InheritStandardStreams)
        {
            // CreateNoWindow stays off, because the child must reach the console of the current process.
            return startInfo;
        }

        // With CreateNoWindow off, a console child of a program without a console would open a console window.
        // With CreateNoWindow on, the child gets a console of its own, which starts with ConsoleUtility.SystemDefaultEncoding.
        var encoding = options.OutputEncoding ?? ConsoleUtility.SystemDefaultEncoding;
        startInfo.CreateNoWindow = true;
        startInfo.RedirectStandardInput = true;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;
        startInfo.StandardOutputEncoding = encoding;
        startInfo.StandardErrorEncoding = encoding;
        return startInfo;
    }

    private static async Task<(string StandardOutput, string StandardError)> RunInheritedAsync(
        Process process,
        CancellationToken cancellationToken)
    {
        // The child receives the same Ctrl-C, and the runner must survive it to return the exit code of the child.
        Console.CancelKeyPress += KeepCurrentProcessRunningHandler;
        try
        {
            _ = process.Start();
            if (!await WaitForExitOrKillAsync(process, cancellationToken).ConfigureAwait(false))
            {
                throw new OperationCanceledException(cancellationToken);
            }
        }
        finally
        {
            Console.CancelKeyPress -= KeepCurrentProcessRunningHandler;
        }

        return (string.Empty, string.Empty);
    }

    [ExcludeFromCodeCoverage(Justification = "Runs only when the console of the current process receives Ctrl-C or Ctrl-Break.")]
    private static void KeepCurrentProcessRunning(object? sender, ConsoleCancelEventArgs e) => e.Cancel = true;

    private static async Task<(string StandardOutput, string StandardError)> RunCapturedAsync(
        Process process,
        ProcessRunOptions options,
        CancellationToken cancellationToken)
    {
        _ = process.Start();

        // Canceling this source aborts the run. The token of the run cancels it, and so does a stream task that fails.
        // The child is then killed, instead of blocking on a pipe nobody reads, and the run waits for outputTask and errorTask alone.
        using var abortSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        var abortToken = abortSource.Token;
        Action cancelAbortSource = abortSource.Cancel;
        ExceptionDispatchInfo? failure = null;

        // The read of options.StandardInput is canceled when the run is aborted, and when the child exits.
        using var inputSource = CancellationTokenSource.CreateLinkedTokenSource(abortToken);
        var inputTask = WriteStandardInputAsync(process.StandardInput, options.StandardInput, Abort, inputSource.Token);
        var outputTask = ReadLinesAsync(process.StandardOutput, options.OnStandardOutputLine, Abort, abortToken);
        var errorTask = ReadLinesAsync(process.StandardError, options.OnStandardErrorLine, Abort, abortToken);
        _ = await WaitForExitOrKillAsync(process, abortToken).ConfigureAwait(false);

        // A child that has exited reads no more input. A read of options.StandardInput that is still pending would never end.
        await inputSource.CancelAsync().ConfigureAwait(false);

        // The streams end once the child has exited or has been killed, unless a process that the child started holds one.
        // An aborted run does not wait for that process.
        var streamsTask = Task.WhenAll(inputTask, outputTask, errorTask);
        _ = await Task.WhenAny(streamsTask, Task.Delay(Timeout.Infinite, abortToken)).ConfigureAwait(false);
        if (abortToken.IsCancellationRequested)
        {
            // Nothing takes the outcome of the stream tasks of an aborted run, so an exception of theirs would count as unobserved.
            _ = streamsTask.ContinueWith(
                static task => _ = task.Exception,
                CancellationToken.None,
                TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default);

            // A line callback may be running, and the caller must not find it running after the run has thrown.
            // abortToken ends the read that follows the callback, so each task ends as soon as its callback returns.
            // The run does not wait for inputTask, because the stream of the caller may ignore its token.
            await ((Task)outputTask).ConfigureAwait(ConfigureAwaitOptions.SuppressThrowing);
            await ((Task)errorTask).ConfigureAwait(ConfigureAwaitOptions.SuppressThrowing);
            failure?.Throw();
            throw new OperationCanceledException(cancellationToken);
        }

        // A run that was not aborted gets here when every stream task has ended, and none has failed.
        return (await outputTask.ConfigureAwait(false), await errorTask.ConfigureAwait(false));

        // Aborts the run because of a failure of a stream task. The first failure is the exception that the run throws.
        void Abort(Exception exception)
        {
            // An aborted run does not wait for inputTask, and may have disposed abortSource when inputTask fails.
            if (abortToken.IsCancellationRequested)
            {
                return;
            }

            _ = Interlocked.CompareExchange(ref failure, ExceptionDispatchInfo.Capture(exception), null);
            cancelAbortSource();
        }
    }

    private static async Task WriteStandardInputAsync(
        StreamWriter standardInput,
        Stream? input,
        Action<Exception> abort,
        CancellationToken cancellationToken)
    {
        // An IOException of the input stream is a failure. An IOException of the pipe means that the child stopped reading.
        var readingInput = false;
        try
        {
            // Disposing the writer closes the standard input of the child, which then finds it at its end.
            await using (standardInput.ConfigureAwait(false))
            {
                if (input is not null)
                {
                    var buffer = new byte[StandardInputBufferSize];
                    while (true)
                    {
                        readingInput = true;
                        var count = await input.ReadAsync(buffer, cancellationToken).ConfigureAwait(false);
                        readingInput = false;
                        if (count == 0)
                        {
                            break;
                        }

                        await standardInput.BaseStream.WriteAsync(buffer.AsMemory(0, count), cancellationToken).ConfigureAwait(false);
                    }
                }
            }
        }
        catch (IOException) when (!readingInput)
        {
            // The child closed its standard input, or exited, before it read all the data.
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            // Either the child has exited, or RunCapturedAsync kills it and reports the cancellation or the failure that caused it.
        }
        catch (Exception exception)
        {
            abort(exception);
            throw;
        }
    }

    private static async Task<string> ReadLinesAsync(
        StreamReader reader,
        Action<string>? onLine,
        Action<Exception> abort,
        CancellationToken abortToken)
    {
        try
        {
            var text = new StringBuilder();
            while (await reader.ReadLineAsync(abortToken).ConfigureAwait(false) is { } line)
            {
                // The reader returns a line that it holds already, even when the token is signaled.
                // An aborted run waits only for a callback that is running, so that line must not reach the callback.
                if (abortToken.IsCancellationRequested)
                {
                    break;
                }

                _ = text.AppendLine(line);
                onLine?.Invoke(line);
            }

            return text.ToString();
        }
        catch (Exception exception)
        {
            abort(exception);
            throw;
        }
    }

    // Returns false when the token was signaled before the child exited. The child and its process tree are then killed.
    private static async Task<bool> WaitForExitOrKillAsync(Process process, CancellationToken cancellationToken)
    {
        try
        {
            await process.WaitForExitAsync(cancellationToken).ConfigureAwait(false);
            return true;
        }
        catch (OperationCanceledException)
        {
            process.Kill(entireProcessTree: true);
            await process.WaitForExitAsync(CancellationToken.None).ConfigureAwait(false);
            return false;
        }
    }
}

#endif
