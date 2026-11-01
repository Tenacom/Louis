#### [Louis](README.md 'README')
### [Louis](Louis.md 'Louis')

## RangeCheck Class

Provides methods to perform range checks and for constraining values to be within ranges\.

```csharp
public static class RangeCheck
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → RangeCheck
### Methods

<a name='Louis.RangeCheck.Clamp_T_(T,T,T)'></a>

## RangeCheck\.Clamp\<T\>\(T, T, T\) Method

Returns [value](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T).value 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T\)\.value') clamped to the inclusive range
of [min](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T).min 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T\)\.min') and [max](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T).max 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T\)\.max')\.

```csharp
public static T Clamp<T>(T value, T min, T max)
    where T : System.IComparable<T>;
```
#### Type parameters

<a name='Louis.RangeCheck.Clamp_T_(T,T,T).T'></a>

`T`

The type of the values being compared\.
#### Parameters

<a name='Louis.RangeCheck.Clamp_T_(T,T,T).value'></a>

`value` [T](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T).T 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T\)\.T')

The value being clamped\.

<a name='Louis.RangeCheck.Clamp_T_(T,T,T).min'></a>

`min` [T](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T).T 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T\)\.T')

The inclusive lower bound of the range\.

<a name='Louis.RangeCheck.Clamp_T_(T,T,T).max'></a>

`max` [T](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T).T 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T\)\.T')

The inclusive upper bound of the range\.

#### Returns
[T](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T).T 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T\)\.T')  

If [value](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T).value 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T\)\.value') < [min](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T).min 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T\)\.min'), [min](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T).min 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T\)\.min').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T).value 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T\)\.value') > [max](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T).max 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T\)\.max'), [max](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T).max 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T\)\.max').

Otherwise, [value](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T).value 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T\)\.value').

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[min](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T).min 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T\)\.min') is greater than [max](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T).max 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T\)\.max')\.

<a name='Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_)'></a>

## RangeCheck\.Clamp\<T\>\(T, T, T, IComparer\<T\>\) Method

Returns [value](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.value') clamped to the inclusive range
of [min](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.min') and [max](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.max'),
using the specified [comparer](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).comparer 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.comparer')\.

```csharp
public static T Clamp<T>(T value, T min, T max, System.Collections.Generic.IComparer<T> comparer)
    where T : notnull;
```
#### Type parameters

<a name='Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).T'></a>

`T`

The type of the values being compared\.
#### Parameters

<a name='Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).value'></a>

`value` [T](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The value being clamped\.

<a name='Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).min'></a>

`min` [T](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The inclusive lower bound of the range\.

<a name='Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).max'></a>

`max` [T](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The inclusive upper bound of the range\.

<a name='Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')

An [IComparer&lt;T&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')
            to use for comparisons\.

#### Returns
[T](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')  

If [value](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.value') < [min](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.min'), [min](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.min').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.value') > [max](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.max'), [max](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.max').

Otherwise, [value](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.value').

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[comparer](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).comparer 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.comparer') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[min](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.min') is greater than [max](Louis.RangeCheck.md#Louis.RangeCheck.Clamp_T_(T,T,T,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.Clamp\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.max')\.

<a name='Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T)'></a>

## RangeCheck\.ClampOrNull\<T\>\(Nullable\<T\>, T, T\) Method

Returns [value](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).value 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T\)\.value'), if it is not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'),
clamped to the inclusive range of [min](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).min 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T\)\.min') and [max](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).max 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T\)\.max')\.

```csharp
public static System.Nullable<T> ClampOrNull<T>(System.Nullable<T> value, T min, T max)
    where T : struct, System.IComparable<T>;
