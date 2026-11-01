#### [Louis](README.md 'README')
### [Louis\.Text](Louis.Text.md 'Louis\.Text')

## StringBuilderExtensions Class

Provides extension methods for [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')\.

```csharp
public static class StringBuilderExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → StringBuilderExtensions
### Methods

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int)'></a>

## StringBuilderExtensions\.AppendClippedLiteral\(this StringBuilder, StringLiteralKind, string, int, int\) Method

Appends the specified string, expressed as a C\# string literal, to the end
of this instance\. If the string is longer than the sum of [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int\)\.headLength'),
[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int\)\.tailLength'), and the length of an ellipsis \(three dots `...`\), then it is clipped,
taking only the first [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int\)\.headLength') characters, followed by the ellipsis
and the last [tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int\)\.tailLength') characters\.

```csharp
public static System.Text.StringBuilder AppendClippedLiteral(this System.Text.StringBuilder @this, Louis.Text.StringLiteralKind literalKind, string? str, int headLength, int tailLength);
```
#### Parameters

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int).literalKind'></a>

`literalKind` [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind')

A [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind') constant specifying the kind of string literal
            to append\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int).str'></a>

`str` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to append\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int).headLength'></a>

`headLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave before clipping\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int).tailLength'></a>

`tailLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave after clipping\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to this instance after the append operation has completed\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int).this 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[literalKind](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int).literalKind 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int\)\.literalKind') is neither [Quoted](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Quoted 'Louis\.Text\.StringLiteralKind\.Quoted')
            nor [Verbatim](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Verbatim 'Louis\.Text\.StringLiteralKind\.Verbatim')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  

[headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int\)\.headLength') is less than 0.

- or -

[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int\)\.tailLength') is less than 0.

### Remarks

If [str](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int).str 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int\)\.str') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), the string `null`
            (without surrounding quotes) will be appended to [this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int).this 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int\)\.this').

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int,bool)'></a>

## StringBuilderExtensions\.AppendClippedLiteral\(this StringBuilder, StringLiteralKind, string, int, int, bool\) Method

Appends the specified string, expressed as a C\# string literal, to the end
of this instance\. If the string is longer than the sum of [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int,bool).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int, bool\)\.headLength'),
[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int,bool).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int, bool\)\.tailLength'), and the length of an ellipsis \(1 if [useUnicodeEllipsis](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int,bool).useUnicodeEllipsis 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int, bool\)\.useUnicodeEllipsis')
is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), 3 otherwise\), then it is clipped, taking only the first [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int,bool).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int, bool\)\.headLength')
characters, followed by an ellipsis \(either the Unicode character `'\x2026'` \(`…`\), or three dots `...`\)
and the last [tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int,bool).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int, bool\)\.tailLength') characters\.

```csharp
public static System.Text.StringBuilder AppendClippedLiteral(this System.Text.StringBuilder @this, Louis.Text.StringLiteralKind literalKind, string? str, int headLength, int tailLength, bool useUnicodeEllipsis);
```
#### Parameters

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int,bool).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int,bool).literalKind'></a>

`literalKind` [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind')

A [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind') constant specifying the kind of string literal
            to append\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int,bool).str'></a>

`str` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to append\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int,bool).headLength'></a>

`headLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave before clipping\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int,bool).tailLength'></a>

`tailLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave after clipping\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int,bool).useUnicodeEllipsis'></a>

`useUnicodeEllipsis` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use a single Unicode character Ellipsis \(`'\x2026'`, `…`\) to replace the clipped part;
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use three dots \(`.`\) instead\. Default is [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to this instance after the append operation has completed\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int,bool).this 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int, bool\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[literalKind](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int,bool).literalKind 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int, bool\)\.literalKind') is neither [Quoted](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Quoted 'Louis\.Text\.StringLiteralKind\.Quoted')
            nor [Verbatim](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Verbatim 'Louis\.Text\.StringLiteralKind\.Verbatim')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  

[headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int,bool).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int, bool\)\.headLength') is less than 0.

- or -

[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int,bool).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int, bool\)\.tailLength') is less than 0.

### Remarks

If [str](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int,bool).str 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int, bool\)\.str') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), the string `null`
            (without surrounding quotes) will be appended to [this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string,int,int,bool).this 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string, int, int, bool\)\.this').

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int)'></a>

## StringBuilderExtensions\.AppendClippedLiteral\(this StringBuilder, StringLiteralKind, ReadOnlySpan\<char\>, int, int\) Method

Appends the specified span of characters, expressed as a C\# string literal, to the end
of this instance\. If the span is longer than the sum of [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>, int, int\)\.headLength'),
[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>, int, int\)\.tailLength'), and the length of an ellipsis \(three dots `...`\), then it is clipped,
taking only the first [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>, int, int\)\.headLength') characters, followed by the ellipsis
and the last [tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>, int, int\)\.tailLength') characters\.

```csharp
public static System.Text.StringBuilder AppendClippedLiteral(this System.Text.StringBuilder @this, Louis.Text.StringLiteralKind literalKind, System.ReadOnlySpan<char> chars, int headLength, int tailLength);
```
#### Parameters

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int).literalKind'></a>

`literalKind` [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind')

A [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind') constant specifying the kind of string literal
            to append\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int).chars'></a>

`chars` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The characters to append\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int).headLength'></a>

`headLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave before clipping\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int).tailLength'></a>

`tailLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave after clipping\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to this instance after the append operation has completed\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int).this 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>, int, int\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[literalKind](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int).literalKind 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>, int, int\)\.literalKind') is neither [Quoted](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Quoted 'Louis\.Text\.StringLiteralKind\.Quoted')
            nor [Verbatim](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Verbatim 'Louis\.Text\.StringLiteralKind\.Verbatim')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  

[headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>, int, int\)\.headLength') is less than 0.

- or -

[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>, int, int\)\.tailLength') is less than 0.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int,bool)'></a>

## StringBuilderExtensions\.AppendClippedLiteral\(this StringBuilder, StringLiteralKind, ReadOnlySpan\<char\>, int, int, bool\) Method

Appends the specified span of characters, expressed as a C\# string literal, to the end
of this instance\. If the span is longer than the sum of [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int,bool).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>, int, int, bool\)\.headLength'),
[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int,bool).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>, int, int, bool\)\.tailLength'), and the length of an ellipsis \(1 if [useUnicodeEllipsis](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int,bool).useUnicodeEllipsis 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>, int, int, bool\)\.useUnicodeEllipsis')
is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), 3 otherwise\), then it is clipped, taking only the first [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int,bool).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>, int, int, bool\)\.headLength')
characters, followed by an ellipsis \(either the Unicode character `'\x2026'` \(`…`\), or three dots `...`\)
and the last [tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int,bool).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>, int, int, bool\)\.tailLength') characters\.

```csharp
public static System.Text.StringBuilder AppendClippedLiteral(this System.Text.StringBuilder @this, Louis.Text.StringLiteralKind literalKind, System.ReadOnlySpan<char> chars, int headLength, int tailLength, bool useUnicodeEllipsis);
```
#### Parameters

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int,bool).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int,bool).literalKind'></a>

`literalKind` [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind')

A [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind') constant specifying the kind of string literal
            to append\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int,bool).chars'></a>

`chars` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The characters to append\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int,bool).headLength'></a>

`headLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave before clipping\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int,bool).tailLength'></a>

`tailLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave after clipping\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int,bool).useUnicodeEllipsis'></a>

`useUnicodeEllipsis` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use a single Unicode character Ellipsis \(`'\x2026'`, `…`\) to replace the clipped part;
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use three dots \(`.`\) instead\. Default is [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to this instance after the append operation has completed\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int,bool).this 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>, int, int, bool\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[literalKind](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int,bool).literalKind 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>, int, int, bool\)\.literalKind') is neither [Quoted](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Quoted 'Louis\.Text\.StringLiteralKind\.Quoted')
            nor [Verbatim](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Verbatim 'Louis\.Text\.StringLiteralKind\.Verbatim')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  

[headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int,bool).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>, int, int, bool\)\.headLength') is less than 0.

- or -

[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_,int,int,bool).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>, int, int, bool\)\.tailLength') is less than 0.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int)'></a>

## StringBuilderExtensions\.AppendClippedQuotedLiteral\(this StringBuilder, string, int, int\) Method

Appends the specified string, expressed as a C\# quoted string literal, to the end
of this instance\. If the string is longer than the sum of [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, string, int, int\)\.headLength'),
[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, string, int, int\)\.tailLength'), and the length of an ellipsis \(three dots `...`\), then it is clipped,
taking only the first [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, string, int, int\)\.headLength') characters, followed by the ellipsis
and the last [tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, string, int, int\)\.tailLength') characters\.

```csharp
public static System.Text.StringBuilder AppendClippedQuotedLiteral(this System.Text.StringBuilder @this, string? str, int headLength, int tailLength);
```
#### Parameters

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int).str'></a>

`str` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to append\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int).headLength'></a>

`headLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave before clipping\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int).tailLength'></a>

`tailLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave after clipping\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to this instance after the append operation has completed\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int).this 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, string, int, int\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  

[headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, string, int, int\)\.headLength') is less than 0.

- or -

[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, string, int, int\)\.tailLength') is less than 0.

### Remarks

If [str](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int).str 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, string, int, int\)\.str') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), the string `null`
            (without surrounding quotes) will be appended to [this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int).this 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, string, int, int\)\.this').

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int,bool)'></a>

## StringBuilderExtensions\.AppendClippedQuotedLiteral\(this StringBuilder, string, int, int, bool\) Method

Appends the specified string, expressed as a C\# quoted string literal, to the end
of this instance\. If the string is longer than the sum of [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, string, int, int, bool\)\.headLength'),
[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, string, int, int, bool\)\.tailLength'), and the length of an ellipsis \(1 if [useUnicodeEllipsis](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).useUnicodeEllipsis 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, string, int, int, bool\)\.useUnicodeEllipsis')
is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), 3 otherwise\), then it is clipped, taking only the first [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, string, int, int, bool\)\.headLength')
characters, followed by an ellipsis \(either the Unicode character `'\x2026'` \(`…`\), or three dots `...`\)
and the last [tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, string, int, int, bool\)\.tailLength') characters\.

```csharp
public static System.Text.StringBuilder AppendClippedQuotedLiteral(this System.Text.StringBuilder @this, string? str, int headLength, int tailLength, bool useUnicodeEllipsis);
```
#### Parameters

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).str'></a>

`str` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to append\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).headLength'></a>

`headLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave before clipping\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).tailLength'></a>

`tailLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave after clipping\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).useUnicodeEllipsis'></a>

`useUnicodeEllipsis` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use a single Unicode character Ellipsis \(`'\x2026'`, `…`\) to replace the clipped part;
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use three dots \(`.`\) instead\. Default is [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to this instance after the append operation has completed\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).this 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, string, int, int, bool\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  

[headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, string, int, int, bool\)\.headLength') is less than 0.

- or -

[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, string, int, int, bool\)\.tailLength') is less than 0.

### Remarks

If [str](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).str 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, string, int, int, bool\)\.str') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), the string `null`
            (without surrounding quotes) will be appended to [this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).this 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, string, int, int, bool\)\.this').

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int)'></a>

## StringBuilderExtensions\.AppendClippedQuotedLiteral\(this StringBuilder, ReadOnlySpan\<char\>, int, int\) Method

Appends the specified span of characters, expressed as a C\# quoted string literal, to the end
of this instance\. If the span is longer than the sum of [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int\)\.headLength'),
[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int\)\.tailLength'), and the length of an ellipsis \(three dots `...`1\), then it is clipped,
taking only the first [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int\)\.headLength') characters, followed by the ellipsis
and the last [tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int\)\.tailLength') characters\.

```csharp
public static System.Text.StringBuilder AppendClippedQuotedLiteral(this System.Text.StringBuilder @this, System.ReadOnlySpan<char> chars, int headLength, int tailLength);
```
#### Parameters

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).chars'></a>

`chars` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The characters to append\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).headLength'></a>

`headLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave before clipping\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).tailLength'></a>

`tailLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave after clipping\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to this instance after the append operation has completed\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).this 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  

[headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int\)\.headLength') is less than 0.

- or -

[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int\)\.tailLength') is less than 0.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool)'></a>

## StringBuilderExtensions\.AppendClippedQuotedLiteral\(this StringBuilder, ReadOnlySpan\<char\>, int, int, bool\) Method

Appends the specified span of characters, expressed as a C\# quoted string literal, to the end
of this instance\. If the span is longer than the sum of [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int, bool\)\.headLength'),
[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int, bool\)\.tailLength'), and the length of an ellipsis \(1 if [useUnicodeEllipsis](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).useUnicodeEllipsis 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int, bool\)\.useUnicodeEllipsis')
is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), 3 otherwise\), then it is clipped, taking only the first [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int, bool\)\.headLength')
characters, followed by an ellipsis \(either the Unicode character `'\x2026'` \(`…`\), or three dots `...`\)
and the last [tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int, bool\)\.tailLength') characters\.

```csharp
public static System.Text.StringBuilder AppendClippedQuotedLiteral(this System.Text.StringBuilder @this, System.ReadOnlySpan<char> chars, int headLength, int tailLength, bool useUnicodeEllipsis);
```
#### Parameters

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).chars'></a>

`chars` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The characters to append\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).headLength'></a>

`headLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave before clipping\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).tailLength'></a>

`tailLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave after clipping\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).useUnicodeEllipsis'></a>

`useUnicodeEllipsis` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use a single Unicode character Ellipsis \(`'\x2026'`, `…`\) to replace the clipped part;
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use three dots \(`...`\) instead\. Default is [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to this instance after the append operation has completed\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).this 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int, bool\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  

[headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int, bool\)\.headLength') is less than 0.

- or -

[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedQuotedLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int, bool\)\.tailLength') is less than 0.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int)'></a>

## StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this StringBuilder, string, int, int\) Method

Appends the specified string, expressed as a C\# verbatim string literal, to the end
of this instance\. If the string is longer than the sum of [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, string, int, int\)\.headLength'),
[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, string, int, int\)\.tailLength'), and the length of an ellipsis \(three dots `...`\), then it is clipped,
taking only the first [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, string, int, int\)\.headLength') characters, followed by the ellipsis
and the last [tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, string, int, int\)\.tailLength') characters\.

```csharp
public static System.Text.StringBuilder AppendClippedVerbatimLiteral(this System.Text.StringBuilder @this, string? str, int headLength, int tailLength);
```
#### Parameters

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int).str'></a>

`str` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to append\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int).headLength'></a>

`headLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave before clipping\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int).tailLength'></a>

`tailLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave after clipping\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to this instance after the append operation has completed\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int).this 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, string, int, int\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  

[headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, string, int, int\)\.headLength') is less than 0.

- or -

[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, string, int, int\)\.tailLength') is less than 0.

### Remarks

If [str](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int).str 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, string, int, int\)\.str') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), the string `null`
            (without surrounding quotes) will be appended to [this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int).this 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, string, int, int\)\.this').

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int,bool)'></a>

## StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this StringBuilder, string, int, int, bool\) Method

Appends the specified string, expressed as a C\# verbatim string literal, to the end
of this instance\. If the string is longer than the sum of [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, string, int, int, bool\)\.headLength'),
[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, string, int, int, bool\)\.tailLength'), and the length of an ellipsis \(1 if [useUnicodeEllipsis](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).useUnicodeEllipsis 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, string, int, int, bool\)\.useUnicodeEllipsis')
is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), 3 otherwise\), then it is clipped, taking only the first [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, string, int, int, bool\)\.headLength')
characters, followed by an ellipsis \(either the Unicode character `'\x2026'` \(`…`\), or three dots `...`\)
and the last [tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, string, int, int, bool\)\.tailLength') characters\.

```csharp
public static System.Text.StringBuilder AppendClippedVerbatimLiteral(this System.Text.StringBuilder @this, string? str, int headLength, int tailLength, bool useUnicodeEllipsis);
```
#### Parameters

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).str'></a>

`str` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to append\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).headLength'></a>

`headLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave before clipping\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).tailLength'></a>

`tailLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave after clipping\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).useUnicodeEllipsis'></a>

`useUnicodeEllipsis` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use a single Unicode character Ellipsis \(`'\x2026'`, `…`\) to replace the clipped part;
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use three dots \(`.`\) instead\. Default is [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to this instance after the append operation has completed\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).this 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, string, int, int, bool\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  

[headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, string, int, int, bool\)\.headLength') is less than 0.

- or -

[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, string, int, int, bool\)\.tailLength') is less than 0.

### Remarks

If [str](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).str 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, string, int, int, bool\)\.str') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), the string `null`
            (without surrounding quotes) will be appended to [this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,string,int,int,bool).this 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, string, int, int, bool\)\.this').

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int)'></a>

## StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this StringBuilder, ReadOnlySpan\<char\>, int, int\) Method

Appends the specified span of characters, expressed as a C\# verbatim string literal, to the end
of this instance\. If the span is longer than the sum of [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int\)\.headLength'),
[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int\)\.tailLength'), and the length of an ellipsis \(three dots `...`\), then it is clipped,
taking only the first [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int\)\.headLength') characters, followed by the ellipsis
and the last [tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int\)\.tailLength') characters\.

```csharp
public static System.Text.StringBuilder AppendClippedVerbatimLiteral(this System.Text.StringBuilder @this, System.ReadOnlySpan<char> chars, int headLength, int tailLength);
```
#### Parameters

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).chars'></a>

`chars` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The characters to append\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).headLength'></a>

`headLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave before clipping\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).tailLength'></a>

`tailLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave after clipping\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to this instance after the append operation has completed\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).this 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  

[headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int\)\.headLength') is less than 0.

- or -

[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int\)\.tailLength') is less than 0.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool)'></a>

## StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this StringBuilder, ReadOnlySpan\<char\>, int, int, bool\) Method

Appends the specified span of characters, expressed as a C\# verbatim string literal, to the end
of this instance\. If the span is longer than the sum of [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int, bool\)\.headLength'),
[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int, bool\)\.tailLength'), and the length of an ellipsis \(1 if [useUnicodeEllipsis](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).useUnicodeEllipsis 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int, bool\)\.useUnicodeEllipsis')
is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), 3 otherwise\), then it is clipped, taking only the first [headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int, bool\)\.headLength')
characters, followed by an ellipsis \(either the Unicode character `'\x2026'` \(`…`\), or three dots `...`\)
and the last [tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int, bool\)\.tailLength') characters\.

```csharp
public static System.Text.StringBuilder AppendClippedVerbatimLiteral(this System.Text.StringBuilder @this, System.ReadOnlySpan<char> chars, int headLength, int tailLength, bool useUnicodeEllipsis);
```
#### Parameters

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).chars'></a>

`chars` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The characters to append\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).headLength'></a>

`headLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave before clipping\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).tailLength'></a>

`tailLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of characters to leave after clipping\.

<a name='Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).useUnicodeEllipsis'></a>

`useUnicodeEllipsis` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use a single Unicode character Ellipsis \(`'\x2026'`, `…`\) to replace the clipped part;
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to use three dots \(`.`\) instead\. Default is [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to this instance after the append operation has completed\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).this 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int, bool\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  

[headLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).headLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int, bool\)\.headLength') is less than 0.

- or -

[tailLength](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendClippedVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_,int,int,bool).tailLength 'Louis\.Text\.StringBuilderExtensions\.AppendClippedVerbatimLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>, int, int, bool\)\.tailLength') is less than 0.

<a name='Louis.Text.StringBuilderExtensions.AppendLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string)'></a>

## StringBuilderExtensions\.AppendLiteral\(this StringBuilder, StringLiteralKind, string\) Method

Appends the specified string, expressed as a C\# string literal, to the end of this instance\.

```csharp
public static System.Text.StringBuilder AppendLiteral(this System.Text.StringBuilder @this, Louis.Text.StringLiteralKind literalKind, string? str);
```
#### Parameters

<a name='Louis.Text.StringBuilderExtensions.AppendLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Text.StringBuilderExtensions.AppendLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string).literalKind'></a>

`literalKind` [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind')

A [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind') constant specifying the kind of string literal
            to append\.

<a name='Louis.Text.StringBuilderExtensions.AppendLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string).str'></a>

`str` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to append\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to this instance after the append operation has completed\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string).this 'Louis\.Text\.StringBuilderExtensions\.AppendLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[literalKind](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string).literalKind 'Louis\.Text\.StringBuilderExtensions\.AppendLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string\)\.literalKind') is neither [Quoted](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Quoted 'Louis\.Text\.StringLiteralKind\.Quoted')
            nor [Verbatim](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Verbatim 'Louis\.Text\.StringLiteralKind\.Verbatim')\.

### Remarks

If [str](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string).str 'Louis\.Text\.StringBuilderExtensions\.AppendLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string\)\.str') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), the string `null`
            (without surrounding quotes) will be appended to [this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string).this 'Louis\.Text\.StringBuilderExtensions\.AppendLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string\)\.this').

### See Also
- [AppendQuotedLiteral\(this StringBuilder, string\)](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendQuotedLiteral(thisSystem.Text.StringBuilder,string) 'Louis\.Text\.StringBuilderExtensions\.AppendQuotedLiteral\(this System\.Text\.StringBuilder, string\)')
- [AppendVerbatimLiteral\(this StringBuilder, string\)](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendVerbatimLiteral(thisSystem.Text.StringBuilder,string) 'Louis\.Text\.StringBuilderExtensions\.AppendVerbatimLiteral\(this System\.Text\.StringBuilder, string\)')
- [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind')

<a name='Louis.Text.StringBuilderExtensions.AppendLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_)'></a>

## StringBuilderExtensions\.AppendLiteral\(this StringBuilder, StringLiteralKind, ReadOnlySpan\<char\>\) Method

Appends the specified span of characters, expressed as a C\# string literal, to the end of this instance\.

```csharp
public static System.Text.StringBuilder AppendLiteral(this System.Text.StringBuilder @this, Louis.Text.StringLiteralKind literalKind, System.ReadOnlySpan<char> chars);
```
#### Parameters

<a name='Louis.Text.StringBuilderExtensions.AppendLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Text.StringBuilderExtensions.AppendLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_).literalKind'></a>

`literalKind` [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind')

A [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind') constant specifying the kind of string literal
            to append\.

<a name='Louis.Text.StringBuilderExtensions.AppendLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_).chars'></a>

`chars` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The characters to append\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to this instance after the append operation has completed\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_).this 'Louis\.Text\.StringBuilderExtensions\.AppendLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[literalKind](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_).literalKind 'Louis\.Text\.StringBuilderExtensions\.AppendLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>\)\.literalKind') is neither [Quoted](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Quoted 'Louis\.Text\.StringLiteralKind\.Quoted')
            nor [Verbatim](Louis.Text.StringLiteralKind.md#Louis.Text.StringLiteralKind.Verbatim 'Louis\.Text\.StringLiteralKind\.Verbatim')\.

### See Also
- [AppendQuotedLiteral\(this StringBuilder, ReadOnlySpan&lt;char&gt;\)](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_) 'Louis\.Text\.StringBuilderExtensions\.AppendQuotedLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>\)')
- [AppendVerbatimLiteral\(this StringBuilder, ReadOnlySpan&lt;char&gt;\)](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_) 'Louis\.Text\.StringBuilderExtensions\.AppendVerbatimLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>\)')
- [StringLiteralKind](Louis.Text.StringLiteralKind.md 'Louis\.Text\.StringLiteralKind')

<a name='Louis.Text.StringBuilderExtensions.AppendQuotedLiteral(thisSystem.Text.StringBuilder,string)'></a>

## StringBuilderExtensions\.AppendQuotedLiteral\(this StringBuilder, string\) Method

Appends the specified string, expressed as a C\# quoted string literal, to the end
of this instance\.

```csharp
public static System.Text.StringBuilder AppendQuotedLiteral(this System.Text.StringBuilder @this, string? str);
```
#### Parameters

<a name='Louis.Text.StringBuilderExtensions.AppendQuotedLiteral(thisSystem.Text.StringBuilder,string).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Text.StringBuilderExtensions.AppendQuotedLiteral(thisSystem.Text.StringBuilder,string).str'></a>

`str` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to append\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to this instance after the append operation has completed\.\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendQuotedLiteral(thisSystem.Text.StringBuilder,string).this 'Louis\.Text\.StringBuilderExtensions\.AppendQuotedLiteral\(this System\.Text\.StringBuilder, string\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### Remarks

If [str](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendQuotedLiteral(thisSystem.Text.StringBuilder,string).str 'Louis\.Text\.StringBuilderExtensions\.AppendQuotedLiteral\(this System\.Text\.StringBuilder, string\)\.str') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), the string `null`
            (without surrounding quotes) will be appended to [this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendQuotedLiteral(thisSystem.Text.StringBuilder,string).this 'Louis\.Text\.StringBuilderExtensions\.AppendQuotedLiteral\(this System\.Text\.StringBuilder, string\)\.this').

### See Also
- [AppendVerbatimLiteral\(this StringBuilder, string\)](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendVerbatimLiteral(thisSystem.Text.StringBuilder,string) 'Louis\.Text\.StringBuilderExtensions\.AppendVerbatimLiteral\(this System\.Text\.StringBuilder, string\)')
- [AppendLiteral\(this StringBuilder, StringLiteralKind, string\)](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string) 'Louis\.Text\.StringBuilderExtensions\.AppendLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string\)')

<a name='Louis.Text.StringBuilderExtensions.AppendQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_)'></a>

## StringBuilderExtensions\.AppendQuotedLiteral\(this StringBuilder, ReadOnlySpan\<char\>\) Method

Appends the specified span of characters, expressed as a C\# quoted string literal,
to the end of this instance\.

```csharp
public static System.Text.StringBuilder AppendQuotedLiteral(this System.Text.StringBuilder @this, System.ReadOnlySpan<char> chars);
```
#### Parameters

<a name='Louis.Text.StringBuilderExtensions.AppendQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Text.StringBuilderExtensions.AppendQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_).chars'></a>

`chars` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The characters to append\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to this instance after the append operation has completed\.\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_).this 'Louis\.Text\.StringBuilderExtensions\.AppendQuotedLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### See Also
- [AppendVerbatimLiteral\(this StringBuilder, ReadOnlySpan&lt;char&gt;\)](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_) 'Louis\.Text\.StringBuilderExtensions\.AppendVerbatimLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>\)')
- [AppendLiteral\(this StringBuilder, StringLiteralKind, ReadOnlySpan&lt;char&gt;\)](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_) 'Louis\.Text\.StringBuilderExtensions\.AppendLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>\)')

<a name='Louis.Text.StringBuilderExtensions.AppendResult(thisSystem.Text.StringBuilder,Louis.ReadOnlySpanFunc_char_)'></a>

## StringBuilderExtensions\.AppendResult\(this StringBuilder, ReadOnlySpanFunc\<char\>\) Method

Appends the result of a method to the end of this builder\.

```csharp
public static System.Text.StringBuilder AppendResult(this System.Text.StringBuilder @this, Louis.ReadOnlySpanFunc<char> func);
```
#### Parameters

<a name='Louis.Text.StringBuilderExtensions.AppendResult(thisSystem.Text.StringBuilder,Louis.ReadOnlySpanFunc_char_).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Text.StringBuilderExtensions.AppendResult(thisSystem.Text.StringBuilder,Louis.ReadOnlySpanFunc_char_).func'></a>

`func` [Louis\.ReadOnlySpanFunc&lt;](Louis.ReadOnlySpanFunc_T_().md 'Louis\.ReadOnlySpanFunc\<T\>\(\)')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](Louis.ReadOnlySpanFunc_T_().md 'Louis\.ReadOnlySpanFunc\<T\>\(\)')

The method to call\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to [this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendResult(thisSystem.Text.StringBuilder,Louis.ReadOnlySpanFunc_char_).this 'Louis\.Text\.StringBuilderExtensions\.AppendResult\(this System\.Text\.StringBuilder, Louis\.ReadOnlySpanFunc\<char\>\)\.this') after the operation is completed\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendResult(thisSystem.Text.StringBuilder,Louis.ReadOnlySpanFunc_char_).this 'Louis\.Text\.StringBuilderExtensions\.AppendResult\(this System\.Text\.StringBuilder, Louis\.ReadOnlySpanFunc\<char\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[func](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendResult(thisSystem.Text.StringBuilder,Louis.ReadOnlySpanFunc_char_).func 'Louis\.Text\.StringBuilderExtensions\.AppendResult\(this System\.Text\.StringBuilder, Louis\.ReadOnlySpanFunc\<char\>\)\.func') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Text.StringBuilderExtensions.AppendResult(thisSystem.Text.StringBuilder,System.Func_string_)'></a>

## StringBuilderExtensions\.AppendResult\(this StringBuilder, Func\<string\>\) Method

Appends the result of a method to the end of this builder\.

```csharp
public static System.Text.StringBuilder AppendResult(this System.Text.StringBuilder @this, System.Func<string?> provider);
```
#### Parameters

<a name='Louis.Text.StringBuilderExtensions.AppendResult(thisSystem.Text.StringBuilder,System.Func_string_).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Text.StringBuilderExtensions.AppendResult(thisSystem.Text.StringBuilder,System.Func_string_).provider'></a>

`provider` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')

The method to call\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to [this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendResult(thisSystem.Text.StringBuilder,System.Func_string_).this 'Louis\.Text\.StringBuilderExtensions\.AppendResult\(this System\.Text\.StringBuilder, System\.Func\<string\>\)\.this') after the operation is completed\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendResult(thisSystem.Text.StringBuilder,System.Func_string_).this 'Louis\.Text\.StringBuilderExtensions\.AppendResult\(this System\.Text\.StringBuilder, System\.Func\<string\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[provider](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendResult(thisSystem.Text.StringBuilder,System.Func_string_).provider 'Louis\.Text\.StringBuilderExtensions\.AppendResult\(this System\.Text\.StringBuilder, System\.Func\<string\>\)\.provider') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Text.StringBuilderExtensions.AppendVerbatimLiteral(thisSystem.Text.StringBuilder,string)'></a>

## StringBuilderExtensions\.AppendVerbatimLiteral\(this StringBuilder, string\) Method

Appends the specified string, expressed as a C\# verbatim string literal, to the end
of this instance\.

```csharp
public static System.Text.StringBuilder AppendVerbatimLiteral(this System.Text.StringBuilder @this, string? str);
```
#### Parameters

<a name='Louis.Text.StringBuilderExtensions.AppendVerbatimLiteral(thisSystem.Text.StringBuilder,string).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Text.StringBuilderExtensions.AppendVerbatimLiteral(thisSystem.Text.StringBuilder,string).str'></a>

`str` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to append\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to this instance after the append operation has completed\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendVerbatimLiteral(thisSystem.Text.StringBuilder,string).this 'Louis\.Text\.StringBuilderExtensions\.AppendVerbatimLiteral\(this System\.Text\.StringBuilder, string\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### Remarks

If [str](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendVerbatimLiteral(thisSystem.Text.StringBuilder,string).str 'Louis\.Text\.StringBuilderExtensions\.AppendVerbatimLiteral\(this System\.Text\.StringBuilder, string\)\.str') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), the string `null`
            (without surrounding quotes) will be appended to [this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendVerbatimLiteral(thisSystem.Text.StringBuilder,string).this 'Louis\.Text\.StringBuilderExtensions\.AppendVerbatimLiteral\(this System\.Text\.StringBuilder, string\)\.this').

### See Also
- [AppendQuotedLiteral\(this StringBuilder, string\)](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendQuotedLiteral(thisSystem.Text.StringBuilder,string) 'Louis\.Text\.StringBuilderExtensions\.AppendQuotedLiteral\(this System\.Text\.StringBuilder, string\)')
- [AppendLiteral\(this StringBuilder, StringLiteralKind, string\)](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,string) 'Louis\.Text\.StringBuilderExtensions\.AppendLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, string\)')

<a name='Louis.Text.StringBuilderExtensions.AppendVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_)'></a>

## StringBuilderExtensions\.AppendVerbatimLiteral\(this StringBuilder, ReadOnlySpan\<char\>\) Method

Appends the specified span of characters, expressed as a C\# verbatim string literal,
to the end of this instance\.

```csharp
public static System.Text.StringBuilder AppendVerbatimLiteral(this System.Text.StringBuilder @this, System.ReadOnlySpan<char> chars);
```
#### Parameters

<a name='Louis.Text.StringBuilderExtensions.AppendVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Text.StringBuilderExtensions.AppendVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_).chars'></a>

`chars` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The characters to append\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to this instance after the append operation has completed\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendVerbatimLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_).this 'Louis\.Text\.StringBuilderExtensions\.AppendVerbatimLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### See Also
- [AppendQuotedLiteral\(this StringBuilder, ReadOnlySpan&lt;char&gt;\)](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendQuotedLiteral(thisSystem.Text.StringBuilder,System.ReadOnlySpan_char_) 'Louis\.Text\.StringBuilderExtensions\.AppendQuotedLiteral\(this System\.Text\.StringBuilder, System\.ReadOnlySpan\<char\>\)')
- [AppendLiteral\(this StringBuilder, StringLiteralKind, ReadOnlySpan&lt;char&gt;\)](Louis.Text.StringBuilderExtensions.md#Louis.Text.StringBuilderExtensions.AppendLiteral(thisSystem.Text.StringBuilder,Louis.Text.StringLiteralKind,System.ReadOnlySpan_char_) 'Louis\.Text\.StringBuilderExtensions\.AppendLiteral\(this System\.Text\.StringBuilder, Louis\.Text\.StringLiteralKind, System\.ReadOnlySpan\<char\>\)')