#### [Louis](README.md 'README')
### [Louis\.Threading](Louis.Threading.md 'Louis\.Threading')

## InterlockedReference\<T\> Struct

Implements thread\-safe management of an object reference\.

```csharp
public struct InterlockedReference<T> : System.IEquatable<Louis.Threading.InterlockedReference<T>>, System.IEquatable<T?>
    where T : class
```
#### Type parameters

<a name='Louis.Threading.InterlockedReference_T_.T'></a>

`T`

The type of the stored reference\.

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[Louis\.Threading\.InterlockedReference&lt;](Louis.Threading.InterlockedReference_T_.md 'Louis\.Threading\.InterlockedReference\<T\>')[T](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.T 'Louis\.Threading\.InterlockedReference\<T\>\.T')[&gt;](Louis.Threading.InterlockedReference_T_.md 'Louis\.Threading\.InterlockedReference\<T\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1'), [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[T](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.T 'Louis\.Threading\.InterlockedReference\<T\>\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')
### Constructors

<a name='Louis.Threading.InterlockedReference_T_.InterlockedReference(T)'></a>

## InterlockedReference\(T\) Constructor

Initializes a new instance of the [InterlockedReference&lt;T&gt;](Louis.Threading.InterlockedReference_T_.md 'Louis\.Threading\.InterlockedReference\<T\>') struct\.

```csharp
public InterlockedReference(T? value);
```
#### Parameters

<a name='Louis.Threading.InterlockedReference_T_.InterlockedReference(T).value'></a>

`value` [T](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.T 'Louis\.Threading\.InterlockedReference\<T\>\.T')

The initial value of the reference\.
### Properties

<a name='Louis.Threading.InterlockedReference_T_.IsNull'></a>

## InterlockedReference\<T\>\.IsNull Property

Gets a value indicating whether the reference stored in an [InterlockedReference&lt;T&gt;](Louis.Threading.InterlockedReference_T_.md 'Louis\.Threading\.InterlockedReference\<T\>') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

```csharp
public bool IsNull { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the reference is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null');
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') otherwise\.

<a name='Louis.Threading.InterlockedReference_T_.Value'></a>

## InterlockedReference\<T\>\.Value Property


Gets or sets the reference stored in an [InterlockedReference&lt;T&gt;](Louis.Threading.InterlockedReference_T_.md 'Louis\.Threading\.InterlockedReference\<T\>').

This property is thread-safe.

```csharp
public T? Value { get; set; }
```

#### Property Value
[T](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.T 'Louis\.Threading\.InterlockedReference\<T\>\.T')
### Methods

<a name='Louis.Threading.InterlockedReference_T_.CompareExchange(T,T)'></a>

## InterlockedReference\<T\>\.CompareExchange\(T, T\) Method

Compares the value of an interlocked reference to a given comparand and, if they are equal, replaces it with a given value\.

```csharp
public T? CompareExchange(T? value, T? comparand);
```
#### Parameters

<a name='Louis.Threading.InterlockedReference_T_.CompareExchange(T,T).value'></a>

`value` [T](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.T 'Louis\.Threading\.InterlockedReference\<T\>\.T')

The value that replaces the destination value if the comparison by reference results in equality\.

<a name='Louis.Threading.InterlockedReference_T_.CompareExchange(T,T).comparand'></a>

`comparand` [T](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.T 'Louis\.Threading\.InterlockedReference\<T\>\.T')

The value that is compared by reference to the value of this instance\.

#### Returns
[T](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.T 'Louis\.Threading\.InterlockedReference\<T\>\.T')  
The original value of this instance\.

<a name='Louis.Threading.InterlockedReference_T_.Equals(object)'></a>

## InterlockedReference\<T\>\.Equals\(object\) Method

Indicates whether this instance and a specified object are equal\.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='Louis.Threading.InterlockedReference_T_.Equals(object).obj'></a>

`obj` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to compare with the current instance\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if [obj](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.Equals(object).obj 'Louis\.Threading\.InterlockedReference\<T\>\.Equals\(object\)\.obj') and this instance are the same type and represent the same value; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='Louis.Threading.InterlockedReference_T_.Equals(T)'></a>

## InterlockedReference\<T\>\.Equals\(T\) Method

Indicates whether the current object is equal to another object of the same type\.

```csharp
public bool Equals(T? other);
```
#### Parameters

<a name='Louis.Threading.InterlockedReference_T_.Equals(T).other'></a>

`other` [T](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.T 'Louis\.Threading\.InterlockedReference\<T\>\.T')

An object to compare with this object\.

Implements [Equals\(T\)](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals#system-iequatable-1-equals(-0) 'System\.IEquatable\`1\.Equals\(\`0\)')

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the current object is equal to the [other](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.Equals(T).other 'Louis\.Threading\.InterlockedReference\<T\>\.Equals\(T\)\.other') parameter; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='Louis.Threading.InterlockedReference_T_.Exchange(T)'></a>

## InterlockedReference\<T\>\.Exchange\(T\) Method

Sets the value of an interlocked reference\.

```csharp
public T? Exchange(T? value);
```
#### Parameters

<a name='Louis.Threading.InterlockedReference_T_.Exchange(T).value'></a>

`value` [T](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.T 'Louis\.Threading\.InterlockedReference\<T\>\.T')

The value to set\.

#### Returns
[T](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.T 'Louis\.Threading\.InterlockedReference\<T\>\.T')  
The previous value of this instance\.

<a name='Louis.Threading.InterlockedReference_T_.GetHashCode()'></a>

## InterlockedReference\<T\>\.GetHashCode\(\) Method

Returns the hash code for this instance\.

```csharp
public override int GetHashCode();
```

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
A 32\-bit signed integer that is the hash code for this instance\.

<a name='Louis.Threading.InterlockedReference_T_.ToString()'></a>

## InterlockedReference\<T\>\.ToString\(\) Method

Returns the fully qualified type name of this instance\.

```csharp
public override string ToString();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The fully qualified type name\.
### Operators

<a name='Louis.Threading.InterlockedReference_T_.op_Equality(Louis.Threading.InterlockedReference_T_,Louis.Threading.InterlockedReference_T_)'></a>

## InterlockedReference\<T\>\.operator ==\(InterlockedReference\<T\>, InterlockedReference\<T\>\) Operator

Determines whether two specified interlocked references have the same value\.

```csharp
public static bool operator ==(Louis.Threading.InterlockedReference<T> a, Louis.Threading.InterlockedReference<T> b);
```
#### Parameters

<a name='Louis.Threading.InterlockedReference_T_.op_Equality(Louis.Threading.InterlockedReference_T_,Louis.Threading.InterlockedReference_T_).a'></a>

`a` [Louis\.Threading\.InterlockedReference&lt;](Louis.Threading.InterlockedReference_T_.md 'Louis\.Threading\.InterlockedReference\<T\>')[T](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.T 'Louis\.Threading\.InterlockedReference\<T\>\.T')[&gt;](Louis.Threading.InterlockedReference_T_.md 'Louis\.Threading\.InterlockedReference\<T\>')

The first instance to compare\.

<a name='Louis.Threading.InterlockedReference_T_.op_Equality(Louis.Threading.InterlockedReference_T_,Louis.Threading.InterlockedReference_T_).b'></a>

`b` [Louis\.Threading\.InterlockedReference&lt;](Louis.Threading.InterlockedReference_T_.md 'Louis\.Threading\.InterlockedReference\<T\>')[T](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.T 'Louis\.Threading\.InterlockedReference\<T\>\.T')[&gt;](Louis.Threading.InterlockedReference_T_.md 'Louis\.Threading\.InterlockedReference\<T\>')

The second instance to compare\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the value of [a](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.op_Equality(Louis.Threading.InterlockedReference_T_,Louis.Threading.InterlockedReference_T_).a 'Louis\.Threading\.InterlockedReference\<T\>\.op\_Equality\(Louis\.Threading\.InterlockedReference\<T\>, Louis\.Threading\.InterlockedReference\<T\>\)\.a') is the same as the value of [b](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.op_Equality(Louis.Threading.InterlockedReference_T_,Louis.Threading.InterlockedReference_T_).b 'Louis\.Threading\.InterlockedReference\<T\>\.op\_Equality\(Louis\.Threading\.InterlockedReference\<T\>, Louis\.Threading\.InterlockedReference\<T\>\)\.b');
            otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='Louis.Threading.InterlockedReference_T_.op_Equality(Louis.Threading.InterlockedReference_T_,T)'></a>

## InterlockedReference\<T\>\.operator ==\(InterlockedReference\<T\>, T\) Operator

Determines whether the value of a specified interlocked reference is the same as a specified value\.

```csharp
public static bool operator ==(Louis.Threading.InterlockedReference<T> a, T? b);
```
#### Parameters

<a name='Louis.Threading.InterlockedReference_T_.op_Equality(Louis.Threading.InterlockedReference_T_,T).a'></a>

`a` [Louis\.Threading\.InterlockedReference&lt;](Louis.Threading.InterlockedReference_T_.md 'Louis\.Threading\.InterlockedReference\<T\>')[T](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.T 'Louis\.Threading\.InterlockedReference\<T\>\.T')[&gt;](Louis.Threading.InterlockedReference_T_.md 'Louis\.Threading\.InterlockedReference\<T\>')

The interlocked reference to compare\.

<a name='Louis.Threading.InterlockedReference_T_.op_Equality(Louis.Threading.InterlockedReference_T_,T).b'></a>

`b` [T](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.T 'Louis\.Threading\.InterlockedReference\<T\>\.T')

The reference to compare\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the value of [a](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.op_Equality(Louis.Threading.InterlockedReference_T_,T).a 'Louis\.Threading\.InterlockedReference\<T\>\.op\_Equality\(Louis\.Threading\.InterlockedReference\<T\>, T\)\.a') is the same as the value of [b](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.op_Equality(Louis.Threading.InterlockedReference_T_,T).b 'Louis\.Threading\.InterlockedReference\<T\>\.op\_Equality\(Louis\.Threading\.InterlockedReference\<T\>, T\)\.b');
            otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='Louis.Threading.InterlockedReference_T_.op_Inequality(Louis.Threading.InterlockedReference_T_,Louis.Threading.InterlockedReference_T_)'></a>

## InterlockedReference\<T\>\.operator \!=\(InterlockedReference\<T\>, InterlockedReference\<T\>\) Operator

Determines whether two specified interlocked references have different values\.

```csharp
public static bool operator !=(Louis.Threading.InterlockedReference<T> a, Louis.Threading.InterlockedReference<T> b);
```
#### Parameters

<a name='Louis.Threading.InterlockedReference_T_.op_Inequality(Louis.Threading.InterlockedReference_T_,Louis.Threading.InterlockedReference_T_).a'></a>

`a` [Louis\.Threading\.InterlockedReference&lt;](Louis.Threading.InterlockedReference_T_.md 'Louis\.Threading\.InterlockedReference\<T\>')[T](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.T 'Louis\.Threading\.InterlockedReference\<T\>\.T')[&gt;](Louis.Threading.InterlockedReference_T_.md 'Louis\.Threading\.InterlockedReference\<T\>')

The first instance to compare\.

<a name='Louis.Threading.InterlockedReference_T_.op_Inequality(Louis.Threading.InterlockedReference_T_,Louis.Threading.InterlockedReference_T_).b'></a>

`b` [Louis\.Threading\.InterlockedReference&lt;](Louis.Threading.InterlockedReference_T_.md 'Louis\.Threading\.InterlockedReference\<T\>')[T](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.T 'Louis\.Threading\.InterlockedReference\<T\>\.T')[&gt;](Louis.Threading.InterlockedReference_T_.md 'Louis\.Threading\.InterlockedReference\<T\>')

The second instance to compare\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the value of [a](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.op_Inequality(Louis.Threading.InterlockedReference_T_,Louis.Threading.InterlockedReference_T_).a 'Louis\.Threading\.InterlockedReference\<T\>\.op\_Inequality\(Louis\.Threading\.InterlockedReference\<T\>, Louis\.Threading\.InterlockedReference\<T\>\)\.a') is different from the value of [b](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.op_Inequality(Louis.Threading.InterlockedReference_T_,Louis.Threading.InterlockedReference_T_).b 'Louis\.Threading\.InterlockedReference\<T\>\.op\_Inequality\(Louis\.Threading\.InterlockedReference\<T\>, Louis\.Threading\.InterlockedReference\<T\>\)\.b');
            otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='Louis.Threading.InterlockedReference_T_.op_Inequality(Louis.Threading.InterlockedReference_T_,T)'></a>

## InterlockedReference\<T\>\.operator \!=\(InterlockedReference\<T\>, T\) Operator

Determines whether the value of a specified interlocked reference is different from a specified value\.

```csharp
public static bool operator !=(Louis.Threading.InterlockedReference<T> a, T? b);
```
#### Parameters

<a name='Louis.Threading.InterlockedReference_T_.op_Inequality(Louis.Threading.InterlockedReference_T_,T).a'></a>

`a` [Louis\.Threading\.InterlockedReference&lt;](Louis.Threading.InterlockedReference_T_.md 'Louis\.Threading\.InterlockedReference\<T\>')[T](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.T 'Louis\.Threading\.InterlockedReference\<T\>\.T')[&gt;](Louis.Threading.InterlockedReference_T_.md 'Louis\.Threading\.InterlockedReference\<T\>')

The interlocked reference to compare\.

<a name='Louis.Threading.InterlockedReference_T_.op_Inequality(Louis.Threading.InterlockedReference_T_,T).b'></a>

`b` [T](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.T 'Louis\.Threading\.InterlockedReference\<T\>\.T')

The reference to compare\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the value of [a](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.op_Inequality(Louis.Threading.InterlockedReference_T_,T).a 'Louis\.Threading\.InterlockedReference\<T\>\.op\_Inequality\(Louis\.Threading\.InterlockedReference\<T\>, T\)\.a') is different from the value of [b](Louis.Threading.InterlockedReference_T_.md#Louis.Threading.InterlockedReference_T_.op_Inequality(Louis.Threading.InterlockedReference_T_,T).b 'Louis\.Threading\.InterlockedReference\<T\>\.op\_Inequality\(Louis\.Threading\.InterlockedReference\<T\>, T\)\.b');
            otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.