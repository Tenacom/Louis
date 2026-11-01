#### [Louis](README.md 'README')
### [Louis\.Text](Louis.Text.md 'Louis\.Text')

## TrueConditionInterpolatedStringHandler Struct


Provides an interpolated string handler that only performs formatting if a given condition is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool').

This type is only available on .NET 6.0 and greater.

This type is only meant to be used by compiler-generated code. As such, it performs no parameter validation whatsoever.

```csharp
public struct TrueConditionInterpolatedStringHandler
```

### Example

The following code shows how this type can be used as an interpolated string handler:

```csharp
using System;
using System.Runtime.CompilerServices;

public static class ConsoleUtility
{
    // Write a message to the console only if condition is true.
    // Usage example: ConsoleUtility.WriteLineIf(score > 100, $"Your score is {score}. That's awesome!");
    // String interpolation will only take place if necessary.
    public static void WriteLineIf(bool condition, [InterpolatedStringHandlerArgument(nameof(condition))] ref TrueConditionInterpolatedStringHandler message)
    {
        if (condition)
        {
            Console.WriteLine(message.ToStringAndClear());
        }
    }
}
```
### Constructors

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.TrueConditionInterpolatedStringHandler(int,int,bool,bool)'></a>

## TrueConditionInterpolatedStringHandler\(int, int, bool, bool\) Constructor

Initializes a new instance of the [TrueConditionInterpolatedStringHandler](Louis.Text.TrueConditionInterpolatedStringHandler.md 'Louis\.Text\.TrueConditionInterpolatedStringHandler') struct\.

```csharp
public TrueConditionInterpolatedStringHandler(int literalLength, int formattedCount, bool condition, out bool shouldAppend);
```
#### Parameters

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.TrueConditionInterpolatedStringHandler(int,int,bool,bool).literalLength'></a>

`literalLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of constant characters outside of interpolation expressions in the interpolated string\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.TrueConditionInterpolatedStringHandler(int,int,bool,bool).formattedCount'></a>

`formattedCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of interpolation expressions in the interpolated string\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.TrueConditionInterpolatedStringHandler(int,int,bool,bool).condition'></a>

`condition` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The condition that determines whether formatting will actually take place\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.TrueConditionInterpolatedStringHandler(int,int,bool,bool).shouldAppend'></a>

`shouldAppend` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether formatting should proceed\.

### Remarks

This constructor is only intended to be called by compiler-generated code.
            As such, it doesn't perform argument validation.
### Methods

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted(object,int,string)'></a>

## TrueConditionInterpolatedStringHandler\.AppendFormatted\(object, int, string\) Method

Writes the specified value to the handler\.

```csharp
public void AppendFormatted(object? value, int alignment=0, string? format=null);
```
#### Parameters

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted(object,int,string).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The value to write\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted(object,int,string).alignment'></a>

`alignment` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The minimum number of characters that should be written for this value\.  If the value is negative, it indicates left\-aligned and the required minimum is the absolute value\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted(object,int,string).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The format string\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted(string)'></a>

## TrueConditionInterpolatedStringHandler\.AppendFormatted\(string\) Method

Writes the specified value to the handler\.

```csharp
public void AppendFormatted(string? value);
```
#### Parameters

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted(string).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The value to write\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted(string,int,string)'></a>

## TrueConditionInterpolatedStringHandler\.AppendFormatted\(string, int, string\) Method

Writes the specified value to the handler\.

```csharp
public void AppendFormatted(string? value, int alignment=0, string? format=null);
```
#### Parameters

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted(string,int,string).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The value to write\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted(string,int,string).alignment'></a>

`alignment` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The minimum number of characters that should be written for this value\. If the value is negative, it indicates left\-aligned and the required minimum is the absolute value\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted(string,int,string).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The format string\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted(System.ReadOnlySpan_char_)'></a>

## TrueConditionInterpolatedStringHandler\.AppendFormatted\(ReadOnlySpan\<char\>\) Method

Writes the specified character span to the handler\.

```csharp
public void AppendFormatted(System.ReadOnlySpan<char> value);
```
#### Parameters

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted(System.ReadOnlySpan_char_).value'></a>

`value` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The span to write\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted(System.ReadOnlySpan_char_,int,string)'></a>

## TrueConditionInterpolatedStringHandler\.AppendFormatted\(ReadOnlySpan\<char\>, int, string\) Method

