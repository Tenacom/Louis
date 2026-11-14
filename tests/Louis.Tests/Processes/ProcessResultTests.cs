// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET5_0_OR_GREATER

using Louis.Processes;

internal sealed class ProcessResultTests
{
    [Test]
    public async Task Constructor_SetsProperties()
    {
        var result = new ProcessResult("tool one", 3, "output", "error", TimeSpan.FromSeconds(2));

        await Assert.That(result.CommandLine).IsEqualTo("tool one");
        await Assert.That(result.ExitCode).IsEqualTo(3);
        await Assert.That(result.StandardOutput).IsEqualTo("output");
        await Assert.That(result.StandardError).IsEqualTo("error");
        await Assert.That(result.Elapsed).IsEqualTo(TimeSpan.FromSeconds(2));
    }

    [Test]
    public async Task Constructor_WithNullCommandLine_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => _ = new ProcessResult(null!, 0, string.Empty, string.Empty, TimeSpan.Zero);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("commandLine");
    }

    [Test]
    public async Task Constructor_WithNullStandardOutput_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => _ = new ProcessResult("tool", 0, null!, string.Empty, TimeSpan.Zero);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("standardOutput");
    }

    [Test]
    public async Task Constructor_WithNullStandardError_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => _ = new ProcessResult("tool", 0, string.Empty, null!, TimeSpan.Zero);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("standardError");
    }
}

#endif
