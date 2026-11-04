#### [Louis](README.md 'README')
### [Louis\.Text](Louis.Text.md 'Louis\.Text')

## CharReadOnlySpanExtensions Class

Provides extension methods for read\-only spans of characters\.

```csharp
public static class CharReadOnlySpanExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CharReadOnlySpanExtensions
### Methods

<a name='Louis.Text.CharReadOnlySpanExtensions.GetLiteralLength(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind)'></a>

## CharReadOnlySpanExtensions\.GetLiteralLength\(this ReadOnlySpan\<char\>, StringLiteralKind\) Method

Gets the length of the representation of a span of characters as a string literal\.

```csharp
public static int GetLiteralLength(this System.ReadOnlySpan<char> @this, Louis.Text.StringLiteralKind literalKind);
```
#### Parameters

<a name='Louis.Text.CharReadOnlySpanExtensions.GetLiteralLength(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind).this'></a>

`this` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The [ReadOnlySpan&lt;char&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')
            on which this method is called\.

<a name='Louis.Text.CharReadOnlySpanExtensions.GetLiteralLength(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind).literalKind'></a>

`literalKind` [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind')

A [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind') constant specifying
            the kind of string literal that would be built\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The length of the string that would result from calling
            [ToLiteral\(this ReadOnlySpan&lt;char&gt;, StringLiteralKind\)](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind) 'Louis\.Text\.CharReadOnlySpanExtensions\.ToLiteral\(this System\.ReadOnlySpan\<char\>, Louis\.Text\.StringLiteralKind\)') on [this](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.GetLiteralLength(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind).this 'Louis\.Text\.CharReadOnlySpanExtensions\.GetLiteralLength\(this System\.ReadOnlySpan\<char\>, Louis\.Text\.StringLiteralKind\)\.this')
            with [literalKind](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.GetLiteralLength(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind).literalKind 'Louis\.Text\.CharReadOnlySpanExtensions\.GetLiteralLength\(this System\.ReadOnlySpan\<char\>, Louis\.Text\.StringLiteralKind\)\.literalKind') as last parameter\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[literalKind](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.GetLiteralLength(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind).literalKind 'Louis\.Text\.CharReadOnlySpanExtensions\.GetLiteralLength\(this System\.ReadOnlySpan\<char\>, Louis\.Text\.StringLiteralKind\)\.literalKind') is neither [Quoted](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Quoted 'Louis\.Text\.StringLiteralKind\.Quoted')
            nor [Verbatim](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Verbatim 'Louis\.Text\.StringLiteralKind\.Verbatim')\.

<a name='Louis.Text.CharReadOnlySpanExtensions.GetQuotedLiteralLength(thisSystem.ReadOnlySpan_char_)'></a>

## CharReadOnlySpanExtensions\.GetQuotedLiteralLength\(this ReadOnlySpan\<char\>\) Method

Gets the length of the [quoted literal](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#quoted-string-literals 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/programming\-guide/strings/\#quoted\-string\-literals')
representation of a span of characters\.

```csharp
public static int GetQuotedLiteralLength(this System.ReadOnlySpan<char> @this);
```
#### Parameters

<a name='Louis.Text.CharReadOnlySpanExtensions.GetQuotedLiteralLength(thisSystem.ReadOnlySpan_char_).this'></a>

`this` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The [ReadOnlySpan&lt;char&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')
            on which this method is called\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The length of the string that would result from calling
            [ToQuotedLiteral\(this ReadOnlySpan&lt;char&gt;\)](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToQuotedLiteral(thisSystem.ReadOnlySpan_char_) 'Louis\.Text\.CharReadOnlySpanExtensions\.ToQuotedLiteral\(this System\.ReadOnlySpan\<char\>\)') on [this](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.GetQuotedLiteralLength(thisSystem.ReadOnlySpan_char_).this 'Louis\.Text\.CharReadOnlySpanExtensions\.GetQuotedLiteralLength\(this System\.ReadOnlySpan\<char\>\)\.this')\.

<a name='Louis.Text.CharReadOnlySpanExtensions.GetVerbatimLiteralLength(thisSystem.ReadOnlySpan_char_)'></a>

## CharReadOnlySpanExtensions\.GetVerbatimLiteralLength\(this ReadOnlySpan\<char\>\) Method

Gets the length of the [verbatim literal](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#verbatim-string-literals 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/programming\-guide/strings/\#verbatim\-string\-literals')
representation of a span of characters\.

```csharp
public static int GetVerbatimLiteralLength(this System.ReadOnlySpan<char> @this);
```
#### Parameters

<a name='Louis.Text.CharReadOnlySpanExtensions.GetVerbatimLiteralLength(thisSystem.ReadOnlySpan_char_).this'></a>

`this` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The [ReadOnlySpan&lt;char&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')
            on which this method is called\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The length of the string that would result from calling
            [ToVerbatimLiteral\(this ReadOnlySpan&lt;char&gt;\)](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToVerbatimLiteral(thisSystem.ReadOnlySpan_char_) 'Louis\.Text\.CharReadOnlySpanExtensions\.ToVerbatimLiteral\(this System\.ReadOnlySpan\<char\>\)') on [this](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.GetVerbatimLiteralLength(thisSystem.ReadOnlySpan_char_).this 'Louis\.Text\.CharReadOnlySpanExtensions\.GetVerbatimLiteralLength\(this System\.ReadOnlySpan\<char\>\)\.this')\.

<a name='Louis.Text.CharReadOnlySpanExtensions.ToClippedLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind,int,int,bool)'></a>

## CharReadOnlySpanExtensions\.ToClippedLiteral\(this ReadOnlySpan\<char\>, StringLiteralKind, int, int, bool\) Method

Builds and returns a string representing a given span of characters as a C\# string literal\.
If the string is longer than the sum of [headLength](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind,int,int,bool).headLength 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedLiteral\(this System\.ReadOnlySpan\<char\>, Louis\.Text\.StringLiteralKind, int, int, bool\)\.headLength'), [tailLength](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind,int,int,bool).tailLength 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedLiteral\(this System\.ReadOnlySpan\<char\>, Louis\.Text\.StringLiteralKind, int, int, bool\)\.tailLength'), and the length of an ellipsis
\(1 if [useUnicodeEllipsis](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind,int,int,bool).useUnicodeEllipsis 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedLiteral\(this System\.ReadOnlySpan\<char\>, Louis\.Text\.StringLiteralKind, int, int, bool\)\.useUnicodeEllipsis') is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), 3 otherwise\), then it is clipped, taking only the first
[headLength](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind,int,int,bool).headLength 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedLiteral\(this System\.ReadOnlySpan\<char\>, Louis\.Text\.StringLiteralKind, int, int, bool\)\.headLength') characters, followed by an ellipsis \(either the Unicode character `'\x2026'` \(`…`\), or
three dots `...`\) and the last [tailLength](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind,int,int,bool).tailLength 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedLiteral\(this System\.ReadOnlySpan\<char\>, Louis\.Text\.StringLiteralKind, int, int, bool\)\.tailLength') characters\.

```csharp
public static string ToClippedLiteral(this System.ReadOnlySpan<char> @this, Louis.Text.StringLiteralKind literalKind, int headLength, int tailLength, bool useUnicodeEllipsis=false);
```
#### Parameters

<a name='Louis.Text.CharReadOnlySpanExtensions.ToClippedLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind,int,int,bool).this'></a>

`this` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The [ReadOnlySpan&lt;char&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')
            on which this method is called\.

<a name='Louis.Text.CharReadOnlySpanExtensions.ToClippedLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind,int,int,bool).literalKind'></a>

`literalKind` [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind')

A [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind') constant specifying the kind of string literal
            to build\.

<a name='Louis.Text.CharReadOnlySpanExtensions.ToClippedLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind,int,int,bool).headLength'></a>

`headLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave before clipping\.

