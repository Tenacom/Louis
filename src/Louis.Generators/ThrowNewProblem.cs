// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace Louis.Generators;

/// <summary>
/// Tells why the generator adds no <c>ThrowNew</c> method for an attribute.
/// </summary>
internal enum ThrowNewProblem
{
    /// <summary>
    /// The generator adds the methods.
    /// </summary>
    None,

    /// <summary>
    /// The language version of the project is older than the code of the generator needs.
    /// </summary>
    LanguageVersion,

    /// <summary>
    /// The constructor with the attribute is static.
    /// </summary>
    StaticConstructor,

    /// <summary>
    /// The constructor with the attribute belongs to a type that is not a class deriving from <c>System.Exception</c>.
    /// </summary>
    NotExceptionClass,

    /// <summary>
    /// The constructor with the attribute belongs to an abstract class.
    /// </summary>
    AbstractClass,

    /// <summary>
    /// The constructor with the attribute has a parameter of a pointer type.
    /// </summary>
    PointerParameter,

    /// <summary>
    /// The class of the constructor with the attribute, or a type that contains the class, is not partial.
    /// </summary>
    NotPartial,

    /// <summary>
    /// The class with the attribute is not static, not partial, nested, or generic.
    /// </summary>
    InvalidExtensionClass,

    /// <summary>
    /// The attribute names no type, or a type that the compiler could not resolve.
    /// </summary>
    UnresolvedExceptionType,

    /// <summary>
    /// The attribute names a type that is not <c>System.Exception</c>, nor a class deriving from it.
    /// </summary>
    NotExceptionType,

    /// <summary>
    /// The attribute names an unbound generic type.
    /// </summary>
    UnboundExceptionType,

    /// <summary>
    /// The attribute names an abstract class.
    /// </summary>
    AbstractExceptionType,

    /// <summary>
    /// The attribute asks for public methods, and names a type that is not public.
    /// </summary>
    NonPublicExceptionType,

    /// <summary>
    /// The attribute names a type with no public constructor that can get a method.
    /// </summary>
    NoPublicConstructor,
}
