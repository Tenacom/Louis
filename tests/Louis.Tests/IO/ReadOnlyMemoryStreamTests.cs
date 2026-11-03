// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.IO;

#pragma warning disable CA1849 // Call async methods when in an async method - Dispose, Flush, and Write are methods under test
internal sealed class ReadOnlyMemoryStreamTests
{
    private static readonly byte[] Data = [1, 2, 3, 4, 5];

    [Test]
    public async Task Constructor_CreatesOpenStreamAtStart()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        await Assert.That(stream.CanRead).IsTrue();
        await Assert.That(stream.CanSeek).IsTrue();
        await Assert.That(stream.CanWrite).IsFalse();
        await Assert.That(stream.Length).IsEqualTo(5);
        await Assert.That(stream.Position).IsEqualTo(0);
    }

    [Test]
    public async Task Dispose_ClosesStream()
    {
        var stream = new ReadOnlyMemoryStream(Data);

        stream.Dispose();

        await Assert.That(stream.CanRead).IsFalse();
        await Assert.That(stream.CanSeek).IsFalse();
        await Assert.That(stream.CanWrite).IsFalse();
    }

    [Test]
    public async Task Dispose_WhenCalledAgain_DoesNothing()
    {
        var stream = new ReadOnlyMemoryStream(Data);
        stream.Dispose();

        void Act() => stream.Dispose();

        await Assert.That(Act).ThrowsNothing();
        await Assert.That(stream.CanRead).IsFalse();
    }

    [Test]
    public async Task Length_OnClosedStream_ThrowsObjectDisposedException()
    {
        var stream = new ReadOnlyMemoryStream(Data);
        stream.Close();

        void Act() => _ = stream.Length;

        await Assert.That(Act).Throws<ObjectDisposedException>().WithMessage("Cannot access a closed Stream.", StringComparison.Ordinal);
    }

    [Test]
    [Arguments(0L)]
    [Arguments(3L)]
    [Arguments(5L)]
    [Arguments(10L)]
    [Arguments((long)int.MaxValue)]
    public async Task Position_WhenSetToNonNegativeValue_MovesPosition(long value)
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        stream.Position = value;

        await Assert.That(stream.Position).IsEqualTo(value);
    }

    [Test]
    public async Task Position_WhenSetToNegativeValue_ThrowsArgumentOutOfRangeException()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        void Act() => stream.Position = -1;

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName("value");
    }

    [Test]
    public async Task Position_WhenSetAboveInt32MaxValue_ThrowsArgumentOutOfRangeException()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        void Act() => stream.Position = int.MaxValue + 1L;

        await Assert.That(Act).Throws<ArgumentOutOfRangeException>().WithParameterName("value");
    }

    [Test]
    public async Task Position_WhenReadOnClosedStream_ThrowsObjectDisposedException()
    {
        var stream = new ReadOnlyMemoryStream(Data);
        stream.Close();

        void Act() => _ = stream.Position;

        await Assert.That(Act).Throws<ObjectDisposedException>();
    }

    [Test]
    public async Task Position_WhenSetOnClosedStream_ThrowsObjectDisposedException()
    {
        var stream = new ReadOnlyMemoryStream(Data);
        stream.Close();

        void Act() => stream.Position = 0;

        await Assert.That(Act).Throws<ObjectDisposedException>();
    }

    [Test]
    public async Task Flush_DoesNothing()
    {
        using var stream = new ReadOnlyMemoryStream(Data);
        stream.Position = 2;

        stream.Flush();

        await Assert.That(stream.Position).IsEqualTo(2);
    }

    [Test]
    public async Task FlushAsync_ReturnsCompletedTask()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        var task = stream.FlushAsync(CancellationToken.None);

        await Assert.That(task.Status).IsEqualTo(TaskStatus.RanToCompletion);
    }

    [Test]
    public async Task FlushAsync_WithCanceledToken_ReturnsCanceledTask()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        var task = stream.FlushAsync(new CancellationToken(canceled: true));

        await Assert.That(task.IsCanceled).IsTrue();
    }

    [Test]
    public async Task SetLength_ThrowsNotSupportedException()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        void Act() => stream.SetLength(10);

        await Assert.That(Act).Throws<NotSupportedException>();
    }

    [Test]
    public async Task Write_WithArray_ThrowsNotSupportedException()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        void Act() => stream.Write(new byte[1], 0, 1);

        await Assert.That(Act).Throws<NotSupportedException>();
    }

    [Test]
    public async Task Write_WithSpan_ThrowsNotSupportedException()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        void Act() => stream.Write(new byte[1].AsSpan());

        await Assert.That(Act).Throws<NotSupportedException>();
    }

    [Test]
    public async Task WriteAsync_WithArray_ThrowsNotSupportedException()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        void Act() => _ = stream.WriteAsync(new byte[1], 0, 1, CancellationToken.None);

        await Assert.That(Act).Throws<NotSupportedException>();
    }

    [Test]
    public async Task WriteAsync_WithMemory_ThrowsNotSupportedException()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        void Act() => _ = stream.WriteAsync(new byte[1].AsMemory(), CancellationToken.None).AsTask();

        await Assert.That(Act).Throws<NotSupportedException>();
    }

    [Test]
    public async Task WriteByte_ThrowsNotSupportedException()
    {
        using var stream = new ReadOnlyMemoryStream(Data);

        void Act() => stream.WriteByte(1);

        await Assert.That(Act).Throws<NotSupportedException>();
    }
}