```
#### Type parameters

<a name='Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).T'></a>

`T`

The type of the values being compared\.
#### Parameters

<a name='Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).value'></a>

`value` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).T 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The value being clamped\.

<a name='Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).min'></a>

`min` [T](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).T 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T\)\.T')

The inclusive lower bound of the range\.

<a name='Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).max'></a>

`max` [T](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).T 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T\)\.T')

The inclusive upper bound of the range\.

#### Returns
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).T 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')  

If [value](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).value 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T\)\.value') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).value 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T\)\.value') < [min](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).min 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T\)\.min'), [min](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).min 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T\)\.min').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).value 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T\)\.value') > [max](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).max 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T\)\.max'), [max](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).max 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T\)\.max').

Otherwise, [value](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).value 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T\)\.value').

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[min](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).min 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T\)\.min') is greater than [max](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T).max 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T\)\.max')\.

<a name='Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_)'></a>

## RangeCheck\.ClampOrNull\<T\>\(Nullable\<T\>, T, T, IComparer\<T\>\) Method

Returns [value](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.value'), if it is not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'),
clamped to the inclusive range of [min](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.min') and [max](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.max'),
using the specified [comparer](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).comparer 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.comparer')\.

```csharp
public static System.Nullable<T> ClampOrNull<T>(System.Nullable<T> value, T min, T max, System.Collections.Generic.IComparer<T> comparer)
    where T : struct;
```
#### Type parameters

<a name='Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).T'></a>

`T`

The type of the values being compared\.
#### Parameters

<a name='Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).value'></a>

`value` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The value being clamped\.

<a name='Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).min'></a>

`min` [T](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The inclusive lower bound of the range\.

<a name='Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).max'></a>

`max` [T](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The inclusive upper bound of the range\.

<a name='Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')

An [IComparer&lt;T&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')
            to use for comparisons\.

#### Returns
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')  

If [value](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.value') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.value') < [min](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.min'), [min](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.min').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.value') > [max](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.max'), [max](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.max').

Otherwise, [value](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.value').

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[comparer](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).comparer 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.comparer') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[min](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.min') is greater than [max](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(System.Nullable_T_,T,T,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.ClampOrNull\<T\>\(System\.Nullable\<T\>, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.max')\.

<a name='Louis.RangeCheck.ClampOrNull_T_(T,T,T)'></a>

## RangeCheck\.ClampOrNull\<T\>\(T, T, T\) Method

Returns [value](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T).value 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T\)\.value'), if it is not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'),
clamped to the inclusive range of [min](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T).min 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T\)\.min') and [max](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T).max 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T\)\.max')\.

```csharp
public static T? ClampOrNull<T>(T? value, T min, T max)
    where T : class, System.IComparable<T>;
```
#### Type parameters

<a name='Louis.RangeCheck.ClampOrNull_T_(T,T,T).T'></a>

`T`

The type of the values being compared\.
#### Parameters

<a name='Louis.RangeCheck.ClampOrNull_T_(T,T,T).value'></a>

`value` [T](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T).T 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T\)\.T')

The value being clamped\.

<a name='Louis.RangeCheck.ClampOrNull_T_(T,T,T).min'></a>

`min` [T](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T).T 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T\)\.T')

The inclusive lower bound of the range\.

<a name='Louis.RangeCheck.ClampOrNull_T_(T,T,T).max'></a>

`max` [T](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T).T 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T\)\.T')

The inclusive upper bound of the range\.

#### Returns
[T](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T).T 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T\)\.T')  

If [value](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T).value 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T\)\.value') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T).value 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T\)\.value') < [min](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T).min 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T\)\.min'), [min](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T).min 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T\)\.min').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T).value 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T\)\.value') > [max](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T).max 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T\)\.max'), [max](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T).max 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T\)\.max').

Otherwise, [value](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T).value 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T\)\.value').

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[min](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T).min 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T\)\.min') is greater than [max](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T).max 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T\)\.max')\.

<a name='Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_)'></a>

## RangeCheck\.ClampOrNull\<T\>\(T, T, T, IComparer\<T\>\) Method

Returns [value](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.value'), if it is not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'),
clamped to the inclusive range of [min](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.min') and [max](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.max'),
using the specified [comparer](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).comparer 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.comparer')\.

```csharp
public static T? ClampOrNull<T>(T? value, T min, T max, System.Collections.Generic.IComparer<T> comparer)
    where T : class;
