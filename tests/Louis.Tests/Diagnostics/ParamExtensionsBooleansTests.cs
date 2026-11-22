// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

internal sealed class ParamExtensionsBooleansTests
{
    [Test]
    public async Task True_WithTrue_ReturnsSameParam()
    {
        static Param<bool> Check(bool flag) => Param.Check(flag).True();

        var param = Check(true);

        await Assert.That(param.Value).IsTrue();
        await Assert.That(param.Name).IsEqualTo("flag");
    }

    [Test]
    public async Task True_WithFalse_ThrowsArgumentException()
    {
        static void Act(bool flag) => Param.Check(flag).True();

        await Assert.That(() => Act(false))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("flag must be true.", StringComparison.Ordinal)
            .And.WithParameterName("flag");
    }

    [Test]
    public async Task True_WithMessage_FormatsMessage()
    {
        static void Act(bool flag) => Param.Check(flag).True("{0} is {1}.");

        await Assert.That(() => Act(false))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("flag is False.", StringComparison.Ordinal)
            .And.WithParameterName("flag");
    }

    [Test]
    public async Task False_WithFalse_ReturnsSameParam()
    {
        static Param<bool> Check(bool flag) => Param.Check(flag).False();

        var param = Check(false);

        await Assert.That(param.Value).IsFalse();
        await Assert.That(param.Name).IsEqualTo("flag");
    }

    [Test]
    public async Task False_WithTrue_ThrowsArgumentException()
    {
        static void Act(bool flag) => Param.Check(flag).False();

        await Assert.That(() => Act(true))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("flag must be false.", StringComparison.Ordinal)
            .And.WithParameterName("flag");
    }

    [Test]
    public async Task False_WithMessage_FormatsMessage()
    {
        static void Act(bool flag) => Param.Check(flag).False("{0} is {1}.");

        await Assert.That(() => Act(true))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("flag is True.", StringComparison.Ordinal)
            .And.WithParameterName("flag");
    }

#if NET6_0_OR_GREATER
    [Test]
    public async Task True_WithTrueAndInterpolatedString_SkipsHoles()
    {
        var calls = 0;
        int Next() => ++calls;
        Param<bool> Check(bool flag) => Param.Check(flag).True($"call {Next()}");

        var param = Check(true);

        await Assert.That(param.Value).IsTrue();
        await Assert.That(calls).IsEqualTo(0);
    }

    [Test]
    public async Task True_WithFalseAndInterpolatedString_UsesTextAsItIs()
    {
        // The braces prove that the text is not processed as a composite format string.
        static void Act(bool flag, int count) => Param.Check(flag).True($"{{0}} items expected, {count} found.");

        await Assert.That(() => Act(false, 3))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("{0} items expected, 3 found.", StringComparison.Ordinal)
            .And.WithParameterName("flag");
    }

    [Test]
    public async Task False_WithFalseAndInterpolatedString_SkipsHoles()
    {
        var calls = 0;
        int Next() => ++calls;
        Param<bool> Check(bool flag) => Param.Check(flag).False($"call {Next()}");

        var param = Check(false);

        await Assert.That(param.Value).IsFalse();
        await Assert.That(calls).IsEqualTo(0);
    }

    [Test]
    public async Task False_WithTrueAndInterpolatedString_UsesTextAsItIs()
    {
        // The braces prove that the text is not processed as a composite format string.
        static void Act(bool flag, int count) => Param.Check(flag).False($"{{0}} items expected, {count} found.");

        await Assert.That(() => Act(true, 3))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("{0} items expected, 3 found.", StringComparison.Ordinal)
            .And.WithParameterName("flag");
    }
#endif
}
