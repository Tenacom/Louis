// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Louis.Generators;

/// <summary>
/// Adds <c>ThrowNew</c> methods to the exception classes whose constructors have <c>ThrowNewAttribute</c>,
/// and <c>ThrowNew</c> extension methods to the static classes that have <c>ThrowNewForAttribute</c>.
/// </summary>
/// <remarks>
/// <para>The generator reports no diagnostic. When an attribute gets no method,
/// <see cref="ThrowNewAttributeAnalyzer"/> reports the reason.</para>
/// </remarks>
[Generator(LanguageNames.CSharp)]
public sealed class ThrowNewGenerator : IIncrementalGenerator
{
    /// <summary>
    /// The name of the step that yields the source files of the classes whose constructors have <c>ThrowNewAttribute</c>.
    /// </summary>
    public const string MemberFilesStepName = "ThrowNewMemberFiles";

    /// <summary>
    /// The name of the step that yields the source files of the classes that have <c>ThrowNewForAttribute</c>.
    /// </summary>
    public const string ExtensionFilesStepName = "ThrowNewExtensionFiles";

    /// <inheritdoc/>
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // A class gets one source file, with the methods of every constructor that has the attribute.
        var memberFiles = context.SyntaxProvider
            .ForAttributeWithMetadataName(
                WellKnownNames.ThrowNewAttribute,
                static (node, _) => node is ConstructorDeclarationSyntax,
                static (attributeContext, _) => ThrowNewSource.ForConstructor(attributeContext))
            .Collect()
            .SelectMany(static (sources, _) => ThrowNewSource.Combine(sources.OfType<ConstructorSource>()))
            .WithTrackingName(MemberFilesStepName);

        var extensionFiles = context.SyntaxProvider
            .ForAttributeWithMetadataName(
                WellKnownNames.ThrowNewForAttribute,
                static (node, _) => node is ClassDeclarationSyntax,
                static (attributeContext, _) => ThrowNewSource.ForExtensionClass(attributeContext))
            .Collect()
            .SelectMany(static (files, _) => files.OfType<GeneratedFile>())
            .WithTrackingName(ExtensionFilesStepName);

        context.RegisterSourceOutput(memberFiles, static (output, file) => output.AddSource(file.HintName, file.Text));
        context.RegisterSourceOutput(extensionFiles, static (output, file) => output.AddSource(file.HintName, file.Text));
    }
}
