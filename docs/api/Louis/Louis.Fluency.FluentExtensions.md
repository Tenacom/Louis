#### [Louis](README.md 'README')
### [Louis\.Fluency](Louis.Fluency.md 'Louis\.Fluency')

## FluentExtensions Class

Provides generic extension methods to perform simple operations with fluent syntax\.

```csharp
public static class FluentExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → FluentExtensions
### Methods

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_)'></a>

## FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\) Method

Invokes a chainable method on an object and additional arguments\.

```csharp
public static T Chain<T,TArg1,TArg2,TArg3,TArg4>(this T @this, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, Louis.Fluency.FluentAction<T,TArg1,TArg2,TArg3,TArg4> func);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).TArg1'></a>

`TArg1`

The type of the first additional parameter to [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.func')\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).TArg2'></a>

`TArg2`

The type of the second additional parameter to [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.func')\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).TArg3'></a>

`TArg3`

The type of the third additional parameter to [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.func')\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).TArg4'></a>

`TArg4`

The type of the fourth additional parameter to [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.func')\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).T 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).arg1'></a>

`arg1` [TArg1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).TArg1 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg1')

The first additional argument to pass to [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.func')\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).arg2'></a>

`arg2` [TArg2](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).TArg2 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg2')

The second additional argument to pass to [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.func')\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).arg3'></a>

`arg3` [TArg3](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).TArg3 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg3')

The third additional argument to pass to [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.func')\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).arg4'></a>

`arg4` [TArg4](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).TArg4 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg4')

The fourth additional argument to pass to [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.func')\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).func'></a>

`func` [Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\(T, TArg1, TArg2, TArg3, TArg4\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).T 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.T')[,](Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\(T, TArg1, TArg2, TArg3, TArg4\)')[TArg1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).TArg1 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg1')[,](Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\(T, TArg1, TArg2, TArg3, TArg4\)')[TArg2](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).TArg2 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg2')[,](Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\(T, TArg1, TArg2, TArg3, TArg4\)')[TArg3](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).TArg3 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg3')[,](Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\(T, TArg1, TArg2, TArg3, TArg4\)')[TArg4](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).TArg4 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg4')[&gt;](Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\(T, TArg1, TArg2, TArg3, TArg4\)')

The chainable method to invoke on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).this 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.this')\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).T 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.T')  
The reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).this 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.this') returned by [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.func')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).this 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\)\.func') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_)'></a>

## FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, FluentAction\<T,TArg1,TArg2,TArg3\>\) Method

Invokes a chainable method on an object and additional arguments\.

```csharp
public static T Chain<T,TArg1,TArg2,TArg3>(this T @this, TArg1 arg1, TArg2 arg2, TArg3 arg3, Louis.Fluency.FluentAction<T,TArg1,TArg2,TArg3> func);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).TArg1'></a>

`TArg1`

The type of the first additional parameter to [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\)\.func')\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).TArg2'></a>

`TArg2`

The type of the second additional parameter to [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\)\.func')\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).TArg3'></a>

`TArg3`

The type of the third additional parameter to [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\)\.func')\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).T 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).arg1'></a>

`arg1` [TArg1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).TArg1 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\)\.TArg1')

The first additional argument to pass to [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\)\.func')\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).arg2'></a>

`arg2` [TArg2](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).TArg2 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\)\.TArg2')

The second additional argument to pass to [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\)\.func')\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).arg3'></a>

`arg3` [TArg3](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).TArg3 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\)\.TArg3')

The third additional argument to pass to [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\)\.func')\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).func'></a>

`func` [Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_(T,TArg1,TArg2,TArg3).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\(T, TArg1, TArg2, TArg3\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).T 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\)\.T')[,](Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_(T,TArg1,TArg2,TArg3).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\(T, TArg1, TArg2, TArg3\)')[TArg1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).TArg1 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\)\.TArg1')[,](Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_(T,TArg1,TArg2,TArg3).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\(T, TArg1, TArg2, TArg3\)')[TArg2](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).TArg2 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\)\.TArg2')[,](Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_(T,TArg1,TArg2,TArg3).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\(T, TArg1, TArg2, TArg3\)')[TArg3](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).TArg3 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\)\.TArg3')[&gt;](Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_(T,TArg1,TArg2,TArg3).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\(T, TArg1, TArg2, TArg3\)')

The chainable method to invoke on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).this 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\)\.this')\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).T 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\)\.T')  
The reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).this 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\)\.this') returned by [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\)\.func')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).this 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3\>\)\.func') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_)'></a>

## FluentExtensions\.Chain\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, FluentAction\<T,TArg1,TArg2\>\) Method

Invokes a chainable method on an object and additional arguments\.

```csharp
public static T Chain<T,TArg1,TArg2>(this T @this, TArg1 arg1, TArg2 arg2, Louis.Fluency.FluentAction<T,TArg1,TArg2> func);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).TArg1'></a>

`TArg1`

The type of the first additional parameter to [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\)\.func')\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).TArg2'></a>

`TArg2`

The type of the second additional parameter to [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\)\.func')\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).T 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).arg1'></a>

`arg1` [TArg1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).TArg1 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\)\.TArg1')

The first additional argument to pass to [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\)\.func')\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).arg2'></a>

`arg2` [TArg2](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).TArg2 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\)\.TArg2')

The second additional argument to pass to [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\)\.func')\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).func'></a>

`func` [Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T,TArg1,TArg2_(T,TArg1,TArg2).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\(T, TArg1, TArg2\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).T 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\)\.T')[,](Louis.Fluency.FluentAction_T,TArg1,TArg2_(T,TArg1,TArg2).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\(T, TArg1, TArg2\)')[TArg1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).TArg1 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\)\.TArg1')[,](Louis.Fluency.FluentAction_T,TArg1,TArg2_(T,TArg1,TArg2).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\(T, TArg1, TArg2\)')[TArg2](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).TArg2 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\)\.TArg2')[&gt;](Louis.Fluency.FluentAction_T,TArg1,TArg2_(T,TArg1,TArg2).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\(T, TArg1, TArg2\)')

The chainable method to invoke on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).this 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\)\.this')\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).T 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\)\.T')  
The reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).this 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\)\.this') returned by [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\)\.func')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).this 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg1,TArg2_(thisT,TArg1,TArg2,Louis.Fluency.FluentAction_T,TArg1,TArg2_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\)\.func') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg_(thisT,TArg,Louis.Fluency.FluentAction_T,TArg_)'></a>

## FluentExtensions\.Chain\<T,TArg\>\(this T, TArg, FluentAction\<T,TArg\>\) Method

Invokes a chainable method on an object and an additional argument\.

```csharp
public static T Chain<T,TArg>(this T @this, TArg arg, Louis.Fluency.FluentAction<T,TArg> func);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg_(thisT,TArg,Louis.Fluency.FluentAction_T,TArg_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg_(thisT,TArg,Louis.Fluency.FluentAction_T,TArg_).TArg'></a>

`TArg`

The type of the additional parameter to [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg_(thisT,TArg,Louis.Fluency.FluentAction_T,TArg_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg\>\(this T, TArg, Louis\.Fluency\.FluentAction\<T,TArg\>\)\.func')\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg_(thisT,TArg,Louis.Fluency.FluentAction_T,TArg_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg_(thisT,TArg,Louis.Fluency.FluentAction_T,TArg_).T 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg\>\(this T, TArg, Louis\.Fluency\.FluentAction\<T,TArg\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg_(thisT,TArg,Louis.Fluency.FluentAction_T,TArg_).arg'></a>

`arg` [TArg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg_(thisT,TArg,Louis.Fluency.FluentAction_T,TArg_).TArg 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg\>\(this T, TArg, Louis\.Fluency\.FluentAction\<T,TArg\>\)\.TArg')

The additional argument to pass to [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg_(thisT,TArg,Louis.Fluency.FluentAction_T,TArg_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg\>\(this T, TArg, Louis\.Fluency\.FluentAction\<T,TArg\>\)\.func')\.

<a name='Louis.Fluency.FluentExtensions.Chain_T,TArg_(thisT,TArg,Louis.Fluency.FluentAction_T,TArg_).func'></a>

`func` [Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg_(thisT,TArg,Louis.Fluency.FluentAction_T,TArg_).T 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg\>\(this T, TArg, Louis\.Fluency\.FluentAction\<T,TArg\>\)\.T')[,](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)')[TArg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg_(thisT,TArg,Louis.Fluency.FluentAction_T,TArg_).TArg 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg\>\(this T, TArg, Louis\.Fluency\.FluentAction\<T,TArg\>\)\.TArg')[&gt;](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)')

The chainable method to invoke on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg_(thisT,TArg,Louis.Fluency.FluentAction_T,TArg_).this 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg\>\(this T, TArg, Louis\.Fluency\.FluentAction\<T,TArg\>\)\.this')\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg_(thisT,TArg,Louis.Fluency.FluentAction_T,TArg_).T 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg\>\(this T, TArg, Louis\.Fluency\.FluentAction\<T,TArg\>\)\.T')  
The reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg_(thisT,TArg,Louis.Fluency.FluentAction_T,TArg_).this 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg\>\(this T, TArg, Louis\.Fluency\.FluentAction\<T,TArg\>\)\.this') returned by [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg_(thisT,TArg,Louis.Fluency.FluentAction_T,TArg_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg\>\(this T, TArg, Louis\.Fluency\.FluentAction\<T,TArg\>\)\.func')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg_(thisT,TArg,Louis.Fluency.FluentAction_T,TArg_).this 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg\>\(this T, TArg, Louis\.Fluency\.FluentAction\<T,TArg\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T,TArg_(thisT,TArg,Louis.Fluency.FluentAction_T,TArg_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T,TArg\>\(this T, TArg, Louis\.Fluency\.FluentAction\<T,TArg\>\)\.func') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.Chain_T_(thisT,Louis.Fluency.FluentAction_T_)'></a>

## FluentExtensions\.Chain\<T\>\(this T, FluentAction\<T\>\) Method

Invokes a chainable method on an object\.

```csharp
public static T Chain<T>(this T @this, Louis.Fluency.FluentAction<T> func);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.Chain_T_(thisT,Louis.Fluency.FluentAction_T_).T'></a>

