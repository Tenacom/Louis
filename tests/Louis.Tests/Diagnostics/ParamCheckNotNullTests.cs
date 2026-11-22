// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

internal sealed class ParamCheckNotNullTests
{
    [Test]
    public async Task CheckNotNull_WithNullReference_ThrowsArgumentNullException()
    {
        static void Act(string? text) => Param.CheckNotNull(text);

        await Assert.That(() => Act(null))
            .Throws<ArgumentNullException>()
            .WithMessageContaining("text cannot be null.", StringComparison.Ordinal)
            .And.WithParameterName("text");
    }

    [Test]
    public async Task CheckNotNull_WithNullReferenceAndExplicitName_NamesParameter()
    {
        // ReSharper disable once ExplicitCallerInfoArgument // the test passes the name on purpose
        static void Act(string? text) => Param.CheckNotNull(text, "other");

        await Assert.That(() => Act(null)).Throws<ArgumentNullException>().WithParameterName("other");
    }

    [Test]
    public async Task CheckNotNull_WithReference_HoldsValueAndExpressionOfArgument()
    {
        var value = new object();

        var param = Param.CheckNotNull(value);

        await Assert.That(param.Value).IsSameReferenceAs(value);
        await Assert.That(param.Name).IsEqualTo("value");
    }

    [Test]
    public async Task CheckNotNull_WithNullNullableValue_ThrowsArgumentNullException()
    {
        static void Act(int? number) => Param.CheckNotNull(number);

        await Assert.That(() => Act(null))
            .Throws<ArgumentNullException>()
            .WithMessageContaining("number cannot be null.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    public async Task CheckNotNull_WithNullableValue_HoldsUnderlyingValue()
    {
        // The return type proves that the call binds to the overload for nullable value types.
        static Param<int> Start(int? number) => Param.CheckNotNull(number);

        var param = Start(42);

        await Assert.That(param.Value).IsEqualTo(42);
        await Assert.That(param.Name).IsEqualTo("number");
    }
}
