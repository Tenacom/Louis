// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Globalization;
using System.Runtime.CompilerServices;
using Louis.Diagnostics;

// ReSharper disable ExplicitCallerInfoArgument // the tests pass the file path and the line number on purpose, to pin the message format
internal sealed class SelfCheckTests
{
    [Test]
    public async Task Failure_ReturnsInternalErrorExceptionWithMessage()
    {
        var exception = SelfCheck.Failure("Something failed.", "Foo.cs", 42);

        await Assert.That(exception).IsTypeOf<InternalErrorException>();
        await Assert.That(exception.Message).IsEqualTo($"[{await GetAssemblyName()}: Foo.cs(42)] Something failed.");
    }

    [Test]
    public async Task CriticalFailure_ReturnsCriticalInternalErrorExceptionWithMessage()
    {
        var exception = SelfCheck.CriticalFailure("Something failed.", "Foo.cs", 42);

        await Assert.That(exception).IsTypeOf<CriticalInternalErrorException>();
        await Assert.That(exception.Message).IsEqualTo($"[{await GetAssemblyName()}: Foo.cs(42)] Something failed.");
    }

    [Test]
    public async Task Fail_ThrowsInternalErrorExceptionWithMessage()
    {
        // No optimization, so that the JIT does not tail-call SelfCheck.Fail and drop the frame the message names.
        [MethodImpl(MethodImplOptions.NoOptimization)]
        static void Act() => SelfCheck.Fail("Something failed.", "Foo.cs", 42);

        var exception = Assert.Throws<InternalErrorException>(Act);

        await Assert.That(exception).IsTypeOf<InternalErrorException>();
        await Assert.That(exception.Message).IsEqualTo($"[{await GetAssemblyName()}: Foo.cs(42)] Something failed.");
    }

    [Test]
    public async Task FailCritically_ThrowsCriticalInternalErrorExceptionWithMessage()
    {
        // No optimization, so that the JIT does not tail-call SelfCheck.FailCritically and drop the frame the message names.
        [MethodImpl(MethodImplOptions.NoOptimization)]
        static void Act() => SelfCheck.FailCritically("Something failed.", "Foo.cs", 42);

        var exception = Assert.Throws<CriticalInternalErrorException>(Act);

        await Assert.That(exception).IsTypeOf<CriticalInternalErrorException>();
        await Assert.That(exception.Message).IsEqualTo($"[{await GetAssemblyName()}: Foo.cs(42)] Something failed.");
    }

    [Test]
    public async Task FailOfT_ThrowsInternalErrorExceptionWithMessage()
    {
        // No optimization, so that the JIT does not tail-call SelfCheck.Fail<T> and drop the frame the message names.
        [MethodImpl(MethodImplOptions.NoOptimization)]
        static void Act() => SelfCheck.Fail<int>("Something failed.", "Foo.cs", 42);

        var exception = Assert.Throws<InternalErrorException>(Act);

        await Assert.That(exception).IsTypeOf<InternalErrorException>();
        await Assert.That(exception.Message).IsEqualTo($"[{await GetAssemblyName()}: Foo.cs(42)] Something failed.");
    }

    [Test]
    public async Task FailCriticallyOfT_ThrowsCriticalInternalErrorExceptionWithMessage()
    {
        // No optimization, so that the JIT does not tail-call SelfCheck.FailCritically<T> and drop the frame the message names.
        [MethodImpl(MethodImplOptions.NoOptimization)]
        static void Act() => SelfCheck.FailCritically<int>("Something failed.", "Foo.cs", 42);

        var exception = Assert.Throws<CriticalInternalErrorException>(Act);

        await Assert.That(exception).IsTypeOf<CriticalInternalErrorException>();
        await Assert.That(exception.Message).IsEqualTo($"[{await GetAssemblyName()}: Foo.cs(42)] Something failed.");
    }

    [Test]
    public async Task Failure_WithCompilerSuppliedArguments_NamesCallingFileAndLine()
    {
        var (exception, line) = (SelfCheck.Failure("Something failed."), CurrentLine());
        var expected = $"[{await GetAssemblyName()}: {CurrentFile()}({line.ToString(CultureInfo.InvariantCulture)})] Something failed.";

        await Assert.That(exception.Message).IsEqualTo(expected);

        static string CurrentFile([CallerFilePath] string filePath = "") => filePath;

        static int CurrentLine([CallerLineNumber] int lineNumber = 0) => lineNumber;
    }

    [Test]
    public async Task Failure_WithEmptyFilePath_OmitsFileAndLine()
    {
        var exception = SelfCheck.Failure("Something failed.", string.Empty, 42);

        await Assert.That(exception.Message).IsEqualTo($"[{await GetAssemblyName()}] Something failed.");
    }

    [Test]
    public async Task Failure_WithZeroLineNumber_OmitsLine()
    {
        var exception = SelfCheck.Failure("Something failed.", "Foo.cs", 0);

        await Assert.That(exception.Message).IsEqualTo($"[{await GetAssemblyName()}: Foo.cs] Something failed.");
    }

    [Test]
    public async Task Failure_WithNullMessage_UsesPlaceholder()
    {
        // ! Null on purpose: testing null detection
        var exception = SelfCheck.Failure(null!, "Foo.cs", 42);

        await Assert.That(exception.Message).IsEqualTo($"[{await GetAssemblyName()}: Foo.cs(42)] <no message>");
    }

    private static async Task<string> GetAssemblyName()
        => await Assert.That(typeof(SelfCheckTests).Assembly.GetName().Name).IsNotNull();
}

// ReSharper restore ExplicitCallerInfoArgument
