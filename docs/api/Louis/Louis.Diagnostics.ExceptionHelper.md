#### [Louis](README.md 'README')
### [Louis\.Diagnostics](Louis.Diagnostics.md 'Louis\.Diagnostics')

## ExceptionHelper Class

Provides utility methods to construct exception messages\.

```csharp
public static class ExceptionHelper
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ExceptionHelper
### Fields

<a name='Louis.Diagnostics.ExceptionHelper.NullText'></a>

## ExceptionHelper\.NullText Field

The text used by [FormatObject\(object, string\)](Louis.Diagnostics.ExceptionHelper.md#Louis.Diagnostics.ExceptionHelper.FormatObject(object,string) 'Louis\.Diagnostics\.ExceptionHelper\.FormatObject\(object, string\)') to represent [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') values\.

```csharp
public const string NullText = "<null>";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Louis.Diagnostics.ExceptionHelper.ToStringEmptyText'></a>

## ExceptionHelper\.ToStringEmptyText Field

The text used by [FormatObject\(object, string\)](Louis.Diagnostics.ExceptionHelper.md#Louis.Diagnostics.ExceptionHelper.FormatObject(object,string) 'Louis\.Diagnostics\.ExceptionHelper\.FormatObject\(object, string\)') to represent values
whose [ToString](https://learn.microsoft.com/en-us/dotnet/api/system.object.tostring 'System\.Object\.ToString') method returns the empty string\.

```csharp
public const string ToStringEmptyText = "<empty!>";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Louis.Diagnostics.ExceptionHelper.ToStringNullText'></a>

## ExceptionHelper\.ToStringNullText Field

The text used by [FormatObject\(object, string\)](Louis.Diagnostics.ExceptionHelper.md#Louis.Diagnostics.ExceptionHelper.FormatObject(object,string) 'Louis\.Diagnostics\.ExceptionHelper\.FormatObject\(object, string\)') to represent values
whose [ToString](https://learn.microsoft.com/en-us/dotnet/api/system.object.tostring 'System\.Object\.ToString') method returns [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

```csharp
public const string ToStringNullText = "<null!>";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Methods

<a name='Louis.Diagnostics.ExceptionHelper.FormatObject(object,string)'></a>

## ExceptionHelper\.FormatObject\(object, string\) Method

Returns a text representation of an object\.

```csharp
public static string FormatObject(object? obj, string? format=null);
```
#### Parameters

<a name='Louis.Diagnostics.ExceptionHelper.FormatObject(object,string).obj'></a>

`obj` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to represent\. Can be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='Louis.Diagnostics.ExceptionHelper.FormatObject(object,string).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An optional format string to apply if [obj](Louis.Diagnostics.ExceptionHelper.md#Louis.Diagnostics.ExceptionHelper.FormatObject(object,string).obj 'Louis\.Diagnostics\.ExceptionHelper\.FormatObject\(object, string\)\.obj')
            implements [System\.IFormattable](https://learn.microsoft.com/en-us/dotnet/api/system.iformattable 'System\.IFormattable')\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A text representation of [obj](Louis.Diagnostics.ExceptionHelper.md#Louis.Diagnostics.ExceptionHelper.FormatObject(object,string).obj 'Louis\.Diagnostics\.ExceptionHelper\.FormatObject\(object, string\)\.obj')\.

### Remarks

This method attempts to never throw exceptions and always return meaningful text,
            without cluttering exception messages with potentially very long string values,
            by using the following algorithm:
- if [obj](Louis.Diagnostics.ExceptionHelper.md#Louis.Diagnostics.ExceptionHelper.FormatObject(object,string).obj 'Louis\.Diagnostics\.ExceptionHelper\.FormatObject\(object, string\)\.obj') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), return [NullText](Louis.Diagnostics.ExceptionHelper.md#Louis.Diagnostics.ExceptionHelper.NullText 'Louis\.Diagnostics\.ExceptionHelper\.NullText');
- if [obj](Louis.Diagnostics.ExceptionHelper.md#Louis.Diagnostics.ExceptionHelper.FormatObject(object,string).obj 'Louis\.Diagnostics\.ExceptionHelper\.FormatObject\(object, string\)\.obj') is a [string](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/string'), convert it to a
              [quoted string literal](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#quoted-string-literals 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/programming\-guide/strings/\#quoted\-string\-literals'),
              clipping it if longer than 43 characters by leaving the first and last 20 characters
              separated by an ellipsis (three dots);
- otherwise, check whether [obj](Louis.Diagnostics.ExceptionHelper.md#Louis.Diagnostics.ExceptionHelper.FormatObject(object,string).obj 'Louis\.Diagnostics\.ExceptionHelper\.FormatObject\(object, string\)\.obj') implements [System\.IFormattable](https://learn.microsoft.com/en-us/dotnet/api/system.iformattable 'System\.IFormattable')
              and act accordingly.

If [obj](Louis.Diagnostics.ExceptionHelper.md#Louis.Diagnostics.ExceptionHelper.FormatObject(object,string).obj 'Louis\.Diagnostics\.ExceptionHelper\.FormatObject\(object, string\)\.obj') implements [System\.IFormattable](https://learn.microsoft.com/en-us/dotnet/api/system.iformattable 'System\.IFormattable'):
- try to format [obj](Louis.Diagnostics.ExceptionHelper.md#Louis.Diagnostics.ExceptionHelper.FormatObject(object,string).obj 'Louis\.Diagnostics\.ExceptionHelper\.FormatObject\(object, string\)\.obj') using the specified [format](Louis.Diagnostics.ExceptionHelper.md#Louis.Diagnostics.ExceptionHelper.FormatObject(object,string).format 'Louis\.Diagnostics\.ExceptionHelper\.FormatObject\(object, string\)\.format')
              and the [invariant culture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.invariantculture 'System\.Globalization\.CultureInfo\.InvariantCulture');
- if an exception is thrown, try again using an empty format string;
- if another exception is thrown, treat [obj](Louis.Diagnostics.ExceptionHelper.md#Louis.Diagnostics.ExceptionHelper.FormatObject(object,string).obj 'Louis\.Diagnostics\.ExceptionHelper\.FormatObject\(object, string\)\.obj') as if it didn't implement [System\.IFormattable](https://learn.microsoft.com/en-us/dotnet/api/system.iformattable 'System\.IFormattable').

If [obj](Louis.Diagnostics.ExceptionHelper.md#Louis.Diagnostics.ExceptionHelper.FormatObject(object,string).obj 'Louis\.Diagnostics\.ExceptionHelper\.FormatObject\(object, string\)\.obj') does not implement [System\.IFormattable](https://learn.microsoft.com/en-us/dotnet/api/system.iformattable 'System\.IFormattable'):
- call [obj](Louis.Diagnostics.ExceptionHelper.md#Louis.Diagnostics.ExceptionHelper.FormatObject(object,string).obj 'Louis\.Diagnostics\.ExceptionHelper\.FormatObject\(object, string\)\.obj').[ToString\(\)](https://learn.microsoft.com/en-us/dotnet/api/system.object.tostring 'System\.Object\.ToString');
- if `ToString` throws an exception, return a string of the form `<{objType}:{exceptionType}>`;
- if `ToString` returns [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), return [ToStringNullText](Louis.Diagnostics.ExceptionHelper.md#Louis.Diagnostics.ExceptionHelper.ToStringNullText 'Louis\.Diagnostics\.ExceptionHelper\.ToStringNullText');
- if `ToString` returns the empty string, return [ToStringNullText](Louis.Diagnostics.ExceptionHelper.md#Louis.Diagnostics.ExceptionHelper.ToStringNullText 'Louis\.Diagnostics\.ExceptionHelper\.ToStringNullText');
- otherwise, return the result of `ToString`.

Keep in mind that instances of [nullable value types](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/nullable\-value\-types')
            will be passed [boxed](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types#boxing-and-unboxing 'https://learn\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/nullable\-value\-types\#boxing\-and\-unboxing')
            and therefore seen as either [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') or a non-nullable value.