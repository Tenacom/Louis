#### [Louis](README.md 'README')
### [Louis\.Threading](Louis.Threading.md 'Louis\.Threading')

## AsyncServiceState Enum

Represents the state of an [AsyncService](Louis.Threading.AsyncService.md 'Louis\.Threading\.AsyncService')\.

```csharp
public enum AsyncServiceState
```
### Fields

<a name='Louis.Threading.AsyncServiceState.Created'></a>

`Created` 0

The service has not started yet\.

<a name='Louis.Threading.AsyncServiceState.Starting'></a>

`Starting` 1

The service is starting but not functional yet\.

<a name='Louis.Threading.AsyncServiceState.Running'></a>

`Running` 2

The service is running\.

<a name='Louis.Threading.AsyncServiceState.Stopping'></a>

`Stopping` 3

The service is stopping\.

<a name='Louis.Threading.AsyncServiceState.Stopped'></a>

`Stopped` 4

The service has stopped\.

<a name='Louis.Threading.AsyncServiceState.Disposed'></a>

`Disposed` 5

The service has been disposed\.