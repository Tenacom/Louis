#### [Louis](README.md 'README')
### [Louis\.ComponentModel](Louis.ComponentModel.md 'Louis\.ComponentModel')

## SimpleStringConverter\<T\> Class

Base class for type converters that can convert instances of a specific type to and from strings\.

```csharp
public abstract class SimpleStringConverter<T> : System.ComponentModel.TypeConverter
```
#### Type parameters

<a name='Louis.ComponentModel.SimpleStringConverter_T_.T'></a>

`T`

The type to convert\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.ComponentModel\.TypeConverter](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.typeconverter 'System\.ComponentModel\.TypeConverter') → SimpleStringConverter\<T\>

Derived  
↳ [MailAddressCollectionConverter](Louis.ComponentModel.MailAddressCollectionConverter.md 'Louis\.ComponentModel\.MailAddressCollectionConverter')  
↳ [MailAddressConverter](Louis.ComponentModel.MailAddressConverter.md 'Louis\.ComponentModel\.MailAddressConverter')  
↳ [ParsableStringConverter&lt;T&gt;](Louis.ComponentModel.ParsableStringConverter_T_.md 'Louis\.ComponentModel\.ParsableStringConverter\<T\>')
### Constructors

<a name='Louis.ComponentModel.SimpleStringConverter_T_.SimpleStringConverter(System.Func_System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,string,T_,System.Func_System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,T,string_)'></a>

## SimpleStringConverter\(Func\<ITypeDescriptorContext,CultureInfo,string,T\>, Func\<ITypeDescriptorContext,CultureInfo,T,string\>\) Constructor

Initializes a new instance of the [SimpleStringConverter&lt;T&gt;](Louis.ComponentModel.SimpleStringConverter_T_.md 'Louis\.ComponentModel\.SimpleStringConverter\<T\>') class\.

```csharp
protected SimpleStringConverter(System.Func<System.ComponentModel.ITypeDescriptorContext?,System.Globalization.CultureInfo?,string,T>? convertFromString, System.Func<System.ComponentModel.ITypeDescriptorContext?,System.Globalization.CultureInfo?,T,string>? convertToString);
```
#### Parameters

<a name='Louis.ComponentModel.SimpleStringConverter_T_.SimpleStringConverter(System.Func_System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,string,T_,System.Func_System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,T,string_).convertFromString'></a>

