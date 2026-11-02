#### [Louis](README.md 'README')

## Louis Namespace

Provides general\-purpose types: disposables that invoke a callback,
utility methods for dates and times, and range checks\.

| Classes | |
| :--- | :--- |
| [ActionAsyncDisposable](Louis.ActionAsyncDisposable.md 'Louis\.ActionAsyncDisposable') | Implements both [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable') and [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable') by invoking a given callback upon disposal\. |
| [ActionDisposable](Louis.ActionDisposable.md 'Louis\.ActionDisposable') | Implements [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable') by invoking a given [System\.Action](https://learn.microsoft.com/en-us/dotnet/api/system.action 'System\.Action') upon disposal\. |
| [AsyncDisposableExtensions](Louis.AsyncDisposableExtensions.md 'Louis\.AsyncDisposableExtensions') | Provides extension methods for objects implementing [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable')\. |
| [DateOnlyExtensions](Louis.DateOnlyExtensions.md 'Louis\.DateOnlyExtensions') |   Provides extension methods for instances of [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly').  This type is not available in the `netstandard` and .NET Framework builds of Louis,             because their BCL has no [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly'). |
| [DateOnlyUtility](Louis.DateOnlyUtility.md 'Louis\.DateOnlyUtility') |   Provides utility methods to work with [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly').  This type is not available in the `netstandard` and .NET Framework builds of Louis,             because their BCL has no [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly'). |
| [DateTimeExtensions](Louis.DateTimeExtensions.md 'Louis\.DateTimeExtensions') | Provides extension methods for instances of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')\. |
| [DateUtility](Louis.DateUtility.md 'Louis\.DateUtility') | Provides utility methods to work with dates\. |
| [DisposingUtility](Louis.DisposingUtility.md 'Louis\.DisposingUtility') | Provides utility methods to handle disposing of objects with a mix of [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable') and [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable') interfaces\. |
| [RangeCheck](Louis.RangeCheck.md 'Louis\.RangeCheck') | Provides methods to perform range checks and for constraining values to be within ranges\. |
| [TimeConstants](Louis.TimeConstants.md 'Louis\.TimeConstants') | Provides constants for typical "magic numbers" used when working with times or time intervals\. |

| Structs | |
| :--- | :--- |
| [LocalActionDisposable](Louis.LocalActionDisposable.md 'Louis\.LocalActionDisposable') |   Implements [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable') by invoking a given [System\.Action](https://learn.microsoft.com/en-us/dotnet/api/system.action 'System\.Action') upon disposal.  This type should be used instead of [ActionDisposable](Louis.ActionDisposable.md 'Louis\.ActionDisposable') when needed in a local scope,             as it avoids a heap allocation. |

| Delegates | |
| :--- | :--- |
| [ReadOnlySpanFunc&lt;T&gt;\(\)](Louis.ReadOnlySpanFunc_T_().md 'Louis\.ReadOnlySpanFunc\<T\>\(\)') | A delegate taking no parameters and returning a [System\.ReadOnlySpan&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')\. |
