// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET9_0_OR_GREATER

using Louis.Diagnostics;

internal sealed class ParamCheckRefTests
{
    [Test]
    public async Task CheckRef_WithRefStruct_HoldsValueAndExpressionOfArgument()
    {
        static CheckOutcome Start()
        {
            ReadOnlySpan<int> items = new int[3];
            RefParam<ReadOnlySpan<int>> param = Param.CheckRef(items);
            return new(param.Value == items, param.Name);
        }

        var outcome = Start();

        await Assert.That(outcome.SameValue).IsTrue();
        await Assert.That(outcome.Name).IsEqualTo("items");
    }

    [Test]
    public async Task CheckRef_WithExplicitName_HoldsName()
    {
        static CheckOutcome Start()
        {
            ReadOnlySpan<int> items = new int[3];

            // ReSharper disable once ExplicitCallerInfoArgument // the test passes the name on purpose
            var param = Param.CheckRef(items, "other");
            return new(param.Value == items, param.Name);
        }

        var outcome = Start();

        await Assert.That(outcome.SameValue).IsTrue();
        await Assert.That(outcome.Name).IsEqualTo("other");
    }

    [Test]
    public async Task CheckRef_WithValueOfAnotherType_HoldsValue()
    {
        static CheckOutcome Start(Version version)
        {
            var param = Param.CheckRef(version);
            return new(ReferenceEquals(param.Value, version), param.Name);
        }

        var outcome = Start(new Version(1, 2));

        await Assert.That(outcome.SameValue).IsTrue();
        await Assert.That(outcome.Name).IsEqualTo("version");
    }
}

#endif
