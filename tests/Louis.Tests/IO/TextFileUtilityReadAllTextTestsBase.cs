// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Text;
using Louis.IO;
using TUnit.Assertions.Enums;

/// <summary>
/// Holds the tests that <see cref="TextFileUtility.ReadAllText"/> and <see cref="TextFileUtility.ReadAllTextAsync"/> share.
/// A derived class says which of the two methods <see cref="ReadAsync"/> calls.
/// </summary>
internal abstract class TextFileUtilityReadAllTextTestsBase
{
    [Test]
    [MethodDataSource(typeof(TextFileSamples), nameof(TextFileSamples.EncodingsWithByteOrderMark))]
    public async Task WithByteOrderMark_ReturnsItsEncoding(Encoding encoding, CancellationToken cancellationToken)
    {
        using var file = new TemporaryFile(TextFileSamples.GetBytes(TextFileSamples.Text, encoding));

        var content = await ReadAsync(file.FilePath, null, cancellationToken);

        await Assert.That(content.Text).IsEqualTo(TextFileSamples.Text);
        await Assert.That(content.Encoding.WebName).IsEqualTo(encoding.WebName);
        await Assert.That(content.Encoding.GetPreamble()).IsEquivalentTo(encoding.GetPreamble(), CollectionOrdering.Matching);
    }

    [Test]
    public async Task WithoutByteOrderMark_ReturnsUtf8WithoutByteOrderMark(CancellationToken cancellationToken)
    {
        using var file = new TemporaryFile(Encoding.UTF8.GetBytes(TextFileSamples.Text));

        var content = await ReadAsync(file.FilePath, null, cancellationToken);

        await Assert.That(content.Text).IsEqualTo(TextFileSamples.Text);
        await Assert.That(content.Encoding.WebName).IsEqualTo("utf-8");
        await Assert.That(content.Encoding.GetPreamble()).IsEmpty();
    }

    [Test]
    public async Task WithFallbackEncoding_ReadsFileWithoutByteOrderMarkWithIt(CancellationToken cancellationToken)
    {
        // Encoding.Unicode emits a byte order mark, which this file does not have. The read returns the encoding as it is.
        using var file = new TemporaryFile(Encoding.Unicode.GetBytes(TextFileSamples.Text));

        var content = await ReadAsync(file.FilePath, Encoding.Unicode, cancellationToken);

        await Assert.That(content.Text).IsEqualTo(TextFileSamples.Text);
        await Assert.That(content.Encoding).IsSameReferenceAs(Encoding.Unicode);
    }

    [Test]
    public async Task WithFallbackEncoding_PrefersByteOrderMark(CancellationToken cancellationToken)
    {
        using var file = new TemporaryFile(TextFileSamples.GetBytes(TextFileSamples.Text, Encoding.UTF8));

        var content = await ReadAsync(file.FilePath, Encoding.Unicode, cancellationToken);

        await Assert.That(content.Text).IsEqualTo(TextFileSamples.Text);
        await Assert.That(content.Encoding.WebName).IsEqualTo("utf-8");
    }

    [Test]
    public async Task WithEmptyFile_ReturnsEmptyTextAndFallbackEncoding(CancellationToken cancellationToken)
    {
        using var file = new TemporaryFile([]);

        var content = await ReadAsync(file.FilePath, Encoding.Unicode, cancellationToken);

        await Assert.That(content.Text).IsEmpty();
        await Assert.That(content.Encoding).IsSameReferenceAs(Encoding.Unicode);
    }

    [Test]
    public async Task WithInvalidBytes_ReplacesThem(CancellationToken cancellationToken)
    {
        using var file = new TemporaryFile(TextFileSamples.InvalidUtf8);

        var content = await ReadAsync(file.FilePath, null, cancellationToken);

        await Assert.That(content.Text).IsEqualTo(TextFileSamples.InvalidUtf8Replaced);
    }

    [Test]
    public async Task WithInvalidBytesAndThrowingFallbackEncoding_ThrowsDecoderFallbackException(
        CancellationToken cancellationToken)
    {
        using var file = new TemporaryFile(TextFileSamples.InvalidUtf8);
        var fallbackEncoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

        Task Act() => ReadAsync(file.FilePath, fallbackEncoding, cancellationToken);

        await Assert.That(Act).Throws<DecoderFallbackException>();
    }

    [Test]
    public async Task WithByteOrderMarkAndThrowingFallbackEncoding_ReplacesInvalidBytes(
        CancellationToken cancellationToken)
    {
        using var file = new TemporaryFile([.. Encoding.UTF8.GetPreamble(), .. TextFileSamples.InvalidUtf8]);
        var fallbackEncoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

        var content = await ReadAsync(file.FilePath, fallbackEncoding, cancellationToken);

        await Assert.That(content.Text).IsEqualTo(TextFileSamples.InvalidUtf8Replaced);
    }

    [Test]
    public async Task WithMissingFile_ThrowsFileNotFoundException(CancellationToken cancellationToken)
    {
        using var file = new TemporaryFile();

        Task Act() => ReadAsync(file.FilePath, null, cancellationToken);

        await Assert.That(Act).Throws<FileNotFoundException>();
    }

    [Test]
    public async Task WithNullPath_ThrowsArgumentNullException(CancellationToken cancellationToken)
    {
        // ! Null on purpose: testing null detection
        Task Act() => ReadAsync(null!, null, cancellationToken);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("path");
    }

    // Calls the method under test.
    protected abstract Task<TextFileContent> ReadAsync(
        string path,
        Encoding? fallbackEncoding,
        CancellationToken cancellationToken);
}