```
#### Type parameters

<a name='Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).T'></a>

`T`

The type of the values being compared\.
#### Parameters

<a name='Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).value'></a>

`value` [T](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The value being clamped\.

<a name='Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).min'></a>

`min` [T](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The inclusive lower bound of the range\.

<a name='Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).max'></a>

`max` [T](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The inclusive upper bound of the range\.

<a name='Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')

An [IComparer&lt;T&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')
            to use for comparisons\.

#### Returns
[T](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')  

If [value](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.value') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.value') < [min](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.min'), [min](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.min').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.value') > [max](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.max'), [max](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.max').

Otherwise, [value](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.value').

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[comparer](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).comparer 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.comparer') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[min](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.min') is greater than [max](Louis.RangeCheck.md#Louis.RangeCheck.ClampOrNull_T_(T,T,T,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.ClampOrNull\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.max')\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool)'></a>

## RangeCheck\.InRangeOrDefault\<T\>\(Nullable\<T\>, T, T, Nullable\<T\>, bool\) Method

Returns a value if it is within an inclusive range, or a default value otherwise\.

```csharp
public static System.Nullable<T> InRangeOrDefault<T>(System.Nullable<T> value, T min, T max, System.Nullable<T> defaultValue, bool acceptNull)
    where T : struct, System.IComparable<T>;
```
#### Type parameters

<a name='Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).T'></a>

`T`

The type of the values being compared\.
#### Parameters

<a name='Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).value'></a>

`value` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The value being checked\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).min'></a>

`min` [T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool\)\.T')

The inclusive lower bound of the range\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).max'></a>

`max` [T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool\)\.T')

The inclusive upper bound of the range\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).defaultValue'></a>

`defaultValue` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The value to return if [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool\)\.value')
            is not within the specified range\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).acceptNull'></a>

`acceptNull` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to consider [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') values
            as if within range; [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') otherwise\.

#### Returns
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')  

If [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool\)\.value') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') and [acceptNull](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).acceptNull 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool\)\.acceptNull') is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool\)\.value') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') and [acceptNull](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).acceptNull 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool\)\.acceptNull') is [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), [defaultValue](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).defaultValue 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool\)\.defaultValue').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool\)\.value') is within [min](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).min 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool\)\.min') and [max](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).max 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool\)\.max'), including boundaries, [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool\)\.value').

Otherwise, [defaultValue](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).defaultValue 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool\)\.defaultValue').

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[min](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).min 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool\)\.min') is greater than [max](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool).max 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool\)\.max')\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_)'></a>

## RangeCheck\.InRangeOrDefault\<T\>\(Nullable\<T\>, T, T, Nullable\<T\>, bool, IComparer\<T\>\) Method

Returns a value if it is within an inclusive range, or a default value otherwise,
using a specified [comparer](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).comparer 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.comparer')\.

```csharp
public static System.Nullable<T> InRangeOrDefault<T>(System.Nullable<T> value, T min, T max, System.Nullable<T> defaultValue, bool acceptNull, System.Collections.Generic.IComparer<T> comparer)
    where T : struct;
