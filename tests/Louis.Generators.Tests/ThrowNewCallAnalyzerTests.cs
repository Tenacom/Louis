// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Globalization;
using Louis.Generators;
using Microsoft.CodeAnalysis;

internal sealed class ThrowNewCallAnalyzerTests
{
    private const string NoMethodReason = "has no 'ThrowNew' method with these parameters";

    [Test]
    public async Task CallOnDerivedClass_ThatInheritsMethodOfBaseClass_GetsLouis0001()
    {
        const string source = """
            using System;
            using Louis.Diagnostics;

            public partial class Base : Exception
            {
                [ThrowNew]
                public Base(string message)
                    : base(message)
                {
                }

                public static void CallFromInside() => ThrowNew("x");
            }

            public class Derived : Base
            {
                public Derived(string message)
                    : base(message)
                {
                }
            }

            public static class Caller
            {
                public static void Good() => Base.ThrowNew("x");

                public static Action<string> GoodMethodGroup() => Base.ThrowNew;

                public static void Bad() => Derived.ThrowNew("x");

                public static int BadInExpression() => Derived.ThrowNew<int>("x");

                public static Action<string> BadMethodGroup() => Derived.ThrowNew;
            }
            """;

        var diagnostics = await TestCompiler.AnalyzeAsync(TestCompiler.Compile(source), new ThrowNewCallAnalyzer());

        const string expectedMessage = $"'Derived.ThrowNew' throws 'Base', because 'Derived' {NoMethodReason}";
        var ids = diagnostics.Select(static diagnostic => diagnostic.Id);
        var severities = diagnostics.Select(static diagnostic => diagnostic.Severity);
        var messages = diagnostics.Select(static diagnostic => diagnostic.GetMessage(CultureInfo.InvariantCulture));
        await Assert.That(ids).IsEquivalentTo(["LOUIS0001", "LOUIS0001", "LOUIS0001"]);
        await Assert.That(severities).ContainsOnly(static severity => severity == DiagnosticSeverity.Warning);
        await Assert.That(messages).ContainsOnly(static message => message == expectedMessage);
        await Assert.That(diagnostics.Select(GetText)).IsEquivalentTo(["Derived.ThrowNew", "Derived.ThrowNew<int>", "Derived.ThrowNew"]);
    }

    [Test]
    public async Task CallOnDerivedType_ThatTakesExtensionMethodOfBaseType_GetsLouis0001()
    {
        const string source = """
            using System;
            using Louis.Diagnostics;

            [ThrowNewFor(typeof(ArgumentException))]
            internal static partial class ArgumentExceptionExtensions;

            public static class Caller
            {
                public static void Good() => ArgumentException.ThrowNew("x");

                public static void Bad() => ArgumentNullException.ThrowNew("x");

                public static int BadInExpression() => System.ArgumentNullException.ThrowNew<int>("x");
            }
            """;

        var diagnostics = await TestCompiler.AnalyzeAsync(TestCompiler.Compile(source), new ThrowNewCallAnalyzer());

        string[] expectedMessages = [
            $"'ArgumentNullException.ThrowNew' throws 'ArgumentException', because 'ArgumentNullException' {NoMethodReason}",
            $"'System.ArgumentNullException.ThrowNew' throws 'ArgumentException', because 'System.ArgumentNullException' {NoMethodReason}",
        ];

        var messages = diagnostics.Select(static diagnostic => diagnostic.GetMessage(CultureInfo.InvariantCulture));
        await Assert.That(messages).IsEquivalentTo(expectedMessages);
    }

    [Test]
    public async Task CallOfOtherMethod_GetsNoDiagnostic()
    {
        const string source = """
            using System;
            using System.Collections.Generic;

            public class NotAnException
            {
                public static void ThrowNew()
                {
                }
            }

            public class Other : NotAnException;

            public class E : Exception
            {
                public static void Throw() => throw new E();

                public void ThrowNew() => throw this;
            }

            public class Derived : E;

            public static class Caller
            {
                public static void StaticMethodOfClassThatIsNotAnException() => Other.ThrowNew();

                public static void InstanceMethod() => new Derived().ThrowNew();

                public static void MethodOfAnotherName() => Derived.Throw();

                public static List<int> CallWithoutInvocationSyntax() => new List<int> { 1 };
            }
            """;

        var diagnostics = await TestCompiler.AnalyzeAsync(TestCompiler.Compile(source), new ThrowNewCallAnalyzer());

        await Assert.That(diagnostics).IsEmpty();
    }

    [Test]
    public async Task Initialize_WithNullContext_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => new ThrowNewCallAnalyzer().Initialize(null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("context");
    }

    private static string GetText(Diagnostic diagnostic)
    {
        var tree = diagnostic.Location.SourceTree ?? throw new InvalidOperationException("The diagnostic has no source location.");
        return tree.GetText().ToString(diagnostic.Location.SourceSpan);
    }
}
