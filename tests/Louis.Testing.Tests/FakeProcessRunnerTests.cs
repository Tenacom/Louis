// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Diagnostics;
using System.Globalization;
using Louis.Processes;
using TUnit.Assertions.Enums;

internal sealed class FakeProcessRunnerTests
{
    private const string CommandLine = "the command line of the outcome";

    private static readonly string NewLine = Environment.NewLine;
    private static readonly TimeSpan Elapsed = TimeSpan.FromSeconds(2);

    [Test]
    public async Task RunAsync_WithoutOnRun_SucceedsWithNoOutput()
    {
        var runner = new FakeProcessRunner();

        var result = await runner.RunAsync("tool", ["two words"]);

        await Assert.That(result.ExitCode).IsEqualTo(0);
        await Assert.That(result.StandardOutput).IsEmpty();
        await Assert.That(result.StandardError).IsEmpty();
        await Assert.That(result.CommandLine).IsEqualTo("tool \"two words\"");
        await Assert.That(result.Elapsed).IsEqualTo(TimeSpan.Zero);
    }

    [Test]
    public async Task RunAsync_RecordsEachRunInOrder()
    {
        var runner = new FakeProcessRunner();
        var options = new ProcessRunOptions { WorkingDirectory = "somewhere" };

        _ = await runner.RunAsync("first", ["a", "b"], options);
        _ = await runner.RunAsync("second", []);

        var runs = runner.Runs;
        string[] expectedArguments = ["a", "b"];
        await Assert.That(runs.Count).IsEqualTo(2);
        await Assert.That(runs[0].Executable).IsEqualTo("first");
        await Assert.That(runs[0].Arguments).IsEquivalentTo(expectedArguments, CollectionOrdering.Matching);
        await Assert.That(runs[0].Options).IsSameReferenceAs(options);
        await Assert.That(runs[1].Executable).IsEqualTo("second");
        await Assert.That(runs[1].Arguments).IsEmpty();
    }

    [Test]
    public async Task RunAsync_WithNullOptions_RecordsDefaultOptions()
    {
        var runner = new FakeProcessRunner();

        _ = await runner.RunAsync("tool", []);

        var options = runner.Runs[0].Options;
        await Assert.That(options.InheritStandardStreams).IsFalse();
        await Assert.That(options.ThrowOnNonZeroExitCode).IsTrue();
        await Assert.That(options.WorkingDirectory).IsNull();
    }

    [Test]
    public async Task RunAsync_RecordsCopyOfArguments()
    {
        var runner = new FakeProcessRunner();
        List<string> arguments = ["original"];

        _ = await runner.RunAsync("tool", arguments);
        arguments[0] = "changed";

        string[] expectedArguments = ["original"];
        await Assert.That(runner.Runs[0].Arguments).IsEquivalentTo(expectedArguments, CollectionOrdering.Matching);
    }

    [Test]
    public async Task RunAsync_EnumeratesArgumentsOnce()
    {
        var runner = new FakeProcessRunner();
        var enumerationCount = 0;
        IEnumerable<string> Arguments()
        {
            enumerationCount++;
            yield return "argument";
        }

        _ = await runner.RunAsync("tool", Arguments());

        await Assert.That(enumerationCount).IsEqualTo(1);
    }

    [Test]
    public async Task Runs_ReturnsCopyThatLaterRunsDoNotChange()
    {
        var runner = new FakeProcessRunner();
        var runsBefore = runner.Runs;

        _ = await runner.RunAsync("tool", []);

        await Assert.That(runsBefore).IsEmpty();
        await Assert.That(runner.Runs.Count).IsEqualTo(1);
    }