`T`

The type of the object\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.Chain_T_(thisT,Louis.Fluency.FluentAction_T_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T_(thisT,Louis.Fluency.FluentAction_T_).T 'Louis\.Fluency\.FluentExtensions\.Chain\<T\>\(this T, Louis\.Fluency\.FluentAction\<T\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.Chain_T_(thisT,Louis.Fluency.FluentAction_T_).func'></a>

`func` [Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T_(T).md 'Louis\.Fluency\.FluentAction\<T\>\(T\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T_(thisT,Louis.Fluency.FluentAction_T_).T 'Louis\.Fluency\.FluentExtensions\.Chain\<T\>\(this T, Louis\.Fluency\.FluentAction\<T\>\)\.T')[&gt;](Louis.Fluency.FluentAction_T_(T).md 'Louis\.Fluency\.FluentAction\<T\>\(T\)')

The chainable method to invoke on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T_(thisT,Louis.Fluency.FluentAction_T_).this 'Louis\.Fluency\.FluentExtensions\.Chain\<T\>\(this T, Louis\.Fluency\.FluentAction\<T\>\)\.this')\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T_(thisT,Louis.Fluency.FluentAction_T_).T 'Louis\.Fluency\.FluentExtensions\.Chain\<T\>\(this T, Louis\.Fluency\.FluentAction\<T\>\)\.T')  
The reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T_(thisT,Louis.Fluency.FluentAction_T_).this 'Louis\.Fluency\.FluentExtensions\.Chain\<T\>\(this T, Louis\.Fluency\.FluentAction\<T\>\)\.this') returned by [func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T_(thisT,Louis.Fluency.FluentAction_T_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T\>\(this T, Louis\.Fluency\.FluentAction\<T\>\)\.func')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T_(thisT,Louis.Fluency.FluentAction_T_).this 'Louis\.Fluency\.FluentExtensions\.Chain\<T\>\(this T, Louis\.Fluency\.FluentAction\<T\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[func](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Chain_T_(thisT,Louis.Fluency.FluentAction_T_).func 'Louis\.Fluency\.FluentExtensions\.Chain\<T\>\(this T, Louis\.Fluency\.FluentAction\<T\>\)\.func') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement,int_)'></a>

## FluentExtensions\.ForEach\<T,TElement\>\(this T, IEnumerable\<TElement\>, FluentAction\<T,TElement,int\>\) Method

Performs a specified action on an object and each element of a sequence,
each time taking the result of the action as the object to pass together with the next element,
then returns the result of the last action\.

```csharp
public static T ForEach<T,TElement>(this T @this, System.Collections.Generic.IEnumerable<TElement> sequence, Louis.Fluency.FluentAction<T,TElement,int> action);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).TElement'></a>

`TElement`

The type of each element of the sequence\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).sequence'></a>

`sequence` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[TElement](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).TElement 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)\.TElement')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The sequence of elements\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).action'></a>

`action` [Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T,TArg1,TArg2_(T,TArg1,TArg2).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\(T, TArg1, TArg2\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)\.T')[,](Louis.Fluency.FluentAction_T,TArg1,TArg2_(T,TArg1,TArg2).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\(T, TArg1, TArg2\)')[TElement](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).TElement 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)\.TElement')[,](Louis.Fluency.FluentAction_T,TArg1,TArg2_(T,TArg1,TArg2).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\(T, TArg1, TArg2\)')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](Louis.Fluency.FluentAction_T,TArg1,TArg2_(T,TArg1,TArg2).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\(T, TArg1, TArg2\)')

The action to perform\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)\.T')  
The result of the last call to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).action 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)\.action')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).this 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).action 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)\.action') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[sequence](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).sequence 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)\.sequence') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

### Remarks

This method is essentially the same as [ForEach&lt;T,TElement&gt;\(this T, IEnumerable&lt;TElement&gt;, FluentAction&lt;T,TElement&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement_) 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)'),
            but it also passes an index to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).action 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)\.action'). The passed index is 0 for the first call and is incremented by 1
            for each subsequent call.

### See Also
- [ForEach&lt;T,TElement&gt;\(this T, IEnumerable&lt;TElement&gt;, Action&lt;T,TElement,int&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement,int_) 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement,int\>\)')
- [ForEach&lt;T,TElement&gt;\(this T, ReadOnlySpan&lt;TElement&gt;, FluentAction&lt;T,TElement,int&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement,int_) 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)')

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement_)'></a>

## FluentExtensions\.ForEach\<T,TElement\>\(this T, IEnumerable\<TElement\>, FluentAction\<T,TElement\>\) Method

Performs a specified action on an object and each element of a sequence,
each time taking the result of the action as the object to pass together with the next element,
then returns the result of the last action\.

```csharp
public static T ForEach<T,TElement>(this T @this, System.Collections.Generic.IEnumerable<TElement> sequence, Louis.Fluency.FluentAction<T,TElement> action);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement_).TElement'></a>

`TElement`

The type of each element of the sequence\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement_).sequence'></a>

`sequence` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[TElement](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement_).TElement 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)\.TElement')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The sequence of elements\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement_).action'></a>

`action` [Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)\.T')[,](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)')[TElement](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement_).TElement 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)\.TElement')[&gt;](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)')

The action to perform\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)\.T')  
The result of the last call to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement_).action 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)\.action')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement_).this 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement_).action 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)\.action') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[sequence](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement_).sequence 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)\.sequence') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

### See Also
- [ForEach&lt;T,TElement&gt;\(this T, IEnumerable&lt;TElement&gt;, Action&lt;T,TElement&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement_) 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement\>\)')
- [ForEach&lt;T,TElement&gt;\(this T, ReadOnlySpan&lt;TElement&gt;, FluentAction&lt;T,TElement&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement_) 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)')

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement,int_)'></a>

## FluentExtensions\.ForEach\<T,TElement\>\(this T, IEnumerable\<TElement\>, Action\<T,TElement,int\>\) Method

Performs a specified action on an object and each element of a sequence,
then returns the object\.

```csharp
public static T ForEach<T,TElement>(this T @this, System.Collections.Generic.IEnumerable<TElement> sequence, System.Action<T,TElement,int> action);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement,int_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement,int_).TElement'></a>

`TElement`

The type of each element of the sequence\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement,int_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement,int_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement,int\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement,int_).sequence'></a>

`sequence` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[TElement](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement,int_).TElement 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement,int\>\)\.TElement')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The sequence of elements\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement,int_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement,int_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement,int\>\)\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')[TElement](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement,int_).TElement 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement,int\>\)\.TElement')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')

The action to perform\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement,int_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement,int\>\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement,int_).this 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement,int\>\)\.this') after the last call to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement,int_).action 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement,int\>\)\.action') returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement,int_).this 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement,int\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement,int_).action 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement,int\>\)\.action') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[sequence](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement,int_).sequence 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement,int\>\)\.sequence') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

### Remarks

This method is essentially the same as [ForEach&lt;T,TElement&gt;\(this T, IEnumerable&lt;TElement&gt;, Action&lt;T,TElement&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement_) 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement\>\)'),
            but it also passes an index to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement,int_).action 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement,int\>\)\.action'). The passed index is 0 for the first call and is incremented by 1
            for each subsequent call.

### See Also
- [ForEach&lt;T,TElement&gt;\(this T, IEnumerable&lt;TElement&gt;, FluentAction&lt;T,TElement,int&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement,int_) 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)')
- [ForEach&lt;T,TElement&gt;\(this T, ReadOnlySpan&lt;TElement&gt;, Action&lt;T,TElement,int&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement,int_) 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement,int\>\)')

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement_)'></a>

## FluentExtensions\.ForEach\<T,TElement\>\(this T, IEnumerable\<TElement\>, Action\<T,TElement\>\) Method

Performs a specified action on an object and each element of a sequence,
then returns the object\.

```csharp
public static T ForEach<T,TElement>(this T @this, System.Collections.Generic.IEnumerable<TElement> sequence, System.Action<T,TElement> action);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement_).TElement'></a>

`TElement`

The type of each element of the sequence\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement_).sequence'></a>

`sequence` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[TElement](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement_).TElement 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement\>\)\.TElement')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The sequence of elements\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement\>\)\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[TElement](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement_).TElement 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement\>\)\.TElement')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')

The action to perform\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement\>\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement_).this 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement\>\)\.this') after the last call to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement_).action 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement\>\)\.action') returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement_).this 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement_).action 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement\>\)\.action') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[sequence](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement_).sequence 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement\>\)\.sequence') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

### See Also
- [ForEach&lt;T,TElement&gt;\(this T, IEnumerable&lt;TElement&gt;, FluentAction&lt;T,TElement&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement_) 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)')
- [ForEach&lt;T,TElement&gt;\(this T, ReadOnlySpan&lt;TElement&gt;, Action&lt;T,TElement&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement_) 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement\>\)')

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement,int_)'></a>

## FluentExtensions\.ForEach\<T,TElement\>\(this T, ReadOnlySpan\<TElement\>, FluentAction\<T,TElement,int\>\) Method

Performs a specified action on an object and each element of a span,
each time taking the result of the action as the object to pass together with the next element,
then returns the result of the last action\.

