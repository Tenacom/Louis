# Architecture

This file is specific to this repository. Rewrite it when `.claude` is copied to another repository.

Louis is a library of general-purpose types for .NET libraries and applications. It ships as two NuGet packages, `Louis` and `Louis.Hosting`, built from the two projects under `src/`. There is no application, no tool, and no source generator.

## Project structure

`Louis.slnx` is the authoritative list of projects.

- `src/Louis`: the `Louis` package. It depends on `CommunityToolkit.Diagnostics`, for argument checks.
- `src/Louis.Hosting`: the `Louis.Hosting` package. `AsyncHostedService` adapts `AsyncService` to the `IHostedService` contract of `Microsoft.Extensions.Hosting.Abstractions`, and logs through `Microsoft.Extensions.Logging.Abstractions`. It references `src/Louis` as a project.

### Test projects

Each package `<Package>`, built from `src/<Package>`, has three test projects under `tests/`. "Every build of a package gets tested" in `testing.md` says what each kind does.

- `<Package>.Tests` is the main test project. It targets `net10.0`, and `net48` on Windows.
- `<Package>.Tests.NetStandard20` and `<Package>.Tests.NetStandard21` are the `netstandard` test projects. They turn `DisableImplicitFrameworkDefines` on and define the symbols of the build they test: `NETSTANDARD`, `NETSTANDARD2_0`, and `NETSTANDARD2_0_OR_GREATER` for a `NetStandard20` project, and `NETSTANDARD`, `NETSTANDARD2_1`, `NETSTANDARD2_0_OR_GREATER`, and `NETSTANDARD2_1_OR_GREATER` for a `NetStandard21` project. A test of framework-specific code then copies the `#if` of the member it tests, in every test project. A `NetStandard20` project references `Microsoft.Bcl.AsyncInterfaces`, because the `netstandard2.0` build of `Louis` does.

`tests/Common.targets` holds the settings every test project gets.

Louis supports Windows and Linux, and `ci.yml` runs the tests on `ubuntu-latest` and `windows-latest`. The `net48` tests run on the Windows runner alone. "Tests on more than one platform" in `testing.md` holds for every other test.

`ReadOnlyMemoryStream` is the one type with members that bind differently per build, as "Every build of a package gets tested" in `testing.md` describes. `Read(Span<byte>)`, `ReadAsync(Memory<byte>, CancellationToken)`, `CopyTo(Stream, int)`, `Write(ReadOnlySpan<byte>)`, and `WriteAsync(ReadOnlyMemory<byte>, CancellationToken)` are overrides only on the frameworks where `Stream` has them as virtual members. A test calls them through a `ReadOnlyMemoryStream` variable, never through a `Stream` variable.

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

A namespace named `Internal` holds types that are not part of the public surface. `Louis.Text.Internal`, `Louis.Diagnostics.Internal`, and `Louis.Hosting.Internal` are the three.

`UnicodeCharacterUtility` is adapted from Roslyn, and `THIRD-PARTY-NOTICES.md` carries the attribution. "Conformance with the toolchain we belong to" in `design-principles.md` says what copying costs. Do not add a second copied file without adding its notice in the same commit.

## Target frameworks

`Louis` packages target `netstandard2.0`, `netstandard2.1`, `net48`, and `net10.0`. The `.NET Framework` target exists next to `netstandard2.0` because a framework-specific build gets better optimization in .NET Framework applications.

- A target framework leaves the list when Microsoft ends its support. The removal is a breaking change, and gets a `**BREAKING CHANGE**:` bullet in `CHANGELOG.md`.
- Code that differs per framework sits under `#if` with an `_OR_GREATER` symbol, such as `NET7_0_OR_GREATER` or `NETSTANDARD2_1_OR_GREATER`. A symbol for one framework alone, such as `NET10_0`, never appears, so that a new framework needs no source change.
- A type or member that only some frameworks get says so in its XML comment. The comment names the builds of the package that lack it, and the BCL type they lack, as the comment of `DateOnlyUtility` does.
- `Common.props` turns `IsTrimmable` on for the frameworks compatible with `net8.0`.
- The projects reference `System.Memory`, `System.Threading.Tasks.Extensions`, and `Microsoft.Bcl.AsyncInterfaces` only on the frameworks that lack the types. `Louis.csproj` holds one `ItemGroup` per such framework.
- PolySharp generates every other polyfill, as internal types. A public BCL type that an older framework lacks, such as `DateOnly`, gets no polyfill, because a consumer's own polyfill of the type would conflict with it. A member that uses such a type goes under `#if`, as `DateOnlyExtensions` does.

### Public API files

`Louis` has one pair of public API files per target framework, under `src/Louis/PublicAPI/<target framework>/`, because its surface differs per framework. `Louis.Hosting` has one pair in its project directory, because its surface is the same everywhere. `UseTfmSpecificPublicApiFiles` in each project file selects the layout. A new target framework gets its directory as a copy of the closest existing one.

## Documentation

`documentation.md` holds the rules. This section lists what they apply to in this repository.

### Files

The following are technical documentation:

- `CHANGELOG.md`
- `docs/`

The following are not technical documentation. Check them for accuracy, but they are allowed a less formal register:

- `README.md`
- `graphics/README.md`
- `src/<project>/NuGet-README.md`

The following are not documentation:

- `THIRD-PARTY-NOTICES.md` holds the copyright notices of code dependencies;
- `THIRD-PARTY-GRAPHICS.md` holds the copyright notices of the graphic elements in `graphics/`.

### Subfolders of `docs/`

`api/`, the generated folder below. Every hand-written page sits in `docs/` itself.

### Generated regions

None.

### Generated folders

`docs/api/<AssemblyName>/` holds the API reference of each package, flat: `README.md` for the assembly, which GitHub renders in the directory view, a page per namespace, and a page per type with its members. The hook `.buildvana/hooks/release/post-pack.cs` writes it with DefaultDocumentation at every release, prereleases included, so the pages on `main` describe the latest release. The hook reads the assembly and the XML documentation file of one target framework, the newest `net<major>.<minor>` one. A `netstandard` build may lack a member the pages hold, and the XML comment of the member says so, as "Target frameworks" above requires.

The summary of a namespace page comes from the `NamespaceDoc` class of the namespace, and the summary of `README.md` from the `AssemblyDoc` class of the package. Both are `internal static`, and a new namespace gets its `NamespaceDoc` class in the same change. The entry pages are the namespace pages, and `docs/README.md` links each one.
