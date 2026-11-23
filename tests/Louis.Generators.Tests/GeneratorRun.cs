// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Microsoft.CodeAnalysis;

/// <summary>
/// Holds the result of a run of the source generator.
/// </summary>
/// <param name="Driver">The driver, after the run.</param>
/// <param name="Output">The compilation, with the source files that the source generator added.</param>
/// <param name="Problems">The warnings and the errors that the compiler reports on <paramref name="Output"/>.
/// A missing XML comment in the source of the test does not count: only the generated code has to have its comments.</param>
internal sealed record GeneratorRun(GeneratorDriver Driver, Compilation Output, IReadOnlyList<string> Problems)
{
    /// <summary>
    /// Gets the source files that the source generator added, by hint name.
    /// </summary>
    public IReadOnlyDictionary<string, string> Files { get; } = Driver.GetRunResult().Results
        .SelectMany(static result => result.GeneratedSources)
        .ToDictionary(static source => source.HintName, static source => source.SourceText.ToString());
}
