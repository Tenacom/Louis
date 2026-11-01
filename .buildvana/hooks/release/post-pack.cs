// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

/*
 * release/post-pack hook: generates the API documentation of the libraries of the solution,
 * under `docs/api/<AssemblyName>/`, with DefaultDocumentation.
 * `bv release` runs the hook after packing, and the pages it writes join the release commit,
 * so that the pages on `main` describe the released code.
 *
 * A library is a project whose output type is `Library` and that is not a test project.
 * `DocumentPackableOnly`, below, restricts the hook to the packable ones.
 * A library without an XML documentation file is skipped,
 * because `GenerateDocumentationFile` is off on purpose there.
 *
 * The generator is the local tool `defaultdocumentation`, pinned in `dotnet-tools.json`.
 * It runs once per library, as a child process, on the assembly and the XML documentation file
 * of one target framework: the newest `net` one, else the newest `.NET Framework` one,
 * else the newest `netstandard` one.
 * A `netstandard` build may lack members that the other builds have, and the XML comment
 * of a framework-specific member says which frameworks get it.
 * The pages of a library are flat: an `index.md` for the assembly, a page per namespace,
 * and a page per type with its members.
 * The generator deletes the stale pages of its output directory itself,
 * and the hook deletes the directory of a library the solution no longer has.
 *
 * A library that references another documented library gets its pages after it.
 * Each run writes a links file to the scratch directory of `bv`,
 * and every later run reads the links files written so far,
 * so that a `cref` to a type of the referenced library links to its page,
 * through a path relative to the sibling directory.
 *
 * To replay the hook by hand, after a `bv release` run or against an args file written by hand:
 *   `dotnet run .buildvana/hooks/release/post-pack.cs`
 */

#:package Buildvana.Runtime

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;
using Buildvana.Runtime;

// Whether the hook documents the packable libraries alone.
// An application solution sets this to false, so that its own libraries get pages too.
const bool DocumentPackableOnly = true;

const string ApiDirectory = "docs/api";
const string LinksDirectoryName = "api-links";

var hookArgs = PostPackHookArgs.Load();

var libraries = new List<DocumentedLibrary>();
foreach (var project in hookArgs.Solution.Projects)
{
    if (DocumentPackableOnly && project.IsPackable != true)
    {
        continue;
    }

    var targetFramework = SelectTargetFramework(project.TargetFrameworks);
    if (targetFramework is not { OutputType: "Library", IsTestProject: false, DocumentationFile: { } documentationFile })
    {
        continue;
    }

    libraries.Add(new(targetFramework.TargetPath, documentationFile));
}

DeleteStaleDirectories(ApiDirectory, libraries.Select(library => library.AssemblyName));

var linksDirectory = Path.Combine(hookArgs.RuntimeInfo.ScratchDirectory, LinksDirectoryName);
if (Directory.Exists(linksDirectory))
{
    Directory.Delete(linksDirectory, recursive: true);
}

Directory.CreateDirectory(linksDirectory);

foreach (var library in OrderByReferences(libraries))
{
    Console.Error.WriteLine($"Generating the documentation of {library.AssemblyName}...");
    var exitCode = RunGenerator(library, Path.Combine(ApiDirectory, library.AssemblyName), linksDirectory);
    if (exitCode != 0)
    {
        Console.Error.WriteLine($"defaultdocumentation exited with code {exitCode} on {library.AssemblyName}.");
        return 1;
    }
}

return 0;

// The target framework whose build gets documented. In order of preference:
//   - `net<major>.<minor>`, with or without a platform suffix;
//   - `net4<minor>[<build>]`;
//   - `netstandard<major>.<minor>`.
// Within a rank, the newest version wins.
// A moniker of another shape is never selected.
static TargetFrameworkInfo? SelectTargetFramework(IReadOnlyList<TargetFrameworkInfo> targetFrameworks)
{
    TargetFrameworkInfo? selected = null;
    var selectedRank = (Tier: 0, Version: new Version(0, 0));
    foreach (var targetFramework in targetFrameworks)
    {
        var rank = GetRank(targetFramework.TargetFramework);
        if (rank is { } value && value.CompareTo(selectedRank) > 0)
        {
            selected = targetFramework;
            selectedRank = value;
        }
    }

    return selected;
}