```csharp
public static T ForEach<T,TElement>(this T @this, System.ReadOnlySpan<TElement> span, Louis.Fluency.FluentAction<T,TElement,int> action);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).TElement'></a>

`TElement`

The type of each element of the span\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).span'></a>

`span` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[TElement](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).TElement 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)\.TElement')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The span of elements\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).action'></a>

`action` [Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T,TArg1,TArg2_(T,TArg1,TArg2).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\(T, TArg1, TArg2\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)\.T')[,](Louis.Fluency.FluentAction_T,TArg1,TArg2_(T,TArg1,TArg2).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\(T, TArg1, TArg2\)')[TElement](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).TElement 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)\.TElement')[,](Louis.Fluency.FluentAction_T,TArg1,TArg2_(T,TArg1,TArg2).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\(T, TArg1, TArg2\)')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](Louis.Fluency.FluentAction_T,TArg1,TArg2_(T,TArg1,TArg2).md 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2\>\(T, TArg1, TArg2\)')

The action to perform\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)\.T')  
The result of the last call to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).action 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)\.action')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).this 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).action 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)\.action') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

### Remarks

This method is essentially the same as [ForEach&lt;T,TElement&gt;\(this T, ReadOnlySpan&lt;TElement&gt;, FluentAction&lt;T,TElement&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement_) 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)'),
            but it also passes the index of each element to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement,int_).action 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)\.action').

### See Also
- [ForEach&lt;T,TElement&gt;\(this T, ReadOnlySpan&lt;TElement&gt;, Action&lt;T,TElement,int&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement,int_) 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement,int\>\)')
- [ForEach&lt;T,TElement&gt;\(this T, IEnumerable&lt;TElement&gt;, FluentAction&lt;T,TElement,int&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement,int_) 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)')

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement_)'></a>

## FluentExtensions\.ForEach\<T,TElement\>\(this T, ReadOnlySpan\<TElement\>, FluentAction\<T,TElement\>\) Method

Performs a specified action on an object and each element of a span,
each time taking the result of the action as the object to pass together with the next element,
then returns the result of the last action\.

```csharp
public static T ForEach<T,TElement>(this T @this, System.ReadOnlySpan<TElement> span, Louis.Fluency.FluentAction<T,TElement> action);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement_).TElement'></a>

`TElement`

The type of each element of the span\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement_).span'></a>

`span` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[TElement](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement_).TElement 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)\.TElement')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The span of elements\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement_).action'></a>

`action` [Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)\.T')[,](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)')[TElement](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement_).TElement 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)\.TElement')[&gt;](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)')

The action to perform\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)\.T')  
The result of the last call to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement_).action 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)\.action')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement_).this 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement_).action 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)\.action') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

### See Also
- [ForEach&lt;T,TElement&gt;\(this T, ReadOnlySpan&lt;TElement&gt;, Action&lt;T,TElement&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement_) 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement\>\)')
- [ForEach&lt;T,TElement&gt;\(this T, IEnumerable&lt;TElement&gt;, FluentAction&lt;T,TElement&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,Louis.Fluency.FluentAction_T,TElement_) 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)')

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement,int_)'></a>

## FluentExtensions\.ForEach\<T,TElement\>\(this T, ReadOnlySpan\<TElement\>, Action\<T,TElement,int\>\) Method

Performs a specified action on an object and each element of a span,
then returns the object\.

```csharp
public static T ForEach<T,TElement>(this T @this, System.ReadOnlySpan<TElement> span, System.Action<T,TElement,int> action);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement,int_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement,int_).TElement'></a>

`TElement`

The type of each element of the span\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement,int_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement,int_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement,int\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement,int_).span'></a>

`span` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[TElement](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement,int_).TElement 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement,int\>\)\.TElement')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The span of elements\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement,int_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement,int_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement,int\>\)\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')[TElement](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement,int_).TElement 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement,int\>\)\.TElement')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')

The action to perform\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement,int_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement,int\>\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement,int_).this 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement,int\>\)\.this') after the last call to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement,int_).action 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement,int\>\)\.action') returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement,int_).this 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement,int\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement,int_).action 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement,int\>\)\.action') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

### Remarks

This method is essentially the same as [ForEach&lt;T,TElement&gt;\(this T, ReadOnlySpan&lt;TElement&gt;, Action&lt;T,TElement&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement_) 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement\>\)'),
            but it also passes the index of each element to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement,int_).action 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement,int\>\)\.action').

### See Also
- [ForEach&lt;T,TElement&gt;\(this T, ReadOnlySpan&lt;TElement&gt;, FluentAction&lt;T,TElement,int&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement,int_) 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement,int\>\)')
- [ForEach&lt;T,TElement&gt;\(this T, IEnumerable&lt;TElement&gt;, Action&lt;T,TElement,int&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement,int_) 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement,int\>\)')

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement_)'></a>

## FluentExtensions\.ForEach\<T,TElement\>\(this T, ReadOnlySpan\<TElement\>, Action\<T,TElement\>\) Method

Performs a specified action on an object and each element of a span,
then returns the object\.

```csharp
public static T ForEach<T,TElement>(this T @this, System.ReadOnlySpan<TElement> span, System.Action<T,TElement> action);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement_).TElement'></a>

`TElement`

The type of each element of the span\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement_).span'></a>

`span` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[TElement](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement_).TElement 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement\>\)\.TElement')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

The span of elements\.

<a name='Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement\>\)\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[TElement](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement_).TElement 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement\>\)\.TElement')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')

The action to perform\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement_).T 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement\>\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement_).this 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement\>\)\.this') after the last call to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement_).action 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement\>\)\.action') returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement_).this 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,System.Action_T,TElement_).action 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, System\.Action\<T,TElement\>\)\.action') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

### See Also
- [ForEach&lt;T,TElement&gt;\(this T, ReadOnlySpan&lt;TElement&gt;, FluentAction&lt;T,TElement&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.ReadOnlySpan_TElement_,Louis.Fluency.FluentAction_T,TElement_) 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.ReadOnlySpan\<TElement\>, Louis\.Fluency\.FluentAction\<T,TElement\>\)')
- [ForEach&lt;T,TElement&gt;\(this T, IEnumerable&lt;TElement&gt;, Action&lt;T,TElement&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.ForEach_T,TElement_(thisT,System.Collections.Generic.IEnumerable_TElement_,System.Action_T,TElement_) 'Louis\.Fluency\.FluentExtensions\.ForEach\<T,TElement\>\(this T, System\.Collections\.Generic\.IEnumerable\<TElement\>, System\.Action\<T,TElement\>\)')

<a name='Louis.Fluency.FluentExtensions.If_T_(thisT,bool,Louis.Fluency.FluentAction_T_)'></a>

## FluentExtensions\.If\<T\>\(this T, bool, FluentAction\<T\>\) Method

Invokes an action on an object if a condition is verified, then returns the result of the action\.

```csharp
public static T If<T>(this T @this, bool condition, Louis.Fluency.FluentAction<T> then);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.If_T_(thisT,bool,Louis.Fluency.FluentAction_T_).T'></a>

`T`

The type of the object\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.If_T_(thisT,bool,Louis.Fluency.FluentAction_T_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,Louis.Fluency.FluentAction_T_).T 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.If_T_(thisT,bool,Louis.Fluency.FluentAction_T_).condition'></a>

`condition` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The condition to test\.

<a name='Louis.Fluency.FluentExtensions.If_T_(thisT,bool,Louis.Fluency.FluentAction_T_).then'></a>

`then` [Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T_(T).md 'Louis\.Fluency\.FluentAction\<T\>\(T\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,Louis.Fluency.FluentAction_T_).T 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>\)\.T')[&gt;](Louis.Fluency.FluentAction_T_(T).md 'Louis\.Fluency\.FluentAction\<T\>\(T\)')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,Louis.Fluency.FluentAction_T_).this 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>\)\.this')
            if [condition](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,Louis.Fluency.FluentAction_T_).condition 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>\)\.condition') is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,Louis.Fluency.FluentAction_T_).T 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>\)\.T')  
The result of [then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,Louis.Fluency.FluentAction_T_).then 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>\)\.then') if [condition](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,Louis.Fluency.FluentAction_T_).condition 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>\)\.condition') is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool');
            otherwise, a reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,Louis.Fluency.FluentAction_T_).this 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>\)\.this')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,Louis.Fluency.FluentAction_T_).this 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,Louis.Fluency.FluentAction_T_).then 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>\)\.then') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

### See Also
- [If&lt;T&gt;\(this T, bool, Action&lt;T&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,System.Action_T_) 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, System\.Action\<T\>\)')

<a name='Louis.Fluency.FluentExtensions.If_T_(thisT,bool,System.Action_T_)'></a>

## FluentExtensions\.If\<T\>\(this T, bool, Action\<T\>\) Method

Invokes an action on an object if a condition is verified, then returns the same object\.

```csharp
public static T If<T>(this T @this, bool condition, System.Action<T> then);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.If_T_(thisT,bool,System.Action_T_).T'></a>

`T`

The type of the object\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.If_T_(thisT,bool,System.Action_T_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,System.Action_T_).T 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, System\.Action\<T\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.If_T_(thisT,bool,System.Action_T_).condition'></a>

`condition` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The condition to test\.

<a name='Louis.Fluency.FluentExtensions.If_T_(thisT,bool,System.Action_T_).then'></a>

`then` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,System.Action_T_).T 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, System\.Action\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,System.Action_T_).this 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, System\.Action\<T\>\)\.this')
            if [condition](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,System.Action_T_).condition 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, System\.Action\<T\>\)\.condition') is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,System.Action_T_).T 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, System\.Action\<T\>\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,System.Action_T_).this 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, System\.Action\<T\>\)\.this') after [then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,System.Action_T_).then 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, System\.Action\<T\>\)\.then'), if called, returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,System.Action_T_).this 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, System\.Action\<T\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,System.Action_T_).then 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, System\.Action\<T\>\)\.then') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

### See Also
- [If&lt;T&gt;\(this T, bool, FluentAction&lt;T&gt;\)](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.If_T_(thisT,bool,Louis.Fluency.FluentAction_T_) 'Louis\.Fluency\.FluentExtensions\.If\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>\)')

<a name='Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,Louis.Fluency.FluentAction_T_,Louis.Fluency.FluentAction_T_)'></a>

## FluentExtensions\.IfElse\<T\>\(this T, bool, FluentAction\<T\>, FluentAction\<T\>\) Method

Invokes one of two actions on an object according to a boolean condition, then returns the result of that action\.

