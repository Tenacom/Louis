# Terminology

This file is specific to this repository. Rewrite it when `.claude` is copied to another repository.

One name per thing, in every kind of prose: documentation, chat, commit messages, issues, and code comments. `output-styles/simple-tech.md` states the rule. This file holds the names. When a thing has no name here, add one before using it in a second place.

| Thing                                                                                         | Name                       | Not                                      |
| --------------------------------------------------------------------------------------------- | -------------------------- | ---------------------------------------- |
| The project, and the family of packages, in all contexts except documentation                 | Louis                      | L.o.U.I.S.                               |
| The project, in documentation                                                                 | L.o.U.I.S.                 | Louis                                    |
| The package built from `src/Louis`                                                            | `Louis`                    | the core package, the main package       |
| The package built from `src/Louis.Hosting`                                                    | `Louis.Hosting`            | the hosting package                      |
| The package built from `src/Louis.Testing`                                                    | `Louis.Testing`            | the testing package, the test package    |
| A `netX.Y` or `netstandardX.Y` moniker a project builds for                                   | target framework           | TFM, platform, target                    |
| The directory Buildvana works from, the repository root here                                  | home directory             | repository root, solution directory      |
| An exception that must not be handled, as `IsCriticalError` defines it                        | critical error             | critical exception, fatal exception      |
| An exception reached through `InnerException` or `AggregateException.InnerExceptions`         | causing exception          | inner exception, root cause              |
| The three phases of `AsyncService`, as `SetupAsync`, `ExecuteAsync`, `TeardownAsync` run them | setup, execution, teardown | start, run, stop                         |
| A C# string literal that `ToLiteral` and `AppendLiteral` produce, in a `StringLiteralKind`    | string literal             | quoted string, escaped string            |
| The replacement of a range of a text with another text, as a `TextEdit` describes it          | edit                       | text change, patch                       |
| The bytes at the start of a text file that identify its encoding                              | byte order mark            | BOM, preamble                            |
| The run mode in which `ProcessRunner` redirects the standard streams of the child process     | capture mode               | captured mode, redirected mode           |
| The run mode in which the child process shares the standard streams of the current process    | inherited mode             | inherit mode, pass-through mode          |
| A `PublicAPI.Shipped.txt` or `PublicAPI.Unshipped.txt` file                                   | public API file            | API file                                 |
| The code under `#if` that serves one group of target frameworks                               | framework-specific code    | platform-specific code, conditional code |
| A package that supplies a BCL type to a target framework that lacks it                        | polyfill                   | shim, compatibility package              |
| A test project that targets the frameworks its package runs on, such as `tests/Louis.Tests`   | main test project          | test project proper, full test project   |
| A test project that compiles the files of a main test project against a `netstandard` build   | `netstandard` test project | flavor project, mirror project           |
