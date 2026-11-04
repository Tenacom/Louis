#### [Louis\.Hosting](README.md 'README')
### [Louis\.Hosting](Louis.Hosting.md 'Louis\.Hosting')

## AsyncHostedService Class

Subclasses [AsyncService](../Louis/Louis.Threading.AsyncService.md 'Louis\.Threading\.AsyncService'), providing support for logging and implementing [Microsoft\.Extensions\.Hosting\.IHostedService](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihostedservice 'Microsoft\.Extensions\.Hosting\.IHostedService')\.

```csharp
public abstract class AsyncHostedService : Louis.Threading.AsyncService, Microsoft.Extensions.Hosting.IHostedService
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [AsyncService](../Louis/Louis.Threading.AsyncService.md 'Louis\.Threading\.AsyncService') → AsyncHostedService

Implements [Microsoft\.Extensions\.Hosting\.IHostedService](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihostedservice 'Microsoft\.Extensions\.Hosting\.IHostedService')
### Constructors

<a name='Louis.Hosting.AsyncHostedService.AsyncHostedService(Microsoft.Extensions.Logging.ILogger)'></a>

## AsyncHostedService\(ILogger\) Constructor

Initializes a new instance of the [AsyncHostedService](Louis.Hosting.AsyncHostedService.md 'Louis\.Hosting\.AsyncHostedService') class\.

```csharp
protected AsyncHostedService(Microsoft.Extensions.Logging.ILogger logger);
```
#### Parameters

<a name='Louis.Hosting.AsyncHostedService.AsyncHostedService(Microsoft.Extensions.Logging.ILogger).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger 'Microsoft\.Extensions\.Logging\.ILogger')

An [Microsoft\.Extensions\.Logging\.ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger 'Microsoft\.Extensions\.Logging\.ILogger') to use for logging\.
### Properties

<a name='Louis.Hosting.AsyncHostedService.FailOnSetupNotStarted'></a>

## AsyncHostedService\.FailOnSetupNotStarted Property

Gets a value indicating whether [StartAsync\(CancellationToken\)](Louis.Hosting.AsyncHostedService.md#Louis.Hosting.AsyncHostedService.StartAsync(System.Threading.CancellationToken) 'Louis\.Hosting\.AsyncHostedService\.StartAsync\(System\.Threading\.CancellationToken\)') will fail if
the result of [StartAndWaitAsync\(CancellationToken\)](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.StartAndWaitAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.StartAndWaitAsync\(System\.Threading\.CancellationToken\)') is [NotStarted](../Louis/Louis.Threading.AsyncServiceSetupResult.md#Louis.Threading.AsyncServiceSetupResult.NotStarted 'Louis\.Threading\.AsyncServiceSetupResult\.NotStarted')\.

```csharp
protected virtual bool FailOnSetupNotStarted { protected get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='Louis.Hosting.AsyncHostedService.FailOnSetupUnsuccessful'></a>

## AsyncHostedService\.FailOnSetupUnsuccessful Property

Gets a value indicating whether [StartAsync\(CancellationToken\)](Louis.Hosting.AsyncHostedService.md#Louis.Hosting.AsyncHostedService.StartAsync(System.Threading.CancellationToken) 'Louis\.Hosting\.AsyncHostedService\.StartAsync\(System\.Threading\.CancellationToken\)') will fail if
the result of [StartAndWaitAsync\(CancellationToken\)](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.StartAndWaitAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.StartAndWaitAsync\(System\.Threading\.CancellationToken\)') is [Unsuccessful](../Louis/Louis.Threading.AsyncServiceSetupResult.md#Louis.Threading.AsyncServiceSetupResult.Unsuccessful 'Louis\.Threading\.AsyncServiceSetupResult\.Unsuccessful')\.

```csharp
protected virtual bool FailOnSetupUnsuccessful { protected get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')
### Methods

<a name='Louis.Hosting.AsyncHostedService.LogBeforeExecute()'></a>

## AsyncHostedService\.LogBeforeExecute\(\) Method


Called just before calling the [ExecuteAsync\(CancellationToken\)](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.ExecuteAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.ExecuteAsync\(System\.Threading\.CancellationToken\)') method.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected sealed override void LogBeforeExecute();
```

<a name='Louis.Hosting.AsyncHostedService.LogBeforeSetup()'></a>

## AsyncHostedService\.LogBeforeSetup\(\) Method


Called just before calling the [SetupAsync\(CancellationToken\)](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.SetupAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.SetupAsync\(System\.Threading\.CancellationToken\)') method.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected sealed override void LogBeforeSetup();
```

<a name='Louis.Hosting.AsyncHostedService.LogBeforeTeardown()'></a>

## AsyncHostedService\.LogBeforeTeardown\(\) Method


Called just before calling the [TeardownAsync\(\)](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.TeardownAsync() 'Louis\.Threading\.AsyncService\.TeardownAsync') method.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected sealed override void LogBeforeTeardown();
```

<a name='Louis.Hosting.AsyncHostedService.LogExecuteCanceled()'></a>

## AsyncHostedService\.LogExecuteCanceled\(\) Method


Called if the [ExecuteAsync\(CancellationToken\)](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.ExecuteAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.ExecuteAsync\(System\.Threading\.CancellationToken\)') method throws [System\.OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception 'System\.OperationCanceledException')
            and the service has been requested to stop.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected sealed override void LogExecuteCanceled();
```

<a name='Louis.Hosting.AsyncHostedService.LogExecuteCompleted()'></a>

## AsyncHostedService\.LogExecuteCompleted\(\) Method


Called if the [ExecuteAsync\(CancellationToken\)](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.ExecuteAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.ExecuteAsync\(System\.Threading\.CancellationToken\)') method terminates successfully.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected sealed override void LogExecuteCompleted();
```

<a name='Louis.Hosting.AsyncHostedService.LogExecuteFailed(System.Exception)'></a>

## AsyncHostedService\.LogExecuteFailed\(Exception\) Method


Called if the [ExecuteAsync\(CancellationToken\)](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.ExecuteAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.ExecuteAsync\(System\.Threading\.CancellationToken\)') method throws an exception, except when such exception indicates
            that service execution has been canceled.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected sealed override void LogExecuteFailed(System.Exception exception);
```
#### Parameters

<a name='Louis.Hosting.AsyncHostedService.LogExecuteFailed(System.Exception).exception'></a>

`exception` [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')

The exception thrown by [ExecuteAsync\(CancellationToken\)](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.ExecuteAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.ExecuteAsync\(System\.Threading\.CancellationToken\)')\.

<a name='Louis.Hosting.AsyncHostedService.LogSetupCanceled()'></a>

## AsyncHostedService\.LogSetupCanceled\(\) Method


Called if the [SetupAsync\(CancellationToken\)](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.SetupAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.SetupAsync\(System\.Threading\.CancellationToken\)') method throws [System\.OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception 'System\.OperationCanceledException')
            and the service has been requested to stop.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected sealed override void LogSetupCanceled();
```

<a name='Louis.Hosting.AsyncHostedService.LogSetupCompleted(bool)'></a>

## AsyncHostedService\.LogSetupCompleted\(bool\) Method


Called if the [SetupAsync\(CancellationToken\)](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.SetupAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.SetupAsync\(System\.Threading\.CancellationToken\)') method terminates successfully.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected sealed override void LogSetupCompleted(bool success);
```
#### Parameters

<a name='Louis.Hosting.AsyncHostedService.LogSetupCompleted(bool).success'></a>

`success` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the operation was successful;
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') otherwise\.

<a name='Louis.Hosting.AsyncHostedService.LogSetupFailed(System.Exception)'></a>

## AsyncHostedService\.LogSetupFailed\(Exception\) Method


Called if the [SetupAsync\(CancellationToken\)](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.SetupAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.SetupAsync\(System\.Threading\.CancellationToken\)') method throws an exception, except when such exception indicates
            that service execution has been canceled.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected sealed override void LogSetupFailed(System.Exception exception);
```
#### Parameters

<a name='Louis.Hosting.AsyncHostedService.LogSetupFailed(System.Exception).exception'></a>

`exception` [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')

The exception thrown by [SetupAsync\(CancellationToken\)](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.SetupAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.SetupAsync\(System\.Threading\.CancellationToken\)')\.

<a name='Louis.Hosting.AsyncHostedService.LogStateChanged(Louis.Threading.AsyncServiceState,Louis.Threading.AsyncServiceState)'></a>

## AsyncHostedService\.LogStateChanged\(AsyncServiceState, AsyncServiceState\) Method


Called whenever the [State](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.State 'Louis\.Threading\.AsyncService\.State') property changes.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected sealed override void LogStateChanged(Louis.Threading.AsyncServiceState oldState, Louis.Threading.AsyncServiceState newState);
```
#### Parameters

<a name='Louis.Hosting.AsyncHostedService.LogStateChanged(Louis.Threading.AsyncServiceState,Louis.Threading.AsyncServiceState).oldState'></a>

`oldState` [AsyncServiceState](../Louis/Louis.Threading.AsyncServiceState.md 'Louis\.Threading\.AsyncServiceState')

The old value of [State](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.State 'Louis\.Threading\.AsyncService\.State')\.

<a name='Louis.Hosting.AsyncHostedService.LogStateChanged(Louis.Threading.AsyncServiceState,Louis.Threading.AsyncServiceState).newState'></a>

`newState` [AsyncServiceState](../Louis/Louis.Threading.AsyncServiceState.md 'Louis\.Threading\.AsyncServiceState')

The new value of [State](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.State 'Louis\.Threading\.AsyncService\.State')\.

<a name='Louis.Hosting.AsyncHostedService.LogStopRequested(Louis.Threading.AsyncServiceState,Louis.Threading.AsyncServiceState,bool)'></a>

## AsyncHostedService\.LogStopRequested\(AsyncServiceState, AsyncServiceState, bool\) Method


Called upon requesting that a service stops.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected sealed override void LogStopRequested(Louis.Threading.AsyncServiceState previousState, Louis.Threading.AsyncServiceState currentState, bool result);
```
#### Parameters

<a name='Louis.Hosting.AsyncHostedService.LogStopRequested(Louis.Threading.AsyncServiceState,Louis.Threading.AsyncServiceState,bool).previousState'></a>

`previousState` [AsyncServiceState](../Louis/Louis.Threading.AsyncServiceState.md 'Louis\.Threading\.AsyncServiceState')

The value of the [State](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.State 'Louis\.Threading\.AsyncService\.State') property before the stop request\.

<a name='Louis.Hosting.AsyncHostedService.LogStopRequested(Louis.Threading.AsyncServiceState,Louis.Threading.AsyncServiceState,bool).currentState'></a>

`currentState` [AsyncServiceState](../Louis/Louis.Threading.AsyncServiceState.md 'Louis\.Threading\.AsyncServiceState')

The value of the [State](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.State 'Louis\.Threading\.AsyncService\.State') property after the stop request\.

<a name='Louis.Hosting.AsyncHostedService.LogStopRequested(Louis.Threading.AsyncServiceState,Louis.Threading.AsyncServiceState,bool).result'></a>

`result` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the service was running when requested to stop;
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') otherwise\.

<a name='Louis.Hosting.AsyncHostedService.LogTeardownCompleted()'></a>

## AsyncHostedService\.LogTeardownCompleted\(\) Method


Called if the [TeardownAsync\(\)](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.TeardownAsync() 'Louis\.Threading\.AsyncService\.TeardownAsync') method terminates successfully.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected sealed override void LogTeardownCompleted();
```

<a name='Louis.Hosting.AsyncHostedService.LogTeardownFailed(System.Exception)'></a>

## AsyncHostedService\.LogTeardownFailed\(Exception\) Method


Called if the [TeardownAsync\(\)](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.TeardownAsync() 'Louis\.Threading\.AsyncService\.TeardownAsync') method throws an exception.

This method must return as early as possible, must not throw, and should be only used for logging purposes.

```csharp
protected sealed override void LogTeardownFailed(System.Exception exception);
```
#### Parameters

<a name='Louis.Hosting.AsyncHostedService.LogTeardownFailed(System.Exception).exception'></a>

`exception` [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')

The exception thrown by [TeardownAsync\(\)](../Louis/Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.TeardownAsync() 'Louis\.Threading\.AsyncService\.TeardownAsync')\.

<a name='Louis.Hosting.AsyncHostedService.StartAsync(System.Threading.CancellationToken)'></a>

## AsyncHostedService\.StartAsync\(CancellationToken\) Method

Triggered when the application host is ready to start the service\.

```csharp
public System.Threading.Tasks.Task StartAsync(System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Louis.Hosting.AsyncHostedService.StartAsync(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Indicates that the start process has been aborted\.

Implements [StartAsync\(CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihostedservice.startasync#microsoft-extensions-hosting-ihostedservice-startasync(system-threading-cancellationtoken) 'Microsoft\.Extensions\.Hosting\.IHostedService\.StartAsync\(System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A [System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task') that represents the asynchronous Start operation\.

<a name='Louis.Hosting.AsyncHostedService.StopAsync(System.Threading.CancellationToken)'></a>

## AsyncHostedService\.StopAsync\(CancellationToken\) Method

Triggered when the application host is performing a graceful shutdown\.

```csharp
public System.Threading.Tasks.Task StopAsync(System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Louis.Hosting.AsyncHostedService.StopAsync(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Indicates that the shutdown process should no longer be graceful\.

Implements [StopAsync\(CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihostedservice.stopasync#microsoft-extensions-hosting-ihostedservice-stopasync(system-threading-cancellationtoken) 'Microsoft\.Extensions\.Hosting\.IHostedService\.StopAsync\(System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A [System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task') that represents the asynchronous Stop operation\.