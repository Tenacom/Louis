#### [Louis](README.md 'README')

## Louis\.Text Namespace

Provides types to work with strings and characters: C\# string literals,
Unicode and UTF\-8 utilities, and conditional interpolated string handlers\.

| Classes | |
| :--- | :--- |
| [CharReadOnlySpanExtensions](Louis.Text.CharReadOnlySpanExtensions.md 'Louis\.Text\.CharReadOnlySpanExtensions') | Provides extension methods for read\-only spans of characters\. |
| [StringBuilderExtensions](Louis.Text.StringBuilderExtensions.md 'Louis\.Text\.StringBuilderExtensions') | Provides extension methods for [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')\. |
| [StringExtensions](Louis.Text.StringExtensions.md 'Louis\.Text\.StringExtensions') | Provides extension methods for strings\. |
| [UnicodeCharacterUtility](Louis.Text.UnicodeCharacterUtility.md 'Louis\.Text\.UnicodeCharacterUtility') | Provides utility methods to classify Unicode characters\. |
| [Utf8Utility](Louis.Text.Utf8Utility.md 'Louis\.Text\.Utf8Utility') | Provides useful methods to work with UTF\-8 encoding\. |

| Structs | |
| :--- | :--- |
| [FalseConditionInterpolatedStringHandler](Louis.Text.FalseConditionInterpolatedStringHandler.md 'Louis\.Text\.FalseConditionInterpolatedStringHandler') |   Provides an interpolated string handler that only performs formatting if a given condition is [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool').  This type is only available on .NET 6.0 and greater.  This type is only meant to be used by compiler-generated code. As such, it performs no parameter validation whatsoever. |
| [TrueConditionInterpolatedStringHandler](Louis.Text.TrueConditionInterpolatedStringHandler.md 'Louis\.Text\.TrueConditionInterpolatedStringHandler') |   Provides an interpolated string handler that only performs formatting if a given condition is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool').  This type is only available on .NET 6.0 and greater.  This type is only meant to be used by compiler-generated code. As such, it performs no parameter validation whatsoever. |

| Enums | |
| :--- | :--- |
| [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind') | Represents the kind of string literal produced by `ToLiteral` methods\. |