```
#### Type parameters

<a name='Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).T'></a>

`T`

The type of the values being compared\.
#### Parameters

<a name='Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).value'></a>

`value` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The value being checked\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).min'></a>

`min` [T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The inclusive lower bound of the range\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).max'></a>

`max` [T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The inclusive upper bound of the range\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).defaultValue'></a>

`defaultValue` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The value to return if [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.value')
            is not within the specified range\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).acceptNull'></a>

`acceptNull` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to consider [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') values
            as if within range; [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') otherwise\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')

The comparer to use for comparisons\.

#### Returns
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')  

If [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.value') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') and [acceptNull](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).acceptNull 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.acceptNull') is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.value') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') and [acceptNull](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).acceptNull 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.acceptNull') is [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), [defaultValue](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).defaultValue 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.defaultValue').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.value') is within [min](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.min') and [max](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.max'), including boundaries, [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.value').

Otherwise, [defaultValue](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).defaultValue 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.defaultValue').

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[comparer](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).comparer 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.comparer') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[min](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.min') is greater than [max](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(System.Nullable_T_,T,T,System.Nullable_T_,bool,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(System\.Nullable\<T\>, T, T, System\.Nullable\<T\>, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.max')\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T)'></a>

## RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T\) Method

Returns a value if it is within an inclusive range, or a default value otherwise\.

```csharp
public static T InRangeOrDefault<T>(T value, T min, T max, T defaultValue)
    where T : System.IComparable<T>;
```
#### Type parameters

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T).T'></a>

`T`

The type of the values being compared\.
#### Parameters

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T).value'></a>

`value` [T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T\)\.T')

The value being checked\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T).min'></a>

`min` [T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T\)\.T')

The inclusive lower bound of the range\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T).max'></a>

`max` [T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T\)\.T')

The inclusive upper bound of the range\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T).defaultValue'></a>

`defaultValue` [T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T\)\.T')

The value to return if [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T\)\.value')
            is not within the specified range\.

#### Returns
[T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T\)\.T')  
If [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T\)\.value') is within [min](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T).min 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T\)\.min') and [max](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T).max 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T\)\.max'), including boundaries, [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T\)\.value');
otherwise, [defaultValue](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T).defaultValue 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T\)\.defaultValue')\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[min](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T).min 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T\)\.min') is greater than [max](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T).max 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T\)\.max')\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool)'></a>

## RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool\) Method

Returns a value if it is within an inclusive range, or a default value otherwise\.

```csharp
public static T? InRangeOrDefault<T>(T? value, T min, T max, T? defaultValue, bool acceptNull)
    where T : class, System.IComparable<T>;
```
#### Type parameters

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).T'></a>

`T`

The type of the values being compared\.
#### Parameters

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).value'></a>

`value` [T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool\)\.T')

The value being checked\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).min'></a>

`min` [T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool\)\.T')

The inclusive lower bound of the range\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).max'></a>

`max` [T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool\)\.T')

The inclusive upper bound of the range\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).defaultValue'></a>

`defaultValue` [T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool\)\.T')

The value to return if [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool\)\.value')
            is not within the specified range\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).acceptNull'></a>

`acceptNull` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to consider [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') values
            as if within range; [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') otherwise\.

#### Returns
[T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool\)\.T')  

If [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool\)\.value') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') and [acceptNull](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).acceptNull 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool\)\.acceptNull') is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool\)\.value') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') and [acceptNull](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).acceptNull 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool\)\.acceptNull') is [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), [defaultValue](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).defaultValue 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool\)\.defaultValue').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool\)\.value') is within [min](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).min 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool\)\.min') and [max](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).max 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool\)\.max'), including boundaries, [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool\)\.value').

Otherwise, [defaultValue](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).defaultValue 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool\)\.defaultValue').

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[min](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).min 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool\)\.min') is greater than [max](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool).max 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool\)\.max')\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_)'></a>

## RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, IComparer\<T\>\) Method

Returns a value if it is within an inclusive range, or a default value otherwise,
using a specified [comparer](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).comparer 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.comparer')\.

```csharp
public static T? InRangeOrDefault<T>(T? value, T min, T max, T? defaultValue, bool acceptNull, System.Collections.Generic.IComparer<T> comparer)
    where T : class;
