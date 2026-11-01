#### [Louis](README.md 'README')
### [Louis](Louis.md 'Louis')

## DisposingUtility Class

Provides utility methods to handle disposing of objects with a mix of [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable')
and [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable') interfaces\.

```csharp
public static class DisposingUtility
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → DisposingUtility
### Methods

<a name='Louis.DisposingUtility.Dispose(object)'></a>

## DisposingUtility\.Dispose\(object\) Method

Synchronously disposes the specified object\.

```csharp
public static void Dispose(object? obj);
```
#### Parameters

<a name='Louis.DisposingUtility.Dispose(object).obj'></a>

`obj` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to dispose\.

### Remarks

If [obj](Louis.DisposingUtility.md#Louis.DisposingUtility.Dispose(object).obj 'Louis\.DisposingUtility\.Dispose\(object\)\.obj') implements [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable'),
            its [System\.IDisposable\.Dispose](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable.dispose 'System\.IDisposable\.Dispose') method is called.

Otherwise, if [obj](Louis.DisposingUtility.md#Louis.DisposingUtility.Dispose(object).obj 'Louis\.DisposingUtility\.Dispose\(object\)\.obj') implements [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable'),
            its [System\.IAsyncDisposable\.DisposeAsync](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable.disposeasync 'System\.IAsyncDisposable\.DisposeAsync') method is called
            and the resulting [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask') is awaited before this method returns.

Otherwise, or if [obj](Louis.DisposingUtility.md#Louis.DisposingUtility.Dispose(object).obj 'Louis\.DisposingUtility\.Dispose\(object\)\.obj') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'),
            this method returns immediately.

This method will not dispose
            [disposable ref structs](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/ref-struct 'https://learn\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/ref\-struct').

### See Also
- [DisposeAsync\(object\)](Louis.DisposingUtility.md#Louis.DisposingUtility.DisposeAsync(object) 'Louis\.DisposingUtility\.DisposeAsync\(object\)')
- [Dispose\(object\[\]\)](Louis.DisposingUtility.md#Louis.DisposingUtility.Dispose(object[]) 'Louis\.DisposingUtility\.Dispose\(object\[\]\)')

<a name='Louis.DisposingUtility.Dispose(object[])'></a>

## DisposingUtility\.Dispose\(object\[\]\) Method

Synchronously dispose all specified disposable objects\.

```csharp
public static void Dispose(params object?[] items);
```
#### Parameters

<a name='Louis.DisposingUtility.Dispose(object[]).items'></a>

`items` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The objects to dispose\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[items](Louis.DisposingUtility.md#Louis.DisposingUtility.Dispose(object[]).items 'Louis\.DisposingUtility\.Dispose\(object\[\]\)\.items') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### Remarks

This method calls [DisposeAll\(this IEnumerable\)](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.DisposeAll(thisSystem.Collections.IEnumerable) 'Louis\.Collections\.EnumerableExtensions\.DisposeAll\(this System\.Collections\.IEnumerable\)')
            on the [items](Louis.DisposingUtility.md#Louis.DisposingUtility.Dispose(object[]).items 'Louis\.DisposingUtility\.Dispose\(object\[\]\)\.items') array.

This method will not dispose
            [disposable ref structs](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/ref-struct 'https://learn\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/ref\-struct').

### See Also
- [Dispose\(object\)](Louis.DisposingUtility.md#Louis.DisposingUtility.Dispose(object) 'Louis\.DisposingUtility\.Dispose\(object\)')
- [DisposeAsync\(object\[\]\)](Louis.DisposingUtility.md#Louis.DisposingUtility.DisposeAsync(object[]) 'Louis\.DisposingUtility\.DisposeAsync\(object\[\]\)')
- [DisposeAll\(this IEnumerable\)](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.DisposeAll(thisSystem.Collections.IEnumerable) 'Louis\.Collections\.EnumerableExtensions\.DisposeAll\(this System\.Collections\.IEnumerable\)')

<a name='Louis.DisposingUtility.DisposeAsync(object)'></a>

## DisposingUtility\.DisposeAsync\(object\) Method

Asynchronously or synchronously disposes the specified object\.

```csharp
public static System.Threading.Tasks.ValueTask DisposeAsync(object? obj);
```
#### Parameters

<a name='Louis.DisposingUtility.DisposeAsync(object).obj'></a>

`obj` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to dispose\.

#### Returns
[System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask')  
A [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask') representing the ongoing operation\.

### Remarks

If [obj](Louis.DisposingUtility.md#Louis.DisposingUtility.DisposeAsync(object).obj 'Louis\.DisposingUtility\.DisposeAsync\(object\)\.obj') implements [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable'),
            it is disposed asynchronously and the returned [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask') represents
            the ongoing call to [System\.IAsyncDisposable\.DisposeAsync](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable.disposeasync 'System\.IAsyncDisposable\.DisposeAsync').

Otherwise, if [obj](Louis.DisposingUtility.md#Louis.DisposingUtility.DisposeAsync(object).obj 'Louis\.DisposingUtility\.DisposeAsync\(object\)\.obj') implements [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable'),
            it is disposed synchronously and this method returns a completed [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask').

Otherwise, or if [obj](Louis.DisposingUtility.md#Louis.DisposingUtility.DisposeAsync(object).obj 'Louis\.DisposingUtility\.DisposeAsync\(object\)\.obj') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'),
            this method immediately returns a completed [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask').

This method will not dispose
            [disposable ref structs](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/ref-struct 'https://learn\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/ref\-struct').

### See Also
- [Dispose\(object\)](Louis.DisposingUtility.md#Louis.DisposingUtility.Dispose(object) 'Louis\.DisposingUtility\.Dispose\(object\)')
- [DisposeAsync\(object\[\]\)](Louis.DisposingUtility.md#Louis.DisposingUtility.DisposeAsync(object[]) 'Louis\.DisposingUtility\.DisposeAsync\(object\[\]\)')

<a name='Louis.DisposingUtility.DisposeAsync(object[])'></a>

## DisposingUtility\.DisposeAsync\(object\[\]\) Method

Asynchronously dispose all specified disposable objects\.

```csharp
public static System.Threading.Tasks.ValueTask DisposeAsync(params object?[] items);
```
#### Parameters

<a name='Louis.DisposingUtility.DisposeAsync(object[]).items'></a>

`items` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The objects to dispose\.

#### Returns
[System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask')  
A [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask') representing the ongoing operation\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[items](Louis.DisposingUtility.md#Louis.DisposingUtility.DisposeAsync(object[]).items 'Louis\.DisposingUtility\.DisposeAsync\(object\[\]\)\.items') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### Remarks

This method calls [DisposeAllAsync\(this IEnumerable\)](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.DisposeAllAsync(thisSystem.Collections.IEnumerable) 'Louis\.Collections\.EnumerableExtensions\.DisposeAllAsync\(this System\.Collections\.IEnumerable\)')
            on the [items](Louis.DisposingUtility.md#Louis.DisposingUtility.DisposeAsync(object[]).items 'Louis\.DisposingUtility\.DisposeAsync\(object\[\]\)\.items') array.

This method will not dispose
            [disposable ref structs](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/ref-struct 'https://learn\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/ref\-struct').

### See Also
- [DisposeAsync\(object\)](Louis.DisposingUtility.md#Louis.DisposingUtility.DisposeAsync(object) 'Louis\.DisposingUtility\.DisposeAsync\(object\)')
- [Dispose\(object\[\]\)](Louis.DisposingUtility.md#Louis.DisposingUtility.Dispose(object[]) 'Louis\.DisposingUtility\.Dispose\(object\[\]\)')
- [DisposeAllAsync\(this IEnumerable\)](Louis.Collections.EnumerableExtensions.md#Louis.Collections.EnumerableExtensions.DisposeAllAsync(thisSystem.Collections.IEnumerable) 'Louis\.Collections\.EnumerableExtensions\.DisposeAllAsync\(this System\.Collections\.IEnumerable\)')