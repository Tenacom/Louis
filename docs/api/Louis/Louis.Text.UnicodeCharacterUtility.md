#### [Louis](README.md 'README')
### [Louis\.Text](Louis.Text.md 'Louis\.Text')

## UnicodeCharacterUtility Class

Provides utility methods to classify Unicode characters\.

```csharp
public static class UnicodeCharacterUtility
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → UnicodeCharacterUtility
### Methods

<a name='Louis.Text.UnicodeCharacterUtility.IsIdentifierPartCharacter(char)'></a>

## UnicodeCharacterUtility\.IsIdentifierPartCharacter\(char\) Method

Checks whether a Unicode character can be a part
of a C\# or Visual Basic identifier\.

```csharp
public static bool IsIdentifierPartCharacter(char ch);
```
#### Parameters

<a name='Louis.Text.UnicodeCharacterUtility.IsIdentifierPartCharacter(char).ch'></a>

`ch` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The character to check\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if [ch](Louis.Text.UnicodeCharacterUtility.md#Louis.Text.UnicodeCharacterUtility.IsIdentifierPartCharacter(char).ch 'Louis\.Text\.UnicodeCharacterUtility\.IsIdentifierPartCharacter\(char\)\.ch') can be a part of an identifier;
            otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='Louis.Text.UnicodeCharacterUtility.IsIdentifierStartCharacter(char)'></a>

## UnicodeCharacterUtility\.IsIdentifierStartCharacter\(char\) Method

Checks whether a Unicode character can be the first character
of a C\# or Visual Basic identifier\.

```csharp
public static bool IsIdentifierStartCharacter(char ch);
```
#### Parameters

<a name='Louis.Text.UnicodeCharacterUtility.IsIdentifierStartCharacter(char).ch'></a>

`ch` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The character to check\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if [ch](Louis.Text.UnicodeCharacterUtility.md#Louis.Text.UnicodeCharacterUtility.IsIdentifierStartCharacter(char).ch 'Louis\.Text\.UnicodeCharacterUtility\.IsIdentifierStartCharacter\(char\)\.ch') can be the first character of an identifier;
            otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='Louis.Text.UnicodeCharacterUtility.IsValidIdentifier(string)'></a>

## UnicodeCharacterUtility\.IsValidIdentifier\(string\) Method

Checks whether a Unicode string is a valid C\# or Visual Basic identifier\.

```csharp
public static bool IsValidIdentifier(string? name);
```
#### Parameters

<a name='Louis.Text.UnicodeCharacterUtility.IsValidIdentifier(string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to check\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if [name](Louis.Text.UnicodeCharacterUtility.md#Louis.Text.UnicodeCharacterUtility.IsValidIdentifier(string).name 'Louis\.Text\.UnicodeCharacterUtility\.IsValidIdentifier\(string\)\.name') is a valid identifier;
            otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='Louis.Text.UnicodeCharacterUtility.IsValidIdentifier(System.ReadOnlySpan_char_)'></a>

## UnicodeCharacterUtility\.IsValidIdentifier\(ReadOnlySpan\<char\>\) Method

Checks whether a span of Unicode characters is a valid C\# or Visual Basic identifier\.

```csharp
public static bool IsValidIdentifier(System.ReadOnlySpan<char> name);
```
#### Parameters

<a name='Louis.Text.UnicodeCharacterUtility.IsValidIdentifier(System.ReadOnlySpan_char_).name'></a>

`name` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The span to check\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if [name](Louis.Text.UnicodeCharacterUtility.md#Louis.Text.UnicodeCharacterUtility.IsValidIdentifier(System.ReadOnlySpan_char_).name 'Louis\.Text\.UnicodeCharacterUtility\.IsValidIdentifier\(System\.ReadOnlySpan\<char\>\)\.name') is a valid identifier;
            otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.