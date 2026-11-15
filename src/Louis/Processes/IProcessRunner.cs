// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET5_0_OR_GREATER

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Louis.Processes;

/// <summary>
/// <para>Runs a child process, waits for it to exit, and returns its outcome.</para>
/// <para>This type is not available in the <c>netstandard</c> and .NET Framework builds of Louis,
/// as <see cref="ProcessRunner"/> is not.</para>
/// </summary>
/// <seealso cref="ProcessRunner"/>
public interface IProcessRunner
{
    /// <summary>
    /// Asynchronously runs a child process and waits for it to exit.
    /// </summary>
    /// <param name="executable">The name or the path of the program to run.</param>
    /// <param name="arguments">The arguments of the program.
    /// Each item reaches the program as one argument, whatever characters it holds.</param>
    /// <param name="options">The options of the run, or <see langword="null"/> to use the default value of every option.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that, when signaled, ends the run.</param>
    /// <returns>A <see cref="Task{TResult}"/> whose result describes the outcome of the run.</returns>
    /// <exception cref="ArgumentNullException">
    /// <para><paramref name="executable"/> is <see langword="null"/>.</para>
    /// <para>- or -</para>
    /// <para><paramref name="arguments"/> is <see langword="null"/>.</para>
    /// </exception>
    /// <exception cref="ArgumentException"><paramref name="arguments"/> holds a <see langword="null"/> item.</exception>
    /// <exception cref="ProcessFailedException">The process exited with a code other than 0,
    /// and <see cref="ProcessRunOptions.ThrowOnNonZeroExitCode"/> is <see langword="true"/>.</exception>
    /// <exception cref="OperationCanceledException"><paramref name="cancellationToken"/> was signaled
    /// before the run ended.</exception>
    Task<ProcessResult> RunAsync(
        string executable,
        IEnumerable<string> arguments,
        ProcessRunOptions? options = null,
        CancellationToken cancellationToken = default);
}

#endif
