// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.IO;

internal sealed class ReadOnlyMemoryStreamSeekTests
{
    private static readonly byte[] Data = [1, 2, 3, 4, 5];

    [Test]
    [Arguments(2, 3L, SeekOrigin.Begin, 3L)]
    [Arguments(2, 0L, SeekOrigin.Begin, 0L)]
    [Arguments(2, 10L, SeekOrigin.Begin, 10L)]
    [Arguments(2, 2L, SeekOrigin.Current, 4L)]
    [Arguments(2, -1L, SeekOrigin.Current, 1L)]
    [Arguments(2, 0L, SeekOrigin.Current, 2L)]
    [Arguments(2, 1L, SeekOrigin.End, 6L)]
    [Arguments(2, -2L, SeekOrigin.End, 3L)]
    [Arguments(2, 0L, SeekOrigin.End, 5L)]
    public async Task Seek_MovesPositionAndReturnsIt(int initialPosition, long offset, SeekOrigin origin, long expected)
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        stream.Position = initialPosition;

        var result = stream.Seek(offset, origin);

        await Assert.That(result).IsEqualTo(expected);
        await Assert.That(stream.Position).IsEqualTo(expected);
    }

    [Test]
    [Arguments(0, -1L, SeekOrigin.Begin)]
    [Arguments(2, -3L, SeekOrigin.Current)]
    [Arguments(0, -6L, SeekOrigin.End)]
    [Arguments(1, (long)int.MaxValue, SeekOrigin.Current)]
    [Arguments(0, (long)int.MaxValue, SeekOrigin.End)]
    public async Task Seek_BeforeBeginning_ThrowsIOException(int initialPosition, long offset, SeekOrigin origin)
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        stream.Position = initialPosition;

        void Act() => stream.Seek(offset, origin);

        await Assert.That(Act).Throws<IOException>();
        await Assert.That(stream.Position).IsEqualTo(initialPosition);
    }

    [Test]
    public async Task Seek_WithOffsetAboveInt32MaxValue_ThrowsArgumentOutOfRangeException()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        void Act() => stream.Seek(int.MaxValue + 1L, SeekOrigin.Begin);

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName("offset");
    }

    [Test]
    public async Task Seek_WithUndefinedOrigin_ThrowsArgumentException()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        void Act() => stream.Seek(0, (SeekOrigin)3);

        await Assert.That(Act).Throws<ArgumentException>();
    }

    [Test]
    public async Task Seek_OnClosedStream_ThrowsObjectDisposedException()
    {
        var stream = new ReadOnlyMemoryStream(Data);
        stream.Close();

        void Act() => stream.Seek(0, SeekOrigin.Begin);

        await Assert.That(Act).Throws<ObjectDisposedException>();
    }
}
