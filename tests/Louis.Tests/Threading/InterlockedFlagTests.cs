// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;

internal sealed partial class InterlockedFlagTests
{
    [Test]
    [Arguments(false)]
    [Arguments(true)]
    public async Task Constructor_SetsValue(bool value)
    {
        var flag = new InterlockedFlag(value);

        await Assert.That(flag.Value).IsEqualTo(value);
    }

    [Test]
    public async Task DefaultValue_IsFalse()
    {
        var flag = default(InterlockedFlag);

        await Assert.That(flag.Value).IsFalse();
    }

    [Test]
    [Arguments(false)]
    [Arguments(true)]
    public async Task Value_Set_ChangesValue(bool value)
    {
        var flag = new InterlockedFlag(!value);

        flag.Value = value;

        await Assert.That(flag.Value).IsEqualTo(value);
    }

    [Test]
    [Arguments(false, false)]
    [Arguments(false, true)]
    [Arguments(true, false)]
    [Arguments(true, true)]
    public async Task CheckAndSet_SetsValueAndReturnsPreviousValue(bool initialValue, bool value)
    {
        var flag = new InterlockedFlag(initialValue);

        var previousValue = flag.CheckAndSet(value);

        await Assert.That(previousValue).IsEqualTo(initialValue);
        await Assert.That(flag.Value).IsEqualTo(value);
    }

    [Test]
    [Arguments(false, false, false)]
    [Arguments(false, true, true)]
    [Arguments(true, false, true)]
    [Arguments(true, true, false)]
    public async Task TrySet_WithValue_SetsValueAndReturnsWhetherItChanged(bool initialValue, bool value, bool expected)
    {
        var flag = new InterlockedFlag(initialValue);

        var result = flag.TrySet(value);

        await Assert.That(result).IsEqualTo(expected);
        await Assert.That(flag.Value).IsEqualTo(value);
    }

    [Test]
    [Arguments(false, true)]
    [Arguments(true, false)]
    public async Task TrySet_SetsFlagAndReturnsWhetherItChanged(bool initialValue, bool expected)
    {
        var flag = new InterlockedFlag(initialValue);

        var result = flag.TrySet();

        await Assert.That(result).IsEqualTo(expected);
        await Assert.That(flag.Value).IsTrue();
    }

    [Test]
    [Arguments(true, true)]
    [Arguments(false, false)]
    public async Task TryReset_ResetsFlagAndReturnsWhetherItChanged(bool initialValue, bool expected)
    {
        var flag = new InterlockedFlag(initialValue);

        var result = flag.TryReset();

        await Assert.That(result).IsEqualTo(expected);
        await Assert.That(flag.Value).IsFalse();
    }

    [Test]
    public async Task TrySet_InParallel_SucceedsOnce()
    {
        var flag = new SharedFlag();
        var successes = 0;

        void TrySet()
        {
            if (flag.TrySet())
            {
                _ = Interlocked.Increment(ref successes);
            }
        }

        _ = Parallel.For(0, 1000, _ => TrySet());

        await Assert.That(successes).IsEqualTo(1);
        await Assert.That(flag.Value).IsTrue();
    }

    [Test]
    [Arguments(false, false, true)]
    [Arguments(false, true, false)]
    [Arguments(true, false, false)]
    [Arguments(true, true, true)]
    public async Task Equality_WithFlag_ComparesValues(bool a, bool b, bool expected)
    {
        var flagA = new InterlockedFlag(a);
        var flagB = new InterlockedFlag(b);

        await Assert.That(flagA == flagB).IsEqualTo(expected);
        await Assert.That(flagA != flagB).IsEqualTo(!expected);
        await Assert.That(flagA.Equals(flagB)).IsEqualTo(expected);
        await Assert.That(flagA.Equals((object)flagB)).IsEqualTo(expected);
    }

    [Test]
    [Arguments(false, false, true)]
    [Arguments(false, true, false)]
    [Arguments(true, false, false)]
    [Arguments(true, true, true)]
    public async Task Equality_WithBool_ComparesValue(bool a, bool b, bool expected)
    {
        var flag = new InterlockedFlag(a);

        await Assert.That(flag == b).IsEqualTo(expected);
        await Assert.That(flag != b).IsEqualTo(!expected);
        await Assert.That(flag.Equals(b)).IsEqualTo(expected);

        // ReSharper disable SuspiciousTypeConversion.Global // Equals(object) with a value of another type is the case under test
        await Assert.That(flag.Equals((object)b)).IsEqualTo(expected);
        // ReSharper restore SuspiciousTypeConversion.Global
    }

    [Test]
    public async Task Equals_WithOtherObject_ReturnsFalse()
    {
        var flag = new InterlockedFlag(true);

        // ReSharper disable SuspiciousTypeConversion.Global // Equals(object) with a value of another type is the case under test
        await Assert.That(flag.Equals("True")).IsFalse();
        // ReSharper restore SuspiciousTypeConversion.Global
        await Assert.That(flag.Equals(null)).IsFalse();
    }

    [Test]
    [Arguments(false)]
    [Arguments(true)]
    public async Task GetHashCode_ReturnsHashCodeOfValue(bool value)
    {
        var flag = new InterlockedFlag(value);

        await Assert.That(flag.GetHashCode()).IsEqualTo(value.GetHashCode());
    }

    [Test]
    [Arguments(false, "False")]
    [Arguments(true, "True")]
    public async Task ToString_ReturnsStringOfValue(bool value, string expected)
    {
        var flag = new InterlockedFlag(value);

        await Assert.That(flag.ToString()).IsEqualTo(expected);
    }
}
