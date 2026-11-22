// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

internal sealed class ParamExtensionsEqualityTests
{
    [Test]
    public async Task Default_WithDefaultValue_ReturnsSameParam()
    {
        var id = Guid.Empty;

        var param = Param.Check(id).Default();

        await Assert.That(param.Value).IsEqualTo(Guid.Empty);
        await Assert.That(param.Name).IsEqualTo("id");
    }

    [Test]
    public async Task Default_WithOtherValue_ThrowsArgumentException()
    {
        static void Act(int number) => Param.Check(number).Default();

        await Assert.That(() => Act(5))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("number (5) must be the default value of its type.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    public async Task Default_WithMessage_FormatsMessage()
    {
        static void Act(int number) => Param.Check(number).Default("{0} is {1}.");

        await Assert.That(() => Act(5))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("number is 5.", StringComparison.Ordinal);
    }

    [Test]
    public async Task NotDefault_WithOtherValue_ReturnsSameParam()
    {
        static Param<int> Check(int number) => Param.Check(number).NotDefault();

        var param = Check(5);

        await Assert.That(param.Value).IsEqualTo(5);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    public async Task NotDefault_WithDefaultValue_ThrowsArgumentException()
    {
        static void Act(Guid id) => Param.Check(id).NotDefault();

        await Assert.That(() => Act(Guid.Empty))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("id must not be the default value of its type.", StringComparison.Ordinal)
            .And.WithParameterName("id");
    }

    [Test]
    public async Task NotDefault_WithMessage_FormatsMessage()
    {
        static void Act(int number) => Param.Check(number).NotDefault("{0} is {1}.");

        await Assert.That(() => Act(0))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("number is 0.", StringComparison.Ordinal);
    }

    [Test]
    public async Task EqualTo_WithEqualValue_ReturnsSameParam()
    {
        var text = new string('a', 3);

        var param = Param.Check(text).EqualTo("aaa");

        await Assert.That(param.Value).IsSameReferenceAs(text);
        await Assert.That(param.Name).IsEqualTo("text");
    }

    [Test]
    public async Task EqualTo_WithOtherValue_ThrowsArgumentException()
    {
        static void Act(int number) => Param.Check(number).EqualTo(6);

        await Assert.That(() => Act(5))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("number (5) must be equal to 6.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    public async Task EqualTo_WithMessage_FormatsMessage()
    {
        static void Act(int number) => Param.Check(number).EqualTo(6, "{0}: {1} is not {2}.");

        await Assert.That(() => Act(5))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("number: 5 is not 6.", StringComparison.Ordinal);
    }

    [Test]
    public async Task NotEqualTo_WithOtherValue_ReturnsSameParam()
    {
        static Param<int> Check(int number) => Param.Check(number).NotEqualTo(6);

        var param = Check(5);

        await Assert.That(param.Value).IsEqualTo(5);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    public async Task NotEqualTo_WithEqualValue_ThrowsArgumentException()
    {
        static void Act(string text) => Param.Check(text).NotEqualTo("aaa");

        await Assert.That(() => Act(new string('a', 3)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""text must not be equal to "aaa".""", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task NotEqualTo_WithMessage_FormatsMessage()
    {
        static void Act(int number) => Param.Check(number).NotEqualTo(5, "{0}: {1} is {2}.");

        await Assert.That(() => Act(5))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("number: 5 is 5.", StringComparison.Ordinal);
    }

    [Test]
    public async Task BitwiseEqualTo_WithSameBytes_ReturnsSameParam()
    {
        var id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e");

        var param = Param.Check(id).BitwiseEqualTo(new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"));

        await Assert.That(param.Value).IsEqualTo(id);
        await Assert.That(param.Name).IsEqualTo("id");
    }

    [Test]
    public async Task BitwiseEqualTo_WithNaN_ReturnsSameParam()
    {
        // NaN is not equal to itself according to the equality operator, and its bytes are equal to themselves.
        static Param<double> Check(double ratio) => Param.Check(ratio).BitwiseEqualTo(double.NaN);

        var param = Check(double.NaN);

        await Assert.That(double.IsNaN(param.Value)).IsTrue();
        await Assert.That(param.Name).IsEqualTo("ratio");
    }

    [Test]
    public async Task BitwiseEqualTo_WithOtherBytes_ThrowsArgumentException()
    {
        static void Act(int number) => Param.Check(number).BitwiseEqualTo(6);

        await Assert.That(() => Act(5))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("number (5) must be a bitwise match for 6.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    public async Task BitwiseEqualTo_WithEqualValueOfOtherBytes_ThrowsArgumentException()
    {
        // Positive and negative zero are equal, and differ by the sign bit.
        static void Act(double ratio) => Param.Check(ratio).BitwiseEqualTo(-0.0);

        await Assert.That(() => Act(0.0)).ThrowsExactly<ArgumentException>().WithParameterName("ratio");
    }

    [Test]
    public async Task BitwiseEqualTo_WithMessage_FormatsMessage()
    {
        static void Act(int number) => Param.Check(number).BitwiseEqualTo(6, "{0}: {1} is not {2}.");

        await Assert.That(() => Act(5))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("number: 5 is not 6.", StringComparison.Ordinal);
    }
}