    [Test]
    public async Task RunAsync_FromSeveralThreads_RecordsEveryRun()
    {
        const int RunCount = 200;
        var runner = new FakeProcessRunner();
        string[] arguments = [.. Enumerable.Range(0, RunCount).Select(index => index.ToString(CultureInfo.InvariantCulture))];

        _ = await Task.WhenAll(arguments.Select(argument => Task.Run(() => runner.RunAsync("tool", [argument]))));

        var recordedArguments = runner.Runs.Select(run => run.Arguments[0]);
        await Assert.That(recordedArguments).IsEquivalentTo(arguments);
    }

    [Test]
    public async Task RunAsync_PassesRecordedRunToOnRun()
    {
        string? receivedExecutable = null;
        IReadOnlyList<string>? receivedArguments = null;
        ProcessRunOptions? receivedOptions = null;
        ProcessResult OnRun(string executable, IReadOnlyList<string> arguments, ProcessRunOptions options)
        {
            receivedExecutable = executable;
            receivedArguments = arguments;
            receivedOptions = options;
            return Outcome();
        }

        var runner = new FakeProcessRunner { OnRun = OnRun };

        _ = await runner.RunAsync("tool", ["argument"]);

        var run = runner.Runs[0];
        await Assert.That(receivedExecutable).IsEqualTo("tool");
        await Assert.That(receivedArguments).IsSameReferenceAs(run.Arguments);
        await Assert.That(receivedOptions).IsSameReferenceAs(run.Options);
    }

    [Test]
    public async Task RunAsync_WithOnRun_ReturnsItsOutcomeWithNormalizedLines()
    {
        var runner = new FakeProcessRunner { OnRun = (_, _, _) => Outcome(0, "first\n\nsecond", "problem\r\ntrouble\r\n") };

        var result = await runner.RunAsync("tool", []);

        await Assert.That(result.CommandLine).IsEqualTo(CommandLine);
        await Assert.That(result.ExitCode).IsEqualTo(0);
        await Assert.That(result.StandardOutput).IsEqualTo($"first{NewLine}{NewLine}second{NewLine}");
        await Assert.That(result.StandardError).IsEqualTo($"problem{NewLine}trouble{NewLine}");
        await Assert.That(result.Elapsed).IsEqualTo(Elapsed);
    }

    [Test]
    public async Task RunAsync_WithCallbacks_CallsEachOncePerLine()
    {
        List<string> lines = [];
        var runner = new FakeProcessRunner { OnRun = (_, _, _) => Outcome(0, "first\nsecond\n", "problem\ntrouble\n") };

        _ = await runner.RunAsync("tool", [], OptionsWithCallbacks(lines, inheritStandardStreams: false));

        string[] expectedLines = ["out:first", "out:second", "err:problem", "err:trouble"];
        await Assert.That(lines).IsEquivalentTo(expectedLines, CollectionOrdering.Matching);
    }

    [Test]
    public async Task RunAsync_WithInheritStandardStreams_CallsNoCallbackAndReturnsEmptyTexts()
    {
        List<string> lines = [];
        var runner = new FakeProcessRunner { OnRun = (_, _, _) => Outcome(0, "output\n", "error\n") };

        var result = await runner.RunAsync("tool", [], OptionsWithCallbacks(lines, inheritStandardStreams: true));

        await Assert.That(lines).IsEmpty();
        await Assert.That(result.StandardOutput).IsEmpty();
        await Assert.That(result.StandardError).IsEmpty();
        await Assert.That(result.CommandLine).IsEqualTo(CommandLine);
        await Assert.That(result.Elapsed).IsEqualTo(Elapsed);
    }

    [Test]
    public async Task RunAsync_WithNonZeroExitCode_ThrowsProcessFailedException()
    {
        var runner = new FakeProcessRunner { OnRun = (_, _, _) => Outcome(3, "before", "problem") };

        Task Act() => runner.RunAsync("tool", []);

        var exception = await Assert.That(Act).Throws<ProcessFailedException>();

        Debug.Assert(exception is not null, "Throws returns null only inside Assert.Multiple.");
        await Assert.That(exception.Result.ExitCode).IsEqualTo(3);
        await Assert.That(exception.Result.CommandLine).IsEqualTo(CommandLine);
        await Assert.That(exception.Result.StandardOutput).IsEqualTo($"before{NewLine}");
        await Assert.That(exception.Result.StandardError).IsEqualTo($"problem{NewLine}");
    }