```
#### Type parameters

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).T'></a>

`T`

The type of the values being compared\.
#### Parameters

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).value'></a>

`value` [T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The value being checked\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).min'></a>

`min` [T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The inclusive lower bound of the range\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).max'></a>

`max` [T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The inclusive upper bound of the range\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).defaultValue'></a>

`defaultValue` [T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The value to return if [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.value')
            is not within the specified range\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).acceptNull'></a>

`acceptNull` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to consider [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') values
            as if within range; [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') otherwise\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')

The comparer to use for comparisons\.

#### Returns
[T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.T')  

If [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.value') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') and [acceptNull](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).acceptNull 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.acceptNull') is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.value') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') and [acceptNull](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).acceptNull 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.acceptNull') is [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), [defaultValue](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).defaultValue 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.defaultValue').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.value') is within [min](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.min') and [max](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.max'), including boundaries, [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.value').

Otherwise, [defaultValue](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).defaultValue 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.defaultValue').

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[comparer](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).comparer 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.comparer') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[min](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.min') is greater than [max](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,bool,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.max')\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_)'></a>

## RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, IComparer\<T\>\) Method

Returns a value if it is within an inclusive range, or a default value otherwise,
using a specified [comparer](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).comparer 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.comparer')\.

```csharp
public static T InRangeOrDefault<T>(T value, T min, T max, T defaultValue, System.Collections.Generic.IComparer<T> comparer)
    where T : notnull;
```
#### Type parameters

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).T'></a>

`T`

The type of the values being compared\.
#### Parameters

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).value'></a>

`value` [T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The value being checked\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).min'></a>

`min` [T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The inclusive lower bound of the range\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).max'></a>

`max` [T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The inclusive upper bound of the range\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).defaultValue'></a>

`defaultValue` [T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The value to return if [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.value')
            is not within the specified range\.

<a name='Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')

The comparer to use for comparisons\.

#### Returns
[T](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')  
If [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.value') is within [min](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.min') and [max](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.max'), including boundaries, [value](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.value');
otherwise, [defaultValue](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).defaultValue 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.defaultValue')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[comparer](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).comparer 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.comparer') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[min](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.min') is greater than [max](Louis.RangeCheck.md#Louis.RangeCheck.InRangeOrDefault_T_(T,T,T,T,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.InRangeOrDefault\<T\>\(T, T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.max')\.

<a name='Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool)'></a>

## RangeCheck\.Verify\<T\>\(Nullable\<T\>, T, T, bool\) Method

Checks whether a nullable value is within an inclusive range,
accepting or rejecting [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') values according to the
value of the [acceptNull](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool).acceptNull 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool\)\.acceptNull') parameter\.

```csharp
public static bool Verify<T>(System.Nullable<T> value, T min, T max, bool acceptNull)
    where T : struct, System.IComparable<T>;
```
#### Type parameters

<a name='Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool).T'></a>

`T`

The type of the values being compared\.
#### Parameters

<a name='Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool).value'></a>

`value` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool).T 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The value being checked\.

<a name='Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool).min'></a>

`min` [T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool).T 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool\)\.T')

The inclusive lower bound of the range\.

<a name='Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool).max'></a>

`max` [T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool).T 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool\)\.T')

The inclusive upper bound of the range\.

<a name='Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool).acceptNull'></a>

`acceptNull` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The Boolean value to return when [value](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool).value 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool\)\.value') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  

If [value](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool).value 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool\)\.value') is not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'):
            [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if [value](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool).value 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool\)\.value') is within [min](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool).min 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool\)\.min')
            and [max](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool).max 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool\)\.max'), including boundaries; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool).value 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool\)\.value') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'):
            the value passed in [acceptNull](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool).acceptNull 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool\)\.acceptNull').

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[min](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool).min 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool\)\.min') is greater than [max](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool).max 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool\)\.max')\.

<a name='Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_)'></a>

## RangeCheck\.Verify\<T\>\(Nullable\<T\>, T, T, bool, IComparer\<T\>\) Method

Checks whether a nullable value is within an inclusive range,
using the specified [comparer](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).comparer 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.comparer'), and
accepting or rejecting [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') values according to the
value of the [acceptNull](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).acceptNull 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.acceptNull') parameter\.

```csharp
public static bool Verify<T>(System.Nullable<T> value, T min, T max, bool acceptNull, System.Collections.Generic.IComparer<T> comparer)
    where T : struct;
