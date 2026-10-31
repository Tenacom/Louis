# Dependency management

This file is specific to this repository. Rewrite it when `.claude` is copied to another repository. `buildvana.md` holds the dependency rules that hold in every repository built with Buildvana.

## Run-time dependencies

Every consumer of a package inherits its run-time dependencies, so each one is a decision Ric takes, never a convenience.

- `Louis` depends on `CommunityToolkit.Diagnostics` and `PolyKit`, and on nothing else that every target framework gets. `System.Memory`, `System.Threading.Tasks.Extensions`, `Microsoft.Bcl.AsyncInterfaces`, and `System.ValueTuple` are polyfills, referenced only on the target frameworks that lack the types. "Target frameworks" in `architecture.md` says which.
- `Louis.Hosting` depends on `Microsoft.Extensions.Hosting.Abstractions` and `Microsoft.Extensions.Logging.Abstractions`. Both pins, and `Microsoft.Bcl.AsyncInterfaces`, stay on the lowest major version still in support, so that a consumer on an older host gets no forced upgrade. The `minor` update policy keeps them there. When Microsoft ends the support of that major, `dotnet bv deps update <id>... --latest` moves the three pins together.
- `Louis` is the library other Tenacom repositories rank alongside the BCL. Do not propose a dependency on another general-purpose utility library. Such a type gets written here instead.

## Development dependencies

Buildvana SDK adds the analyzers to every project, so `Directory.Packages.props` pins no analyzer package. The .NET SDK bundles SourceLink, so `Common.targets` references no SourceLink package. `buildvana.jsonc` sets the `minor-` policy on `StyleCop.Analyzers`, the one SDK-injected package pinned to a prerelease line.

## Test dependencies

The "Test dependencies" group of `Directory.Packages.props` is empty. `testing.md` says what the first test project gets: TUnit on Microsoft.Testing.Platform, with `Microsoft.Testing.Extensions.CodeCoverage`.

## The Buildvana family

`global.json` pins Buildvana SDK, and `dotnet-tools.json` pins `bv`, at one version. `dotnet bv self-update` moves both. Run it only when Ric asks.