<a name='Louis.Text.CharReadOnlySpanExtensions.ToClippedLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind,int,int,bool).tailLength'></a>

`tailLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave after clipping\.

<a name='Louis.Text.CharReadOnlySpanExtensions.ToClippedLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind,int,int,bool).useUnicodeEllipsis'></a>

`useUnicodeEllipsis` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use a single Unicode character Ellipsis \(`'\x2026'`, `…`\) to replace the clipped part;
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use three dots \(`...`\) instead\. Default is [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A newly\-constructed [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string')\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[literalKind](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind,int,int,bool).literalKind 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedLiteral\(this System\.ReadOnlySpan\<char\>, Louis\.Text\.StringLiteralKind, int, int, bool\)\.literalKind') is neither [Quoted](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Quoted 'Louis\.Text\.StringLiteralKind\.Quoted')
            nor [Verbatim](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Verbatim 'Louis\.Text\.StringLiteralKind\.Verbatim')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  

[headLength](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind,int,int,bool).headLength 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedLiteral\(this System\.ReadOnlySpan\<char\>, Louis\.Text\.StringLiteralKind, int, int, bool\)\.headLength') is less than 0.

- or -

[tailLength](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind,int,int,bool).tailLength 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedLiteral\(this System\.ReadOnlySpan\<char\>, Louis\.Text\.StringLiteralKind, int, int, bool\)\.tailLength') is less than 0.

### See Also
- [ToClippedQuotedLiteral\(this ReadOnlySpan&lt;char&gt;, int, int, bool\)](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedQuotedLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool) 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedQuotedLiteral\(this System\.ReadOnlySpan\<char\>, int, int, bool\)')
- [ToClippedVerbatimLiteral\(this ReadOnlySpan&lt;char&gt;, int, int, bool\)](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedVerbatimLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool) 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedVerbatimLiteral\(this System\.ReadOnlySpan\<char\>, int, int, bool\)')

<a name='Louis.Text.CharReadOnlySpanExtensions.ToClippedQuotedLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool)'></a>

## CharReadOnlySpanExtensions\.ToClippedQuotedLiteral\(this ReadOnlySpan\<char\>, int, int, bool\) Method

Builds and returns a string representing a given span of characters as a C\#
[quoted string literal](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#quoted-string-literals 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/programming\-guide/strings/\#quoted\-string\-literals')\.
If the string is longer than the sum of [headLength](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedQuotedLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).headLength 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedQuotedLiteral\(this System\.ReadOnlySpan\<char\>, int, int, bool\)\.headLength'), [tailLength](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedQuotedLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).tailLength 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedQuotedLiteral\(this System\.ReadOnlySpan\<char\>, int, int, bool\)\.tailLength'), and the length of an ellipsis
\(1 if [useUnicodeEllipsis](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedQuotedLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).useUnicodeEllipsis 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedQuotedLiteral\(this System\.ReadOnlySpan\<char\>, int, int, bool\)\.useUnicodeEllipsis') is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), 3 otherwise\), then it is clipped, taking only the first
[headLength](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedQuotedLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).headLength 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedQuotedLiteral\(this System\.ReadOnlySpan\<char\>, int, int, bool\)\.headLength') characters, followed by an ellipsis \(either the Unicode character `'\x2026'` \(`…`\), or
three dots `...`\) and the last [tailLength](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedQuotedLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).tailLength 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedQuotedLiteral\(this System\.ReadOnlySpan\<char\>, int, int, bool\)\.tailLength') characters\.

```csharp
public static string ToClippedQuotedLiteral(this System.ReadOnlySpan<char> @this, int headLength, int tailLength, bool useUnicodeEllipsis=false);
```
#### Parameters

<a name='Louis.Text.CharReadOnlySpanExtensions.ToClippedQuotedLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).this'></a>

`this` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The [ReadOnlySpan&lt;char&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')
            on which this method is called\.

<a name='Louis.Text.CharReadOnlySpanExtensions.ToClippedQuotedLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).headLength'></a>

`headLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave before clipping\.

