// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET8_0_OR_GREATER

using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using Louis.Processes;
using TUnit.Core.Enums;

[Timeout(60_000)]
internal sealed class ProcessRunnerCancellationTests
{
    // Long enough for a child that has nothing more to do to exit. A test that waits this long still passes
    // when the child takes longer, because the runner then kills the child and the process it started.
    private static readonly TimeSpan TimeForChildToExit = TimeSpan.FromMilliseconds(500);

    // Long enough for an aborted run to kill the child and throw. A callback that keeps running this long is still running
    // when a run that does not wait for it throws. A test that relies on this time still passes when the kill takes longer,
    // because the run waits for the callback.
    private static readonly TimeSpan TimeForAbortedRunToThrow = TimeSpan.FromMilliseconds(500);

    private readonly ProcessRunner _runner = new();

    [Test]
    public async Task RunAsync_WithCanceledToken_ThrowsWithoutStartingChild(CancellationToken cancellationToken)
    {
        using var cancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        await cancellationSource.CancelAsync();

        // A missing executable would throw Win32Exception if the runner tried to start it.
        Task Act() => _runner.RunAsync("louis-tests-no-such-program", [], null, cancellationSource.Token);

        var exception = await Assert.That(Act).Throws<OperationCanceledException>();

        Debug.Assert(exception is not null, "Throws returns null only inside Assert.Multiple.");
        await Assert.That(exception.CancellationToken).IsEqualTo(cancellationSource.Token);
    }

    [Test]
    public async Task RunAsync_WhenTokenIsSignaled_KillsChildAndThrows(CancellationToken cancellationToken)
    {
        using var cancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        var options = new ProcessRunOptions { OnStandardOutputLine = _ => cancellationSource.Cancel() };

        // Without the kill, the child would sleep forever, and so would the run.
        Task Act() => _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("out:ready", "sleep"),
            options,
            cancellationSource.Token);

        var exception = await Assert.That(Act).Throws<OperationCanceledException>();

