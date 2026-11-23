// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Globalization;
using Louis.Generators;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

// The tests of the diagnostics for ThrowNewAttribute. ThrowNewForAttributeAnalyzerTests holds the others.
internal sealed class ThrowNewAttributeAnalyzerTests
{
    private const string Usings = "using System; using Louis.Diagnostics; ";
    private const string NotPartialMessage = "gets no 'ThrowNew' method, because it is not partial, or a type that contains it is not";
    private const string NoMethodMessage = "gets no 'ThrowNew' method, because";

    [Test]
    public async Task ValidConstructor_GetsNoDiagnostic()
    {
        const string source = """
            using System;
            using Louis.Diagnostics;

            public partial class E : Exception
            {
                [ThrowNew]
                public E()
                {
                }

                public E(int notMarked)
                {
                }
            }
            """;

        var compilation = TestCompiler.Compile(source);

        await Assert.That(await TestCompiler.AnalyzeAsync(compilation, new ThrowNewAttributeAnalyzer())).IsEmpty();
        await Assert.That(TestCompiler.RunGenerator(compilation).Files).Count().IsEqualTo(1);
    }

    [Test]
    [Arguments("public class E : Exception { [ThrowNew] public E() { } }", "E")]
    [Arguments("public class Outer { public partial class E : Exception { [ThrowNew] public E() { } } }", "Outer.E")]
    [Arguments("public partial class Outer { public class E : Exception { [ThrowNew] public E() { } } }", "Outer.E")]
    public async Task ClassThatIsNotPartial_GetsLouis0002_AndNoMethod(string declaration, string className)
    {
        var compilation = TestCompiler.Compile($"{Usings}{declaration}");

        var diagnostic = await GetSingleDiagnosticAsync(compilation);

        await Assert.That(diagnostic.Id).IsEqualTo("LOUIS0002");
        await Assert.That(diagnostic.Severity).IsEqualTo(DiagnosticSeverity.Error);
        await Assert.That(diagnostic.GetMessage(CultureInfo.InvariantCulture)).IsEqualTo($"'{className}' {NotPartialMessage}");
        await Assert.That(TestCompiler.RunGenerator(compilation).Files).IsEmpty();
    }

    [Test]
    [Arguments("public partial class E : Exception { [ThrowNew] static E() { } }", "E", "it is static")]
    [Arguments(
        "public partial class C { [ThrowNew] public C() { } }",
        "C",
        "the type is not a class that derives from 'System.Exception'")]
    [Arguments(
        "public partial struct S { [ThrowNew] public S(int a) { } }",
        "S",
        "the type is not a class that derives from 'System.Exception'")]
    [Arguments("public abstract partial class E : Exception { [ThrowNew] protected E() { } }", "E", "the class is abstract")]
    [Arguments(
        "public unsafe partial class E : Exception { [ThrowNew] public E(int* pointer) { } }",
        "E",
        "it has a parameter of a pointer type")]
    [Arguments(
        "public unsafe partial class E : Exception { [ThrowNew] public E(int*[] pointers) { } }",
        "E",
        "it has a parameter of a pointer type")]
    [Arguments(
        "public unsafe partial class E : Exception { [ThrowNew] public E(delegate*<void> function) { } }",
        "E",
        "it has a parameter of a pointer type")]
    public async Task ConstructorThatCannotGetMethods_GetsLouis0003_AndNoMethod(string declaration, string typeName, string reason)
    {
        var compilation = TestCompiler.Compile($"{Usings}{declaration}");

        var diagnostic = await GetSingleDiagnosticAsync(compilation);

        await Assert.That(diagnostic.Id).IsEqualTo("LOUIS0003");
        await Assert.That(diagnostic.Severity).IsEqualTo(DiagnosticSeverity.Error);
        var expectedMessage = $"This constructor of '{typeName}' {NoMethodMessage} {reason}";
        await Assert.That(diagnostic.GetMessage(CultureInfo.InvariantCulture)).IsEqualTo(expectedMessage);
        await Assert.That(TestCompiler.RunGenerator(compilation).Files).IsEmpty();
    }

    [Test]
    public async Task LanguageVersionBeforeCSharp8_GetsLouis0007_AndNoMethod()
    {
        const string source = $$"""{{Usings}}public partial class E : Exception { [ThrowNew] public E() { } }""";
        var compilation = TestCompiler.Compile(source, LanguageVersion.CSharp7_3);

        var diagnostic = await GetSingleDiagnosticAsync(compilation);

        const string expectedMessage = "'ThrowNewAttribute' needs C# 8.0 or later, and the language version of the project is 7.3";
        await Assert.That(diagnostic.Id).IsEqualTo("LOUIS0007");
        await Assert.That(diagnostic.Severity).IsEqualTo(DiagnosticSeverity.Error);
        await Assert.That(diagnostic.GetMessage(CultureInfo.InvariantCulture)).IsEqualTo(expectedMessage);
        await Assert.That(TestCompiler.RunGenerator(compilation).Files).IsEmpty();
    }

    [Test]
    public async Task Diagnostic_IsAtTheConstructor()
    {
        const string source = """
            using System;
            using Louis.Diagnostics;

            public class E : Exception
            {
                [ThrowNew]
                public E()
                {
                }
            }
            """;

        var diagnostic = await GetSingleDiagnosticAsync(TestCompiler.Compile(source));

        var position = diagnostic.Location.GetLineSpan().StartLinePosition;
        await Assert.That(position.Line).IsEqualTo(6);
        await Assert.That(position.Character).IsEqualTo(11);
    }

    // The compiler rejects the attribute on a method, and the analyzer adds nothing to its error.
    [Test]
    public async Task AttributeOnMethod_GetsNoDiagnostic()
    {
        const string source = $$"""{{Usings}}public partial class E : Exception { [ThrowNew] public void M() { } }""";
        var compilation = TestCompiler.Compile(source);

        await Assert.That(await TestCompiler.AnalyzeAsync(compilation, new ThrowNewAttributeAnalyzer())).IsEmpty();
        await Assert.That(TestCompiler.RunGenerator(compilation).Files).IsEmpty();
    }

    [Test]
    public async Task ProjectWithoutLouis_GetsNoDiagnostic()
    {
        const string source = """
            using System;

            [AttributeUsage(AttributeTargets.All)]
            public sealed class ThrowNewAttribute : Attribute;

            [ThrowNew]
            public class E : Exception
            {
                [ThrowNew]
                public E()
                {
                }
            }
            """;

        var compilation = TestCompiler.CompileForNetStandard20(source);

        await Assert.That(await TestCompiler.AnalyzeAsync(compilation, new ThrowNewAttributeAnalyzer())).IsEmpty();
        await Assert.That(TestCompiler.RunGenerator(compilation).Files).IsEmpty();
    }

    [Test]
    public async Task Initialize_WithNullContext_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new ThrowNewAttributeAnalyzer().Initialize(null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("context");
    }

    private static async Task<Diagnostic> GetSingleDiagnosticAsync(CSharpCompilation compilation)
    {
        var diagnostics = await TestCompiler.AnalyzeAsync(compilation, new ThrowNewAttributeAnalyzer());
        await Assert.That(diagnostics).Count().IsEqualTo(1);
        return diagnostics[0];
    }
}
