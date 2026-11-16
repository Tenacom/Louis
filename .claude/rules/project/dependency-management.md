# Dependency management

This file is specific to this repository. Rewrite it when `.claude` is copied to another repository. `buildvana.md` holds the dependency rules that hold in every repository built with Buildvana.

## Run-time dependencies

Every consumer of a package inherits its run-time dependencies, so each one is a decision the maintainer takes, never a convenience.

- `Louis` depends on `CommunityToolkit.Diagnostics`, and on nothing else that every target framework gets. `System.Memory`, `System.Threading.Tasks.Extensions`, `Microsoft.Bcl.AsyncInterfaces`, `Microsoft.Bcl.Memory`, and `System.Text.Encoding.CodePages` are polyfills, referenced only on the target frameworks that lack the types. "Target frameworks" in `architecture.md` says which.
- `Louis.Hosting` depends on `Microsoft.Extensions.Hosting.Abstractions` and `Microsoft.Extensions.Logging.Abstractions`.
- Five pins name packages that Microsoft releases with each major version of .NET. "Packages released with .NET" below says how they are pinned.
- `Louis.Testing` depends on `Louis`, and on nothing else, so that a test project gets no test framework by referencing it.
- `Louis` is the library other Tenacom repositories rank alongside the BCL. Do not propose a dependency on another general-purpose utility library. Such a type gets written here instead.

## Packages released with .NET

Five run-time pins name packages that Microsoft builds in the `dotnet/runtime` repository and releases with each major version of .NET, under the version number of that .NET version: `Microsoft.Bcl.AsyncInterfaces`, `Microsoft.Bcl.Memory`, `Microsoft.Extensions.Hosting.Abstractions`, `Microsoft.Extensions.Logging.Abstractions`, and `System.Text.Encoding.CodePages`.

Pin each of the five to its latest major version, in one `PackageVersion` item with no condition. Do not hold a pin at an older major version because a package of this repository still targets the .NET version with the same number: 11.0.0 of all five supports .NET 10.

### Why one pin is enough

- A package of this family does not drop a .NET version that is in support. Only a version released after Microsoft's support for a .NET version has ended may drop it. "Compatibility" in the [.NET Package Servicing Model](https://github.com/dotnet/core/blob/main/Documentation/policies/package-servicing.md) states the policy.
- `NetCoreAppMinimum` in [`Directory.Build.props`](https://github.com/dotnet/runtime/blob/main/Directory.Build.props) of `dotnet/runtime` applies the policy. Each release branch sets the property to the oldest .NET version that release supports: `net10.0` in `release/11.0`, `net8.0` in `release/10.0` and in `release/9.0`.
- All five also have a build for .NET Standard 2.0 and one for .NET Framework 4.6.2. These serve the `netstandard` and .NET Framework target frameworks of this repository.

"Target frameworks" in `architecture.md` gives every release of this repository a target framework for each .NET version that Microsoft supports on the day of the release, and removes a target framework when Microsoft ends its support. The latest major version of each of the five supports the same .NET versions, so one pin serves every target framework that references the package.

### What "supports a target framework" means

A package of this family supports a target framework when a project with that target framework builds without this warning:

```text
<package> <version> doesn't support <target framework> and has not been tested with it.
```

A successful restore proves nothing. On a .NET version older than `NetCoreAppMinimum` the package restores through its `netstandard2.0` build, and the warning is the only sign that the target framework is not supported.

### The exception

A target framework for a .NET version that Microsoft no longer supports is the one case the latest major version can leave out. Such a target framework is due to leave the list, and it can still be there when the pins move. When the latest major version of a package gives that warning on such a target framework, the target framework gets its own `PackageVersion` item, with a condition on `TargetFramework` and the highest version that builds without the warning. Remove the item when the target framework is removed.

### Moving to a new major version

The default `minor` update policy keeps a pin within its major version, so the move to a new major version is made by hand. A patch release keeps the target frameworks of its major version, so the move is the only moment when support for a target framework can change.

### Which packages the policy covers

The policy covers the packages built from `src/libraries` in `dotnet/runtime`, and no others. The five pins above are the ones this repository references. The prefix of a package name does not tell whether the policy covers it: `Microsoft.Extensions.Http` is covered, `Microsoft.Extensions.Http.Resilience` is not.

Before adding a dependency whose version number is that of a .NET version, check whether the policy covers it. It does when both of these hold:

- The release branch of `dotnet/runtime` for the latest .NET version has the project `src/libraries/<package>/src/<package>.csproj`. For .NET 11 the folder is `https://github.com/dotnet/runtime/tree/release/11.0/src/libraries/<package>`.
- That project sets `IsPackable` to `true`.

The projects under [`src/libraries`](https://github.com/dotnet/runtime/tree/release/11.0/src/libraries) that set `IsPackable` to `true` are the complete list. When a new dependency is covered, add it to the pins named at the top of this section.

The policy does not cover these packages:

- `System.Memory` and `System.Threading.Tasks.Extensions`, the two other polyfills of `Louis`. They are built in `dotnet/maintenance-packages` and have version numbers of their own. The same holds for `System.Buffers`, `System.Runtime.CompilerServices.Unsafe`, and `Microsoft.Bcl.HashCode`.
- ASP.NET Core and Entity Framework Core packages. They have the version number of a .NET version, but each major version targets one .NET version: `Microsoft.EntityFrameworkCore` 11.0.0 targets `net11.0` only.
- `dotnet/extensions` packages, such as `Microsoft.Extensions.Http.Resilience`. They are serviced on their latest version only and choose their own target frameworks.

## Development dependencies

Buildvana SDK adds the analyzers to every project, so `Directory.Packages.props` pins no analyzer package. The .NET SDK bundles SourceLink, so `Common.targets` references no SourceLink package. `buildvana.jsonc` sets the `minor-` policy on `StyleCop.Analyzers`, the one SDK-injected package pinned to a prerelease line.

`PolySharp` is a development dependency of `Louis`. Its generated code is compiled into `Louis.dll`, so `THIRD-PARTY-NOTICES.md` carries its MIT notice.

## Test dependencies

The "Test dependencies" group of `Directory.Packages.props` pins `TUnit`, the test framework `testing.md` names. `TUnit` depends on `TUnit.Engine`, `TUnit.Assertions`, and `Microsoft.Testing.Extensions.CodeCoverage`, so the group pins nothing else. The `netstandard2.0` test projects reference `Microsoft.Bcl.AsyncInterfaces` and `Microsoft.Bcl.Memory` through their run-time pins, because the `netstandard2.0` build of `Louis` needs them and NuGet restore does not follow that build. "Every build of a package gets tested" in `testing.md` says why.

## The Buildvana family

`global.json` pins Buildvana SDK, and `dotnet-tools.json` pins `bv`, at one version. `dotnet bv self-update` moves both. Run it only when the maintainer asks.
