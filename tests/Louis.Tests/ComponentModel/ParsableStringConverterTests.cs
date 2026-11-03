// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET7_0_OR_GREATER

using System.Globalization;
using Louis.ComponentModel;

internal sealed partial class ParsableStringConverterTests
{
    [Test]
    public async Task ConvertFrom_WithParsableString_ParsesWithCulture()
    {
        var converter = new ParsableStringConverter<double>();

        await Assert.That(converter.ConvertFromString(null, CommaCulture(), "1,5")).IsEqualTo(1.5);
    }

    [Test]
    public async Task ConvertFrom_WithUnparsableString_ThrowsArgumentException()
    {
        static void Act() => new ParsableStringConverter<double>().ConvertFromString("not a number");

        var exception = Assert.Throws<ArgumentException>(Act);

        await Assert.That(exception.ParamName).IsEqualTo("value");
    }

    [Test]
    public async Task ConvertTo_WithFormattable_FormatsWithCulture()
    {
        var converter = new ParsableStringConverter<double>();

        await Assert.That(converter.ConvertToString(null, CommaCulture(), 1.5)).IsEqualTo("1,5");
    }

    [Test]
    public async Task ConvertTo_WithNonFormattable_ReturnsToString()
    {
        var converter = new ParsableStringConverter<TestParsable>();

        await Assert.That(converter.ConvertToString(new TestParsable("text"))).IsEqualTo("text");
    }

    [Test]
    public async Task ConvertTo_WithNonFormattableWhoseToStringReturnsNull_ThrowsArgumentException()
    {
        static void Act() => new ParsableStringConverter<TestParsable>().ConvertToString(new TestParsable(null));

        await Assert.That(Act).Throws<ArgumentException>();
    }

    private static CultureInfo CommaCulture()
    {
        var culture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        culture.NumberFormat.NumberDecimalSeparator = ",";
        culture.NumberFormat.NumberGroupSeparator = ".";
        return culture;
    }
}

#endif
