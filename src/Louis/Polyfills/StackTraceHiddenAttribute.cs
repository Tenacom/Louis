// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if !NET6_0_OR_GREATER

// ReSharper disable once CheckNamespace // A stack trace formatter looks for the attribute by its namespace and its name.
namespace System.Diagnostics;

#if NETSTANDARD2_1_OR_GREATER

// The type is internal in this build, which also serves the versions of .NET whose BCL has the attribute.
// A public type would make the name of the attribute ambiguous in a project for one of those versions.
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Struct,
    Inherited = false)]
internal sealed class StackTraceHiddenAttribute : Attribute;

#else

/// <summary>
/// Indicates that a stack trace leaves out a method, or the methods of a type.
/// </summary>
/// <remarks>
/// <para>This type is available in the <c>netstandard2.0</c> and .NET Framework builds of Louis alone.
/// The BCL of the .NET builds has it, and the <c>netstandard2.1</c> build keeps it internal.</para>
/// <para>No runtime that loads one of these two builds looks for the attribute.
/// It is of use to code that formats a stack trace and looks for the attribute by name.</para>
/// <para>The .NET builds of Louis forward this type to the attribute of the BCL.
/// When an application loads a library that uses this type together with one of those builds,
/// the runtime honors the attribute.</para>
/// </remarks>
// The type is public for the source generators that run on a project that references Louis, ThrowNewGenerator included.
// A generator gives a method this attribute only when the project can name the attribute, and it does not see
// the output of another generator. An attribute that a generator of polyfills adds to the project would not count.
// A generator of polyfills, such as PolySharp, adds no type that the project can already name.
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Struct,
    Inherited = false)]
public sealed class StackTraceHiddenAttribute : Attribute;

#endif

#else

// A library for .NET Standard 2.0 that uses the attribute refers to it as a type of the Louis assembly.
// An application may load such a library together with this build, which does not declare the type.
[assembly: System.Runtime.CompilerServices.TypeForwardedTo(typeof(System.Diagnostics.StackTraceHiddenAttribute))]

#endif
