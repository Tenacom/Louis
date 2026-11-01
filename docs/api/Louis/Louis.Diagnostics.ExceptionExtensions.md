#### [Louis](README.md 'README')
### [Louis\.Diagnostics](Louis.Diagnostics.md 'Louis\.Diagnostics')

## ExceptionExtensions Class

Provides extension methods for exceptions\.

```csharp
public static class ExceptionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ExceptionExtensions
### Methods

<a name='Louis.Diagnostics.ExceptionExtensions.AnyCausingException(thisSystem.Exception,System.Func_System.Exception,bool_)'></a>

## ExceptionExtensions\.AnyCausingException\(this Exception, Func\<Exception,bool\>\) Method

Determines whether any of the causing exceptions for this exception
satisfies the given [predicate](Louis.Diagnostics.ExceptionExtensions.md#Louis.Diagnostics.ExceptionExtensions.AnyCausingException(thisSystem.Exception,System.Func_System.Exception,bool_).predicate 'Louis\.Diagnostics\.ExceptionExtensions\.AnyCausingException\(this System\.Exception, System\.Func\<System\.Exception,bool\>\)\.predicate')\.

```csharp
public static bool AnyCausingException(this System.Exception @this, System.Func<System.Exception,bool> predicate);
```
#### Parameters

<a name='Louis.Diagnostics.ExceptionExtensions.AnyCausingException(thisSystem.Exception,System.Func_System.Exception,bool_).this'></a>

`this` [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')

The [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception') on which this method is called\.

<a name='Louis.Diagnostics.ExceptionExtensions.AnyCausingException(thisSystem.Exception,System.Func_System.Exception,bool_).predicate'></a>

`predicate` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

A function to test each causing exception for a condition\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if [predicate](Louis.Diagnostics.ExceptionExtensions.md#Louis.Diagnostics.ExceptionExtensions.AnyCausingException(thisSystem.Exception,System.Func_System.Exception,bool_).predicate 'Louis\.Diagnostics\.ExceptionExtensions\.AnyCausingException\(this System\.Exception, System\.Func\<System\.Exception,bool\>\)\.predicate') returns `true` for at least one
            of the causing exceptions of [this](Louis.Diagnostics.ExceptionExtensions.md#Louis.Diagnostics.ExceptionExtensions.AnyCausingException(thisSystem.Exception,System.Func_System.Exception,bool_).this 'Louis\.Diagnostics\.ExceptionExtensions\.AnyCausingException\(this System\.Exception, System\.Func\<System\.Exception,bool\>\)\.this'); otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  

[this](Louis.Diagnostics.ExceptionExtensions.md#Louis.Diagnostics.ExceptionExtensions.AnyCausingException(thisSystem.Exception,System.Func_System.Exception,bool_).this 'Louis\.Diagnostics\.ExceptionExtensions\.AnyCausingException\(this System\.Exception, System\.Func\<System\.Exception,bool\>\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

- or -

[predicate](Louis.Diagnostics.ExceptionExtensions.md#Louis.Diagnostics.ExceptionExtensions.AnyCausingException(thisSystem.Exception,System.Func_System.Exception,bool_).predicate 'Louis\.Diagnostics\.ExceptionExtensions\.AnyCausingException\(this System\.Exception, System\.Func\<System\.Exception,bool\>\)\.predicate') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null').

### Remarks

For an explanation of what are considered causing exceptions of an exception, see the "Remarks"
            section of [GetCausingExceptions\(this Exception\)](Louis.Diagnostics.ExceptionExtensions.md#Louis.Diagnostics.ExceptionExtensions.GetCausingExceptions(thisSystem.Exception) 'Louis\.Diagnostics\.ExceptionExtensions\.GetCausingExceptions\(this System\.Exception\)').

This method yields the same result as calling `exception.GetCausingExceptions().Any(predicate)`,
            but is faster and allocates less memory. It is used internally by the [IsCriticalError\(this Exception\)](Louis.Diagnostics.ExceptionExtensions.md#Louis.Diagnostics.ExceptionExtensions.IsCriticalError(thisSystem.Exception) 'Louis\.Diagnostics\.ExceptionExtensions\.IsCriticalError\(this System\.Exception\)') method.

<a name='Louis.Diagnostics.ExceptionExtensions.GetCausingExceptions(thisSystem.Exception)'></a>

## ExceptionExtensions\.GetCausingExceptions\(this Exception\) Method

Enumerates all causing exceptions of the current exception\.

```csharp
public static System.Collections.Generic.IEnumerable<System.Exception> GetCausingExceptions(this System.Exception @this);
```
#### Parameters

<a name='Louis.Diagnostics.ExceptionExtensions.GetCausingExceptions(thisSystem.Exception).this'></a>

`this` [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')

The [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception') on which this method is called\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
An enumeration of the causing exceptions of [this](Louis.Diagnostics.ExceptionExtensions.md#Louis.Diagnostics.ExceptionExtensions.GetCausingExceptions(thisSystem.Exception).this 'Louis\.Diagnostics\.ExceptionExtensions\.GetCausingExceptions\(this System\.Exception\)\.this')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Diagnostics.ExceptionExtensions.md#Louis.Diagnostics.ExceptionExtensions.GetCausingExceptions(thisSystem.Exception).this 'Louis\.Diagnostics\.ExceptionExtensions\.GetCausingExceptions\(this System\.Exception\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### Remarks

The "causing exceptions" of an exceptions are the exceptions that caused it to be thrown,
            including itself (but excluding [System\.AggregateException](https://learn.microsoft.com/en-us/dotnet/api/system.aggregateexception 'System\.AggregateException')s, as they are only meant
            as containers for other exceptions).

Enumerating the causing exceptions of an exception is useful, for example, when we want
            to reconstruct the chain of events that lead to the current exception being thrown.
            [GetCausingExceptions\(this Exception\)](Louis.Diagnostics.ExceptionExtensions.md#Louis.Diagnostics.ExceptionExtensions.GetCausingExceptions(thisSystem.Exception) 'Louis\.Diagnostics\.ExceptionExtensions\.GetCausingExceptions\(this System\.Exception\)') enumerates innermost exceptions first, in order to make
            this chain of events clear.

Another common use case for causing exceptions is determining whether any of
            the causing exception of a caught exception is of a certain type, or anyway satisfies a
            given condition. While you can use LINQ's [System\.Linq\.Enumerable\.Any&lt;&gt;\.Collections\.Generic\.IEnumerable\{&lt;&gt;\.Func\{&lt;&gt;\.Boolean\}\)](https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any--1#system-linq-enumerable-any--1(system-collections-generic-ienumerable{--0}-system-func{--0-system-boolean}) 'System\.Linq\.Enumerable\.Any\`\`1\(System\.Collections\.Generic\.IEnumerable\{\`\`0\},System\.Func\{\`\`0,System\.Boolean\}\)') method
            on the return value of [GetCausingExceptions\(this Exception\)](Louis.Diagnostics.ExceptionExtensions.md#Louis.Diagnostics.ExceptionExtensions.GetCausingExceptions(thisSystem.Exception) 'Louis\.Diagnostics\.ExceptionExtensions\.GetCausingExceptions\(this System\.Exception\)'), L.o.U.I.S. also provides
            the [AnyCausingException\(this Exception, Func&lt;Exception,bool&gt;\)](Louis.Diagnostics.ExceptionExtensions.md#Louis.Diagnostics.ExceptionExtensions.AnyCausingException(thisSystem.Exception,System.Func_System.Exception,bool_) 'Louis\.Diagnostics\.ExceptionExtensions\.AnyCausingException\(this System\.Exception, System\.Func\<System\.Exception,bool\>\)') extension method, which is optimized specifically
            for this case.

<a name='Louis.Diagnostics.ExceptionExtensions.IsCriticalError(thisSystem.Exception)'></a>

## ExceptionExtensions\.IsCriticalError\(this Exception\) Method

Returns a value that tells whether an [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception') is of a type that
is better not caught, as it signals an unrecoverable condition\.

```csharp
public static bool IsCriticalError(this System.Exception @this);
```
#### Parameters

<a name='Louis.Diagnostics.ExceptionExtensions.IsCriticalError(thisSystem.Exception).this'></a>

`this` [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')

The exception being thrown\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if [this](Louis.Diagnostics.ExceptionExtensions.md#Louis.Diagnostics.ExceptionExtensions.IsCriticalError(thisSystem.Exception).this 'Louis\.Diagnostics\.ExceptionExtensions\.IsCriticalError\(this System\.Exception\)\.this') represents a critical error;
            otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Diagnostics.ExceptionExtensions.md#Louis.Diagnostics.ExceptionExtensions.IsCriticalError(thisSystem.Exception).this 'Louis\.Diagnostics\.ExceptionExtensions\.IsCriticalError\(this System\.Exception\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### Remarks

The following exception types are considered critical errors:
- [System\.NullReferenceException](https://learn.microsoft.com/en-us/dotnet/api/system.nullreferenceexception 'System\.NullReferenceException');
- [System\.StackOverflowException](https://learn.microsoft.com/en-us/dotnet/api/system.stackoverflowexception 'System\.StackOverflowException');
- [System\.AppDomainUnloadedException](https://learn.microsoft.com/en-us/dotnet/api/system.appdomainunloadedexception 'System\.AppDomainUnloadedException');
- [System\.BadImageFormatException](https://learn.microsoft.com/en-us/dotnet/api/system.badimageformatexception 'System\.BadImageFormatException');
- [System\.InvalidProgramException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidprogramexception 'System\.InvalidProgramException');
- [System\.Threading\.ThreadAbortException](https://learn.microsoft.com/en-us/dotnet/api/system.threading.threadabortexception 'System\.Threading\.ThreadAbortException');
- [System\.AccessViolationException](https://learn.microsoft.com/en-us/dotnet/api/system.accessviolationexception 'System\.AccessViolationException');
- [System\.OutOfMemoryException](https://learn.microsoft.com/en-us/dotnet/api/system.outofmemoryexception 'System\.OutOfMemoryException');
- [System\.Runtime\.InteropServices\.SEHException](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.sehexception 'System\.Runtime\.InteropServices\.SEHException');
- [System\.Security\.SecurityException](https://learn.microsoft.com/en-us/dotnet/api/system.security.securityexception 'System\.Security\.SecurityException');
- any exception type implementing the [ICriticalError](Louis.Diagnostics.ICriticalError.md 'Louis\.Diagnostics\.ICriticalError') interface.

Of course, not all exceptions of the above types must necessarily cause an application
            to terminate: for example, attempting to dynamically load an assembly as a plug-in
            will cause a [System\.BadImageFormatException](https://learn.microsoft.com/en-us/dotnet/api/system.badimageformatexception 'System\.BadImageFormatException') to be thrown if the assembly file is corrupted.
            However, these situations should be handled explicitly, by catching specific exception types in
            restricted contexts (to continue the above example, a `catch (BadImageFormatException)` block
            should be present in the method that attempts to load the plug-in) and appropriate action
            (such as alerting the user, logging, etc.) should be taken instead of letting the exception
            "fall through" to external `catch` blocks.

This method is mainly meant for "generic" catch blocks, when the only valuable information
            is that "something has gone wrong". In these cases, a simple `catch` or `catch (Exception ex)`
            block will trigger
            [warning CA1031](https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1031 'https://docs\.microsoft\.com/en\-us/dotnet/fundamentals/code\-analysis/quality\-rules/ca1031')
            unless the exception is rethrown, because a potential serious problem is being hidden from the user;
            a conditional `catch (Exception ex) when (!ex.IsCriticalError())`, however, will not only
            prevent the warning, but correctly avoid hiding unrecoverable error conditions.

<a name='Louis.Diagnostics.ExceptionExtensions.Rethrow(thisSystem.Exception)'></a>

## ExceptionExtensions\.Rethrow\(this Exception\) Method

Rethrows an exception, preserving the original stack trace\. This method never returns\.

```csharp
public static void Rethrow(this System.Exception @this);
```
#### Parameters

<a name='Louis.Diagnostics.ExceptionExtensions.Rethrow(thisSystem.Exception).this'></a>

`this` [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')

The exception to rethrow\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[this](Louis.Diagnostics.ExceptionExtensions.md#Louis.Diagnostics.ExceptionExtensions.Rethrow(thisSystem.Exception).this 'Louis\.Diagnostics\.ExceptionExtensions\.Rethrow\(this System\.Exception\)\.this') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.