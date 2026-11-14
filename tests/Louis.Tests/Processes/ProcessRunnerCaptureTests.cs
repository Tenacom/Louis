// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET5_0_OR_GREATER

using System.ComponentModel;
using System.Diagnostics;
using Louis.Processes;
using TUnit.Assertions.Enums;

[Timeout(60_000)]
internal sealed class ProcessRunnerCaptureTests
{
    private static readonly string NewLine = Environment.NewLine;

    private readonly ProcessRunner _runner = new();

    [Test]
    public async Task RunAsync_CapturesStandardOutputAndStandardError(CancellationToken cancellationToken)
    {
        var arguments = ChildProcess.Arguments("out:first", "err:problem", "out:second");

        var result = await _runner.RunAsync(ChildProcess.Executable, arguments, cancellationToken: cancellationToken);

        await Assert.That(result.ExitCode).IsEqualTo(0);
        await Assert.That(result.StandardOutput).IsEqualTo($"first{NewLine}second{NewLine}");
        await Assert.That(result.StandardError).IsEqualTo($"problem{NewLine}");
        await Assert.That(result.CommandLine).IsEqualTo(CommandLineFormatter.Format(ChildProcess.Executable, arguments));
        await Assert.That(result.Elapsed).IsGreaterThan(TimeSpan.Zero);
    }

    [Test]
    public async Task RunAsync_WithCallbacks_CallsEachOncePerLine(CancellationToken cancellationToken)
    {
        List<string> outputLines = [];
        List<string> errorLines = [];
        var options = new ProcessRunOptions { OnStandardOutputLine = outputLines.Add, OnStandardErrorLine = errorLines.Add };

        var result = await _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("out:first", "err:problem", "out:second", "err:trouble"),
            options,
            cancellationToken);

