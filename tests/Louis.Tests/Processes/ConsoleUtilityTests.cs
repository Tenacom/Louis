// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET5_0_OR_GREATER

using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using Louis.Processes;
using Louis.Text;
using TUnit.Core.Enums;

internal sealed partial class ConsoleUtilityTests
{
    [Test]
    public async Task SystemDefaultEncoding_WritesNoByteOrderMark()
    {
        await Assert.That(ConsoleUtility.SystemDefaultEncoding.GetPreamble()).IsEmpty();
    }

    [Test]
    public async Task SystemDefaultEncoding_ReturnsSameInstanceEveryTime()
    {
        await Assert.That(ConsoleUtility.SystemDefaultEncoding).IsSameReferenceAs(ConsoleUtility.SystemDefaultEncoding);
    }

    [Test]
    [ExcludeOn(OS.Windows)]
    public async Task SystemDefaultEncoding_OutsideWindows_IsUtf8()
    {
        await Assert.That(ConsoleUtility.SystemDefaultEncoding).IsSameReferenceAs(Utf8Utility.Utf8NoBomEncoding);
    }

    [Test]
    [RunOn(OS.Windows)]
    [Timeout(60_000)]
    public async Task SystemDefaultEncoding_OnWindows_HasCodePageOfNewConsole(CancellationToken cancellationToken)
    {
        // chcp names the code page of its console. With CreateNoWindow on, that console is a new one.
        // The text around the number depends on the language of Windows, and the number is the last thing on the line.
        var startInfo = new ProcessStartInfo("cmd.exe") { UseShellExecute = false, CreateNoWindow = true, RedirectStandardOutput = true };
        startInfo.ArgumentList.Add("/c");
        startInfo.ArgumentList.Add("chcp");
        using var process = await Assert.That(Process.Start(startInfo)).IsNotNull();
        var output = await process.StandardOutput.ReadToEndAsync(cancellationToken);
        await process.WaitForExitAsync(cancellationToken);
        var codePage = int.Parse(TrailingNumber().Match(output).Value, CultureInfo.InvariantCulture);

        await Assert.That(ConsoleUtility.SystemDefaultEncoding.CodePage).IsEqualTo(codePage);
    }

    [GeneratedRegex(@"\d+(?=\s*$)")]
    private static partial Regex TrailingNumber();
}

#endif
