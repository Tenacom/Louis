#### [Louis](README.md 'README')
### [Louis\.ComponentModel](Louis.ComponentModel.md 'Louis\.ComponentModel')

## ParsableStringConverter\<T\> Class


A type converters that uses the [System\.IParsable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iparsable-1 'System\.IParsable\`1') interface to convert strings to instances of a type.

If the type also implements [System\.IFormattable](https://learn.microsoft.com/en-us/dotnet/api/system.iformattable 'System\.IFormattable'), it is used to perform the opposite conversion.

This type is not available in the `netstandard` and .NET Framework builds of Louis,
            because their BCL has no [System\.IParsable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iparsable-1 'System\.IParsable\`1').

```csharp
public class ParsableStringConverter<T> : Louis.ComponentModel.SimpleStringConverter<T>
    where T : System.IParsable<T>
```
#### Type parameters

<a name='Louis.ComponentModel.ParsableStringConverter_T_.T'></a>

`T`

The type to convert\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.ComponentModel\.TypeConverter](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.typeconverter 'System\.ComponentModel\.TypeConverter') → [Louis\.ComponentModel\.SimpleStringConverter&lt;](Louis.ComponentModel.SimpleStringConverter_T_.md 'Louis\.ComponentModel\.SimpleStringConverter\<T\>')[T](Louis.ComponentModel.ParsableStringConverter_T_.md#Louis.ComponentModel.ParsableStringConverter_T_.T 'Louis\.ComponentModel\.ParsableStringConverter\<T\>\.T')[&gt;](Louis.ComponentModel.SimpleStringConverter_T_.md 'Louis\.ComponentModel\.SimpleStringConverter\<T\>') → ParsableStringConverter\<T\>
### Constructors

<a name='Louis.ComponentModel.ParsableStringConverter_T_.ParsableStringConverter()'></a>

## ParsableStringConverter\(\) Constructor

Initializes a new instance of the [ParsableStringConverter&lt;T&gt;](Louis.ComponentModel.ParsableStringConverter_T_.md 'Louis\.ComponentModel\.ParsableStringConverter\<T\>') class\.

```csharp
public ParsableStringConverter();
```