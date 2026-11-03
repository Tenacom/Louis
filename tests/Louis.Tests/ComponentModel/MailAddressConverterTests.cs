// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Net.Mail;
using Louis.ComponentModel;

internal sealed class MailAddressConverterTests
{
    [Test]
    public async Task ConvertFrom_WithPlainAddress_ReturnsMailAddress()
    {
        var converter = new MailAddressConverter();

        var result = converter.ConvertFromString("someone@example.com");

        var address = await Assert.That(result).IsTypeOf<MailAddress>().And.IsNotNull();
        await Assert.That(address.Address).IsEqualTo("someone@example.com");
        await Assert.That(address.DisplayName).IsEmpty();
    }

    [Test]
    public async Task ConvertFrom_WithDisplayName_ReturnsMailAddress()
    {
        var converter = new MailAddressConverter();

        var result = converter.ConvertFromString("Someone <someone@example.com>");

        var address = await Assert.That(result).IsTypeOf<MailAddress>().And.IsNotNull();
        await Assert.That(address.Address).IsEqualTo("someone@example.com");
        await Assert.That(address.DisplayName).IsEqualTo("Someone");
    }

    [Test]
    public async Task ConvertFrom_WithInvalidString_ThrowsArgumentException()
    {
        static void Act() => new MailAddressConverter().ConvertFromString("not an address");

        var exception = Assert.Throws<ArgumentException>(Act);

        await Assert.That(exception.ParamName).IsEqualTo("value");
#if !NET5_0_OR_GREATER
        await Assert.That(exception.InnerException).IsTypeOf<FormatException>();
#endif
    }

    [Test]
    public async Task ConvertTo_WithMailAddress_ReturnsString()
    {
        var converter = new MailAddressConverter();

        await Assert.That(converter.ConvertToString(new MailAddress("someone@example.com"))).IsEqualTo("someone@example.com");
    }
}
