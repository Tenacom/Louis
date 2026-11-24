// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if !NET6_0_OR_GREATER

// ReSharper disable once CheckNamespace // A stack trace formatter looks for the attribute by its namespace and its name.
namespace System.Diagnostics;

/// <summary>
/// Indicates that a stack trace leaves out a method, or the methods of a type.
/// </summary>
/// <remarks>
/// <para>This type is available in the <c>netstandard2.0</c> and .NET Framework builds of Louis alone,
/// because the BCL of every other build has it.</para>
/// <para>No runtime honors this type: .NET Framework looks for no such attribute,
/// and .NET looks for the attribute of its own BCL.
/// This type is of use to code that formats a stack trace and looks for the attribute by name.</para>
/// <para>The .NET builds of Louis forward this type to the attribute of the BCL.
/// When an application loads a library that uses this type together with one of those builds,
/// the runtime honors the attribute.</para>
/// </remarks>
// The type is public for the source generators that run on a project that references Louis, ThrowNewGenerator included.
// A source generator gives a method this attribute only when the project can name the attribute, and it does not see
// the output of another source generator. An attribute that PolySharp adds to the project would not count.
// PolySharp, a source generator of polyfills, adds no type that the project can already name.
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Struct,
    Inherited = false)]
public sealed class StackTraceHiddenAttribute : Attribute;

#else

// A library for .NET Standard 2.0 that uses the attribute refers to it as a type of the Louis assembly.
// An application may load such a library together with this build, which does not declare the type.
[assembly: System.Runtime.CompilerServices.TypeForwardedTo(typeof(System.Diagnostics.StackTraceHiddenAttribute))]

#endif
