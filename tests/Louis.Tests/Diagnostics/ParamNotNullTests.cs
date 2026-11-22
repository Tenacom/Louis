// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

internal sealed class ParamNotNullTests
{
    [Test]
    public async Task NotNull_WithNullReference_ThrowsArgumentNullException()
    {
        static void Act(string? text) => Param.NotNull(text);

        await Assert.That(() => Act(null))
            .Throws<ArgumentNullException>()
            .WithMessageContaining("text cannot be null.", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task NotNull_WithNullReferenceAndExplicitName_NamesParameter()
    {
        // ReSharper disable once ExplicitCallerInfoArgument // the test passes the name on purpose
        static void Act(string? text) => Param.NotNull(text, "other");

        await Assert.That(() => Act(null))
            .Throws<ArgumentNullException>()
            .WithMessageContaining("other cannot be null.", StringComparison.Ordinal)
            .And.WithParameterName("other");
    }

    [Test]
    public async Task NotNull_WithReference_ReturnsSameInstance()
    {
        var value = new object();

        var result = Param.NotNull(value);

        await Assert.That(result).IsSameReferenceAs(value);
    }

    [Test]
    public async Task NotNull_WithNullNullableValue_ThrowsArgumentNullException()
    {
        static void Act(int? number) => Param.NotNull(number);

        await Assert.That(() => Act(null))
            .Throws<ArgumentNullException>()
            .WithMessageContaining("number cannot be null.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    public async Task NotNull_WithNullableValue_ReturnsUnderlyingValue()
    {
        // The return type proves that the call binds to the overload for nullable value types.
        static int Unwrap(int? number) => Param.NotNull(number);

        await Assert.That(Unwrap(42)).IsEqualTo(42);
    }

    [Test]
    public async Task NotNull_WithNonNullableValue_ReturnsValue()
    {
        static int Check(int number) => Param.NotNull(number);

        await Assert.That(Check(42)).IsEqualTo(42);
    }
}
