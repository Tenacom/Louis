// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.IO.Compression;
using Louis.Diagnostics;

// A DeflateStream that compresses supports writing alone. It supports neither reading nor seeking.
internal sealed class ParamExtensionsStreamsTests
{
    [Test]
    public async Task CanRead_WithReadableStream_ReturnsSameParam()
    {
        using var stream = new MemoryStream();

        var param = Param.Check(stream).CanRead();

        await Assert.That(param.Value).IsSameReferenceAs(stream);
        await Assert.That(param.Name).IsEqualTo("stream");
    }

    [Test]
    public async Task CanRead_WithStreamNotReadable_ThrowsArgumentException()
    {
        static void Act()
        {
            using var buffer = new MemoryStream();
            using var stream = new DeflateStream(buffer, CompressionMode.Compress);
            Param.Check(stream).CanRead();
        }

        await Assert.That(Act)
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("stream must support reading.", StringComparison.Ordinal)
            .And.WithParameterName("stream");
    }

    [Test]
    public async Task CanRead_WithMessage_FormatsMessage()
    {
        static void Act()
        {
            using var buffer = new MemoryStream();
            using var stream = new DeflateStream(buffer, CompressionMode.Compress);
            Param.Check(stream).CanRead("{0} is a {1}, and is not readable.");
        }

        await Assert.That(Act)
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("stream is a System.IO.Compression.DeflateStream, and is not readable.", StringComparison.Ordinal);
    }

    [Test]
    public async Task CanWrite_WithWritableStream_ReturnsSameParam()
    {
        using var stream = new MemoryStream();

        var param = Param.Check(stream).CanWrite();

        await Assert.That(param.Value).IsSameReferenceAs(stream);
        await Assert.That(param.Name).IsEqualTo("stream");
    }

    [Test]
    public async Task CanWrite_WithStreamNotWritable_ThrowsArgumentException()
    {
        static void Act()
        {
            using var stream = new MemoryStream(new byte[4], writable: false);
            Param.Check(stream).CanWrite();
        }

        await Assert.That(Act)
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("stream must support writing.", StringComparison.Ordinal)
            .And.WithParameterName("stream");
    }

    [Test]
    public async Task CanWrite_WithMessage_FormatsMessage()
    {
        static void Act()
        {
            using var stream = new MemoryStream(new byte[4], writable: false);
            Param.Check(stream).CanWrite("{0} is a {1}, and is not writable.");
        }

        await Assert.That(Act)
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("stream is a System.IO.MemoryStream, and is not writable.", StringComparison.Ordinal);
    }

    [Test]
    public async Task CanSeek_WithSeekableStream_ReturnsSameParam()
    {
        using var stream = new MemoryStream();

        var param = Param.Check(stream).CanSeek();

        await Assert.That(param.Value).IsSameReferenceAs(stream);
        await Assert.That(param.Name).IsEqualTo("stream");
    }

    [Test]
    public async Task CanSeek_WithStreamNotSeekable_ThrowsArgumentException()
    {
        static void Act()
        {
            using var buffer = new MemoryStream();
            using var stream = new DeflateStream(buffer, CompressionMode.Compress);
            Param.Check(stream).CanSeek();
        }

        await Assert.That(Act)
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("stream must support seeking.", StringComparison.Ordinal)
            .And.WithParameterName("stream");
    }

    [Test]
    public async Task CanSeek_WithMessage_FormatsMessage()
    {
        static void Act()
        {
            using var buffer = new MemoryStream();
            using var stream = new DeflateStream(buffer, CompressionMode.Compress);
            Param.Check(stream).CanSeek("{0} is a {1}, and is not seekable.");
        }

        await Assert.That(Act)
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("stream is a System.IO.Compression.DeflateStream, and is not seekable.", StringComparison.Ordinal);
    }

