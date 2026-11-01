#### [Louis](README.md 'README')
### [Louis\.Diagnostics](Louis.Diagnostics.md 'Louis\.Diagnostics')

## CriticalInternalErrorException Class

The exception that is thrown by methods of the [SelfCheck](Louis.Diagnostics.SelfCheck.md 'Louis\.Diagnostics\.SelfCheck') class
to signal an unrecoverable condition, most probably caused by an internal error in a library
or application, that should cause an application to terminate immediately\.

```csharp
public class CriticalInternalErrorException : Louis.Diagnostics.InternalErrorException, Louis.Diagnostics.ICriticalError
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception') → [InternalErrorException](Louis.Diagnostics.InternalErrorException.md 'Louis\.Diagnostics\.InternalErrorException') → CriticalInternalErrorException

Implements [ICriticalError](Louis.Diagnostics.ICriticalError.md 'Louis\.Diagnostics\.ICriticalError')
### Constructors

<a name='Louis.Diagnostics.CriticalInternalErrorException.CriticalInternalErrorException()'></a>

## CriticalInternalErrorException\(\) Constructor

Initializes a new instance of the [CriticalInternalErrorException](Louis.Diagnostics.CriticalInternalErrorException.md 'Louis\.Diagnostics\.CriticalInternalErrorException') class\.

```csharp
public CriticalInternalErrorException();
```

<a name='Louis.Diagnostics.CriticalInternalErrorException.CriticalInternalErrorException(string)'></a>

## CriticalInternalErrorException\(string\) Constructor

Initializes a new instance of the [CriticalInternalErrorException](Louis.Diagnostics.CriticalInternalErrorException.md 'Louis\.Diagnostics\.CriticalInternalErrorException') class
with a specified error message\.

```csharp
public CriticalInternalErrorException(string message);
```
#### Parameters

<a name='Louis.Diagnostics.CriticalInternalErrorException.CriticalInternalErrorException(string).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The message that describes the error\.

<a name='Louis.Diagnostics.CriticalInternalErrorException.CriticalInternalErrorException(string,System.Exception)'></a>

## CriticalInternalErrorException\(string, Exception\) Constructor

Initializes a new instance of the [CriticalInternalErrorException](Louis.Diagnostics.CriticalInternalErrorException.md 'Louis\.Diagnostics\.CriticalInternalErrorException') class
with a specified error message and a reference to the inner exception that is the cause of this exception\.

```csharp
public CriticalInternalErrorException(string message, System.Exception? innerException);
```
#### Parameters

<a name='Louis.Diagnostics.CriticalInternalErrorException.CriticalInternalErrorException(string,System.Exception).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error message that explains the reason for the exception\.

<a name='Louis.Diagnostics.CriticalInternalErrorException.CriticalInternalErrorException(string,System.Exception).innerException'></a>

`innerException` [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')

The exception that is the cause of the current exception,
            or a [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') reference \(`Nothing` in Visual Basic\) if no inner exception is specified\.

<a name='Louis.Diagnostics.CriticalInternalErrorException.CriticalInternalErrorException(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)'></a>

## CriticalInternalErrorException\(SerializationInfo, StreamingContext\) Constructor

Initializes a new instance of the [CriticalInternalErrorException](Louis.Diagnostics.CriticalInternalErrorException.md 'Louis\.Diagnostics\.CriticalInternalErrorException') class
with serialized data\.

```csharp
protected CriticalInternalErrorException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
```
#### Parameters

<a name='Louis.Diagnostics.CriticalInternalErrorException.CriticalInternalErrorException(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext).info'></a>

`info` [System\.Runtime\.Serialization\.SerializationInfo](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.serialization.serializationinfo 'System\.Runtime\.Serialization\.SerializationInfo')

The [System\.Runtime\.Serialization\.SerializationInfo](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.serialization.serializationinfo 'System\.Runtime\.Serialization\.SerializationInfo') that holds the serialized object data
            about the exception being thrown\.

<a name='Louis.Diagnostics.CriticalInternalErrorException.CriticalInternalErrorException(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext).context'></a>

`context` [System\.Runtime\.Serialization\.StreamingContext](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.serialization.streamingcontext 'System\.Runtime\.Serialization\.StreamingContext')

The [System\.Runtime\.Serialization\.StreamingContext](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.serialization.streamingcontext 'System\.Runtime\.Serialization\.StreamingContext') that contains contextual information
            about the source or destination\.