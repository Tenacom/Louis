#### [Louis](README.md 'README')
### [Louis\.Text](Louis.Text.md 'Louis\.Text')

## StringExtensions Class

Provides extension methods for strings\.

```csharp
public static class StringExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → StringExtensions
### Methods

<a name='Louis.Text.StringExtensions.GetLiteralLength(thisstring,Louis.Text.StringLiteralKind)'></a>

## StringExtensions\.GetLiteralLength\(this string, StringLiteralKind\) Method

Gets the length of the representation of a string as a string literal\.

```csharp
public static int GetLiteralLength(this string? @this, Louis.Text.StringLiteralKind literalKind);
```
#### Parameters

<a name='Louis.Text.StringExtensions.GetLiteralLength(thisstring,Louis.Text.StringLiteralKind).this'></a>

`this` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string') on which this method is called\.

<a name='Louis.Text.StringExtensions.GetLiteralLength(thisstring,Louis.Text.StringLiteralKind).literalKind'></a>

`literalKind` [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind')

A [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind') constant specifying
            the kind of string literal that would be built\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The length of the string that would result from calling
            [ToLiteral\(this string, StringLiteralKind\)](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToLiteral(thisstring,Louis.Text.StringLiteralKind) 'Louis\.Text\.StringExtensions\.ToLiteral\(this string, Louis\.Text\.StringLiteralKind\)')on [this](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.GetLiteralLength(thisstring,Louis.Text.StringLiteralKind).this 'Louis\.Text\.StringExtensions\.GetLiteralLength\(this string, Louis\.Text\.StringLiteralKind\)\.this')
            with [literalKind](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.GetLiteralLength(thisstring,Louis.Text.StringLiteralKind).literalKind 'Louis\.Text\.StringExtensions\.GetLiteralLength\(this string, Louis\.Text\.StringLiteralKind\)\.literalKind') as last parameter\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[literalKind](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.GetLiteralLength(thisstring,Louis.Text.StringLiteralKind).literalKind 'Louis\.Text\.StringExtensions\.GetLiteralLength\(this string, Louis\.Text\.StringLiteralKind\)\.literalKind') is neither [Quoted](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Quoted 'Louis\.Text\.StringLiteralKind\.Quoted')
            nor [Verbatim](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Verbatim 'Louis\.Text\.StringLiteralKind\.Verbatim')\.

<a name='Louis.Text.StringExtensions.GetQuotedLiteralLength(thisstring)'></a>

## StringExtensions\.GetQuotedLiteralLength\(this string\) Method

Gets the length of the [quoted literal](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#quoted-string-literals 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/programming\-guide/strings/\#quoted\-string\-literals')
representation of a string\.

```csharp
public static int GetQuotedLiteralLength(this string? @this);
```
#### Parameters

<a name='Louis.Text.StringExtensions.GetQuotedLiteralLength(thisstring).this'></a>

`this` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string') on which this method is called\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The length of the string that would result from calling
            [ToQuotedLiteral\(this string\)](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToQuotedLiteral(thisstring) 'Louis\.Text\.StringExtensions\.ToQuotedLiteral\(this string\)')on [this](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.GetQuotedLiteralLength(thisstring).this 'Louis\.Text\.StringExtensions\.GetQuotedLiteralLength\(this string\)\.this')\.

<a name='Louis.Text.StringExtensions.GetVerbatimLiteralLength(thisstring)'></a>

## StringExtensions\.GetVerbatimLiteralLength\(this string\) Method

Gets the length of the [verbatim literal](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#verbatim-string-literals 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/programming\-guide/strings/\#verbatim\-string\-literals')
representation of a string\.

```csharp
public static int GetVerbatimLiteralLength(this string? @this);
```
#### Parameters

<a name='Louis.Text.StringExtensions.GetVerbatimLiteralLength(thisstring).this'></a>

`this` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string') on which this method is called\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The length of the string that would result from calling
            [ToVerbatimLiteral\(this string\)](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToVerbatimLiteral(thisstring) 'Louis\.Text\.StringExtensions\.ToVerbatimLiteral\(this string\)')on [this](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.GetVerbatimLiteralLength(thisstring).this 'Louis\.Text\.StringExtensions\.GetVerbatimLiteralLength\(this string\)\.this')\.

<a name='Louis.Text.StringExtensions.ToClippedLiteral(thisstring,Louis.Text.StringLiteralKind,int,int,bool)'></a>

## StringExtensions\.ToClippedLiteral\(this string, StringLiteralKind, int, int, bool\) Method

Builds and returns a string representing a given string as a C\# string literal\.
If the string is longer than the sum of [headLength](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedLiteral(thisstring,Louis.Text.StringLiteralKind,int,int,bool).headLength 'Louis\.Text\.StringExtensions\.ToClippedLiteral\(this string, Louis\.Text\.StringLiteralKind, int, int, bool\)\.headLength'), [tailLength](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedLiteral(thisstring,Louis.Text.StringLiteralKind,int,int,bool).tailLength 'Louis\.Text\.StringExtensions\.ToClippedLiteral\(this string, Louis\.Text\.StringLiteralKind, int, int, bool\)\.tailLength'), and the length of an ellipsis
\(1 if [useUnicodeEllipsis](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedLiteral(thisstring,Louis.Text.StringLiteralKind,int,int,bool).useUnicodeEllipsis 'Louis\.Text\.StringExtensions\.ToClippedLiteral\(this string, Louis\.Text\.StringLiteralKind, int, int, bool\)\.useUnicodeEllipsis') is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), 3 otherwise\), then it is clipped, taking only the first
[headLength](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedLiteral(thisstring,Louis.Text.StringLiteralKind,int,int,bool).headLength 'Louis\.Text\.StringExtensions\.ToClippedLiteral\(this string, Louis\.Text\.StringLiteralKind, int, int, bool\)\.headLength') characters, followed by an ellipsis \(either the Unicode character `'\x2026'` \(`…`\), or
three dots `...`\) and the last [tailLength](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedLiteral(thisstring,Louis.Text.StringLiteralKind,int,int,bool).tailLength 'Louis\.Text\.StringExtensions\.ToClippedLiteral\(this string, Louis\.Text\.StringLiteralKind, int, int, bool\)\.tailLength') characters\.

```csharp
public static string ToClippedLiteral(this string? @this, Louis.Text.StringLiteralKind literalKind, int headLength, int tailLength, bool useUnicodeEllipsis=false);
```
#### Parameters

<a name='Louis.Text.StringExtensions.ToClippedLiteral(thisstring,Louis.Text.StringLiteralKind,int,int,bool).this'></a>

`this` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string') on which this method is called\.

<a name='Louis.Text.StringExtensions.ToClippedLiteral(thisstring,Louis.Text.StringLiteralKind,int,int,bool).literalKind'></a>

`literalKind` [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind')

A [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind') constant specifying the kind of string literal
            to build\.

<a name='Louis.Text.StringExtensions.ToClippedLiteral(thisstring,Louis.Text.StringLiteralKind,int,int,bool).headLength'></a>

`headLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave before clipping\.

