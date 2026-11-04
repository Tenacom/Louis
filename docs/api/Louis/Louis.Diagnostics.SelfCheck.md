#### [Louis](README.md 'README')
### [Louis\.Diagnostics](Louis.Diagnostics.md 'Louis\.Diagnostics')

## SelfCheck Class

Provides methods to perform self\-checks in library or application code\.

```csharp
public static class SelfCheck
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → SelfCheck

### Remarks

The message of every exception created by this class names the assembly of the calling method,
            as the call stack reports it. When the JIT compiler removes the frame of the calling method,
            by inlining it into its own caller or by a tail call, the message names the assembly of the next frame instead.
### Methods

<a name='Louis.Diagnostics.SelfCheck.CriticalFailure(string,string,int)'></a>

## SelfCheck\.CriticalFailure\(string, string, int\) Method

Creates and returns a critical exception telling that an internal self\-check has failed
and the application should terminate immediately\.

```csharp
public static Louis.Diagnostics.CriticalInternalErrorException CriticalFailure(string message, string filePath="", int lineNumber=0);
```
#### Parameters

<a name='Louis.Diagnostics.SelfCheck.CriticalFailure(string,string,int).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The exception message\.

<a name='Louis.Diagnostics.SelfCheck.CriticalFailure(string,string,int).filePath'></a>

`filePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the source file where this method is called\.
            This parameter is automatically added by the compiler and should never be provided explicitly\.

<a name='Louis.Diagnostics.SelfCheck.CriticalFailure(string,string,int).lineNumber'></a>

`lineNumber` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The line number in source where this method is called\.
            This parameter is automatically added by the compiler and should never be provided explicitly\.

#### Returns
[CriticalInternalErrorException](Louis.Diagnostics.CriticalInternalErrorException.md 'Louis\.Diagnostics\.CriticalInternalErrorException')  
A newly\-created instance of [CriticalInternalErrorException](Louis.Diagnostics.CriticalInternalErrorException.md 'Louis\.Diagnostics\.CriticalInternalErrorException')\.

### Remarks

