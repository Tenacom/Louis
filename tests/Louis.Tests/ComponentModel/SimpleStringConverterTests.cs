// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

internal sealed partial class SimpleStringConverterTests
{
    [Test]
    public async Task CanConvertFrom_WithStringAndDelegate_ReturnsTrue()
    {
        var converter = new TestConverter(ParseInt, null);

        await Assert.That(converter.CanConvertFrom(typeof(string))).IsTrue();
    }

    [Test]
    public async Task CanConvertFrom_WithStringAndNoDelegate_ReturnsFalse()
    {
        var converter = new TestConverter(null, null);

        await Assert.That(converter.CanConvertFrom(typeof(string))).IsFalse();
    }

    [Test]
    [Arguments(typeof(InstanceDescriptor), true)]
    [Arguments(typeof(int), false)]
    public async Task CanConvertFrom_WithOtherType_ReturnsBaseResult(Type sourceType, bool expected)
    {
        var converter = new TestConverter(ParseInt, null);

        await Assert.That(converter.CanConvertFrom(sourceType)).IsEqualTo(expected);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task CanConvertTo_WithString_ReturnsTrue(bool withDelegate)
    {
        var converter = new TestConverter(null, withDelegate ? FormatInt : null);

        await Assert.That(converter.CanConvertTo(typeof(string))).IsTrue();
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task CanConvertTo_WithOtherType_ReturnsFalse(bool withDelegate)
    {
        var converter = new TestConverter(null, withDelegate ? FormatInt : null);

        await Assert.That(converter.CanConvertTo(typeof(int))).IsFalse();
    }

    [Test]
    public async Task ConvertFrom_WithStringAndDelegate_PassesContextCultureAndString()
    {
        ITypeDescriptorContext? seenContext = null;
        CultureInfo? seenCulture = null;
        string? seenValue = null;
        var converter = new TestConverter(Record, null);
        var descriptorContext = new TestDescriptorContext();

        var result = converter.ConvertFrom(descriptorContext, CultureInfo.InvariantCulture, "42");

        await Assert.That(result).IsEqualTo(42);
        await Assert.That(seenContext).IsSameReferenceAs(descriptorContext);
        await Assert.That(seenCulture).IsSameReferenceAs(CultureInfo.InvariantCulture);
        await Assert.That(seenValue).IsEqualTo("42");

        int Record(ITypeDescriptorContext? context, CultureInfo? culture, string value)
        {
            seenContext = context;
            seenCulture = culture;
            seenValue = value;
            return 42;
        }
    }

    [Test]
    public async Task ConvertFrom_WithStringAndNoDelegate_ThrowsNotSupportedException()
    {
        var converter = new TestConverter(null, null);

        await Assert.That(() => converter.ConvertFrom("42")).Throws<NotSupportedException>();
    }

    [Test]
    public async Task ConvertFrom_WithNonString_ThrowsNotSupportedException()
    {
        var converter = new TestConverter(ParseInt, null);

        await Assert.That(() => converter.ConvertFrom(42)).Throws<NotSupportedException>();
    }

    [Test]
    public async Task ConvertTo_WithTypedValueAndDelegate_PassesContextCultureAndValue()
    {
        ITypeDescriptorContext? seenContext = null;
        CultureInfo? seenCulture = null;
        int? seenValue = null;
        var converter = new TestConverter(null, Record);
        var descriptorContext = new TestDescriptorContext();

        var result = converter.ConvertTo(descriptorContext, CultureInfo.InvariantCulture, 42, typeof(string));

        await Assert.That(result).IsEqualTo("forty-two");
        await Assert.That(seenContext).IsSameReferenceAs(descriptorContext);
        await Assert.That(seenCulture).IsSameReferenceAs(CultureInfo.InvariantCulture);
        await Assert.That(seenValue).IsEqualTo(42);

        string Record(ITypeDescriptorContext? context, CultureInfo? culture, int value)
        {
            seenContext = context;
            seenCulture = culture;
            seenValue = value;
            return "forty-two";
        }
    }

    [Test]
    public async Task ConvertTo_WithTypedValueAndNoDelegate_ReturnsToString()
    {
        var converter = new TestConverter(null, null);

        await Assert.That(converter.ConvertToString(42)).IsEqualTo("42");
    }

    [Test]
    public async Task ConvertTo_WithValueOfOtherType_ReturnsBaseResult()
    {
        var converter = new TestConverter(null, FormatInt);

        await Assert.That(converter.ConvertToString(42L)).IsEqualTo("42");
    }

    [Test]
    public async Task ConvertTo_WithOtherDestinationType_ThrowsNotSupportedException()
    {
        var converter = new TestConverter(null, FormatInt);

        await Assert.That(() => converter.ConvertTo(42, typeof(long))).Throws<NotSupportedException>();
    }

    private static int ParseInt(ITypeDescriptorContext? context, CultureInfo? culture, string value)
        => int.Parse(value, CultureInfo.InvariantCulture);

    private static string FormatInt(ITypeDescriptorContext? context, CultureInfo? culture, int value)
        => "int:" + value.ToString(CultureInfo.InvariantCulture);
}
