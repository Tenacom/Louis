// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Generators;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

internal sealed class ThrowNewGeneratorCachingTests
{
    private const string Source = """
        using System;
        using Louis.Diagnostics;

        public partial class E : Exception
        {
            [ThrowNew]
            public E()
            {
            }
        }

        [ThrowNewFor(typeof(InvalidOperationException))]
        internal static partial class X;
        """;

    [Test]
    public async Task ChangeToOtherCode_LeavesSourceFilesUnchanged()
    {
        var compilation = TestCompiler.Compile(Source);
        var firstRun = TestCompiler.RunGenerator(compilation);
        var otherTree = CSharpSyntaxTree.ParseText("internal static class Unrelated;", GetParseOptions(compilation));

        var result = firstRun.Driver.RunGenerators(compilation.AddSyntaxTrees(otherTree)).GetRunResult().Results.Single();

        var memberReasons = GetReasons(result, ThrowNewGenerator.MemberFilesStepName);
        var extensionReasons = GetReasons(result, ThrowNewGenerator.ExtensionFilesStepName);
        await Assert.That(memberReasons).Count().IsEqualTo(1);
        await Assert.That(memberReasons).ContainsOnly(IsUnchanged);
        await Assert.That(extensionReasons).Count().IsEqualTo(1);
        await Assert.That(extensionReasons).ContainsOnly(IsUnchanged);
    }

    [Test]
    public async Task ChangeToOtherCode_LeavesSourceFileOfPrimaryConstructorUnchanged()
    {
        const string source = """
            using System;
            using Louis.Diagnostics;

            [method: ThrowNew]
            public partial class E(string message) : Exception(message);
            """;

        var compilation = TestCompiler.Compile(source);
        var firstRun = TestCompiler.RunGenerator(compilation);
        var otherTree = CSharpSyntaxTree.ParseText("internal static class Unrelated;", GetParseOptions(compilation));

        var result = firstRun.Driver.RunGenerators(compilation.AddSyntaxTrees(otherTree)).GetRunResult().Results.Single();

        var memberReasons = GetReasons(result, ThrowNewGenerator.MemberFilesStepName);
        await Assert.That(memberReasons).Count().IsEqualTo(1);
        await Assert.That(memberReasons).ContainsOnly(IsUnchanged);
    }

    [Test]
    public async Task ChangeToConstructor_ChangesSourceFileOfItsClass()
    {
        var compilation = TestCompiler.Compile(Source);
        var firstRun = TestCompiler.RunGenerator(compilation);
        var changedSource = Source.Replace("public E()", "public E(int code)", StringComparison.Ordinal);
        var changedTree = CSharpSyntaxTree.ParseText(changedSource, GetParseOptions(compilation));

        var changedCompilation = compilation.ReplaceSyntaxTree(compilation.SyntaxTrees[0], changedTree);
        var result = firstRun.Driver.RunGenerators(changedCompilation).GetRunResult().Results.Single();

        var memberReasons = GetReasons(result, ThrowNewGenerator.MemberFilesStepName);
        var extensionReasons = GetReasons(result, ThrowNewGenerator.ExtensionFilesStepName);
        await Assert.That(memberReasons).IsEquivalentTo([IncrementalStepRunReason.Modified]);
        await Assert.That(extensionReasons).Count().IsEqualTo(1);
        await Assert.That(extensionReasons).ContainsOnly(IsUnchanged);
    }

    private static CSharpParseOptions GetParseOptions(CSharpCompilation compilation)
        => (CSharpParseOptions)compilation.SyntaxTrees[0].Options;

    // The reason why the generator kept or replaced each output of a step.
    private static IncrementalStepRunReason[] GetReasons(GeneratorRunResult result, string stepName)
        => [.. result.TrackedSteps[stepName].SelectMany(static step => step.Outputs).Select(static output => output.Reason)];

    private static bool IsUnchanged(IncrementalStepRunReason reason)
        => reason is IncrementalStepRunReason.Cached or IncrementalStepRunReason.Unchanged;
}
