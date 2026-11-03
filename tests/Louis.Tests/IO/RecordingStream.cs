// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

/// <summary>
/// A write-only <see cref="Stream"/> that is not a <see cref="MemoryStream"/>.
/// It records the bytes written to it and counts the write calls.
/// </summary>
// The memory-based WriteAsync of Stream calls the array-based override, which records the write.
#pragma warning disable CA1844 // Provide memory-based overrides of async methods when subclassing 'Stream'
internal sealed class RecordingStream : Stream
{
    private readonly List<byte> _writtenBytes = [];

    public int WriteCallCount { get; private set; }

    public byte[] WrittenBytes => [.. _writtenBytes];

    public override bool CanRead => false;

    public override bool CanSeek => false;

    public override bool CanWrite => true;

    public override long Length => throw new NotSupportedException();

    public override long Position
    {
        get => throw new NotSupportedException();
        set => throw new NotSupportedException();
    }

    public override void Flush()
    {
    }

    public override int Read(byte[] buffer, int offset, int count) => throw new NotSupportedException();

    public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

    public override void SetLength(long value) => throw new NotSupportedException();

    public override void Write(byte[] buffer, int offset, int count)
    {
        WriteCallCount++;
        _writtenBytes.AddRange(new ArraySegment<byte>(buffer, offset, count));
    }

    public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
        Write(buffer, offset, count);
        return Task.CompletedTask;
    }
}
