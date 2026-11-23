// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Louis.Generators;

/// <summary>
/// Reports a <c>ThrowNewAttribute</c> or a <c>ThrowNewForAttribute</c> that gets no <c>ThrowNew</c> method,
/// and a public class whose <c>ThrowNew</c> methods are internal.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class ThrowNewAttributeAnalyzer : DiagnosticAnalyzer
{
    // The end of the message of DiagnosticDescriptors.InvalidConstructor, for each problem that it reports.
    private static readonly Dictionary<ThrowNewProblem, string> ConstructorReasons = new() {
        [ThrowNewProblem.StaticConstructor] = "it is static",
        [ThrowNewProblem.NotExceptionClass] = "the type is not a class that derives from 'System.Exception'",
        [ThrowNewProblem.AbstractClass] = "the class is abstract",
        [ThrowNewProblem.PointerParameter] = "it has a parameter of a pointer type",
    };

    // The end of the message of DiagnosticDescriptors.InvalidExceptionType, for each problem that it reports.
    private static readonly Dictionary<ThrowNewProblem, string> ExceptionTypeReasons = new() {
        [ThrowNewProblem.NotExceptionType] = "the type is not a class that derives from 'System.Exception'",
        [ThrowNewProblem.UnboundExceptionType] = "the type is an unbound generic type",
        [ThrowNewProblem.AbstractExceptionType] = "the type is abstract",
        [ThrowNewProblem.NonPublicExceptionType] = "the type is not public, and the methods are",
        [ThrowNewProblem.NoPublicConstructor] = "the type has no public constructor that can get a method",
    };

    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = [
        DiagnosticDescriptors.ClassNotPartial,
        DiagnosticDescriptors.InvalidConstructor,
        DiagnosticDescriptors.InvalidExtensionClass,
        DiagnosticDescriptors.InvalidExceptionType,
        DiagnosticDescriptors.PublicClassInternalMethods,
        DiagnosticDescriptors.LanguageVersion,
    ];

    /// <inheritdoc/>
    public override void Initialize(AnalysisContext context)
    {
        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterCompilationStartAction(RegisterSymbolActions);
    }

    private static void RegisterSymbolActions(CompilationStartAnalysisContext context)
    {
        var throwNewAttribute = context.Compilation.GetTypeByMetadataName(WellKnownNames.ThrowNewAttribute);
        var throwNewForAttribute = context.Compilation.GetTypeByMetadataName(WellKnownNames.ThrowNewForAttribute);
        context.RegisterSymbolAction(symbolContext => AnalyzeMethod(symbolContext, throwNewAttribute), SymbolKind.Method);
        context.RegisterSymbolAction(symbolContext => AnalyzeType(symbolContext, throwNewForAttribute), SymbolKind.NamedType);
    }

    private static void AnalyzeMethod(SymbolAnalysisContext context, INamedTypeSymbol? attributeType)
    {
        // The compiler rejects the attribute on a method that is not a constructor.
        var method = (IMethodSymbol)context.Symbol;
        var attribute = FindAttribute(method, attributeType);
        if (attribute is null || method.MethodKind is not (MethodKind.Constructor or MethodKind.StaticConstructor))
        {
            return;
        }

        var compilation = (CSharpCompilation)context.Compilation;
        var typeName = GetName(method.ContainingType);
        var location = method.Locations[0];
        var problem = ThrowNewRules.CheckConstructor(method, compilation);
        if (problem == ThrowNewProblem.LanguageVersion)
        {
            ReportLanguageVersion(
                context,
                location,
                WellKnownNames.ThrowNewAttributeName,
                ThrowNewRules.MemberLanguageVersion,
                compilation);
        }
        else if (problem == ThrowNewProblem.NotPartial)
        {
            context.ReportDiagnostic(Diagnostic.Create(DiagnosticDescriptors.ClassNotPartial, location, typeName));
        }
        else if (ConstructorReasons.TryGetValue(problem, out var reason))
        {
            context.ReportDiagnostic(Diagnostic.Create(DiagnosticDescriptors.InvalidConstructor, location, typeName, reason));
        }
    }

    private static void AnalyzeType(SymbolAnalysisContext context, INamedTypeSymbol? attributeType)
    {
        // The compiler rejects the attribute on a type that is not a class.
        var type = (INamedTypeSymbol)context.Symbol;
        var attribute = FindAttribute(type, attributeType);
        if (attribute is null || type.TypeKind != TypeKind.Class)
        {
            return;
        }

        var compilation = (CSharpCompilation)context.Compilation;
        var typeName = GetName(type);
        var location = type.Locations[0];
        var problem = ThrowNewRules.CheckExtensionClass(type, attribute, compilation, out var exceptionType, out var isPublic);
        var isPublicClass = type.DeclaredAccessibility == Accessibility.Public;
        if (problem == ThrowNewProblem.LanguageVersion)
        {
            ReportLanguageVersion(
                context,
                location,
                WellKnownNames.ThrowNewForAttributeName,
                ThrowNewRules.ExtensionLanguageVersion,
                compilation);
        }
        else if (problem == ThrowNewProblem.InvalidExtensionClass)
        {
            context.ReportDiagnostic(Diagnostic.Create(DiagnosticDescriptors.InvalidExtensionClass, location, typeName));
        }
        else if (exceptionType is not null && ExceptionTypeReasons.TryGetValue(problem, out var reason))
        {
            context.ReportDiagnostic(Diagnostic.Create(
                DiagnosticDescriptors.InvalidExceptionType,
                location,
                typeName,
                GetName(exceptionType),
                reason));
        }
        else if (problem == ThrowNewProblem.None && !isPublic && isPublicClass)
        {
            context.ReportDiagnostic(Diagnostic.Create(DiagnosticDescriptors.PublicClassInternalMethods, location, typeName));
        }
    }

    // The attribute type is null in a project that does not reference Louis.
    private static AttributeData? FindAttribute(ISymbol symbol, INamedTypeSymbol? attributeType)
        => attributeType is null
            ? null
            : symbol.GetAttributes()
                .FirstOrDefault(attribute => SymbolEqualityComparer.Default.Equals(attribute.AttributeClass, attributeType));

    private static string GetName(ITypeSymbol type) => type.ToDisplayString(SymbolDisplayFormat.CSharpShortErrorMessageFormat);

    private static void ReportLanguageVersion(
        SymbolAnalysisContext context,
        Location location,
        string attributeName,
        LanguageVersion neededVersion,
        CSharpCompilation compilation)
        => context.ReportDiagnostic(Diagnostic.Create(
            DiagnosticDescriptors.LanguageVersion,
            location,
            attributeName,
            neededVersion.ToDisplayString(),
            compilation.LanguageVersion.ToDisplayString()));
}
