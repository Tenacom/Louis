// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET5_0_OR_GREATER

/// <summary>
/// Builds the command that runs the <c>Louis.Tests.ChildProcess</c> program, which the build copies to the output directory.
/// <c>Program.cs</c> of that project lists the instructions the program takes.
/// </summary>
internal static class ChildProcess
{
    public const string Executable = "dotnet";

    public static string[] Arguments(params string[] instructions)
        => [Path.Combine(AppContext.BaseDirectory, "Louis.Tests.ChildProcess.dll"), .. instructions];
}

#endif
