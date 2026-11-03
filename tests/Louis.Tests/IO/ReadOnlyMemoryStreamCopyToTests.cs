// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.IO;
using TUnit.Assertions.Enums;

#pragma warning disable CA1849 // Call async methods when in an async method - the synchronous CopyTo is the method under test
internal sealed class ReadOnlyMemoryStreamCopyToTests
{
    private static readonly byte[] Data = [1, 2, 3, 4, 5];

    [Test]
    public async Task CopyTo_WithNullDestination_ThrowsArgumentNullException()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        // ! Null on purpose: testing null detection
        void Act() => stream.CopyTo(null!, 1);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("destination");
    }

    [Test]
    [Arguments(0)]
    [Arguments(-1)]
    public async Task CopyTo_WithNonPositiveBufferSize_ThrowsArgumentOutOfRangeException(int bufferSize)
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        using var destination = new MemoryStream();

        void Act() => stream.CopyTo(destination, bufferSize);

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName("bufferSize");
    }

    [Test]
    public async Task CopyTo_WithReadOnlyDestination_ThrowsNotSupportedException()
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        using var destination = new ReadOnlyMemoryStream(ReadOnlyMemory<byte>.Empty);

        void Act() => stream.CopyTo(destination, 1);

        await Assert.That(Act).Throws<NotSupportedException>();
    }

    [Test]
    public async Task CopyTo_WithClosedDestination_ThrowsObjectDisposedException()
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        var destination = new MemoryStream();
        destination.Close();

        void Act() => stream.CopyTo(destination, 1);

        await Assert.That(Act).Throws<ObjectDisposedException>();
    }

    [Test]
    public async Task CopyTo_OnClosedStream_ThrowsObjectDisposedException()
    {
        var stream = new ReadOnlyMemoryStream(Data);
        stream.Close();
        using var destination = new MemoryStream();

        void Act() => stream.CopyTo(destination, 1);

        await Assert.That(Act).Throws<ObjectDisposedException>();
    }

    [Test]
    public async Task CopyTo_CopiesBytesFromPositionAndMovesToEnd()
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        stream.Position = 2;
        using var destination = new MemoryStream();
        byte[] expected = [3, 4, 5];

        stream.CopyTo(destination, 1);

        await Assert.That(destination.ToArray()).IsEquivalentTo(expected, CollectionOrdering.Matching);
        await Assert.That(stream.Position).IsEqualTo(5);
    }

    [Test]
    [Arguments(5)]
    [Arguments(7)]
    public async Task CopyTo_AtEnd_CopiesNothing(int position)
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        stream.Position = position;
        using var destination = new MemoryStream();

        stream.CopyTo(destination, 1);

        await Assert.That(destination.Length).IsEqualTo(0);
        await Assert.That(stream.Position).IsEqualTo(position);
    }

    [Test]
    public async Task CopyTo_WithNonMemoryStreamDestination_CopiesBytesInOneWrite()
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        stream.Position = 2;
        using var destination = new RecordingStream();
        byte[] expected = [3, 4, 5];

        stream.CopyTo(destination, 1);

        await Assert.That(destination.WrittenBytes).IsEquivalentTo(expected, CollectionOrdering.Matching);
        await Assert.That(destination.WriteCallCount).IsEqualTo(1);
    }

    [Test]
    public async Task CopyTo_WithoutBackingArray_CopiesBytesFromPosition()
    {
        using var manager = new ArrayMemoryManager(Data);
        using var stream = new ReadOnlyMemoryStream(manager.Memory);
        stream.Position = 2;
        using var destination = new MemoryStream();
        byte[] expected = [3, 4, 5];

        stream.CopyTo(destination, 1);

        await Assert.That(destination.ToArray()).IsEquivalentTo(expected, CollectionOrdering.Matching);
        await Assert.That(stream.Position).IsEqualTo(5);
    }

    [Test]
    public async Task CopyTo_WithoutBufferSize_CopiesBytesFromPosition()
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        stream.Position = 2;
        using var destination = new MemoryStream();
        byte[] expected = [3, 4, 5];

        stream.CopyTo(destination);

        await Assert.That(destination.ToArray()).IsEquivalentTo(expected, CollectionOrdering.Matching);
        await Assert.That(stream.Position).IsEqualTo(5);
    }
}
