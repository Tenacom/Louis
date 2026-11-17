// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Diagnostics;
using Louis.Text;

namespace Louis.IO;

/// <summary>
/// Provides methods to read a text file together with its encoding, and to write a text file only when its text changes.
/// </summary>
public static class TextFileUtility
{
#if !NET7_0_OR_GREATER
    // The buffer size of a FileStream that the File class opens.
    private const int FileBufferSize = 4096;

    // The default buffer size of Stream.CopyToAsync.
    private const int CopyBufferSize = 81920;
#endif

    /// <summary>
    /// Reads the text of a file, together with the encoding to write the file back with.
    /// </summary>
    /// <param name="path">The path of the file to read.</param>
    /// <param name="fallbackEncoding">The encoding of a file that has no byte order mark,
    /// or <see langword="null"/> for UTF-8 without a byte order mark.
    /// A fallback encoding that emits a byte order mark is returned as it is,
    /// so a file written back with it gets a byte order mark.</param>
    /// <returns>The text of the file, and the encoding to write the file back with.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="path"/> is <see langword="null"/>.</exception>
    /// <exception cref="FileNotFoundException">The file does not exist.</exception>
    /// <remarks>
    /// <para>This method recognizes the byte order marks of UTF-8, UTF-16, and UTF-32.
    /// When the file starts with one, the returned encoding is the encoding of that byte order mark, and emits it.
    /// When the file starts with none, the returned encoding is the fallback encoding.
    /// A file written back with the returned encoding keeps the byte order mark it had,
    /// and a file that had none gets none, unless the fallback encoding emits one.</para>
    /// <para>A file that starts with the byte order mark of the fallback encoding is read with the fallback encoding,
    /// which is also the returned encoding.
    /// The encoding of any other byte order mark replaces every invalid byte sequence with the replacement character, U+FFFD.
    /// The default fallback encoding does the same, as <see cref="File.ReadAllText(string)"/> does.
    /// To get a <see cref="DecoderFallbackException"/> for an invalid byte sequence in a file without a byte order mark,
    /// pass <c>new UTF8Encoding(false, true)</c> as <paramref name="fallbackEncoding"/>.</para>
    /// <para>For a file it cannot read, this method throws what <see cref="File.ReadAllText(string, Encoding)"/> throws.</para>
    /// </remarks>
    /// <seealso cref="ReadAllTextAsync"/>
    /// <seealso cref="WriteAllTextIfChanged"/>
    public static TextFileContent ReadAllText(string path, Encoding? fallbackEncoding = null)
    {
        Guard.IsNotNull(path);

        return Read(path, fallbackEncoding ?? Utf8Utility.Utf8NoBomEncoding, detectEncoding: true);
    }

    /// <summary>
    /// Asynchronously reads the text of a file, together with the encoding to write the file back with.
    /// </summary>
    /// <param name="path">The path of the file to read.</param>
    /// <param name="fallbackEncoding">The encoding of a file that has no byte order mark,
    /// or <see langword="null"/> for UTF-8 without a byte order mark.
    /// A fallback encoding that emits a byte order mark is returned as it is,
    /// so a file written back with it gets a byte order mark.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that, when signaled, ends the read.</param>
    /// <returns>A <see cref="Task{TResult}"/> whose result holds the text of the file,
    /// and the encoding to write the file back with.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="path"/> is <see langword="null"/>.</exception>
    /// <exception cref="FileNotFoundException">The file does not exist.</exception>
    /// <exception cref="OperationCanceledException"><paramref name="cancellationToken"/> was signaled
    /// before the read ended.</exception>
    /// <remarks>
    /// <para>This method recognizes the byte order marks of UTF-8, UTF-16, and UTF-32.
    /// When the file starts with one, the returned encoding is the encoding of that byte order mark, and emits it.
    /// When the file starts with none, the returned encoding is the fallback encoding.
    /// A file written back with the returned encoding keeps the byte order mark it had,
    /// and a file that had none gets none, unless the fallback encoding emits one.</para>
    /// <para>A file that starts with the byte order mark of the fallback encoding is read with the fallback encoding,
    /// which is also the returned encoding.
    /// The encoding of any other byte order mark replaces every invalid byte sequence with the replacement character, U+FFFD.
    /// The default fallback encoding does the same, as <see cref="File.ReadAllText(string)"/> does.
    /// To get a <see cref="DecoderFallbackException"/> for an invalid byte sequence in a file without a byte order mark,
    /// pass <c>new UTF8Encoding(false, true)</c> as <paramref name="fallbackEncoding"/>.</para>
    /// <para>For a file it cannot read, this method throws what <see cref="File.ReadAllText(string, Encoding)"/> throws.</para>
    /// </remarks>
    /// <seealso cref="ReadAllText"/>
    /// <seealso cref="WriteAllTextIfChangedAsync"/>
    public static Task<TextFileContent> ReadAllTextAsync(
        string path,
        Encoding? fallbackEncoding = null,
        CancellationToken cancellationToken = default)
    {
        Guard.IsNotNull(path);

        return ReadAsync(path, fallbackEncoding ?? Utf8Utility.Utf8NoBomEncoding, detectEncoding: true, cancellationToken);
    }

