// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Globalization;
using System.Security;
using Louis.Diagnostics;

internal sealed partial class ExceptionHelperTests
{
    [Test]
    public async Task FormatObject_WithNull_ReturnsNullText()
        => await Assert.That(ExceptionHelper.FormatObject(null)).IsEqualTo("<null>");

    [Test]
    public async Task FormatObject_WithString_ReturnsQuotedLiteral()
    {
        const string expected = """
            "say \"hi\"\n"
            """;

        await Assert.That(ExceptionHelper.FormatObject("say \"hi\"\n")).IsEqualTo(expected);
    }

    [Test]
    public async Task FormatObject_WithStringOf43Characters_DoesNotClipIt()
    {
        const string text = "0123456789012345678901234567890123456789abc";

        await Assert.That(ExceptionHelper.FormatObject(text)).IsEqualTo("\"" + text + "\"");
    }

    [Test]
    public async Task FormatObject_WithStringOf44Characters_LeavesFirstAndLast20Characters()
    {
        const string text = "0123456789012345678901234567890123456789abcd";
        const string expected = """
            "01234567890123456789...4567890123456789abcd"
            """;

        await Assert.That(ExceptionHelper.FormatObject(text)).IsEqualTo(expected);
    }

    [Test]
    public async Task FormatObject_WithFormattable_PassesFormatAndInvariantCulture()
    {
        string? seenFormat = null;
        IFormatProvider? seenProvider = null;
        var formattable = new TestFormattable(Record, () => "plain");

        var result = ExceptionHelper.FormatObject(formattable, "X");

        await Assert.That(result).IsEqualTo("formatted");
        await Assert.That(seenFormat).IsEqualTo("X");
        await Assert.That(seenProvider).IsSameReferenceAs(CultureInfo.InvariantCulture);

        string Record(string? format, IFormatProvider? provider)
        {
            seenFormat = format;
            seenProvider = provider;
            return "formatted";
        }
    }

    [Test]
    [NotInParallel]
    public async Task FormatObject_WithFormattable_IgnoresCurrentCulture()
    {
        var commaCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        commaCulture.NumberFormat.NumberDecimalSeparator = ",";
        var previousCulture = CultureInfo.CurrentCulture;
        string result;
        CultureInfo.CurrentCulture = commaCulture;
        try
        {
            result = ExceptionHelper.FormatObject(1234.5, "F2");
        }
        finally
        {
            CultureInfo.CurrentCulture = previousCulture;
        }

        await Assert.That(result).IsEqualTo("1234.50");
    }

    [Test]
    public async Task FormatObject_WithFormattableAndNoFormat_PassesNullFormat()
        => await Assert.That(ExceptionHelper.FormatObject(1234.5)).IsEqualTo("1234.5");

    [Test]
    public async Task FormatObject_WithFormattableThrowingOnFormat_RetriesWithEmptyFormat()
    {
        var formattable = new TestFormattable(
            (format, _) => string.IsNullOrEmpty(format) ? "retried" : throw new FormatException(),
            () => "plain");

        await Assert.That(ExceptionHelper.FormatObject(formattable, "X")).IsEqualTo("retried");
    }

    [Test]
    [Arguments("")]
    [Arguments("X")]
    public async Task FormatObject_WithFormattableThrowingOnEveryFormat_ReturnsToString(string format)
    {
        var formattable = new TestFormattable((_, _) => throw new FormatException(), () => "plain");

        await Assert.That(ExceptionHelper.FormatObject(formattable, format)).IsEqualTo("plain");
    }

    [Test]
    public async Task FormatObject_WithFormattableThrowingEverywhere_ReturnsTypeNames()
    {
        var formattable = new TestFormattable(
            (_, _) => throw new FormatException(),
            () => throw new InvalidOperationException());

        await Assert.That(ExceptionHelper.FormatObject(formattable)).IsEqualTo("<TestFormattable:InvalidOperationException>");
    }

    [Test]
    public async Task FormatObject_WithNonFormattable_ReturnsToString()
    {
        var obj = new TestObject(() => "text");

        await Assert.That(ExceptionHelper.FormatObject(obj)).IsEqualTo("text");
    }

    [Test]
    public async Task FormatObject_WithNonFormattableWhoseToStringReturnsNull_ReturnsToStringNullText()
    {
        var obj = new TestObject(() => null);

        await Assert.That(ExceptionHelper.FormatObject(obj)).IsEqualTo("<null!>");
    }

    [Test]
    public async Task FormatObject_WithNonFormattableWhoseToStringReturnsEmpty_ReturnsToStringEmptyText()
    {
        var obj = new TestObject(() => string.Empty);

        await Assert.That(ExceptionHelper.FormatObject(obj)).IsEqualTo("<empty!>");
    }

    [Test]
    public async Task FormatObject_WithNonFormattableWhoseToStringThrows_ReturnsTypeNames()
    {
        var obj = new TestObject(() => throw new InvalidOperationException());

        await Assert.That(ExceptionHelper.FormatObject(obj)).IsEqualTo("<TestObject:InvalidOperationException>");
    }

    [Test]
    public async Task FormatObject_WithNonFormattableWhoseToStringThrowsCriticalError_Throws()
    {
        var obj = new TestObject(() => throw new SecurityException());

        await Assert.That(() => ExceptionHelper.FormatObject(obj)).Throws<SecurityException>();
    }

    [Test]
    public async Task FormatObject_WithNullableValue_FormatsBoxedValue()
    {
        int? value = 42;

        await Assert.That(ExceptionHelper.FormatObject(value, "D4")).IsEqualTo("0042");
    }
}