    [Test]
    public async Task RunAsync_WithNonZeroExitCodeAndInheritStandardStreams_ThrowsWithEmptyTexts()
    {
        var runner = new FakeProcessRunner { OnRun = (_, _, _) => Outcome(3, "before", "problem") };

        Task Act() => runner.RunAsync("tool", [], new ProcessRunOptions { InheritStandardStreams = true });

        var exception = await Assert.That(Act).Throws<ProcessFailedException>();

        Debug.Assert(exception is not null, "Throws returns null only inside Assert.Multiple.");
        await Assert.That(exception.Result.ExitCode).IsEqualTo(3);
        await Assert.That(exception.Result.StandardOutput).IsEmpty();
        await Assert.That(exception.Result.StandardError).IsEmpty();
    }

    [Test]
    public async Task RunAsync_WithNonZeroExitCodeAndNoThrow_ReturnsResult()
    {
        var runner = new FakeProcessRunner { OnRun = (_, _, _) => Outcome(3, "before") };

        var result = await runner.RunAsync("tool", [], new ProcessRunOptions { ThrowOnNonZeroExitCode = false });

        await Assert.That(result.ExitCode).IsEqualTo(3);
        await Assert.That(result.StandardOutput).IsEqualTo($"before{NewLine}");
    }

    [Test]
    public async Task RunAsync_WithSignaledToken_ThrowsAndRecordsNoRun()
    {
        using var cancellationSource = new CancellationTokenSource();
        await cancellationSource.CancelAsync();

        // OnRun would make the run throw another exception if the fake called it.
        var runner = new FakeProcessRunner { OnRun = (_, _, _) => throw new InvalidOperationException("OnRun was called.") };

        Task Act() => runner.RunAsync("tool", [], null, cancellationSource.Token);

        var exception = await Assert.That(Act).Throws<OperationCanceledException>();

        Debug.Assert(exception is not null, "Throws returns null only inside Assert.Multiple.");
        await Assert.That(exception.CancellationToken).IsEqualTo(cancellationSource.Token);
        await Assert.That(runner.Runs).IsEmpty();
    }

    [Test]
    public async Task RunAsync_WhenOnRunSignalsToken_ThrowsAndCallsNoCallback()
    {
        using var cancellationSource = new CancellationTokenSource();
        List<string> lines = [];
        var runner = new FakeProcessRunner { OnRun = (_, _, _) => CancelAndReturn(cancellationSource, Outcome(0, "output\n")) };

        Task Act() => runner.RunAsync("tool", [], new ProcessRunOptions { OnStandardOutputLine = lines.Add }, cancellationSource.Token);

        var exception = await Assert.That(Act).Throws<OperationCanceledException>();

        Debug.Assert(exception is not null, "Throws returns null only inside Assert.Multiple.");
        await Assert.That(exception.CancellationToken).IsEqualTo(cancellationSource.Token);
        await Assert.That(lines).IsEmpty();
        await Assert.That(runner.Runs.Count).IsEqualTo(1);
    }

    [Test]
    public async Task RunAsync_WhenLineCallbackSignalsToken_ThrowsAndReplaysNoMoreLines()
    {
        using var cancellationSource = new CancellationTokenSource();
        List<string> lines = [];
        void AddAndCancel(string line)
        {
            lines.Add(line);
            cancellationSource.Cancel();
        }

        var runner = new FakeProcessRunner { OnRun = (_, _, _) => Outcome(0, "first\nsecond\n", "problem\n") };

        Task Act() => runner.RunAsync("tool", [], OptionsWithCallbacks(AddAndCancel), cancellationSource.Token);

        var exception = await Assert.That(Act).Throws<OperationCanceledException>();

        Debug.Assert(exception is not null, "Throws returns null only inside Assert.Multiple.");
        string[] expectedLines = ["first"];
        await Assert.That(exception.CancellationToken).IsEqualTo(cancellationSource.Token);
        await Assert.That(lines).IsEquivalentTo(expectedLines, CollectionOrdering.Matching);
    }

