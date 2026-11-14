// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET5_0_OR_GREATER

using Louis.Processes;

internal sealed class ProcessFailedExceptionTests
{
    [Test]
    public async Task Constructor_SetsResultAndMessage()
    {
        var result = new ProcessResult("tool \"two words\"", 3, "output", "error", TimeSpan.Zero);

        var exception = new ProcessFailedException(result);

        await Assert.That(exception.Result).IsSameReferenceAs(result);
        await Assert.That(exception.Message).IsEqualTo("Process exited with code 3: tool \"two words\"");
        await Assert.That(exception.InnerException).IsNull();
    }

    [Test]
    public async Task Constructor_WithNullResult_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => _ = new ProcessFailedException(null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("result");
    }
}

#endif
