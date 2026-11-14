// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET5_0_OR_GREATER

using System.Text;
using Louis.Processes;
using TUnit.Core.Enums;

[Timeout(60_000)]
internal sealed class ProcessRunnerOutputEncodingTests
{
    private static readonly string NewLine = Environment.NewLine;

    private readonly ProcessRunner _runner = new();

    [Test]
    public async Task RunAsync_WithoutOutputEncoding_DecodesOutputOfDotNetChild(CancellationToken cancellationToken)
    {
        // The child writes through Console, with the encoding of its console.
        var result = await _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("out:caffè", "err:perché"),
            cancellationToken: cancellationToken);

        await Assert.That(result.StandardOutput).IsEqualTo($"caffè{NewLine}");
        await Assert.That(result.StandardError).IsEqualTo($"perché{NewLine}");
    }

    [Test]
    [RunOn(OS.Windows)]
    public async Task RunAsync_WithoutOutputEncoding_DecodesOutputOfNativeChild(CancellationToken cancellationToken)
    {
        // cmd writes to a pipe with the code page of its console.
        var result = await _runner.RunAsync("cmd.exe", ["/c", "echo perché"], cancellationToken: cancellationToken);

        await Assert.That(result.StandardOutput).IsEqualTo($"perché{NewLine}");
    }

    [Test]
    public async Task RunAsync_WithOutputEncoding_DecodesOutputWithIt(CancellationToken cancellationToken)
    {
        // UTF-16 is the default encoding of no console, so the text comes out right only when the runner uses the option.
        var result = await _runner.RunAsync(
            ChildProcess.Executable,
            ChildProcess.Arguments("utf16:perché"),
            new ProcessRunOptions { OutputEncoding = Encoding.Unicode },
            cancellationToken);

        await Assert.That(result.StandardOutput).IsEqualTo($"perché{NewLine}");
    }
}

#endif
