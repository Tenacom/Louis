// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET5_0_OR_GREATER

using System.Diagnostics;
using Louis.Processes;

[Timeout(60_000)]
internal sealed class ProcessRunnerCancellationTests
{
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
    public async Task RunAsync_WhenTokenIsSignaledWhileReadingStandardInput_KillsChildAndThrows(CancellationToken cancellationToken)
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
}

#endif
