// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

internal sealed class ParamExtensionsTypesTests
{
    [Test]
    public async Task OfType_WithValueOfType_ReturnsSameParam()
    {
        Stream stream = new MemoryStream();

        var param = Param.Check(stream).OfType(typeof(MemoryStream));

        await Assert.That(param.Value).IsSameReferenceAs(stream);
        await Assert.That(param.Name).IsEqualTo("stream");
    }

    [Test]
    public async Task OfType_WithValueOfValueType_ReturnsSameParam()
    {
        static Param<int> Check(int number) => Param.Check(number).OfType(typeof(int));

        var param = Check(42);

        await Assert.That(param.Value).IsEqualTo(42);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    public async Task OfType_WithValueOfDerivedType_ThrowsArgumentException()
    {
        static void Act(Stream stream) => Param.Check(stream).OfType(typeof(Stream));

        await Assert.That(() => Act(new MemoryStream()))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("stream (System.IO.MemoryStream) must be of type System.IO.Stream.", StringComparison.Ordinal)
            .And.WithParameterName("stream");
    }

    [Test]
    public async Task OfType_WithMessage_FormatsMessage()
    {
        static void Act(object value) => Param.Check(value).OfType(typeof(int), "{0} is {1}, not a {2}.");

        await Assert.That(() => Act("abc"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""value is "abc", not a System.Int32.""", StringComparison.Ordinal);
    }

    [Test]
    public async Task OfType_WithNullType_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act(object value) => Param.Check(value).OfType(null!);

        await Assert.That(() => Act("abc")).Throws<ArgumentNullException>().WithParameterName("type");
    }

    [Test]
    public async Task NotOfType_WithValueOfDerivedType_ReturnsSameParam()
    {
        Stream stream = new MemoryStream();

        var param = Param.Check(stream).NotOfType(typeof(Stream));

        await Assert.That(param.Value).IsSameReferenceAs(stream);
        await Assert.That(param.Name).IsEqualTo("stream");
    }

    [Test]
    public async Task NotOfType_WithValueOfType_ThrowsArgumentException()
    {
        static void Act(Stream stream) => Param.Check(stream).NotOfType(typeof(MemoryStream));

        await Assert.That(() => Act(new MemoryStream()))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining(
                "stream (System.IO.MemoryStream) must not be of type System.IO.MemoryStream.",
                StringComparison.Ordinal)
            .And.WithParameterName("stream");
    }

    [Test]
    public async Task NotOfType_WithNullType_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act(object value) => Param.Check(value).NotOfType(null!);

        await Assert.That(() => Act("abc")).Throws<ArgumentNullException>().WithParameterName("type");
    }

    [Test]
    [Arguments(typeof(MemoryStream))]
    [Arguments(typeof(Stream))]
    [Arguments(typeof(IDisposable))]
    [Arguments(typeof(object))]
    public async Task AssignableTo_WithAssignableValue_ReturnsSameParam(Type type)
    {
        Stream stream = new MemoryStream();

        var param = Param.Check(stream).AssignableTo(type);

        await Assert.That(param.Value).IsSameReferenceAs(stream);
        await Assert.That(param.Name).IsEqualTo("stream");
    }

    [Test]
    public async Task AssignableTo_WithValueNotAssignable_ThrowsArgumentException()
    {
        static void Act(object value) => Param.Check(value).AssignableTo(typeof(Stream));

        await Assert.That(() => Act("abc"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""value ("abc") must be assignable to type System.IO.Stream.""", StringComparison.Ordinal)
            .And.WithParameterName("value");
    }

    [Test]
    public async Task AssignableTo_WithNullType_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act(object value) => Param.Check(value).AssignableTo(null!);

        await Assert.That(() => Act("abc")).Throws<ArgumentNullException>().WithParameterName("type");
    }

    [Test]
    public async Task NotAssignableTo_WithValueNotAssignable_ReturnsSameParam()
    {
        object value = "abc";

        var param = Param.Check(value).NotAssignableTo(typeof(Stream));

        await Assert.That(param.Value).IsSameReferenceAs(value);
        await Assert.That(param.Name).IsEqualTo("value");
    }

    [Test]
    [Arguments(typeof(MemoryStream))]
    [Arguments(typeof(Stream))]
    [Arguments(typeof(IDisposable))]
    public async Task NotAssignableTo_WithAssignableValue_ThrowsArgumentException(Type type)
    {
        static void Act(Stream stream, Type type) => Param.Check(stream).NotAssignableTo(type);

        await Assert.That(() => Act(new MemoryStream(), type))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining(
                $"stream (System.IO.MemoryStream) must not be assignable to type {type}.",
                StringComparison.Ordinal)
            .And.WithParameterName("stream");
    }

    [Test]
    public async Task NotAssignableTo_WithNullType_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act(object value) => Param.Check(value).NotAssignableTo(null!);

        await Assert.That(() => Act("abc")).Throws<ArgumentNullException>().WithParameterName("type");
    }