The returned exception will be of type [CriticalInternalErrorException](Louis.Diagnostics.CriticalInternalErrorException.md 'Louis\.Diagnostics\.CriticalInternalErrorException'); its
            [Message](https://learn.microsoft.com/en-us/dotnet/api/system.exception.message 'System\.Exception\.Message') property will contain the specified
            [message](Louis.Diagnostics.SelfCheck.md#Louis.Diagnostics.SelfCheck.CriticalFailure(string,string,int).message 'Louis\.Diagnostics\.SelfCheck\.CriticalFailure\(string, string, int\)\.message'), preceded by an indication of the assembly, source file,
            and line number of the failed check.

The returned exception is of a type that will be considered a critical error
            by the [IsCriticalError\(this Exception\)](Louis.Diagnostics.ExceptionExtensions.md#Louis.Diagnostics.ExceptionExtensions.IsCriticalError(thisSystem.Exception) 'Louis\.Diagnostics\.ExceptionExtensions\.IsCriticalError\(this System\.Exception\)') method;
            therefore, assuming critical error checks are implemented correctly, it will not
            be caught and will cause the application to terminate immediately.

### See Also
- [Failure\(string, string, int\)](Louis.Diagnostics.SelfCheck.md#Louis.Diagnostics.SelfCheck.Failure(string,string,int) 'Louis\.Diagnostics\.SelfCheck\.Failure\(string, string, int\)')

<a name='Louis.Diagnostics.SelfCheck.Fail(string,string,int)'></a>

## SelfCheck\.Fail\(string, string, int\) Method

Throws an exception telling that an internal self\-check has failed\.

```csharp
public static void Fail(string message, string filePath="", int lineNumber=0);
```
#### Parameters

<a name='Louis.Diagnostics.SelfCheck.Fail(string,string,int).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The exception message\.

<a name='Louis.Diagnostics.SelfCheck.Fail(string,string,int).filePath'></a>

`filePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the source file where this method is called\.
            This parameter is automatically added by the compiler and should never be provided explicitly\.

<a name='Louis.Diagnostics.SelfCheck.Fail(string,string,int).lineNumber'></a>

`lineNumber` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The line number in source where this method is called\.
            This parameter is automatically added by the compiler and should never be provided explicitly\.

### Remarks

The thrown exception will be of type [InternalErrorException](Louis.Diagnostics.InternalErrorException.md 'Louis\.Diagnostics\.InternalErrorException'); its
            [Message](https://learn.microsoft.com/en-us/dotnet/api/system.exception.message 'System\.Exception\.Message') property will contain the specified
            [message](Louis.Diagnostics.SelfCheck.md#Louis.Diagnostics.SelfCheck.Fail(string,string,int).message 'Louis\.Diagnostics\.SelfCheck\.Fail\(string, string, int\)\.message'), preceded by an indication of the assembly, source file,
            and line number of the failed check.

<a name='Louis.Diagnostics.SelfCheck.Fail_T_(string,string,int)'></a>

## SelfCheck\.Fail\<T\>\(string, string, int\) Method

Throws an exception telling that an internal self\-check has failed\.

```csharp
public static T Fail<T>(string message, string filePath="", int lineNumber=0);
```
#### Type parameters

<a name='Louis.Diagnostics.SelfCheck.Fail_T_(string,string,int).T'></a>

`T`

The expected return type\.
#### Parameters

<a name='Louis.Diagnostics.SelfCheck.Fail_T_(string,string,int).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The exception message\.

<a name='Louis.Diagnostics.SelfCheck.Fail_T_(string,string,int).filePath'></a>

`filePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the source file where this method is called\.
            This parameter is automatically added by the compiler and should never be provided explicitly\.

<a name='Louis.Diagnostics.SelfCheck.Fail_T_(string,string,int).lineNumber'></a>

`lineNumber` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The line number in source where this method is called\.
            This parameter is automatically added by the compiler and should never be provided explicitly\.

#### Returns
[T](Louis.Diagnostics.SelfCheck.md#Louis.Diagnostics.SelfCheck.Fail_T_(string,string,int).T 'Louis\.Diagnostics\.SelfCheck\.Fail\<T\>\(string, string, int\)\.T')  
This method never returns\.

### Remarks

The thrown exception will be of type [InternalErrorException](Louis.Diagnostics.InternalErrorException.md 'Louis\.Diagnostics\.InternalErrorException'); its
            [Message](https://learn.microsoft.com/en-us/dotnet/api/system.exception.message 'System\.Exception\.Message') property will contain the specified
            [message](Louis.Diagnostics.SelfCheck.md#Louis.Diagnostics.SelfCheck.Fail_T_(string,string,int).message 'Louis\.Diagnostics\.SelfCheck\.Fail\<T\>\(string, string, int\)\.message'), preceded by an indication of the assembly, source file,
            and line number of the failed check.

<a name='Louis.Diagnostics.SelfCheck.FailCritically(string,string,int)'></a>

## SelfCheck\.FailCritically\(string, string, int\) Method

Throws a critical exception telling that an internal self\-check has failed\.

```csharp
public static void FailCritically(string message, string filePath="", int lineNumber=0);
```
#### Parameters

<a name='Louis.Diagnostics.SelfCheck.FailCritically(string,string,int).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The exception message\.

<a name='Louis.Diagnostics.SelfCheck.FailCritically(string,string,int).filePath'></a>

`filePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the source file where this method is called\.
            This parameter is automatically added by the compiler and should never be provided explicitly\.

<a name='Louis.Diagnostics.SelfCheck.FailCritically(string,string,int).lineNumber'></a>

`lineNumber` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The line number in source where this method is called\.
            This parameter is automatically added by the compiler and should never be provided explicitly\.

### Remarks

The thrown exception will be of type [CriticalInternalErrorException](Louis.Diagnostics.CriticalInternalErrorException.md 'Louis\.Diagnostics\.CriticalInternalErrorException'); its
            [Message](https://learn.microsoft.com/en-us/dotnet/api/system.exception.message 'System\.Exception\.Message') property will contain the specified
            [message](Louis.Diagnostics.SelfCheck.md#Louis.Diagnostics.SelfCheck.FailCritically(string,string,int).message 'Louis\.Diagnostics\.SelfCheck\.FailCritically\(string, string, int\)\.message'), preceded by an indication of the assembly, source file,
            and line number of the failed check.

The thrown exception is of a type that will be considered critical by the [IsCriticalError\(this Exception\)](Louis.Diagnostics.ExceptionExtensions.md#Louis.Diagnostics.ExceptionExtensions.IsCriticalError(thisSystem.Exception) 'Louis\.Diagnostics\.ExceptionExtensions\.IsCriticalError\(this System\.Exception\)')
            method; therefore, assuming critical exception checks are implemented correctly, it will not
            be caught and will cause the application to terminate immediately.

<a name='Louis.Diagnostics.SelfCheck.FailCritically_T_(string,string,int)'></a>

## SelfCheck\.FailCritically\<T\>\(string, string, int\) Method

Throws a critical exception telling that an internal self\-check has failed\.

```csharp
public static T FailCritically<T>(string message, string filePath="", int lineNumber=0);
```
#### Type parameters

<a name='Louis.Diagnostics.SelfCheck.FailCritically_T_(string,string,int).T'></a>

`T`

The expected return type\.
#### Parameters

<a name='Louis.Diagnostics.SelfCheck.FailCritically_T_(string,string,int).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The exception message\.

<a name='Louis.Diagnostics.SelfCheck.FailCritically_T_(string,string,int).filePath'></a>

`filePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the source file where this method is called\.
            This parameter is automatically added by the compiler and should never be provided explicitly\.

<a name='Louis.Diagnostics.SelfCheck.FailCritically_T_(string,string,int).lineNumber'></a>

`lineNumber` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The line number in source where this method is called\.
            This parameter is automatically added by the compiler and should never be provided explicitly\.

#### Returns
[T](Louis.Diagnostics.SelfCheck.md#Louis.Diagnostics.SelfCheck.FailCritically_T_(string,string,int).T 'Louis\.Diagnostics\.SelfCheck\.FailCritically\<T\>\(string, string, int\)\.T')  
This method never returns\.

### Remarks

The thrown exception will be of type [CriticalInternalErrorException](Louis.Diagnostics.CriticalInternalErrorException.md 'Louis\.Diagnostics\.CriticalInternalErrorException'); its
            [Message](https://learn.microsoft.com/en-us/dotnet/api/system.exception.message 'System\.Exception\.Message') property will contain the specified
            [message](Louis.Diagnostics.SelfCheck.md#Louis.Diagnostics.SelfCheck.FailCritically_T_(string,string,int).message 'Louis\.Diagnostics\.SelfCheck\.FailCritically\<T\>\(string, string, int\)\.message'), preceded by an indication of the assembly, source file,
            and line number of the failed check.

The thrown exception is of a type that will be considered critical by the [IsCriticalError\(this Exception\)](Louis.Diagnostics.ExceptionExtensions.md#Louis.Diagnostics.ExceptionExtensions.IsCriticalError(thisSystem.Exception) 'Louis\.Diagnostics\.ExceptionExtensions\.IsCriticalError\(this System\.Exception\)')
            method; therefore, assuming critical exception checks are implemented correctly, it will not
            be caught and will cause the application to terminate immediately.

<a name='Louis.Diagnostics.SelfCheck.Failure(string,string,int)'></a>

## SelfCheck\.Failure\(string, string, int\) Method

Creates and returns an exception telling that an internal self\-check has failed\.

```csharp
public static Louis.Diagnostics.InternalErrorException Failure(string message, string filePath="", int lineNumber=0);
```
#### Parameters

<a name='Louis.Diagnostics.SelfCheck.Failure(string,string,int).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The exception message\.

<a name='Louis.Diagnostics.SelfCheck.Failure(string,string,int).filePath'></a>

`filePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the source file where this method is called\.
            This parameter is automatically added by the compiler and should never be provided explicitly\.

<a name='Louis.Diagnostics.SelfCheck.Failure(string,string,int).lineNumber'></a>

`lineNumber` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The line number in source where this method is called\.
            This parameter is automatically added by the compiler and should never be provided explicitly\.

#### Returns
[InternalErrorException](Louis.Diagnostics.InternalErrorException.md 'Louis\.Diagnostics\.InternalErrorException')  
A newly\-created instance of [InternalErrorException](Louis.Diagnostics.InternalErrorException.md 'Louis\.Diagnostics\.InternalErrorException')\.

### Remarks

The returned exception will be of type [InternalErrorException](Louis.Diagnostics.InternalErrorException.md 'Louis\.Diagnostics\.InternalErrorException'); its
            [Message](https://learn.microsoft.com/en-us/dotnet/api/system.exception.message 'System\.Exception\.Message') property will contain the specified
            [message](Louis.Diagnostics.SelfCheck.md#Louis.Diagnostics.SelfCheck.Failure(string,string,int).message 'Louis\.Diagnostics\.SelfCheck\.Failure\(string, string, int\)\.message'), preceded by an indication of the assembly, source file,
            and line number of the failed check.

### See Also
- [CriticalFailure\(string, string, int\)](Louis.Diagnostics.SelfCheck.md#Louis.Diagnostics.SelfCheck.CriticalFailure(string,string,int) 'Louis\.Diagnostics\.SelfCheck\.CriticalFailure\(string, string, int\)')