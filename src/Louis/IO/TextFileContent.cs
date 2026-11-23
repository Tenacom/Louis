// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Text;
using Louis.Diagnostics;

namespace Louis.IO;

/// <summary>
/// Holds the text of a file, and the encoding to write the file back with.
/// </summary>
/// <seealso cref="TextFileUtility"/>
public sealed class TextFileContent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TextFileContent"/> class.
    /// </summary>
    /// <param name="text">The text of the file.</param>
    /// <param name="encoding">The encoding to write the file back with.</param>
    /// <exception cref="ArgumentNullException">
    /// <para><paramref name="text"/> is <see langword="null"/>.</para>
    /// <para>- or -</para>
    /// <para><paramref name="encoding"/> is <see langword="null"/>.</para>
    /// </exception>
    public TextFileContent(string text, Encoding encoding)
    {
        Text = Param.NotNull(text);
        Encoding = Param.NotNull(encoding);
    }

    /// <summary>
    /// Gets the text of the file.
    /// </summary>
    public string Text { get; }

    /// <summary>
    /// Gets the encoding to write the file back with.
    /// </summary>
    /// <value>
    /// For a content that <see cref="TextFileUtility.ReadAllText"/> returns, the encoding of the byte order mark of the file,
    /// or the fallback encoding if the file has none.
    /// </value>
    public Encoding Encoding { get; }

    /// <summary>
    /// Deconstructs this instance into the text of the file and the encoding to write the file back with.
    /// </summary>
    /// <param name="text">When this method returns, the value of <see cref="Text"/>.</param>
    /// <param name="encoding">When this method returns, the value of <see cref="Encoding"/>.</param>
    public void Deconstruct(out string text, out Encoding encoding)
    {
        text = Text;
        encoding = Encoding;
    }
}
