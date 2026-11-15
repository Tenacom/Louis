// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET8_0_OR_GREATER

using System.ComponentModel;
using System.Diagnostics;
using Louis.Processes;

// A child in inherited mode shares the standard streams of the test host, so these tests make it write nothing.
[Timeout(60_000)]
internal sealed class ProcessRunnerInheritedModeTests
{
    private readonly ProcessRunner _runner = new();

    [Test]
    public async Task RunAsync_InInheritedMode_ReturnsExitCodeAndEmptyTexts(CancellationToken cancellationToken)
    {
        var arguments = ChildProcess.Arguments("exit:0");

        var result = await _runner.RunAsync(
            ChildProcess.Executable,
            arguments,
            new ProcessRunOptions { InheritStandardStreams = true },
            cancellationToken);

        await Assert.That(result.ExitCode).IsEqualTo(0);
        await Assert.That(result.StandardOutput).IsEmpty();
        await Assert.That(result.StandardError).IsEmpty();
        await Assert.That(result.CommandLine).IsEqualTo(CommandLineFormatter.Format(ChildProcess.Executable, arguments));
        await Assert.That(result.Elapsed).IsGreaterThan(TimeSpan.Zero);
    }

    [Test]
    public async Task RunAsync_InInheritedMode_IgnoresStandardInput(CancellationToken cancellationToken)
    {
        var readCount = 0;
        using var input = new CallbackReadStream(CountRead);

        ValueTask<int> CountRead(Memory<byte> buffer, CancellationToken readToken)
        {
            readCount++;
            return ValueTask.FromResult(0);
        }

        _ = await _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("exit:0"),
            new ProcessRunOptions { InheritStandardStreams = true, StandardInput = input },
            cancellationToken);

        await Assert.That(readCount).IsEqualTo(0);
    }

    [Test]
    public async Task RunAsync_InInheritedModeWithNonZeroExitCode_ThrowsProcessFailedException(CancellationToken cancellationToken)
    {
        Task Act() => _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("exit:3"),
            new ProcessRunOptions { InheritStandardStreams = true },
            cancellationToken);

        var exception = await Assert.That(Act).Throws<ProcessFailedException>();

        Debug.Assert(exception is not null, "Throws returns null only inside Assert.Multiple.");
        await Assert.That(exception.Result.ExitCode).IsEqualTo(3);
        await Assert.That(exception.Result.StandardOutput).IsEmpty();
        await Assert.That(exception.Result.StandardError).IsEmpty();
    }

    [Test]
    public async Task RunAsync_InInheritedModeWhenTokenIsSignaled_KillsChildAndThrows(CancellationToken cancellationToken)
    {
        using var cancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        cancellationSource.CancelAfter(TimeSpan.FromMilliseconds(500));

        // Without the kill, the child would sleep forever, and so would the run.
        Task Act() => _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("sleep"),
            new ProcessRunOptions { InheritStandardStreams = true },
            cancellationSource.Token);

        var exception = await Assert.That(Act).Throws<OperationCanceledException>();

        Debug.Assert(exception is not null, "Throws returns null only inside Assert.Multiple.");
        await Assert.That(exception.CancellationToken).IsEqualTo(cancellationSource.Token);
    }

    [Test]
    public async Task RunAsync_InInheritedModeWithMissingExecutable_ThrowsWin32Exception(CancellationToken cancellationToken)
    {
        Task Act() => _runner.RunAsync(
            "louis-tests-no-such-program",
            [],
            new ProcessRunOptions { InheritStandardStreams = true },
            cancellationToken);

        await Assert.That(Act).Throws<Win32Exception>();
    }
}

#endif