    [Test]
    public async Task OfTypeWithTypeArgument_WithValueOfType_ReturnsParamOfType()
    {
        object value = "abc";

        // The declared type proves that the chain takes the checked type.
        Param<string> param = Param.Check(value).OfType<string>();

        await Assert.That(param.Value).IsSameReferenceAs(value);
        await Assert.That(param.Name).IsEqualTo("value");
    }

    [Test]
    public async Task OfTypeWithTypeArgument_WithValueOfValueType_ReturnsParamOfType()
    {
        object value = 42;

        Param<int> param = Param.Check(value).OfType<int>();

        await Assert.That(param.Value).IsEqualTo(42);
        await Assert.That(param.Name).IsEqualTo("value");
    }

    [Test]
    public async Task OfTypeWithTypeArgument_WithValueOfDerivedType_ThrowsArgumentException()
    {
        static void Act(object value) => Param.Check(value).OfType<Stream>();

        await Assert.That(() => Act(new MemoryStream()))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("value (System.IO.MemoryStream) must be of type System.IO.Stream.", StringComparison.Ordinal)
            .And.WithParameterName("value");
    }

    [Test]
    public async Task OfTypeWithTypeArgument_WithMessage_FormatsMessage()
    {
        static void Act(object value) => Param.Check(value).OfType<int>("{0} is {1}, not a {2}.");

        await Assert.That(() => Act("abc"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""value is "abc", not a System.Int32.""", StringComparison.Ordinal);
    }

    [Test]
    public async Task NotOfTypeWithTypeArgument_WithValueOfDerivedType_ReturnsSameParam()
    {
        object value = new MemoryStream();

        var param = Param.Check(value).NotOfType<Stream>();

        await Assert.That(param.Value).IsSameReferenceAs(value);
        await Assert.That(param.Name).IsEqualTo("value");
    }

    [Test]
    public async Task NotOfTypeWithTypeArgument_WithValueOfType_ThrowsArgumentException()
    {
        static void Act(object value) => Param.Check(value).NotOfType<string>();

        await Assert.That(() => Act("abc"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""value ("abc") must not be of type System.String.""", StringComparison.Ordinal)
            .And.WithParameterName("value");
    }

    [Test]
    public async Task AssignableToWithTypeArgument_WithAssignableValue_ReturnsParamOfType()
    {
        object value = new MemoryStream();

        Param<Stream> param = Param.Check(value).AssignableTo<Stream>();

        await Assert.That(param.Value).IsSameReferenceAs(value);
        await Assert.That(param.Name).IsEqualTo("value");
    }

    [Test]
    public async Task AssignableToWithTypeArgument_WithValueNotAssignable_ThrowsArgumentException()
    {
        static void Act(object value) => Param.Check(value).AssignableTo<Stream>();

        await Assert.That(() => Act("abc"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""value ("abc") must be assignable to type System.IO.Stream.""", StringComparison.Ordinal)
            .And.WithParameterName("value");
    }

    [Test]
    public async Task AssignableToWithTypeArgument_WithMessage_FormatsMessage()
    {
        static void Act(object value) => Param.Check(value).AssignableTo<Stream>("{0} is {1}, not a {2}.");

        await Assert.That(() => Act("abc"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""value is "abc", not a System.IO.Stream.""", StringComparison.Ordinal);
    }

    [Test]
    public async Task NotAssignableToWithTypeArgument_WithValueNotAssignable_ReturnsSameParam()
    {
        object value = "abc";

        var param = Param.Check(value).NotAssignableTo<Stream>();

        await Assert.That(param.Value).IsSameReferenceAs(value);
        await Assert.That(param.Name).IsEqualTo("value");
    }

    [Test]
    public async Task NotAssignableToWithTypeArgument_WithAssignableValue_ThrowsArgumentException()
    {
        static void Act(object value) => Param.Check(value).NotAssignableTo<Stream>();

        await Assert.That(() => Act(new MemoryStream()))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining(
                "value (System.IO.MemoryStream) must not be assignable to type System.IO.Stream.",
                StringComparison.Ordinal)
            .And.WithParameterName("value");
    }
}
