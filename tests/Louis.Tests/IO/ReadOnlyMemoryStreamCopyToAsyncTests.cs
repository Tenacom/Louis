// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.IO;
using TUnit.Assertions.Enums;

// A test that does not await the task of CopyToAsync has one that throws, or one that is complete when CopyToAsync returns.
#pragma warning disable CA2025 // Ensure tasks using 'IDisposable' instances complete before the instances are disposed
internal sealed class ReadOnlyMemoryStreamCopyToAsyncTests
{
    private static readonly byte[] Data = [1, 2, 3, 4, 5];

    [Test]
    public async Task CopyToAsync_WithNullDestination_ThrowsArgumentNullException()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        // ! Null on purpose: testing null detection
        void Act() => _ = stream.CopyToAsync(null!, 1, CancellationToken.None);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("destination");
    }

    [Test]
    [Arguments(0)]
    [Arguments(-1)]
    public async Task CopyToAsync_WithNonPositiveBufferSize_ThrowsArgumentOutOfRangeException(int bufferSize)
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        using var destination = new MemoryStream();

        void Act() => _ = stream.CopyToAsync(destination, bufferSize, CancellationToken.None);

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName("bufferSize");
    }

    [Test]
    public async Task CopyToAsync_WithReadOnlyDestination_ThrowsNotSupportedException()
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        using var destination = new ReadOnlyMemoryStream(ReadOnlyMemory<byte>.Empty);

        void Act() => _ = stream.CopyToAsync(destination, 1, CancellationToken.None);

        await Assert.That(Act).Throws<NotSupportedException>();
    }

    [Test]
    public async Task CopyToAsync_WithClosedDestination_ThrowsObjectDisposedException()
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        var destination = new MemoryStream();
        destination.Close();

        void Act() => _ = stream.CopyToAsync(destination, 1, CancellationToken.None);

        await Assert.That(Act).Throws<ObjectDisposedException>();
    }

    [Test]
    public async Task CopyToAsync_OnClosedStream_ThrowsObjectDisposedException()
    {
        var stream = new ReadOnlyMemoryStream(Data);
        stream.Close();
        using var destination = new MemoryStream();

        void Act() => _ = stream.CopyToAsync(destination, 1, CancellationToken.None);

        await Assert.That(Act).Throws<ObjectDisposedException>();
    }

    [Test]
    public async Task CopyToAsync_WithCanceledToken_ReturnsCanceledTask()
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        using var destination = new MemoryStream();

        var task = stream.CopyToAsync(destination, 1, new CancellationToken(canceled: true));

        await Assert.That(task.IsCanceled).IsTrue();
    }

    [Test]
    public async Task CopyToAsync_CopiesBytesFromPositionAndMovesToEnd()
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        stream.Position = 2;
        using var destination = new MemoryStream();
        byte[] expected = [3, 4, 5];

        await stream.CopyToAsync(destination, 1, CancellationToken.None);

        await Assert.That(destination.ToArray()).IsEquivalentTo(expected, CollectionOrdering.Matching);
        await Assert.That(stream.Position).IsEqualTo(5);
    }

    [Test]
    [Arguments(5)]
    [Arguments(7)]
    public async Task CopyToAsync_AtEnd_CopiesNothing(int position)
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        stream.Position = position;
        using var destination = new MemoryStream();

        await stream.CopyToAsync(destination, 1, CancellationToken.None);

        await Assert.That(destination.Length).IsEqualTo(0);
        await Assert.That(stream.Position).IsEqualTo(position);
    }

    [Test]
    public async Task CopyToAsync_WhenDestinationWriteThrows_ReturnsFaultedTask()
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        using var destination = new MemoryStream(new byte[2]);

        var task = stream.CopyToAsync(destination, 1, CancellationToken.None);

        await Assert.That(task.IsFaulted).IsTrue();
        await Assert.That(async () => await task).Throws<NotSupportedException>();
    }

    [Test]
    public async Task CopyToAsync_WithNonMemoryStreamDestination_CopiesBytesInOneWrite()
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        stream.Position = 2;
        using var destination = new RecordingStream();
        byte[] expected = [3, 4, 5];

        await stream.CopyToAsync(destination, 1, CancellationToken.None);

        await Assert.That(destination.WrittenBytes).IsEquivalentTo(expected, CollectionOrdering.Matching);
        await Assert.That(destination.WriteCallCount).IsEqualTo(1);
        await Assert.That(stream.Position).IsEqualTo(5);
    }

    [Test]
    public async Task CopyToAsync_WithoutBackingArray_CopiesBytesFromPosition()
    {
        using var manager = new ArrayMemoryManager(Data);
        using var stream = new ReadOnlyMemoryStream(manager.Memory);
        stream.Position = 2;
        using var destination = new MemoryStream();
        byte[] expected = [3, 4, 5];

        await stream.CopyToAsync(destination, 1, CancellationToken.None);

        await Assert.That(destination.ToArray()).IsEquivalentTo(expected, CollectionOrdering.Matching);
        await Assert.That(stream.Position).IsEqualTo(5);
    }

    [Test]
    public async Task CopyToAsync_WithoutBackingArrayAndNonMemoryStreamDestination_CopiesBytesInOneWrite()
    {
        using var manager = new ArrayMemoryManager(Data);
        using var stream = new ReadOnlyMemoryStream(manager.Memory);
        stream.Position = 2;
        using var destination = new RecordingStream();
        byte[] expected = [3, 4, 5];

        await stream.CopyToAsync(destination, 1, CancellationToken.None);

        await Assert.That(destination.WrittenBytes).IsEquivalentTo(expected, CollectionOrdering.Matching);
        await Assert.That(destination.WriteCallCount).IsEqualTo(1);
        await Assert.That(stream.Position).IsEqualTo(5);
    }
}
