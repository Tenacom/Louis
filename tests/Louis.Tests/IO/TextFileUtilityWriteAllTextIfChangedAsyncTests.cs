// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Text;
using Louis.IO;

[InheritsTests]
internal sealed class TextFileUtilityWriteAllTextIfChangedAsyncTests : TextFileUtilityWriteAllTextIfChangedTestsBase
{
    [Test]
    public async Task WithCanceledToken_ThrowsWithoutWritingFile()
    {
        using var file = new TemporaryFile();
        var canceledToken = new CancellationToken(canceled: true);

        Task Act() => TextFileUtility.WriteAllTextIfChangedAsync(file.FilePath, TextFileSamples.Text, Encoding.UTF8, canceledToken);

        var exception = await Assert.That(Act).Throws<OperationCanceledException>();

        await Assert.That(exception?.CancellationToken).IsEqualTo(canceledToken);
        await Assert.That(file.Exists).IsFalse();
    }

    protected override Task<TextFileContent> ReadAsync(string path, CancellationToken cancellationToken)
        => TextFileUtility.ReadAllTextAsync(path, cancellationToken: cancellationToken);

    protected override Task<bool> WriteAsync(
        string path,
        string text,
        Encoding? encoding,
        CancellationToken cancellationToken)
        => TextFileUtility.WriteAllTextIfChangedAsync(path, text, encoding, cancellationToken);
}
