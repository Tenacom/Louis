// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;

namespace Louis.Processes;

/// <summary>
/// Describes one run that a <see cref="FakeProcessRunner"/> recorded.
/// </summary>
/// <seealso cref="FakeProcessRunner.Runs"/>
public sealed class FakeProcessRun
{
    internal FakeProcessRun(string executable, IReadOnlyList<string> arguments, ProcessRunOptions options)
    {
        Executable = executable;
        Arguments = arguments;
        Options = options;
    }

    /// <summary>
    /// Gets the name or the path of the program that the run received.
    /// </summary>
    public string Executable { get; }

    /// <summary>
    /// Gets the arguments of the program that the run received.
    /// </summary>
    /// <value>
    /// A copy of the arguments, made when the run started.
    /// </value>
    public IReadOnlyList<string> Arguments { get; }

    /// <summary>
    /// Gets the options of the run.
    /// </summary>
    /// <value>
    /// The options that the run received. When the run received <see langword="null"/>,
    /// an instance with the default value of every option.
    /// </value>
    public ProcessRunOptions Options { get; }
}
