// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Net.Mail;
using Louis.ComponentModel;
using TUnit.Assertions.Enums;

internal sealed class MailAddressCollectionConverterTests
{
    [Test]
    public async Task ConvertFrom_WithOneAddress_ReturnsCollectionWithOneAddress()
    {
        var converter = new MailAddressCollectionConverter();
        string[] expected = ["one@example.com"];

        var result = converter.ConvertFromString("one@example.com");

        var collection = await Assert.That(result).IsTypeOf<MailAddressCollection>().And.IsNotNull();
        await Assert.That(collection.Select(address => address.Address)).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task ConvertFrom_WithCommaSeparatedAddresses_ReturnsCollectionWithEveryAddress()
    {
        var converter = new MailAddressCollectionConverter();
        string[] expected = ["one@example.com", "two@example.com"];

        var result = converter.ConvertFromString("one@example.com, two@example.com");

        var collection = await Assert.That(result).IsTypeOf<MailAddressCollection>().And.IsNotNull();
        await Assert.That(collection.Select(address => address.Address)).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task ConvertFrom_WithEmptyString_ThrowsArgumentException()
    {
        static void Act() => new MailAddressCollectionConverter().ConvertFromString(string.Empty);

        var exception = Assert.Throws<ArgumentException>(Act);

        await Assert.That(exception.ParamName).IsEqualTo("value");
    }

    [Test]
    public async Task ConvertFrom_WithInvalidString_ThrowsArgumentExceptionWithFormatExceptionInside()
    {
        static void Act() => new MailAddressCollectionConverter().ConvertFromString("not an address");

        var exception = Assert.Throws<ArgumentException>(Act);

        await Assert.That(exception.ParamName).IsEqualTo("value");
        await Assert.That(exception.InnerException).IsTypeOf<FormatException>();
    }

    [Test]
    public async Task ConvertTo_WithCollection_ReturnsCommaSeparatedString()
    {
        var converter = new MailAddressCollectionConverter();
        var collection = new MailAddressCollection { new MailAddress("one@example.com"), new MailAddress("two@example.com") };

        await Assert.That(converter.ConvertToString(collection)).IsEqualTo("one@example.com, two@example.com");
    }
}
