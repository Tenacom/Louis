// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET5_0_OR_GREATER

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Louis.Text;

namespace Louis.Processes;

/// <summary>
/// <para>Provides utility members to work with the console.</para>
/// <para>This type is not available in the <c>netstandard</c> and .NET Framework builds of Louis,
/// which have no <c>Louis.Processes</c> namespace.</para>
/// </summary>
public static partial class ConsoleUtility
{
    /// <summary>
    /// Gets the encoding that a new console of the system starts with.
    /// </summary>
    /// <value>
    /// On Windows, the encoding of the OEM code page of the system.
    /// On every other operating system, UTF-8 without a byte order mark (BOM).
    /// </value>
    /// <remarks>
    /// <para>A console program that sets no encoding writes its redirected output with the encoding of its console.
    /// On Windows, a child process started without a console window gets a console of its own, which starts
    /// with this encoding, whatever the encoding of the console of its parent.
    /// This encoding therefore decodes the output of such a child.</para>
    /// <para>The <see cref="System.Diagnostics.Process"/> class decodes redirected output with the encoding
    /// of the console of the current process by default, or with the ANSI code page of the system
    /// when the current process has no console. Neither is the encoding such a child writes with.</para>
    /// <para>This property needs no call to <see cref="Encoding.RegisterProvider"/>,
    /// and the encoding it returns never writes a byte order mark.</para>
    /// </remarks>
    public static Encoding SystemDefaultEncoding { get; } = GetSystemDefaultEncoding();

    [ExcludeFromCodeCoverage(Justification = "The path taken depends on the operating system and on its OEM code page.")]
    private static Encoding GetSystemDefaultEncoding()
    {
        if (!OperatingSystem.IsWindows())
        {
            return Utf8Utility.Utf8NoBomEncoding;
        }

        // A new console starts with the OEM code page of the system. MSBuild decodes the output of a tool the same way:
        // see EncodingUtilities.CurrentSystemOemEncoding in https://github.com/dotnet/msbuild/blob/main/src/Framework/EncodingUtilities.cs
        // CodePagesEncodingProvider returns null for UTF-8 (code page 65001), because the runtime has that encoding built in.
        var codePage = (int)NativeMethods.GetOEMCP();
        return CodePagesEncodingProvider.Instance.GetEncoding(codePage) ?? Utf8Utility.Utf8NoBomEncoding;
    }
}

#endif
