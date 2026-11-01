#### [Louis](README.md 'README')
### [Louis\.Threading](Louis.Threading.md 'Louis\.Threading')

## ValueTaskUtility Class

Provides utility methods to deal with [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask') objects\.

```csharp
public static class ValueTaskUtility
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ValueTaskUtility
### Methods

<a name='Louis.Threading.ValueTaskUtility.WhenAll(System.Collections.Generic.IEnumerable_System.Threading.Tasks.ValueTask_)'></a>

## ValueTaskUtility\.WhenAll\(IEnumerable\<ValueTask\>\) Method

Creates a task that will complete when all of the [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask') objects in an enumerable collection have completed\.

```csharp
public static System.Threading.Tasks.ValueTask WhenAll(System.Collections.Generic.IEnumerable<System.Threading.Tasks.ValueTask> valueTasks);
```
#### Parameters

<a name='Louis.Threading.ValueTaskUtility.WhenAll(System.Collections.Generic.IEnumerable_System.Threading.Tasks.ValueTask_).valueTasks'></a>

`valueTasks` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask')s to wait on for completion\.

#### Returns
[System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask')  
A [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask') that represents the completion of all of the supplied [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask')s\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[valueTasks](Louis.Threading.ValueTaskUtility.md#Louis.Threading.ValueTaskUtility.WhenAll(System.Collections.Generic.IEnumerable_System.Threading.Tasks.ValueTask_).valueTasks 'Louis\.Threading\.ValueTaskUtility\.WhenAll\(System\.Collections\.Generic\.IEnumerable\<System\.Threading\.Tasks\.ValueTask\>\)\.valueTasks') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='Louis.Threading.ValueTaskUtility.WhenAll(System.Threading.Tasks.ValueTask[])'></a>

## ValueTaskUtility\.WhenAll\(ValueTask\[\]\) Method

Creates a task that will complete when all of the [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask') objects in an enumerable collection have completed\.

```csharp
public static System.Threading.Tasks.ValueTask WhenAll(params System.Threading.Tasks.ValueTask[] valueTasks);
```
#### Parameters

<a name='Louis.Threading.ValueTaskUtility.WhenAll(System.Threading.Tasks.ValueTask[]).valueTasks'></a>

`valueTasks` [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask')s to wait on for completion\.

#### Returns
[System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask')  
A [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask') that represents the completion of all of the supplied [System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask')s\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[valueTasks](Louis.Threading.ValueTaskUtility.md#Louis.Threading.ValueTaskUtility.WhenAll(System.Threading.Tasks.ValueTask[]).valueTasks 'Louis\.Threading\.ValueTaskUtility\.WhenAll\(System\.Threading\.Tasks\.ValueTask\[\]\)\.valueTasks') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.