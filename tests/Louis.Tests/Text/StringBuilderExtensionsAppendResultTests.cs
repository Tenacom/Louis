// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Text;
using Louis;
using Louis.Text;

internal sealed class StringBuilderExtensionsAppendResultTests
{
    [Test]
    public async Task AppendResult_WithFunc_AppendsResult()
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendResult(() => "abc");

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("xabc");
    }

    [Test]
    public async Task AppendResult_WithFuncReturningNull_AppendsNothing()
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendResult(() => null);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("x");
    }

    [Test]
    public async Task AppendResult_WithFuncAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((StringBuilder)null!).AppendResult(() => "abc");

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task AppendResult_WithNullProvider_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new StringBuilder().AppendResult(null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("provider");
    }

    [Test]
    public async Task AppendResult_WithReadOnlySpanFunc_AppendsResult()
    {
        var builder = new StringBuilder("x");

        var result = builder.AppendResult("abc".AsSpan);

        await Assert.That(result).IsSameReferenceAs(builder);
        await Assert.That(builder.ToString()).IsEqualTo("xabc");
    }

    [Test]
    public async Task AppendResult_WithReadOnlySpanFuncAndNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((StringBuilder)null!).AppendResult("abc".AsSpan);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task AppendResult_WithNullReadOnlySpanFunc_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new StringBuilder().AppendResult((ReadOnlySpanFunc<char>)null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("func");
    }
}
