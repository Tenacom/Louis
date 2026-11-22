// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

internal sealed class ParamExtensionsNullTests
{
    [Test]
    public async Task Null_WithNullReference_ReturnsSameParam()
    {
        string? text = null;

        var param = Param.Check(text).Null();

        await Assert.That(param.Value).IsNull();
        await Assert.That(param.Name).IsEqualTo("text");
    }

    [Test]
    public async Task Null_WithNullNullableValue_ReturnsSameParam()
    {
        int? number = null;

        var param = Param.Check(number).Null();

        await Assert.That(param.Value).IsNull();
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    public async Task Null_WithReference_ThrowsArgumentException()
    {
        static void Act(string? text) => Param.Check(text).Null();

        await Assert.That(() => Act("abc"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""text ("abc") must be null.""", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task Null_WithNullableValue_ThrowsArgumentException()
    {
        static void Act(int? number) => Param.Check(number).Null();

        await Assert.That(() => Act(42))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("number (42) must be null.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    public async Task Null_WithMessage_FormatsMessage()
    {
        static void Act(int? number) => Param.Check(number).Null("{0} is {1}, and must be absent.");

        await Assert.That(() => Act(42))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("number is 42, and must be absent.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }
}