        Debug.Assert(exception is not null, "Throws returns null only inside Assert.Multiple.");
        await Assert.That(exception.CancellationToken).IsEqualTo(cancellationSource.Token);
    }

    [Test]
    public async Task RunAsync_WhenTokenIsSignaled_KillsProcessTreeOfChild(CancellationToken cancellationToken)
    {
        using var cancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        void CancelOnProcessId(string line)
        {
            if (line.StartsWith("pid:", StringComparison.Ordinal))
            {
                cancellationSource.Cancel();
            }
        }

        // The process that the child starts inherits both pipes of the child, and sleeps forever.
        // The run ends when both pipes are closed, so it ends only if that process is killed too.
        Task Act() => _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("spawn", "sleep"),
            new ProcessRunOptions { OnStandardOutputLine = CancelOnProcessId },
            cancellationSource.Token);

        await Assert.That(Act).Throws<OperationCanceledException>();
    }

    [Test]
    public async Task RunAsync_WhenTokenIsSignaledWhileReadingStandardInput_KillsChildAndThrows(
        CancellationToken cancellationToken)
    {
        using var cancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        using var input = new CallbackReadStream(ReadForever);

        // The read never ends by itself. It ends when the runner cancels it, which the token of the run causes.
        async ValueTask<int> ReadForever(Memory<byte> buffer, CancellationToken readToken)
        {
            cancellationSource.CancelAfter(TimeSpan.FromMilliseconds(100));
            await Task.Delay(Timeout.Infinite, readToken);
            return 0;
        }

        Task Act() => _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("stdin", "sleep"),
            new ProcessRunOptions { StandardInput = input },
            cancellationSource.Token);

        var exception = await Assert.That(Act).Throws<OperationCanceledException>();

        Debug.Assert(exception is not null, "Throws returns null only inside Assert.Multiple.");
        await Assert.That(exception.CancellationToken).IsEqualTo(cancellationSource.Token);
    }

    [Test]
    public async Task RunAsync_WhenCallbackThrows_KillsChildAndThrowsSameException(CancellationToken cancellationToken)
    {
        var failure = new InvalidOperationException("The callback failed.");
        var options = new ProcessRunOptions { OnStandardErrorLine = _ => throw failure };

        // Without the kill, the child would sleep forever, and so would the run.
        Task Act() => _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("err:ready", "sleep"),
            options,
            cancellationToken);

        var thrown = await Assert.That(Act).Throws<InvalidOperationException>();

        await Assert.That(thrown).IsSameReferenceAs(failure);
    }

    [Test]
    public async Task RunAsync_WhenTokenIsSignaled_CallsNoCallbackAfterwards(CancellationToken cancellationToken)
    {
        using var cancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        var lineCount = 0;
        void CountAndCancel(string line)
        {
            lineCount++;
            cancellationSource.Cancel();
        }

        // The child writes both lines at once, so the runner holds the second line when the callback signals the token.
        Task Act() => _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("out:first\nsecond", "sleep"),
            new ProcessRunOptions { OnStandardOutputLine = CountAndCancel },
            cancellationSource.Token);

        await Assert.That(Act).Throws<OperationCanceledException>();
        await Assert.That(lineCount).IsEqualTo(1);
    }

    [Test]
    public async Task RunAsync_WhenCallbackThrowsAfterTokenIsSignaled_ThrowsOperationCanceledException(
        CancellationToken cancellationToken)
    {
        using var cancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        void CancelAndThrow(string line)
        {
            cancellationSource.Cancel();
            throw new InvalidOperationException("The callback failed.");
        }

        // The token was signaled first, so the run reports the cancellation, and not the failure of the callback.
        Task Act() => _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("out:ready", "sleep"),
            new ProcessRunOptions { OnStandardOutputLine = CancelAndThrow },
            cancellationSource.Token);

        var exception = await Assert.That(Act).Throws<OperationCanceledException>();

        Debug.Assert(exception is not null, "Throws returns null only inside Assert.Multiple.");
        await Assert.That(exception.CancellationToken).IsEqualTo(cancellationSource.Token);
    }

    [Test]
    public async Task RunAsync_WhenTokenIsSignaledWhileCallbackRuns_ThrowsAfterCallbackReturns(
        CancellationToken cancellationToken)
    {
        using var cancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        var callbackHasReturned = false;
        void CancelAndKeepRunning(string line)
        {
            cancellationSource.Cancel();
            Thread.Sleep(TimeForAbortedRunToThrow);
            callbackHasReturned = true;
        }

        Task Act() => _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("out:ready", "sleep"),
            new ProcessRunOptions { OnStandardOutputLine = CancelAndKeepRunning },
            cancellationSource.Token);

        await Assert.That(Act).Throws<OperationCanceledException>();
        await Assert.That(callbackHasReturned).IsTrue();
    }

    [Test]
    [RunOn(OS.Linux)]
    public async Task RunAsync_WhenTokenIsSignaledAndProcessOutlivesKill_ThrowsAfterCallbackReturns(
        CancellationToken cancellationToken)
    {
        Skip.Unless(await CanRunSudoWithoutPasswordAsync(cancellationToken), "sudo is missing, or needs a password.");

        using var cancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        var callbackHasReturned = false;
        void CancelAndKeepRunning(string line)
        {
            cancellationSource.Cancel();
            Thread.Sleep(TimeForAbortedRunToThrow);
            callbackHasReturned = true;
        }

        // With no terminal, as on a CI runner, the shell that sudo starts runs as root, and the current user cannot kill it.
        // Process.Kill then throws AggregateException, which must not replace the exception of the run.
        // With a terminal, the kill ends the shell too, and the test passes without that exception.
        // The shell that outlives the kill ends by itself after its sleep.
        Task Act() => _runner.RunAsync(
            "sudo",
            ["-n", "sh", "-c", "echo ready; sleep 5"],
            new ProcessRunOptions { OnStandardOutputLine = CancelAndKeepRunning },
            cancellationSource.Token);

        var exception = await Assert.That(Act).Throws<OperationCanceledException>();

        Debug.Assert(exception is not null, "Throws returns null only inside Assert.Multiple.");
        await Assert.That(exception.CancellationToken).IsEqualTo(cancellationSource.Token);
        await Assert.That(callbackHasReturned).IsTrue();
    }

    [Test]
    public async Task RunAsync_WhenCallbackThrowsWhileOtherCallbackRuns_ThrowsAfterOtherCallbackReturns(
        CancellationToken cancellationToken)
    {
        var failure = new InvalidOperationException("The callback failed.");
        using var outputCallbackIsRunning = new ManualResetEventSlim();
        var outputCallbackHasReturned = false;
        void KeepRunning(string line)
        {
            outputCallbackIsRunning.Set();
            Thread.Sleep(TimeForAbortedRunToThrow);
            outputCallbackHasReturned = true;
        }

        void ThrowWhileOutputCallbackRuns(string line)
        {
            outputCallbackIsRunning.Wait(cancellationToken);
            throw failure;
        }

        var options = new ProcessRunOptions { OnStandardOutputLine = KeepRunning, OnStandardErrorLine = ThrowWhileOutputCallbackRuns };
        Task Act() => _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("out:ready", "err:ready", "sleep"),
            options,
            cancellationToken);

        var thrown = await Assert.That(Act).Throws<InvalidOperationException>();

        await Assert.That(thrown).IsSameReferenceAs(failure);
        await Assert.That(outputCallbackHasReturned).IsTrue();
    }

    [Test]
    public async Task RunAsync_WhenTokenIsSignaledAfterChildHasExited_ThrowsWithoutWaitingForStreams(
        CancellationToken cancellationToken)
    {
        using var cancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        var spawnedProcessId = 0;
        void CancelAfterChildHasExited(string line)
        {
            if (TryGetSpawnedProcessId(line, out var processId))
            {
                spawnedProcessId = processId;
                cancellationSource.CancelAfter(TimeForChildToExit);
            }
        }

        // The process that the child starts inherits both pipes of the child, and sleeps forever.
        // The child exits at once, so the token is signaled while the runner waits for both pipes to be closed.
        Task Act() => _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("spawn"),
            new ProcessRunOptions { OnStandardOutputLine = CancelAfterChildHasExited },
            cancellationSource.Token);

        try
        {
            var exception = await Assert.That(Act).Throws<OperationCanceledException>();

            Debug.Assert(exception is not null, "Throws returns null only inside Assert.Multiple.");
            await Assert.That(exception.CancellationToken).IsEqualTo(cancellationSource.Token);
        }
        finally
        {
            KillSpawnedProcess(spawnedProcessId);
        }
    }

    [Test]
    public async Task RunAsync_WhenCallbackThrowsAfterChildHasExited_ThrowsWithoutWaitingForStreams(
        CancellationToken cancellationToken)
    {
        var failure = new InvalidOperationException("The callback failed.");
        var spawnedProcessId = 0;
        void ThrowAfterChildHasExited(string line)
        {
            if (TryGetSpawnedProcessId(line, out var processId))
            {
                spawnedProcessId = processId;
                Thread.Sleep(TimeForChildToExit);
                throw failure;
            }
        }

        // The process that the child starts inherits both pipes of the child, and sleeps forever.
        // The child exits while the callback sleeps, so the callback throws while the standard error of the child is still open.
        Task Act() => _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("spawn"),
            new ProcessRunOptions { OnStandardOutputLine = ThrowAfterChildHasExited },
            cancellationToken);

        try
        {
            var thrown = await Assert.That(Act).Throws<InvalidOperationException>();

            await Assert.That(thrown).IsSameReferenceAs(failure);
        }
        finally
        {
            KillSpawnedProcess(spawnedProcessId);
        }
    }

    // Reads the line that the "spawn" instruction of the child writes: "pid:" and the id of the process it started.
    private static bool TryGetSpawnedProcessId(string line, out int processId)
    {
        const string Prefix = "pid:";
        processId = 0;
        return line.StartsWith(Prefix, StringComparison.Ordinal)
            && int.TryParse(line.AsSpan(Prefix.Length), NumberStyles.None, CultureInfo.InvariantCulture, out processId);
    }

    // The runner kills the process that the child started only together with the child.
    // A test in which the child exits by itself kills that process, so that it does not outlive the test run.
    private static void KillSpawnedProcess(int processId)
    {
        // The id is 0 when the child wrote no line, and the test has failed already.
        if (processId == 0)
        {
            return;
        }

        try
        {
            using var process = Process.GetProcessById(processId);
            process.Kill();
        }
        catch (ArgumentException)
        {
            // The process has exited: the runner killed it with the child, because the child had not exited yet.
        }
    }

    // A test of a kill that leaves a process running gets a process of another user from sudo.
    private async Task<bool> CanRunSudoWithoutPasswordAsync(CancellationToken cancellationToken)
    {
        try
        {
            var options = new ProcessRunOptions { ThrowOnNonZeroExitCode = false };
            var result = await _runner.RunAsync("sudo", ["-n", "true"], options, cancellationToken);
            return result.ExitCode == 0;
        }
        catch (Win32Exception)
        {
            // The system has no sudo.
            return false;
        }
    }
}

#endif
