// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

/// <summary>
/// The program that the tests of <c>Louis.Processes</c> run as a child process.
/// Each argument is one instruction, of the form <c>name</c> or <c>name:value</c>. The program runs them in order.
/// </summary>
// The coverage collector follows the tests into their child processes, and a test project is not a test subject.
[ExcludeFromCodeCoverage(Justification = "This program is test code: the tests of Louis.Processes run it as their child process.")]
internal static class Program
{
    private const int UnknownInstructionExitCode = 99;

    private static int Main(string[] args)
    {
        for (var i = 0; i < args.Length; i++)
        {
            var (name, value) = SplitInstruction(args[i]);
            switch (name)
            {
                // Writes the value and a line terminator to standard output.
                case "out":
                    Console.Out.WriteLine(value);
                    break;

                // Writes the value and a line terminator to standard error.
                case "err":
                    Console.Error.WriteLine(value);
                    break;

                // Writes the environment variable the value names to standard output.
                case "env":
                    Console.Out.WriteLine(Environment.GetEnvironmentVariable(value) ?? "<unset>");
                    break;

                // Writes "yes" or "no" to standard output: whether the file the value names exists.
                // A relative path resolves against the working directory.
                case "exists":
                    Console.Out.WriteLine(File.Exists(value) ? "yes" : "no");
                    break;

                // Writes each line of standard input to standard output, with an "in:" prefix, then "eof".
                case "stdin":
                    EchoStandardInput();
                    break;

                // Writes the value and a line feed to standard output as UTF-16, whatever the encoding of the console.
                case "utf16":
                    WriteUtf16Line(value);
                    break;

                // Writes as many numbered lines as the value says, each to standard output and to standard error.
                case "flood":
                    Flood(int.Parse(value, CultureInfo.InvariantCulture));
                    break;

                // Writes each of the following arguments to standard output, one per line, and exits.
                case "echo":
                    foreach (var arg in args.AsSpan(i + 1))
                    {
                        Console.Out.WriteLine(arg);
                    }

                    return 0;

                // Starts this program again with the "sleep" instruction, and writes "pid:" and its process id to standard output.
                case "spawn":
                    Spawn();
                    break;

                // Never returns.
                case "sleep":
                    Thread.Sleep(Timeout.Infinite);
                    break;

                // Exits with the value as the exit code.
                case "exit":
                    return int.Parse(value, CultureInfo.InvariantCulture);

                default:
                    Console.Error.WriteLine($"Unknown instruction: {args[i]}");
                    return UnknownInstructionExitCode;
            }
        }

        return 0;
    }

    private static (string Name, string Value) SplitInstruction(string instruction)
    {
        var separatorIndex = instruction.IndexOf(':', StringComparison.Ordinal);
        return separatorIndex < 0
            ? (instruction, string.Empty)
            : (instruction[..separatorIndex], instruction[(separatorIndex + 1)..]);
    }

    private static void EchoStandardInput()
    {
        while (Console.In.ReadLine() is { } line)
        {
            Console.Out.WriteLine("in:" + line);
        }

        Console.Out.WriteLine("eof");
    }

    private static void WriteUtf16Line(string text)
    {
        using var standardOutput = Console.OpenStandardOutput();
        standardOutput.Write(Encoding.Unicode.GetBytes(text + "\n"));
    }

    private static void Flood(int lineCount)
    {
        for (var i = 0; i < lineCount; i++)
        {
            var line = string.Create(CultureInfo.InvariantCulture, $"{i:D8} {new string('x', 91)}");
            Console.Out.WriteLine(line);
            Console.Error.WriteLine(line);
        }
    }

    private static void Spawn()
    {
        var host = Environment.ProcessPath ?? throw new InvalidOperationException("The process has no path.");
        var startInfo = new ProcessStartInfo(host) { UseShellExecute = false };
        startInfo.ArgumentList.Add(typeof(Program).Assembly.Location);
        startInfo.ArgumentList.Add("sleep");
        using var process = Process.Start(startInfo) ?? throw new InvalidOperationException("No process was started.");
        Console.Out.WriteLine(string.Create(CultureInfo.InvariantCulture, $"pid:{process.Id}"));
    }
}