```
#### Type parameters

<a name='Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).T'></a>

`T`

The type of the values being compared\.
#### Parameters

<a name='Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).value'></a>

`value` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The value being checked\.

<a name='Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).min'></a>

`min` [T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The inclusive lower bound of the range\.

<a name='Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).max'></a>

`max` [T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The inclusive upper bound of the range\.

<a name='Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).acceptNull'></a>

`acceptNull` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The Boolean value to return when [value](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.value') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')

The comparer to use for comparisons\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  

If [value](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.value') is not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'):
            [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if [value](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.value') is within [min](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.min')
            and [max](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.max'), including boundaries; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.value') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'):
            the value passed in [acceptNull](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).acceptNull 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.acceptNull').

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[comparer](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).comparer 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.comparer') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[min](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.min') is greater than [max](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(System.Nullable_T_,T,T,bool,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.Verify\<T\>\(System\.Nullable\<T\>, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.max')\.

<a name='Louis.RangeCheck.Verify_T_(T,T,T)'></a>

## RangeCheck\.Verify\<T\>\(T, T, T\) Method

Checks whether a value is within an inclusive range\.

```csharp
public static bool Verify<T>(T value, T min, T max)
    where T : System.IComparable<T>;
```
#### Type parameters

<a name='Louis.RangeCheck.Verify_T_(T,T,T).T'></a>

`T`

The type of the values being compared\.
#### Parameters

<a name='Louis.RangeCheck.Verify_T_(T,T,T).value'></a>

`value` [T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T).T 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T\)\.T')

The value being checked\.

<a name='Louis.RangeCheck.Verify_T_(T,T,T).min'></a>

`min` [T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T).T 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T\)\.T')

The inclusive lower bound of the range\.

<a name='Louis.RangeCheck.Verify_T_(T,T,T).max'></a>

`max` [T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T).T 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T\)\.T')

The inclusive upper bound of the range\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if [value](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T).value 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T\)\.value') is within [min](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T).min 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T\)\.min')
            and [max](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T).max 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T\)\.max'), including boundaries; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[min](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T).min 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T\)\.min') is greater than [max](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T).max 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T\)\.max')\.

<a name='Louis.RangeCheck.Verify_T_(T,T,T,bool)'></a>

## RangeCheck\.Verify\<T\>\(T, T, T, bool\) Method

Checks whether a nullable value is within an inclusive range,
accepting or rejecting [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') values according to the
value of the [acceptNull](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool).acceptNull 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool\)\.acceptNull') parameter\.

```csharp
public static bool Verify<T>(T? value, T min, T max, bool acceptNull)
    where T : class, System.IComparable<T>;
```
#### Type parameters

<a name='Louis.RangeCheck.Verify_T_(T,T,T,bool).T'></a>

`T`

The type of the values being compared\.
#### Parameters

<a name='Louis.RangeCheck.Verify_T_(T,T,T,bool).value'></a>

`value` [T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool).T 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool\)\.T')

The value being checked\.

<a name='Louis.RangeCheck.Verify_T_(T,T,T,bool).min'></a>

`min` [T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool).T 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool\)\.T')

The inclusive lower bound of the range\.

<a name='Louis.RangeCheck.Verify_T_(T,T,T,bool).max'></a>

`max` [T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool).T 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool\)\.T')

The inclusive upper bound of the range\.

<a name='Louis.RangeCheck.Verify_T_(T,T,T,bool).acceptNull'></a>

`acceptNull` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The Boolean value to return when [value](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool).value 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool\)\.value') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  

If [value](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool).value 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool\)\.value') is not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'):
            [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if [value](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool).value 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool\)\.value') is within [min](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool).min 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool\)\.min')
            and [max](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool).max 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool\)\.max'), including boundaries; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool).value 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool\)\.value') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'):
            the value passed in [acceptNull](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool).acceptNull 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool\)\.acceptNull').

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[min](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool).min 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool\)\.min') is greater than [max](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool).max 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool\)\.max')\.

<a name='Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_)'></a>

## RangeCheck\.Verify\<T\>\(T, T, T, bool, IComparer\<T\>\) Method

Checks whether a nullable value is within an inclusive range,
using the specified [comparer](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).comparer 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.comparer'), and
accepting or rejecting [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') values according to the
value of the [acceptNull](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).acceptNull 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.acceptNull') parameter\.

```csharp
public static bool Verify<T>(T? value, T min, T max, bool acceptNull, System.Collections.Generic.IComparer<T> comparer)
    where T : class;
