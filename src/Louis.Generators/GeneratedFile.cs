// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace Louis.Generators;

/// <summary>
/// Holds a source file that the source generator adds to a compilation.
/// </summary>
/// <param name="HintName">The name of the file, unique within the compilation.</param>
/// <param name="Text">The C# text of the file.</param>
internal sealed record GeneratedFile(string HintName, string Text);
