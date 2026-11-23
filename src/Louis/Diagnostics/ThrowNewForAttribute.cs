// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

namespace Louis.Diagnostics;

/// <summary>
/// Specifies that the source generator of L.o.U.I.S. adds <c>ThrowNew</c> extension methods for an exception type
/// to the static class that has the attribute.
/// </summary>
/// <remarks>
/// <para>Use this attribute for an exception type that you cannot change, such as a type of another assembly.
/// For an exception class of your own project, use <see cref="ThrowNewAttribute"/>.</para>
/// <para>For each public constructor of the exception type, the source generator adds two static extension methods
/// to the class. Both methods have the parameters of the constructor, and throw a new instance of the exception type.
/// Call them on the exception type, as in <c>JsonException.ThrowNew(message)</c>.</para>
/// <para>The first method returns no value. Call it as a statement.</para>
/// <para>The second method has a type parameter, which is also its return type.
/// Call it where the code needs an expression of that type.</para>
/// <para>The methods are <see langword="internal"/>, unless <see cref="Public"/> is <see langword="true"/>.
/// When two assemblies have public <c>ThrowNew</c> methods for one exception type,
/// a call is ambiguous in a project that references both.</para>
/// <para>The class must be static and partial, and must be neither nested nor generic.
/// A class holds the methods of one exception type.</para>
/// <para>The exception type must not be abstract, and must have at least one public constructor.
/// A constructor with a parameter of a pointer type gets no method.</para>
/// <para>The code that the source generator adds needs C# 14 or later.</para>
/// </remarks>
/// <example>
/// <para>The following code declares <c>ThrowNew</c> methods for an exception type of the base class library,
/// and throws an instance of it:</para>
/// <code>
/// [ThrowNewFor(typeof(JsonException))]
/// internal static partial class JsonExceptionExtensions;
///
/// // As a statement
/// JsonException.ThrowNew("The document has no root object.");
///
/// // In an expression
/// return root ?? JsonException.ThrowNew&lt;JsonObject&gt;("The document has no root object.");
/// </code>
/// </example>
/// <seealso cref="ThrowNewAttribute"/>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class ThrowNewForAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ThrowNewForAttribute"/> class.
    /// </summary>
    /// <param name="exceptionType">The exception type that gets the <c>ThrowNew</c> methods.</param>
    public ThrowNewForAttribute(Type exceptionType)
    {
        ExceptionType = exceptionType;
    }

    /// <summary>
    /// Gets the exception type that gets the <c>ThrowNew</c> methods.
    /// </summary>
    public Type ExceptionType { get; }

    /// <summary>
    /// Gets or sets a value indicating whether the <c>ThrowNew</c> methods are public.
    /// </summary>
    /// <value><see langword="true"/> if the methods are <see langword="public"/>;
    /// <see langword="false"/> if they are <see langword="internal"/>. The default is <see langword="false"/>.</value>
    public bool Public { get; set; }
}