<a name='Louis.Text.StringExtensions.ToClippedLiteral(thisstring,Louis.Text.StringLiteralKind,int,int,bool).tailLength'></a>

`tailLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave after clipping\.

<a name='Louis.Text.StringExtensions.ToClippedLiteral(thisstring,Louis.Text.StringLiteralKind,int,int,bool).useUnicodeEllipsis'></a>

`useUnicodeEllipsis` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use a single Unicode character Ellipsis \(`'\x2026'`, `…`\) to replace the clipped part;
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use three dots \(`.`\) instead\. Default is [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A newly\-constructed [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string')\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[literalKind](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedLiteral(thisstring,Louis.Text.StringLiteralKind,int,int,bool).literalKind 'Louis\.Text\.StringExtensions\.ToClippedLiteral\(this string, Louis\.Text\.StringLiteralKind, int, int, bool\)\.literalKind') is neither [Quoted](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Quoted 'Louis\.Text\.StringLiteralKind\.Quoted')
            nor [Verbatim](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Verbatim 'Louis\.Text\.StringLiteralKind\.Verbatim')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  

[headLength](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedLiteral(thisstring,Louis.Text.StringLiteralKind,int,int,bool).headLength 'Louis\.Text\.StringExtensions\.ToClippedLiteral\(this string, Louis\.Text\.StringLiteralKind, int, int, bool\)\.headLength') is less than 0.

- or -

[tailLength](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedLiteral(thisstring,Louis.Text.StringLiteralKind,int,int,bool).tailLength 'Louis\.Text\.StringExtensions\.ToClippedLiteral\(this string, Louis\.Text\.StringLiteralKind, int, int, bool\)\.tailLength') is less than 0.

### See Also
- [ToClippedQuotedLiteral\(this string, int, int, bool\)](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedQuotedLiteral(thisstring,int,int,bool) 'Louis\.Text\.StringExtensions\.ToClippedQuotedLiteral\(this string, int, int, bool\)')
- [ToClippedVerbatimLiteral\(this string, int, int, bool\)](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedVerbatimLiteral(thisstring,int,int,bool) 'Louis\.Text\.StringExtensions\.ToClippedVerbatimLiteral\(this string, int, int, bool\)')

<a name='Louis.Text.StringExtensions.ToClippedQuotedLiteral(thisstring,int,int,bool)'></a>

## StringExtensions\.ToClippedQuotedLiteral\(this string, int, int, bool\) Method

Builds and returns a string representing a given string as a C\#
[quoted string literal](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#quoted-string-literals 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/programming\-guide/strings/\#quoted\-string\-literals')\.
If the string is longer than the sum of [headLength](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedQuotedLiteral(thisstring,int,int,bool).headLength 'Louis\.Text\.StringExtensions\.ToClippedQuotedLiteral\(this string, int, int, bool\)\.headLength'), [tailLength](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedQuotedLiteral(thisstring,int,int,bool).tailLength 'Louis\.Text\.StringExtensions\.ToClippedQuotedLiteral\(this string, int, int, bool\)\.tailLength'), and the length of an ellipsis
\(1 if [useUnicodeEllipsis](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedQuotedLiteral(thisstring,int,int,bool).useUnicodeEllipsis 'Louis\.Text\.StringExtensions\.ToClippedQuotedLiteral\(this string, int, int, bool\)\.useUnicodeEllipsis') is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), 3 otherwise\), then it is clipped, taking only the first
[headLength](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedQuotedLiteral(thisstring,int,int,bool).headLength 'Louis\.Text\.StringExtensions\.ToClippedQuotedLiteral\(this string, int, int, bool\)\.headLength') characters, followed by an ellipsis \(either the Unicode character `'\x2026'` \(`…`\), or
three dots `...`\) and the last [tailLength](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedQuotedLiteral(thisstring,int,int,bool).tailLength 'Louis\.Text\.StringExtensions\.ToClippedQuotedLiteral\(this string, int, int, bool\)\.tailLength') characters\.

```csharp
public static string ToClippedQuotedLiteral(this string? @this, int headLength, int tailLength, bool useUnicodeEllipsis=false);
```
#### Parameters

<a name='Louis.Text.StringExtensions.ToClippedQuotedLiteral(thisstring,int,int,bool).this'></a>

`this` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string') on which this method is called\.

<a name='Louis.Text.StringExtensions.ToClippedQuotedLiteral(thisstring,int,int,bool).headLength'></a>

`headLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave before clipping\.