Writes the specified string of chars to the handler\.

```csharp
public void AppendFormatted(System.ReadOnlySpan<char> value, int alignment=0, string? format=null);
```
#### Parameters

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted(System.ReadOnlySpan_char_,int,string).value'></a>

`value` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The span to write\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted(System.ReadOnlySpan_char_,int,string).alignment'></a>

`alignment` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The minimum number of characters that should be written for this value\.  If the value is negative, it indicates left\-aligned and the required minimum is the absolute value\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted(System.ReadOnlySpan_char_,int,string).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The format string\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted_T_(T)'></a>

## TrueConditionInterpolatedStringHandler\.AppendFormatted\<T\>\(T\) Method

Writes the specified value to the handler\.

```csharp
public void AppendFormatted<T>(T value);
```
#### Type parameters

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted_T_(T).T'></a>

`T`

The type of the value to write\.
#### Parameters

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted_T_(T).value'></a>

`value` [T](Louis.Text.TrueConditionInterpolatedStringHandler.md#Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted_T_(T).T 'Louis\.Text\.TrueConditionInterpolatedStringHandler\.AppendFormatted\<T\>\(T\)\.T')

The value to write\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted_T_(T,int)'></a>

## TrueConditionInterpolatedStringHandler\.AppendFormatted\<T\>\(T, int\) Method

Writes the specified value to the handler\.

```csharp
public void AppendFormatted<T>(T value, int alignment);
```
#### Type parameters

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted_T_(T,int).T'></a>

`T`

The type of the value to write\.
#### Parameters

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted_T_(T,int).value'></a>

`value` [T](Louis.Text.TrueConditionInterpolatedStringHandler.md#Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted_T_(T,int).T 'Louis\.Text\.TrueConditionInterpolatedStringHandler\.AppendFormatted\<T\>\(T, int\)\.T')

The value to write\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted_T_(T,int).alignment'></a>

`alignment` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The minimum number of characters that should be written for this value\. If the value is negative, it indicates left\-aligned and the required minimum is the absolute value\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted_T_(T,int,string)'></a>

## TrueConditionInterpolatedStringHandler\.AppendFormatted\<T\>\(T, int, string\) Method

Writes the specified value to the handler\.

```csharp
public void AppendFormatted<T>(T value, int alignment, string? format);
```
#### Type parameters

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted_T_(T,int,string).T'></a>

`T`

The type of the value to write\.
#### Parameters

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted_T_(T,int,string).value'></a>

`value` [T](Louis.Text.TrueConditionInterpolatedStringHandler.md#Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted_T_(T,int,string).T 'Louis\.Text\.TrueConditionInterpolatedStringHandler\.AppendFormatted\<T\>\(T, int, string\)\.T')

The value to write\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted_T_(T,int,string).alignment'></a>

`alignment` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The minimum number of characters that should be written for this value\. If the value is negative, it indicates left\-aligned and the required minimum is the absolute value\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted_T_(T,int,string).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The format string\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted_T_(T,string)'></a>

## TrueConditionInterpolatedStringHandler\.AppendFormatted\<T\>\(T, string\) Method

Writes the specified value to the handler\.

```csharp
public void AppendFormatted<T>(T value, string? format);
```
#### Type parameters

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted_T_(T,string).T'></a>

`T`

The type of the value to write\.
#### Parameters

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted_T_(T,string).value'></a>

`value` [T](Louis.Text.TrueConditionInterpolatedStringHandler.md#Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted_T_(T,string).T 'Louis\.Text\.TrueConditionInterpolatedStringHandler\.AppendFormatted\<T\>\(T, string\)\.T')

The value to write\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendFormatted_T_(T,string).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The format string\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendLiteral(string)'></a>

## TrueConditionInterpolatedStringHandler\.AppendLiteral\(string\) Method

Writes the specified string to the handler\.

```csharp
public void AppendLiteral(string value);
```
#### Parameters

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.AppendLiteral(string).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to write\.

<a name='Louis.Text.TrueConditionInterpolatedStringHandler.ToStringAndClear()'></a>

## TrueConditionInterpolatedStringHandler\.ToStringAndClear\(\) Method

Extracts the built string and frees any allocated memory\.

```csharp
public string ToStringAndClear();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The built string\.