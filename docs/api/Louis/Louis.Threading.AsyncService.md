#### [Louis](README.md 'README')
### [Louis\.Threading](Louis.Threading.md 'Louis\.Threading')

## AsyncService Class

Base class for long\-running services\.

```csharp
public abstract class AsyncService : System.IAsyncDisposable, System.IDisposable
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → AsyncService

Implements [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable'), [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable')

### Remarks

This class differs from the [BackgroundService](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.backgroundservice 'https://docs\.microsoft\.com/en\-us/dotnet/api/microsoft\.extensions\.hosting\.backgroundservice')
            class found in `Microsoft.Extensions.Hosting` in that it gives you more control over your service:
- you can, optionally, override the [SetupAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.SetupAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.SetupAsync\(System\.Threading\.CancellationToken\)') and [TeardownAsync\(\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.TeardownAsync() 'Louis\.Threading\.AsyncService\.TeardownAsync\(\)') methods
              to separate setup and teardown from the core of your service;
- you can either start your service in background by calling [Start\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.Start(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.Start\(System\.Threading\.CancellationToken\)'),
              start it in background and wait for preliminary operations to complete by calling [StartAndWaitAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.StartAndWaitAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.StartAndWaitAsync\(System\.Threading\.CancellationToken\)'),
              or run it as a task by calling [RunAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.RunAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.RunAsync\(System\.Threading\.CancellationToken\)');
- you can use the [State](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.State 'Louis\.Threading\.AsyncService\.State') property to know, at any time, if your service has been started, has finished starting,
              is stopping, has finished stopping, or has been disposed;
- you can use the [DoneToken](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.DoneToken 'Louis\.Threading\.AsyncService\.DoneToken') property to get a cancellation token that will be canceled
              as soon as execution of the service stops, just before the teardown phase starts;
- you can synchronize other tasks with your service by calling [WaitUntilStartedAsync\(\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.WaitUntilStartedAsync() 'Louis\.Threading\.AsyncService\.WaitUntilStartedAsync\(\)')
              and [WaitUntilStoppedAsync\(\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.WaitUntilStoppedAsync() 'Louis\.Threading\.AsyncService\.WaitUntilStoppedAsync\(\)');
- you can stop your service and let it complete in the background by calling [Stop\(\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.Stop() 'Louis\.Threading\.AsyncService\.Stop\(\)'),
              or stop and wait for completion by calling [StopAndWaitAsync\(\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.StopAndWaitAsync() 'Louis\.Threading\.AsyncService\.StopAndWaitAsync\(\)').
### Constructors

<a name='Louis.Threading.AsyncService.AsyncService()'></a>

## AsyncService\(\) Constructor

Initializes a new instance of the [AsyncService](Louis.Threading.AsyncService.md 'Louis\.Threading\.AsyncService') class\.

```csharp
protected AsyncService();
```
### Properties

<a name='Louis.Threading.AsyncService.DoneToken'></a>

## AsyncService\.DoneToken Property

Gets a [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken') that is canceled as soon as the service has finished executing
\(either successfully or with an exception\) or has failed starting\.

```csharp
public System.Threading.CancellationToken DoneToken { get; }
```

#### Property Value
[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

<a name='Louis.Threading.AsyncService.State'></a>

## AsyncService\.State Property

Gets the state of the service\.

```csharp
public Louis.Threading.AsyncServiceState State { get; }
```

#### Property Value
[AsyncServiceState](Louis.Threading.AsyncServiceState.md 'Louis\.Threading\.AsyncServiceState')

### See Also
- [AsyncServiceState](Louis.Threading.AsyncServiceState.md 'Louis\.Threading\.AsyncServiceState')
### Methods

<a name='Louis.Threading.AsyncService.Dispose()'></a>

## AsyncService\.Dispose\(\) Method

Performs application\-defined tasks associated with freeing, releasing, or resetting unmanaged resources\.

```csharp
public void Dispose();
```

Implements [Dispose\(\)](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable.dispose 'System\.IDisposable\.Dispose')

<a name='Louis.Threading.AsyncService.DisposeAsync()'></a>

## AsyncService\.DisposeAsync\(\) Method

Performs application\-defined tasks associated with freeing, releasing, or
resetting unmanaged resources asynchronously\.

```csharp
public System.Threading.Tasks.ValueTask DisposeAsync();
```

Implements [DisposeAsync\(\)](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable.disposeasync 'System\.IAsyncDisposable\.DisposeAsync')

#### Returns
[System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask')  
A task that represents the asynchronous dispose operation\.

<a name='Louis.Threading.AsyncService.DisposeResourcesAsync()'></a>

## AsyncService\.DisposeResourcesAsync\(\) Method


Asynchronously releases managed resources owned by this instance.

Note that an instance of a class derived from [AsyncService](Louis.Threading.AsyncService.md 'Louis\.Threading\.AsyncService')
            cannot directly own unmanaged resources.

```csharp
protected virtual System.Threading.Tasks.ValueTask DisposeResourcesAsync();
```

#### Returns
[System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask')  
A [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask') that represents the ongoing operation\.

<a name='Louis.Threading.AsyncService.ExecuteAsync(System.Threading.CancellationToken)'></a>

## AsyncService\.ExecuteAsync\(CancellationToken\) Method

When overridden in a derived class, performs the actual operations the service is meant to carry out\.

```csharp
protected abstract System.Threading.Tasks.Task ExecuteAsync(System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Louis.Threading.AsyncService.ExecuteAsync(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken') used to stop the service\.

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A [System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task') representing the ongoing operation\.

<a name='Louis.Threading.AsyncService.LogBeforeExecute()'></a>

## AsyncService\.LogBeforeExecute\(\) Method


Called just before calling the [ExecuteAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.ExecuteAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.ExecuteAsync\(System\.Threading\.CancellationToken\)') method.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected virtual void LogBeforeExecute();
```

<a name='Louis.Threading.AsyncService.LogBeforeSetup()'></a>

## AsyncService\.LogBeforeSetup\(\) Method


Called just before calling the [SetupAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.SetupAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.SetupAsync\(System\.Threading\.CancellationToken\)') method.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected virtual void LogBeforeSetup();
```

<a name='Louis.Threading.AsyncService.LogBeforeTeardown()'></a>

## AsyncService\.LogBeforeTeardown\(\) Method


Called just before calling the [TeardownAsync\(\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.TeardownAsync() 'Louis\.Threading\.AsyncService\.TeardownAsync\(\)') method.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected virtual void LogBeforeTeardown();
```

<a name='Louis.Threading.AsyncService.LogExecuteCanceled()'></a>

## AsyncService\.LogExecuteCanceled\(\) Method


Called if the [ExecuteAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.ExecuteAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.ExecuteAsync\(System\.Threading\.CancellationToken\)') method throws [System\.OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception 'System\.OperationCanceledException')
            and the service has been requested to stop.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected virtual void LogExecuteCanceled();
```

<a name='Louis.Threading.AsyncService.LogExecuteCompleted()'></a>

## AsyncService\.LogExecuteCompleted\(\) Method


Called if the [ExecuteAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.ExecuteAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.ExecuteAsync\(System\.Threading\.CancellationToken\)') method terminates successfully.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected virtual void LogExecuteCompleted();
```

<a name='Louis.Threading.AsyncService.LogExecuteFailed(System.Exception)'></a>

## AsyncService\.LogExecuteFailed\(Exception\) Method


Called if the [ExecuteAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.ExecuteAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.ExecuteAsync\(System\.Threading\.CancellationToken\)') method throws an exception, except when such exception indicates
            that service execution has been canceled.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected virtual void LogExecuteFailed(System.Exception exception);
```
#### Parameters

<a name='Louis.Threading.AsyncService.LogExecuteFailed(System.Exception).exception'></a>

`exception` [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')

The exception thrown by [ExecuteAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.ExecuteAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.ExecuteAsync\(System\.Threading\.CancellationToken\)')\.

<a name='Louis.Threading.AsyncService.LogSetupCanceled()'></a>

## AsyncService\.LogSetupCanceled\(\) Method


Called if the [SetupAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.SetupAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.SetupAsync\(System\.Threading\.CancellationToken\)') method throws [System\.OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception 'System\.OperationCanceledException')
            and the service has been requested to stop.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected virtual void LogSetupCanceled();
```

<a name='Louis.Threading.AsyncService.LogSetupCompleted(bool)'></a>

## AsyncService\.LogSetupCompleted\(bool\) Method


Called if the [SetupAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.SetupAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.SetupAsync\(System\.Threading\.CancellationToken\)') method terminates successfully.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected virtual void LogSetupCompleted(bool success);
```
#### Parameters

<a name='Louis.Threading.AsyncService.LogSetupCompleted(bool).success'></a>

`success` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the operation was successful;
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') otherwise\.

<a name='Louis.Threading.AsyncService.LogSetupFailed(System.Exception)'></a>

## AsyncService\.LogSetupFailed\(Exception\) Method


Called if the [SetupAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.SetupAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.SetupAsync\(System\.Threading\.CancellationToken\)') method throws an exception, except when such exception indicates
            that service execution has been canceled.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected virtual void LogSetupFailed(System.Exception exception);
```
#### Parameters

<a name='Louis.Threading.AsyncService.LogSetupFailed(System.Exception).exception'></a>

`exception` [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')

The exception thrown by [SetupAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.SetupAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.SetupAsync\(System\.Threading\.CancellationToken\)')\.

<a name='Louis.Threading.AsyncService.LogStateChanged(Louis.Threading.AsyncServiceState,Louis.Threading.AsyncServiceState)'></a>

## AsyncService\.LogStateChanged\(AsyncServiceState, AsyncServiceState\) Method


Called whenever the [State](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.State 'Louis\.Threading\.AsyncService\.State') property changes.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected virtual void LogStateChanged(Louis.Threading.AsyncServiceState oldState, Louis.Threading.AsyncServiceState newState);
```
#### Parameters

<a name='Louis.Threading.AsyncService.LogStateChanged(Louis.Threading.AsyncServiceState,Louis.Threading.AsyncServiceState).oldState'></a>

`oldState` [AsyncServiceState](Louis.Threading.AsyncServiceState.md 'Louis\.Threading\.AsyncServiceState')

The old value of [State](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.State 'Louis\.Threading\.AsyncService\.State')\.

<a name='Louis.Threading.AsyncService.LogStateChanged(Louis.Threading.AsyncServiceState,Louis.Threading.AsyncServiceState).newState'></a>

`newState` [AsyncServiceState](Louis.Threading.AsyncServiceState.md 'Louis\.Threading\.AsyncServiceState')

The new value of [State](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.State 'Louis\.Threading\.AsyncService\.State')\.

<a name='Louis.Threading.AsyncService.LogStopRequested(Louis.Threading.AsyncServiceState,Louis.Threading.AsyncServiceState,bool)'></a>

## AsyncService\.LogStopRequested\(AsyncServiceState, AsyncServiceState, bool\) Method


Called upon requesting that a service stops.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected virtual void LogStopRequested(Louis.Threading.AsyncServiceState previousState, Louis.Threading.AsyncServiceState currentState, bool result);
```
#### Parameters

<a name='Louis.Threading.AsyncService.LogStopRequested(Louis.Threading.AsyncServiceState,Louis.Threading.AsyncServiceState,bool).previousState'></a>

`previousState` [AsyncServiceState](Louis.Threading.AsyncServiceState.md 'Louis\.Threading\.AsyncServiceState')

The value of the [State](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.State 'Louis\.Threading\.AsyncService\.State') property before the stop request\.

<a name='Louis.Threading.AsyncService.LogStopRequested(Louis.Threading.AsyncServiceState,Louis.Threading.AsyncServiceState,bool).currentState'></a>

`currentState` [AsyncServiceState](Louis.Threading.AsyncServiceState.md 'Louis\.Threading\.AsyncServiceState')

The value of the [State](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.State 'Louis\.Threading\.AsyncService\.State') property after the stop request\.

<a name='Louis.Threading.AsyncService.LogStopRequested(Louis.Threading.AsyncServiceState,Louis.Threading.AsyncServiceState,bool).result'></a>

`result` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the service was running when requested to stop;
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') otherwise\.

<a name='Louis.Threading.AsyncService.LogTeardownCompleted()'></a>

## AsyncService\.LogTeardownCompleted\(\) Method


Called if the [TeardownAsync\(\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.TeardownAsync() 'Louis\.Threading\.AsyncService\.TeardownAsync\(\)') method terminates successfully.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected virtual void LogTeardownCompleted();
```

<a name='Louis.Threading.AsyncService.LogTeardownFailed(System.Exception)'></a>

## AsyncService\.LogTeardownFailed\(Exception\) Method


Called if the [TeardownAsync\(\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.TeardownAsync() 'Louis\.Threading\.AsyncService\.TeardownAsync\(\)') method throws an exception.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected virtual void LogTeardownFailed(System.Exception exception);
```
#### Parameters

<a name='Louis.Threading.AsyncService.LogTeardownFailed(System.Exception).exception'></a>

`exception` [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')

The exception thrown by [TeardownAsync\(\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.TeardownAsync() 'Louis\.Threading\.AsyncService\.TeardownAsync\(\)')\.

<a name='Louis.Threading.AsyncService.RunAsync(System.Threading.CancellationToken)'></a>

## AsyncService\.RunAsync\(CancellationToken\) Method

Asynchronously runs an asynchronous service\.

```csharp
public System.Threading.Tasks.Task RunAsync(System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Louis.Threading.AsyncService.RunAsync(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken') used to stop the service\.

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A [System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task') that will complete when the service has stopped\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
The service has already been started, either by calling [RunAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.RunAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.RunAsync\(System\.Threading\.CancellationToken\)'), [Start\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.Start(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.Start\(System\.Threading\.CancellationToken\)'),
or [StartAndWaitAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.StartAndWaitAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.StartAndWaitAsync\(System\.Threading\.CancellationToken\)')\.

### Remarks

Only one of [RunAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.RunAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.RunAsync\(System\.Threading\.CancellationToken\)'), [Start\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.Start(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.Start\(System\.Threading\.CancellationToken\)'), and [StartAndWaitAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.StartAndWaitAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.StartAndWaitAsync\(System\.Threading\.CancellationToken\)') may be called, at most once.

<a name='Louis.Threading.AsyncService.SetupAsync(System.Threading.CancellationToken)'></a>

## AsyncService\.SetupAsync\(CancellationToken\) Method

When overridden in a derived class, performs asynchronous operations
related to starting the service\.

```csharp
protected virtual System.Threading.Tasks.ValueTask<bool> SetupAsync(System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Louis.Threading.AsyncService.SetupAsync(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken') used to stop the operation\.

#### Returns
[System\.Threading\.Tasks\.ValueTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1 'System\.Threading\.Tasks\.ValueTask\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1 'System\.Threading\.Tasks\.ValueTask\`1')  
A [Task&lt;bool&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1 'System\.Threading\.Tasks\.ValueTask\`1') whose result will be [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the operation
was successful, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') otherwise\.

### Remarks

If the returned task completes with [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), service execution will be stopped and neither
            [ExecuteAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.ExecuteAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.ExecuteAsync\(System\.Threading\.CancellationToken\)') nor [TeardownAsync\(\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.TeardownAsync() 'Louis\.Threading\.AsyncService\.TeardownAsync\(\)') will be called.

<a name='Louis.Threading.AsyncService.Start(System.Threading.CancellationToken)'></a>

## AsyncService\.Start\(CancellationToken\) Method

Starts an asynchronous service, then return while it continues to run in the background\.

```csharp
public void Start(System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Louis.Threading.AsyncService.Start(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken') used to stop the service\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
The service has already been started, either by calling [RunAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.RunAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.RunAsync\(System\.Threading\.CancellationToken\)'), [Start\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.Start(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.Start\(System\.Threading\.CancellationToken\)'), or [StartAndWaitAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.StartAndWaitAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.StartAndWaitAsync\(System\.Threading\.CancellationToken\)')\.

### Remarks

Only one of [RunAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.RunAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.RunAsync\(System\.Threading\.CancellationToken\)'), [Start\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.Start(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.Start\(System\.Threading\.CancellationToken\)'), and [StartAndWaitAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.StartAndWaitAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.StartAndWaitAsync\(System\.Threading\.CancellationToken\)') may be called, at most once.

If your program needs to know the exact reason why a service stops or fails to start,
            do not use this method; call [RunAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.RunAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.RunAsync\(System\.Threading\.CancellationToken\)') from a separate task instead.

<a name='Louis.Threading.AsyncService.StartAndWaitAsync(System.Threading.CancellationToken)'></a>

## AsyncService\.StartAndWaitAsync\(CancellationToken\) Method

Asynchronously starts an asynchronous service and waits for its [SetupAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.SetupAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.SetupAsync\(System\.Threading\.CancellationToken\)') method to complete\.

```csharp
public System.Threading.Tasks.Task<Louis.Threading.AsyncServiceSetupResult> StartAndWaitAsync(System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Louis.Threading.AsyncService.StartAndWaitAsync(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken') used to stop the service\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[AsyncServiceSetupResult](Louis.Threading.AsyncServiceSetupResult.md 'Louis\.Threading\.AsyncServiceSetupResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A [Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')\<[AsyncServiceSetupResult](Louis.Threading.AsyncServiceSetupResult.md 'Louis\.Threading\.AsyncServiceSetupResult')\> that will complete as soon as the service
either has started or could not start\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
The service has already been started, either by calling [RunAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.RunAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.RunAsync\(System\.Threading\.CancellationToken\)'), [Start\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.Start(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.Start\(System\.Threading\.CancellationToken\)'),  or [StartAndWaitAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.StartAndWaitAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.StartAndWaitAsync\(System\.Threading\.CancellationToken\)')\.

### Remarks

You may call one of [RunAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.RunAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.RunAsync\(System\.Threading\.CancellationToken\)') and [StartAndWaitAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.StartAndWaitAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.StartAndWaitAsync\(System\.Threading\.CancellationToken\)') at most once.

If your program needs to know the exact reason why a service stops or fails to start,
            do not use this method; call [RunAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.RunAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.RunAsync\(System\.Threading\.CancellationToken\)') from a separate task instead.

### See Also
- [AsyncServiceSetupResult](Louis.Threading.AsyncServiceSetupResult.md 'Louis\.Threading\.AsyncServiceSetupResult')

<a name='Louis.Threading.AsyncService.Stop()'></a>

## AsyncService\.Stop\(\) Method

Stops an asynchronous service, without waiting for it to complete\.
If the service has not started yet, calling this method prevents it from starting\.

```csharp
public bool Stop();
```

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the service was running and has been requested to stop;
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the service was not running\.

<a name='Louis.Threading.AsyncService.StopAndWaitAsync()'></a>

## AsyncService\.StopAndWaitAsync\(\) Method

Asynchronously stops an asynchronous service and waits for it to complete\.
If the service has not started yet, calling this method prevents it from starting\.

```csharp
public System.Threading.Tasks.Task<bool> StopAndWaitAsync();
```

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A [Task&lt;bool&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1') that will complete as soon as the service has finished stopping
\(in which case the result will be [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\), or immediately if the service was not running
\(in which case the result will be [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\)\.

<a name='Louis.Threading.AsyncService.TeardownAsync()'></a>

## AsyncService\.TeardownAsync\(\) Method

When overridden in a derived class, performs asynchronous operations
related to stopping the service\.

```csharp
protected virtual System.Threading.Tasks.ValueTask TeardownAsync();
```

#### Returns
[System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask')  
A [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask') that represents the ongoing operation\.

### Remarks

This method is called if and only if the [System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task') returned by [StartAndWaitAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.StartAndWaitAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.StartAndWaitAsync\(System\.Threading\.CancellationToken\)')
            completes successfully, even if the service is prevented from starting afterwards
            (for example if the [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken') passed to [StartAndWaitAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.StartAndWaitAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.StartAndWaitAsync\(System\.Threading\.CancellationToken\)')
            is canceled after [StartAndWaitAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.StartAndWaitAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.StartAndWaitAsync\(System\.Threading\.CancellationToken\)') checks it for the last time).

<a name='Louis.Threading.AsyncService.WaitUntilStartedAsync()'></a>

## AsyncService\.WaitUntilStartedAsync\(\) Method

Asynchronously wait until an asynchronous service has started\.

```csharp
public System.Threading.Tasks.Task<Louis.Threading.AsyncServiceSetupResult> WaitUntilStartedAsync();
```

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[AsyncServiceSetupResult](Louis.Threading.AsyncServiceSetupResult.md 'Louis\.Threading\.AsyncServiceSetupResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A [Task&lt;bool&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1') that will complete as soon as the service has started
\(in which case the result will be [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\), or it could not start
\(in which case the result will be [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\)\.

### Remarks

If neither [RunAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.RunAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.RunAsync\(System\.Threading\.CancellationToken\)') nor [StartAndWaitAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.StartAndWaitAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.StartAndWaitAsync\(System\.Threading\.CancellationToken\)') have been called,
            the returned task will not complete until one of them is called.

If the service has already finished starting, the returned task is already completed.

<a name='Louis.Threading.AsyncService.WaitUntilStoppedAsync()'></a>

## AsyncService\.WaitUntilStoppedAsync\(\) Method

Asynchronously wait until an asynchronous service has stopped\.

```csharp
public System.Threading.Tasks.Task WaitUntilStoppedAsync();
```

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A [System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task') that will complete as soon as the service has started and then stopped,
or until it has failed to start\.

### Remarks

If neither [RunAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.RunAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.RunAsync\(System\.Threading\.CancellationToken\)') nor [StartAndWaitAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.StartAndWaitAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.StartAndWaitAsync\(System\.Threading\.CancellationToken\)') have been called,
            the returned task will not complete until one of them is called.

If the service has already stopped, the returned task is already completed.