<a name='Louis.Text.CharReadOnlySpanExtensions.ToClippedQuotedLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).tailLength'></a>

`tailLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave after clipping\.

<a name='Louis.Text.CharReadOnlySpanExtensions.ToClippedQuotedLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).useUnicodeEllipsis'></a>

`useUnicodeEllipsis` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use a single Unicode character Ellipsis \(`'\x2026'`, `…`\) to replace the clipped part;
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use three dots \(`...`\) instead\. Default is [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A newly\-constructed [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string')\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  

[headLength](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedQuotedLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).headLength 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedQuotedLiteral\(this System\.ReadOnlySpan\<char\>, int, int, bool\)\.headLength') is less than 0.

- or -

[tailLength](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedQuotedLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).tailLength 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedQuotedLiteral\(this System\.ReadOnlySpan\<char\>, int, int, bool\)\.tailLength') is less than 0.

### See Also
- [ToClippedVerbatimLiteral\(this ReadOnlySpan&lt;char&gt;, int, int, bool\)](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedVerbatimLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool) 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedVerbatimLiteral\(this System\.ReadOnlySpan\<char\>, int, int, bool\)')
- [ToClippedLiteral\(this ReadOnlySpan&lt;char&gt;, StringLiteralKind, int, int, bool\)](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind,int,int,bool) 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedLiteral\(this System\.ReadOnlySpan\<char\>, Louis\.Text\.StringLiteralKind, int, int, bool\)')

<a name='Louis.Text.CharReadOnlySpanExtensions.ToClippedVerbatimLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool)'></a>

## CharReadOnlySpanExtensions\.ToClippedVerbatimLiteral\(this ReadOnlySpan\<char\>, int, int, bool\) Method

Builds and returns a string representing a given span of characters as a C\#
[verbatim string literal](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#verbatim-string-literals 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/programming\-guide/strings/\#verbatim\-string\-literals')\.
If the string is longer than the sum of [headLength](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedVerbatimLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).headLength 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedVerbatimLiteral\(this System\.ReadOnlySpan\<char\>, int, int, bool\)\.headLength'), [tailLength](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedVerbatimLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).tailLength 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedVerbatimLiteral\(this System\.ReadOnlySpan\<char\>, int, int, bool\)\.tailLength'), and the length of an ellipsis
\(1 if [useUnicodeEllipsis](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedVerbatimLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).useUnicodeEllipsis 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedVerbatimLiteral\(this System\.ReadOnlySpan\<char\>, int, int, bool\)\.useUnicodeEllipsis') is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), 3 otherwise\), then it is clipped, taking only the first
[headLength](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedVerbatimLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).headLength 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedVerbatimLiteral\(this System\.ReadOnlySpan\<char\>, int, int, bool\)\.headLength') characters, followed by an ellipsis \(either the Unicode character `'\x2026'` \(`…`\), or
three dots `...`\) and the last [tailLength](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedVerbatimLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).tailLength 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedVerbatimLiteral\(this System\.ReadOnlySpan\<char\>, int, int, bool\)\.tailLength') characters\.

```csharp
public static string ToClippedVerbatimLiteral(this System.ReadOnlySpan<char> @this, int headLength, int tailLength, bool useUnicodeEllipsis=false);
```
#### Parameters

<a name='Louis.Text.CharReadOnlySpanExtensions.ToClippedVerbatimLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).this'></a>

`this` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The [ReadOnlySpan&lt;char&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')
            on which this method is called\.

<a name='Louis.Text.CharReadOnlySpanExtensions.ToClippedVerbatimLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).headLength'></a>

`headLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave before clipping\.

