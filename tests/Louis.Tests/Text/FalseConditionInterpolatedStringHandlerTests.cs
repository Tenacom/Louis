// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET6_0_OR_GREATER

using System.Runtime.CompilerServices;
using Louis.Text;

internal sealed class FalseConditionInterpolatedStringHandlerTests
{
    [Test]
    public async Task Constructor_WithFalseCondition_EnablesFormatting()
    {
        await Assert.That(FormatUnless(false, $"a{1}b")).IsEqualTo("a1b");
    }

    [Test]
    public async Task Constructor_WithTrueCondition_DisablesFormatting()
    {
        await Assert.That(FormatUnless(true, $"a{1}b")).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task Constructor_WithFalseCondition_EvaluatesHoles()
    {
        var calls = 0;
        int Next() => ++calls;

        _ = FormatUnless(false, $"{Next()}");

        await Assert.That(calls).IsEqualTo(1);
    }

    [Test]
    public async Task Constructor_WithTrueCondition_SkipsHoles()
    {
        var calls = 0;
        int Next() => ++calls;

        _ = FormatUnless(true, $"{Next()}");

        await Assert.That(calls).IsEqualTo(0);
    }

    [Test]
    public async Task AppendLiteral_AppendsText()
    {
        await Assert.That(FormatUnless(false, $"abc")).IsEqualTo("abc");
    }

    [Test]
    public async Task AppendFormatted_WithValue_AppendsValue()
    {
        await Assert.That(FormatUnless(false, $"{42}")).IsEqualTo("42");
    }

    [Test]
    public async Task AppendFormatted_WithValueAndFormat_AppendsFormattedValue()
    {
        await Assert.That(FormatUnless(false, $"{42:X}")).IsEqualTo("2A");
    }

    [Test]
    public async Task AppendFormatted_WithValueAndAlignment_AppendsAlignedValue()
    {
        await Assert.That(FormatUnless(false, $"{42,4}")).IsEqualTo("  42");
    }

    [Test]
    public async Task AppendFormatted_WithValueAlignmentAndFormat_AppendsAlignedFormattedValue()
    {
        await Assert.That(FormatUnless(false, $"{42,4:X}")).IsEqualTo("  2A");
    }

    [Test]
    public async Task AppendFormatted_WithSpan_AppendsSpan()
    {
        await Assert.That(FormatUnless(false, $"{"abc".AsSpan()}")).IsEqualTo("abc");
    }

    [Test]
    public async Task AppendFormatted_WithSpanAndAlignment_AppendsAlignedSpan()
    {
        await Assert.That(FormatUnless(false, $"{"abc".AsSpan(),5}")).IsEqualTo("  abc");
    }

    [Test]
    public async Task AppendFormatted_WithString_AppendsString()
    {
        await Assert.That(FormatUnless(false, $"{"abc"}")).IsEqualTo("abc");
    }

    // A string hole with an alignment and no format binds to the generic overload, because the compiler
    // prefers a method whose parameters all have an argument, as it does with StringBuilder.AppendInterpolatedStringHandler.
    [Test]
    public async Task AppendFormatted_WithStringAlignmentAndFormat_AppendsAlignedString()
    {
        await Assert.That(FormatUnless(false, $"{"abc",-5:x}")).IsEqualTo("abc  ");
    }

    [Test]
    public async Task AppendFormatted_WithObjectAlignmentAndFormat_AppendsAlignedFormattedObject()
    {
        await Assert.That(FormatUnless(false, $"{(object)42,4:X}")).IsEqualTo("  2A");
    }

    [Test]
    public async Task ToStringAndClear_OnSecondCall_ReturnsEmptyString()
    {
        var (first, second) = FormatTwiceUnless(false, $"a{1}b");

        await Assert.That(first).IsEqualTo("a1b");
        await Assert.That(second).IsEqualTo(string.Empty);
    }

    // ReSharper disable once EntityNameCapturedOnly.Local // InterpolatedStringHandlerArgument passes condition to the handler
    private static string FormatUnless(
        bool condition,
        [InterpolatedStringHandlerArgument(nameof(condition))] ref FalseConditionInterpolatedStringHandler message)
        => message.ToStringAndClear();

    // ReSharper disable once EntityNameCapturedOnly.Local // InterpolatedStringHandlerArgument passes condition to the handler
    private static (string First, string Second) FormatTwiceUnless(
        bool condition,
        [InterpolatedStringHandlerArgument(nameof(condition))] ref FalseConditionInterpolatedStringHandler message)
        => (message.ToStringAndClear(), message.ToStringAndClear());
}

#endif
