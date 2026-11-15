// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Processes;

internal sealed class CommandLineFormatterTests
{
    // TUnit takes a row with an array from a Func, so that each test gets an array of its own.
    public static IEnumerable<Func<(string Executable, string[] Arguments, string Expected)>> FormatRows()
        => [
            // Nothing to quote
            () => ("git", [], "git"),
            () => ("git", ["status"], "git status"),
            () => ("git", ["rev-parse", "--abbrev-ref", "HEAD"], "git rev-parse --abbrev-ref HEAD"),
            () => ("tool", ["C:\\dir\\file.txt", "a'b", "--name=value"], "tool C:\\dir\\file.txt a'b --name=value"),

            // An empty item, and an item with a space, a tab, or a double quote
            () => ("tool", [string.Empty], "tool \"\""),
            () => ("tool", ["two words"], "tool \"two words\""),
            () => ("tool", ["tab\there"], "tool \"tab\there\""),
            () => ("tool", ["say \"hi\""], "tool \"say \\\"hi\\\"\""),
            () => ("tool", ["\""], "tool \"\\\"\""),

            // The executable follows the same rules
            () => ("C:\\Program Files\\tool.exe", ["one", "two words"], "\"C:\\Program Files\\tool.exe\" one \"two words\""),
        ];

    [Test]
    [MethodDataSource(nameof(FormatRows))]
    public async Task Format_ReturnsExecutableAndArguments(string executable, string[] arguments, string expected)
    {
        await Assert.That(CommandLineFormatter.Format(executable, arguments)).IsEqualTo(expected);
    }

    [Test]
    public async Task Format_EnumeratesArgumentsOnce()
    {
        var arguments = new RecordingEnumerable<string>(["one", "two"]);

        _ = CommandLineFormatter.Format("tool", arguments);

        await Assert.That(arguments.GetEnumeratorCallCount).IsEqualTo(1);
    }

    [Test]
    public async Task Format_WithNullExecutable_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => _ = CommandLineFormatter.Format(null!, []);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("executable");
    }

    [Test]
    public async Task Format_WithNullArguments_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => _ = CommandLineFormatter.Format("tool", null!);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("arguments");
    }

    [Test]
    public async Task Format_WithNullArgument_ThrowsArgumentException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => _ = CommandLineFormatter.Format("tool", ["one", null!]);

        await Assert.That(Act).Throws<ArgumentException>().WithParameterName("arguments");
    }
}
