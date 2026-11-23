// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

namespace Louis.Diagnostics;

/// <summary>
/// Specifies that the source generator of L.o.U.I.S. adds <c>ThrowNew</c> methods for a constructor
/// to the exception class that declares the constructor.
/// </summary>
/// <remarks>
/// <para>For a constructor with this attribute, the source generator adds two static methods to the class.
/// Both methods have the parameters and the accessibility of the constructor,
/// and throw a new instance of the class that the constructor initializes.</para>
/// <para>The first method returns no value. Call it as a statement.</para>
/// <para>The second method has a type parameter, which is also its return type.
/// Call it where the code needs an expression of that type.</para>
/// <para>The class must be partial, must not be abstract, and must derive from <see cref="Exception"/>.
/// If the class is nested, the types that contain it must be partial too.</para>
/// <para>For a primary constructor, apply this attribute to the class declaration with the <c>method</c> target,
/// as in <c>[method: ThrowNew]</c>.</para>
/// <para>The code that the source generator adds needs C# 8 or later.</para>
/// </remarks>
/// <example>
/// <para>The following code declares an exception class, and throws an instance of it:</para>
/// <code>
/// public sealed partial class QuotaExceededException : Exception
/// {
///     [ThrowNew]
///     public QuotaExceededException(string message)
///         : base(message)
///     {
///     }
/// }
///
/// // As a statement
/// QuotaExceededException.ThrowNew("The quota is used up.");
///
/// // In an expression
/// return quota ?? QuotaExceededException.ThrowNew&lt;Quota&gt;("The account has no quota.");
/// </code>
/// </example>
/// <seealso cref="ThrowNewForAttribute"/>
[AttributeUsage(AttributeTargets.Constructor, Inherited = false)]
public sealed class ThrowNewAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ThrowNewAttribute"/> class.
    /// </summary>
    public ThrowNewAttribute()
    {
    }
}
