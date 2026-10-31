# Disposing anything

Let's say you have to get rid of some objects: some may implement `IDisposable`, others `IAsyncDisposable`, and some may be not disposable at all.  
Or maybe they're just interfaces to you, and you don't know whether they must be disposed or not.

> [!IMPORTANT]
> None of the methods described in this section handles [disposable ref structs](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/ref-struct).

---

<!-- markdownlint-disable MD036 -->
**Table of contents**
<!-- markdownlint-enable MD036 -->

- [Disposing synchronously](#disposing-synchronously)
  - [Disposing a single object synchronously](#disposing-a-single-object-synchronously)
  - [Disposing multiple objects synchronously](#disposing-multiple-objects-synchronously)
  - [Disposing a sequence of objects synchronously](#disposing-a-sequence-of-objects-synchronously)
- [Disposing asynchronously](#disposing-asynchronously)
  - [Disposing a single object asynchronously](#disposing-a-single-object-asynchronously)
  - [Disposing multiple objects asynchronously](#disposing-multiple-objects-asynchronously)
  - [Disposing a sequence of objects asynchronously](#disposing-a-sequence-of-objects-asynchronously)

---

## Disposing synchronously

All the following methods always return to the synchronization context of the caller; it is therefore safe to call them from a UI thread.

### Disposing a single object synchronously

The synchronous `DisposingUtility.Dispose(object? obj)` method in namespace `Louis`:

- if `obj` implements `IDisposable`, calls its `Dispose` method synchronously (so non-thread-safe objects are treated correctly);
- otherwise, if the object implements `IAsyncDisposable`, calls its `DisposeAsync` method and synchronously waits for the returned `ValueTask` to complete;
- otherwise, returns immediately.

### Disposing multiple objects synchronously

The synchronous `DisposingUtility.Dispose(params object?[] items)` method in namespace `Louis`:

- calls the `Dispose` methods of all items implementing `IDisposable`;
- calls the `DisposeAsync` methods of all items implementing `IAsyncDisposable` but not implementing `IDisposable`;
- waits for the returned `ValueTask`s to complete in parallel.

Any exceptions thrown by called `Dispose` and/or `DisposeAsync` methods are returned together as an `AggregateException`.

### Disposing a sequence of objects synchronously

The synchronous `IEnumerable.DisposeAll()` extension method in namespace `Louis.Collections`:

- calls the `Dispose` methods of all items implementing `IDisposable`;
- calls the `DisposeAsync` methods of all items implementing `IAsyncDisposable` but not implementing `IDisposable`;
- waits for the returned `ValueTask`s to complete in parallel.

Any exceptions thrown by called `Dispose` and/or `DisposeAsync` methods are returned together as an `AggregateException`.

---

## Disposing asynchronously

### Disposing a single object asynchronously

The asynchronous `DisposingUtility.DisposeAsync(object? obj)` method in namespace `Louis`:

- if the object implements `IAsyncDisposable`, calls its `DisposeAsync` method and returns the resulting `ValueTask`;
- otherwise, if the object implements `IDisposable`, calls its `Dispose` method synchronously (so non-thread-safe objects are treated correctly) and returns a completed `ValueTask`;
- otherwise, immediately returns a completed `ValueTask`.

### Disposing multiple objects asynchronously

The asynchronous `DisposingUtility.DisposeAsync(params object?[] items)` method in namespace `Louis`:

- calls the `Dispose` methods of all items implementing `IDisposable`;
- calls the `DisposeAsync` methods of all items implementing `IAsyncDisposable` but not implementing `IDisposable`;
- asynchronously waits for the returned `ValueTask`s to complete in parallel.

Any exceptions thrown by called `Dispose` and/or `DisposeAsync` methods are returned together as an `AggregateException`.

### Disposing a sequence of objects asynchronously

The asynchronous `IEnumerable.DisposeAllAsync()` method in namespace `Louis.Collections`:

- calls the `Dispose` methods of all items implementing `IDisposable`;
- calls the `DisposeAsync` methods of all items implementing `IAsyncDisposable` but not implementing `IDisposable`;
- asynchronously waits for the returned `ValueTask`s to complete in parallel.

Any exceptions thrown by called `Dispose` and/or `DisposeAsync` methods are returned together as an `AggregateException`.