```csharp
public static T IfElse<T>(this T @this, bool condition, Louis.Fluency.FluentAction<T> then, Louis.Fluency.FluentAction<T> @else);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,Louis.Fluency.FluentAction_T_,Louis.Fluency.FluentAction_T_).T'></a>

`T`

The type of the object\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,Louis.Fluency.FluentAction_T_,Louis.Fluency.FluentAction_T_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,Louis.Fluency.FluentAction_T_,Louis.Fluency.FluentAction_T_).T 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>, Louis\.Fluency\.FluentAction\<T\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,Louis.Fluency.FluentAction_T_,Louis.Fluency.FluentAction_T_).condition'></a>

`condition` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The condition to test\.

<a name='Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,Louis.Fluency.FluentAction_T_,Louis.Fluency.FluentAction_T_).then'></a>

`then` [Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T_(T).md 'Louis\.Fluency\.FluentAction\<T\>\(T\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,Louis.Fluency.FluentAction_T_,Louis.Fluency.FluentAction_T_).T 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>, Louis\.Fluency\.FluentAction\<T\>\)\.T')[&gt;](Louis.Fluency.FluentAction_T_(T).md 'Louis\.Fluency\.FluentAction\<T\>\(T\)')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,Louis.Fluency.FluentAction_T_,Louis.Fluency.FluentAction_T_).this 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>, Louis\.Fluency\.FluentAction\<T\>\)\.this')
            if [condition](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,Louis.Fluency.FluentAction_T_,Louis.Fluency.FluentAction_T_).condition 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>, Louis\.Fluency\.FluentAction\<T\>\)\.condition') is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,Louis.Fluency.FluentAction_T_,Louis.Fluency.FluentAction_T_).else'></a>

`else` [Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T_(T).md 'Louis\.Fluency\.FluentAction\<T\>\(T\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,Louis.Fluency.FluentAction_T_,Louis.Fluency.FluentAction_T_).T 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>, Louis\.Fluency\.FluentAction\<T\>\)\.T')[&gt;](Louis.Fluency.FluentAction_T_(T).md 'Louis\.Fluency\.FluentAction\<T\>\(T\)')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,Louis.Fluency.FluentAction_T_,Louis.Fluency.FluentAction_T_).this 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>, Louis\.Fluency\.FluentAction\<T\>\)\.this')
            if [condition](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,Louis.Fluency.FluentAction_T_,Louis.Fluency.FluentAction_T_).condition 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>, Louis\.Fluency\.FluentAction\<T\>\)\.condition') is [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,Louis.Fluency.FluentAction_T_,Louis.Fluency.FluentAction_T_).T 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>, Louis\.Fluency\.FluentAction\<T\>\)\.T')  
The result of [then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,Louis.Fluency.FluentAction_T_,Louis.Fluency.FluentAction_T_).then 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>, Louis\.Fluency\.FluentAction\<T\>\)\.then') if [condition](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,Louis.Fluency.FluentAction_T_,Louis.Fluency.FluentAction_T_).condition 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>, Louis\.Fluency\.FluentAction\<T\>\)\.condition') is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool');
            otherwise, the result of [else](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,Louis.Fluency.FluentAction_T_,Louis.Fluency.FluentAction_T_).else 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>, Louis\.Fluency\.FluentAction\<T\>\)\.else')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,Louis.Fluency.FluentAction_T_,Louis.Fluency.FluentAction_T_).this 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>, Louis\.Fluency\.FluentAction\<T\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,Louis.Fluency.FluentAction_T_,Louis.Fluency.FluentAction_T_).then 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>, Louis\.Fluency\.FluentAction\<T\>\)\.then') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[else](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,Louis.Fluency.FluentAction_T_,Louis.Fluency.FluentAction_T_).else 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, Louis\.Fluency\.FluentAction\<T\>, Louis\.Fluency\.FluentAction\<T\>\)\.else') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,System.Action_T_,System.Action_T_)'></a>

## FluentExtensions\.IfElse\<T\>\(this T, bool, Action\<T\>, Action\<T\>\) Method

Invokes one of two actions on an object according to a boolean condition, then returns the same object\.

```csharp
public static T IfElse<T>(this T @this, bool condition, System.Action<T> then, System.Action<T> @else);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,System.Action_T_,System.Action_T_).T'></a>

`T`

The type of the object\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,System.Action_T_,System.Action_T_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,System.Action_T_,System.Action_T_).T 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, System\.Action\<T\>, System\.Action\<T\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,System.Action_T_,System.Action_T_).condition'></a>

`condition` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The condition to test\.

<a name='Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,System.Action_T_,System.Action_T_).then'></a>

`then` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,System.Action_T_,System.Action_T_).T 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, System\.Action\<T\>, System\.Action\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,System.Action_T_,System.Action_T_).this 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, System\.Action\<T\>, System\.Action\<T\>\)\.this')
            if [condition](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,System.Action_T_,System.Action_T_).condition 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, System\.Action\<T\>, System\.Action\<T\>\)\.condition') is [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,System.Action_T_,System.Action_T_).else'></a>

`else` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,System.Action_T_,System.Action_T_).T 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, System\.Action\<T\>, System\.Action\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,System.Action_T_,System.Action_T_).this 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, System\.Action\<T\>, System\.Action\<T\>\)\.this')
            if [condition](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,System.Action_T_,System.Action_T_).condition 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, System\.Action\<T\>, System\.Action\<T\>\)\.condition') is [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,System.Action_T_,System.Action_T_).T 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, System\.Action\<T\>, System\.Action\<T\>\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,System.Action_T_,System.Action_T_).this 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, System\.Action\<T\>, System\.Action\<T\>\)\.this') after either [then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,System.Action_T_,System.Action_T_).then 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, System\.Action\<T\>, System\.Action\<T\>\)\.then') or [else](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,System.Action_T_,System.Action_T_).else 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, System\.Action\<T\>, System\.Action\<T\>\)\.else') returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,System.Action_T_,System.Action_T_).this 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, System\.Action\<T\>, System\.Action\<T\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,System.Action_T_,System.Action_T_).then 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, System\.Action\<T\>, System\.Action\<T\>\)\.then') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[else](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfElse_T_(thisT,bool,System.Action_T_,System.Action_T_).else 'Louis\.Fluency\.FluentExtensions\.IfElse\<T\>\(this T, bool, System\.Action\<T\>, System\.Action\<T\>\)\.else') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_)'></a>

## FluentExtensions\.IfNotNull\<T,T1\>\(this T, Nullable\<T1\>, FluentAction\<T,T1\>\) Method

Invokes an action on an object if a nullable value is not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), then returns the result of the action\.

```csharp
public static T IfNotNull<T,T1>(this T @this, System.Nullable<T1> arg, Louis.Fluency.FluentAction<T,T1> then)
    where T1 : struct;
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_).T1'></a>

`T1`

The type of the additional argument to pass to [then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, Louis\.Fluency\.FluentAction\<T,T1\>\)\.then')\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_).T 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, Louis\.Fluency\.FluentAction\<T,T1\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_).arg'></a>

`arg` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[T1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_).T1 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, Louis\.Fluency\.FluentAction\<T,T1\>\)\.T1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The additional argument to pass to [then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, Louis\.Fluency\.FluentAction\<T,T1\>\)\.then')\.

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_).then'></a>

`then` [Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_).T 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, Louis\.Fluency\.FluentAction\<T,T1\>\)\.T')[,](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)')[T1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_).T1 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, Louis\.Fluency\.FluentAction\<T,T1\>\)\.T1')[&gt;](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_).this 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, Louis\.Fluency\.FluentAction\<T,T1\>\)\.this') and [arg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_).arg 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, Louis\.Fluency\.FluentAction\<T,T1\>\)\.arg')
            if [arg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_).arg 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, Louis\.Fluency\.FluentAction\<T,T1\>\)\.arg') is not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_).T 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, Louis\.Fluency\.FluentAction\<T,T1\>\)\.T')  
The result of [then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, Louis\.Fluency\.FluentAction\<T,T1\>\)\.then') if [arg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_).arg 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, Louis\.Fluency\.FluentAction\<T,T1\>\)\.arg') is not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null');
            otherwise, a reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_).this 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, Louis\.Fluency\.FluentAction\<T,T1\>\)\.this')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_).this 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, Louis\.Fluency\.FluentAction\<T,T1\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,Louis.Fluency.FluentAction_T,T1_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, Louis\.Fluency\.FluentAction\<T,T1\>\)\.then') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,System.Action_T,T1_)'></a>

## FluentExtensions\.IfNotNull\<T,T1\>\(this T, Nullable\<T1\>, Action\<T,T1\>\) Method

Invokes an action on an object if a nullable value is not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), then returns the same object\.

```csharp
public static T IfNotNull<T,T1>(this T @this, System.Nullable<T1> arg, System.Action<T,T1> then)
    where T1 : struct;
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,System.Action_T,T1_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,System.Action_T,T1_).T1'></a>

`T1`

The type of the additional argument to pass to [then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,System.Action_T,T1_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, System\.Action\<T,T1\>\)\.then')\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,System.Action_T,T1_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,System.Action_T,T1_).T 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, System\.Action\<T,T1\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,System.Action_T,T1_).arg'></a>

`arg` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[T1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,System.Action_T,T1_).T1 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, System\.Action\<T,T1\>\)\.T1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The additional argument to pass to [then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,System.Action_T,T1_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, System\.Action\<T,T1\>\)\.then')\.

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,System.Action_T,T1_).then'></a>

`then` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,System.Action_T,T1_).T 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, System\.Action\<T,T1\>\)\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[T1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,System.Action_T,T1_).T1 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, System\.Action\<T,T1\>\)\.T1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,System.Action_T,T1_).this 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, System\.Action\<T,T1\>\)\.this') and [arg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,System.Action_T,T1_).arg 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, System\.Action\<T,T1\>\)\.arg')
            if [arg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,System.Action_T,T1_).arg 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, System\.Action\<T,T1\>\)\.arg') is not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,System.Action_T,T1_).T 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, System\.Action\<T,T1\>\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,System.Action_T,T1_).this 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, System\.Action\<T,T1\>\)\.this') after [then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,System.Action_T,T1_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, System\.Action\<T,T1\>\)\.then'), if called, returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,System.Action_T,T1_).this 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, System\.Action\<T,T1\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,System.Nullable_T1_,System.Action_T,T1_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, System\.Nullable\<T1\>, System\.Action\<T,T1\>\)\.then') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_)'></a>

## FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, FluentAction\<T,T1\>\) Method

Invokes an action on an object if a reference is not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), then returns the result of the action\.

```csharp
public static T IfNotNull<T,T1>(this T @this, T1? arg, Louis.Fluency.FluentAction<T,T1> then)
    where T1 : class;
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_).T1'></a>

`T1`

The type of the additional argument to pass to [then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, Louis\.Fluency\.FluentAction\<T,T1\>\)\.then')\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_).T 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, Louis\.Fluency\.FluentAction\<T,T1\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_).arg'></a>

`arg` [T1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_).T1 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, Louis\.Fluency\.FluentAction\<T,T1\>\)\.T1')

The additional argument to pass to [then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, Louis\.Fluency\.FluentAction\<T,T1\>\)\.then')\.

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_).then'></a>

`then` [Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_).T 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, Louis\.Fluency\.FluentAction\<T,T1\>\)\.T')[,](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)')[T1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_).T1 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, Louis\.Fluency\.FluentAction\<T,T1\>\)\.T1')[&gt;](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_).this 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, Louis\.Fluency\.FluentAction\<T,T1\>\)\.this') and [arg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_).arg 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, Louis\.Fluency\.FluentAction\<T,T1\>\)\.arg')
            if [arg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_).arg 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, Louis\.Fluency\.FluentAction\<T,T1\>\)\.arg') is not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_).T 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, Louis\.Fluency\.FluentAction\<T,T1\>\)\.T')  
The result of [then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, Louis\.Fluency\.FluentAction\<T,T1\>\)\.then') if [arg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_).arg 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, Louis\.Fluency\.FluentAction\<T,T1\>\)\.arg') is not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null');
            otherwise, a reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_).this 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, Louis\.Fluency\.FluentAction\<T,T1\>\)\.this')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_).this 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, Louis\.Fluency\.FluentAction\<T,T1\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,Louis.Fluency.FluentAction_T,T1_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, Louis\.Fluency\.FluentAction\<T,T1\>\)\.then') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,System.Action_T,T1_)'></a>

## FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, Action\<T,T1\>\) Method

Invokes an action on an object if a reference is not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), then returns the same object\.

```csharp
public static T IfNotNull<T,T1>(this T @this, T1? arg, System.Action<T,T1> then)
    where T1 : class;
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,System.Action_T,T1_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,System.Action_T,T1_).T1'></a>

`T1`

The type of the additional argument to pass to [then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,System.Action_T,T1_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, System\.Action\<T,T1\>\)\.then')\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,System.Action_T,T1_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,System.Action_T,T1_).T 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, System\.Action\<T,T1\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,System.Action_T,T1_).arg'></a>

`arg` [T1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,System.Action_T,T1_).T1 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, System\.Action\<T,T1\>\)\.T1')

The additional argument to pass to [then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,System.Action_T,T1_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, System\.Action\<T,T1\>\)\.then')\.

<a name='Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,System.Action_T,T1_).then'></a>

`then` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,System.Action_T,T1_).T 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, System\.Action\<T,T1\>\)\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[T1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,System.Action_T,T1_).T1 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, System\.Action\<T,T1\>\)\.T1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,System.Action_T,T1_).this 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, System\.Action\<T,T1\>\)\.this') and [arg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,System.Action_T,T1_).arg 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, System\.Action\<T,T1\>\)\.arg')
            if [arg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,System.Action_T,T1_).arg 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, System\.Action\<T,T1\>\)\.arg') is not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,System.Action_T,T1_).T 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, System\.Action\<T,T1\>\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,System.Action_T,T1_).this 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, System\.Action\<T,T1\>\)\.this') after [then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,System.Action_T,T1_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, System\.Action\<T,T1\>\)\.then'), if called, returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,System.Action_T,T1_).this 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, System\.Action\<T,T1\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNull_T,T1_(thisT,T1,System.Action_T,T1_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNull\<T,T1\>\(this T, T1, System\.Action\<T,T1\>\)\.then') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,Louis.Fluency.FluentAction_T,string_)'></a>

## FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, FluentAction\<T,string\>\) Method

Invokes an action on an object if a string is neither [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') nor the empty string,
then returns the result of the action\.

```csharp
public static T IfNotNullOrEmpty<T>(this T @this, string? arg, Louis.Fluency.FluentAction<T,string> then);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,Louis.Fluency.FluentAction_T,string_).T'></a>

`T`

The type of the object\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,Louis.Fluency.FluentAction_T,string_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,Louis.Fluency.FluentAction_T,string_).T 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, Louis\.Fluency\.FluentAction\<T,string\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,Louis.Fluency.FluentAction_T,string_).arg'></a>

`arg` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to check and pass to [then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,Louis.Fluency.FluentAction_T,string_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, Louis\.Fluency\.FluentAction\<T,string\>\)\.then') if called\.

<a name='Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,Louis.Fluency.FluentAction_T,string_).then'></a>

`then` [Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,Louis.Fluency.FluentAction_T,string_).T 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, Louis\.Fluency\.FluentAction\<T,string\>\)\.T')[,](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,Louis.Fluency.FluentAction_T,string_).this 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, Louis\.Fluency\.FluentAction\<T,string\>\)\.this') and [arg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,Louis.Fluency.FluentAction_T,string_).arg 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, Louis\.Fluency\.FluentAction\<T,string\>\)\.arg')
            if [arg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,Louis.Fluency.FluentAction_T,string_).arg 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, Louis\.Fluency\.FluentAction\<T,string\>\)\.arg') is neither [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') nor the empty string\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,Louis.Fluency.FluentAction_T,string_).T 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, Louis\.Fluency\.FluentAction\<T,string\>\)\.T')  
The result of [then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,Louis.Fluency.FluentAction_T,string_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, Louis\.Fluency\.FluentAction\<T,string\>\)\.then') if [arg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,Louis.Fluency.FluentAction_T,string_).arg 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, Louis\.Fluency\.FluentAction\<T,string\>\)\.arg') is neither [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') nor the empty string;
            otherwise, a reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,Louis.Fluency.FluentAction_T,string_).this 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, Louis\.Fluency\.FluentAction\<T,string\>\)\.this')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,Louis.Fluency.FluentAction_T,string_).this 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, Louis\.Fluency\.FluentAction\<T,string\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,Louis.Fluency.FluentAction_T,string_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, Louis\.Fluency\.FluentAction\<T,string\>\)\.then') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,System.Action_T,string_)'></a>

## FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, Action\<T,string\>\) Method

Invokes an action on an object if a string is neither [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') nor the empty string, then returns the same object\.

```csharp
public static T IfNotNullOrEmpty<T>(this T @this, string? arg, System.Action<T,string> then);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,System.Action_T,string_).T'></a>

`T`

The type of the object\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,System.Action_T,string_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,System.Action_T,string_).T 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, System\.Action\<T,string\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,System.Action_T,string_).arg'></a>

`arg` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to check and pass to [then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,System.Action_T,string_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, System\.Action\<T,string\>\)\.then') if called\.

<a name='Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,System.Action_T,string_).then'></a>

`then` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,System.Action_T,string_).T 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, System\.Action\<T,string\>\)\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,System.Action_T,string_).this 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, System\.Action\<T,string\>\)\.this') and [arg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,System.Action_T,string_).arg 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, System\.Action\<T,string\>\)\.arg')
            if [arg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,System.Action_T,string_).arg 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, System\.Action\<T,string\>\)\.arg') is neither [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') nor the empty string\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,System.Action_T,string_).T 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, System\.Action\<T,string\>\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,System.Action_T,string_).this 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, System\.Action\<T,string\>\)\.this') after [then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,System.Action_T,string_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, System\.Action\<T,string\>\)\.then'), if called, returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,System.Action_T,string_).this 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, System\.Action\<T,string\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[then](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.IfNotNullOrEmpty_T_(thisT,string,System.Action_T,string_).then 'Louis\.Fluency\.FluentExtensions\.IfNotNullOrEmpty\<T\>\(this T, string, System\.Action\<T,string\>\)\.then') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_)'></a>

## FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, Action\<T,TArg1,TArg2,TArg3,TArg4\>\) Method

Invokes an action on an object and additional arguments and returns the same object\.

```csharp
public static T Invoke<T,TArg1,TArg2,TArg3,TArg4>(this T @this, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, System.Action<T,TArg1,TArg2,TArg3,TArg4> action);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg1'></a>

`TArg1`

The type of the first additional parameter to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg2'></a>

`TArg2`

The type of the second additional parameter to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg3'></a>

`TArg3`

The type of the third additional parameter to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg4'></a>

`TArg4`

The type of the fourth additional parameter to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.action')\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).T 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).arg1'></a>

`arg1` [TArg1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg1 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg1')

The first additional argument to pass to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).arg2'></a>

`arg2` [TArg2](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg2 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg2')

The second additional argument to pass to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).arg3'></a>

`arg3` [TArg3](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg3 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg3')

The third additional argument to pass to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).arg4'></a>

`arg4` [TArg4](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg4 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg4')

The fourth additional argument to pass to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-5 'System\.Action\`5')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).T 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-5 'System\.Action\`5')[TArg1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg1 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg1')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-5 'System\.Action\`5')[TArg2](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg2 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg2')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-5 'System\.Action\`5')[TArg3](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg3 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg3')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-5 'System\.Action\`5')[TArg4](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg4 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg4')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-5 'System\.Action\`5')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).this 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.this') and the additional arguments\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).T 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).this 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.this') after [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.action') returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).this 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3,TArg4_(thisT,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.action') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_)'></a>

## FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, Action\<T,TArg1,TArg2,TArg3\>\) Method

Invokes an action on an object and additional arguments and returns the same object\.

```csharp
public static T Invoke<T,TArg1,TArg2,TArg3>(this T @this, TArg1 arg1, TArg2 arg2, TArg3 arg3, System.Action<T,TArg1,TArg2,TArg3> action);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).TArg1'></a>

`TArg1`

The type of the first additional parameter to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).TArg2'></a>

`TArg2`

The type of the second additional parameter to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).TArg3'></a>

`TArg3`

The type of the third additional parameter to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.action')\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).T 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).arg1'></a>

`arg1` [TArg1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).TArg1 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.TArg1')

