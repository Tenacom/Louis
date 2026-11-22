// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Globalization;
using Louis.Diagnostics;

// Every chain check formats its message the same way. These tests cover the rules once, through checks of each arity.
internal sealed class ParamExtensionsMessageTests
{
    [Test]
    public async Task Message_WithFormatItems_ReceivesNameValueAndArguments()
    {
        static void Act(int count) => Param.Check(count).InRange(10, 20, "{0}|{1}|{2}|{3}");

        await Assert.That(() => Act(5))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining("count|5|10|20", StringComparison.Ordinal)
            .And.WithParameterName("count");
    }

    [Test]
    public async Task Message_WithoutFormatItems_IsUsedAsItIs()
    {
        static void Act(int count) => Param.Check(count).GreaterThan(0, "There must be at least one item.");

        await Assert.That(() => Act(0))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining("There must be at least one item.", StringComparison.Ordinal);
    }

    [Test]
    [Arguments("{0} must be in {range")]
    [Arguments("{0} must be in {7}")]
    [Arguments("} {0} {")]
    public async Task Message_ThatIsNotValidFormatString_IsUsedAsItIs(string message)
    {
        static void Act(int count, string message) => Param.Check(count).GreaterThan(0, message);

        await Assert.That(() => Act(0, message))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining(message, StringComparison.Ordinal);
    }

    [Test]
    public async Task Message_WithEscapedBraces_KeepsBraces()
    {
        static void Act(int count) => Param.Check(count).GreaterThan(0, "{{{0}}} is too small.");

        await Assert.That(() => Act(0))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining("{count} is too small.", StringComparison.Ordinal);
    }

    [Test]
    public async Task Message_WithStringValues_ShowsStringLiterals()
    {
        static void Act(string text) => Param.Check(text).EqualTo("a\tb");

        await Assert.That(() => Act("abc"))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("""text ("abc") must be equal to "a\tb".""", StringComparison.Ordinal);
    }

    [Test]
    public async Task Message_WithFormattableValues_UsesInvariantCulture()
    {
        static void Act(double ratio) => Param.Check(ratio).LessThan(1.5);

        // A culture whose decimal separator is a comma. The current culture belongs to the execution context of the test.
        var previousCulture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("it-IT");
        ArgumentOutOfRangeException exception;
        try
        {
            exception = Assert.Throws<ArgumentOutOfRangeException>(() => Act(2.25));
        }
        finally
        {
            CultureInfo.CurrentCulture = previousCulture;
        }

        await Assert.That(exception.Message).Contains("ratio (2.25) must be less than 1.5.", StringComparison.Ordinal);
    }

    [Test]
    public async Task Message_WithExplicitName_NamesParameter()
    {
        // ReSharper disable once ExplicitCallerInfoArgument // the test passes the name on purpose
        static void Act(int count) => Param.Check(count, "other").GreaterThan(0);

        await Assert.That(() => Act(0))
            .ThrowsExactly<ArgumentOutOfRangeException>()
            .WithMessageContaining("other (0) must be greater than 0.", StringComparison.Ordinal)
            .And.WithParameterName("other");
    }

    [Test]
    public async Task FailedComparison_SetsActualValue()
    {
        static void Act(int count) => Param.Check(count).GreaterThan(0);

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Act(-3));

        await Assert.That(exception.ActualValue).IsEqualTo(-3);
    }
}
