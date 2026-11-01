#### [Louis](README.md 'README')
### [Louis](Louis.md 'Louis')

## AsyncDisposableExtensions Class

Provides extension methods for objects implementing [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable')\.

```csharp
public static class AsyncDisposableExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → AsyncDisposableExtensions
### Methods

<a name='Louis.AsyncDisposableExtensions.DisposeSynchronously(thisSystem.IAsyncDisposable)'></a>

## AsyncDisposableExtensions\.DisposeSynchronously\(this IAsyncDisposable\) Method

Disposes an [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable') synchronously by awaiting the result of [System\.IAsyncDisposable\.DisposeAsync](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable.disposeasync 'System\.IAsyncDisposable\.DisposeAsync')\.

```csharp
public static void DisposeSynchronously(this System.IAsyncDisposable @this);
```
#### Parameters

<a name='Louis.AsyncDisposableExtensions.DisposeSynchronously(thisSystem.IAsyncDisposable).this'></a>

`this` [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable')

The [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable') interface on which this method is called\.

### Remarks

The most common use case for this method is add an implementation of [System\.IDisposable\.Dispose](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable.dispose 'System\.IDisposable\.Dispose')
            to a type that already implements [System\.IAsyncDisposable\.DisposeAsync](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable.disposeasync 'System\.IAsyncDisposable\.DisposeAsync'), without duplicating any code:

```csharp
public void Dispose() => this.DisposeSynchronously();
```