    [Test]
    public async Task RunAsync_WhenOnRunThrows_ReturnsTaskThatThrowsSameException()
    {
        var failure = new InvalidOperationException("The child cannot start.");
        var runner = new FakeProcessRunner { OnRun = (_, _, _) => throw failure };

        // The call itself does not throw: the task holds the exception, as the task of ProcessRunner does.
        var task = runner.RunAsync("tool", []);
        Task Act() => task;

        await Assert.That(task.IsFaulted).IsTrue();
        var thrown = await Assert.That(Act).Throws<InvalidOperationException>();
        await Assert.That(thrown).IsSameReferenceAs(failure);
    }

    [Test]
    public async Task RunAsync_WhenLineCallbackThrows_ThrowsSameException()
    {
        var failure = new InvalidOperationException("The callback failed.");
        var runner = new FakeProcessRunner { OnRun = (_, _, _) => Outcome(0, "output\n", "error\n") };

        Task Act() => runner.RunAsync("tool", [], new ProcessRunOptions { OnStandardErrorLine = _ => throw failure });

        var thrown = await Assert.That(Act).Throws<InvalidOperationException>();

        await Assert.That(thrown).IsSameReferenceAs(failure);
    }

    [Test]
    public async Task RunAsync_DoesNotReadStandardInput()
    {
        var runner = new FakeProcessRunner();
        using var input = new MemoryStream([1, 2, 3]);

        _ = await runner.RunAsync("tool", [], new ProcessRunOptions { StandardInput = input });

        await Assert.That(input.Position).IsEqualTo(0L);
    }

    [Test]
    public async Task RunAsync_WithNullExecutable_ThrowsArgumentNullException()
    {
        var runner = new FakeProcessRunner();

        // ! Null on purpose: testing null detection
        void Act() => _ = runner.RunAsync(null!, []);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("executable");
    }

    [Test]
    public async Task RunAsync_WithNullArguments_ThrowsArgumentNullException()
    {
        var runner = new FakeProcessRunner();

        // ! Null on purpose: testing null detection
        void Act() => _ = runner.RunAsync("tool", null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("arguments");
    }

    [Test]
    public async Task RunAsync_WithNullArgument_ThrowsArgumentExceptionAndRecordsNoRun()
    {
        var runner = new FakeProcessRunner();

        // ! Null on purpose: testing null detection
        void Act() => _ = runner.RunAsync("tool", ["first", null!]);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("arguments");
        await Assert.That(runner.Runs).IsEmpty();
    }

    private static ProcessResult Outcome(int exitCode = 0, string standardOutput = "", string standardError = "")
        => new(CommandLine, exitCode, standardOutput, standardError, Elapsed);

    private static ProcessResult CancelAndReturn(CancellationTokenSource cancellationSource, ProcessResult outcome)
    {
        cancellationSource.Cancel();
        return outcome;
    }

    private static ProcessRunOptions OptionsWithCallbacks(List<string> lines, bool inheritStandardStreams)
    {
        void OnOutput(string line) => lines.Add($"out:{line}");
        void OnError(string line) => lines.Add($"err:{line}");
        return new() { InheritStandardStreams = inheritStandardStreams, OnStandardOutputLine = OnOutput, OnStandardErrorLine = OnError };
    }

    private static ProcessRunOptions OptionsWithCallbacks(Action<string> onLine)
        => new() { OnStandardOutputLine = onLine, OnStandardErrorLine = onLine };
}
