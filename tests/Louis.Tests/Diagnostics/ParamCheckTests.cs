// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

internal sealed class ParamCheckTests
{
    [Test]
    public async Task Check_HoldsValueAndExpressionOfArgument()
    {
        var value = new object();

        var param = Param.Check(value);

        await Assert.That(param.Value).IsSameReferenceAs(value);
        await Assert.That(param.Name).IsEqualTo("value");
    }

    [Test]
    public async Task Check_WithExplicitName_HoldsName()
    {
        var value = new object();

        // ReSharper disable once ExplicitCallerInfoArgument // the test passes the name on purpose
        var param = Param.Check(value, "other");

        await Assert.That(param.Value).IsSameReferenceAs(value);
        await Assert.That(param.Name).IsEqualTo("other");
    }

    [Test]
    public async Task Check_WithNull_HoldsNull()
    {
        static Param<string?> Start(string? text) => Param.Check(text);

        var param = Start(null);

        await Assert.That(param.Value).IsNull();
        await Assert.That(param.Name).IsEqualTo("text");
    }

    [Test]
    public async Task Check_WithArray_ReturnsParamOfArray()
    {
        var items = new int[3];

        Param<int[]> param = Param.Check(items);

        await Assert.That(param.Value).IsSameReferenceAs(items);
        await Assert.That(param.Name).IsEqualTo("items");
    }

    [Test]
    [Arguments("abc")]
    public async Task Check_WithString_ReturnsParamOfString(string text)
    {
        Param<string> param = Param.Check(text);

        await Assert.That(param.Value).IsSameReferenceAs(text);
        await Assert.That(param.Name).IsEqualTo("text");
    }

    [Test]
    public async Task Check_WithReadOnlySpan_HoldsSpanAndExpressionOfArgument()
    {
        static CheckOutcome Start()
        {
            ReadOnlySpan<int> items = new int[3];
            ReadOnlySpanParam<int> param = Param.Check(items);
            return new(param.Value == items, param.Name);
        }

        var outcome = Start();

        await Assert.That(outcome.SameValue).IsTrue();
        await Assert.That(outcome.Name).IsEqualTo("items");
    }

    [Test]
    public async Task Check_WithReadOnlySpanAndExplicitName_HoldsName()
    {
        static CheckOutcome Start()
        {
            ReadOnlySpan<int> items = new int[3];

            // ReSharper disable once ExplicitCallerInfoArgument // the test passes the name on purpose
            var param = Param.Check(items, "other");
            return new(param.Value == items, param.Name);
        }

        var outcome = Start();

        await Assert.That(outcome.SameValue).IsTrue();
        await Assert.That(outcome.Name).IsEqualTo("other");
    }

    [Test]
    public async Task Check_WithSpan_HoldsSpanAndExpressionOfArgument()
    {
        static CheckOutcome Start()
        {
            Span<int> items = new int[3];
            SpanParam<int> param = Param.Check(items);
            return new(param.Value == items, param.Name);
        }

        var outcome = Start();

        await Assert.That(outcome.SameValue).IsTrue();
        await Assert.That(outcome.Name).IsEqualTo("items");
    }

    [Test]
    public async Task Check_WithSpanAndExplicitName_HoldsName()
    {
        static CheckOutcome Start()
        {
            Span<int> items = new int[3];

            // ReSharper disable once ExplicitCallerInfoArgument // the test passes the name on purpose
            var param = Param.Check(items, "other");
            return new(param.Value == items, param.Name);
        }

        var outcome = Start();

        await Assert.That(outcome.SameValue).IsTrue();
        await Assert.That(outcome.Name).IsEqualTo("other");
    }
}
