# L.o.U.I.S. documentation

Every release of L.o.U.I.S. has its own API reference, generated from XML comments.
Each line below links the page of a namespace, which lists its types and links the page of each one.

## `Louis`

- [`Louis`](api/Louis/Louis.md): disposables that invoke a callback, utility methods for dates and times, and range checks.
- [`Louis.Collections`](api/Louis/Louis.Collections.md): extension methods for enumerable types.
- [`Louis.ComponentModel`](api/Louis/Louis.ComponentModel.md): type converters between a type and strings, and base classes to write such converters.
- [`Louis.Diagnostics`](api/Louis/Louis.Diagnostics.md): types to create, inspect, and rethrow exceptions, to identify critical errors, and to perform self-checks.
- [`Louis.Fluency`](api/Louis/Louis.Fluency.md): extension methods that embed conditional logic and other operations in a fluent call chain.
- [`Louis.Processes`](api/Louis/Louis.Processes.md): types that run a child process and read what it writes, and utility members for the console.
- [`Louis.Text`](api/Louis/Louis.Text.md): C# string literals, Unicode and UTF-8 utilities, text editing utilities, and conditional interpolated string handlers.
- [`Louis.Threading`](api/Louis/Louis.Threading.md): a base class for long-running services, thread-safe flags and references, and utility methods for `ValueTask`.

## `Louis.Hosting`

- [`Louis.Hosting`](api/Louis.Hosting/Louis.Hosting.md): types that run an `AsyncService` as a hosted service.

## `Louis.Testing`

- [`Louis.Processes`](api/Louis.Testing/Louis.Processes.md): a test double of `IProcessRunner`, which records each run and starts no process.
