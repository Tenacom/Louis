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
    public async Task DoesNotReturnAttribute_IsForwardedToBclWhereBclHasIt()
        => await AssertForwardedToBcl(DoesNotReturn);
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
    public async Task StackTraceHiddenAttribute_IsForwardedToBclWhereBclHasIt()
        => await AssertForwardedToBcl(StackTraceHidden);
#else
    [Test]
    public async Task StackTraceHiddenAttribute_IsPublicAttributeForTypesAndMethods()
    {
        const AttributeTargets validOn = AttributeTargets.Class
            | AttributeTargets.Method
            | AttributeTargets.Constructor
            | AttributeTargets.Struct;
        var type = await AssertAttributeFor(StackTraceHidden, validOn);

        await Assert.That(type.IsPublic).IsTrue();
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

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
    // A library for .NET Standard 2.0 that uses an attribute refers to it as a type of the Louis assembly.
    // Assembly.GetType follows a type forwarder, as the runtime does when it resolves that reference.
    private static async Task AssertForwardedToBcl(string name)
    {
        var type = await Assert.That(LouisAssembly.GetType(name)).IsNotNull();

        await Assert.That(type.Assembly).IsEqualTo(typeof(object).Assembly);
    }
#endif
}
