// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

internal sealed class CriticalInternalErrorExceptionTests
{
    [Test]
    public async Task Constructor_WithoutArguments_SetsNoInnerException()
    {
        var exception = new CriticalInternalErrorException();

        await Assert.That(exception.Message).IsNotEmpty();
        await Assert.That(exception.InnerException).IsNull();
    }

    [Test]
    public async Task Constructor_WithMessage_SetsMessage()
    {
        var exception = new CriticalInternalErrorException("Something failed.");

        await Assert.That(exception.Message).IsEqualTo("Something failed.");
        await Assert.That(exception.InnerException).IsNull();
    }

    [Test]
    public async Task Constructor_WithMessageAndInnerException_SetsBoth()
    {
        var innerException = new InvalidOperationException();

        var exception = new CriticalInternalErrorException("Something failed.", innerException);

        await Assert.That(exception.Message).IsEqualTo("Something failed.");
        await Assert.That(exception.InnerException).IsSameReferenceAs(innerException);
    }

    [Test]
    public async Task Type_DerivesFromInternalErrorException()
        => await Assert.That(new CriticalInternalErrorException()).IsAssignableTo<InternalErrorException>();

    [Test]
    public async Task Type_ImplementsICriticalError()
        => await Assert.That(new CriticalInternalErrorException()).IsAssignableTo<ICriticalError>();
}
