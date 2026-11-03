// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Text;

internal sealed class UnicodeCharacterUtilityTests
{
    [Test]
    [Arguments('@', false)] // The character before 'A'
    [Arguments('A', true)]
    [Arguments('Z', true)]
    [Arguments('[', false)] // The character after 'Z'
    [Arguments('_', true)]
    [Arguments('`', false)] // The character before 'a'
    [Arguments('a', true)]
    [Arguments('z', true)]
    [Arguments('{', false)] // The character after 'z'
    [Arguments('0', false)]
    [Arguments('9', false)]
    [Arguments('\x7F', false)] // DEL
    [Arguments('é', true)] // A lowercase letter
    [Arguments('Ω', true)] // An uppercase letter
    [Arguments('ǅ', true)] // A titlecase letter
    [Arguments('ʰ', true)] // A modifier letter
    [Arguments('一', true)] // An other letter
    [Arguments('\x0661', false)] // Arabic-Indic digit one, a decimal digit
    [Arguments('\x2160', false)] // Roman numeral one, a letter number
    [Arguments('\x0301', false)] // Combining acute accent, a non-spacing mark
    [Arguments('\x0903', false)] // Devanagari sign visarga, a spacing combining mark
    [Arguments('\x203F', false)] // Undertie, a connector punctuation
    [Arguments('\x200D', false)] // Zero width joiner, a format character
    [Arguments('€', false)] // A currency symbol
    public async Task IsIdentifierStartCharacter_ReturnsWhetherCharacterCanStartIdentifier(char ch, bool expected)
    {
        await Assert.That(UnicodeCharacterUtility.IsIdentifierStartCharacter(ch)).IsEqualTo(expected);
    }

    [Test]
    [Arguments('/', false)] // The character before '0'
    [Arguments('0', true)]
    [Arguments('9', true)]
    [Arguments(':', false)] // The character after '9'
    [Arguments('@', false)] // The character before 'A'
    [Arguments('A', true)]
    [Arguments('Z', true)]
    [Arguments('[', false)] // The character after 'Z'
    [Arguments('_', true)]
    [Arguments('`', false)] // The character before 'a'
    [Arguments('a', true)]
    [Arguments('z', true)]
    [Arguments('{', false)] // The character after 'z'
    [Arguments('\x7F', false)] // DEL
    [Arguments('é', true)] // A lowercase letter
    [Arguments('Ω', true)] // An uppercase letter
    [Arguments('ǅ', true)] // A titlecase letter
    [Arguments('ʰ', true)] // A modifier letter
    [Arguments('一', true)] // An other letter
    [Arguments('\x0661', true)] // Arabic-Indic digit one, a decimal digit
    [Arguments('\x2160', true)] // Roman numeral one, a letter number
    [Arguments('\x0301', true)] // Combining acute accent, a non-spacing mark
    [Arguments('\x0903', true)] // Devanagari sign visarga, a spacing combining mark
    [Arguments('\x203F', true)] // Undertie, a connector punctuation
    [Arguments('\x200D', true)] // Zero width joiner, a format character
    [Arguments('€', false)] // A currency symbol
    public async Task IsIdentifierPartCharacter_ReturnsWhetherCharacterCanBePartOfIdentifier(char ch, bool expected)
    {
        await Assert.That(UnicodeCharacterUtility.IsIdentifierPartCharacter(ch)).IsEqualTo(expected);
    }

    [Test]
    [Arguments(null, false)]
    [Arguments("", false)]
    [Arguments("_", true)]
    [Arguments("abc_1", true)]
    [Arguments("1abc", false)]
    [Arguments("ab-c", false)]
    public async Task IsValidIdentifier_WithString_ReturnsWhetherStringIsValidIdentifier(string? name, bool expected)
    {
        await Assert.That(UnicodeCharacterUtility.IsValidIdentifier(name)).IsEqualTo(expected);
    }

    [Test]
    [Arguments("", false)]
    [Arguments("_", true)]
    [Arguments("abc_1", true)]
    [Arguments("1abc", false)]
    [Arguments("ab-c", false)]
    public async Task IsValidIdentifier_WithSpan_ReturnsWhetherSpanIsValidIdentifier(string name, bool expected)
    {
        await Assert.That(UnicodeCharacterUtility.IsValidIdentifier(name.AsSpan())).IsEqualTo(expected);
    }
}
