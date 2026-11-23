// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Globalization;
using Louis.Generators;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

// The tests of the diagnostics for ThrowNewForAttribute. ThrowNewAttributeAnalyzerTests holds the others.
internal sealed class ThrowNewForAttributeAnalyzerTests
{
    private const string Usings = "using System; using Louis.Diagnostics; ";
    private const string InvalidClassMessage =
        "gets no 'ThrowNew' method, because it is not a static partial class that is neither nested nor generic";

    private const string NotExceptionReason = "the type is not a class that derives from 'System.Exception'";
    private const string NotPublicReason = "the type is not public, and the methods are";
    private const string NoConstructorReason = "the type has no public constructor that can get a method";

    [Test]
    [Arguments("[ThrowNewFor(typeof(Exception))] internal static partial class X;")]
    [Arguments("[ThrowNewFor(typeof(Exception), Public = true)] public static partial class X;")]
    [Arguments("[ThrowNewFor(typeof(Exception), Public = true)] internal static partial class X;")]
    public async Task ValidClass_GetsNoDiagnostic(string declaration)
    {
        var compilation = TestCompiler.Compile($"{Usings}{declaration}");

        await Assert.That(await TestCompiler.AnalyzeAsync(compilation, new ThrowNewAttributeAnalyzer())).IsEmpty();
        await Assert.That(TestCompiler.RunGenerator(compilation).Files).Count().IsEqualTo(1);
    }

    [Test]
    [Arguments("[ThrowNewFor(typeof(Exception))] internal partial class X;", "X")]
    [Arguments("[ThrowNewFor(typeof(Exception))] internal static class X;", "X")]
    [Arguments("internal static partial class Outer { [ThrowNewFor(typeof(Exception))] internal static partial class X; }", "Outer.X")]
    [Arguments("[ThrowNewFor(typeof(Exception))] internal static partial class X<T>;", "X<T>")]
    public async Task ClassThatCannotGetMethods_GetsLouis0004_AndNoMethod(string declaration, string className)
    {
        var compilation = TestCompiler.Compile($"{Usings}{declaration}");

        var diagnostic = await GetSingleDiagnosticAsync(compilation);

        await Assert.That(diagnostic.Id).IsEqualTo("LOUIS0004");
        await Assert.That(diagnostic.Severity).IsEqualTo(DiagnosticSeverity.Error);
        await Assert.That(diagnostic.GetMessage(CultureInfo.InvariantCulture)).IsEqualTo($"'{className}' {InvalidClassMessage}");
        await Assert.That(TestCompiler.RunGenerator(compilation).Files).IsEmpty();
    }

    [Test]
    [Arguments("", "string", false, NotExceptionReason)]
    [Arguments("", "int[]", false, NotExceptionReason)]
    [Arguments("", "IDisposable", false, NotExceptionReason)]
    [Arguments("public class E<T> : Exception;", "E<>", false, "the type is an unbound generic type")]
    [Arguments("public abstract class E : Exception;", "E", false, "the type is abstract")]
    [Arguments("internal class E : Exception;", "E", true, NotPublicReason)]
    [Arguments("internal class Outer { public class E : Exception; }", "Outer.E", true, NotPublicReason)]
    [Arguments("internal class H; public class E<T> : Exception;", "E<H>", true, NotPublicReason)]
    [Arguments("internal class H; public class E<T> : Exception;", "E<H[]>", true, NotPublicReason)]
    [Arguments("public class E : Exception { internal E() { } }", "E", false, NoConstructorReason)]
    [Arguments("public unsafe class E : Exception { public E(int* pointer) { } }", "E", false, NoConstructorReason)]
    public async Task TypeThatCannotGetMethods_GetsLouis0005_AndNoMethod(
        string declarations,
        string typeName,
        bool isPublic,
        string reason)
    {
        var arguments = isPublic ? $"typeof({typeName}), Public = true" : $"typeof({typeName})";
        var compilation = TestCompiler.Compile($"{Usings}{declarations} [ThrowNewFor({arguments})] internal static partial class X;");

        var diagnostic = await GetSingleDiagnosticAsync(compilation);

        var expectedMessage = $"'X' gets no 'ThrowNew' method for '{typeName}', because {reason}";
        await Assert.That(diagnostic.Id).IsEqualTo("LOUIS0005");
        await Assert.That(diagnostic.Severity).IsEqualTo(DiagnosticSeverity.Error);
        await Assert.That(diagnostic.GetMessage(CultureInfo.InvariantCulture)).IsEqualTo(expectedMessage);
        await Assert.That(TestCompiler.RunGenerator(compilation).Files).IsEmpty();
    }

