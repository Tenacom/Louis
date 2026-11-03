// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.IO;
using TUnit.Assertions.Enums;

#pragma warning disable CA1849 // Call async methods when in an async method - the synchronous Read is the method under test
internal sealed class ReadOnlyMemoryStreamReadTests
{
    private static readonly byte[] Data = [1, 2, 3, 4, 5];

    [Test]
    public async Task Read_WithNullArray_ThrowsArgumentNullException()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        // ! Null on purpose: testing null detection
        void Act() => _ = stream.Read(null!, 0, 1);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("buffer");
    }

    [Test]
    public async Task Read_WithNegativeOffset_ThrowsArgumentOutOfRangeException()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        void Act() => _ = stream.Read(new byte[5], -1, 1);

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName("offset");
    }

    [Test]
    [Arguments(0, -1)]
    [Arguments(0, 6)]
    [Arguments(3, 3)]
    public async Task Read_WithCountOutsideArray_ThrowsArgumentOutOfRangeException(int offset, int count)
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        void Act() => _ = stream.Read(new byte[5], offset, count);

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName("count");
    }

    [Test]
    public async Task Read_WithArray_OnClosedStream_ThrowsObjectDisposedException()
    {
        var stream = new ReadOnlyMemoryStream(Data);
        stream.Close();

        void Act() => _ = stream.Read(new byte[5], 0, 5);

        await Assert.That(Act).Throws<ObjectDisposedException>();
    }

    [Test]
    [Arguments(0, 3, new byte[] { 1, 2, 3 })]
    [Arguments(0, 5, new byte[] { 1, 2, 3, 4, 5 })]
    [Arguments(3, 5, new byte[] { 4, 5 })]
    [Arguments(5, 3, new byte[0])]
    [Arguments(7, 3, new byte[0])]
    public async Task Read_WithArray_ReadsAvailableBytes(int position, int count, byte[] expected)
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        stream.Position = position;
        var buffer = new byte[count];

        var read = stream.Read(buffer, 0, count);

        await Assert.That(read).IsEqualTo(expected.Length);
        await Assert.That(buffer.Take(read)).IsEquivalentTo(expected, CollectionOrdering.Matching);
        await Assert.That(stream.Position).IsEqualTo(position + expected.Length);
    }

    [Test]
    public async Task Read_WithArray_WritesAtOffset()
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        var buffer = new byte[5];
        byte[] expected = [0, 0, 1, 2, 0];

        var read = stream.Read(buffer, 2, 2);

        await Assert.That(read).IsEqualTo(2);
        await Assert.That(buffer).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task Read_WithArray_WithoutBackingArray_ReadsAvailableBytes()
    {
        using var manager = new ArrayMemoryManager(Data);
        using var stream = new ReadOnlyMemoryStream(manager.Memory);
        stream.Position = 2;
        var buffer = new byte[5];
        byte[] expected = [3, 4, 5];

        var read = stream.Read(buffer, 0, 5);

        await Assert.That(read).IsEqualTo(3);
        await Assert.That(buffer.Take(read)).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task Read_WithSpan_OnClosedStream_ThrowsObjectDisposedException()
    {
        var stream = new ReadOnlyMemoryStream(Data);
        stream.Close();

        void Act() => _ = stream.Read(new byte[5].AsSpan());

        await Assert.That(Act).Throws<ObjectDisposedException>();
    }

    [Test]
    [Arguments(0, 3, new byte[] { 1, 2, 3 })]
    [Arguments(0, 5, new byte[] { 1, 2, 3, 4, 5 })]
    [Arguments(3, 5, new byte[] { 4, 5 })]
    [Arguments(5, 3, new byte[0])]
    [Arguments(7, 3, new byte[0])]
    [Arguments(0, 0, new byte[0])]
    public async Task Read_WithSpan_ReadsAvailableBytes(int position, int length, byte[] expected)
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        stream.Position = position;
        var buffer = new byte[length];

        var read = stream.Read(buffer.AsSpan());

        await Assert.That(read).IsEqualTo(expected.Length);
        await Assert.That(buffer.Take(read)).IsEquivalentTo(expected, CollectionOrdering.Matching);
        await Assert.That(stream.Position).IsEqualTo(position + expected.Length);
    }

    [Test]
    public async Task Read_WithSpan_WithoutBackingArray_ReadsAvailableBytes()
    {
        using var manager = new ArrayMemoryManager(Data);
        using var stream = new ReadOnlyMemoryStream(manager.Memory);
        stream.Position = 2;
        var buffer = new byte[5];
        byte[] expected = [3, 4, 5];

        var read = stream.Read(buffer.AsSpan());

        await Assert.That(read).IsEqualTo(3);
        await Assert.That(buffer.Take(read)).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    public async Task ReadByte_ReadsEachByteThenMinusOne()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        var results = Enumerable.Range(0, 7).Select(_ => stream.ReadByte()).ToArray();

        await Assert.That(results).IsEquivalentTo([1, 2, 3, 4, 5, -1, -1], CollectionOrdering.Matching);
        await Assert.That(stream.Position).IsEqualTo(5);
    }

    [Test]
    public async Task ReadByte_OnClosedStream_ThrowsObjectDisposedException()
    {
        var stream = new ReadOnlyMemoryStream(Data);
        stream.Close();

        void Act() => _ = stream.ReadByte();

        await Assert.That(Act).Throws<ObjectDisposedException>();
    }
}
