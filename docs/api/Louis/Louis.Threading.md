#### [Louis](README.md 'README')

## Louis\.Threading Namespace

Provides a base class for long\-running services, thread\-safe flags and references,
and utility methods for [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask')\.

| Classes | |
| :--- | :--- |
| [AsyncService](Louis.Threading.AsyncService.md 'Louis\.Threading\.AsyncService') | Base class for long\-running services\. |
| [ValueTaskUtility](Louis.Threading.ValueTaskUtility.md 'Louis\.Threading\.ValueTaskUtility') | Provides utility methods to deal with [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask') objects\. |

| Structs | |
| :--- | :--- |
| [InterlockedFlag](Louis.Threading.InterlockedFlag.md 'Louis\.Threading\.InterlockedFlag') | Implements thread\-safe management of a boolean value\. |
| [InterlockedReference&lt;T&gt;](Louis.Threading.InterlockedReference_T_.md 'Louis\.Threading\.InterlockedReference\<T\>') | Implements thread\-safe management of an object reference\. |

| Enums | |
| :--- | :--- |
| [AsyncServiceSetupResult](Louis.Threading.AsyncServiceSetupResult.md 'Louis\.Threading\.AsyncServiceSetupResult') | Represents the outcome of the setup phase of an [AsyncService](Louis.Threading.AsyncService.md 'Louis\.Threading\.AsyncService')\. |
| [AsyncServiceState](Louis.Threading.AsyncServiceState.md 'Louis\.Threading\.AsyncServiceState') | Represents the state of an [AsyncService](Louis.Threading.AsyncService.md 'Louis\.Threading\.AsyncService')\. |
