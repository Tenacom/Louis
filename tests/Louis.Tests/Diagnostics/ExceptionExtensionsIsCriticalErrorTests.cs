// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;
using System.Security;
using Louis.Diagnostics;

internal sealed partial class ExceptionExtensionsIsCriticalErrorTests
{
    // ThreadAbortException is missing from the list: it has no public constructor.
#pragma warning disable CA2201 // Do not raise reserved exception types - the data source constructs each critical type on purpose
    public static IEnumerable<Func<Exception>> CriticalErrors() => [
        () => new NullReferenceException(),
        () => new StackOverflowException(),
        () => new AppDomainUnloadedException(),
        () => new BadImageFormatException(),
        () => new InvalidProgramException(),
        () => new AccessViolationException(),
        () => new OutOfMemoryException(),
        () => new SEHException(),
        () => new SecurityException(),
        () => new CriticalInternalErrorException(),
        () => new TestCriticalException(),
    ];
#pragma warning restore CA2201 // Do not raise reserved exception types

    public static IEnumerable<Func<Exception>> OrdinaryExceptions() => [
        () => new InvalidOperationException(),
        () => new InvalidOperationException("outer", new ArgumentException("inner")),
        () => new AggregateException(new InvalidOperationException(), new ArgumentException()),
        () => new OperationCanceledException(),
    ];

    [Test]
    public async Task IsCriticalError_WithNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((Exception)null!).IsCriticalError();

        var exception = Assert.Throws<ArgumentNullException>(Act);
        await Assert.That(exception.ParamName).IsEqualTo("this");
    }

    [Test]
    [MethodDataSource(nameof(CriticalErrors))]
    public async Task IsCriticalError_WithCriticalError_ReturnsTrue(Exception exception)
        => await Assert.That(exception.IsCriticalError()).IsTrue();

    [Test]
    [MethodDataSource(nameof(CriticalErrors))]
    public async Task IsCriticalError_WithCriticalErrorAsInnerException_ReturnsTrue(Exception exception)
    {
        var outer = new InvalidOperationException("outer", exception);

        await Assert.That(outer.IsCriticalError()).IsTrue();
    }

    [Test]
    [MethodDataSource(nameof(CriticalErrors))]
    public async Task IsCriticalError_WithCriticalErrorInAggregateException_ReturnsTrue(Exception exception)
    {
        var aggregate = new AggregateException(new InvalidOperationException("ordinary"), exception);

        await Assert.That(aggregate.IsCriticalError()).IsTrue();
    }

    [Test]
    [MethodDataSource(nameof(OrdinaryExceptions))]
    public async Task IsCriticalError_WithOrdinaryException_ReturnsFalse(Exception exception)
        => await Assert.That(exception.IsCriticalError()).IsFalse();
}