<a name='Louis.Text.CharReadOnlySpanExtensions.ToClippedVerbatimLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).tailLength'></a>

`tailLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave after clipping\.

<a name='Louis.Text.CharReadOnlySpanExtensions.ToClippedVerbatimLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).useUnicodeEllipsis'></a>

`useUnicodeEllipsis` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use a single Unicode character Ellipsis \(`'\x2026'`, `…`\) to replace the clipped part;
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use three dots \(`...`\) instead\. Default is [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A newly\-constructed [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string')\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  

[headLength](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedVerbatimLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).headLength 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedVerbatimLiteral\(this System\.ReadOnlySpan\<char\>, int, int, bool\)\.headLength') is less than 0.

- or -

[tailLength](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedVerbatimLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool).tailLength 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedVerbatimLiteral\(this System\.ReadOnlySpan\<char\>, int, int, bool\)\.tailLength') is less than 0.

### See Also
- [ToClippedQuotedLiteral\(this ReadOnlySpan&lt;char&gt;, int, int, bool\)](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedQuotedLiteral(thisSystem.ReadOnlySpan_char_,int,int,bool) 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedQuotedLiteral\(this System\.ReadOnlySpan\<char\>, int, int, bool\)')
- [ToClippedLiteral\(this ReadOnlySpan&lt;char&gt;, StringLiteralKind, int, int, bool\)](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToClippedLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind,int,int,bool) 'Louis\.Text\.CharReadOnlySpanExtensions\.ToClippedLiteral\(this System\.ReadOnlySpan\<char\>, Louis\.Text\.StringLiteralKind, int, int, bool\)')

<a name='Louis.Text.CharReadOnlySpanExtensions.ToLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind)'></a>

## CharReadOnlySpanExtensions\.ToLiteral\(this ReadOnlySpan\<char\>, StringLiteralKind\) Method

Builds and returns a string representing a given span of characters as a C\# string literal\.

```csharp
public static string ToLiteral(this System.ReadOnlySpan<char> @this, Louis.Text.StringLiteralKind literalKind);
```
#### Parameters

<a name='Louis.Text.CharReadOnlySpanExtensions.ToLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind).this'></a>

`this` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The [ReadOnlySpan&lt;char&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')
            on which this method is called\.

<a name='Louis.Text.CharReadOnlySpanExtensions.ToLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind).literalKind'></a>

`literalKind` [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind')

A [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind') constant specifying the kind of string literal
            to build\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A newly\-constructed [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string')\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[literalKind](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind).literalKind 'Louis\.Text\.CharReadOnlySpanExtensions\.ToLiteral\(this System\.ReadOnlySpan\<char\>, Louis\.Text\.StringLiteralKind\)\.literalKind') is neither [Quoted](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Quoted 'Louis\.Text\.StringLiteralKind\.Quoted')
            nor [Verbatim](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Verbatim 'Louis\.Text\.StringLiteralKind\.Verbatim')\.

### See Also
- [ToQuotedLiteral\(this ReadOnlySpan&lt;char&gt;\)](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToQuotedLiteral(thisSystem.ReadOnlySpan_char_) 'Louis\.Text\.CharReadOnlySpanExtensions\.ToQuotedLiteral\(this System\.ReadOnlySpan\<char\>\)')
- [ToVerbatimLiteral\(this ReadOnlySpan&lt;char&gt;\)](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToVerbatimLiteral(thisSystem.ReadOnlySpan_char_) 'Louis\.Text\.CharReadOnlySpanExtensions\.ToVerbatimLiteral\(this System\.ReadOnlySpan\<char\>\)')

<a name='Louis.Text.CharReadOnlySpanExtensions.ToQuotedLiteral(thisSystem.ReadOnlySpan_char_)'></a>

## CharReadOnlySpanExtensions\.ToQuotedLiteral\(this ReadOnlySpan\<char\>\) Method

Builds and returns a string representing a given span of characters as a C\#
[quoted string literal](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#quoted-string-literals 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/programming\-guide/strings/\#quoted\-string\-literals')\.

```csharp
public static string ToQuotedLiteral(this System.ReadOnlySpan<char> @this);
```
#### Parameters

<a name='Louis.Text.CharReadOnlySpanExtensions.ToQuotedLiteral(thisSystem.ReadOnlySpan_char_).this'></a>

`this` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The [ReadOnlySpan&lt;char&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')
            on which this method is called\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A newly\-constructed [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string')\.

### See Also
- [ToVerbatimLiteral\(this ReadOnlySpan&lt;char&gt;\)](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToVerbatimLiteral(thisSystem.ReadOnlySpan_char_) 'Louis\.Text\.CharReadOnlySpanExtensions\.ToVerbatimLiteral\(this System\.ReadOnlySpan\<char\>\)')
- [ToLiteral\(this ReadOnlySpan&lt;char&gt;, StringLiteralKind\)](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind) 'Louis\.Text\.CharReadOnlySpanExtensions\.ToLiteral\(this System\.ReadOnlySpan\<char\>, Louis\.Text\.StringLiteralKind\)')

<a name='Louis.Text.CharReadOnlySpanExtensions.ToVerbatimLiteral(thisSystem.ReadOnlySpan_char_)'></a>

## CharReadOnlySpanExtensions\.ToVerbatimLiteral\(this ReadOnlySpan\<char\>\) Method

Builds and returns a string representing a given span of characters as a C\#
[verbatim string literal](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#verbatim-string-literals 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/programming\-guide/strings/\#verbatim\-string\-literals')\.

```csharp
public static string ToVerbatimLiteral(this System.ReadOnlySpan<char> @this);
```
#### Parameters

<a name='Louis.Text.CharReadOnlySpanExtensions.ToVerbatimLiteral(thisSystem.ReadOnlySpan_char_).this'></a>

`this` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The [ReadOnlySpan&lt;char&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')
            on which this method is called\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A newly\-constructed [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string')\.

### See Also
- [ToQuotedLiteral\(this ReadOnlySpan&lt;char&gt;\)](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToQuotedLiteral(thisSystem.ReadOnlySpan_char_) 'Louis\.Text\.CharReadOnlySpanExtensions\.ToQuotedLiteral\(this System\.ReadOnlySpan\<char\>\)')
- [ToLiteral\(this ReadOnlySpan&lt;char&gt;, StringLiteralKind\)](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind) 'Louis\.Text\.CharReadOnlySpanExtensions\.ToLiteral\(this System\.ReadOnlySpan\<char\>, Louis\.Text\.StringLiteralKind\)')