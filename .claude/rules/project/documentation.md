# Documentation inventory

This file is specific to this repository. Rewrite it when `.claude` is copied to another repository. `rules/common/documentation.md` holds the rules. This file lists what they apply to here: the files, the page kinds, the subfolders of `docs/`, the generated regions, the generated folders, and the pinned reference pages.

## Files

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

## Page kinds

Besides the guide and the reference of `rules/common/documentation.md`, the repository has two page kinds.

- An **API reference page** documents one assembly, one namespace, or one type with its members. DefaultDocumentation writes it, under the generated folder below, and no rule of the page template applies to it. A fix goes in the XML comment the page comes from.
- An **article** is non-technical documentation, under `docs/articles/`. No article exists yet, and the first one creates the folder.

## Subfolders of `docs/`

- `api/`, the generated folder below.
- `articles/`, for articles, once the first one exists.

Every hand-written page sits in `docs/` itself.

## Generated regions

None.

## Generated folders

`docs/api/<AssemblyName>/` holds the API reference of each package, flat: `README.md` for the assembly, which GitHub renders in the directory view, a page per namespace, and a page per type with its members. The hook `.buildvana/hooks/release/post-pack.cs` writes it with DefaultDocumentation at every release, prereleases included, so the pages on `main` describe the latest release. The hook reads the assembly and the XML documentation file of one target framework, the newest `net<major>.<minor>` one. A `netstandard` build may lack a member the pages hold, and the XML comment of the member says so, as "Target frameworks" in `architecture.md` requires.

The summary of a namespace page comes from the `NamespaceDoc` class of the namespace, and the summary of `README.md` from the `AssemblyDoc` class of the package. Both are `internal static`, and a new namespace gets its `NamespaceDoc` class in the same change. The entry pages are the namespace pages, and `docs/README.md` links each one.

## Pinned reference pages

None. No hand-written page lists a code surface, and an API reference page comes from the code itself.
