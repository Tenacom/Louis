// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Text;
using Louis.IO;
using TUnit.Assertions.Enums;

/// <summary>
/// Holds the tests that <see cref="TextFileUtility.WriteAllTextIfChanged"/>
/// and <see cref="TextFileUtility.WriteAllTextIfChangedAsync"/> share.
/// A derived class says which of the two methods <see cref="WriteAsync"/> calls,
/// and which of the two read methods <see cref="ReadAsync"/> calls.
/// </summary>
internal abstract class TextFileUtilityWriteAllTextIfChangedTestsBase
{
    // A timestamp that no write of a test gives to a file.
    private static readonly DateTime OldTimeUtc = new(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    [Test]
    public async Task WithMissingFile_WritesIt(CancellationToken cancellationToken)
    {
        using var file = new TemporaryFile();

        var written = await WriteAsync(file.FilePath, TextFileSamples.Text, Encoding.UTF8, cancellationToken);

        var expectedBytes = TextFileSamples.GetBytes(TextFileSamples.Text, Encoding.UTF8);
        await Assert.That(written).IsTrue();
        await Assert.That(file.ReadAllBytes()).IsEquivalentTo(expectedBytes, CollectionOrdering.Matching);
    }

    [Test]
    public async Task WithUnchangedText_LeavesFileAlone(CancellationToken cancellationToken)
    {
        using var file = new TemporaryFile(TextFileSamples.GetBytes(TextFileSamples.Text, Encoding.UTF8));
        file.LastWriteTimeUtc = OldTimeUtc;

        var written = await WriteAsync(file.FilePath, TextFileSamples.Text, Encoding.UTF8, cancellationToken);

        await Assert.That(written).IsFalse();
        await Assert.That(file.LastWriteTimeUtc).IsEqualTo(OldTimeUtc);
    }

    [Test]
    public async Task WithChangedText_WritesFile(CancellationToken cancellationToken)
    {
        // The new text is shorter than the old one, so the write must also shorten the file.
        using var file = new TemporaryFile(TextFileSamples.GetBytes(TextFileSamples.Text, Encoding.UTF8));
        file.LastWriteTimeUtc = OldTimeUtc;

        var written = await WriteAsync(file.FilePath, "new", Encoding.UTF8, cancellationToken);

        var expectedBytes = TextFileSamples.GetBytes("new", Encoding.UTF8);
        await Assert.That(written).IsTrue();
        await Assert.That(file.ReadAllBytes()).IsEquivalentTo(expectedBytes, CollectionOrdering.Matching);
        await Assert.That(file.LastWriteTimeUtc).IsNotEqualTo(OldTimeUtc);
    }

    [Test]
    public async Task WithEmptyText_WritesByteOrderMark(CancellationToken cancellationToken)
    {
        using var file = new TemporaryFile();

        var written = await WriteAsync(file.FilePath, string.Empty, Encoding.UTF8, cancellationToken);

        await Assert.That(written).IsTrue();
        await Assert.That(file.ReadAllBytes()).IsEquivalentTo(Encoding.UTF8.GetPreamble(), CollectionOrdering.Matching);
    }

    [Test]
    public async Task WithFileWithoutByteOrderMark_ComparesText(CancellationToken cancellationToken)
    {
        // Encoding.UTF8 emits a byte order mark, which this file does not have. The text is the same, so the file is unchanged.
        var bytes = Encoding.UTF8.GetBytes(TextFileSamples.Text);
        using var file = new TemporaryFile(bytes);

        var written = await WriteAsync(file.FilePath, TextFileSamples.Text, Encoding.UTF8, cancellationToken);

        await Assert.That(written).IsFalse();
        await Assert.That(file.ReadAllBytes()).IsEquivalentTo(bytes, CollectionOrdering.Matching);
    }

    [Test]
    public async Task WithFileWithByteOrderMarkAndEncodingWithout_WritesFile(CancellationToken cancellationToken)
    {
        // Read with no detection, the byte order mark of the file is a character of its text, so the file is changed.
        var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
        using var file = new TemporaryFile(TextFileSamples.GetBytes(TextFileSamples.Text, Encoding.UTF8));

        var written = await WriteAsync(file.FilePath, TextFileSamples.Text, encoding, cancellationToken);

        var expectedBytes = encoding.GetBytes(TextFileSamples.Text);
        await Assert.That(written).IsTrue();
        await Assert.That(file.ReadAllBytes()).IsEquivalentTo(expectedBytes, CollectionOrdering.Matching);
    }

    [Test]
    [MethodDataSource(typeof(TextFileSamples), nameof(TextFileSamples.Encodings))]
    public async Task AfterRead_KeepsBytesOfFile(Encoding encoding, CancellationToken cancellationToken)
    {
        var bytes = TextFileSamples.GetBytes(TextFileSamples.Text, encoding);
        using var file = new TemporaryFile(bytes);
        var (text, readEncoding) = await ReadAsync(file.FilePath, cancellationToken);

        var writtenWhenUnchanged = await WriteAsync(file.FilePath, text, readEncoding, cancellationToken);
        var writtenWhenChanged = await WriteAsync(file.FilePath, text + "!", readEncoding, cancellationToken);
        var writtenWhenRestored = await WriteAsync(file.FilePath, text, readEncoding, cancellationToken);

        await Assert.That(writtenWhenUnchanged).IsFalse();
        await Assert.That(writtenWhenChanged).IsTrue();
        await Assert.That(writtenWhenRestored).IsTrue();
        await Assert.That(file.ReadAllBytes()).IsEquivalentTo(bytes, CollectionOrdering.Matching);
    }

    [Test]
    public async Task WithMissingDirectory_ThrowsDirectoryNotFoundException(CancellationToken cancellationToken)
    {
        using var file = new TemporaryFile();
        var path = Path.Combine(file.DirectoryPath, "missing", "file.txt");

        Task Act() => WriteAsync(path, TextFileSamples.Text, Encoding.UTF8, cancellationToken);

        await Assert.That(Act).Throws<DirectoryNotFoundException>();
    }

    [Test]
    public async Task WithNullPath_ThrowsArgumentNullException(CancellationToken cancellationToken)
    {
        // ! Null on purpose: testing null detection
        Task Act() => WriteAsync(null!, TextFileSamples.Text, Encoding.UTF8, cancellationToken);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("path");
    }

    [Test]
    public async Task WithNullText_ThrowsArgumentNullException(CancellationToken cancellationToken)
    {
        using var file = new TemporaryFile();

        // ! Null on purpose: testing null detection
        Task Act() => WriteAsync(file.FilePath, null!, Encoding.UTF8, cancellationToken);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("text");
        await Assert.That(file.Exists).IsFalse();
    }

    [Test]
    public async Task WithNullEncoding_UsesUtf8WithoutByteOrderMark(CancellationToken cancellationToken)
    {
        using var file = new TemporaryFile();

        var writtenWhenMissing = await WriteAsync(file.FilePath, TextFileSamples.Text, null, cancellationToken);
        var writtenWhenUnchanged = await WriteAsync(file.FilePath, TextFileSamples.Text, null, cancellationToken);

        var expectedBytes = Encoding.UTF8.GetBytes(TextFileSamples.Text);
        await Assert.That(writtenWhenMissing).IsTrue();
        await Assert.That(writtenWhenUnchanged).IsFalse();
        await Assert.That(file.ReadAllBytes()).IsEquivalentTo(expectedBytes, CollectionOrdering.Matching);
    }

    // Calls the read method that goes with the method under test.
    protected abstract Task<TextFileContent> ReadAsync(string path, CancellationToken cancellationToken);

    // Calls the method under test.
    protected abstract Task<bool> WriteAsync(
        string path,
        string text,
        Encoding? encoding,
        CancellationToken cancellationToken);
}
