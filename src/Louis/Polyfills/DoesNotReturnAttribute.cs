// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if !(NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER)

// ReSharper disable once CheckNamespace // The compiler knows the attribute by its namespace and its name.
namespace System.Diagnostics.CodeAnalysis;

/// <summary>
/// Indicates that a method never returns to its caller.
/// </summary>
/// <remarks>
/// <para>This type is available in the <c>netstandard2.0</c> and .NET Framework builds of Louis alone,
/// because the BCL of every other build has it.</para>
/// <para>The compiler takes this type for the attribute of the BCL.
/// A project that references Louis can therefore apply it to its own methods.</para>
/// <para>Every other build of Louis forwards this type to the attribute of the BCL.
/// An application can therefore load a library that uses this type together with any build of Louis.</para>
/// </remarks>
// The type is public for the source generators that run on a project that references Louis, ThrowNewGenerator included.
// A generator gives a method this attribute only when the project can name the attribute, and it does not see
// the output of another generator. An attribute that a generator of polyfills adds to the project would not count.
// A generator of polyfills, such as PolySharp, adds no type that the project can already name.
[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public sealed class DoesNotReturnAttribute : Attribute;

#else

// A library for .NET Standard 2.0 that uses the attribute refers to it as a type of the Louis assembly.
// An application may load such a library together with this build, which does not declare the type.
[assembly: System.Runtime.CompilerServices.TypeForwardedTo(typeof(System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute))]

#endif
