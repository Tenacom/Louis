# C# in this repository

This file is specific to this repository. Rewrite it when `.claude` is copied to another repository. `csharp-style-guide.md` holds the C# rules of every repository. This file holds the rules that differ here.

## Classic extension methods

A classic extension method is a static method whose first parameter carries the `this` modifier.

- Write every extension method of a project under `src/` as a classic extension method.
- Do not write an extension block in a project under `src/`, except for the case of "Static extension methods" below. Do not propose to convert an extension class to extension blocks.
- This rule overrides "Extension blocks" in `csharp-style-guide.md`, and the mention of extension blocks in "Modern C# features" there.
- The receiver parameter is still named `@this`, as in an extension block.
- "Extension classes" in `csharp-style-guide.md` still applies. Read "the extension methods for a type" where it says "extension block".
- An extension property is not available. Write a method instead.
- A test project has no API reference, so `csharp-style-guide.md` applies there unchanged.

### Static extension methods

A static extension method is a static method that an extension block adds to a type. `ArgumentException.ThrowNew(message)` is one.

- An extension block under `src/` declares static extension methods, and nothing else.
- The block names no receiver: `extension(ArgumentException)`.
- "Extension blocks" in `csharp-style-guide.md` applies to the class: the template with its two `#pragma` lines, and one block per class.
- The summary of each static extension method states the call form, in a sentence of its own: "Call this method as `ArgumentException.ThrowNew(...)`."
- Code that a source generator writes follows the same rules.

### Why

DefaultDocumentation writes the API reference from the assembly and its XML documentation file, as "Generated folders" in `rules/project/documentation.md` says. Version 1.2.6 does not know extension blocks and generates incorrect documentation for them.

Documentation integrity is important, so the extension methods stay classic.

A static extension method is the exception, because its page is complete. DefaultDocumentation shows it as a static method of the extension class, and names neither the extended type nor the call form. The sentence in the summary supplies both.

### When to revisit

Revisit the rule when a release of DefaultDocumentation supports extension blocks. To measure a release:

1. Convert one extension class to an extension block, and build.
2. Run the generator into a directory under `.claude/scratchpad/`, with the arguments of `RunGenerator` in `.buildvana/hooks/release/post-pack.cs`.
3. Compare the pages with the ones under `docs/api/`.

The rule goes away only when the comparison shows no defect, and Ric agrees.
