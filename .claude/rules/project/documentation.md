# Documentation inventory

This file is specific to this repository. Rewrite it when `.claude` is copied to another repository. `rules/common/documentation.md` holds the rules. This file lists what they apply to here: the files, the informal documents, the page kinds, the subfolders of `docs/`, the generated regions, the published documentation, and the pinned reference pages.

## Files

The following are documentation:

- `README.md`
- `CHANGELOG.md`
- `docs/`, which the documentation site renders
- `graphics/README.md`
- `src/<project>/NuGet-README.md`

The following are not documentation:

- `THIRD-PARTY-NOTICES.md` holds the copyright notices of code dependencies;
- `THIRD-PARTY-GRAPHICS.md` holds the copyright notices of the graphic elements in `graphics/`.

## Informal documents

None, beyond the `README.md` and `NuGet-README.md` files, which are informal documents in every repository. `docs/index.md`, the home page of the documentation site, follows the default register.

## Page kinds

None, beyond the guide and the reference of `rules/common/documentation.md`.

## Subfolders of `docs/`

None. Every page sits in `docs/` itself.

## Generated regions

None.

## Published documentation

The repository has a documentation site on GitHub Pages, with an API reference of every package. "Published documentation" in `rules/common/documentation.md` describes the site.

- The stable part is at `https://tenacom.github.io/Louis/`, and the preview part at `https://tenacom.github.io/Louis/preview/`. `Documentation.SiteUrl` in `tools/ProjectFacts.cs` holds the first URL.
- Under the URL of a part, the page of a type is `api/<namespace>.<type>.html`, such as `api/Louis.Text.StringExtensions.html`. A generic type has its arity after a hyphen, as in `api/Louis.Fluency.FluentAction-1.html`.
- The page of a namespace is `api/namespaces/<namespace>.html`. The page of a package is `api/packages/<package id>.html`, with the package id in lowercase.
- A type has one page for every build of its package. A member that only some builds have shows its target frameworks, and its XML comment still names the builds that lack it, as "Target frameworks" in `architecture.md` requires.
- A namespace has one page for every package. `Louis` and `Louis.Testing` both declare types in `Louis.Processes`, and the page of that namespace lists the types of both, with the package of each.
- The workflow `docs.yml` builds both parts and deploys the site. The `docs` job of `release.yml` calls it after `bv release`.
- The `pack` job of `ci.yml` runs the generator on the packages it built, with every warning as an error. A defect of an XML comment, or of a page under `docs/`, therefore fails the checks of a pull request.

## Pinned reference pages

`docs/diagnostics.md` lists the diagnostics of the analyzers in `src/Louis.Generators`. `DiagnosticsPageTests`, in `tests/Louis.Generators.Tests`, compares the table and the sections of the page with the descriptors of the analyzers. The help link of each diagnostic names its section of that page, in the preview part of the documentation site.

No other page under `docs/` lists a code surface, and the API reference comes from the code itself.
