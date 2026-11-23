# Architecture

This file is specific to this repository. Rewrite it when `.claude` is copied to another repository.

Louis is a library of general-purpose types for .NET libraries and applications. It ships as three NuGet packages, `Louis`, `Louis.Hosting`, and `Louis.Testing`, each built from the project of its name under `src/`. The `Louis` package also holds a source generator and analyzers, built from `src/Louis.Generators`. There is no application and no tool.

## Project structure

`Louis.slnx` is the authoritative list of projects.

- `src/Louis`: the `Louis` package. It depends on the BCL alone. On a target framework that lacks a type it needs, it also references a polyfill from Microsoft, such as `System.Memory` or `Microsoft.Bcl.Memory`. It references `src/Louis.Generators` as an analyzer, and packs the assembly of that project in its `analyzers` folder.
- `src/Louis.Hosting`: the `Louis.Hosting` package. It runs a long-running service of `Louis` under the `IHostedService` contract of `Microsoft.Extensions.Hosting.Abstractions`, and logs through `Microsoft.Extensions.Logging.Abstractions`. It references `src/Louis` as a project.
- `src/Louis.Testing`: the `Louis.Testing` package. It holds the test doubles of the contracts of `Louis`. It references `src/Louis` as a project, and nothing else. Its `RootNamespace` is `Louis`, because a test double goes in the namespace of its contract.
- `src/Louis.Generators`: the source generator and the analyzers of the `Louis` package. It is not packable, and no package depends on it. It targets `netstandard2.0`, because the compiler loads a generator of no other target framework. `guest-code.md` governs the code it generates.

The references of `src/Louis.Hosting` and `src/Louis.Testing` to `src/Louis` set `PrivateAssets` to `contentfiles;build`. A project that references one of those two packages alone then gets the source generator and the analyzers.

### Test projects

`Louis` and `Louis.Hosting` have three test projects each under `tests/`, where `<Package>` below is the name of the package. "Every build of a package gets tested" in `testing.md` says what each kind does, and which frameworks it targets.

- `<Package>.Tests` is the main test project.
- `<Package>.Tests.NetStandard20` and `<Package>.Tests.NetStandard21` are the `netstandard` test projects. They turn `DisableImplicitFrameworkDefines` on and define the symbols of the build they test: `NETSTANDARD`, `NETSTANDARD2_0`, and `NETSTANDARD2_0_OR_GREATER` for a `NetStandard20` project, and `NETSTANDARD`, `NETSTANDARD2_1`, `NETSTANDARD2_0_OR_GREATER`, and `NETSTANDARD2_1_OR_GREATER` for a `NetStandard21` project. A test of framework-specific code then copies the `#if` of the member it tests, in every test project. A `NetStandard20` project references `Microsoft.Bcl.AsyncInterfaces` and `Microsoft.Bcl.Memory`, because the `netstandard2.0` build of `Louis` does. No `netstandard` test project references `System.Text.Encoding.CodePages`, because the runtime it runs on has that assembly.

`Louis.Testing` has one test project, `Louis.Testing.Tests`, on the target frameworks of the package.

`Louis.Generators` has one test project, `Louis.Generators.Tests`, on the newest target framework alone. Its tests compile source text with the version of Roslyn that `Louis.Generators` references, and run the source generator and the analyzers on it.

The test projects of `Louis` reference `src/Louis.Generators` as an analyzer, as a project that references the `Louis` package does. Their tests call generated methods on every build of `Louis`.

`tests/Louis.Tests.ChildProcess` is not a test project. It is the program that the tests of `Louis.Processes` run as a child process, from the output directory. `Louis.Tests` references it on its `net<major>.<minor>` target frameworks, because the types that run a child process are in those builds of `Louis` alone. The coverage collector follows a test into its child processes, so `Program` has `[ExcludeFromCodeCoverage]`.

`tests/Common.props` and `tests/Common.targets` hold the settings of every project under `tests/`, test project or not. The settings of the test projects alone are in `tests/Common.targets`, under a condition on `IsTestingPlatformApplication`.

Louis supports Windows and Linux, and `ci.yml` runs the tests on `ubuntu-latest` and `windows-latest`. The .NET Framework tests run on the Windows runner alone. "Tests on more than one platform" in `testing.md` holds for every other test.

### Namespaces of `Louis`

A type goes in the namespace these rules select:

- `Louis` holds two kinds of types. The first kind relates to, or helps with, types in `System`. Examples are the implementations of `IDisposable` that invoke a callback, and the extension methods for `DateTime`. The second kind is so basic and general-purpose that it would be in `System` if the BCL had it. The range checks on comparable values are an example.
- `Louis.<name>` holds features of the area `System.<name>` covers, when the BCL has that namespace. `Louis.Diagnostics` and `Louis.Text` are examples.
- `Louis.<name>` is a namespace in its own right, when the BCL has no `System.<name>`. The list below says what each such namespace holds, and a new one gets its line in the same change.
- A namespace named `Internal` holds types that are not part of the public surface.
- An extension class sits in the namespace of the features its members provide, whatever the namespace of the extended type. The extension methods that inspect and rethrow a `System.Exception` sit in `Louis.Diagnostics`. The ones that turn a `System.String` into a C# string literal sit in `Louis.Text`. "Extension classes" in `csharp-style-guide.md` says how the class is named.

