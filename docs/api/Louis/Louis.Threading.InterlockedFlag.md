#### [Louis](README.md 'README')
### [Louis\.Threading](Louis.Threading.md 'Louis\.Threading')

## InterlockedFlag Struct

Implements thread\-safe management of a boolean value\.

```csharp
public struct InterlockedFlag : System.IEquatable<Louis.Threading.InterlockedFlag>, System.IEquatable<bool>
```

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[InterlockedFlag](Louis.Threading.InterlockedFlag.md 'Louis\.Threading\.InterlockedFlag')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1'), [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')
### Constructors

<a name='Louis.Threading.InterlockedFlag.InterlockedFlag(bool)'></a>

## InterlockedFlag\(bool\) Constructor

Initializes a new instance of the [InterlockedFlag](Louis.Threading.InterlockedFlag.md 'Louis\.Threading\.InterlockedFlag') struct\.

```csharp
public InterlockedFlag(bool value);
```
#### Parameters

<a name='Louis.Threading.InterlockedFlag.InterlockedFlag(bool).value'></a>

`value` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The initial value of the flag\.
### Properties

<a name='Louis.Threading.InterlockedFlag.Value'></a>

## InterlockedFlag\.Value Property


Gets or sets a value indicating whether the flag is set.

This property if thread-safe.

```csharp
public bool Value { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
The value of the flag\.
### Methods

<a name='Louis.Threading.InterlockedFlag.CheckAndSet(bool)'></a>

## InterlockedFlag\.CheckAndSet\(bool\) Method


Sets the value of an [InterlockedFlag](Louis.Threading.InterlockedFlag.md 'Louis\.Threading\.InterlockedFlag') and returns the previous value.

This method is thread-safe.

```csharp
public bool CheckAndSet(bool value);
```
#### Parameters

<a name='Louis.Threading.InterlockedFlag.CheckAndSet(bool).value'></a>

`value` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The value to assign to the flag\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
The previous value of the flag\.

<a name='Louis.Threading.InterlockedFlag.Equals(object)'></a>

## InterlockedFlag\.Equals\(object\) Method

Indicates whether this instance and a specified object are equal\.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='Louis.Threading.InterlockedFlag.Equals(object).obj'></a>

`obj` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to compare with the current instance\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if [obj](Louis.Threading.InterlockedFlag.md#Louis.Threading.InterlockedFlag.Equals(object).obj 'Louis\.Threading\.InterlockedFlag\.Equals\(object\)\.obj') and this instance are the same type and represent the same value; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='Louis.Threading.InterlockedFlag.GetHashCode()'></a>

## InterlockedFlag\.GetHashCode\(\) Method

Returns the hash code for this instance\.

```csharp
public override int GetHashCode();
```

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
A 32\-bit signed integer that is the hash code for this instance\.

<a name='Louis.Threading.InterlockedFlag.ToString()'></a>

## InterlockedFlag\.ToString\(\) Method

Returns the fully qualified type name of this instance\.

```csharp
public override string ToString();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The fully qualified type name\.

<a name='Louis.Threading.InterlockedFlag.TryReset()'></a>

## InterlockedFlag\.TryReset\(\) Method


