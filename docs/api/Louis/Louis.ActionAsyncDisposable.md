#### [Louis](README.md 'README')
### [Louis](Louis.md 'Louis')

## ActionAsyncDisposable Class

Implements both [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable') and [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable') by invoking a given callback upon disposal\.

```csharp
public class ActionAsyncDisposable : System.IAsyncDisposable, System.IDisposable
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ActionAsyncDisposable

Implements [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable'), [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable')
### Constructors

<a name='Louis.ActionAsyncDisposable.ActionAsyncDisposable(System.Func_System.Threading.Tasks.ValueTask_)'></a>

## ActionAsyncDisposable\(Func\<ValueTask\>\) Constructor

Initializes a new instance of the [ActionAsyncDisposable](Louis.ActionAsyncDisposable.md 'Louis\.ActionAsyncDisposable') class\.

```csharp
public ActionAsyncDisposable(System.Func<System.Threading.Tasks.ValueTask> onDisposeAsync);
```
#### Parameters

<a name='Louis.ActionAsyncDisposable.ActionAsyncDisposable(System.Func_System.Threading.Tasks.ValueTask_).onDisposeAsync'></a>

`onDisposeAsync` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')

A callback to invoke upon the first call to [Dispose\(\)](Louis.ActionAsyncDisposable.md#Louis.ActionAsyncDisposable.Dispose() 'Louis\.ActionAsyncDisposable\.Dispose\(\)') or [DisposeAsync\(\)](Louis.ActionAsyncDisposable.md#Louis.ActionAsyncDisposable.DisposeAsync() 'Louis\.ActionAsyncDisposable\.DisposeAsync\(\)')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[onDisposeAsync](Louis.ActionAsyncDisposable.md#Louis.ActionAsyncDisposable.ActionAsyncDisposable(System.Func_System.Threading.Tasks.ValueTask_).onDisposeAsync 'Louis\.ActionAsyncDisposable\.ActionAsyncDisposable\(System\.Func\<System\.Threading\.Tasks\.ValueTask\>\)\.onDisposeAsync') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### See Also
- [ActionDisposable](Louis.ActionDisposable.md 'Louis\.ActionDisposable')
- [LocalActionDisposable](Louis.LocalActionDisposable.md 'Louis\.LocalActionDisposable')
### Methods

<a name='Louis.ActionAsyncDisposable.Dispose()'></a>

## ActionAsyncDisposable\.Dispose\(\) Method


When invoked for the first time, invokes the callback passed to the constructor
            and synchronously awaits its result.

If / when invoked again, or if invoked after [DisposeAsync\(\)](Louis.ActionAsyncDisposable.md#Louis.ActionAsyncDisposable.DisposeAsync() 'Louis\.ActionAsyncDisposable\.DisposeAsync\(\)'), this method does nothing.

```csharp
public void Dispose();
```

Implements [Dispose\(\)](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable.dispose 'System\.IDisposable\.Dispose')

<a name='Louis.ActionAsyncDisposable.DisposeAsync()'></a>

## ActionAsyncDisposable\.DisposeAsync\(\) Method


When invoked for the first time, invokes the callback passed to the constructor.

If / when invoked again, or if invoked after [Dispose\(\)](Louis.ActionAsyncDisposable.md#Louis.ActionAsyncDisposable.Dispose() 'Louis\.ActionAsyncDisposable\.Dispose\(\)'), this method does nothing.

```csharp
public System.Threading.Tasks.ValueTask DisposeAsync();
```

Implements [DisposeAsync\(\)](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable.disposeasync 'System\.IAsyncDisposable\.DisposeAsync')

#### Returns
[System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask')  
A [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask') that represents the ongoing operation\.