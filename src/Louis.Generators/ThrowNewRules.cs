// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Louis.Generators;

/// <summary>
/// Decides whether an attribute gets <c>ThrowNew</c> methods.
/// The source generator and <see cref="ThrowNewAttributeAnalyzer"/> both ask this class, so that they always agree.
/// </summary>
internal static class ThrowNewRules
{
    /// <summary>
    /// The oldest language version that compiles the methods added to an exception class.
    /// </summary>
    public const LanguageVersion MemberLanguageVersion = LanguageVersion.CSharp8;

    /// <summary>
    /// The oldest language version that compiles the extension methods added to a static class.
    /// </summary>
    public const LanguageVersion ExtensionLanguageVersion = LanguageVersion.CSharp14;

    /// <summary>
    /// Determines whether a constructor with <c>ThrowNewAttribute</c> gets <c>ThrowNew</c> methods.
    /// </summary>
    /// <param name="constructor">The constructor with the attribute.</param>
    /// <param name="compilation">The compilation that declares <paramref name="constructor"/>.</param>
    /// <returns><see cref="ThrowNewProblem.None"/> if the constructor gets the methods;
    /// otherwise, the reason why it gets none.</returns>
    public static ThrowNewProblem CheckConstructor(IMethodSymbol constructor, CSharpCompilation compilation)
    {
        var type = constructor.ContainingType;
        return compilation.LanguageVersion < MemberLanguageVersion ? ThrowNewProblem.LanguageVersion
            : constructor.IsStatic ? ThrowNewProblem.StaticConstructor
            : !IsExceptionType(type.BaseType, compilation) ? ThrowNewProblem.NotExceptionClass
            : type.IsAbstract ? ThrowNewProblem.AbstractClass
            : HasPointerParameter(constructor) ? ThrowNewProblem.PointerParameter
            : !IsPartialWithContainingTypes(type) ? ThrowNewProblem.NotPartial
            : ThrowNewProblem.None;
    }

    /// <summary>
    /// Determines whether a class with <c>ThrowNewForAttribute</c> gets <c>ThrowNew</c> extension methods.
    /// </summary>
    /// <param name="class">The class with the attribute.</param>
    /// <param name="attribute">The attribute.</param>
    /// <param name="compilation">The compilation that declares <paramref name="class"/>.</param>
    /// <param name="exceptionType">When this method returns, the type that the attribute names,
    /// or <see langword="null"/> if the attribute names no type that the compiler could resolve.</param>
    /// <param name="isPublic">When this method returns, <see langword="true"/> if the attribute asks for public methods;
    /// otherwise, <see langword="false"/>.</param>
    /// <returns><see cref="ThrowNewProblem.None"/> if the class gets the methods;
    /// otherwise, the reason why it gets none.</returns>
    public static ThrowNewProblem CheckExtensionClass(
        INamedTypeSymbol @class,
        AttributeData attribute,
        CSharpCompilation compilation,
        out ITypeSymbol? exceptionType,
        out bool isPublic)
    {
        var argument = attribute.ConstructorArguments.FirstOrDefault();
        exceptionType = argument is { Kind: TypedConstantKind.Type, Value: ITypeSymbol { TypeKind: not TypeKind.Error } type }
            ? type
            : null;

        // Public is the one property of the attribute that code can set, so a named argument is a value of Public.
        isPublic = attribute.NamedArguments.Any(static pair => Equals(pair.Value.Value, true));
        var isValidClass = @class is { IsStatic: true, ContainingType: null, IsGenericType: false } && IsPartial(@class);
        if (compilation.LanguageVersion < ExtensionLanguageVersion)
        {
            return ThrowNewProblem.LanguageVersion;
        }

        if (!isValidClass)
        {
            return ThrowNewProblem.InvalidExtensionClass;
        }

        if (exceptionType is null)
        {
            return ThrowNewProblem.UnresolvedExceptionType;
        }

        if (exceptionType is INamedTypeSymbol { IsUnboundGenericType: true })
        {
            return ThrowNewProblem.UnboundExceptionType;
        }

        if (exceptionType is not INamedTypeSymbol namedType || !IsExceptionType(namedType, compilation))
        {
            return ThrowNewProblem.NotExceptionType;
        }

        return namedType.IsAbstract ? ThrowNewProblem.AbstractExceptionType
            : isPublic && !IsPublicEverywhere(namedType) ? ThrowNewProblem.NonPublicExceptionType
            : !GetPublicConstructors(namedType).Any() ? ThrowNewProblem.NoPublicConstructor
            : ThrowNewProblem.None;
    }

    /// <summary>
    /// Gets the constructors of an exception type that get <c>ThrowNew</c> extension methods.
    /// </summary>
    /// <param name="exceptionType">The exception type.</param>
    /// <returns>The public instance constructors of <paramref name="exceptionType"/>
    /// that have no parameter of a pointer type.</returns>
    public static IEnumerable<IMethodSymbol> GetPublicConstructors(INamedTypeSymbol exceptionType)
        => exceptionType.InstanceConstructors.Where(static constructor
            => constructor.DeclaredAccessibility == Accessibility.Public && !HasPointerParameter(constructor));

    /// <summary>
    /// Determines whether a type is <c>System.Exception</c>, or a class that derives from it.
    /// </summary>
    /// <param name="type">The type to test.</param>
    /// <param name="compilation">The compilation that <paramref name="type"/> comes from.</param>
    /// <returns><see langword="true"/> if <paramref name="type"/> is an exception type;
    /// otherwise, <see langword="false"/>.</returns>
    public static bool IsExceptionType(ITypeSymbol? type, Compilation compilation)
    {
        var exception = compilation.GetTypeByMetadataName(WellKnownNames.Exception);
        for (var current = type; current is not null; current = current.BaseType)
        {
            if (SymbolEqualityComparer.Default.Equals(current, exception))
            {
                return true;
            }
        }

        return false;
    }

    private static bool HasPointerParameter(IMethodSymbol constructor)
        => constructor.Parameters.Any(static parameter => IsPointerOrArrayOfPointers(parameter.Type));

    private static bool IsPartialWithContainingTypes(INamedTypeSymbol type)
    {
        for (var current = type; current is not null; current = current.ContainingType)
        {
            if (!IsPartial(current))
            {
                return false;
            }
        }

        return true;
    }

    // The modifiers of a type declaration are tokens of its syntax node.
    private static bool IsPartial(INamedTypeSymbol type)
        => type.DeclaringSyntaxReferences.Any(static reference
            => reference.GetSyntax().ChildTokens().Any(static token => token.IsKind(SyntaxKind.PartialKeyword)));

    // A method cannot be more accessible than the type it extends.
    // A type argument and a containing type count, as well as the type itself.
    private static bool IsPublicEverywhere(INamedTypeSymbol type)
        => type.DeclaredAccessibility == Accessibility.Public
            && (type.ContainingType is null || IsPublicEverywhere(type.ContainingType))
            && type.TypeArguments.Select(GetElementType).OfType<INamedTypeSymbol>().All(IsPublicEverywhere);

    private static bool IsPointerOrArrayOfPointers(ITypeSymbol type)
        => GetElementType(type).TypeKind is TypeKind.Pointer or TypeKind.FunctionPointer;

    private static ITypeSymbol GetElementType(ITypeSymbol type)
    {
        var current = type;
        while (current is IArrayTypeSymbol array)
        {
            current = array.ElementType;
        }

        return current;
    }
}
