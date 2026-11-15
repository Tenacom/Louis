// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Diagnostics;
using Louis.Processes;
using Louis.Text;
using TUnit.Core.Enums;

internal sealed class ConsoleUtilityTests
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
        var codePage = ParseLastNumber(RunChcpInNewConsole(cancellationToken));

        await Assert.That(ConsoleUtility.SystemDefaultEncoding.CodePage).IsEqualTo(codePage);
    }

    // chcp names the code page of its console. With CreateNoWindow on, that console is a new one.
    // The helper is synchronous, and uses no member that .NET Framework lacks, so that every test project compiles it.
    private static string RunChcpInNewConsole(CancellationToken cancellationToken)
    {
        using var process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.Arguments = "/c chcp";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.RedirectStandardOutput = true;
        _ = process.Start();

        // Killing the child ends its standard output, and the read with it.
        using var registration = cancellationToken.Register(process.Kill);
        var output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        return output;
    }

    // The text around the code page depends on the language of Windows. The code page is the last number in the text.
    private static int ParseLastNumber(string text)
    {
        var end = text.Length;
        while (end > 0 && !IsDigit(text[end - 1]))
        {
            end--;
        }

        var start = end;
        while (start > 0 && IsDigit(text[start - 1]))
        {
            start--;
        }

        var number = 0;
        for (var i = start; i < end; i++)
        {
            number *= 10;
            number += text[i] - '0';
        }

        return number;

        static bool IsDigit(char c) => c is >= '0' and <= '9';
    }
}