`convertFromString` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[System\.ComponentModel\.ITypeDescriptorContext](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.itypedescriptorcontext 'System\.ComponentModel\.ITypeDescriptorContext')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[System\.Globalization\.CultureInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo 'System\.Globalization\.CultureInfo')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[T](Louis.ComponentModel.SimpleStringConverter_T_.md#Louis.ComponentModel.SimpleStringConverter_T_.T 'Louis\.ComponentModel\.SimpleStringConverter\<T\>\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')

A delegate used to convert strings to instances of [T](Louis.ComponentModel.SimpleStringConverter_T_.md#Louis.ComponentModel.SimpleStringConverter_T_.T 'Louis\.ComponentModel\.SimpleStringConverter\<T\>\.T'),
            or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') if this provider does not provide this functionality\.

<a name='Louis.ComponentModel.SimpleStringConverter_T_.SimpleStringConverter(System.Func_System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,string,T_,System.Func_System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,T,string_).convertToString'></a>

`convertToString` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[System\.ComponentModel\.ITypeDescriptorContext](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.itypedescriptorcontext 'System\.ComponentModel\.ITypeDescriptorContext')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[System\.Globalization\.CultureInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo 'System\.Globalization\.CultureInfo')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[T](Louis.ComponentModel.SimpleStringConverter_T_.md#Louis.ComponentModel.SimpleStringConverter_T_.T 'Louis\.ComponentModel\.SimpleStringConverter\<T\>\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')

A delegate used to convert instances of [T](Louis.ComponentModel.SimpleStringConverter_T_.md#Louis.ComponentModel.SimpleStringConverter_T_.T 'Louis\.ComponentModel\.SimpleStringConverter\<T\>\.T') to strings,
            or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') if this provider does not provide this functionality\.
### Methods

<a name='Louis.ComponentModel.SimpleStringConverter_T_.CanConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Type)'></a>

## SimpleStringConverter\<T\>\.CanConvertFrom\(ITypeDescriptorContext, Type\) Method

Returns whether this converter can convert an object of type [sourceType](Louis.ComponentModel.SimpleStringConverter_T_.md#Louis.ComponentModel.SimpleStringConverter_T_.CanConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Type).sourceType 'Louis\.ComponentModel\.SimpleStringConverter\<T\>\.CanConvertFrom\(System\.ComponentModel\.ITypeDescriptorContext, System\.Type\)\.sourceType')
to [T](Louis.ComponentModel.SimpleStringConverter_T_.md#Louis.ComponentModel.SimpleStringConverter_T_.T 'Louis\.ComponentModel\.SimpleStringConverter\<T\>\.T'), using the specified [context](Louis.ComponentModel.SimpleStringConverter_T_.md#Louis.ComponentModel.SimpleStringConverter_T_.CanConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Type).context 'Louis\.ComponentModel\.SimpleStringConverter\<T\>\.CanConvertFrom\(System\.ComponentModel\.ITypeDescriptorContext, System\.Type\)\.context')\.

```csharp
public sealed override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext? context, System.Type sourceType);
```
#### Parameters

<a name='Louis.ComponentModel.SimpleStringConverter_T_.CanConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Type).context'></a>

`context` [System\.ComponentModel\.ITypeDescriptorContext](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.itypedescriptorcontext 'System\.ComponentModel\.ITypeDescriptorContext')

An [System\.ComponentModel\.ITypeDescriptorContext](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.itypedescriptorcontext 'System\.ComponentModel\.ITypeDescriptorContext') that provides a format context\.

<a name='Louis.ComponentModel.SimpleStringConverter_T_.CanConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Type).sourceType'></a>

`sourceType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

A [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type') that represents the type to convert from\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if this converter can perform the conversion; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

### Remarks

This method returns [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if [sourceType](Louis.ComponentModel.SimpleStringConverter_T_.md#Louis.ComponentModel.SimpleStringConverter_T_.CanConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Type).sourceType 'Louis\.ComponentModel\.SimpleStringConverter\<T\>\.CanConvertFrom\(System\.ComponentModel\.ITypeDescriptorContext, System\.Type\)\.sourceType') is [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
            and the constructor received a non-null `convertFromString` delegate;
            otherwise, it calls [System\.ComponentModel\.TypeConverter\.CanConvertFrom\(System\.ComponentModel\.ITypeDescriptorContext,System\.Type\)](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.typeconverter.canconvertfrom#system-componentmodel-typeconverter-canconvertfrom(system-componentmodel-itypedescriptorcontext-system-type) 'System\.ComponentModel\.TypeConverter\.CanConvertFrom\(System\.ComponentModel\.ITypeDescriptorContext,System\.Type\)') and returns the result.

<a name='Louis.ComponentModel.SimpleStringConverter_T_.CanConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Type)'></a>

## SimpleStringConverter\<T\>\.CanConvertTo\(ITypeDescriptorContext, Type\) Method

Returns whether this converter can convert an object an instance of [T](Louis.ComponentModel.SimpleStringConverter_T_.md#Louis.ComponentModel.SimpleStringConverter_T_.T 'Louis\.ComponentModel\.SimpleStringConverter\<T\>\.T') to [destinationType](Louis.ComponentModel.SimpleStringConverter_T_.md#Louis.ComponentModel.SimpleStringConverter_T_.CanConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Type).destinationType 'Louis\.ComponentModel\.SimpleStringConverter\<T\>\.CanConvertTo\(System\.ComponentModel\.ITypeDescriptorContext, System\.Type\)\.destinationType'),
using the specified [context](Louis.ComponentModel.SimpleStringConverter_T_.md#Louis.ComponentModel.SimpleStringConverter_T_.CanConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Type).context 'Louis\.ComponentModel\.SimpleStringConverter\<T\>\.CanConvertTo\(System\.ComponentModel\.ITypeDescriptorContext, System\.Type\)\.context')\.

```csharp
public sealed override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext? context, System.Type? destinationType);
```
#### Parameters

<a name='Louis.ComponentModel.SimpleStringConverter_T_.CanConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Type).context'></a>

`context` [System\.ComponentModel\.ITypeDescriptorContext](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.itypedescriptorcontext 'System\.ComponentModel\.ITypeDescriptorContext')

An [System\.ComponentModel\.ITypeDescriptorContext](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.itypedescriptorcontext 'System\.ComponentModel\.ITypeDescriptorContext') that provides a format context\.

<a name='Louis.ComponentModel.SimpleStringConverter_T_.CanConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Type).destinationType'></a>

`destinationType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

A [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type') that represents the type to convert to\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if this converter can perform the conversion; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

### Remarks

This method always returns [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if [destinationType](Louis.ComponentModel.SimpleStringConverter_T_.md#Louis.ComponentModel.SimpleStringConverter_T_.CanConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Type).destinationType 'Louis\.ComponentModel\.SimpleStringConverter\<T\>\.CanConvertTo\(System\.ComponentModel\.ITypeDescriptorContext, System\.Type\)\.destinationType') is [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String');
            otherwise, it calls [System\.ComponentModel\.TypeConverter\.CanConvertTo\(System\.ComponentModel\.ITypeDescriptorContext,System\.Type\)](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.typeconverter.canconvertto#system-componentmodel-typeconverter-canconvertto(system-componentmodel-itypedescriptorcontext-system-type) 'System\.ComponentModel\.TypeConverter\.CanConvertTo\(System\.ComponentModel\.ITypeDescriptorContext,System\.Type\)') and returns the result.

<a name='Louis.ComponentModel.SimpleStringConverter_T_.ConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,object)'></a>

## SimpleStringConverter\<T\>\.ConvertFrom\(ITypeDescriptorContext, CultureInfo, object\) Method

Converts the given object to [T](Louis.ComponentModel.SimpleStringConverter_T_.md#Louis.ComponentModel.SimpleStringConverter_T_.T 'Louis\.ComponentModel\.SimpleStringConverter\<T\>\.T'), using the specified context and culture information\.

```csharp
public sealed override object? ConvertFrom(System.ComponentModel.ITypeDescriptorContext? context, System.Globalization.CultureInfo? culture, object value);
```
#### Parameters

<a name='Louis.ComponentModel.SimpleStringConverter_T_.ConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,object).context'></a>

`context` [System\.ComponentModel\.ITypeDescriptorContext](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.itypedescriptorcontext 'System\.ComponentModel\.ITypeDescriptorContext')

An [System\.ComponentModel\.ITypeDescriptorContext](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.itypedescriptorcontext 'System\.ComponentModel\.ITypeDescriptorContext') that provides a format context\.

<a name='Louis.ComponentModel.SimpleStringConverter_T_.ConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,object).culture'></a>

`culture` [System\.Globalization\.CultureInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo 'System\.Globalization\.CultureInfo')

The [System\.Globalization\.CultureInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo 'System\.Globalization\.CultureInfo') to use as the current culture\.

<a name='Louis.ComponentModel.SimpleStringConverter_T_.ConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,object).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') to convert\.

#### Returns
[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')  
An [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') that represents the converted value\.

#### Exceptions

[System\.NotSupportedException](https://learn.microsoft.com/en-us/dotnet/api/system.notsupportedexception 'System\.NotSupportedException')  
The conversion cannot be performed\.

<a name='Louis.ComponentModel.SimpleStringConverter_T_.ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,object,System.Type)'></a>

## SimpleStringConverter\<T\>\.ConvertTo\(ITypeDescriptorContext, CultureInfo, object, Type\) Method

Converts the given object to [destinationType](Louis.ComponentModel.SimpleStringConverter_T_.md#Louis.ComponentModel.SimpleStringConverter_T_.ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,object,System.Type).destinationType 'Louis\.ComponentModel\.SimpleStringConverter\<T\>\.ConvertTo\(System\.ComponentModel\.ITypeDescriptorContext, System\.Globalization\.CultureInfo, object, System\.Type\)\.destinationType'), using the specified context and culture information\.

```csharp
public sealed override object? ConvertTo(System.ComponentModel.ITypeDescriptorContext? context, System.Globalization.CultureInfo? culture, object? value, System.Type destinationType);
```
#### Parameters

<a name='Louis.ComponentModel.SimpleStringConverter_T_.ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,object,System.Type).context'></a>

`context` [System\.ComponentModel\.ITypeDescriptorContext](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.itypedescriptorcontext 'System\.ComponentModel\.ITypeDescriptorContext')

An [System\.ComponentModel\.ITypeDescriptorContext](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.itypedescriptorcontext 'System\.ComponentModel\.ITypeDescriptorContext') that provides a format context\.

<a name='Louis.ComponentModel.SimpleStringConverter_T_.ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,object,System.Type).culture'></a>

`culture` [System\.Globalization\.CultureInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo 'System\.Globalization\.CultureInfo')

The [System\.Globalization\.CultureInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo 'System\.Globalization\.CultureInfo') to use as the current culture\.

<a name='Louis.ComponentModel.SimpleStringConverter_T_.ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,object,System.Type).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') to convert\.

<a name='Louis.ComponentModel.SimpleStringConverter_T_.ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,object,System.Type).destinationType'></a>

`destinationType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

A [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type') that represents the type to convert to\.

#### Returns
[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')  
An [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') that represents the converted value\.

#### Exceptions

[System\.NotSupportedException](https://learn.microsoft.com/en-us/dotnet/api/system.notsupportedexception 'System\.NotSupportedException')  
The conversion cannot be performed\.