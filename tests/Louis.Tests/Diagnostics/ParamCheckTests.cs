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
}
