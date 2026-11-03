// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

internal sealed class InternalErrorExceptionTests
{
    [Test]
    public async Task Constructor_WithoutArguments_SetsNoInnerException()
    {
        var exception = new InternalErrorException();

        await Assert.That(exception.Message).IsNotEmpty();
        await Assert.That(exception.InnerException).IsNull();
    }

    [Test]
    public async Task Constructor_WithMessage_SetsMessage()
    {
        var exception = new InternalErrorException("Something failed.");

        await Assert.That(exception.Message).IsEqualTo("Something failed.");
        await Assert.That(exception.InnerException).IsNull();
    }

    [Test]
    public async Task Constructor_WithMessageAndInnerException_SetsBoth()
    {
        var innerException = new InvalidOperationException();

        var exception = new InternalErrorException("Something failed.", innerException);

        await Assert.That(exception.Message).IsEqualTo("Something failed.");
        await Assert.That(exception.InnerException).IsSameReferenceAs(innerException);
    }
}
