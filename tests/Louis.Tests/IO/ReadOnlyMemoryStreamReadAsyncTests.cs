// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.IO;
using TUnit.Assertions.Enums;

#pragma warning disable CA1835 // Prefer the memory-based overloads of ReadAsync - the array-based overload is a method under test
internal sealed class ReadOnlyMemoryStreamReadAsyncTests
{
    private static readonly byte[] Data = [1, 2, 3, 4, 5];

    [Test]
    public async Task ReadAsync_WithNullArray_ThrowsArgumentNullException()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        // ! Null on purpose: testing null detection
        void Act() => _ = stream.ReadAsync(null!, 0, 1, CancellationToken.None);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("buffer");
    }

    [Test]
    public async Task ReadAsync_WithNegativeOffset_ThrowsArgumentOutOfRangeException()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        void Act() => _ = stream.ReadAsync(new byte[5], -1, 1, CancellationToken.None);

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName("offset");
    }

    [Test]
    [Arguments(0, -1)]
    [Arguments(0, 6)]
    [Arguments(3, 3)]
    public async Task ReadAsync_WithCountOutsideArray_ThrowsArgumentOutOfRangeException(int offset, int count)
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        void Act() => _ = stream.ReadAsync(new byte[5], offset, count, CancellationToken.None);

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName("count");
    }

    [Test]
    public async Task ReadAsync_WithArray_OnClosedStream_ThrowsObjectDisposedException()
    {
        var stream = new ReadOnlyMemoryStream(Data);
        stream.Close();

        void Act() => _ = stream.ReadAsync(new byte[5], 0, 5, CancellationToken.None);

        await Assert.That(Act).Throws<ObjectDisposedException>();
    }

    [Test]
    public async Task ReadAsync_WithArray_WithCanceledToken_ReturnsCanceledTask()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        var task = stream.ReadAsync(new byte[5], 0, 5, new CancellationToken(canceled: true));

        await Assert.That(task.IsCanceled).IsTrue();
    }

    [Test]
    [Arguments(0, 3, new byte[] { 1, 2, 3 })]
    [Arguments(0, 5, new byte[] { 1, 2, 3, 4, 5 })]
    [Arguments(3, 5, new byte[] { 4, 5 })]
    [Arguments(5, 3, new byte[0])]
    [Arguments(7, 3, new byte[0])]
    public async Task ReadAsync_WithArray_ReadsAvailableBytes(int position, int count, byte[] expected)
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        stream.Position = position;
        var buffer = new byte[count];

        var read = await stream.ReadAsync(buffer, 0, count, CancellationToken.None);

        await Assert.That(read).IsEqualTo(expected.Length);
        await Assert.That(buffer.Take(read)).IsEquivalentTo(expected, CollectionOrdering.Matching);
        await Assert.That(stream.Position).IsEqualTo(position + expected.Length);
    }

    [Test]
    public async Task ReadAsync_WithArray_ReadsUntilEnd()
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        var buffer = new byte[2];
        var counts = new List<int>();

        int read;
        do
        {
            read = await stream.ReadAsync(buffer, 0, 2, CancellationToken.None);
            counts.Add(read);
        }
        while (read > 0);

        await Assert.That(counts).IsEquivalentTo([2, 2, 1, 0], CollectionOrdering.Matching);
        await Assert.That(stream.Position).IsEqualTo(5);
    }

    [Test]
    public async Task ReadAsync_WithMemory_OnClosedStream_ThrowsObjectDisposedException()
    {
        var stream = new ReadOnlyMemoryStream(Data);
        stream.Close();

        void Act() => _ = stream.ReadAsync(new byte[5].AsMemory(), CancellationToken.None).AsTask();

        await Assert.That(Act).Throws<ObjectDisposedException>();
    }

    [Test]
    public async Task ReadAsync_WithMemory_WithCanceledToken_ReturnsCanceledTask()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        var task = stream.ReadAsync(new byte[5].AsMemory(), new CancellationToken(canceled: true));

        await Assert.That(task.IsCanceled).IsTrue();
    }

    [Test]
    [Arguments(0, 3, new byte[] { 1, 2, 3 })]
    [Arguments(0, 5, new byte[] { 1, 2, 3, 4, 5 })]
    [Arguments(3, 5, new byte[] { 4, 5 })]
    [Arguments(5, 3, new byte[0])]
    [Arguments(7, 3, new byte[0])]
    [Arguments(0, 0, new byte[0])]
    public async Task ReadAsync_WithMemory_ReadsAvailableBytes(int position, int length, byte[] expected)
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        stream.Position = position;
        var buffer = new byte[length];

        var read = await stream.ReadAsync(buffer.AsMemory(), CancellationToken.None);

        await Assert.That(read).IsEqualTo(expected.Length);
        await Assert.That(buffer.Take(read)).IsEquivalentTo(expected, CollectionOrdering.Matching);
        await Assert.That(stream.Position).IsEqualTo(position + expected.Length);
    }

    [Test]
    public async Task ReadAsync_WithMemory_ReadsUntilEnd()
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        var buffer = new byte[2];
        var counts = new List<int>();

        int read;
        do
        {
            read = await stream.ReadAsync(buffer.AsMemory(), CancellationToken.None);
            counts.Add(read);
        }
        while (read > 0);

        await Assert.That(counts).IsEquivalentTo([2, 2, 1, 0], CollectionOrdering.Matching);
        await Assert.That(stream.Position).IsEqualTo(5);
    }
}