Tries to reset the value of an [InterlockedFlag](Louis.Threading.InterlockedFlag.md 'Louis\.Threading\.InterlockedFlag') to [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool').

This method is thread-safe.

```csharp
public bool TryReset();
```

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the flag has been reset;
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the value of the flag was already [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='Louis.Threading.InterlockedFlag.TrySet()'></a>

## InterlockedFlag\.TrySet\(\) Method


Tries to set the value of an [InterlockedFlag](Louis.Threading.InterlockedFlag.md 'Louis\.Threading\.InterlockedFlag') to [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool').

This method is thread-safe.

```csharp
public bool TrySet();
```

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the flag has been set;
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the flag was already set\.

<a name='Louis.Threading.InterlockedFlag.TrySet(bool)'></a>

## InterlockedFlag\.TrySet\(bool\) Method


Tries to set the value of an [InterlockedFlag](Louis.Threading.InterlockedFlag.md 'Louis\.Threading\.InterlockedFlag') to the specified value.

This method is thread-safe.

```csharp
public bool TrySet(bool value);
```
#### Parameters

<a name='Louis.Threading.InterlockedFlag.TrySet(bool).value'></a>

`value` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The desired value to set\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the flag has been set to [value](Louis.Threading.InterlockedFlag.md#Louis.Threading.InterlockedFlag.TrySet(bool).value 'Louis\.Threading\.InterlockedFlag\.TrySet\(bool\)\.value');
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the value of the flag was already equal to [value](Louis.Threading.InterlockedFlag.md#Louis.Threading.InterlockedFlag.TrySet(bool).value 'Louis\.Threading\.InterlockedFlag\.TrySet\(bool\)\.value')\.
### Operators

<a name='Louis.Threading.InterlockedFlag.op_Equality(Louis.Threading.InterlockedFlag,bool)'></a>

## InterlockedFlag\.operator ==\(InterlockedFlag, bool\) Operator

Determines whether a specified interlocked flag has the specified value\.

```csharp
public static bool operator ==(Louis.Threading.InterlockedFlag a, bool b);
```
#### Parameters

<a name='Louis.Threading.InterlockedFlag.op_Equality(Louis.Threading.InterlockedFlag,bool).a'></a>

`a` [InterlockedFlag](Louis.Threading.InterlockedFlag.md 'Louis\.Threading\.InterlockedFlag')

The interlocked flag to compare\.

<a name='Louis.Threading.InterlockedFlag.op_Equality(Louis.Threading.InterlockedFlag,bool).b'></a>

`b` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The value to compare\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the value of [a](Louis.Threading.InterlockedFlag.md#Louis.Threading.InterlockedFlag.op_Equality(Louis.Threading.InterlockedFlag,bool).a 'Louis\.Threading\.InterlockedFlag\.op\_Equality\(Louis\.Threading\.InterlockedFlag, bool\)\.a') is the same as [b](Louis.Threading.InterlockedFlag.md#Louis.Threading.InterlockedFlag.op_Equality(Louis.Threading.InterlockedFlag,bool).b 'Louis\.Threading\.InterlockedFlag\.op\_Equality\(Louis\.Threading\.InterlockedFlag, bool\)\.b');
            otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='Louis.Threading.InterlockedFlag.op_Equality(Louis.Threading.InterlockedFlag,Louis.Threading.InterlockedFlag)'></a>

## InterlockedFlag\.operator ==\(InterlockedFlag, InterlockedFlag\) Operator

Determines whether two specified interlocked flags have the same value\.

```csharp
public static bool operator ==(Louis.Threading.InterlockedFlag a, Louis.Threading.InterlockedFlag b);
```
#### Parameters

<a name='Louis.Threading.InterlockedFlag.op_Equality(Louis.Threading.InterlockedFlag,Louis.Threading.InterlockedFlag).a'></a>

`a` [InterlockedFlag](Louis.Threading.InterlockedFlag.md 'Louis\.Threading\.InterlockedFlag')

The first flag to compare\.

<a name='Louis.Threading.InterlockedFlag.op_Equality(Louis.Threading.InterlockedFlag,Louis.Threading.InterlockedFlag).b'></a>

`b` [InterlockedFlag](Louis.Threading.InterlockedFlag.md 'Louis\.Threading\.InterlockedFlag')

The second flag to compare\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the value of [a](Louis.Threading.InterlockedFlag.md#Louis.Threading.InterlockedFlag.op_Equality(Louis.Threading.InterlockedFlag,Louis.Threading.InterlockedFlag).a 'Louis\.Threading\.InterlockedFlag\.op\_Equality\(Louis\.Threading\.InterlockedFlag, Louis\.Threading\.InterlockedFlag\)\.a') is the same as the value of [b](Louis.Threading.InterlockedFlag.md#Louis.Threading.InterlockedFlag.op_Equality(Louis.Threading.InterlockedFlag,Louis.Threading.InterlockedFlag).b 'Louis\.Threading\.InterlockedFlag\.op\_Equality\(Louis\.Threading\.InterlockedFlag, Louis\.Threading\.InterlockedFlag\)\.b');
            otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='Louis.Threading.InterlockedFlag.op_Inequality(Louis.Threading.InterlockedFlag,bool)'></a>

## InterlockedFlag\.operator \!=\(InterlockedFlag, bool\) Operator

Determines whether a specified interlocked flags has a value different from a specified value\.

```csharp
public static bool operator !=(Louis.Threading.InterlockedFlag a, bool b);
```
#### Parameters

<a name='Louis.Threading.InterlockedFlag.op_Inequality(Louis.Threading.InterlockedFlag,bool).a'></a>

`a` [InterlockedFlag](Louis.Threading.InterlockedFlag.md 'Louis\.Threading\.InterlockedFlag')

The interlocked flag to compare\.

<a name='Louis.Threading.InterlockedFlag.op_Inequality(Louis.Threading.InterlockedFlag,bool).b'></a>

`b` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The value to compare\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the value of [a](Louis.Threading.InterlockedFlag.md#Louis.Threading.InterlockedFlag.op_Inequality(Louis.Threading.InterlockedFlag,bool).a 'Louis\.Threading\.InterlockedFlag\.op\_Inequality\(Louis\.Threading\.InterlockedFlag, bool\)\.a') is different from [b](Louis.Threading.InterlockedFlag.md#Louis.Threading.InterlockedFlag.op_Inequality(Louis.Threading.InterlockedFlag,bool).b 'Louis\.Threading\.InterlockedFlag\.op\_Inequality\(Louis\.Threading\.InterlockedFlag, bool\)\.b');
            otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='Louis.Threading.InterlockedFlag.op_Inequality(Louis.Threading.InterlockedFlag,Louis.Threading.InterlockedFlag)'></a>

## InterlockedFlag\.operator \!=\(InterlockedFlag, InterlockedFlag\) Operator

Determines whether two specified interlocked flags have different values\.

```csharp
public static bool operator !=(Louis.Threading.InterlockedFlag a, Louis.Threading.InterlockedFlag b);
```
#### Parameters

<a name='Louis.Threading.InterlockedFlag.op_Inequality(Louis.Threading.InterlockedFlag,Louis.Threading.InterlockedFlag).a'></a>

`a` [InterlockedFlag](Louis.Threading.InterlockedFlag.md 'Louis\.Threading\.InterlockedFlag')

The first flag to compare\.

<a name='Louis.Threading.InterlockedFlag.op_Inequality(Louis.Threading.InterlockedFlag,Louis.Threading.InterlockedFlag).b'></a>

`b` [InterlockedFlag](Louis.Threading.InterlockedFlag.md 'Louis\.Threading\.InterlockedFlag')

The second flag to compare\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the value of [a](Louis.Threading.InterlockedFlag.md#Louis.Threading.InterlockedFlag.op_Inequality(Louis.Threading.InterlockedFlag,Louis.Threading.InterlockedFlag).a 'Louis\.Threading\.InterlockedFlag\.op\_Inequality\(Louis\.Threading\.InterlockedFlag, Louis\.Threading\.InterlockedFlag\)\.a') is different from the value of [b](Louis.Threading.InterlockedFlag.md#Louis.Threading.InterlockedFlag.op_Inequality(Louis.Threading.InterlockedFlag,Louis.Threading.InterlockedFlag).b 'Louis\.Threading\.InterlockedFlag\.op\_Inequality\(Louis\.Threading\.InterlockedFlag, Louis\.Threading\.InterlockedFlag\)\.b');
            otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.