```
#### Type parameters

<a name='Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).T'></a>

`T`

The type of the values being compared\.
#### Parameters

<a name='Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).value'></a>

`value` [T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The value being checked\.

<a name='Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).min'></a>

`min` [T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The inclusive lower bound of the range\.

<a name='Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).max'></a>

`max` [T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The inclusive upper bound of the range\.

<a name='Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).acceptNull'></a>

`acceptNull` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The Boolean value to return when [value](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.value') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')

The comparer to use for comparisons\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  

If [value](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.value') is not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'):
            [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if [value](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.value') is within [min](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.min')
            and [max](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.max'), including boundaries; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool').

If [value](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.value') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'):
            the value passed in [acceptNull](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).acceptNull 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.acceptNull').

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[comparer](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).comparer 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.comparer') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[min](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.min') is greater than [max](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,bool,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, bool, System\.Collections\.Generic\.IComparer\<T\>\)\.max')\.

<a name='Louis.RangeCheck.Verify_T_(T,T,T,System.Collections.Generic.IComparer_T_)'></a>

## RangeCheck\.Verify\<T\>\(T, T, T, IComparer\<T\>\) Method

Checks whether a value is within an inclusive range,
using the specified [comparer](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,System.Collections.Generic.IComparer_T_).comparer 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.comparer')\.

```csharp
public static bool Verify<T>(T value, T min, T max, System.Collections.Generic.IComparer<T> comparer)
    where T : notnull;
```
#### Type parameters

<a name='Louis.RangeCheck.Verify_T_(T,T,T,System.Collections.Generic.IComparer_T_).T'></a>

`T`

The type of the values being compared\.
#### Parameters

<a name='Louis.RangeCheck.Verify_T_(T,T,T,System.Collections.Generic.IComparer_T_).value'></a>

`value` [T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The value being checked\.

<a name='Louis.RangeCheck.Verify_T_(T,T,T,System.Collections.Generic.IComparer_T_).min'></a>

`min` [T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The inclusive lower bound of the range\.

<a name='Louis.RangeCheck.Verify_T_(T,T,T,System.Collections.Generic.IComparer_T_).max'></a>

`max` [T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')

The inclusive upper bound of the range\.

<a name='Louis.RangeCheck.Verify_T_(T,T,T,System.Collections.Generic.IComparer_T_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[T](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,System.Collections.Generic.IComparer_T_).T 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')

The comparer to use for comparisons\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if [value](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,System.Collections.Generic.IComparer_T_).value 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.value') is within [min](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.min')
            and [max](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.max'), including boundaries; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[comparer](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,System.Collections.Generic.IComparer_T_).comparer 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.comparer') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[min](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,System.Collections.Generic.IComparer_T_).min 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.min') is greater than [max](Louis.RangeCheck.md#Louis.RangeCheck.Verify_T_(T,T,T,System.Collections.Generic.IComparer_T_).max 'Louis\.RangeCheck\.Verify\<T\>\(T, T, T, System\.Collections\.Generic\.IComparer\<T\>\)\.max')\.