static (int Tier, Version Version)? GetRank(string targetFramework)
{
    var match = Regex.Match(targetFramework, @"^net(\d+\.\d+)(-\w+)?$");
    if (match.Success)
    {
        return (3, Version.Parse(match.Groups[1].Value));
    }

    match = Regex.Match(targetFramework, @"^net(\d)(\d)(\d)?$");
    if (match.Success)
    {
        var digits = match.Groups.Cast<Group>().Skip(1).Where(group => group.Success).Select(group => group.Value);
        return (2, Version.Parse(string.Join('.', digits)));
    }

    match = Regex.Match(targetFramework, @"^netstandard(\d+\.\d+)$");
    return match.Success ? (1, Version.Parse(match.Groups[1].Value)) : null;
}

static void DeleteStaleDirectories(string apiDirectory, IEnumerable<string> assemblyNames)
{
    if (!Directory.Exists(apiDirectory))
    {
        return;
    }

    var keep = new HashSet<string>(assemblyNames, StringComparer.OrdinalIgnoreCase);
    foreach (var directory in Directory.GetDirectories(apiDirectory))
    {
        if (!keep.Contains(Path.GetFileName(directory)))
        {
            Directory.Delete(directory, recursive: true);
        }
    }
}

// A library comes after every documented library its assembly references.
// Assembly references form no cycle, so the visit always ends.
static IReadOnlyList<DocumentedLibrary> OrderByReferences(IReadOnlyList<DocumentedLibrary> libraries)
{
    var byAssemblyName = libraries.ToDictionary(library => library.AssemblyName, StringComparer.OrdinalIgnoreCase);
    var ordered = new List<DocumentedLibrary>();
    foreach (var library in libraries)
    {
        Visit(library);
    }

    return ordered;

    void Visit(DocumentedLibrary library)
    {
        if (ordered.Contains(library))
        {
            return;
        }

        foreach (var referencedName in GetReferencedAssemblyNames(library.AssemblyPath))
        {
            if (byAssemblyName.TryGetValue(referencedName, out var referenced))
            {
                Visit(referenced);
            }
        }

        ordered.Add(library);
    }
}

static IReadOnlyList<string> GetReferencedAssemblyNames(string assemblyPath)
{
    using var stream = File.OpenRead(assemblyPath);
    using var peReader = new PEReader(stream);
    var metadata = peReader.GetMetadataReader();
    return [.. metadata.AssemblyReferences.Select(handle => metadata.GetString(metadata.GetAssemblyReference(handle).Name))];
}

static int RunGenerator(DocumentedLibrary library, string outputDirectory, string linksDirectory)
{
    var startInfo = new ProcessStartInfo("dotnet")
    {
        UseShellExecute = false,
    };

    // - `Api` documents the public and protected members alone.
    // - A page per namespace and per type, with the members inlined in the page of their type:
    //   a page per member would be named after the full signature of the member, and such a path
    //   exceeds the 260 characters Windows allows by default.
    // - `index` names the assembly page of every library, whatever its number of namespaces.
    // - The links file states its URLs relative to the sibling directory of the library,
    //   which is where the pages of another library read them.
    string[] arguments =
    [
        "defaultdocumentation",
        "--LogLevel", "Warning",
        "--AssemblyFilePath", library.AssemblyPath,
        "--DocumentationFilePath", library.DocumentationFilePath,
        "--OutputDirectoryPath", outputDirectory,
        "--GeneratedAccessModifiers", "Api",
        "--GeneratedPages", "Namespaces,Types",
        "--AssemblyPageName", "index",
        "--LinksOutputFilePath", Path.Combine(linksDirectory, library.AssemblyName),
        "--LinksBaseUrl", $"../{library.AssemblyName}/",
        "--ExternLinksFilePaths", Path.Combine(linksDirectory, "*"),
    ];

    foreach (var argument in arguments)
    {
        startInfo.ArgumentList.Add(argument);
    }

    using var process = Process.Start(startInfo);
    if (process is null)
    {
        Console.Error.WriteLine("Could not start dotnet.");
        return 1;
    }

    process.WaitForExit();
    return process.ExitCode;
}

internal sealed record DocumentedLibrary(string AssemblyPath, string DocumentationFilePath)
{
    public string AssemblyName => Path.GetFileNameWithoutExtension(AssemblyPath);
}
