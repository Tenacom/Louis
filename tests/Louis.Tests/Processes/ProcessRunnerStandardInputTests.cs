// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET5_0_OR_GREATER

using Louis.Processes;

[Timeout(60_000)]
internal sealed class ProcessRunnerStandardInputTests
{
    private static readonly string NewLine = Environment.NewLine;

    private readonly ProcessRunner _runner = new();

    [Test]
    public async Task RunAsync_WithStandardInput_ChildReadsItFromCurrentPosition(CancellationToken cancellationToken)
    {
        using var input = new MemoryStream("skipped\nalpha\nbeta\n"u8.ToArray());
        input.Position = "skipped\n".Length;

        var result = await _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("stdin"),
            new ProcessRunOptions { StandardInput = input },
            cancellationToken);

        await Assert.That(result.StandardOutput).IsEqualTo($"in:alpha{NewLine}in:beta{NewLine}eof{NewLine}");
        await Assert.That(input.CanRead).IsTrue();
    }

    [Test]
    public async Task RunAsync_WithoutStandardInput_ChildFindsEndOfInput(CancellationToken cancellationToken)
    {
        var result = await _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("stdin"),
            cancellationToken: cancellationToken);

        await Assert.That(result.StandardOutput).IsEqualTo($"eof{NewLine}");
    }

    [Test]
    public async Task RunAsync_WhenChildExitsWithoutReadingStandardInput_ReturnsResult(CancellationToken cancellationToken)
    {
        // More data than a pipe holds: the runner is still writing when the child exits.
        using var input = new MemoryStream(new byte[4 * 1024 * 1024]);

        var result = await _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("out:done"),
            new ProcessRunOptions { StandardInput = input },
            cancellationToken);

        await Assert.That(result.ExitCode).IsEqualTo(0);
        await Assert.That(result.StandardOutput).IsEqualTo($"done{NewLine}");
    }

    [Test]
    public async Task RunAsync_WhenStandardInputThrowsIOException_KillsChildAndThrowsIt(CancellationToken cancellationToken)
    {
        var failure = new IOException("The input cannot be read.");
        using var input = new CallbackReadStream((_, _) => throw failure);

        // Without the kill, the child would wait for its standard input forever.
        Task Act() => _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("stdin", "sleep"),
            new ProcessRunOptions { StandardInput = input },
            cancellationToken);

        var thrown = await Assert.That(Act).Throws<IOException>();

        await Assert.That(thrown).IsSameReferenceAs(failure);
    }

    [Test]
    public async Task RunAsync_WhenStandardInputThrowsOperationCanceledException_KillsChildAndThrowsIt(
        CancellationToken cancellationToken)
    {
        // The exception does not come from the token of the run, so it is a failure of the stream.
        var failure = new OperationCanceledException("The input was canceled.");
        using var input = new CallbackReadStream((_, _) => throw failure);

        Task Act() => _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("stdin", "sleep"),
            new ProcessRunOptions { StandardInput = input },
            cancellationToken);

        var thrown = await Assert.That(Act).Throws<OperationCanceledException>();

        await Assert.That(thrown).IsSameReferenceAs(failure);
    }
}

#endif
