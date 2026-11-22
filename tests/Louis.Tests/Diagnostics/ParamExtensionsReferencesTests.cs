// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

internal sealed class ParamExtensionsReferencesTests
{
    [Test]
    public async Task ReferenceEqualTo_WithSameInstance_ReturnsSameParam()
    {
        var version = new Version(1, 2);

        var param = Param.Check(version).ReferenceEqualTo(version);

        await Assert.That(param.Value).IsSameReferenceAs(version);
        await Assert.That(param.Name).IsEqualTo("version");
    }

    [Test]
    public async Task ReferenceEqualTo_WithEqualInstance_ThrowsArgumentException()
    {
        static void Act(Version version) => Param.Check(version).ReferenceEqualTo(new Version(1, 2));

        await Assert.That(() => Act(new Version(1, 2)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("version (1.2) must be the same instance as 1.2.", StringComparison.Ordinal)
            .And.WithParameterName("version");
    }

    [Test]
    public async Task ReferenceEqualTo_WithMessage_FormatsMessage()
    {
        static void Act(Version version) => Param.Check(version).ReferenceEqualTo(new Version(3, 4), "{0}: {1} is not {2}.");

        await Assert.That(() => Act(new Version(1, 2)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("version: 1.2 is not 3.4.", StringComparison.Ordinal);
    }

    [Test]
    public async Task ReferenceNotEqualTo_WithEqualInstance_ReturnsSameParam()
    {
        var version = new Version(1, 2);

        var param = Param.Check(version).ReferenceNotEqualTo(new Version(1, 2));

        await Assert.That(param.Value).IsSameReferenceAs(version);
        await Assert.That(param.Name).IsEqualTo("version");
    }

    [Test]
    public async Task ReferenceNotEqualTo_WithSameInstance_ThrowsArgumentException()
    {
        static void Act(Version version) => Param.Check(version).ReferenceNotEqualTo(version);

        await Assert.That(() => Act(new Version(1, 2)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("version (1.2) must not be the same instance as 1.2.", StringComparison.Ordinal)
            .And.WithParameterName("version");
    }

    [Test]
    public async Task ReferenceNotEqualTo_WithMessage_FormatsMessage()
    {
        static void Act(Version version) => Param.Check(version).ReferenceNotEqualTo(version, "{0}: {1} is {2}.");

        await Assert.That(() => Act(new Version(1, 2)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("version: 1.2 is 1.2.", StringComparison.Ordinal);
    }
}
