// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;

namespace Louis.Generators;

/// <summary>
/// Reports a <c>ThrowNew</c> call that throws a base type of the exception type it names.
/// </summary>
/// <remarks>
/// <para>A derived exception class inherits the static <c>ThrowNew</c> methods of its base class,
/// and takes the <c>ThrowNew</c> extension methods of the nearest base type that has them.
/// When the derived class has no <c>ThrowNew</c> method of its own for the arguments of a call,
/// the call compiles, and throws the base type.</para>
/// </remarks>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class ThrowNewCallAnalyzer : DiagnosticAnalyzer
{
    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = [DiagnosticDescriptors.BaseTypeThrown];

    /// <inheritdoc/>
    public override void Initialize(AnalysisContext context)
    {
        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterOperationAction(
            static operationContext => Analyze(operationContext, ((IInvocationOperation)operationContext.Operation).TargetMethod),
            OperationKind.Invocation);
        context.RegisterOperationAction(
            static operationContext => Analyze(operationContext, ((IMethodReferenceOperation)operationContext.Operation).Method),
            OperationKind.MethodReference);
    }

    private static void Analyze(OperationAnalysisContext context, IMethodSymbol method)
    {
        // The syntax of a call is an invocation, and the syntax of a method group is the expression that names the method.
        // An expression that names no type, such as a call from the exception class itself, has nothing to compare.
        var syntax = context.Operation.Syntax;
        var target = syntax is InvocationExpressionSyntax invocation ? invocation.Expression : syntax;
        var isThrowNew = method is { Name: WellKnownNames.ThrowNew, IsStatic: true };
        if (!isThrowNew || target is not MemberAccessExpressionSyntax memberAccess || context.Operation.SemanticModel is not { } model)
        {
            return;
        }

        // A method of an extension block throws the type that the block extends.
        // Any other method throws the class that declares it.
        var declaringType = method.ContainingType;
        var thrownType = declaringType is { IsExtension: true, ExtensionParameter.Type: { } extendedType } ? extendedType : declaringType;
        var throwsBaseType = model.GetSymbolInfo(memberAccess.Expression, context.CancellationToken).Symbol is INamedTypeSymbol namedType
            && !SymbolEqualityComparer.Default.Equals(namedType, thrownType)
            && ThrowNewRules.IsExceptionType(thrownType, context.Compilation);
        if (!throwsBaseType)
        {
            return;
        }

        context.ReportDiagnostic(Diagnostic.Create(
            DiagnosticDescriptors.BaseTypeThrown,
            memberAccess.GetLocation(),
            memberAccess.Expression.ToString(),
            thrownType.ToDisplayString(SymbolDisplayFormat.CSharpShortErrorMessageFormat)));
    }
}
