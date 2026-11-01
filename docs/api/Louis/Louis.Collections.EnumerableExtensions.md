#### [Louis](README.md 'README')
### [Louis\.Collections](Louis.Collections.md 'Louis\.Collections')

## EnumerableExtensions Class

Provides extension methods for types implementing [System\.Collections\.IEnumerable](https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable 'System\.Collections\.IEnumerable') or [System\.Collections\.Generic\.IEnumerable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')\.

```csharp
public static class EnumerableExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → EnumerableExtensions
### Methods

<a name='Louis.Collections.EnumerableExtensions.DisposeAll(thisSystem.Collections.IEnumerable)'></a>

## EnumerableExtensions\.DisposeAll\(this IEnumerable\) Method


Disposes all items that implement either [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable') or [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable').

If an item implements both, only [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable') is considered.

```csharp
public static void DisposeAll(this System.Collections.IEnumerable @this);
```
#### Parameters

<a name='Louis.Collections.EnumerableExtensions.DisposeAll(thisSystem.Collections.IEnumerable).this'></a>

`this` [System\.Collections\.IEnumerable](https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable 'System\.Collections\.IEnumerable')

The [System\.Collections\.IEnumerable](https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable 'System\.Collections\.IEnumerable') interface on which this method is called\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.DisposeAll(thisSystem.Collections.IEnumerable).this 'Louis\.Collections\.EnumerableExtensions\.DisposeAll\(this System\.Collections\.IEnumerable\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.AggregateException](https://learn.microsoft.com/en-us/dotnet/api/system.aggregateexception 'System\.AggregateException')  
One or more exceptions were raised by the [System\.IDisposable\.Dispose](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable.dispose 'System\.IDisposable\.Dispose')
and/or [System\.IAsyncDisposable\.DisposeAsync](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable.disposeasync 'System\.IAsyncDisposable\.DisposeAsync') methods of items\.

### Remarks

This method will not dispose
            [disposable ref structs](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/ref-struct 'https://learn\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/ref\-struct').

<a name='Louis.Collections.EnumerableExtensions.DisposeAllAsync(thisSystem.Collections.IEnumerable)'></a>

## EnumerableExtensions\.DisposeAllAsync\(this IEnumerable\) Method


Asynchronously disposes all items that implement either [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable') or [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable').

If an item implements both, only [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable') is considered.

```csharp
public static System.Threading.Tasks.ValueTask DisposeAllAsync(this System.Collections.IEnumerable @this);
```
#### Parameters

<a name='Louis.Collections.EnumerableExtensions.DisposeAllAsync(thisSystem.Collections.IEnumerable).this'></a>

`this` [System\.Collections\.IEnumerable](https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable 'System\.Collections\.IEnumerable')

The [System\.Collections\.IEnumerable](https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable 'System\.Collections\.IEnumerable') interface on which this method is called\.

#### Returns
[System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask')  
A [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask') that represents the ongoing operation\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.DisposeAllAsync(thisSystem.Collections.IEnumerable).this 'Louis\.Collections\.EnumerableExtensions\.DisposeAllAsync\(this System\.Collections\.IEnumerable\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.AggregateException](https://learn.microsoft.com/en-us/dotnet/api/system.aggregateexception 'System\.AggregateException')  
One or more exceptions were raised by the [System\.IAsyncDisposable\.DisposeAsync](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable.disposeasync 'System\.IAsyncDisposable\.DisposeAsync')
and/or [System\.IDisposable\.Dispose](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable.dispose 'System\.IDisposable\.Dispose') methods of items\.

### Remarks

This method will not dispose
            [disposable ref structs](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/ref-struct 'https://learn\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/ref\-struct').

<a name='Louis.Collections.EnumerableExtensions.WhereNot_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,bool_)'></a>

## EnumerableExtensions\.WhereNot\<T\>\(this IEnumerable\<T\>, Func\<T,bool\>\) Method

Filters a sequence of values based on a predicate, taking only those that do not satisfy the condition set by the predicate\.

```csharp
public static System.Collections.Generic.IEnumerable<T> WhereNot<T>(this System.Collections.Generic.IEnumerable<T> @this, System.Func<T,bool> predicate);
```
#### Type parameters

<a name='Louis.Collections.EnumerableExtensions.WhereNot_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,bool_).T'></a>

`T`

The type of the elements of [this](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.WhereNot_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,bool_).this 'Louis\.Collections\.EnumerableExtensions\.WhereNot\<T\>\(this System\.Collections\.Generic\.IEnumerable\<T\>, System\.Func\<T,bool\>\)\.this')\.
#### Parameters

<a name='Louis.Collections.EnumerableExtensions.WhereNot_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,bool_).this'></a>

`this` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[T](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.WhereNot_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,bool_).T 'Louis\.Collections\.EnumerableExtensions\.WhereNot\<T\>\(this System\.Collections\.Generic\.IEnumerable\<T\>, System\.Func\<T,bool\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

An [System\.Collections\.Generic\.IEnumerable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1') to filter\.

<a name='Louis.Collections.EnumerableExtensions.WhereNot_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[T](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.WhereNot_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,bool_).T 'Louis\.Collections\.EnumerableExtensions\.WhereNot\<T\>\(this System\.Collections\.Generic\.IEnumerable\<T\>, System\.Func\<T,bool\>\)\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

A function to test each element for a condition\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[T](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.WhereNot_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,bool_).T 'Louis\.Collections\.EnumerableExtensions\.WhereNot\<T\>\(this System\.Collections\.Generic\.IEnumerable\<T\>, System\.Func\<T,bool\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
An [System\.Collections\.Generic\.IEnumerable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1') that contains elements from the input sequence that do not satisfy the condition
            defined by [predicate](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.WhereNot_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,bool_).predicate 'Louis\.Collections\.EnumerableExtensions\.WhereNot\<T\>\(this System\.Collections\.Generic\.IEnumerable\<T\>, System\.Func\<T,bool\>\)\.predicate')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.WhereNot_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,bool_).this 'Louis\.Collections\.EnumerableExtensions\.WhereNot\<T\>\(this System\.Collections\.Generic\.IEnumerable\<T\>, System\.Func\<T,bool\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[predicate](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.WhereNot_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,bool_).predicate 'Louis\.Collections\.EnumerableExtensions\.WhereNot\<T\>\(this System\.Collections\.Generic\.IEnumerable\<T\>, System\.Func\<T,bool\>\)\.predicate') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

<a name='Louis.Collections.EnumerableExtensions.WhereNotNull_T_(thisSystem.Collections.Generic.IEnumerable_System.Nullable_T__)'></a>

## EnumerableExtensions\.WhereNotNull\<T\>\(this IEnumerable\<Nullable\<T\>\>\) Method

Filters a sequence of nullable values, taking only those that are not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

```csharp
public static System.Collections.Generic.IEnumerable<T> WhereNotNull<T>(this System.Collections.Generic.IEnumerable<System.Nullable<T>> @this)
    where T : struct;
```
#### Type parameters

<a name='Louis.Collections.EnumerableExtensions.WhereNotNull_T_(thisSystem.Collections.Generic.IEnumerable_System.Nullable_T__).T'></a>

`T`

The type of the elements of [this](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.WhereNotNull_T_(thisSystem.Collections.Generic.IEnumerable_System.Nullable_T__).this 'Louis\.Collections\.EnumerableExtensions\.WhereNotNull\<T\>\(this System\.Collections\.Generic\.IEnumerable\<System\.Nullable\<T\>\>\)\.this')\.
#### Parameters

<a name='Louis.Collections.EnumerableExtensions.WhereNotNull_T_(thisSystem.Collections.Generic.IEnumerable_System.Nullable_T__).this'></a>

`this` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[T](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.WhereNotNull_T_(thisSystem.Collections.Generic.IEnumerable_System.Nullable_T__).T 'Louis\.Collections\.EnumerableExtensions\.WhereNotNull\<T\>\(this System\.Collections\.Generic\.IEnumerable\<System\.Nullable\<T\>\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

An [System\.Collections\.Generic\.IEnumerable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1') to filter\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[T](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.WhereNotNull_T_(thisSystem.Collections.Generic.IEnumerable_System.Nullable_T__).T 'Louis\.Collections\.EnumerableExtensions\.WhereNotNull\<T\>\(this System\.Collections\.Generic\.IEnumerable\<System\.Nullable\<T\>\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
An [System\.Collections\.Generic\.IEnumerable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1') that contains the values of the elements from the input sequence that are not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.WhereNotNull_T_(thisSystem.Collections.Generic.IEnumerable_System.Nullable_T__).this 'Louis\.Collections\.EnumerableExtensions\.WhereNotNull\<T\>\(this System\.Collections\.Generic\.IEnumerable\<System\.Nullable\<T\>\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='Louis.Collections.EnumerableExtensions.WhereNotNull_T_(thisSystem.Collections.Generic.IEnumerable_T_)'></a>

## EnumerableExtensions\.WhereNotNull\<T\>\(this IEnumerable\<T\>\) Method

Filters a sequence of nullable values, taking only those that are not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

```csharp
public static System.Collections.Generic.IEnumerable<T> WhereNotNull<T>(this System.Collections.Generic.IEnumerable<T?> @this)
    where T : class;
```
#### Type parameters

<a name='Louis.Collections.EnumerableExtensions.WhereNotNull_T_(thisSystem.Collections.Generic.IEnumerable_T_).T'></a>

`T`

The type of the elements of [this](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.WhereNotNull_T_(thisSystem.Collections.Generic.IEnumerable_T_).this 'Louis\.Collections\.EnumerableExtensions\.WhereNotNull\<T\>\(this System\.Collections\.Generic\.IEnumerable\<T\>\)\.this')\.
#### Parameters

<a name='Louis.Collections.EnumerableExtensions.WhereNotNull_T_(thisSystem.Collections.Generic.IEnumerable_T_).this'></a>

`this` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[T](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.WhereNotNull_T_(thisSystem.Collections.Generic.IEnumerable_T_).T 'Louis\.Collections\.EnumerableExtensions\.WhereNotNull\<T\>\(this System\.Collections\.Generic\.IEnumerable\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

An [System\.Collections\.Generic\.IEnumerable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1') to filter\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[T](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.WhereNotNull_T_(thisSystem.Collections.Generic.IEnumerable_T_).T 'Louis\.Collections\.EnumerableExtensions\.WhereNotNull\<T\>\(this System\.Collections\.Generic\.IEnumerable\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
An [System\.Collections\.Generic\.IEnumerable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1') that contains elements from the input sequence that are not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.WhereNotNull_T_(thisSystem.Collections.Generic.IEnumerable_T_).this 'Louis\.Collections\.EnumerableExtensions\.WhereNotNull\<T\>\(this System\.Collections\.Generic\.IEnumerable\<T\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='Louis.Collections.EnumerableExtensions.WhereNotNullOrEmpty(thisSystem.Collections.Generic.IEnumerable_string_)'></a>

## EnumerableExtensions\.WhereNotNullOrEmpty\(this IEnumerable\<string\>\) Method

Filters a sequence of nullable strings, taking only those that are neither [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') nor the empty string\.

```csharp
public static System.Collections.Generic.IEnumerable<string> WhereNotNullOrEmpty(this System.Collections.Generic.IEnumerable<string?> @this);
```
#### Parameters

<a name='Louis.Collections.EnumerableExtensions.WhereNotNullOrEmpty(thisSystem.Collections.Generic.IEnumerable_string_).this'></a>

`this` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

An [IEnumerable&lt;string?&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1') to filter\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
An [IEnumerable&lt;string&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1') that contains elements from the input sequence
            that are neither [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') nor the empty string\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.WhereNotNullOrEmpty(thisSystem.Collections.Generic.IEnumerable_string_).this 'Louis\.Collections\.EnumerableExtensions\.WhereNotNullOrEmpty\(this System\.Collections\.Generic\.IEnumerable\<string\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='Louis.Collections.EnumerableExtensions.WhereNotNullOrWhiteSpace(thisSystem.Collections.Generic.IEnumerable_string_)'></a>

## EnumerableExtensions\.WhereNotNullOrWhiteSpace\(this IEnumerable\<string\>\) Method

Filters a sequence of nullable strings, taking only those that are not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'),
nor empty, nor consisting only of white\-space characters\.

```csharp
public static System.Collections.Generic.IEnumerable<string> WhereNotNullOrWhiteSpace(this System.Collections.Generic.IEnumerable<string?> @this);
```
#### Parameters

<a name='Louis.Collections.EnumerableExtensions.WhereNotNullOrWhiteSpace(thisSystem.Collections.Generic.IEnumerable_string_).this'></a>

`this` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

An [IEnumerable&lt;string?&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1') to filter\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
An [IEnumerable&lt;string&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1') that contains elements from the input sequence
            that are not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'), nor empty, nor consisting only of white\-space characters\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.WhereNotNullOrWhiteSpace(thisSystem.Collections.Generic.IEnumerable_string_).this 'Louis\.Collections\.EnumerableExtensions\.WhereNotNullOrWhiteSpace\(this System\.Collections\.Generic\.IEnumerable\<string\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.