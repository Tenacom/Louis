# Documentation inventory

This file is specific to this repository. Rewrite it when `.claude` is copied to another repository. `rules/common/documentation.md` holds the rules. This file lists what they apply to here: the files, the page kinds, the subfolders of `docs/`, the generated regions, the API reference, and the pinned reference pages.

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

Besides the guide and the reference of `rules/common/documentation.md`, the repository has the article.

- An **article** is non-technical documentation, under `docs/articles/`. No article exists yet, and the first one creates the folder.

## Subfolders of `docs/`

- `articles/`, for articles, once the first one exists.

Every other page sits in `docs/` itself.

## Generated regions

None.

## API reference

The API reference is a site on GitHub Pages, as "Open source repositories" in `rules/common/documentation.md` says.

- The stable part is at `https://tenacom.github.io/Louis/`, and the preview part at `https://tenacom.github.io/Louis/preview/`. `Documentation.ApiReferencePreviewUrl` in `tools/ProjectFacts.cs` holds the second URL.
- Under the URL of a part, the page of a type is `api/<namespace>.<type>.html`, such as `api/Louis.Text.StringExtensions.html`. A generic type has its arity after a hyphen, as in `api/Louis.Fluency.FluentAction-1.html`.
- The page of a namespace is `api/namespaces/<namespace>.html`. The page of a package is `api/packages/<package id>.html`, with the package id in lowercase.
- A type has one page for every build of its package. A member that only some builds have shows its target frameworks, and its XML comment still names the builds that lack it, as "Target frameworks" in `architecture.md` requires.
- A namespace has one page for every package. `Louis` and `Louis.Testing` both declare types in `Louis.Processes`, and the page of that namespace lists the types of both, with the package of each.
- The workflow `docs.yml` builds both parts and deploys the site. `release.yml` calls it after `bv release`.
- The `pack` job of `ci.yml` runs the generator on the packages it built, with every warning as an error. A defect of an XML comment therefore fails the checks of a pull request.
- The hook `.buildvana/hooks/release/post-pack.cs` rewrites the links to the preview part, in the new section of `CHANGELOG.md`, at a stable release.

The entry pages are the namespace pages, and `docs/README.md` links each one in the preview part. A namespace page has no summary, so the line of `docs/README.md` is the one description of a namespace.

A change that adds a namespace, or changes what a namespace holds, adds or changes the line of the namespace in `docs/README.md`. The line does not wait for the release that publishes the page, and no check reports a missing line.

## Pinned reference pages

None. No page under `docs/` lists a code surface, and the API reference comes from the code itself.
