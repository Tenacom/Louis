// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

/// <summary>
/// Owns a temporary directory, and the path of one file in it. The file exists only when the test gives its content.
/// The disposal deletes the directory, with everything the test wrote in it.
/// </summary>
internal sealed class TemporaryFile : IDisposable
{
    public TemporaryFile(byte[]? content = null)
    {
        DirectoryPath = Path.Combine(Path.GetTempPath(), $"louis-tests-{Guid.NewGuid():N}");
        FilePath = Path.Combine(DirectoryPath, "file.txt");
        _ = Directory.CreateDirectory(DirectoryPath);
        if (content is not null)
        {
            File.WriteAllBytes(FilePath, content);
        }
    }

    public string DirectoryPath { get; }

    public string FilePath { get; }

    public bool Exists => File.Exists(FilePath);

    public DateTime LastWriteTimeUtc
    {
        get => File.GetLastWriteTimeUtc(FilePath);
        set => File.SetLastWriteTimeUtc(FilePath, value);
    }

    public byte[] ReadAllBytes() => File.ReadAllBytes(FilePath);

    public void Dispose() => Directory.Delete(DirectoryPath, recursive: true);
}
