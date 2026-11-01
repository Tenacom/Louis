#### [Louis](README.md 'README')
### [Louis](Louis.md 'Louis')

## LocalActionDisposable Struct


Implements [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable') by invoking a given [System\.Action](https://learn.microsoft.com/en-us/dotnet/api/system.action 'System\.Action') upon disposal.

This type should be used instead of [ActionDisposable](Louis.ActionDisposable.md 'Louis\.ActionDisposable') when needed in a local scope,
            as it avoids a heap allocation.

```csharp
public ref struct LocalActionDisposable
```
### Constructors

<a name='Louis.LocalActionDisposable.LocalActionDisposable(System.Action)'></a>

## LocalActionDisposable\(Action\) Constructor

Initializes a new instance of the [LocalActionDisposable](Louis.LocalActionDisposable.md 'Louis\.LocalActionDisposable') struct\.

```csharp
public LocalActionDisposable(System.Action onDispose);
```
#### Parameters

<a name='Louis.LocalActionDisposable.LocalActionDisposable(System.Action).onDispose'></a>

`onDispose` [System\.Action](https://learn.microsoft.com/en-us/dotnet/api/system.action 'System\.Action')

The [System\.Action](https://learn.microsoft.com/en-us/dotnet/api/system.action 'System\.Action') to call upon the first call to [Dispose\(\)](Louis.LocalActionDisposable.md#Louis.LocalActionDisposable.Dispose() 'Louis\.LocalActionDisposable\.Dispose\(\)')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[onDispose](Louis.LocalActionDisposable.md#Louis.LocalActionDisposable.LocalActionDisposable(System.Action).onDispose 'Louis\.LocalActionDisposable\.LocalActionDisposable\(System\.Action\)\.onDispose') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### See Also
- [ActionDisposable](Louis.ActionDisposable.md 'Louis\.ActionDisposable')
- [ActionAsyncDisposable](Louis.ActionAsyncDisposable.md 'Louis\.ActionAsyncDisposable')
### Methods

<a name='Louis.LocalActionDisposable.Dispose()'></a>

## LocalActionDisposable\.Dispose\(\) Method


When invoked for the first time, invokes the [System\.Action](https://learn.microsoft.com/en-us/dotnet/api/system.action 'System\.Action') passed to the constructor.

If / when invoked again, this method does nothing.

```csharp
public void Dispose();
```