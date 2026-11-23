// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Microsoft.CodeAnalysis;

namespace Louis.Generators;

// The diagnostics are in English alone, as every message of L.o.U.I.S. is.
#pragma warning disable RS1007 // Provide localizable arguments to diagnostic descriptor constructor

// No custom tag applies to these diagnostics.
#pragma warning disable RS1028 // Provide non-null 'customTags' value to diagnostic descriptor constructor

/// <summary>
/// Holds the descriptors of the diagnostics that the analyzers report.
/// The page <c>docs/diagnostics.md</c> describes each of them, and a test compares the page with the descriptors.
/// </summary>
internal static class DiagnosticDescriptors
{
    /// <summary>
    /// The descriptor of the diagnostic for a <c>ThrowNew</c> call that throws a base type of the type it names.
    /// </summary>
    public static readonly DiagnosticDescriptor BaseTypeThrown = new(
        "LOUIS0001",
        "A ThrowNew call throws a base type of the type it names",
        "'{0}.ThrowNew' throws '{1}', because '{0}' has no 'ThrowNew' method with these parameters",
        Category,
        DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        helpLinkUri: $"{HelpLinkBase}louis0001");

    /// <summary>
    /// The descriptor of the diagnostic for a <c>ThrowNewAttribute</c> in a class that is not partial.
    /// </summary>
    public static readonly DiagnosticDescriptor ClassNotPartial = new(
        "LOUIS0002",
        "ThrowNewAttribute is in a class that is not partial",
        "'{0}' gets no 'ThrowNew' method, because it is not partial, or a type that contains it is not",
        Category,
        DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        helpLinkUri: $"{HelpLinkBase}louis0002");

    /// <summary>
    /// The descriptor of the diagnostic for a <c>ThrowNewAttribute</c> on a constructor that cannot get a method.
    /// </summary>
    public static readonly DiagnosticDescriptor InvalidConstructor = new(
        "LOUIS0003",
        "ThrowNewAttribute is on a constructor that cannot get ThrowNew methods",
        "This constructor of '{0}' gets no 'ThrowNew' method, because {1}",
        Category,
        DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        helpLinkUri: $"{HelpLinkBase}louis0003");

    /// <summary>
    /// The descriptor of the diagnostic for a <c>ThrowNewForAttribute</c> on a class of the wrong kind.
    /// </summary>
    public static readonly DiagnosticDescriptor InvalidExtensionClass = new(
        "LOUIS0004",
        "ThrowNewForAttribute is on a class that cannot get ThrowNew methods",
        "'{0}' gets no 'ThrowNew' method, because it is not a static partial class that is neither nested nor generic",
        Category,
        DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        helpLinkUri: $"{HelpLinkBase}louis0004");

    /// <summary>
    /// The descriptor of the diagnostic for a <c>ThrowNewForAttribute</c> that names a type of the wrong kind.
    /// </summary>
    public static readonly DiagnosticDescriptor InvalidExceptionType = new(
        "LOUIS0005",
        "ThrowNewForAttribute names a type that cannot get ThrowNew methods",
        "'{0}' gets no 'ThrowNew' method for '{1}', because {2}",
        Category,
        DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        helpLinkUri: $"{HelpLinkBase}louis0005");

    /// <summary>
    /// The descriptor of the diagnostic for a public class whose <c>ThrowNew</c> methods are internal.
    /// </summary>
    public static readonly DiagnosticDescriptor PublicClassInternalMethods = new(
        "LOUIS0006",
        "A public class with ThrowNewForAttribute has internal ThrowNew methods",
        "'{0}' is public, and its 'ThrowNew' methods are internal",
        Category,
        DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        helpLinkUri: $"{HelpLinkBase}louis0006");

    /// <summary>
    /// The descriptor of the diagnostic for an attribute in a project whose language version is too old.
    /// </summary>
    public static readonly DiagnosticDescriptor LanguageVersion = new(
        "LOUIS0007",
        "ThrowNew methods need a later version of C#",
        "'{0}' needs C# {1} or later, and the language version of the project is {2}",
        Category,
        DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        helpLinkUri: $"{HelpLinkBase}louis0007");

    private const string Category = "Usage";

    // The preview part of the documentation site describes the release with the highest version, stable or not.
    // It therefore has the page as soon as one release has it, where the stable part waits for a stable release.
    private const string HelpLinkBase = "https://tenacom.github.io/Louis/preview/diagnostics.html#";
}
