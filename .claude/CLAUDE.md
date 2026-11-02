# L.o.U.I.S.

This is L.o.U.I.S. (Lots of Useful and Interesting Stuff), a collection of useful types commonly needed in the development of .NET libraries and applications.
We refer to L.o.U.I.S. as Louis in conversations and where an identifier is needed.
See `.claude/rules/` for project instructions.

## Repository

- Upstream: `Tenacom/Louis`. Issues, PRs, and releases live there. It is the default target of `gh` calls.
- PR branches go to the contributor's own fork, the `origin` remote. Run `git remote -v` once per session when you need its name. Do not assume it.

## Rules index

The `.claude` directory is meant to be copied whole into other projects. This index says what survives the copy unchanged and what has to be rewritten on arrival. Each Markdown file under `.claude` says the same of itself in its first paragraph, so that the information survives a copy without this index.

### Portable: copy verbatim

- `rules/common/workflow.md`: how Ric and I work together: issues, PRs, the self-review cycle, sanity checks, out-of-scope fixes, commit messages.
- `rules/common/session.md`: scratchpad and handoff rules, for every session, with or without an issue.
- `rules/common/design-principles.md`: scope, abstraction completeness, portability, conformance with the surrounding toolchain, LLM-automation stance.
- `rules/common/csharp-style-guide.md`: C# style beyond what `.editorconfig` and `.globalconfig` can express.
- `rules/common/dependency-injection.md`: disposability as an implementation detail, and when a service gets a contract.
- `rules/common/file-formats.md`: encoding, indentation, and per-format conventions.
- `rules/common/powershell.md`: Windows PowerShell 5.1 pitfalls and shell-usage rules.
- `rules/common/testing.md`: test framework, MTP-only orchestration, coverage exclusion policy, cross-platform test rules.
- `rules/common/buildvana.md`: build commands, dependency commands, and the Buildvana documentation. Assumes the project is built with Buildvana.
- `rules/common/dotnet.md`: efficiency rules for .NET tooling, and how to inspect a third-party package.
- `rules/common/documentation.md`: what counts as user documentation, the register, the structure of `docs/`, the changelog bullet format, and the checks. The names it relies on are in `rules/project/terminology.md`, and the inventory it applies to is in `rules/project/architecture.md`.
- `skills/review-pr/SKILL.md`: how a PR is reviewed and how the review is posted. Run it with `/review-pr <N>`. Its "What the gate and CI already cover" section names `inspect.cs` and the workflows under `.github/workflows/`, and a copy names its own checks there.
- `agents/pr-reviewer.md`: the subagent that runs the skill for the self-review cycle. Nothing repo-specific in it.
- `output-styles/simple-tech.md`: the register for every kind of prose, from chat to commit messages. Select it with `/output-style`.
- `tools/Common.props`: build options for the tools. It turns off the StyleCop rules that a single-file app cannot follow, SA1636 included, so that a tool keeps its header whatever copyright text the repository sets.
- `tools/inspect.cs`: the sanity-check gate. It finds the solution file in the home directory by itself.
- `tools/lint-commit.cs`: commit-message check, run on the draft before every commit. Its `bannedWords` and `announcingVerbs` arrays come from past commits of the repository the tool was written in. They apply anywhere, and a copy may extend them.
- `tools/lint-docs.cs`: documentation check, the first phase of `inspect.cs`. Its `fenceTags` array is the list in `rules/common/documentation.md`. Its `todoExemptFiles` and `sentenceExemptFiles` arrays hold globs. The first is empty here, and the second holds the non-technical documentation that `rules/common/documentation.md` lists. A copy may add globs to either. Its `generatedFolders` array names `docs/api`, the generated folder of `rules/project/architecture.md`, and a copy names its own.
- `scratchpad/`: scratch directory for temporary files, commit messages included. Its `Common.props` turns StyleCop and code style enforcement off for scratch code, and states every property it relies on. Everything else in the directory is gitignored.
- `settings.json`: the output style and the tool permissions that apply before the classifier. Nothing repo-specific in it.
- `.gitignore`: keeps `settings.local.json`, `worktrees/`, `agent-memory-local/`, `handoff/`, and the contents of `scratchpad/` out of git. Nothing repo-specific in it.

### Project-specific: rewrite when copied

- `rules/project/architecture.md`: the packages, the namespaces of `Louis`, the target frameworks and the `#if` policy, the public API file layout, and the documentation inventory: files, subfolders of `docs/`, generated regions. Entirely about this repo.
- `rules/project/dependency-management.md`: the run-time dependencies of each package and the reason each is allowed, the polyfill packages, and the test and development dependency groups. The common part is in `rules/common/buildvana.md`.
- `rules/project/terminology.md`: the one name for each thing the repository documents. Entirely about this repo.
- `rules/project/pr-checks.md`: the checks of a pull request whose failure does not stop a review. The Codecov section applies to any repository whose CI uploads to Codecov, and a copy adds its own checks.
- this file: repository coordinates, and the index itself.
