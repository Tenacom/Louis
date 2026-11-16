# Architecture

This file is specific to this repository. Rewrite it when `.claude` is copied to another repository.

Louis is a library of general-purpose types for .NET libraries and applications. It ships as three NuGet packages, `Louis`, `Louis.Hosting`, and `Louis.Testing`, built from the three projects under `src/`. There is no application, no tool, and no source generator.

## Project structure

`Louis.slnx` is the authoritative list of projects.

- `src/Louis`: the `Louis` package. It depends on `CommunityToolkit.Diagnostics`, for argument checks.
- `src/Louis.Hosting`: the `Louis.Hosting` package. `AsyncHostedService` adapts `AsyncService` to the `IHostedService` contract of `Microsoft.Extensions.Hosting.Abstractions`, and logs through `Microsoft.Extensions.Logging.Abstractions`. It references `src/Louis` as a project.
- `src/Louis.Testing`: the `Louis.Testing` package. It holds the test doubles of the contracts of `Louis`, such as `FakeProcessRunner` for `IProcessRunner`. It references `src/Louis` as a project, and nothing else. Its `RootNamespace` is `Louis`, because a test double goes in the namespace of its contract.

### Test projects

`Louis` and `Louis.Hosting` have three test projects each under `tests/`, where `<Package>` below is the name of the package. "Every build of a package gets tested" in `testing.md` says what each kind does.

- `<Package>.Tests` is the main test project. It targets `net10.0` and `net11.0`, and `net48` on Windows.
- `<Package>.Tests.NetStandard20` and `<Package>.Tests.NetStandard21` are the `netstandard` test projects. They turn `DisableImplicitFrameworkDefines` on and define the symbols of the build they test: `NETSTANDARD`, `NETSTANDARD2_0`, and `NETSTANDARD2_0_OR_GREATER` for a `NetStandard20` project, and `NETSTANDARD`, `NETSTANDARD2_1`, `NETSTANDARD2_0_OR_GREATER`, and `NETSTANDARD2_1_OR_GREATER` for a `NetStandard21` project. A test of framework-specific code then copies the `#if` of the member it tests, in every test project. A `NetStandard20` project references `Microsoft.Bcl.AsyncInterfaces` and `Microsoft.Bcl.Memory`, because the `netstandard2.0` build of `Louis` does. No `netstandard` test project references `System.Text.Encoding.CodePages`, because the `net11.0` runtime it runs on has that assembly.

`Louis.Testing` has one test project, `Louis.Testing.Tests`, on `net10.0` and `net11.0`, the target frameworks of the package.

`tests/Louis.Tests.ChildProcess` is not a test project. It is the program that the tests of `ProcessRunner` run as a child process. `Louis.Tests` references it on `net10.0` and `net11.0`, and `ChildProcess` there builds the command that runs it from the output directory. The coverage collector follows a test into its child processes, so `Program` has `[ExcludeFromCodeCoverage]`.

`tests/Common.targets` holds the settings every test project gets. It also turns `IsPackable` off for every project under `tests/`, test project or not.

Louis supports Windows and Linux, and `ci.yml` runs the tests on `ubuntu-latest` and `windows-latest`. The `net48` tests run on the Windows runner alone. "Tests on more than one platform" in `testing.md` holds for every other test.

### Namespaces of `Louis`

Each namespace of `Louis` groups types by the BCL area they extend or complete.

| Namespace             | Holds                                                                                                                                                                               |
| --------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `Louis`               | Disposing: `ActionDisposable`, `ActionAsyncDisposable`, `LocalActionDisposable`, `DisposingUtility`, `AsyncDisposableExtensions`. Dates: `DateUtility`, `DateTimeExtensions`, `DateOnlyUtility`, `DateOnlyExtensions`, `TimeConstants`. Also `RangeCheck` and `ReadOnlySpanFunc<T>`. |
| `Louis.Collections`   | `EnumerableExtensions`.                                                                                                                                                             |
| `Louis.ComponentModel` | Type converters: `SimpleStringConverter<T>`, `ParsableStringConverter<T>`, `MailAddressConverter`, `MailAddressCollectionConverter`, and `SimpleStringConverter` to register them. |
| `Louis.Diagnostics`   | Exceptions: `ExceptionExtensions`, `ExceptionHelper`, `SelfCheck`, `InternalErrorException`, `CriticalInternalErrorException`, `ICriticalError`. Also `StringBuilderExtensions`, with `AppendFormattedObject`. |
| `Louis.Fluency`       | `FluentExtensions` and the `FluentAction` delegates.                                                                                                                                |
| `Louis.Processes`     | `ProcessRunner` with its contract `IProcessRunner`, `ProcessRunOptions`, `ProcessResult`, `ProcessFailedException`, in the `net10.0` and `net11.0` builds alone. Also `CommandLineFormatter` and `ConsoleUtility`, in every build. |
| `Louis.Text`          | String literals: `StringExtensions`, `CharReadOnlySpanExtensions`, `StringBuilderExtensions`, `StringLiteralKind`. Lines: `ComputeLineClipping` in the first two, and `LineClipping`. Also `UnicodeCharacterUtility`, `Utf8Utility`, and the conditional interpolated string handlers. |
| `Louis.Threading`     | `AsyncService` with its enums, `InterlockedFlag`, `InterlockedReference<T>`, `ValueTaskUtility`.                                                                                    |

