// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Text;
using Louis.Diagnostics;

internal sealed class AppendFormattedObjectTests
{
    [Test]
    public async Task AppendFormattedObject_WithNullThis_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((StringBuilder)null!).AppendFormattedObject(42);

        var exception = Assert.Throws<ArgumentNullException>(Act);
        await Assert.That(exception.ParamName).IsEqualTo("this");
    }

    [Test]
    public async Task AppendFormattedObject_AppendsFormatObjectText()
    {
        var builder = new StringBuilder("value: ");

        builder.AppendFormattedObject(null);

        await Assert.That(builder.ToString()).IsEqualTo("value: <null>");
    }

    [Test]
    public async Task AppendFormattedObject_WithFormat_AppendsFormattedText()
    {
        var builder = new StringBuilder("value: ");

        builder.AppendFormattedObject(1.5, "F2");

        await Assert.That(builder.ToString()).IsEqualTo("value: 1.50");
    }

    [Test]
    public async Task AppendFormattedObject_ReturnsSameBuilder()
    {
        var builder = new StringBuilder();

        var result = builder.AppendFormattedObject("text");

        await Assert.That(result).IsSameReferenceAs(builder);
    }
}