The first additional argument to pass to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).arg2'></a>

`arg2` [TArg2](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).TArg2 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.TArg2')

The second additional argument to pass to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).arg3'></a>

`arg3` [TArg3](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).TArg3 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.TArg3')

The third additional argument to pass to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-4 'System\.Action\`4')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).T 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-4 'System\.Action\`4')[TArg1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).TArg1 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.TArg1')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-4 'System\.Action\`4')[TArg2](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).TArg2 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.TArg2')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-4 'System\.Action\`4')[TArg3](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).TArg3 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.TArg3')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-4 'System\.Action\`4')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).this 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.this') and the additional arguments\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).T 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).this 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.this') after [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.action') returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).this 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2,TArg3_(thisT,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2,TArg3\>\(this T, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.action') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_)'></a>

## FluentExtensions\.Invoke\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, Action\<T,TArg1,TArg2\>\) Method

Invokes an action on an object and additional arguments and returns the same object\.

```csharp
public static T Invoke<T,TArg1,TArg2>(this T @this, TArg1 arg1, TArg2 arg2, System.Action<T,TArg1,TArg2> action);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).TArg1'></a>

`TArg1`

The type of the first additional parameter to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).TArg2'></a>

`TArg2`

The type of the second additional parameter to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.action')\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).T 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).arg1'></a>

`arg1` [TArg1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).TArg1 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.TArg1')

The first additional argument to pass to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).arg2'></a>

`arg2` [TArg2](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).TArg2 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.TArg2')

The second additional argument to pass to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).T 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')[TArg1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).TArg1 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.TArg1')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')[TArg2](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).TArg2 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.TArg2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).this 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.this') and the additional arguments\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).T 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).this 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.this') after [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.action') returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).this 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg1,TArg2_(thisT,TArg1,TArg2,System.Action_T,TArg1,TArg2_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg1,TArg2\>\(this T, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.action') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg_(thisT,TArg,System.Action_T,TArg_)'></a>

## FluentExtensions\.Invoke\<T,TArg\>\(this T, TArg, Action\<T,TArg\>\) Method

Invokes an action on an object and an additional argument and returns the same object\.

```csharp
public static T Invoke<T,TArg>(this T @this, TArg arg, System.Action<T,TArg> action);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg_(thisT,TArg,System.Action_T,TArg_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg_(thisT,TArg,System.Action_T,TArg_).TArg'></a>

`TArg`

The type of the additional parameter to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg_(thisT,TArg,System.Action_T,TArg_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg\>\(this T, TArg, System\.Action\<T,TArg\>\)\.action')\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg_(thisT,TArg,System.Action_T,TArg_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg_(thisT,TArg,System.Action_T,TArg_).T 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg\>\(this T, TArg, System\.Action\<T,TArg\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg_(thisT,TArg,System.Action_T,TArg_).arg'></a>

`arg` [TArg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg_(thisT,TArg,System.Action_T,TArg_).TArg 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg\>\(this T, TArg, System\.Action\<T,TArg\>\)\.TArg')

The additional argument to pass to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg_(thisT,TArg,System.Action_T,TArg_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg\>\(this T, TArg, System\.Action\<T,TArg\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T,TArg_(thisT,TArg,System.Action_T,TArg_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg_(thisT,TArg,System.Action_T,TArg_).T 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg\>\(this T, TArg, System\.Action\<T,TArg\>\)\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[TArg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg_(thisT,TArg,System.Action_T,TArg_).TArg 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg\>\(this T, TArg, System\.Action\<T,TArg\>\)\.TArg')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg_(thisT,TArg,System.Action_T,TArg_).this 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg\>\(this T, TArg, System\.Action\<T,TArg\>\)\.this') and [arg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg_(thisT,TArg,System.Action_T,TArg_).arg 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg\>\(this T, TArg, System\.Action\<T,TArg\>\)\.arg')\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg_(thisT,TArg,System.Action_T,TArg_).T 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg\>\(this T, TArg, System\.Action\<T,TArg\>\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg_(thisT,TArg,System.Action_T,TArg_).this 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg\>\(this T, TArg, System\.Action\<T,TArg\>\)\.this') after [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg_(thisT,TArg,System.Action_T,TArg_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg\>\(this T, TArg, System\.Action\<T,TArg\>\)\.action') returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg_(thisT,TArg,System.Action_T,TArg_).this 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg\>\(this T, TArg, System\.Action\<T,TArg\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T,TArg_(thisT,TArg,System.Action_T,TArg_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T,TArg\>\(this T, TArg, System\.Action\<T,TArg\>\)\.action') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.Invoke_T_(thisT,System.Action_T_)'></a>

## FluentExtensions\.Invoke\<T\>\(this T, Action\<T\>\) Method

Invokes an action on an object and returns the same object\.

```csharp
public static T Invoke<T>(this T @this, System.Action<T> action);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.Invoke_T_(thisT,System.Action_T_).T'></a>

`T`

The type of the object\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.Invoke_T_(thisT,System.Action_T_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T_(thisT,System.Action_T_).T 'Louis\.Fluency\.FluentExtensions\.Invoke\<T\>\(this T, System\.Action\<T\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.Invoke_T_(thisT,System.Action_T_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T_(thisT,System.Action_T_).T 'Louis\.Fluency\.FluentExtensions\.Invoke\<T\>\(this T, System\.Action\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T_(thisT,System.Action_T_).this 'Louis\.Fluency\.FluentExtensions\.Invoke\<T\>\(this T, System\.Action\<T\>\)\.this')\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T_(thisT,System.Action_T_).T 'Louis\.Fluency\.FluentExtensions\.Invoke\<T\>\(this T, System\.Action\<T\>\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T_(thisT,System.Action_T_).this 'Louis\.Fluency\.FluentExtensions\.Invoke\<T\>\(this T, System\.Action\<T\>\)\.this') after [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T_(thisT,System.Action_T_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T\>\(this T, System\.Action\<T\>\)\.action') returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T_(thisT,System.Action_T_).this 'Louis\.Fluency\.FluentExtensions\.Invoke\<T\>\(this T, System\.Action\<T\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Invoke_T_(thisT,System.Action_T_).action 'Louis\.Fluency\.FluentExtensions\.Invoke\<T\>\(this T, System\.Action\<T\>\)\.action') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_)'></a>

## FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, Action\<T,TArg1,TArg2,TArg3,TArg4\>\) Method

Invokes an action on an object and additional arguments if a condition is satisfied, then returns the same object\.

```csharp
public static T InvokeIf<T,TArg1,TArg2,TArg3,TArg4>(this T @this, bool condition, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, System.Action<T,TArg1,TArg2,TArg3,TArg4> action);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg1'></a>

`TArg1`

The type of the first additional parameter to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg2'></a>

`TArg2`

The type of the second additional parameter to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg3'></a>

`TArg3`

The type of the third additional parameter to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg4'></a>

`TArg4`

The type of the fourth additional parameter to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.action')\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).T 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).condition'></a>

`condition` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The condition to check\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).arg1'></a>

`arg1` [TArg1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg1 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg1')

The first additional argument to pass to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).arg2'></a>

`arg2` [TArg2](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg2 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg2')

The second additional argument to pass to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).arg3'></a>

`arg3` [TArg3](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg3 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg3')

The third additional argument to pass to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).arg4'></a>

`arg4` [TArg4](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg4 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg4')

The fourth additional argument to pass to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-5 'System\.Action\`5')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).T 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-5 'System\.Action\`5')[TArg1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg1 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg1')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-5 'System\.Action\`5')[TArg2](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg2 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg2')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-5 'System\.Action\`5')[TArg3](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg3 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg3')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-5 'System\.Action\`5')[TArg4](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).TArg4 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.TArg4')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-5 'System\.Action\`5')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).this 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.this') and the additional arguments\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).T 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).this 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.this') after [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.action') returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).this 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3,TArg4_(thisT,bool,TArg1,TArg2,TArg3,TArg4,System.Action_T,TArg1,TArg2,TArg3,TArg4_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3,TArg4\>\(this T, bool, TArg1, TArg2, TArg3, TArg4, System\.Action\<T,TArg1,TArg2,TArg3,TArg4\>\)\.action') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_)'></a>

## FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, Action\<T,TArg1,TArg2,TArg3\>\) Method

Invokes an action on an object and additional arguments if a condition is satisfied, then returns the same object\.

```csharp
public static T InvokeIf<T,TArg1,TArg2,TArg3>(this T @this, bool condition, TArg1 arg1, TArg2 arg2, TArg3 arg3, System.Action<T,TArg1,TArg2,TArg3> action);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).TArg1'></a>

`TArg1`

The type of the first additional parameter to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).TArg2'></a>

`TArg2`

The type of the second additional parameter to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).TArg3'></a>

`TArg3`

The type of the third additional parameter to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.action')\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).T 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).condition'></a>

`condition` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The condition to check\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).arg1'></a>

`arg1` [TArg1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).TArg1 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.TArg1')

The first additional argument to pass to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).arg2'></a>

`arg2` [TArg2](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).TArg2 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.TArg2')

The second additional argument to pass to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).arg3'></a>

`arg3` [TArg3](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).TArg3 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.TArg3')

The third additional argument to pass to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-4 'System\.Action\`4')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).T 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-4 'System\.Action\`4')[TArg1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).TArg1 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.TArg1')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-4 'System\.Action\`4')[TArg2](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).TArg2 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.TArg2')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-4 'System\.Action\`4')[TArg3](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).TArg3 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.TArg3')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-4 'System\.Action\`4')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).this 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.this') and the additional arguments\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).T 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).this 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.this') after [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.action') returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).this 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2,TArg3_(thisT,bool,TArg1,TArg2,TArg3,System.Action_T,TArg1,TArg2,TArg3_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2,TArg3\>\(this T, bool, TArg1, TArg2, TArg3, System\.Action\<T,TArg1,TArg2,TArg3\>\)\.action') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_)'></a>

## FluentExtensions\.InvokeIf\<T,TArg1,TArg2\>\(this T, bool, TArg1, TArg2, Action\<T,TArg1,TArg2\>\) Method

Invokes an action on an object and additional arguments if a condition is satisfied, then returns the same object\.

```csharp
public static T InvokeIf<T,TArg1,TArg2>(this T @this, bool condition, TArg1 arg1, TArg2 arg2, System.Action<T,TArg1,TArg2> action);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).TArg1'></a>