<a name='Louis.Text.StringExtensions.ToClippedQuotedLiteral(thisstring,int,int,bool).tailLength'></a>

`tailLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave after clipping\.

<a name='Louis.Text.StringExtensions.ToClippedQuotedLiteral(thisstring,int,int,bool).useUnicodeEllipsis'></a>

`useUnicodeEllipsis` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use a single Unicode character Ellipsis \(`'\x2026'`, `…`\) to replace the clipped part;
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use three dots \(`.`\) instead\. Default is [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A newly\-constructed [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string')\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  

[headLength](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedQuotedLiteral(thisstring,int,int,bool).headLength 'Louis\.Text\.StringExtensions\.ToClippedQuotedLiteral\(this string, int, int, bool\)\.headLength') is less than 0.

- or -

[tailLength](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedQuotedLiteral(thisstring,int,int,bool).tailLength 'Louis\.Text\.StringExtensions\.ToClippedQuotedLiteral\(this string, int, int, bool\)\.tailLength') is less than 0.

### See Also
- [ToClippedVerbatimLiteral\(this string, int, int, bool\)](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedVerbatimLiteral(thisstring,int,int,bool) 'Louis\.Text\.StringExtensions\.ToClippedVerbatimLiteral\(this string, int, int, bool\)')
- [ToClippedLiteral\(this string, StringLiteralKind, int, int, bool\)](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedLiteral(thisstring,Louis.Text.StringLiteralKind,int,int,bool) 'Louis\.Text\.StringExtensions\.ToClippedLiteral\(this string, Louis\.Text\.StringLiteralKind, int, int, bool\)')

<a name='Louis.Text.StringExtensions.ToClippedVerbatimLiteral(thisstring,int,int,bool)'></a>

## StringExtensions\.ToClippedVerbatimLiteral\(this string, int, int, bool\) Method

Builds and returns a string representing a given string as a C\#
[verbatim string literal](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#verbatim-string-literals 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/programming\-guide/strings/\#verbatim\-string\-literals')\.
If the string is longer than the sum of [headLength](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedVerbatimLiteral(thisstring,int,int,bool).headLength 'Louis\.Text\.StringExtensions\.ToClippedVerbatimLiteral\(this string, int, int, bool\)\.headLength'), [tailLength](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedVerbatimLiteral(thisstring,int,int,bool).tailLength 'Louis\.Text\.StringExtensions\.ToClippedVerbatimLiteral\(this string, int, int, bool\)\.tailLength'), and the length of an ellipsis
\(1 if [useUnicodeEllipsis](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedVerbatimLiteral(thisstring,int,int,bool).useUnicodeEllipsis 'Louis\.Text\.StringExtensions\.ToClippedVerbatimLiteral\(this string, int, int, bool\)\.useUnicodeEllipsis') is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), 3 otherwise\), then it is clipped, taking only the first
[headLength](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedVerbatimLiteral(thisstring,int,int,bool).headLength 'Louis\.Text\.StringExtensions\.ToClippedVerbatimLiteral\(this string, int, int, bool\)\.headLength') characters, followed by an ellipsis \(either the Unicode character `'\x2026'` \(`…`\), or
three dots `...`\) and the last [tailLength](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedVerbatimLiteral(thisstring,int,int,bool).tailLength 'Louis\.Text\.StringExtensions\.ToClippedVerbatimLiteral\(this string, int, int, bool\)\.tailLength') characters\.

```csharp
public static string ToClippedVerbatimLiteral(this string? @this, int headLength, int tailLength, bool useUnicodeEllipsis=false);
```
#### Parameters

<a name='Louis.Text.StringExtensions.ToClippedVerbatimLiteral(thisstring,int,int,bool).this'></a>

`this` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string') on which this method is called\.

<a name='Louis.Text.StringExtensions.ToClippedVerbatimLiteral(thisstring,int,int,bool).headLength'></a>

`headLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave before clipping\.