`Louis.Testing` adds `FakeProcessRunner` and `FakeProcessRun` to `Louis.Processes`.

A namespace named `Internal` holds types that are not part of the public surface. `Louis.Text.Internal` and `Louis.Hosting.Internal` are the two.

`UnicodeCharacterUtility` is adapted from Roslyn, and `THIRD-PARTY-NOTICES.md` carries the attribution. "Conformance with the toolchain we belong to" in `design-principles.md` says what copying costs. Do not add a second copied file without adding its notice in the same commit.

## Target frameworks

`Louis` and `Louis.Hosting` target `netstandard2.0`, `netstandard2.1`, `net48`, `net10.0`, and `net11.0`. The `.NET Framework` target exists next to `netstandard2.0` because a framework-specific build gets better optimization in .NET Framework applications.

`Louis.Testing` targets `net10.0` and `net11.0` alone, because `IProcessRunner` is in those two builds of `Louis` alone. It gets the other target frameworks with its first test double of a contract every build has.

- Every release supports each .NET version that Microsoft supports on the day of the release, with a target framework of its own. The [.NET Support Policy](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core) lists the supported versions. "Packages released with .NET" in `dependency-management.md` relies on this rule.
- A target framework leaves the list when Microsoft ends its support. The removal is a breaking change, and gets a `**BREAKING CHANGE**:` bullet in `CHANGELOG.md`.
- Code that differs per framework sits under `#if` with an `_OR_GREATER` symbol, such as `NET7_0_OR_GREATER` or `NETSTANDARD2_1_OR_GREATER`. A symbol for one framework alone, such as `NET10_0`, never appears, so that a new framework needs no source change.
- Code that depends on a framework family, and not on a version, sits under a family symbol: `NETFRAMEWORK`, `NETSTANDARD`, or `NETCOREAPP`. For example, `#if !NETFRAMEWORK` excludes code from .NET Framework builds but keeps it for .NET and .NET Standard, regardless of version.
- A type or member that only some frameworks get says so in its XML comment. The comment names the builds of the package that lack it, and the BCL type they lack, as the comment of `DateOnlyUtility` does.
- Every release is built with the latest .NET SDK that Microsoft has released on the day of the release, previews excluded. `global.json` selects the SDK. Its major version is that of the newest target framework.
- `ci.yml` and `release.yml` install the .NET SDK of `global.json` through `global-json-file`. Their `dotnet-version` input lists the older `net<major>.<minor>` frameworks alone, so that the tests of each have a runtime. It never lists the major version of the SDK.
- `Common.props` turns `IsTrimmable` on for the frameworks compatible with `net8.0`.
- The projects reference `System.Memory`, `System.Threading.Tasks.Extensions`, `Microsoft.Bcl.AsyncInterfaces`, `Microsoft.Bcl.Memory`, and `System.Text.Encoding.CodePages` only on the frameworks that lack the types. `Louis.csproj` holds one `ItemGroup` per such framework. `Microsoft.Bcl.Memory` supplies the public `Range` that `LineClipping` exposes. `System.Text.Encoding.CodePages` supplies the `CodePagesEncodingProvider` that `ConsoleUtility` reads the OEM code page encoding from.
- PolySharp generates every other polyfill, as internal types. A public BCL type that an older framework lacks and no Microsoft package supplies, such as `DateOnly`, gets no polyfill, because a consumer's own polyfill of the type would conflict with it. A member that uses such a type goes under `#if`, as `DateOnlyExtensions` does.

### Public API files

`Louis` has one pair of public API files per target framework, under `src/Louis/PublicAPI/<target framework>/`, because its surface differs per framework. `Louis.Hosting` and `Louis.Testing` have one pair each, in the project directory, because the surface of each is the same on every target framework. `UseTfmSpecificPublicApiFiles` in each project file selects the layout. No release holds a build for a new target framework. Its directory has the `#nullable enable` header alone in `PublicAPI.Shipped.txt`, and its whole surface in `PublicAPI.Unshipped.txt`, with no `*REMOVED*` line.