`TArg1`

The type of the first additional parameter to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2\>\(this T, bool, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).TArg2'></a>

`TArg2`

The type of the second additional parameter to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2\>\(this T, bool, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.action')\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).T 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2\>\(this T, bool, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).condition'></a>

`condition` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The condition to check\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).arg1'></a>

`arg1` [TArg1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).TArg1 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2\>\(this T, bool, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.TArg1')

The first additional argument to pass to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2\>\(this T, bool, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).arg2'></a>

`arg2` [TArg2](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).TArg2 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2\>\(this T, bool, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.TArg2')

The second additional argument to pass to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2\>\(this T, bool, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).T 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2\>\(this T, bool, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')[TArg1](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).TArg1 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2\>\(this T, bool, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.TArg1')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')[TArg2](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).TArg2 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2\>\(this T, bool, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.TArg2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-3 'System\.Action\`3')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).this 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2\>\(this T, bool, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.this') and the additional arguments\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).T 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2\>\(this T, bool, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).this 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2\>\(this T, bool, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.this') after [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2\>\(this T, bool, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.action') returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).this 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2\>\(this T, bool, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg1,TArg2_(thisT,bool,TArg1,TArg2,System.Action_T,TArg1,TArg2_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg1,TArg2\>\(this T, bool, TArg1, TArg2, System\.Action\<T,TArg1,TArg2\>\)\.action') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg_(thisT,bool,TArg,System.Action_T,TArg_)'></a>

## FluentExtensions\.InvokeIf\<T,TArg\>\(this T, bool, TArg, Action\<T,TArg\>\) Method

Invokes an action on an object and an additional argument if a condition is satisfied, then returns the same object\.

```csharp
public static T InvokeIf<T,TArg>(this T @this, bool condition, TArg arg, System.Action<T,TArg> action);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg_(thisT,bool,TArg,System.Action_T,TArg_).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg_(thisT,bool,TArg,System.Action_T,TArg_).TArg'></a>

`TArg`

The type of the additional parameter to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg_(thisT,bool,TArg,System.Action_T,TArg_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg\>\(this T, bool, TArg, System\.Action\<T,TArg\>\)\.action')\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg_(thisT,bool,TArg,System.Action_T,TArg_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg_(thisT,bool,TArg,System.Action_T,TArg_).T 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg\>\(this T, bool, TArg, System\.Action\<T,TArg\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg_(thisT,bool,TArg,System.Action_T,TArg_).condition'></a>

`condition` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The condition to check\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg_(thisT,bool,TArg,System.Action_T,TArg_).arg'></a>

`arg` [TArg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg_(thisT,bool,TArg,System.Action_T,TArg_).TArg 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg\>\(this T, bool, TArg, System\.Action\<T,TArg\>\)\.TArg')

The additional argument to pass to [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg_(thisT,bool,TArg,System.Action_T,TArg_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg\>\(this T, bool, TArg, System\.Action\<T,TArg\>\)\.action')\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T,TArg_(thisT,bool,TArg,System.Action_T,TArg_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg_(thisT,bool,TArg,System.Action_T,TArg_).T 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg\>\(this T, bool, TArg, System\.Action\<T,TArg\>\)\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[TArg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg_(thisT,bool,TArg,System.Action_T,TArg_).TArg 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg\>\(this T, bool, TArg, System\.Action\<T,TArg\>\)\.TArg')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg_(thisT,bool,TArg,System.Action_T,TArg_).this 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg\>\(this T, bool, TArg, System\.Action\<T,TArg\>\)\.this') and [arg](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg_(thisT,bool,TArg,System.Action_T,TArg_).arg 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg\>\(this T, bool, TArg, System\.Action\<T,TArg\>\)\.arg')\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg_(thisT,bool,TArg,System.Action_T,TArg_).T 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg\>\(this T, bool, TArg, System\.Action\<T,TArg\>\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg_(thisT,bool,TArg,System.Action_T,TArg_).this 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg\>\(this T, bool, TArg, System\.Action\<T,TArg\>\)\.this') after [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg_(thisT,bool,TArg,System.Action_T,TArg_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg\>\(this T, bool, TArg, System\.Action\<T,TArg\>\)\.action') returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg_(thisT,bool,TArg,System.Action_T,TArg_).this 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg\>\(this T, bool, TArg, System\.Action\<T,TArg\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T,TArg_(thisT,bool,TArg,System.Action_T,TArg_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T,TArg\>\(this T, bool, TArg, System\.Action\<T,TArg\>\)\.action') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T_(thisT,bool,System.Action_T_)'></a>

## FluentExtensions\.InvokeIf\<T\>\(this T, bool, Action\<T\>\) Method

Invokes an action on an object if a condition is satisfied, then returns the same object\.

```csharp
public static T InvokeIf<T>(this T @this, bool condition, System.Action<T> action);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T_(thisT,bool,System.Action_T_).T'></a>

`T`

The type of the object\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T_(thisT,bool,System.Action_T_).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T_(thisT,bool,System.Action_T_).T 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T\>\(this T, bool, System\.Action\<T\>\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T_(thisT,bool,System.Action_T_).condition'></a>

`condition` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The condition to check\.

<a name='Louis.Fluency.FluentExtensions.InvokeIf_T_(thisT,bool,System.Action_T_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T_(thisT,bool,System.Action_T_).T 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T\>\(this T, bool, System\.Action\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

The action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T_(thisT,bool,System.Action_T_).this 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T\>\(this T, bool, System\.Action\<T\>\)\.this')\.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T_(thisT,bool,System.Action_T_).T 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T\>\(this T, bool, System\.Action\<T\>\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T_(thisT,bool,System.Action_T_).this 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T\>\(this T, bool, System\.Action\<T\>\)\.this') after [action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T_(thisT,bool,System.Action_T_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T\>\(this T, bool, System\.Action\<T\>\)\.action') returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T_(thisT,bool,System.Action_T_).this 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T\>\(this T, bool, System\.Action\<T\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[action](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.InvokeIf_T_(thisT,bool,System.Action_T_).action 'Louis\.Fluency\.FluentExtensions\.InvokeIf\<T\>\(this T, bool, System\.Action\<T\>\)\.action') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[])'></a>

## FluentExtensions\.Switch\<T,TValue\>\(this T, IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,FluentAction\<T\> Action\)\[\]\) Method

Selects an action to invoke on an object by comparing a given value against a list of comparands,
then returns the result of the action\.

```csharp
public static T Switch<T,TValue>(this T @this, System.Collections.Generic.IEqualityComparer<TValue> comparer, TValue value, params (TValue Comparand,Louis.Fluency.FluentAction<T>? Action)[] cases);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).TValue'></a>

`TValue`

The type of the value being compared\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).comparer'></a>

`comparer` [System\.Collections\.Generic\.IEqualityComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1 'System\.Collections\.Generic\.IEqualityComparer\`1')[TValue](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).TValue 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.TValue')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1 'System\.Collections\.Generic\.IEqualityComparer\`1')

The interface to use for comparisons\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value'></a>

`value` [TValue](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).TValue 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.TValue')

The value to compare\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).cases'></a>

`cases` [&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[TValue](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).TValue 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.TValue')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T_(T).md 'Louis\.Fluency\.FluentAction\<T\>\(T\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.T')[&gt;](Louis.Fluency.FluentAction_T_(T).md 'Louis\.Fluency\.FluentAction\<T\>\(T\)')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')


An array of pairs, where each element consists of a value to compare against [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.value')
            and an optional action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.this') if they are equal.

If the action is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), no action is performed if the value is equal to [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.value');
            instead, the method returns immediately.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.T')  
The result of the action of the first case whose comparand is equal to [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.value'),
            or a reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.this') if there is no such case or its action is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[comparer](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).comparer 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.comparer') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.cases') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

### Remarks

If [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.value') is not equal to any of the values in [cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.cases'),
            this method returns immediately.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[])'></a>

## FluentExtensions\.Switch\<T,TValue\>\(this T, IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,Action\<T\> Action\)\[\]\) Method

Selects an action to invoke on an object by comparing a given value against a list of comparands, then returns the object\.

```csharp
public static T Switch<T,TValue>(this T @this, System.Collections.Generic.IEqualityComparer<TValue> comparer, TValue value, params (TValue Comparand,System.Action<T>? Action)[] cases);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).TValue'></a>

`TValue`

The type of the value being compared\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).comparer'></a>

`comparer` [System\.Collections\.Generic\.IEqualityComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1 'System\.Collections\.Generic\.IEqualityComparer\`1')[TValue](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).TValue 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.TValue')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1 'System\.Collections\.Generic\.IEqualityComparer\`1')

The interface to use for comparisons\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).value'></a>

`value` [TValue](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).TValue 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.TValue')

The value to compare\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).cases'></a>

`cases` [&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[TValue](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).TValue 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.TValue')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')


An array of pairs, where each element consists of a value to compare against [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.value')
            and an optional action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.this') if they are equal.

If the action is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), no action is performed if the value is equal to [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.value');
            instead, the method returns immediately.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.this') after one of the actions in [cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.cases'), if any, returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[comparer](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).comparer 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.comparer') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.cases') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

### Remarks

If [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.value') is not equal to any of the values in [cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,(TValueComparand,System.Action_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.cases'),
            this method returns immediately.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[])'></a>

## FluentExtensions\.Switch\<T,TValue\>\(this T, IEqualityComparer\<TValue\>, TValue, FluentAction\<T\>, \(TValue Comparand,FluentAction\<T\> Action\)\[\]\) Method

Selects an action to invoke on an object by comparing a given value against a list of comparands,
then returns the result of the action\.

```csharp
public static T Switch<T,TValue>(this T @this, System.Collections.Generic.IEqualityComparer<TValue> comparer, TValue value, Louis.Fluency.FluentAction<T>? @default, params (TValue Comparand,Louis.Fluency.FluentAction<T>? Action)[] cases);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).TValue'></a>

`TValue`

The type of the value being compared\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).comparer'></a>

