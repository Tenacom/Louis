#### [Louis](README.md 'README')
### [Louis\.Text](Louis.Text.md 'Louis\.Text')

## Utf8Utility Class

Provides useful methods to work with UTF\-8 encoding\.

```csharp
public static class Utf8Utility
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Utf8Utility
### Fields

<a name='Louis.Text.Utf8Utility.Utf8NoBomEncoding'></a>

## Utf8Utility\.Utf8NoBomEncoding Field


An [System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding') that can be used to encode UTF-8 text without a byte order mark (BOM).

```csharp
public static readonly Encoding Utf8NoBomEncoding;
```

#### Field Value
[System\.Text\.Encoding](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding 'System\.Text\.Encoding')
### Methods

<a name='Louis.Text.Utf8Utility.GetMaxCharsInBytes(string,int)'></a>

## Utf8Utility\.GetMaxCharsInBytes\(string, int\) Method

Computes the maximum number of characters from a given string
that will fit in a given number of bytes when encoded using UTF\-8\.

```csharp
public static int GetMaxCharsInBytes(string str, int maxBytes);
```
#### Parameters

<a name='Louis.Text.Utf8Utility.GetMaxCharsInBytes(string,int).str'></a>

`str` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to encode\.

<a name='Louis.Text.Utf8Utility.GetMaxCharsInBytes(string,int).maxBytes'></a>

`maxBytes` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of bytes available for the encoded text\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The maximum number of characters, starting from the beginning of [str](Louis.Text.Utf8Utility.md#Louis.Text.Utf8Utility.GetMaxCharsInBytes(string,int).str 'Louis\.Text\.Utf8Utility\.GetMaxCharsInBytes\(string, int\)\.str'),
            whose UTF\-8 representation will fit in a maximum of [maxBytes](Louis.Text.Utf8Utility.md#Louis.Text.Utf8Utility.GetMaxCharsInBytes(string,int).maxBytes 'Louis\.Text\.Utf8Utility\.GetMaxCharsInBytes\(string, int\)\.maxBytes') bytes\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[str](Louis.Text.Utf8Utility.md#Louis.Text.Utf8Utility.GetMaxCharsInBytes(string,int).str 'Louis\.Text\.Utf8Utility\.GetMaxCharsInBytes\(string, int\)\.str') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[maxBytes](Louis.Text.Utf8Utility.md#Louis.Text.Utf8Utility.GetMaxCharsInBytes(string,int).maxBytes 'Louis\.Text\.Utf8Utility\.GetMaxCharsInBytes\(string, int\)\.maxBytes') is a negative number\.

### Remarks

This method does not use any functionality from the `System.Text` namespace;
            its computations are based solely on the UTF-8 standard.

This method assumes that any unrepresentable character will be encoded as the Unicode replacement character
            (code point `0xFFFD`). This is the default for both [System\.Text\.Encoding\.UTF8](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.utf8 'System\.Text\.Encoding\.UTF8')
            and [Utf8NoBomEncoding](Louis.Text.Utf8Utility.md#Louis.Text.Utf8Utility.Utf8NoBomEncoding 'Louis\.Text\.Utf8Utility\.Utf8NoBomEncoding').

This method does not take into account the UTF-8 preamble (BOM), which would add 3 additional bytes
            at the start of the encoded string. If you plan to use the preamble, you should subtract 3 from the number
            of available bytes when calling this method.

<a name='Louis.Text.Utf8Utility.GetMaxCharsInBytes(System.ReadOnlySpan_char_,int)'></a>

## Utf8Utility\.GetMaxCharsInBytes\(ReadOnlySpan\<char\>, int\) Method

Computes the maximum number of characters from a given span
that will fit in a given number of bytes when encoded using UTF\-8\.

```csharp
public static int GetMaxCharsInBytes(System.ReadOnlySpan<char> chars, int maxBytes);
```
#### Parameters

<a name='Louis.Text.Utf8Utility.GetMaxCharsInBytes(System.ReadOnlySpan_char_,int).chars'></a>

`chars` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The characters to encode\.

<a name='Louis.Text.Utf8Utility.GetMaxCharsInBytes(System.ReadOnlySpan_char_,int).maxBytes'></a>

`maxBytes` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of bytes available for the encoded text\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The maximum number of characters, starting from the beginning of [chars](Louis.Text.Utf8Utility.md#Louis.Text.Utf8Utility.GetMaxCharsInBytes(System.ReadOnlySpan_char_,int).chars 'Louis\.Text\.Utf8Utility\.GetMaxCharsInBytes\(System\.ReadOnlySpan\<char\>, int\)\.chars'),
            whose UTF\-8 representation will fit in a maximum of [maxBytes](Louis.Text.Utf8Utility.md#Louis.Text.Utf8Utility.GetMaxCharsInBytes(System.ReadOnlySpan_char_,int).maxBytes 'Louis\.Text\.Utf8Utility\.GetMaxCharsInBytes\(System\.ReadOnlySpan\<char\>, int\)\.maxBytes') bytes\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[maxBytes](Louis.Text.Utf8Utility.md#Louis.Text.Utf8Utility.GetMaxCharsInBytes(System.ReadOnlySpan_char_,int).maxBytes 'Louis\.Text\.Utf8Utility\.GetMaxCharsInBytes\(System\.ReadOnlySpan\<char\>, int\)\.maxBytes') is a negative number\.

### Remarks

This method does not use any functionality from the `System.Text` namespace;
            its computations are based solely on the UTF-8 standard.

This method assumes that any unrepresentable character will be encoded as the Unicode replacement character
            (code point `0xFFFD`). This is the default for both [System\.Text\.Encoding\.UTF8](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.utf8 'System\.Text\.Encoding\.UTF8')
            and [Utf8NoBomEncoding](Louis.Text.Utf8Utility.md#Louis.Text.Utf8Utility.Utf8NoBomEncoding 'Louis\.Text\.Utf8Utility\.Utf8NoBomEncoding').

This method does not take into account the UTF-8 preamble (BOM), which would add 3 additional bytes
            at the start of the encoded string. If you plan to use the preamble, you should subtract 3 from the number
            of available bytes when calling this method.