# Dependency management

This file is specific to this repository. Rewrite it when `.claude` is copied to another repository. `buildvana.md` holds the dependency rules that hold in every repository built with Buildvana.

## Run-time dependencies

Every consumer of a package inherits its run-time dependencies, so each one is a decision the maintainer takes, never a convenience.

- `Louis` depends on `CommunityToolkit.Diagnostics`, and on nothing else that every target framework gets. `System.Memory`, `System.Threading.Tasks.Extensions`, `Microsoft.Bcl.AsyncInterfaces`, `Microsoft.Bcl.Memory`, and `System.Text.Encoding.CodePages` are polyfills, referenced only on the target frameworks that lack the types. "Target frameworks" in `architecture.md` says which.
- `Louis.Hosting` depends on `Microsoft.Extensions.Hosting.Abstractions` and `Microsoft.Extensions.Logging.Abstractions`.
- Five pins name packages that Microsoft releases with each major version of .NET: `Microsoft.Bcl.AsyncInterfaces`, `Microsoft.Bcl.Memory`, `Microsoft.Extensions.Hosting.Abstractions`, `Microsoft.Extensions.Logging.Abstractions`, and `System.Text.Encoding.CodePages`. Each target framework that references one of the five packages gets the highest version that supports that target framework. When the highest version of a package supports every target framework that references it, the pin is one `PackageVersion` item. When it does not, each target framework it leaves out gets its own `PackageVersion` item, with a condition on `TargetFramework` and the highest version that supports that target framework. The default `minor` update policy keeps a pin within its major version, so a move to a new major version is made by hand.
- `Louis.Testing` depends on `Louis`, and on nothing else, so that a test project gets no test framework by referencing it.
- `Louis` is the library other Tenacom repositories rank alongside the BCL. Do not propose a dependency on another general-purpose utility library. Such a type gets written here instead.

## Development dependencies

Buildvana SDK adds the analyzers to every project, so `Directory.Packages.props` pins no analyzer package. The .NET SDK bundles SourceLink, so `Common.targets` references no SourceLink package. `buildvana.jsonc` sets the `minor-` policy on `StyleCop.Analyzers`, the one SDK-injected package pinned to a prerelease line.

`PolySharp` is a development dependency of `Louis`. Its generated code is compiled into `Louis.dll`, so `THIRD-PARTY-NOTICES.md` carries its MIT notice.

## Test dependencies

The "Test dependencies" group of `Directory.Packages.props` pins `TUnit`, the test framework `testing.md` names. `TUnit` depends on `TUnit.Engine`, `TUnit.Assertions`, and `Microsoft.Testing.Extensions.CodeCoverage`, so the group pins nothing else. The `netstandard2.0` test projects reference `Microsoft.Bcl.AsyncInterfaces` and `Microsoft.Bcl.Memory` through their run-time pins, because the `netstandard2.0` build of `Louis` needs them and NuGet restore does not follow that build. "Every build of a package gets tested" in `testing.md` says why.

## The Buildvana family

`global.json` pins Buildvana SDK, and `dotnet-tools.json` pins `bv`, at one version. `dotnet bv self-update` moves both. Run it only when the maintainer asks.
