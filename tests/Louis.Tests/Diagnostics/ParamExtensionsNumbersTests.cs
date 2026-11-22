// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

internal sealed class ParamExtensionsNumbersTests
{
    [Test]
    [Arguments(8, 10, 2U)]
    [Arguments(10, 10, 0U)]
    [Arguments(12, 10, 2U)]
    [Arguments(int.MinValue, int.MaxValue, uint.MaxValue)]
    [Arguments(int.MaxValue, int.MinValue, uint.MaxValue)]
    public async Task CloseTo_WithInt32WithinDelta_ReturnsSameParam(int number, int target, uint delta)
    {
        var param = Param.Check(number).CloseTo(target, delta);

        await Assert.That(param.Value).IsEqualTo(number);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    [Arguments(7, 10, 2U)]
    [Arguments(13, 10, 2U)]
    [Arguments(int.MinValue, int.MaxValue, uint.MaxValue - 1)]
    [Arguments(int.MaxValue, int.MinValue, uint.MaxValue - 1)]
    public async Task CloseTo_WithInt32BeyondDelta_ThrowsArgumentException(int number, int target, uint delta)
    {
        static void Act(int number, int target, uint delta) => Param.Check(number).CloseTo(target, delta);

        await Assert.That(() => Act(number, target, delta))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"number ({number}) must be within {delta} of {target}.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    [Arguments(7, 10, 2U)]
    [Arguments(13, 10, 2U)]
    [Arguments(int.MinValue, int.MaxValue, uint.MaxValue - 1)]
    public async Task NotCloseTo_WithInt32BeyondDelta_ReturnsSameParam(int number, int target, uint delta)
    {
        var param = Param.Check(number).NotCloseTo(target, delta);

        await Assert.That(param.Value).IsEqualTo(number);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    [Arguments(8, 10, 2U)]
    [Arguments(10, 10, 0U)]
    [Arguments(12, 10, 2U)]
    [Arguments(int.MinValue, int.MaxValue, uint.MaxValue)]
    public async Task NotCloseTo_WithInt32WithinDelta_ThrowsArgumentException(int number, int target, uint delta)
    {
        static void Act(int number, int target, uint delta) => Param.Check(number).NotCloseTo(target, delta);

        await Assert.That(() => Act(number, target, delta))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"number ({number}) must not be within {delta} of {target}.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    [Arguments(8L, 10L, 2UL)]
    [Arguments(12L, 10L, 2UL)]
    [Arguments(long.MinValue, long.MaxValue, ulong.MaxValue)]
    [Arguments(long.MaxValue, long.MinValue, ulong.MaxValue)]
    public async Task CloseTo_WithInt64WithinDelta_ReturnsSameParam(long number, long target, ulong delta)
    {
        var param = Param.Check(number).CloseTo(target, delta);

        await Assert.That(param.Value).IsEqualTo(number);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    [Arguments(7L, 10L, 2UL)]
    [Arguments(13L, 10L, 2UL)]
    [Arguments(long.MinValue, long.MaxValue, ulong.MaxValue - 1)]
    public async Task CloseTo_WithInt64BeyondDelta_ThrowsArgumentException(long number, long target, ulong delta)
    {
        static void Act(long number, long target, ulong delta) => Param.Check(number).CloseTo(target, delta);

        await Assert.That(() => Act(number, target, delta))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"number ({number}) must be within {delta} of {target}.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    [Arguments(7L, 10L, 2UL)]
    [Arguments(long.MinValue, long.MaxValue, ulong.MaxValue - 1)]
    public async Task NotCloseTo_WithInt64BeyondDelta_ReturnsSameParam(long number, long target, ulong delta)
    {
        var param = Param.Check(number).NotCloseTo(target, delta);

        await Assert.That(param.Value).IsEqualTo(number);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    [Arguments(8L, 10L, 2UL)]
    [Arguments(long.MinValue, long.MaxValue, ulong.MaxValue)]
    public async Task NotCloseTo_WithInt64WithinDelta_ThrowsArgumentException(long number, long target, ulong delta)
    {
        static void Act(long number, long target, ulong delta) => Param.Check(number).NotCloseTo(target, delta);

        await Assert.That(() => Act(number, target, delta))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"number ({number}) must not be within {delta} of {target}.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    // An attribute cannot hold a native integer, so the tests of nint take 32-bit arguments.
    [Test]
    [Arguments(8, 10, 2U)]
    [Arguments(12, 10, 2U)]
    [Arguments(-5, 5, 10U)]
    public async Task CloseTo_WithIntPtrWithinDelta_ReturnsSameParam(int value, int target, uint delta)
    {
        nint number = value;

        var param = Param.Check(number).CloseTo(target, delta);

        await Assert.That(param.Value).IsEqualTo(number);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    [Arguments(7, 10, 2U)]
    [Arguments(13, 10, 2U)]
    [Arguments(-5, 5, 9U)]
    public async Task CloseTo_WithIntPtrBeyondDelta_ThrowsArgumentException(int value, int target, uint delta)
    {
        static void Act(nint number, nint target, nuint delta) => Param.Check(number).CloseTo(target, delta);

        await Assert.That(() => Act(value, target, delta))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"number ({value}) must be within {delta} of {target}.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    public async Task CloseTo_WithIntPtrExtremes_ReturnsSameParam()
    {
        // The size of a native integer depends on the process, and its limits are not constants on every framework.
        var is64Bit = Environment.Is64BitProcess;
        var number = is64Bit ? unchecked((nint)long.MinValue) : int.MinValue;
        var target = is64Bit ? unchecked((nint)long.MaxValue) : int.MaxValue;
        var delta = is64Bit ? unchecked((nuint)ulong.MaxValue) : uint.MaxValue;

        var param = Param.Check(number).CloseTo(target, delta);

        await Assert.That(param.Value).IsEqualTo(number);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    public async Task CloseTo_WithIntPtrExtremesAndLesserDelta_ThrowsArgumentException()
    {
        static void Act(nint number, nint target, nuint delta) => Param.Check(number).CloseTo(target, delta);

        var is64Bit = Environment.Is64BitProcess;
        var number = is64Bit ? unchecked((nint)long.MinValue) : int.MinValue;
        var target = is64Bit ? unchecked((nint)long.MaxValue) : int.MaxValue;
        var delta = is64Bit ? unchecked((nuint)(ulong.MaxValue - 1)) : uint.MaxValue - 1;

        await Assert.That(() => Act(number, target, delta)).ThrowsExactly<ArgumentException>().WithParameterName("number");
    }

    [Test]
    public async Task NotCloseTo_WithIntPtrBeyondDelta_ReturnsSameParam()
    {
        static Param<nint> Check(nint number) => Param.Check(number).NotCloseTo(10, 2);

        var param = Check(7);

        await Assert.That(param.Value).IsEqualTo(7);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    public async Task NotCloseTo_WithIntPtrWithinDelta_ThrowsArgumentException()
    {
        static void Act(nint number) => Param.Check(number).NotCloseTo(10, 2);

        await Assert.That(() => Act(8))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("number (8) must not be within 2 of 10.", StringComparison.Ordinal)
            .And.WithParameterName("number");
    }

    [Test]
    [Arguments(9.5f, 10f, 0.5f)]
    [Arguments(10f, 10f, 0f)]
    [Arguments(10.5f, 10f, 0.5f)]
    public async Task CloseTo_WithSingleWithinDelta_ReturnsSameParam(float number, float target, float delta)
    {
        var param = Param.Check(number).CloseTo(target, delta);

        await Assert.That(param.Value).IsEqualTo(number);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    [Arguments(9f, 10f, 0.5f)]
    [Arguments(11f, 10f, 0.5f)]
    [Arguments(float.NaN, 10f, 0.5f)]
    [Arguments(10f, float.NaN, 0.5f)]
    [Arguments(10f, 10f, float.NaN)]
    public async Task CloseTo_WithSingleBeyondDeltaOrNaN_ThrowsArgumentException(float number, float target, float delta)
    {
        static void Act(float number, float target, float delta) => Param.Check(number).CloseTo(target, delta);

        await Assert.That(() => Act(number, target, delta)).ThrowsExactly<ArgumentException>().WithParameterName("number");
    }

    [Test]
    [Arguments(9f, 10f, 0.5f)]
    [Arguments(11f, 10f, 0.5f)]
    public async Task NotCloseTo_WithSingleBeyondDelta_ReturnsSameParam(float number, float target, float delta)
    {
        var param = Param.Check(number).NotCloseTo(target, delta);

        await Assert.That(param.Value).IsEqualTo(number);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    [Arguments(9.5f, 10f, 0.5f)]
    [Arguments(10f, 10f, 0f)]
    [Arguments(float.NaN, 10f, 0.5f)]
    [Arguments(10f, float.NaN, 0.5f)]
    [Arguments(10f, 10f, float.NaN)]
    public async Task NotCloseTo_WithSingleWithinDeltaOrNaN_ThrowsArgumentException(float number, float target, float delta)
    {
        static void Act(float number, float target, float delta) => Param.Check(number).NotCloseTo(target, delta);

        await Assert.That(() => Act(number, target, delta)).ThrowsExactly<ArgumentException>().WithParameterName("number");
    }

    [Test]
    [Arguments(9.5, 10.0, 0.5)]
    [Arguments(10.0, 10.0, 0.0)]
    [Arguments(10.5, 10.0, 0.5)]
    public async Task CloseTo_WithDoubleWithinDelta_ReturnsSameParam(double number, double target, double delta)
    {
        var param = Param.Check(number).CloseTo(target, delta);

        await Assert.That(param.Value).IsEqualTo(number);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    [Arguments(9.0, 10.0, 0.5)]
    [Arguments(11.0, 10.0, 0.5)]
    [Arguments(double.NaN, 10.0, 0.5)]
    [Arguments(10.0, double.NaN, 0.5)]
    [Arguments(10.0, 10.0, double.NaN)]
    public async Task CloseTo_WithDoubleBeyondDeltaOrNaN_ThrowsArgumentException(double number, double target, double delta)
    {
        static void Act(double number, double target, double delta) => Param.Check(number).CloseTo(target, delta);

        await Assert.That(() => Act(number, target, delta)).ThrowsExactly<ArgumentException>().WithParameterName("number");
    }

    [Test]
    [Arguments(9.0, 10.0, 0.5)]
    [Arguments(11.0, 10.0, 0.5)]
    public async Task NotCloseTo_WithDoubleBeyondDelta_ReturnsSameParam(double number, double target, double delta)
    {
        var param = Param.Check(number).NotCloseTo(target, delta);

        await Assert.That(param.Value).IsEqualTo(number);
        await Assert.That(param.Name).IsEqualTo("number");
    }

    [Test]
    [Arguments(9.5, 10.0, 0.5)]
    [Arguments(10.0, 10.0, 0.0)]
    [Arguments(double.NaN, 10.0, 0.5)]
    [Arguments(10.0, double.NaN, 0.5)]
    [Arguments(10.0, 10.0, double.NaN)]
    public async Task NotCloseTo_WithDoubleWithinDeltaOrNaN_ThrowsArgumentException(double number, double target, double delta)
    {
        static void Act(double number, double target, double delta) => Param.Check(number).NotCloseTo(target, delta);

        await Assert.That(() => Act(number, target, delta)).ThrowsExactly<ArgumentException>().WithParameterName("number");
    }

    [Test]
    public async Task CloseTo_WithFloatingPointValues_NamesValuesInMessage()
    {
        static void ActSingle(float number) => Param.Check(number).CloseTo(10f, 0.5f);
        static void ActDouble(double number) => Param.Check(number).NotCloseTo(10.0, 0.5);

        await Assert.That(() => ActSingle(11f))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("number (11) must be within 0.5 of 10.", StringComparison.Ordinal);
        await Assert.That(() => ActDouble(10.25))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("number (10.25) must not be within 0.5 of 10.", StringComparison.Ordinal);
    }

    [Test]
    public async Task CloseTo_WithMessage_FormatsMessage()
    {
        static void Act(int number) => Param.Check(number).CloseTo(10, 2, "{0}: {1}, {2}, {3}");
        static void ActNot(int number) => Param.Check(number).NotCloseTo(10, 2, "{0}: {1}, {2}, {3}");

        await Assert.That(() => Act(13))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("number: 13, 10, 2", StringComparison.Ordinal);
        await Assert.That(() => ActNot(11))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("number: 11, 10, 2", StringComparison.Ordinal);
    }
}
