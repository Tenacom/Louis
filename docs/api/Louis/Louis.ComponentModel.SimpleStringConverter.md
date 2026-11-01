#### [Louis](README.md 'README')
### [Louis\.ComponentModel](Louis.ComponentModel.md 'Louis\.ComponentModel')

## SimpleStringConverter Class

Provides utility methods to simplify use of type converters derived from [SimpleStringConverter&lt;T&gt;](Louis.ComponentModel.SimpleStringConverter_T_.md 'Louis\.ComponentModel\.SimpleStringConverter\<T\>')\.

```csharp
public static class SimpleStringConverter
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → SimpleStringConverter
### Methods

<a name='Louis.ComponentModel.SimpleStringConverter.AddToTypeDescriptor_T,TConverter_()'></a>

## SimpleStringConverter\.AddToTypeDescriptor\<T,TConverter\>\(\) Method

Registers a type converter for use by [System\.ComponentModel\.TypeDescriptor](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.typedescriptor 'System\.ComponentModel\.TypeDescriptor') methods\.

```csharp
public static void AddToTypeDescriptor<T,TConverter>()
    where TConverter : Louis.ComponentModel.SimpleStringConverter<T>;
```
#### Type parameters

<a name='Louis.ComponentModel.SimpleStringConverter.AddToTypeDescriptor_T,TConverter_().T'></a>

`T`

The type of the object to convert to / from [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')\.

<a name='Louis.ComponentModel.SimpleStringConverter.AddToTypeDescriptor_T,TConverter_().TConverter'></a>

`TConverter`

The type of the converter to use\.

<a name='Louis.ComponentModel.SimpleStringConverter.AddToTypeDescriptor_T_()'></a>

## SimpleStringConverter\.AddToTypeDescriptor\<T\>\(\) Method

Registers a type converter for use by [System\.ComponentModel\.TypeDescriptor](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.typedescriptor 'System\.ComponentModel\.TypeDescriptor') methods, where the type to convert to
implements the [System\.IParsable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iparsable-1 'System\.IParsable\`1') interface\.

```csharp
public static void AddToTypeDescriptor<T>()
    where T : System.IParsable<T>;
```
#### Type parameters

<a name='Louis.ComponentModel.SimpleStringConverter.AddToTypeDescriptor_T_().T'></a>

`T`

The type of the object to convert to / from [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')\. The type must implement the [System\.IParsable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iparsable-1 'System\.IParsable\`1') interface\.