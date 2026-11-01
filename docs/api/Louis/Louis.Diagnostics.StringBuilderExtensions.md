#### [Louis](README.md 'README')
### [Louis\.Diagnostics](Louis.Diagnostics.md 'Louis\.Diagnostics')

## StringBuilderExtensions Class

Provides extension methods for [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')\.

```csharp
public static class StringBuilderExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → StringBuilderExtensions
### Methods

<a name='Louis.Diagnostics.StringBuilderExtensions.AppendFormattedObject(thisSystem.Text.StringBuilder,object,string)'></a>

## StringBuilderExtensions\.AppendFormattedObject\(this StringBuilder, object, string\) Method

Appends a text representation of an object to the end of this instance,
using the same algorithm as [FormatObject\(object, string\)](Louis.Diagnostics.ExceptionHelper.md#Louis.Diagnostics.ExceptionHelper.FormatObject(object,string) 'Louis\.Diagnostics\.ExceptionHelper\.FormatObject\(object, string\)')\.

```csharp
public static System.Text.StringBuilder AppendFormattedObject(this System.Text.StringBuilder @this, object? obj, string? format=null);
```
#### Parameters

<a name='Louis.Diagnostics.StringBuilderExtensions.AppendFormattedObject(thisSystem.Text.StringBuilder,object,string).this'></a>

`this` [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

The [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder') on which this method is called\.

<a name='Louis.Diagnostics.StringBuilderExtensions.AppendFormattedObject(thisSystem.Text.StringBuilder,object,string).obj'></a>

`obj` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to represent\. Can be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='Louis.Diagnostics.StringBuilderExtensions.AppendFormattedObject(thisSystem.Text.StringBuilder,object,string).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An optional format string to apply if [obj](Louis.Diagnostics.StringBuilderExtensions.md#Louis.Diagnostics.StringBuilderExtensions.AppendFormattedObject(thisSystem.Text.StringBuilder,object,string).obj 'Louis\.Diagnostics\.StringBuilderExtensions\.AppendFormattedObject\(this System\.Text\.StringBuilder, object, string\)\.obj')
            implements [System\.IFormattable](https://learn.microsoft.com/en-us/dotnet/api/system.iformattable 'System\.IFormattable')\.

#### Returns
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')  
A reference to this instance after the append operation has completed\.\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Diagnostics.StringBuilderExtensions.md#Louis.Diagnostics.StringBuilderExtensions.AppendFormattedObject(thisSystem.Text.StringBuilder,object,string).this 'Louis\.Diagnostics\.StringBuilderExtensions\.AppendFormattedObject\(this System\.Text\.StringBuilder, object, string\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.