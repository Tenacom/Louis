// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Reflection;
using Louis.Diagnostics;

// The tests find each attribute by name. A netstandard test project cannot name one in code,
// because the BCL of the framework it targets and the build of Louis it references both declare it.
internal sealed class PolyfillAttributesTests
{
    private const string DoesNotReturn = "System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute";
    private const string StackTraceHidden = "System.Diagnostics.StackTraceHiddenAttribute";

    private static readonly Assembly LouisAssembly = typeof(Param).Assembly;

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
    [Test]
    public async Task DoesNotReturnAttribute_IsNotDeclaredWhereBclHasIt()
        => await Assert.That(LouisAssembly.GetType(DoesNotReturn)).IsNull();
#else
    [Test]
    public async Task DoesNotReturnAttribute_IsPublicAttributeForMethods()
    {
        var type = await AssertAttributeFor(DoesNotReturn, AttributeTargets.Method);

        await Assert.That(type.IsPublic).IsTrue();
    }
#endif

#if NET6_0_OR_GREATER
    [Test]
    public async Task StackTraceHiddenAttribute_IsNotDeclaredWhereBclHasIt()
        => await Assert.That(LouisAssembly.GetType(StackTraceHidden)).IsNull();
#else
    [Test]
    public async Task StackTraceHiddenAttribute_IsPublicUnlessBuildServesFrameworkThatHasIt()
    {
        const AttributeTargets validOn = AttributeTargets.Class
            | AttributeTargets.Method
            | AttributeTargets.Constructor
            | AttributeTargets.Struct;
        var type = await AssertAttributeFor(StackTraceHidden, validOn);

#if NETSTANDARD2_1_OR_GREATER
        await Assert.That(type.IsPublic).IsFalse();
#else
        await Assert.That(type.IsPublic).IsTrue();
#endif
    }

    private static async Task<Type> AssertAttributeFor(string name, AttributeTargets validOn)
    {
        var type = await Assert.That(LouisAssembly.GetType(name)).IsNotNull();
        var usage = await Assert.That(type.GetCustomAttribute<AttributeUsageAttribute>()).IsNotNull();

        await Assert.That(Activator.CreateInstance(type, nonPublic: true)).IsAssignableTo<Attribute>();
        await Assert.That(usage.ValidOn).IsEqualTo(validOn);
        await Assert.That(usage.Inherited).IsFalse();
        return type;
    }
#endif
}
