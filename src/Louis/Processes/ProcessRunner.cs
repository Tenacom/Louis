// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET5_0_OR_GREATER

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
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
/// <para>When the <see cref="CancellationToken"/> of a run is signaled, the runner kills the child
/// and every process the child started, then throws an <see cref="OperationCanceledException"/>.</para>
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

        // A stream task that fails cancels this source. The child is then killed, instead of blocking on a pipe nobody reads.
        using var abortSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        var abortToken = abortSource.Token;
        Action abort = abortSource.Cancel;
        var inputTask = WriteStandardInputAsync(process.StandardInput, options.StandardInput, abort, abortToken);
        var outputTask = ReadLinesAsync(process.StandardOutput, options.OnStandardOutputLine, abort);
        var errorTask = ReadLinesAsync(process.StandardError, options.OnStandardErrorLine, abort);
        var exited = await WaitForExitOrKillAsync(process, abortToken).ConfigureAwait(false);

        // The streams end once the child has exited or has been killed. A stream task that failed throws here.
        await Task.WhenAll(inputTask, outputTask, errorTask).ConfigureAwait(false);
        if (!exited)
        {
            throw new OperationCanceledException(cancellationToken);
        }

        return (await outputTask.ConfigureAwait(false), await errorTask.ConfigureAwait(false));
    }

    private static async Task WriteStandardInputAsync(
        StreamWriter standardInput,
        Stream? input,
        Action abort,
        CancellationToken abortToken)
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
                        var count = await input.ReadAsync(buffer, abortToken).ConfigureAwait(false);
                        readingInput = false;
                        if (count == 0)
                        {
                            break;
                        }

                        await standardInput.BaseStream.WriteAsync(buffer.AsMemory(0, count), abortToken).ConfigureAwait(false);
                    }
                }
            }
        }
        catch (IOException) when (!readingInput)
        {
            // The child closed its standard input, or exited, before it read all the data.
        }
        catch (OperationCanceledException) when (abortToken.IsCancellationRequested)
        {
            // RunCapturedAsync kills the child, and reports the cancellation or the failure that caused it.
        }
        catch
        {
            abort();
            throw;
        }
    }

    private static async Task<string> ReadLinesAsync(StreamReader reader, Action<string>? onLine, Action abort)
    {
        try
        {
            var text = new StringBuilder();
            while (await reader.ReadLineAsync().ConfigureAwait(false) is { } line)
            {
                _ = text.AppendLine(line);
                onLine?.Invoke(line);
            }

            return text.ToString();
        }
        catch
        {
            abort();
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