    /// <summary>
    /// Writes a text to a file, unless the file holds that text already.
    /// </summary>
    /// <param name="path">The path of the file to write.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="encoding">The encoding to read the file with, and to write it with,
    /// or <see langword="null"/> for UTF-8 without a byte order mark.</param>
    /// <returns><see langword="true"/> if this method wrote the file;
    /// <see langword="false"/> if the file held <paramref name="text"/> already.</returns>
    /// <exception cref="ArgumentNullException">
    /// <para><paramref name="path"/> is <see langword="null"/>.</para>
    /// <para>- or -</para>
    /// <para><paramref name="text"/> is <see langword="null"/>.</para>
    /// </exception>
    /// <exception cref="DirectoryNotFoundException">The directory of the file does not exist.</exception>
    /// <remarks>
    /// <para>This method writes the file when the file does not exist,
    /// and when its text differs from <paramref name="text"/> by ordinal comparison.
    /// A file this method does not write keeps its timestamp.</para>
    /// <para>The comparison is on text, not on bytes. This method reads the file with the encoding it writes with,
    /// and detects no encoding from a byte order mark.
    /// A file without a byte order mark, compared through an encoding that emits one,
    /// counts as unchanged when the text is the same.
    /// A file with a byte order mark, compared through an encoding that emits none, counts as changed.</para>
    /// <para>For a file it cannot read or write, this method throws
    /// what <see cref="File.ReadAllText(string, Encoding)"/> and <see cref="File.WriteAllText(string, string, Encoding)"/> throw.</para>
    /// </remarks>
    /// <seealso cref="WriteAllTextIfChangedAsync"/>
    /// <seealso cref="ReadAllText"/>
    public static bool WriteAllTextIfChanged(string path, string text, Encoding? encoding = null)
    {
        Guard.IsNotNull(path);
        Guard.IsNotNull(text);

        encoding ??= Utf8Utility.Utf8NoBomEncoding;
        if (HasText(path, text, encoding))
        {
            return false;
        }

        File.WriteAllText(path, text, encoding);
        return true;
    }

    /// <summary>
    /// Asynchronously writes a text to a file, unless the file holds that text already.
    /// </summary>
    /// <param name="path">The path of the file to write.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="encoding">The encoding to read the file with, and to write it with,
    /// or <see langword="null"/> for UTF-8 without a byte order mark.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that, when signaled, ends the operation.</param>
    /// <returns>A <see cref="Task{TResult}"/> whose result is <see langword="true"/> if this method wrote the file;
    /// <see langword="false"/> if the file held <paramref name="text"/> already.</returns>
    /// <exception cref="ArgumentNullException">
    /// <para><paramref name="path"/> is <see langword="null"/>.</para>
    /// <para>- or -</para>
    /// <para><paramref name="text"/> is <see langword="null"/>.</para>
    /// </exception>
    /// <exception cref="DirectoryNotFoundException">The directory of the file does not exist.</exception>
    /// <exception cref="OperationCanceledException"><paramref name="cancellationToken"/> was signaled
    /// before the operation ended.</exception>
    /// <remarks>
    /// <para>This method writes the file when the file does not exist,
    /// and when its text differs from <paramref name="text"/> by ordinal comparison.
    /// A file this method does not write keeps its timestamp.</para>
    /// <para>The comparison is on text, not on bytes. This method reads the file with the encoding it writes with,
    /// and detects no encoding from a byte order mark.
    /// A file without a byte order mark, compared through an encoding that emits one,
    /// counts as unchanged when the text is the same.
    /// A file with a byte order mark, compared through an encoding that emits none, counts as changed.</para>
    /// <para>A <paramref name="cancellationToken"/> signaled while this method writes the file leaves the file incomplete.</para>
    /// <para>For a file it cannot read or write, this method throws
    /// what <see cref="File.ReadAllText(string, Encoding)"/> and <see cref="File.WriteAllText(string, string, Encoding)"/> throw.</para>
    /// </remarks>
    /// <seealso cref="WriteAllTextIfChanged"/>
    /// <seealso cref="ReadAllTextAsync"/>
    public static Task<bool> WriteAllTextIfChangedAsync(
        string path,
        string text,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default)
    {
        Guard.IsNotNull(path);
        Guard.IsNotNull(text);

        return WriteAllTextIfChangedCoreAsync(path, text, encoding ?? Utf8Utility.Utf8NoBomEncoding, cancellationToken);
    }