<a name='Louis.Text.StringExtensions.ToClippedVerbatimLiteral(thisstring,int,int,bool).tailLength'></a>

`tailLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave after clipping\.

<a name='Louis.Text.StringExtensions.ToClippedVerbatimLiteral(thisstring,int,int,bool).useUnicodeEllipsis'></a>

`useUnicodeEllipsis` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use a single Unicode character Ellipsis \(`'\x2026'`, `…`\) to replace the clipped part;
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use three dots \(`.`\) instead\. Default is [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A newly\-constructed [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string')\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  

[headLength](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedVerbatimLiteral(thisstring,int,int,bool).headLength 'Louis\.Text\.StringExtensions\.ToClippedVerbatimLiteral\(this string, int, int, bool\)\.headLength') is less than 0.

- or -

[tailLength](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedVerbatimLiteral(thisstring,int,int,bool).tailLength 'Louis\.Text\.StringExtensions\.ToClippedVerbatimLiteral\(this string, int, int, bool\)\.tailLength') is less than 0.

### See Also
- [ToClippedQuotedLiteral\(this string, int, int, bool\)](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedQuotedLiteral(thisstring,int,int,bool) 'Louis\.Text\.StringExtensions\.ToClippedQuotedLiteral\(this string, int, int, bool\)')
- [ToClippedLiteral\(this string, StringLiteralKind, int, int, bool\)](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToClippedLiteral(thisstring,Louis.Text.StringLiteralKind,int,int,bool) 'Louis\.Text\.StringExtensions\.ToClippedLiteral\(this string, Louis\.Text\.StringLiteralKind, int, int, bool\)')

<a name='Louis.Text.StringExtensions.ToLiteral(thisstring,Louis.Text.StringLiteralKind)'></a>

## StringExtensions\.ToLiteral\(this string, StringLiteralKind\) Method

Builds and returns a string representing a given string as a C\# string literal\.

```csharp
public static string ToLiteral(this string? @this, Louis.Text.StringLiteralKind literalKind);
```
#### Parameters

<a name='Louis.Text.StringExtensions.ToLiteral(thisstring,Louis.Text.StringLiteralKind).this'></a>

`this` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string') on which this method is called\.

<a name='Louis.Text.StringExtensions.ToLiteral(thisstring,Louis.Text.StringLiteralKind).literalKind'></a>

`literalKind` [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind')

A [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind') constant specifying the kind of string literal
            to build\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A newly\-constructed [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string')\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[literalKind](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToLiteral(thisstring,Louis.Text.StringLiteralKind).literalKind 'Louis\.Text\.StringExtensions\.ToLiteral\(this string, Louis\.Text\.StringLiteralKind\)\.literalKind') is neither [Quoted](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Quoted 'Louis\.Text\.StringLiteralKind\.Quoted')
            nor [Verbatim](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Verbatim 'Louis\.Text\.StringLiteralKind\.Verbatim')\.

### See Also
- [ToQuotedLiteral\(this string\)](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToQuotedLiteral(thisstring) 'Louis\.Text\.StringExtensions\.ToQuotedLiteral\(this string\)')
- [ToVerbatimLiteral\(this string\)](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToVerbatimLiteral(thisstring) 'Louis\.Text\.StringExtensions\.ToVerbatimLiteral\(this string\)')

<a name='Louis.Text.StringExtensions.ToQuotedLiteral(thisstring)'></a>

## StringExtensions\.ToQuotedLiteral\(this string\) Method

Builds and returns a string representing a given string as a C\#
[quoted string literal](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#quoted-string-literals 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/programming\-guide/strings/\#quoted\-string\-literals')\.

```csharp
public static string ToQuotedLiteral(this string? @this);
```
#### Parameters

<a name='Louis.Text.StringExtensions.ToQuotedLiteral(thisstring).this'></a>

`this` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string') on which this method is called\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A newly\-constructed [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string')\.

### See Also
- [ToVerbatimLiteral\(this string\)](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToVerbatimLiteral(thisstring) 'Louis\.Text\.StringExtensions\.ToVerbatimLiteral\(this string\)')
- [ToLiteral\(this string, StringLiteralKind\)](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToLiteral(thisstring,Louis.Text.StringLiteralKind) 'Louis\.Text\.StringExtensions\.ToLiteral\(this string, Louis\.Text\.StringLiteralKind\)')

<a name='Louis.Text.StringExtensions.ToVerbatimLiteral(thisstring)'></a>

## StringExtensions\.ToVerbatimLiteral\(this string\) Method

Builds and returns a string representing a given string as a C\#
[verbatim string literal](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#verbatim-string-literals 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/programming\-guide/strings/\#verbatim\-string\-literals')\.

```csharp
public static string ToVerbatimLiteral(this string? @this);
```
#### Parameters

<a name='Louis.Text.StringExtensions.ToVerbatimLiteral(thisstring).this'></a>

`this` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string') on which this method is called\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A newly\-constructed [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string')\.

### See Also
- [ToQuotedLiteral\(this string\)](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToQuotedLiteral(thisstring) 'Louis\.Text\.StringExtensions\.ToQuotedLiteral\(this string\)')
- [ToLiteral\(this string, StringLiteralKind\)](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToLiteral(thisstring,Louis.Text.StringLiteralKind) 'Louis\.Text\.StringExtensions\.ToLiteral\(this string, Louis\.Text\.StringLiteralKind\)')