    [Test]
    public async Task AtStartPosition_WithStreamAtStart_ReturnsSameParam()
    {
        using var stream = new MemoryStream(new byte[4]);

        var param = Param.Check(stream).AtStartPosition();

        await Assert.That(param.Value).IsSameReferenceAs(stream);
        await Assert.That(param.Name).IsEqualTo("stream");
    }

    [Test]
    public async Task AtStartPosition_WithStreamNotAtStart_ThrowsArgumentException()
    {
        static void Act()
        {
            using var stream = new MemoryStream(new byte[4]);
            stream.Position = 2;
            Param.Check(stream).AtStartPosition();
        }

        await Assert.That(Act)
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("stream must be at its start position, and its position is 2.", StringComparison.Ordinal)
            .And.WithParameterName("stream");
    }

    [Test]
    public async Task AtStartPosition_WithStreamNotSeekable_ThrowsNotSupportedException()
    {
        static void Act()
        {
            using var buffer = new MemoryStream();
            using var stream = new DeflateStream(buffer, CompressionMode.Compress);
            Param.Check(stream).AtStartPosition();
        }

        await Assert.That(Act).ThrowsExactly<NotSupportedException>();
    }

    [Test]
    public async Task AtStartPosition_WithMessage_FormatsMessage()
    {
        static void Act()
        {
            using var stream = new MemoryStream(new byte[4]);
            stream.Position = 2;
            Param.Check(stream).AtStartPosition("{0}|{1}|{2}");
        }

        await Assert.That(Act)
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("stream|System.IO.MemoryStream|2", StringComparison.Ordinal);
    }

    [Test]
    public async Task AtEndPosition_WithStreamAtEnd_ReturnsSameParam()
    {
        using var stream = new MemoryStream(new byte[4]);
        stream.Position = 4;

        var param = Param.Check(stream).AtEndPosition();

        await Assert.That(param.Value).IsSameReferenceAs(stream);
        await Assert.That(param.Name).IsEqualTo("stream");
    }

    [Test]
    public async Task AtEndPosition_WithEmptyStream_ReturnsSameParam()
    {
        using var stream = new MemoryStream();

        var param = Param.Check(stream).AtEndPosition();

        await Assert.That(param.Value).IsSameReferenceAs(stream);
        await Assert.That(param.Name).IsEqualTo("stream");
    }

    [Test]
    [Arguments(0L)]
    [Arguments(2L)]
    [Arguments(6L)]
    public async Task AtEndPosition_WithStreamNotAtEnd_ThrowsArgumentException(long position)
    {
        static void Act(long position)
        {
            using var stream = new MemoryStream(new byte[4]);
            stream.Position = position;
            Param.Check(stream).AtEndPosition();
        }

        await Assert.That(() => Act(position))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"stream must be at its end position 4, and its position is {position}.", StringComparison.Ordinal)
            .And.WithParameterName("stream");
    }

    [Test]
    public async Task AtEndPosition_WithStreamNotSeekable_ThrowsNotSupportedException()
    {
        static void Act()
        {
            using var buffer = new MemoryStream();
            using var stream = new DeflateStream(buffer, CompressionMode.Compress);
            Param.Check(stream).AtEndPosition();
        }

        await Assert.That(Act).ThrowsExactly<NotSupportedException>();
    }

    [Test]
    public async Task AtEndPosition_WithMessage_FormatsMessage()
    {
        static void Act()
        {
            using var stream = new MemoryStream(new byte[4]);
            stream.Position = 2;
            Param.Check(stream).AtEndPosition("{0}|{1}|{2}|{3}");
        }

        await Assert.That(Act)
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("stream|System.IO.MemoryStream|2|4", StringComparison.Ordinal);
    }

    [Test]
    public async Task StreamChecks_OnDerivedType_KeepTypeOfChain()
    {
        static MemoryStream Check(MemoryStream stream) => Param.Check(stream).CanRead().CanWrite().CanSeek().AtStartPosition().Value;

        using var stream = new MemoryStream();

        var result = Check(stream);

        await Assert.That(result).IsSameReferenceAs(stream);
    }
}