`comparer` [System\.Collections\.Generic\.IEqualityComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1 'System\.Collections\.Generic\.IEqualityComparer\`1')[TValue](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).TValue 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.TValue')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1 'System\.Collections\.Generic\.IEqualityComparer\`1')

The interface to use for comparisons\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value'></a>

`value` [TValue](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).TValue 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.TValue')

The value to compare\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).default'></a>

`default` [Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T_(T).md 'Louis\.Fluency\.FluentAction\<T\>\(T\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.T')[&gt;](Louis.Fluency.FluentAction_T_(T).md 'Louis\.Fluency\.FluentAction\<T\>\(T\)')


An optional action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.this') if [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.value') is not equal
            to any of the values in [cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.cases').

If this parameter is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') and [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.value') is not equal
            to any of the values in [cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.cases'), this method returns immediately.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).cases'></a>

`cases` [&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[TValue](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).TValue 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.TValue')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T_(T).md 'Louis\.Fluency\.FluentAction\<T\>\(T\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.T')[&gt;](Louis.Fluency.FluentAction_T_(T).md 'Louis\.Fluency\.FluentAction\<T\>\(T\)')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')


An array of pairs, where each element consists of a value to compare against [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.value')
            and an optional action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.this') if they are equal.

If the action is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), no action is performed if the value is equal to [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.value');
            instead, the method returns immediately.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.T')  
The result of the action of the first case whose comparand is equal to [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.value'),
            or of [default](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).default 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.default') if there is no such case,
            or a reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.this') if the action to invoke is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[comparer](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).comparer 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.comparer') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.cases') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[])'></a>

## FluentExtensions\.Switch\<T,TValue\>\(this T, IEqualityComparer\<TValue\>, TValue, Action\<T\>, \(TValue Comparand,Action\<T\> Action\)\[\]\) Method

Selects an action to invoke on an object by comparing a given value against a list of comparands, then returns the object\.

```csharp
public static T Switch<T,TValue>(this T @this, System.Collections.Generic.IEqualityComparer<TValue> comparer, TValue value, System.Action<T>? @default, params (TValue Comparand,System.Action<T>? Action)[] cases);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).TValue'></a>

`TValue`

The type of the value being compared\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).comparer'></a>

`comparer` [System\.Collections\.Generic\.IEqualityComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1 'System\.Collections\.Generic\.IEqualityComparer\`1')[TValue](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).TValue 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.TValue')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1 'System\.Collections\.Generic\.IEqualityComparer\`1')

The interface to use for comparisons\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).value'></a>

`value` [TValue](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).TValue 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.TValue')

The value to compare\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).default'></a>

`default` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')


An optional action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.this') if [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.value') is not equal
            to any of the values in [cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.cases').

If this parameter is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') and [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.value') is not equal
            to any of the values in [cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.cases'), this method returns immediately.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).cases'></a>

`cases` [&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[TValue](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).TValue 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.TValue')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')


An array of pairs, where each element consists of a value to compare against [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.value')
            and an optional action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.this') if they are equal.

If the action is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), no action is performed if the value is equal to [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.value');
            instead, the method returns immediately.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.this') after the action to invoke, if any, returns\.
            The action to invoke is the action of the first case whose comparand is equal to [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.value'),
            or [default](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).default 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.default') if there is no such case\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[comparer](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).comparer 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.comparer') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,System.Collections.Generic.IEqualityComparer_TValue_,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, System\.Collections\.Generic\.IEqualityComparer\<TValue\>, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.cases') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[])'></a>

## FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,FluentAction\<T\> Action\)\[\]\) Method

Selects an action to invoke on an object by comparing a given value against a list of comparands,
then returns the result of the action\.

```csharp
public static T Switch<T,TValue>(this T @this, TValue value, params (TValue Comparand,Louis.Fluency.FluentAction<T>? Action)[] cases);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).TValue'></a>

`TValue`

The type of the value being compared\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value'></a>

`value` [TValue](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).TValue 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.TValue')

The value to compare\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).cases'></a>

`cases` [&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[TValue](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).TValue 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.TValue')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T_(T).md 'Louis\.Fluency\.FluentAction\<T\>\(T\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.T')[&gt;](Louis.Fluency.FluentAction_T_(T).md 'Louis\.Fluency\.FluentAction\<T\>\(T\)')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')


An array of pairs, where each element consists of a value to compare against [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.value')
            and an optional action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.this') if they are equal.

If the action is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), no action is performed if the value is equal to [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.value');
            instead, the method returns immediately.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.T')  
The result of the action of the first case whose comparand is equal to [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.value'),
            or a reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.this') if there is no such case or its action is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.cases') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

### Remarks

If [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.value') is not equal to any of the values in [cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.cases'),
            this method returns immediately.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,System.Action_T_Action)[])'></a>

## FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,Action\<T\> Action\)\[\]\) Method

Selects an action to invoke on an object by comparing a given value against a list of comparands, then returns the object\.

```csharp
public static T Switch<T,TValue>(this T @this, TValue value, params (TValue Comparand,System.Action<T>? Action)[] cases);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,System.Action_T_Action)[]).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,System.Action_T_Action)[]).TValue'></a>

`TValue`

The type of the value being compared\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,System.Action_T_Action)[]).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,System.Action_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,System.Action_T_Action)[]).value'></a>

`value` [TValue](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,System.Action_T_Action)[]).TValue 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.TValue')

The value to compare\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,System.Action_T_Action)[]).cases'></a>

`cases` [&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[TValue](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,System.Action_T_Action)[]).TValue 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.TValue')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,System.Action_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')


An array of pairs, where each element consists of a value to compare against [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,System.Action_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.value')
            and an optional action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,System.Action_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.this') if they are equal.

If the action is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), no action is performed if the value is equal to [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,System.Action_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.value');
            instead, the method returns immediately.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,System.Action_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,System.Action_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.this') after one of the actions in [cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,System.Action_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.cases'), if any, returns\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,System.Action_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,System.Action_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.cases') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

### Remarks

If [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,System.Action_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.value') is not equal to any of the values in [cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,(TValueComparand,System.Action_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.cases'),
            this method returns immediately.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[])'></a>

## FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, FluentAction\<T\>, \(TValue Comparand,FluentAction\<T\> Action\)\[\]\) Method

Selects an action to invoke on an object by comparing a given value against a list of comparands,
then returns the result of the action\.

```csharp
public static T Switch<T,TValue>(this T @this, TValue value, Louis.Fluency.FluentAction<T>? @default, params (TValue Comparand,Louis.Fluency.FluentAction<T>? Action)[] cases);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).TValue'></a>

`TValue`

The type of the value being compared\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value'></a>

`value` [TValue](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).TValue 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.TValue')

The value to compare\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).default'></a>

`default` [Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T_(T).md 'Louis\.Fluency\.FluentAction\<T\>\(T\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.T')[&gt;](Louis.Fluency.FluentAction_T_(T).md 'Louis\.Fluency\.FluentAction\<T\>\(T\)')


An optional action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.this') if [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.value') is not equal
            to any of the values in [cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.cases').

If this parameter is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') and [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.value') is not equal
            to any of the values in [cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.cases'), this method returns immediately.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).cases'></a>

`cases` [&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[TValue](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).TValue 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.TValue')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[Louis\.Fluency\.FluentAction&lt;](Louis.Fluency.FluentAction_T_(T).md 'Louis\.Fluency\.FluentAction\<T\>\(T\)')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.T')[&gt;](Louis.Fluency.FluentAction_T_(T).md 'Louis\.Fluency\.FluentAction\<T\>\(T\)')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')


An array of pairs, where each element consists of a value to compare against [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.value')
            and an optional action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.this') if they are equal.

If the action is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), no action is performed if the value is equal to [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.value');
            instead, the method returns immediately.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.T')  
The result of the action of the first case whose comparand is equal to [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.value'),
            or of [default](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).default 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.default') if there is no such case,
            or a reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.this') if the action to invoke is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,Louis.Fluency.FluentAction_T_,(TValueComparand,Louis.Fluency.FluentAction_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, Louis\.Fluency\.FluentAction\<T\>, \(TValue Comparand,Louis\.Fluency\.FluentAction\<T\> Action\)\[\]\)\.cases') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[])'></a>

## FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, Action\<T\>, \(TValue Comparand,Action\<T\> Action\)\[\]\) Method

Selects an action to invoke on an object by comparing a given value against a list of comparands, then returns the object\.

```csharp
public static T Switch<T,TValue>(this T @this, TValue value, System.Action<T>? @default, params (TValue Comparand,System.Action<T>? Action)[] cases);
```
#### Type parameters

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).T'></a>

`T`

The type of the object\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).TValue'></a>

`TValue`

The type of the value being compared\.
#### Parameters

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).this'></a>

`this` [T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.T')

The object on which this method was called\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).value'></a>

`value` [TValue](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).TValue 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.TValue')

The value to compare\.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).default'></a>

`default` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')


An optional action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.this') if [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.value') is not equal
            to any of the values in [cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.cases').

If this parameter is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') and [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.value') is not equal
            to any of the values in [cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.cases'), this method returns immediately.

<a name='Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).cases'></a>

`cases` [&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[TValue](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).TValue 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.TValue')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')


An array of pairs, where each element consists of a value to compare against [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.value')
            and an optional action to perform on [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.this') if they are equal.

If the action is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), no action is performed if the value is equal to [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.value');
            instead, the method returns immediately.

#### Returns
[T](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).T 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.T')  
A reference to [this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.this') after the action to invoke, if any, returns\.
            The action to invoke is the action of the first case whose comparand is equal to [value](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).value 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.value'),
            or [default](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).default 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.default') if there is no such case\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).this 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[cases](Louis.Fluency.FluentExtensions.md#Louis.Fluency.FluentExtensions.Switch_T,TValue_(thisT,TValue,System.Action_T_,(TValueComparand,System.Action_T_Action)[]).cases 'Louis\.Fluency\.FluentExtensions\.Switch\<T,TValue\>\(this T, TValue, System\.Action\<T\>, \(TValue Comparand,System\.Action\<T\> Action\)\[\]\)\.cases') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').