    [Test]
    [Arguments("[ThrowNewFor(typeof(Exception))] public static partial class X;")]
    [Arguments("[ThrowNewFor(typeof(Exception), Public = false)] public static partial class X;")]
    public async Task PublicClassWithInternalMethods_GetsLouis0006_AndItsMethods(string declaration)
    {
        var compilation = TestCompiler.Compile($"{Usings}{declaration}");

        var diagnostic = await GetSingleDiagnosticAsync(compilation);

        const string expectedMessage = "'X' is public, and its 'ThrowNew' methods are internal";
        await Assert.That(diagnostic.Id).IsEqualTo("LOUIS0006");
        await Assert.That(diagnostic.Severity).IsEqualTo(DiagnosticSeverity.Warning);
        await Assert.That(diagnostic.GetMessage(CultureInfo.InvariantCulture)).IsEqualTo(expectedMessage);
        await Assert.That(TestCompiler.RunGenerator(compilation).Files).Count().IsEqualTo(1);
    }

    [Test]
    public async Task LanguageVersionBeforeCSharp14_GetsLouis0007_AndNoMethod()
    {
        const string source = $"{Usings}[ThrowNewFor(typeof(Exception))] internal static partial class X;";
        var compilation = TestCompiler.Compile(source, LanguageVersion.CSharp13);

        var diagnostic = await GetSingleDiagnosticAsync(compilation);

        const string expectedMessage = "'ThrowNewForAttribute' needs C# 14.0 or later, and the language version of the project is 13.0";
        await Assert.That(diagnostic.Id).IsEqualTo("LOUIS0007");
        await Assert.That(diagnostic.Severity).IsEqualTo(DiagnosticSeverity.Error);
        await Assert.That(diagnostic.GetMessage(CultureInfo.InvariantCulture)).IsEqualTo(expectedMessage);
        await Assert.That(TestCompiler.RunGenerator(compilation).Files).IsEmpty();
    }

    [Test]
    public async Task Diagnostic_IsAtTheClass()
    {
        const string source = """
            using System;
            using Louis.Diagnostics;

            [ThrowNewFor(typeof(Exception))]
            internal static class X;
            """;

        var diagnostic = await GetSingleDiagnosticAsync(TestCompiler.Compile(source));

        var position = diagnostic.Location.GetLineSpan().StartLinePosition;
        await Assert.That(position.Line).IsEqualTo(4);
        await Assert.That(position.Character).IsEqualTo(22);
    }

    // The compiler reports a type it cannot resolve, a null argument, and the attribute on a struct.
    // The analyzer adds nothing to its errors.
    [Test]
    [Arguments("[ThrowNewFor(typeof(Missing))] internal static partial class X;")]
    [Arguments("[ThrowNewFor(null)] internal static partial class X;")]
    [Arguments("[ThrowNewFor] internal static partial class X;")]
    [Arguments("[ThrowNewFor(typeof(Exception))] internal partial struct S;")]
    public async Task CodeThatTheCompilerRejects_GetsNoDiagnostic_AndNoMethod(string declaration)
    {
        var compilation = TestCompiler.Compile($"{Usings}{declaration}");

        await Assert.That(await TestCompiler.AnalyzeAsync(compilation, new ThrowNewAttributeAnalyzer())).IsEmpty();
        await Assert.That(TestCompiler.RunGenerator(compilation).Files).IsEmpty();
    }

    private static async Task<Diagnostic> GetSingleDiagnosticAsync(CSharpCompilation compilation)
    {
        var diagnostics = await TestCompiler.AnalyzeAsync(compilation, new ThrowNewAttributeAnalyzer());
        await Assert.That(diagnostics).Count().IsEqualTo(1);
        return diagnostics[0];
    }
}
