// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Text;
using Louis.IO;

[InheritsTests]
internal sealed class TextFileUtilityReadAllTextAsyncTests : TextFileUtilityReadAllTextTestsBase
{
    [Test]
    public async Task WithCanceledToken_ThrowsWithoutOpeningFile()
    {
        // A missing file would throw FileNotFoundException if the method tried to open it.
        using var file = new TemporaryFile();
        var canceledToken = new CancellationToken(canceled: true);

        Task Act() => TextFileUtility.ReadAllTextAsync(file.FilePath, cancellationToken: canceledToken);

        var exception = await Assert.That(Act).Throws<OperationCanceledException>();

        await Assert.That(exception?.CancellationToken).IsEqualTo(canceledToken);
    }

    protected override Task<TextFileContent> ReadAsync(
        string path,
        Encoding? fallbackEncoding,
        CancellationToken cancellationToken)
        => TextFileUtility.ReadAllTextAsync(path, fallbackEncoding, cancellationToken);
}
