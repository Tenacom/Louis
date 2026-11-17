// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Text;
using Louis.IO;

#pragma warning disable CA1849 // Call async methods when in an async method - the synchronous ReadAllText is the method under test
[InheritsTests]
internal sealed class TextFileUtilityReadAllTextTests : TextFileUtilityReadAllTextTestsBase
{
    protected override Task<TextFileContent> ReadAsync(
        string path,
        Encoding? fallbackEncoding,
        CancellationToken cancellationToken)
        => Task.FromResult(TextFileUtility.ReadAllText(path, fallbackEncoding));
}
