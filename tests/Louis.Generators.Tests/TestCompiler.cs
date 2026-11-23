// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using Basic.Reference.Assemblies;
using Louis.Diagnostics;
using Louis.Generators;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;

/// <summary>
/// Compiles the source of a test, and runs the generator and the analyzers on it.
/// </summary>
internal static class TestCompiler
{
    /// <summary>
    /// The two attributes of Louis, for a compilation that cannot reference the Louis assembly of this test project.
    /// </summary>
    public const string AttributeSource = """
        namespace Louis.Diagnostics
        {
            [System.AttributeUsage(System.AttributeTargets.Constructor, Inherited = false)]
            public sealed class ThrowNewAttribute : System.Attribute;

            [System.AttributeUsage(System.AttributeTargets.Class, Inherited = false)]
            public sealed class ThrowNewForAttribute(System.Type exceptionType) : System.Attribute
            {
                public System.Type ExceptionType { get; } = exceptionType;

                public bool Public { get; set; }
            }
        }
        """;

    private const string MissingXmlCommentId = "CS1591";

    private static readonly ImmutableArray<MetadataReference> CurrentReferences = GetCurrentReferences();

    /// <summary>
    /// Gets the version that the generator states in the <c>GeneratedCodeAttribute</c> of each method:
    /// the informational version of its assembly.
    /// </summary>
    public static string GeneratorVersion { get; } = GetGeneratorVersion();

    /// <summary>
    /// Compiles source text against the runtime that runs the tests, with a reference to Louis.
    /// </summary>
    /// <param name="source">The source text.</param>
    /// <param name="languageVersion">The language version of the compilation.</param>
    /// <returns>The compilation.</returns>
    public static CSharpCompilation Compile(string source, LanguageVersion languageVersion = LanguageVersion.CSharp14)
        => Compile([source], CurrentReferences, languageVersion);

    /// <summary>
    /// Compiles source text against .NET Standard 2.0, with no reference to Louis.
    /// </summary>
    /// <param name="sources">The source texts. <see cref="AttributeSource"/> stands in for Louis.</param>
    /// <returns>The compilation.</returns>
    public static CSharpCompilation CompileForNetStandard20(params string[] sources)
        => Compile(sources, [.. NetStandard20.References.All], LanguageVersion.CSharp14);

    /// <summary>
    /// Runs <see cref="ThrowNewGenerator"/> on a compilation.
    /// </summary>
    /// <param name="compilation">The compilation.</param>
    /// <returns>The result of the run.</returns>
    public static GeneratorRun RunGenerator(CSharpCompilation compilation)
    {
        GeneratorDriver driver = CSharpGeneratorDriver.Create(
            [new ThrowNewGenerator().AsSourceGenerator()],
            parseOptions: (CSharpParseOptions)compilation.SyntaxTrees[0].Options,
            driverOptions: new GeneratorDriverOptions(IncrementalGeneratorOutputKind.None, trackIncrementalGeneratorSteps: true));
        driver = driver.RunGeneratorsAndUpdateCompilation(compilation, out var output, out _);

        // The source of a test has no XML comments, so a missing comment counts only in the code that the generator added.
        IEnumerable<SyntaxTree> sourceTrees = compilation.SyntaxTrees;
        var problems = output.GetDiagnostics()
            .Where(static diagnostic => diagnostic.Severity >= DiagnosticSeverity.Warning)
            .Where(diagnostic => diagnostic.Id != MissingXmlCommentId || !sourceTrees.Contains(diagnostic.Location.SourceTree))
            .Select(static diagnostic => diagnostic.ToString());
        return new(driver, output, [.. problems]);
    }

    /// <summary>
    /// Runs the generator on a compilation, then an analyzer on the result.
    /// </summary>
    /// <param name="compilation">The compilation.</param>
    /// <param name="analyzer">The analyzer.</param>
    /// <returns>The diagnostics of the analyzer, in the order of their positions.</returns>
    public static async Task<IReadOnlyList<Diagnostic>> AnalyzeAsync(CSharpCompilation compilation, DiagnosticAnalyzer analyzer)
    {
        var output = RunGenerator(compilation).Output;
        var diagnostics = await output.WithAnalyzers([analyzer]).GetAnalyzerDiagnosticsAsync();
        return [.. diagnostics.OrderBy(static diagnostic => diagnostic.Location.SourceSpan.Start)];
    }

    private static string GetGeneratorVersion()
    {
        var attribute = typeof(ThrowNewGenerator).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        Debug.Assert(attribute is not null, "The build gives every assembly an informational version.");
        return attribute.InformationalVersion;
    }

    // The assemblies of the runtime that runs the tests, and the Louis assembly, which holds the two attributes.
    private static ImmutableArray<MetadataReference> GetCurrentReferences()
    {
        var trustedAssemblies = AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES") as string;
        Debug.Assert(trustedAssemblies is not null, "The runtime sets the list of its assemblies for every application.");
        var runtimeDirectory = RuntimeEnvironment.GetRuntimeDirectory();
        return [
            .. trustedAssemblies.Split(Path.PathSeparator)
                .Where(path => path.StartsWith(runtimeDirectory, StringComparison.Ordinal))
                .Append(typeof(ThrowNewAttribute).Assembly.Location)
                .Select(static path => MetadataReference.CreateFromFile(path)),
        ];
    }

    private static CSharpCompilation Compile(
        IEnumerable<string> sources,
        ImmutableArray<MetadataReference> references,
        LanguageVersion languageVersion)
    {
        // The compiler checks XML comments only in this documentation mode, which a project with a documentation file has.
        var parseOptions = new CSharpParseOptions(languageVersion, DocumentationMode.Diagnose);
        var options = new CSharpCompilationOptions(
            OutputKind.DynamicallyLinkedLibrary,
            nullableContextOptions: NullableContextOptions.Enable,
            allowUnsafe: true);
        return CSharpCompilation.Create(
            "TestAssembly",
            sources.Select(source => CSharpSyntaxTree.ParseText(source, parseOptions)),
            references,
            options);
    }
}
