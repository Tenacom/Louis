# Architecture

This file is specific to this repository. Rewrite it when `.claude` is copied to another repository.

Louis is a library of general-purpose types for .NET libraries and applications. It ships as two NuGet packages, `Louis` and `Louis.Hosting`, built from the two projects under `src/`. There is no application, no tool, and no source generator.

## Project structure

`Louis.slnx` is the authoritative list of projects.

- `src/Louis`: the `Louis` package. It depends on `CommunityToolkit.Diagnostics`, for argument checks, and on `PolyKit`, for polyfills of BCL types missing on the older target frameworks.
- `src/Louis.Hosting`: the `Louis.Hosting` package. `AsyncHostedService` adapts `AsyncService` to the `IHostedService` contract of `Microsoft.Extensions.Hosting.Abstractions`, and logs through `Microsoft.Extensions.Logging.Abstractions`. It references `src/Louis` as a project.

The repository has no test project. `tests/Common.targets` holds the settings a test project gets when one arrives, and `testing.md` says what framework it uses.

### Namespaces of `Louis`

Each namespace of `Louis` groups types by the BCL area they extend or complete.

| Namespace             | Holds                                                                                                                                                                               |
| --------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `Louis`               | Disposing: `ActionDisposable`, `ActionAsyncDisposable`, `LocalActionDisposable`, `DisposingUtility`, `AsyncDisposableExtensions`. Dates: `DateUtility`, `DateTimeExtensions`, `DateOnlyUtility`, `DateOnlyExtensions`, `TimeConstants`. Also `RangeCheck` and `ReadOnlySpanFunc<T>`. |
| `Louis.Collections`   | `EnumerableExtensions`.                                                                                                                                                             |
| `Louis.ComponentModel` | Type converters: `SimpleStringConverter<T>`, `ParsableStringConverter<T>`, `MailAddressConverter`, `MailAddressCollectionConverter`, and `SimpleStringConverter` to register them. |
| `Louis.Diagnostics`   | Exceptions: `ExceptionExtensions`, `ExceptionHelper`, `SelfCheck`, `InternalErrorException`, `CriticalInternalErrorException`, `ICriticalError`. Also `StringBuilderExtensions`, with `AppendFormattedObject`. |
| `Louis.Fluency`       | `FluentExtensions` and the `FluentAction` delegates.                                                                                                                                |
| `Louis.IO`            | `ReadOnlyMemoryStream`.                                                                                                                                                             |
| `Louis.Text`          | String literals: `StringExtensions`, `CharReadOnlySpanExtensions`, `StringBuilderExtensions`, `StringLiteralKind`. Also `UnicodeCharacterUtility`, `Utf8Utility`, and the conditional interpolated string handlers. |
| `Louis.Threading`     | `AsyncService` with its enums, `InterlockedFlag`, `InterlockedReference<T>`, `ValueTaskUtility`.                                                                                    |

A namespace named `Internal` holds types that are not part of the public surface. `Louis.Text.Internal` and `Louis.Hosting.Internal` are the two.

`UnicodeCharacterUtility` is adapted from Roslyn, and `THIRD-PARTY-NOTICES.md` carries the attribution. "Conformance with the toolchain we belong to" in `design-principles.md` says what copying costs. Do not add a second copied file without adding its notice in the same commit.

## Target frameworks

`Louis` targets `netstandard2.0`, `netstandard2.1`, `net462`, `net47`, and `net10.0`. `Louis.Hosting` targets the same set without `net47`. The `.NET Framework` targets exist next to `netstandard2.0` because a framework-specific build gets better optimization in .NET Framework applications.

- A target framework leaves the list when Microsoft ends its support. The removal is a breaking change, and gets a `**BREAKING CHANGE**:` bullet in `CHANGELOG.md`.
- Code that differs per framework sits under `#if` with an `_OR_GREATER` symbol, such as `NET7_0_OR_GREATER` or `NETSTANDARD2_1_OR_GREATER`. A symbol for one framework alone, such as `NET10_0`, never appears, so that a new framework needs no source change.
- A type or member that only some frameworks get says so in its XML comment, as `ParsableStringConverter<T>` does.
- `Common.props` turns `IsTrimmable` on for the frameworks compatible with `net8.0`.
- The projects reference `System.Memory`, `System.Threading.Tasks.Extensions`, `Microsoft.Bcl.AsyncInterfaces`, and `System.ValueTuple` only on the frameworks that lack the types. `Louis.csproj` holds one `ItemGroup` per such framework.

### Public API files

`Louis` has one pair of public API files per target framework, under `src/Louis/PublicAPI/<target framework>/`, because its surface differs per framework. `Louis.Hosting` has one pair in its project directory, because its surface is the same everywhere. `UseTfmSpecificPublicApiFiles` in each project file selects the layout. A new target framework gets its directory as a copy of the closest existing one.

## Documentation

`documentation.md` holds the rules. This section lists what they apply to in this repository.

### Files

- `README.md`
- `CHANGELOG.md`
- `docs/`
- `src/Louis/NuGet-README.md`
- `src/Louis.Hosting/NuGet-README.md`

`graphics/README.md` is not documentation. It holds the copyright notices of the graphic elements, and `THIRD-PARTY-NOTICES.md` points at it.

### Subfolders of `docs/`

`api/`, the generated folder below. Every hand-written page sits in `docs/` itself.

### Generated regions

None.

### Generated folders

`docs/api/<AssemblyName>/` holds the API reference of each package, flat: `README.md` for the assembly, which GitHub renders in the directory view, a page per namespace, and a page per type with its members. The hook `.buildvana/hooks/release/post-pack.cs` writes it with DefaultDocumentation at every release, prereleases included, so the pages on `main` describe the latest release. The hook reads the assembly and the XML documentation file of one target framework, the newest `net<major>.<minor>` one. A `netstandard` build may lack a member the pages hold, and the XML comment of the member says so, as "Target frameworks" above requires.

The summary of a namespace page comes from the `NamespaceDoc` class of the namespace, and the summary of `README.md` from the `AssemblyDoc` class of the package. Both are `internal static`, and a new namespace gets its `NamespaceDoc` class in the same change. The entry pages are the namespace pages, and `docs/README.md` links each one.
