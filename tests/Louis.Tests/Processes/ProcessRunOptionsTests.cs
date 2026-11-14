// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET5_0_OR_GREATER

using Louis.Processes;

internal sealed class ProcessRunOptionsTests
{
    [Test]
    public async Task Constructor_SetsDefaults()
    {
        var options = new ProcessRunOptions();

        await Assert.That(options.Environment).IsNull();
        await Assert.That(options.WorkingDirectory).IsNull();
        await Assert.That(options.InheritStandardStreams).IsFalse();
        await Assert.That(options.StandardInput).IsNull();
        await Assert.That(options.OutputEncoding).IsNull();
        await Assert.That(options.OnStandardOutputLine).IsNull();
        await Assert.That(options.OnStandardErrorLine).IsNull();
        await Assert.That(options.ThrowOnNonZeroExitCode).IsTrue();
    }
}

#endif