        string[] expectedOutputLines = ["first", "second"];
        string[] expectedErrorLines = ["problem", "trouble"];
        await Assert.That(outputLines).IsEquivalentTo(expectedOutputLines, CollectionOrdering.Matching);
        await Assert.That(errorLines).IsEquivalentTo(expectedErrorLines, CollectionOrdering.Matching);
        await Assert.That(result.StandardOutput).IsEqualTo($"first{NewLine}second{NewLine}");
        await Assert.That(result.StandardError).IsEqualTo($"problem{NewLine}trouble{NewLine}");
    }

    [Test]
    public async Task RunAsync_WithMoreOutputThanAPipeHolds_CapturesBothStreams(CancellationToken cancellationToken)
    {
        const int LineCount = 20_000;
        const int LineLength = 100;

        var result = await _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments($"flood:{LineCount}"),
            cancellationToken: cancellationToken);

        var expectedLength = LineCount * (LineLength + NewLine.Length);
        await Assert.That(result.StandardOutput.Length).IsEqualTo(expectedLength);
        await Assert.That(result.StandardError.Length).IsEqualTo(expectedLength);
        await Assert.That(result.StandardOutput).StartsWith("00000000 x");
        await Assert.That(result.StandardError).EndsWith($"x{NewLine}");
    }

    [Test]
    public async Task RunAsync_PassesEachArgumentAsOneArgument(CancellationToken cancellationToken)
    {
        string[] arguments = ["two words", string.Empty, "quo\"te", @"back\slash", "tab\there", @"trailing\"];

        var result = await _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments(["echo", .. arguments]),
            cancellationToken: cancellationToken);

        await Assert.That(result.StandardOutput).IsEqualTo(string.Concat(arguments.Select(argument => argument + NewLine)));
    }

    [Test]
    public async Task RunAsync_EnumeratesArgumentsOnce(CancellationToken cancellationToken)
    {
        var arguments = new RecordingEnumerable<string>(ChildProcess.Arguments("out:done"));

        _ = await _runner.RunAsync(ChildProcess.Executable, arguments, cancellationToken: cancellationToken);

        await Assert.That(arguments.GetEnumeratorCallCount).IsEqualTo(1);
    }

    [Test]
    [NotInParallel]
    public async Task RunAsync_WithEnvironment_AddsReplacesAndRemovesVariables(CancellationToken cancellationToken)
    {
        const string Added = "LOUIS_TESTS_ADDED";
        const string Replaced = "LOUIS_TESTS_REPLACED";
        const string Removed = "LOUIS_TESTS_REMOVED";
        const string Inherited = "LOUIS_TESTS_INHERITED";
        Environment.SetEnvironmentVariable(Replaced, "original");
        Environment.SetEnvironmentVariable(Removed, "original");
        Environment.SetEnvironmentVariable(Inherited, "original");
        try
        {
            var environment = new Dictionary<string, string?> { [Added] = "added", [Replaced] = "replaced", [Removed] = null };

            var result = await _runner.RunAsync(
                ChildProcess.Executable,
                ChildProcess.Arguments($"env:{Added}", $"env:{Replaced}", $"env:{Removed}", $"env:{Inherited}"),
                new ProcessRunOptions { Environment = environment },
                cancellationToken);

            await Assert.That(result.StandardOutput).IsEqualTo($"added{NewLine}replaced{NewLine}<unset>{NewLine}original{NewLine}");
        }
        finally
        {
            Environment.SetEnvironmentVariable(Replaced, null);
            Environment.SetEnvironmentVariable(Removed, null);
            Environment.SetEnvironmentVariable(Inherited, null);
        }
    }

    [Test]
    public async Task RunAsync_WithWorkingDirectory_StartsChildInIt(CancellationToken cancellationToken)
    {
        // The marker file exists in the working directory alone, so the child finds it only when it starts there.
        var markerName = $"marker-{Guid.NewGuid():N}.txt";
        var workingDirectory = Directory.CreateTempSubdirectory("louis-tests-");
        try
        {
            await File.WriteAllTextAsync(Path.Combine(workingDirectory.FullName, markerName), string.Empty, cancellationToken);
            var arguments = ChildProcess.Arguments($"exists:{markerName}");

            var result = await _runner.RunAsync(
                ChildProcess.Executable,
                arguments,
                new ProcessRunOptions { WorkingDirectory = workingDirectory.FullName },
                cancellationToken);
            var resultElsewhere = await _runner.RunAsync(ChildProcess.Executable, arguments, cancellationToken: cancellationToken);

            await Assert.That(result.StandardOutput).IsEqualTo($"yes{NewLine}");
            await Assert.That(resultElsewhere.StandardOutput).IsEqualTo($"no{NewLine}");
        }
        finally
        {
            workingDirectory.Delete(recursive: true);
        }
    }

    [Test]
    public async Task RunAsync_WithNonZeroExitCode_ThrowsProcessFailedException(CancellationToken cancellationToken)
    {
        var arguments = ChildProcess.Arguments("out:before", "err:problem", "exit:3");
        var commandLine = CommandLineFormatter.Format(ChildProcess.Executable, arguments);

        Task Act() => _runner.RunAsync(ChildProcess.Executable, arguments, cancellationToken: cancellationToken);

        var exception = await Assert.That(Act)
            .Throws<ProcessFailedException>()
            .WithMessage($"Process exited with code 3: {commandLine}", StringComparison.Ordinal);

        Debug.Assert(exception is not null, "Throws returns null only inside Assert.Multiple.");
        await Assert.That(exception.Result.ExitCode).IsEqualTo(3);
        await Assert.That(exception.Result.CommandLine).IsEqualTo(commandLine);
        await Assert.That(exception.Result.StandardOutput).IsEqualTo($"before{NewLine}");
        await Assert.That(exception.Result.StandardError).IsEqualTo($"problem{NewLine}");
    }

    [Test]
    public async Task RunAsync_WithNonZeroExitCodeAndNoThrow_ReturnsResult(CancellationToken cancellationToken)
    {
        var result = await _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("out:before", "exit:3"),
            new ProcessRunOptions { ThrowOnNonZeroExitCode = false },
            cancellationToken);

        await Assert.That(result.ExitCode).IsEqualTo(3);
        await Assert.That(result.StandardOutput).IsEqualTo($"before{NewLine}");
    }

    [Test]
    public async Task RunAsync_WithMissingExecutable_ThrowsWin32Exception(CancellationToken cancellationToken)
    {
        Task Act() => _runner.RunAsync("louis-tests-no-such-program", [], cancellationToken: cancellationToken);

        await Assert.That(Act).Throws<Win32Exception>();
    }

    [Test]
    public async Task RunAsync_WithNullExecutable_ThrowsArgumentNullException(CancellationToken cancellationToken)
    {
        // ! Null on purpose: testing null detection
        void Act() => _ = _runner.RunAsync(null!, [], cancellationToken: cancellationToken);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("executable");
    }

    [Test]
    public async Task RunAsync_WithNullArguments_ThrowsArgumentNullException(CancellationToken cancellationToken)
    {
        // ! Null on purpose: testing null detection
        void Act() => _ = _runner.RunAsync(ChildProcess.Executable, null!, cancellationToken: cancellationToken);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("arguments");
    }

    [Test]
    public async Task RunAsync_WithNullArgument_ThrowsArgumentException(CancellationToken cancellationToken)
    {
        // ! Null on purpose: testing null detection
        void Act() => _ = _runner.RunAsync(ChildProcess.Executable, ["first", null!], cancellationToken: cancellationToken);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("arguments");
    }
}

#endif
