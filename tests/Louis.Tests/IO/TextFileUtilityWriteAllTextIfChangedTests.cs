// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Text;
using Louis.IO;

#pragma warning disable CA1849 // Call async methods when in an async method - this class tests the synchronous methods
[InheritsTests]
internal sealed class TextFileUtilityWriteAllTextIfChangedTests : TextFileUtilityWriteAllTextIfChangedTestsBase
{
    protected override Task<TextFileContent> ReadAsync(string path, CancellationToken cancellationToken)
        => Task.FromResult(TextFileUtility.ReadAllText(path));

    protected override Task<bool> WriteAsync(
        string path,
        string text,
        Encoding? encoding,
        CancellationToken cancellationToken)
        => Task.FromResult(TextFileUtility.WriteAllTextIfChanged(path, text, encoding));
}
