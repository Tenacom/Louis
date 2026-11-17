// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Text;
using Louis.IO;

internal sealed class TextFileContentTests
{
    [Test]
    public async Task Constructor_SetsProperties()
    {
        var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

        var content = new TextFileContent("text", encoding);

        await Assert.That(content.Text).IsEqualTo("text");
        await Assert.That(content.Encoding).IsSameReferenceAs(encoding);
    }

    [Test]
    public async Task Constructor_WithNullText_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => _ = new TextFileContent(null!, Encoding.UTF8);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("text");
    }

    [Test]
    public async Task Constructor_WithNullEncoding_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => _ = new TextFileContent("text", null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("encoding");
    }

    [Test]
    public async Task Deconstruct_ReturnsTextAndEncoding()
    {
        var content = new TextFileContent("text", Encoding.Unicode);

        var (text, encoding) = content;

        await Assert.That(text).IsEqualTo("text");
        await Assert.That(encoding).IsSameReferenceAs(Encoding.Unicode);
    }
}
