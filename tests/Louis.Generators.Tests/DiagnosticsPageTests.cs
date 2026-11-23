// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Text.RegularExpressions;
using Louis.Generators;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using TUnit.Assertions.Enums;

// The reference page docs/diagnostics.md lists the diagnostics of the analyzers.
// These tests fail when the page and the analyzers disagree.
internal sealed partial class DiagnosticsPageTests
{
    private static readonly IReadOnlyList<DiagnosticDescriptor> Descriptors = [
        .. new DiagnosticAnalyzer[] { new ThrowNewCallAnalyzer(), new ThrowNewAttributeAnalyzer() }
            .SelectMany(static analyzer => analyzer.SupportedDiagnostics)
            .OrderBy(static descriptor => descriptor.Id, StringComparer.Ordinal),
    ];

    private static readonly string[] PageLines = File.ReadAllLines(Path.Combine(AppContext.BaseDirectory, "docs", "diagnostics.md"));

    // A row of the table: a link to the section of the diagnostic, its severity, and its title.
    [GeneratedRegex(@"^\| \[`(?<id>LOUIS\d{4})`\]\(#louis\d{4}\) +\| (?<severity>\w+) +\| (?<title>.+?) +\|$")]
    private static partial Regex TableRowRegex { get; }

    [Test]
    public async Task Table_HasOneRowForEachDiagnostic_WithItsSeverityAndTitle()
    {
        var expectedRows = Descriptors.Select(static descriptor => $"{descriptor.Id}|{descriptor.DefaultSeverity}|{descriptor.Title}");

        var rows = PageLines
            .Select(static line => TableRowRegex.Match(line))
            .Where(static match => match.Success)
            .Select(static match => $"{match.Groups["id"].Value}|{match.Groups["severity"].Value}|{match.Groups["title"].Value}");

        await Assert.That(rows).IsEquivalentTo(expectedRows, CollectionOrdering.Matching);
    }

    [Test]
    public async Task Page_HasOneSectionForEachDiagnostic()
    {
        var expectedHeadings = Descriptors.Select(static descriptor => $"### `{descriptor.Id}`");

        var headings = PageLines.Where(static line => line.StartsWith("### ", StringComparison.Ordinal));

        await Assert.That(headings).IsEquivalentTo(expectedHeadings, CollectionOrdering.Matching);
    }

    // The anchor of a section is the identifier of its diagnostic, in lowercase.
    [Test]
    public async Task HelpLink_OfEachDiagnostic_NamesItsSectionOfThePage()
    {
        var expectedLinks = Descriptors.Select(static descriptor => $"DIAGNOSTICS.HTML#{descriptor.Id}");

        var links = Descriptors.Select(static descriptor => descriptor.HelpLinkUri.Split('/')[^1].ToUpperInvariant());

        await Assert.That(links).IsEquivalentTo(expectedLinks, CollectionOrdering.Matching);
        await Assert.That(Descriptors.Select(static descriptor => descriptor.HelpLinkUri.Split('#')[^1])).ContainsOnly(IsLowercase);

        static bool IsLowercase(string anchor) => anchor.All(static c => !char.IsUpper(c));
    }
}