    private static async Task<bool> WriteAllTextIfChangedCoreAsync(
        string path,
        string text,
        Encoding encoding,
        CancellationToken cancellationToken)
    {
        if (await HasTextAsync(path, text, encoding, cancellationToken).ConfigureAwait(false))
        {
            return false;
        }

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_0_OR_GREATER
        await File.WriteAllTextAsync(path, text, encoding, cancellationToken).ConfigureAwait(false);
#else
        await WriteAllTextAsync(path, text, encoding, cancellationToken).ConfigureAwait(false);
#endif
        return true;
    }

    // Returns false for a file that does not exist. Every other failure of the read reaches the caller.
    private static bool HasText(string path, string text, Encoding encoding)
    {
        try
        {
            return string.Equals(Read(path, encoding, detectEncoding: false).Text, text, StringComparison.Ordinal);
        }
        catch (FileNotFoundException)
        {
            return false;
        }
    }

    // Returns false for a file that does not exist. Every other failure of the read reaches the caller.
    private static async Task<bool> HasTextAsync(
        string path,
        string text,
        Encoding encoding,
        CancellationToken cancellationToken)
    {
        try
        {
            var content = await ReadAsync(path, encoding, detectEncoding: false, cancellationToken).ConfigureAwait(false);
            return string.Equals(content.Text, text, StringComparison.Ordinal);
        }
        catch (FileNotFoundException)
        {
            return false;
        }
    }

    private static TextFileContent Read(string path, Encoding encoding, bool detectEncoding)
    {
        using var reader = new StreamReader(path, encoding, detectEncoding);
        return ReadToEnd(reader);
    }

#if NET7_0_OR_GREATER
    private static async Task<TextFileContent> ReadAsync(
        string path,
        Encoding encoding,
        bool detectEncoding,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var options = new FileStreamOptions { Options = FileOptions.Asynchronous | FileOptions.SequentialScan };
        using var reader = new StreamReader(path, encoding, detectEncoding, options);
        var text = await reader.ReadToEndAsync(cancellationToken).ConfigureAwait(false);
        return new(text, reader.CurrentEncoding);
    }
#else
    // StreamReader.ReadToEndAsync takes no CancellationToken on these frameworks, and Stream.CopyToAsync takes one.
    // This method reads the bytes of the file with CopyToAsync, then decodes them from memory.
    private static async Task<TextFileContent> ReadAsync(
        string path,
        Encoding encoding,
        bool detectEncoding,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        using var bytes = new MemoryStream();
        var stream = new FileStream(
            path,
            FileMode.Open,
            FileAccess.Read,
            FileShare.Read,
            FileBufferSize,
            FileOptions.Asynchronous | FileOptions.SequentialScan);

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
        await using (stream.ConfigureAwait(false))
#else
        using (stream)
#endif
        {
            await stream.CopyToAsync(bytes, CopyBufferSize, cancellationToken).ConfigureAwait(false);
        }

        bytes.Position = 0;
        using var reader = new StreamReader(bytes, encoding, detectEncoding);
        return ReadToEnd(reader);
    }
#endif

    // A reader that detects the encoding has it in CurrentEncoding only after the first read.
    private static TextFileContent ReadToEnd(StreamReader reader)
    {
        var text = reader.ReadToEnd();
        return new(text, reader.CurrentEncoding);
    }

#if !(NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_0_OR_GREATER)
    // Does what File.WriteAllTextAsync does on the frameworks that have it.
    private static async Task WriteAllTextAsync(
        string path,
        string text,
        Encoding encoding,
        CancellationToken cancellationToken)
    {
        // The file starts with the byte order mark of the encoding, even when the text is empty.
        var preamble = encoding.GetPreamble();
        var bytes = new byte[preamble.Length + encoding.GetByteCount(text)];
        preamble.CopyTo(bytes, 0);
        _ = encoding.GetBytes(text, 0, text.Length, bytes, preamble.Length);

        // FileMode.Create truncates the file. A token that is signaled already ends the write before that.
        cancellationToken.ThrowIfCancellationRequested();
        using var stream = new FileStream(
            path,
            FileMode.Create,
            FileAccess.Write,
            FileShare.Read,
            FileBufferSize,
            FileOptions.Asynchronous);
        await stream.WriteAsync(bytes, 0, bytes.Length, cancellationToken).ConfigureAwait(false);
        await stream.FlushAsync(cancellationToken).ConfigureAwait(false);
    }
#endif
}
