# Exceptions

The `Louis.Diagnostics` namespace helps you follow exception creation and handling best practices.

---

<!-- markdownlint-disable MD036 -->
**Table of contents**
<!-- markdownlint-enable MD036 -->

- [(Not) handling critical errors](#not-handling-critical-errors)
  - [Critical exception types](#critical-exception-types)
  - [Early detection of critical errors](#early-detection-of-critical-errors)
  - [Custom critical exception types](#custom-critical-exception-types)
- [Drilling down](#drilling-down)
- [Rethrowing exceptions](#rethrowing-exceptions)
- [Building exception messages](#building-exception-messages)

---

## (Not) handling critical errors

A critical error means that something has gone horribly wrong and whatever you do next will likely cause a crash.

When a critical error occurs, and your program doesn't crash at once, a _critical exception_ is thrown.
Handling a critical exception will likely crash your program, losing the original exception's stack trace.
Even rethrowing a critical exception may fail; best you can do is not catch it at all.

### Critical exception types

There is no single critical exception class.
Exceptions of the following types are considered critical errors:

- [`NullReferenceException`](https://learn.microsoft.com/en-us/dotnet/api/system.nullreferenceexception)
- [`StackOverflowException`](https://learn.microsoft.com/en-us/dotnet/api/system.stackoverflowexception)
- [`AppDomainUnloadedException`](https://learn.microsoft.com/en-us/dotnet/api/system.appdomainunloadedexception)
- [`BadImageFormatException`](https://learn.microsoft.com/en-us/dotnet/api/system.badimageformatexception)
- [`InvalidProgramException`](https://learn.microsoft.com/en-us/dotnet/api/system.invalidprogramexception)
- [`ThreadAbortException`](https://learn.microsoft.com/en-us/dotnet/api/system.threading.threadabortexception)
- [`AccessViolationException`](https://learn.microsoft.com/en-us/dotnet/api/system.accessviolationexception)
- [`OutOfMemoryException`](https://learn.microsoft.com/en-us/dotnet/api/system.outofmemoryexception)
- [`SEHException`](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.sehexception)
- [`SecurityException`](https://learn.microsoft.com/en-us/dotnet/api/system.security.securityexception)

### Early detection of critical errors

Here's how to avoid a critical exception ever entering a `catch` block:

```csharp
// using Louis.Diagnostics;

catch (Exception e) when (!e.IsCriticalError())
{
     // Handle any non-critical exception
}
```

The `when` clause prevents stack unwinding: execution goes straight to any outer `catch` block, hopefully implementing the same logic.

Ultimately, your program _will_ crash, as it was already bound to do.
Just a little faster, and with the actual exception information you need to diagnose your software.

### Custom critical exception types

Any exception type that implements the `Louis.Diagnostics.ICriticalError` interface is considered a critical error as well.
`ICriticalError` is a "flag" interface with no members.

This allows you to add your own exception types to the list, although the need for it should be rare.

---

## Drilling down

Exceptions can be misleading.

Say an I/O error occurs while saving a file to a USB drive.  
You need to warn the user accordingly, so you handle `IOException`, right?  
But what if the `IOException` gets wrapped in a `FileWriterException` by some third-party library?  
And then in a `WhateverLibraryException`?  
And then again in an `AggregateException`?  
Handling code can get pretty ugly pretty fast.

Here comes L.o.U.I.S. to the rescue:

```csharp
// using Louis.Diagnostics;

catch (Exception e) when (!e.IsCriticalError() && e.AnyCausingException(x => x is IOException))
{
     // Something went wrong with I/O
}
```

You can also enumerate all exceptions represented by an exception, from outer to inner ones:

```csharp
// using Louis.Diagnostics;

foreach (var e in exception.GetCausingExceptions())
{
    // Do something
}
```

---

## Rethrowing exceptions

How do you rethrow an exception, preserving stack trace information?  
Easy:

- on .NET or .NET Standard 2.1, use [`ExceptionDispatchInfo.Throw(ex)`](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.exceptionservices.exceptiondispatchinfo.throw#system-runtime-exceptionservices-exceptiondispatchinfo-throw(system-exception));
- on .NET, .NET Framework, or .NET Standard 2.0, use [`ExceptionDispatchInfo.Capture(ex)`](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.exceptionservices.exceptiondispatchinfo.capture)[`.Throw()`](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.exceptionservices.exceptiondispatchinfo.throw#system-runtime-exceptionservices-exceptiondispatchinfo-throw).

Writing software for multiple target frameworks?  
Enjoy your `#if` blocks. :shrug:

Or just use `Rethrow()`: easier and cleaner, works on any target framework L.o.U.I.S. supports.

```csharp
// using Louis.Diagnostics;

WhateverException? exception = null;
try
{
    // Do someything risky
}
catch (WhateverException e)
{
    // Do what you have to do here; then...
    exception = e;
}

exception?.Rethrow();
```

---

## Building exception messages

Sometimes an exception message has to give a clue as to which object caused the exception.
So you can dump the object in the message... but what if it is a 2-megabyte string?

Or you can tell just the object type.
Great, now the log says it's an `Int32`: hardly helpful.

Or you can leave it to `ExceptionHelper.FormatObject(obj)` and get:

| If `obj` is...                             | `FormatObject` returns...                                                                                  |
| ------------------------------------------ | ---------------------------------------------------------------------------------------------------------- |
| `null`                                     | `"<null>"`                                                                                                 |
| The default value of a nullable value type | `"<null>"`                                                                                                 |
| A string                                   | `obj` escaped, quoted, and trimmed to max 20 leading and 20 trailing characters with `"..."` in the middle |
| An `IFormattable` instance                 | `obj` formatted using the invariant culture                                                                |

For any other object, `FormatObject` will call `obj.ToString()` and return:

- if `ToString` fails, `"<{objType}:{exceptionType}>"`;
- if the result is `null`, `"<null!>"`;
- if the result is the empty string, `"<empty!>"`;
- otherwise, as if `obj` were the returned string (see the above table).

You may also pass a format string as `FormatObject`'s second parameter.  
It will be used (with the invariant culture) if `obj` implements `IFormattable`.

If formatting an `IFormattable` instance fails with an exception, `FormatObject` will:

- first retry with an empty format string if it was called with a non-empty one;
- failing that, treat the object as if it didn't implement `IFormattable`.