The namespaces in their own right:

- `Louis.Fluency` holds extension methods that embed conditional logic and other operations in a fluent call chain.
- `Louis.Processes` holds types to run a child process and read what it writes, and utilities for the console.

No rule covers any other case yet, such as helpers for types in `Microsoft.Extensions.<name>`. Ask the maintainer when one arises.

## Target frameworks

The `TargetFrameworks` property of each project file is the authority on the target frameworks of the project. This file does not list them.

- `Louis` and `Louis.Hosting` have a .NET Framework target framework next to `netstandard2.0`, because a framework-specific build gets better optimization in .NET Framework applications.
- `Louis.Testing` has the `net<major>.<minor>` target frameworks alone, because the contracts it has test doubles of are in those builds of `Louis` alone. It gets the other target frameworks with its first test double of a contract every build has.
- Every release supports each .NET version that Microsoft supports on the day of the release, with a target framework of its own. The [.NET Support Policy](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core) lists the supported versions. "Packages released with .NET" in `dependency-management.md` relies on this rule.
- A target framework leaves `TargetFrameworks` when Microsoft ends its support. The removal is a breaking change, and gets a `**BREAKING CHANGE**:` bullet in `CHANGELOG.md`.
- Code that differs per framework sits under `#if` with an `_OR_GREATER` symbol, such as `NET7_0_OR_GREATER` or `NETSTANDARD2_1_OR_GREATER`. A symbol for one framework alone, such as `NET10_0`, never appears, so that a new framework needs no source change.
- Code that depends on a framework family, and not on a version, sits under a family symbol: `NETFRAMEWORK`, `NETSTANDARD`, or `NETCOREAPP`. For example, `#if !NETFRAMEWORK` excludes code from .NET Framework builds but keeps it for .NET and .NET Standard, regardless of version.
- The symbols of a `#if` name the frameworks the discriminating feature arrived with, even frameworks no package targets. The discriminating feature is the BCL type or member that the code under the `#if` needs. `NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_0_OR_GREATER` is the `#if` of a feature that .NET Core 2.0 and .NET Standard 2.1 introduced. When the code starts to use a newer feature, the symbols change with it.
- Each build uses the best that its framework provides. Where some frameworks have a BCL member that does the job, call it under `#if`, and keep the workaround for the other frameworks in the `#else`. Do not run the workaround on every build, and do not suppress an analyzer that asks for the newer member.
- When a type sits under a `#if`, a type whose only purpose is to support it gets the same `#if`. A type that is of use by itself gets the `#if` its own code needs, which may be none.
- A type or member that only some frameworks get says so in its XML comment. The comment names the builds of the package that lack it, and the BCL type they lack.
- Every release is built with the latest .NET SDK that Microsoft has released on the day of the release, previews excluded. `global.json` selects the SDK. Its major version is that of the newest target framework.
- `ci.yml` and `release.yml` install the .NET SDK of `global.json` through `global-json-file`. Their `dotnet-version` input lists the older `net<major>.<minor>` frameworks alone, so that the tests of each have a runtime. It never lists the major version of the SDK.
- The projects reference `System.Memory`, `System.Threading.Tasks.Extensions`, `Microsoft.Bcl.AsyncInterfaces`, `Microsoft.Bcl.Memory`, and `System.Text.Encoding.CodePages` only on the frameworks that lack the types. `Louis.csproj` holds one `ItemGroup` per such framework. `Microsoft.Bcl.Memory` supplies `Range`, which the public surface of `Louis` exposes. `System.Text.Encoding.CodePages` supplies `CodePagesEncodingProvider`, the source of the OEM code page encoding.
- PolySharp generates every other polyfill, as internal types. A public BCL type that an older framework lacks and no Microsoft package supplies, such as `DateOnly`, gets no polyfill, because a consumer's own polyfill of the type would conflict with it. A member that uses such a type goes under `#if`.
- `src/Louis/Polyfills` declares `DoesNotReturnAttribute` and `StackTraceHiddenAttribute` itself, as public types, on the target frameworks that lack them. They are the one exception to the rule above. A source generator gives a method one of these attributes only when the project can name it, and it does not see a type that PolySharp generates. `StackTraceHiddenAttribute` is internal in the `netstandard2.1` build, because that build also serves .NET versions whose BCL has the attribute.

### Public API files

`Louis` has one pair of public API files per target framework, under `src/Louis/PublicAPI/<target framework>/`, because its surface differs per framework. `Louis.Hosting` and `Louis.Testing` have one pair each, in the project directory, because the surface of each is the same on every target framework. `UseTfmSpecificPublicApiFiles` in each project file selects the layout. `PublicAPI.Shipped.txt` lists the surface of the latest stable release. The directory of a new target framework starts as a copy of the directory of the newest older `net<major>.<minor>` target framework of that release, because a project on the new target framework got that build before. An API removed from the new build then needs a `*REMOVED*` line, and `bv release` requires a major version for it.
