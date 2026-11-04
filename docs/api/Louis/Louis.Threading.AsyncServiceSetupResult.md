#### [Louis](README.md 'README')
### [Louis\.Threading](Louis.Threading.md 'Louis\.Threading')

## AsyncServiceSetupResult Enum

Represents the outcome of the setup phase of an [AsyncService](Louis.Threading.AsyncService.md 'Louis\.Threading\.AsyncService')\.

```csharp
public enum AsyncServiceSetupResult
```
### Fields

<a name='Louis.Threading.AsyncServiceSetupResult.Successful'></a>

`Successful` 0


Setup succeeded (the task returned by [SetupAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.SetupAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.SetupAsync\(System\.Threading\.CancellationToken\)') completed with [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')).

Service execution continues normally.

<a name='Louis.Threading.AsyncServiceSetupResult.NotStarted'></a>

`NotStarted` 1


Setup was not started (the service was stopped without being started).

Service execution is stopped.

<a name='Louis.Threading.AsyncServiceSetupResult.Unsuccessful'></a>

`Unsuccessful` 2


Setup failed (the task returned by [SetupAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.SetupAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.SetupAsync\(System\.Threading\.CancellationToken\)') completed with [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')).

Service execution is stopped.

<a name='Louis.Threading.AsyncServiceSetupResult.Canceled'></a>

`Canceled` 3


Setup was canceled (the task returned by [SetupAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.SetupAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.SetupAsync\(System\.Threading\.CancellationToken\)') was canceled).

Service execution is stopped.

<a name='Louis.Threading.AsyncServiceSetupResult.Faulted'></a>

`Faulted` 4


Setup failed with an exception (the task returned by [SetupAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.SetupAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.SetupAsync\(System\.Threading\.CancellationToken\)') has faulted).

Service execution is stopped.

Only [WaitUntilStartedAsync\(\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.WaitUntilStartedAsync() 'Louis\.Threading\.AsyncService\.WaitUntilStartedAsync\(\)') returns this value.
            [StartAndWaitAsync\(CancellationToken\)](Louis.Threading.AsyncService.md#Louis.Threading.AsyncService.StartAndWaitAsync(System.Threading.CancellationToken) 'Louis\.Threading\.AsyncService\.StartAndWaitAsync\(System\.Threading\.CancellationToken\)') throws the exception instead.