// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET8_0_OR_GREATER

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Louis.Processes;

/// <summary>
/// <para>Holds the options of a run of <see cref="IProcessRunner.RunAsync"/>.</para>
/// <para>This type is not available in the <c>netstandard</c> and .NET Framework builds of Louis,
/// as <see cref="ProcessRunner"/> is not.</para>
/// </summary>
/// <remarks>
/// <para>A run has one of two modes, which <see cref="InheritStandardStreams"/> selects.</para>
/// <para>In capture mode, the default, the runner redirects the standard streams of the child:
/// it writes the standard input of the child, and reads its standard output and its standard error.</para>
/// <para>In inherited mode, the child shares the standard streams of the current process, and the runner reads nothing.</para>
/// </remarks>
public sealed class ProcessRunOptions
{
    /// <summary>
    /// Gets the changes to make to the environment of the child.
    /// </summary>
    /// <value>
    /// A dictionary of environment variables, or <see langword="null"/> for no change. The default is <see langword="null"/>.
    /// </value>
    /// <remarks>
    /// <para>The child starts with the environment of the current process.
    /// A variable with a non-<see langword="null"/> value is added to it, or replaces the variable of the same name.
    /// A variable with a <see langword="null"/> value is removed from it.</para>
    /// </remarks>
    public IReadOnlyDictionary<string, string?>? Environment { get; init; }

    /// <summary>
    /// Gets the working directory of the child.
    /// </summary>
    /// <value>
    /// The path of a directory, or <see langword="null"/> to use the working directory of the current process.
    /// The default is <see langword="null"/>.
    /// </value>
    public string? WorkingDirectory { get; init; }

    /// <summary>
    /// Gets a value indicating whether the child shares the standard streams of the current process.
    /// </summary>
    /// <value>
    /// <see langword="true"/> for inherited mode: the child shares the standard streams of the current process.
    /// <see langword="false"/> for capture mode: the runner redirects the standard streams of the child,
    /// and reads what the child writes. The default is <see langword="false"/>.
    /// </value>
    /// <remarks>
    /// <para>When this property is <see langword="true"/>, the runner ignores <see cref="StandardInput"/>,
    /// <see cref="OutputEncoding"/>, <see cref="OnStandardOutputLine"/>, and <see cref="OnStandardErrorLine"/>,
    /// and both texts of the <see cref="ProcessResult"/> are empty.</para>
    /// </remarks>
    public bool InheritStandardStreams { get; init; }

    /// <summary>
    /// Gets the stream that holds the data for the standard input of the child.
    /// </summary>
    /// <value>
    /// A readable stream, or <see langword="null"/> for no data. The default is <see langword="null"/>.
    /// </value>
    /// <remarks>
    /// <para>The runner copies the stream to the standard input of the child, from the current position
    /// of the stream to its end, then closes the standard input of the child. The runner does not dispose the stream.
    /// With <see langword="null"/>, the child finds its standard input at its end.</para>
    /// <para>The runner ignores this property when <see cref="InheritStandardStreams"/> is <see langword="true"/>.</para>
    /// </remarks>
    public Stream? StandardInput { get; init; }

    /// <summary>
    /// Gets the encoding of the text that the child writes to its standard output and to its standard error.
    /// </summary>
    /// <value>
    /// An encoding, or <see langword="null"/> to use <see cref="ConsoleUtility.SystemDefaultEncoding"/>.
    /// The default is <see langword="null"/>.
    /// </value>
    /// <remarks>
    /// <para>The runner cannot know the encoding a child writes with. A console program that sets no encoding writes
    /// with the encoding of its console. For a child whose output the runner reads, that encoding is
    /// <see cref="ConsoleUtility.SystemDefaultEncoding"/>. Set this property for a child that writes with another encoding.</para>
    /// <para>The runner ignores this property when <see cref="InheritStandardStreams"/> is <see langword="true"/>.</para>
    /// </remarks>
    public Encoding? OutputEncoding { get; init; }

    /// <summary>
    /// Gets the callback that receives each line the child writes to its standard output.
    /// </summary>
    /// <value>
    /// A callback, or <see langword="null"/> for none. The default is <see langword="null"/>.
    /// </value>
    /// <remarks>
    /// <para>The runner calls the callback once per line, as the line arrives,
    /// with the text of the line without its terminator.</para>
    /// <para>The runner calls the callback from a thread of the thread pool. It never calls the same callback
    /// twice at the same time, but it may call this callback and <see cref="OnStandardErrorLine"/> at the same time.</para>
    /// <para>The runner never calls the callback after <see cref="IProcessRunner.RunAsync"/> has returned its result or thrown.
    /// When the run is canceled, or fails, while the callback is running,
    /// <see cref="IProcessRunner.RunAsync"/> throws after the callback returns.</para>
    /// <para>When the callback throws an exception, the runner kills the child,
    /// and <see cref="IProcessRunner.RunAsync"/> throws the same exception.</para>
    /// <para>The runner ignores this property when <see cref="InheritStandardStreams"/> is <see langword="true"/>.</para>
    /// </remarks>
    public Action<string>? OnStandardOutputLine { get; init; }

    /// <summary>
    /// Gets the callback that receives each line the child writes to its standard error.
    /// </summary>
    /// <value>
    /// A callback, or <see langword="null"/> for none. The default is <see langword="null"/>.
    /// </value>
    /// <remarks>
    /// <para>The runner calls the callback once per line, as the line arrives,
    /// with the text of the line without its terminator.</para>
    /// <para>The runner calls the callback from a thread of the thread pool. It never calls the same callback
    /// twice at the same time, but it may call this callback and <see cref="OnStandardOutputLine"/> at the same time.</para>
    /// <para>The runner never calls the callback after <see cref="IProcessRunner.RunAsync"/> has returned its result or thrown.
    /// When the run is canceled, or fails, while the callback is running,
    /// <see cref="IProcessRunner.RunAsync"/> throws after the callback returns.</para>
    /// <para>When the callback throws an exception, the runner kills the child,
    /// and <see cref="IProcessRunner.RunAsync"/> throws the same exception.</para>
    /// <para>The runner ignores this property when <see cref="InheritStandardStreams"/> is <see langword="true"/>.</para>
    /// </remarks>
    public Action<string>? OnStandardErrorLine { get; init; }

    /// <summary>
    /// Gets a value indicating whether an exit code other than 0 throws a <see cref="ProcessFailedException"/>.
    /// </summary>
    /// <value>
    /// <see langword="true"/> to throw a <see cref="ProcessFailedException"/> when the child exits with a code other than 0;
    /// <see langword="false"/> to return the <see cref="ProcessResult"/> whatever the exit code.
    /// The default is <see langword="true"/>.
    /// </value>
    public bool ThrowOnNonZeroExitCode { get; init; } = true;
}

#endif
