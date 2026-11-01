#### [Louis](README.md 'README')
### [Louis](Louis.md 'Louis')

## ActionDisposable Class

Implements [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable') by invoking a given [System\.Action](https://learn.microsoft.com/en-us/dotnet/api/system.action 'System\.Action') upon disposal\.

```csharp
public class ActionDisposable : System.IDisposable
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ActionDisposable

Implements [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable')
### Constructors

<a name='Louis.ActionDisposable.ActionDisposable(System.Action)'></a>

## ActionDisposable\(Action\) Constructor

Initializes a new instance of the [ActionDisposable](Louis.ActionDisposable.md 'Louis\.ActionDisposable') class\.

```csharp
public ActionDisposable(System.Action onDispose);
```
#### Parameters

<a name='Louis.ActionDisposable.ActionDisposable(System.Action).onDispose'></a>

`onDispose` [System\.Action](https://learn.microsoft.com/en-us/dotnet/api/system.action 'System\.Action')

The [System\.Action](https://learn.microsoft.com/en-us/dotnet/api/system.action 'System\.Action') to call upon the first call to [Dispose\(\)](Louis.ActionDisposable.md#Louis.ActionDisposable.Dispose() 'Louis\.ActionDisposable\.Dispose\(\)')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[onDispose](Louis.ActionDisposable.md#Louis.ActionDisposable.ActionDisposable(System.Action).onDispose 'Louis\.ActionDisposable\.ActionDisposable\(System\.Action\)\.onDispose') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### See Also
- [LocalActionDisposable](Louis.LocalActionDisposable.md 'Louis\.LocalActionDisposable')
- [ActionAsyncDisposable](Louis.ActionAsyncDisposable.md 'Louis\.ActionAsyncDisposable')
### Methods

<a name='Louis.ActionDisposable.Dispose()'></a>

## ActionDisposable\.Dispose\(\) Method


When invoked for the first time, invokes the [System\.Action](https://learn.microsoft.com/en-us/dotnet/api/system.action 'System\.Action') passed to the constructor.

If / when invoked again, this method does nothing.

```csharp
public void Dispose();
```

Implements [Dispose\(\)](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable.dispose 'System\.IDisposable\.Dispose')