// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Louis.Generators;

/// <summary>
/// Turns symbols into the C# text that the generator writes.
/// </summary>
internal static class SymbolText
{
    private static readonly SymbolDisplayFormat TypeFormat = SymbolDisplayFormat.FullyQualifiedFormat
        .WithMiscellaneousOptions(
            SymbolDisplayMiscellaneousOptions.UseSpecialTypes
            | SymbolDisplayMiscellaneousOptions.EscapeKeywordIdentifiers
            | SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier);

    private static readonly SymbolDisplayFormat NamespaceFormat = SymbolDisplayFormat.FullyQualifiedFormat
        .WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.Omitted);

    private static readonly SymbolDisplayFormat DeclarationFormat = new(
        typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameOnly,
        genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters,
        miscellaneousOptions: SymbolDisplayMiscellaneousOptions.EscapeKeywordIdentifiers);

    // Each attribute of the two sets below takes strings and Booleans alone, which Constant can write.
    private static readonly HashSet<string> CopiedMethodAttributes = [
        "System.ObsoleteAttribute",
        "System.Diagnostics.CodeAnalysis.ExperimentalAttribute",
        "System.Diagnostics.CodeAnalysis.RequiresAssemblyFilesAttribute",
        "System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute",
        "System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute",
    ];

    private static readonly HashSet<string> CopiedParameterAttributes = [
        "System.Runtime.CompilerServices.CallerArgumentExpressionAttribute",
        "System.Runtime.CompilerServices.CallerFilePathAttribute",
        "System.Runtime.CompilerServices.CallerLineNumberAttribute",
        "System.Runtime.CompilerServices.CallerMemberNameAttribute",
    ];

    /// <summary>
    /// Gets the name of a type, as code in any namespace can write it.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>The fully qualified name of <paramref name="type"/>, with its nullable annotations.</returns>
    public static string TypeName(ITypeSymbol type) => type.ToDisplayString(TypeFormat);

    /// <summary>
    /// Gets the name of a namespace.
    /// </summary>
    /// <param name="namespace">The namespace.</param>
    /// <returns>The full name of <paramref name="namespace"/>.</returns>
    public static string NamespaceName(INamespaceSymbol @namespace) => @namespace.ToDisplayString(NamespaceFormat);

    /// <summary>
    /// Gets the text that opens a partial declaration of a type.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>The <see langword="partial"/> modifier, the keyword of <paramref name="type"/>,
    /// and its name with its type parameters.</returns>
    public static string PartialDeclaration(INamedTypeSymbol type)
    {
        var keyword = type switch {
            { IsRecord: true, TypeKind: TypeKind.Struct } => "record struct",
            { IsRecord: true } => "record",
            { TypeKind: TypeKind.Struct } => "struct",
            { TypeKind: TypeKind.Interface } => "interface",
            _ => "class",
        };

        return $"partial {keyword} {type.ToDisplayString(DeclarationFormat)}";
    }

    /// <summary>
    /// Gets the identifier of a symbol in its XML documentation.
    /// </summary>
    /// <param name="symbol">The symbol.</param>
    /// <returns>The documentation comment identifier of the definition of <paramref name="symbol"/>.</returns>
    public static string? DocumentationId(ISymbol symbol) => symbol.OriginalDefinition.GetDocumentationCommentId();

    /// <summary>
    /// Gets the attributes of a constructor that its <c>ThrowNew</c> methods take.
    /// </summary>
    /// <param name="constructor">The constructor.</param>
    /// <returns>The text of each attribute, without brackets.</returns>
    /// <remarks>
    /// <para>The compiler reports a call to an obsolete or experimental constructor,
    /// unless the caller has the attribute too.
    /// The trim analyzers do the same for a constructor that needs code which trimming may remove.</para>
    /// </remarks>
    public static IEnumerable<string> CopiedAttributes(IMethodSymbol constructor)
        => CopyAttributes(constructor.GetAttributes(), CopiedMethodAttributes);

    /// <summary>
    /// Gets the declaration of a parameter that forwards its argument to a parameter of a constructor.
    /// </summary>
    /// <param name="parameter">The parameter of the constructor.</param>
    /// <returns>The attributes that supply caller information, the modifiers, the type, the name,
    /// and the default value of <paramref name="parameter"/>.</returns>
    public static string ParameterDeclaration(IParameterSymbol parameter)
    {
        var builder = new StringBuilder();
        foreach (var attribute in CopyAttributes(parameter.GetAttributes(), CopiedParameterAttributes))
        {
            _ = builder.Append('[').Append(attribute).Append("] ");
        }

        // The base class library of .NET Framework and .NET Standard 2.0 has no nullable annotations.
        // A reference type without an annotation accepts null there, so the parameter accepts it too.
        var type = parameter.Type;
        var isOblivious = type.IsReferenceType && parameter.NullableAnnotation == NullableAnnotation.None;
        var annotation = isOblivious ? NullableAnnotation.Annotated : parameter.NullableAnnotation;
        var modifier = parameter switch {
            { IsParams: true } => "params ",
            { RefKind: RefKind.Ref } => "ref ",
            { RefKind: RefKind.Out } => "out ",
            { RefKind: RefKind.In } => "in ",
            { RefKind: RefKind.RefReadOnlyParameter } => "ref readonly ",
            _ => string.Empty,
        };

        _ = builder
            .Append(modifier)
            .Append(TypeName(type.WithNullableAnnotation(annotation)))
            .Append(' ')
            .Append(Identifier(parameter.Name));
        if (parameter.HasExplicitDefaultValue)
        {
            _ = builder.Append(" = ").Append(Constant(parameter.ExplicitDefaultValue, type));
        }

        return builder.ToString();
    }

    /// <summary>
    /// Gets the argument that forwards a parameter to a parameter of a constructor.
    /// </summary>
    /// <param name="parameter">The parameter of the constructor.</param>
    /// <returns>The name of <paramref name="parameter"/>, after the modifier that its kind of reference needs.</returns>
    public static string Argument(IParameterSymbol parameter)
    {
        var modifier = parameter.RefKind switch {
            RefKind.Ref => "ref ",
            RefKind.Out => "out ",
            RefKind.In or RefKind.RefReadOnlyParameter => "in ",
            _ => string.Empty,
        };

        return $"{modifier}{Identifier(parameter.Name)}";
    }

    private static IEnumerable<string> CopyAttributes(ImmutableArray<AttributeData> attributes, HashSet<string> names)
    {
        foreach (var attribute in attributes)
        {
            // The text of a symbol is its full name, which a type that is neither nested nor generic can take after "global::".
            var name = $"{attribute.AttributeClass}";
            if (names.Contains(name))
            {
                var arguments = attribute.ConstructorArguments
                    .Select(static argument => Constant(argument.Value, argument.Type))
                    .Concat(attribute.NamedArguments.Select(static pair => $"{pair.Key} = {Constant(pair.Value.Value, pair.Value.Type)}"));
                yield return $"global::{name}({string.Join(", ", arguments)})";
            }
        }
    }

    private static string Identifier(string name) => SyntaxFacts.GetKeywordKind(name) == SyntaxKind.None ? name : $"@{name}";

    private static string? Constant(object? value, ITypeSymbol? type)
    {
        if (value is null)
        {
            return "default";
        }

        var literal = value switch {
            float number => FloatingPoint(number, "float", $"{number.ToString("R", CultureInfo.InvariantCulture)}F"),
            double number => FloatingPoint(number, "double", $"{number.ToString("R", CultureInfo.InvariantCulture)}D"),
            decimal number => $"{number.ToString(CultureInfo.InvariantCulture)}M",
            _ => SymbolDisplay.FormatPrimitive(value, quoteStrings: true, useHexadecimalNumbers: false),
        };

        // The value of an enumeration constant is a number, and so is the value of a nullable one.
        var valueType = type is INamedTypeSymbol { OriginalDefinition.SpecialType: SpecialType.System_Nullable_T } nullableType
            ? nullableType.TypeArguments[0]
            : type;
        return valueType is { TypeKind: TypeKind.Enum } ? $"({TypeName(valueType)})({literal})" : literal;
    }

    // A real literal cannot state a value that is not a number, nor an infinity. The constants of the type can.
    private static string FloatingPoint(double value, string keyword, string literal)
        => double.IsNaN(value) ? $"{keyword}.NaN"
            : double.IsPositiveInfinity(value) ? $"{keyword}.PositiveInfinity"
            : double.IsNegativeInfinity(value) ? $"{keyword}.NegativeInfinity"
            : literal;
}
