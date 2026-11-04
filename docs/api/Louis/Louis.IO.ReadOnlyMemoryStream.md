#### [Louis](README.md 'README')
### [Louis\.IO](Louis.IO.md 'Louis\.IO')

## ReadOnlyMemoryStream Class

Implements a read\-only [System\.IO\.Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream 'System\.IO\.Stream') using a [ReadOnlyMemory&lt;byte&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlymemory-1 'System\.ReadOnlyMemory\`1') as backing store\.

```csharp
public sealed class ReadOnlyMemoryStream : System.IO.Stream
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.MarshalByRefObject](https://learn.microsoft.com/en-us/dotnet/api/system.marshalbyrefobject 'System\.MarshalByRefObject') → [System\.IO\.Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream 'System\.IO\.Stream') → ReadOnlyMemoryStream
### Constructors

<a name='Louis.IO.ReadOnlyMemoryStream.ReadOnlyMemoryStream(System.ReadOnlyMemory_byte_)'></a>

## ReadOnlyMemoryStream\(ReadOnlyMemory\<byte\>\) Constructor

Initializes a new instance of the [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream') class\.

```csharp
public ReadOnlyMemoryStream(System.ReadOnlyMemory<byte> data);
```
#### Parameters

<a name='Louis.IO.ReadOnlyMemoryStream.ReadOnlyMemoryStream(System.ReadOnlyMemory_byte_).data'></a>

`data` [System\.ReadOnlyMemory&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlymemory-1 'System\.ReadOnlyMemory\`1')[System\.Byte](https://learn.microsoft.com/en-us/dotnet/api/system.byte 'System\.Byte')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlymemory-1 'System\.ReadOnlyMemory\`1')

The memory from which to create the current stream\.
### Properties

<a name='Louis.IO.ReadOnlyMemoryStream.CanRead'></a>

## ReadOnlyMemoryStream\.CanRead Property

Gets a value indicating whether the current stream supports reading\.

```csharp
public override bool CanRead { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the stream is open\.

<a name='Louis.IO.ReadOnlyMemoryStream.CanSeek'></a>

## ReadOnlyMemoryStream\.CanSeek Property

Gets a value indicating whether the current stream supports seeking\.

```csharp
public override bool CanSeek { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the stream is open\.

<a name='Louis.IO.ReadOnlyMemoryStream.CanWrite'></a>

## ReadOnlyMemoryStream\.CanWrite Property

Gets a value indicating whether the current stream supports writing\.

```csharp
public override bool CanWrite { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
Always [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='Louis.IO.ReadOnlyMemoryStream.Length'></a>

## ReadOnlyMemoryStream\.Length Property

Gets the length of the stream in bytes\.

```csharp
public override long Length { get; }
```

#### Property Value
[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')  
The length of the stream in bytes\.

#### Exceptions

[System\.ObjectDisposedException](https://learn.microsoft.com/en-us/dotnet/api/system.objectdisposedexception 'System\.ObjectDisposedException')  
The stream is closed\.

<a name='Louis.IO.ReadOnlyMemoryStream.Position'></a>

## ReadOnlyMemoryStream\.Position Property

Gets or sets the current position within the stream\.

```csharp
public override long Position { get; set; }
```

#### Property Value
[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')  
The current position within the stream\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
The position is set to a negative value
            or a value greater than [System\.Int32\.MaxValue](https://learn.microsoft.com/en-us/dotnet/api/system.int32.maxvalue 'System\.Int32\.MaxValue')\.

[System\.ObjectDisposedException](https://learn.microsoft.com/en-us/dotnet/api/system.objectdisposedexception 'System\.ObjectDisposedException')  
The stream is closed\.
### Methods

<a name='Louis.IO.ReadOnlyMemoryStream.CopyTo(System.IO.Stream,int)'></a>

## ReadOnlyMemoryStream\.CopyTo\(Stream, int\) Method

Reads the bytes from the current stream and writes them to another stream, using a specified buffer size\.

```csharp
public override void CopyTo(System.IO.Stream destination, int bufferSize);
```
#### Parameters

<a name='Louis.IO.ReadOnlyMemoryStream.CopyTo(System.IO.Stream,int).destination'></a>

`destination` [System\.IO\.Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream 'System\.IO\.Stream')

The stream to which the contents of the current stream will be copied\.

<a name='Louis.IO.ReadOnlyMemoryStream.CopyTo(System.IO.Stream,int).bufferSize'></a>

`bufferSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The size of the buffer\. This value must be greater than zero\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[destination](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.CopyTo(System.IO.Stream,int).destination 'Louis\.IO\.ReadOnlyMemoryStream\.CopyTo\(System\.IO\.Stream, int\)\.destination') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[bufferSize](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.CopyTo(System.IO.Stream,int).bufferSize 'Louis\.IO\.ReadOnlyMemoryStream\.CopyTo\(System\.IO\.Stream, int\)\.bufferSize') is zero or negative\.

[System\.ObjectDisposedException](https://learn.microsoft.com/en-us/dotnet/api/system.objectdisposedexception 'System\.ObjectDisposedException')  
Either this stream or [destination](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.CopyTo(System.IO.Stream,int).destination 'Louis\.IO\.ReadOnlyMemoryStream\.CopyTo\(System\.IO\.Stream, int\)\.destination') is closed\.

### Remarks

This method overrides the corresponding method of [System\.IO\.Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream 'System\.IO\.Stream') on runtimes where it is `virtual`
            (.NET Core 2.0 and newer, .NET 5 and newer, .NET Standard 2.1 and newer).
            On older runtimes, this method can be accessed as a method of [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream'),
            while a [System\.IO\.Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream 'System\.IO\.Stream') reference will use the standard implementation,
            which works but is slower and may allocate more memory.

Since this method copies all the contents of the stream (starting from the current [Position](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.Position 'Louis\.IO\.ReadOnlyMemoryStream\.Position')) in one go,
            the [bufferSize](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.CopyTo(System.IO.Stream,int).bufferSize 'Louis\.IO\.ReadOnlyMemoryStream\.CopyTo\(System\.IO\.Stream, int\)\.bufferSize') parameter is not used; it is still validated for backward compatibility.

<a name='Louis.IO.ReadOnlyMemoryStream.CopyToAsync(System.IO.Stream,int,System.Threading.CancellationToken)'></a>

## ReadOnlyMemoryStream\.CopyToAsync\(Stream, int, CancellationToken\) Method

Asynchronously reads all the bytes from the current stream and writes them to another stream, using a specified buffer size,
and monitors cancellation requests\.

```csharp
public override System.Threading.Tasks.Task CopyToAsync(System.IO.Stream destination, int bufferSize, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Louis.IO.ReadOnlyMemoryStream.CopyToAsync(System.IO.Stream,int,System.Threading.CancellationToken).destination'></a>

`destination` [System\.IO\.Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream 'System\.IO\.Stream')

The stream to which the contents of the current stream will be copied\.

<a name='Louis.IO.ReadOnlyMemoryStream.CopyToAsync(System.IO.Stream,int,System.Threading.CancellationToken).bufferSize'></a>

`bufferSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The size, in bytes, of the buffer\. This value must be greater than zero\.

<a name='Louis.IO.ReadOnlyMemoryStream.CopyToAsync(System.IO.Stream,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A task that represents the asynchronous copy operation\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[destination](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.CopyToAsync(System.IO.Stream,int,System.Threading.CancellationToken).destination 'Louis\.IO\.ReadOnlyMemoryStream\.CopyToAsync\(System\.IO\.Stream, int, System\.Threading\.CancellationToken\)\.destination') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[bufferSize](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.CopyToAsync(System.IO.Stream,int,System.Threading.CancellationToken).bufferSize 'Louis\.IO\.ReadOnlyMemoryStream\.CopyToAsync\(System\.IO\.Stream, int, System\.Threading\.CancellationToken\)\.bufferSize') is zero or negative\.

[System\.ObjectDisposedException](https://learn.microsoft.com/en-us/dotnet/api/system.objectdisposedexception 'System\.ObjectDisposedException')  
Either this stream or [destination](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.CopyToAsync(System.IO.Stream,int,System.Threading.CancellationToken).destination 'Louis\.IO\.ReadOnlyMemoryStream\.CopyToAsync\(System\.IO\.Stream, int, System\.Threading\.CancellationToken\)\.destination') is closed\.

[System\.OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception 'System\.OperationCanceledException')  
The cancellation token was canceled\.
            This exception is stored into the returned task\.

<a name='Louis.IO.ReadOnlyMemoryStream.Dispose(bool)'></a>

## ReadOnlyMemoryStream\.Dispose\(bool\) Method

Releases the unmanaged resources used by the [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream') class and optionally releases the managed resources\.

```csharp
protected override void Dispose(bool disposing);
```
#### Parameters

<a name='Louis.IO.ReadOnlyMemoryStream.Dispose(bool).disposing'></a>

`disposing` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to release both managed and unmanaged resources;
            [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') to release only unmanaged resources\.

<a name='Louis.IO.ReadOnlyMemoryStream.Flush()'></a>

## ReadOnlyMemoryStream\.Flush\(\) Method

Overrides the [System\.IO\.Stream\.Flush](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream.flush 'System\.IO\.Stream\.Flush') method, performing no action\.

```csharp
public override void Flush();
```

### Remarks

Since a [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream') cannot be written to, this method is redundant.
            However, flushing a read-only stream is a valid operation; therefore this method simply returns
            without doing anything.

<a name='Louis.IO.ReadOnlyMemoryStream.FlushAsync(System.Threading.CancellationToken)'></a>

## ReadOnlyMemoryStream\.FlushAsync\(CancellationToken\) Method

Overrides the [System\.IO\.Stream\.FlushAsync\(System\.Threading\.CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream.flushasync#system-io-stream-flushasync(system-threading-cancellationtoken) 'System\.IO\.Stream\.FlushAsync\(System\.Threading\.CancellationToken\)') method, performing no action\.

```csharp
public override System.Threading.Tasks.Task FlushAsync(System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Louis.IO.ReadOnlyMemoryStream.FlushAsync(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A task that represents the asynchronous flush operation\.

#### Exceptions

[System\.OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception 'System\.OperationCanceledException')  
The cancellation token was canceled\.
            This exception is stored into the returned task\.

### Remarks

Since a [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream') cannot be written to, this method is redundant.
            However, flushing a read-only stream is a valid operation; therefore this method simply returns
            a completed [System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task') without doing anything, unless [cancellationToken](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.FlushAsync(System.Threading.CancellationToken).cancellationToken 'Louis\.IO\.ReadOnlyMemoryStream\.FlushAsync\(System\.Threading\.CancellationToken\)\.cancellationToken')
            has been canceled.

<a name='Louis.IO.ReadOnlyMemoryStream.Read(byte[],int,int)'></a>

## ReadOnlyMemoryStream\.Read\(byte\[\], int, int\) Method

Reads a block of bytes from the current stream and writes the data to a buffer\.

```csharp
public override int Read(byte[] buffer, int offset, int count);
```
#### Parameters

<a name='Louis.IO.ReadOnlyMemoryStream.Read(byte[],int,int).buffer'></a>

`buffer` [System\.Byte](https://learn.microsoft.com/en-us/dotnet/api/system.byte 'System\.Byte')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

When this method returns, contains the specified byte array
            with the values between `offset` and `(offset + count - 1)`
            replaced by the characters read from the current stream\.

<a name='Louis.IO.ReadOnlyMemoryStream.Read(byte[],int,int).offset'></a>

`offset` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The zero\-based byte offset in [buffer](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.Read(byte[],int,int).buffer 'Louis\.IO\.ReadOnlyMemoryStream\.Read\(byte\[\], int, int\)\.buffer')
            at which to begin storing data from the current stream\.

<a name='Louis.IO.ReadOnlyMemoryStream.Read(byte[],int,int).count'></a>

`count` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of bytes to read\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The total number of bytes written into the buffer\.
            This can be less than the number of bytes requested if that number of bytes are not currently available,
            or zero if the end of the stream is reached before any bytes are read\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[buffer](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.Read(byte[],int,int).buffer 'Louis\.IO\.ReadOnlyMemoryStream\.Read\(byte\[\], int, int\)\.buffer') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[offset](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.Read(byte[],int,int).offset 'Louis\.IO\.ReadOnlyMemoryStream\.Read\(byte\[\], int, int\)\.offset') or [count](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.Read(byte[],int,int).count 'Louis\.IO\.ReadOnlyMemoryStream\.Read\(byte\[\], int, int\)\.count') is negative\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[offset](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.Read(byte[],int,int).offset 'Louis\.IO\.ReadOnlyMemoryStream\.Read\(byte\[\], int, int\)\.offset') subtracted from the length of [buffer](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.Read(byte[],int,int).buffer 'Louis\.IO\.ReadOnlyMemoryStream\.Read\(byte\[\], int, int\)\.buffer')
            is less than [count](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.Read(byte[],int,int).count 'Louis\.IO\.ReadOnlyMemoryStream\.Read\(byte\[\], int, int\)\.count')\.

[System\.ObjectDisposedException](https://learn.microsoft.com/en-us/dotnet/api/system.objectdisposedexception 'System\.ObjectDisposedException')  
The stream is closed\.

<a name='Louis.IO.ReadOnlyMemoryStream.Read(System.Span_byte_)'></a>

## ReadOnlyMemoryStream\.Read\(Span\<byte\>\) Method

Reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read\.

```csharp
public override int Read(System.Span<byte> buffer);
```
#### Parameters

<a name='Louis.IO.ReadOnlyMemoryStream.Read(System.Span_byte_).buffer'></a>

`buffer` [System\.Span&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.span-1 'System\.Span\`1')[System\.Byte](https://learn.microsoft.com/en-us/dotnet/api/system.byte 'System\.Byte')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.span-1 'System\.Span\`1')

A region of memory\. When this method returns,
            the contents of this span are replaced by the bytes read from the current stream\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The total number of bytes read into the buffer\.
            This can be less than the number of bytes allocated in the buffer if that many bytes are not currently available,
            or zero \(0\) if the end of the stream has been reached\.

#### Exceptions

[System\.ObjectDisposedException](https://learn.microsoft.com/en-us/dotnet/api/system.objectdisposedexception 'System\.ObjectDisposedException')  
The stream is closed\.

### Remarks

This method overrides the corresponding method of [System\.IO\.Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream 'System\.IO\.Stream') on runtimes where it is available
            (.NET Core 2.1 and newer, .NET 5 and newer, .NET Standard 2.1 and newer).
            On older runtimes, this method is present as a method of [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream')
            and depends on the `System.Memory` NuGet package.

<a name='Louis.IO.ReadOnlyMemoryStream.ReadAsync(byte[],int,int,System.Threading.CancellationToken)'></a>

## ReadOnlyMemoryStream\.ReadAsync\(byte\[\], int, int, CancellationToken\) Method

Asynchronously reads a sequence of bytes from the current stream,
advances the position within the stream by the number of bytes read, and monitors cancellation requests\.

```csharp
public override System.Threading.Tasks.Task<int> ReadAsync(byte[] buffer, int offset, int count, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Louis.IO.ReadOnlyMemoryStream.ReadAsync(byte[],int,int,System.Threading.CancellationToken).buffer'></a>

`buffer` [System\.Byte](https://learn.microsoft.com/en-us/dotnet/api/system.byte 'System\.Byte')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The buffer to write the data into\.

<a name='Louis.IO.ReadOnlyMemoryStream.ReadAsync(byte[],int,int,System.Threading.CancellationToken).offset'></a>

`offset` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The byte offset in [buffer](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.ReadAsync(byte[],int,int,System.Threading.CancellationToken).buffer 'Louis\.IO\.ReadOnlyMemoryStream\.ReadAsync\(byte\[\], int, int, System\.Threading\.CancellationToken\)\.buffer') at which to begin writing data from the stream\.

<a name='Louis.IO.ReadOnlyMemoryStream.ReadAsync(byte[],int,int,System.Threading.CancellationToken).count'></a>

`count` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of bytes to read\.

<a name='Louis.IO.ReadOnlyMemoryStream.ReadAsync(byte[],int,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  

A task that represents the asynchronous read operation.

The [Result](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1.result 'System\.Threading\.Tasks\.Task\`1\.Result') of the returned task
            will be the total number of bytes read into the buffer.

The result value can be less than the number of bytes requested if the number of bytes currently available
            is less than the requested number, or it can be 0 (zero) if the end of the stream has been reached.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[buffer](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.ReadAsync(byte[],int,int,System.Threading.CancellationToken).buffer 'Louis\.IO\.ReadOnlyMemoryStream\.ReadAsync\(byte\[\], int, int, System\.Threading\.CancellationToken\)\.buffer') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[offset](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.ReadAsync(byte[],int,int,System.Threading.CancellationToken).offset 'Louis\.IO\.ReadOnlyMemoryStream\.ReadAsync\(byte\[\], int, int, System\.Threading\.CancellationToken\)\.offset') or [count](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.ReadAsync(byte[],int,int,System.Threading.CancellationToken).count 'Louis\.IO\.ReadOnlyMemoryStream\.ReadAsync\(byte\[\], int, int, System\.Threading\.CancellationToken\)\.count') is negative\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[offset](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.ReadAsync(byte[],int,int,System.Threading.CancellationToken).offset 'Louis\.IO\.ReadOnlyMemoryStream\.ReadAsync\(byte\[\], int, int, System\.Threading\.CancellationToken\)\.offset') subtracted from the length of [buffer](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.ReadAsync(byte[],int,int,System.Threading.CancellationToken).buffer 'Louis\.IO\.ReadOnlyMemoryStream\.ReadAsync\(byte\[\], int, int, System\.Threading\.CancellationToken\)\.buffer')
            is less than [count](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.ReadAsync(byte[],int,int,System.Threading.CancellationToken).count 'Louis\.IO\.ReadOnlyMemoryStream\.ReadAsync\(byte\[\], int, int, System\.Threading\.CancellationToken\)\.count')\.

[System\.ObjectDisposedException](https://learn.microsoft.com/en-us/dotnet/api/system.objectdisposedexception 'System\.ObjectDisposedException')  
The stream is closed\.

[System\.OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception 'System\.OperationCanceledException')  
The cancellation token was canceled\.
            This exception is stored into the returned task\.

<a name='Louis.IO.ReadOnlyMemoryStream.ReadAsync(System.Memory_byte_,System.Threading.CancellationToken)'></a>

## ReadOnlyMemoryStream\.ReadAsync\(Memory\<byte\>, CancellationToken\) Method

Asynchronously reads a sequence of bytes from the current stream, writes the sequence into [buffer](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.ReadAsync(System.Memory_byte_,System.Threading.CancellationToken).buffer 'Louis\.IO\.ReadOnlyMemoryStream\.ReadAsync\(System\.Memory\<byte\>, System\.Threading\.CancellationToken\)\.buffer'),
advances the position within the stream by the number of bytes read, and monitors cancellation requests\.

```csharp
public override System.Threading.Tasks.ValueTask<int> ReadAsync(System.Memory<byte> buffer, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Louis.IO.ReadOnlyMemoryStream.ReadAsync(System.Memory_byte_,System.Threading.CancellationToken).buffer'></a>

`buffer` [System\.Memory&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1 'System\.Memory\`1')[System\.Byte](https://learn.microsoft.com/en-us/dotnet/api/system.byte 'System\.Byte')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1 'System\.Memory\`1')

The region of memory to write the data into\.

<a name='Louis.IO.ReadOnlyMemoryStream.ReadAsync(System.Memory_byte_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[System\.Threading\.Tasks\.ValueTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1 'System\.Threading\.Tasks\.ValueTask\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1 'System\.Threading\.Tasks\.ValueTask\`1')  

A task that represents the asynchronous read operation.

The [Result](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1.result 'System\.Threading\.Tasks\.Task\`1\.Result') of the returned task
            will be the total number of bytes read into [buffer](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.ReadAsync(System.Memory_byte_,System.Threading.CancellationToken).buffer 'Louis\.IO\.ReadOnlyMemoryStream\.ReadAsync\(System\.Memory\<byte\>, System\.Threading\.CancellationToken\)\.buffer').

The result value can be less than the number of bytes requested if the number of bytes currently available
            is less than the requested number, or it can be 0 (zero) if the end of the stream has been reached.

#### Exceptions

[System\.ObjectDisposedException](https://learn.microsoft.com/en-us/dotnet/api/system.objectdisposedexception 'System\.ObjectDisposedException')  
The stream is closed\.

[System\.OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception 'System\.OperationCanceledException')  
The cancellation token was canceled\.
            This exception is stored into the returned task\.

### Remarks

This method overrides the corresponding method of [System\.IO\.Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream 'System\.IO\.Stream') on runtimes where it is available
            (.NET Core 2.1 and newer, .NET 5 and newer, .NET Standard 2.1 and newer).
            On older runtimes, this method is present as a method of [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream')
            and depends on the `System.Memory` NuGet package.

<a name='Louis.IO.ReadOnlyMemoryStream.ReadByte()'></a>

## ReadOnlyMemoryStream\.ReadByte\(\) Method

Reads a byte from the current stream\.

```csharp
public override int ReadByte();
```

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The byte cast to an [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32'), or \-1 if the end of the stream has been reached\.

#### Exceptions

[System\.ObjectDisposedException](https://learn.microsoft.com/en-us/dotnet/api/system.objectdisposedexception 'System\.ObjectDisposedException')  
The stream is closed\.

<a name='Louis.IO.ReadOnlyMemoryStream.Seek(long,System.IO.SeekOrigin)'></a>

## ReadOnlyMemoryStream\.Seek\(long, SeekOrigin\) Method

Sets the position within the current stream to the specified value\.

```csharp
public override long Seek(long offset, System.IO.SeekOrigin origin);
```
#### Parameters

<a name='Louis.IO.ReadOnlyMemoryStream.Seek(long,System.IO.SeekOrigin).offset'></a>

`offset` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The new position within the stream\.
            This is relative to the [origin](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.Seek(long,System.IO.SeekOrigin).origin 'Louis\.IO\.ReadOnlyMemoryStream\.Seek\(long, System\.IO\.SeekOrigin\)\.origin') parameter, and can be positive or negative\.

<a name='Louis.IO.ReadOnlyMemoryStream.Seek(long,System.IO.SeekOrigin).origin'></a>

`origin` [System\.IO\.SeekOrigin](https://learn.microsoft.com/en-us/dotnet/api/system.io.seekorigin 'System\.IO\.SeekOrigin')

A value of type [System\.IO\.SeekOrigin](https://learn.microsoft.com/en-us/dotnet/api/system.io.seekorigin 'System\.IO\.SeekOrigin'), which acts as the seek reference point\.

#### Returns
[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')  
The new position within the stream, calculated by combining the initial reference point and the offset\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
[offset](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.Seek(long,System.IO.SeekOrigin).offset 'Louis\.IO\.ReadOnlyMemoryStream\.Seek\(long, System\.IO\.SeekOrigin\)\.offset') is greater than [System\.Int32\.MaxValue](https://learn.microsoft.com/en-us/dotnet/api/system.int32.maxvalue 'System\.Int32\.MaxValue')\.

[System\.IO\.IOException](https://learn.microsoft.com/en-us/dotnet/api/system.io.ioexception 'System\.IO\.IOException')  
Seeking is attempted before the beginning of the stream\.

[System\.ObjectDisposedException](https://learn.microsoft.com/en-us/dotnet/api/system.objectdisposedexception 'System\.ObjectDisposedException')  
The stream is closed\.

<a name='Louis.IO.ReadOnlyMemoryStream.SetLength(long)'></a>

## ReadOnlyMemoryStream\.SetLength\(long\) Method


Sets the length of the current stream to the specified value.

Since a [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream') cannot be written to,
            this method will always throw a [System\.NotSupportedException](https://learn.microsoft.com/en-us/dotnet/api/system.notsupportedexception 'System\.NotSupportedException').

```csharp
public override void SetLength(long value);
```
#### Parameters

<a name='Louis.IO.ReadOnlyMemoryStream.SetLength(long).value'></a>

`value` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The value at which to set the length\.

#### Exceptions

[System\.NotSupportedException](https://learn.microsoft.com/en-us/dotnet/api/system.notsupportedexception 'System\.NotSupportedException')  
Always thrown,
            because instances of [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream') are read\-only\.

<a name='Louis.IO.ReadOnlyMemoryStream.Write(byte[],int,int)'></a>

## ReadOnlyMemoryStream\.Write\(byte\[\], int, int\) Method


Writes a block of bytes to the current stream using data read from a buffer.

Since a [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream') cannot be written to,
            this method will always throw a [System\.NotSupportedException](https://learn.microsoft.com/en-us/dotnet/api/system.notsupportedexception 'System\.NotSupportedException').

```csharp
public override void Write(byte[] buffer, int offset, int count);
```
#### Parameters

<a name='Louis.IO.ReadOnlyMemoryStream.Write(byte[],int,int).buffer'></a>

`buffer` [System\.Byte](https://learn.microsoft.com/en-us/dotnet/api/system.byte 'System\.Byte')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The buffer to write data from\.

<a name='Louis.IO.ReadOnlyMemoryStream.Write(byte[],int,int).offset'></a>

`offset` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The zero\-based byte offset in [buffer](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.Write(byte[],int,int).buffer 'Louis\.IO\.ReadOnlyMemoryStream\.Write\(byte\[\], int, int\)\.buffer')
            at which to begin copying bytes to the current stream\.

<a name='Louis.IO.ReadOnlyMemoryStream.Write(byte[],int,int).count'></a>

`count` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of bytes to write\.

#### Exceptions

[System\.NotSupportedException](https://learn.microsoft.com/en-us/dotnet/api/system.notsupportedexception 'System\.NotSupportedException')  
Always thrown,
            because instances of [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream') are read\-only\.

<a name='Louis.IO.ReadOnlyMemoryStream.Write(System.ReadOnlySpan_byte_)'></a>

## ReadOnlyMemoryStream\.Write\(ReadOnlySpan\<byte\>\) Method


Writes a sequence of bytes into the current stream
            and advances the current position within this stream by the number of bytes written.

Since a [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream') cannot be written to,
            this method will always throw a [System\.NotSupportedException](https://learn.microsoft.com/en-us/dotnet/api/system.notsupportedexception 'System\.NotSupportedException').

```csharp
public override void Write(System.ReadOnlySpan<byte> buffer);
```
#### Parameters

<a name='Louis.IO.ReadOnlyMemoryStream.Write(System.ReadOnlySpan_byte_).buffer'></a>

`buffer` [System\.ReadOnlySpan&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')[System\.Byte](https://learn.microsoft.com/en-us/dotnet/api/system.byte 'System\.Byte')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1 'System\.ReadOnlySpan\`1')

A region of memory\.

#### Exceptions

[System\.NotSupportedException](https://learn.microsoft.com/en-us/dotnet/api/system.notsupportedexception 'System\.NotSupportedException')  
Always thrown,
            because instances of [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream') are read\-only\.

### Remarks

This method overrides the corresponding method of [System\.IO\.Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream 'System\.IO\.Stream') on runtimes where it is available
            (.NET Core 2.1 and newer, .NET 5 and newer, .NET Standard 2.1 and newer).
            On older runtimes, this method is present as a method of [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream')
            and depends on the `System.Memory` NuGet package.

<a name='Louis.IO.ReadOnlyMemoryStream.WriteAsync(byte[],int,int,System.Threading.CancellationToken)'></a>

## ReadOnlyMemoryStream\.WriteAsync\(byte\[\], int, int, CancellationToken\) Method


Asynchronously writes a sequence of bytes to the current stream,
            advances the current position within this stream by the number of bytes written, and monitors cancellation requests.

Since a [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream') cannot be written to,
            this method will always throw a [System\.NotSupportedException](https://learn.microsoft.com/en-us/dotnet/api/system.notsupportedexception 'System\.NotSupportedException').

```csharp
public override System.Threading.Tasks.Task WriteAsync(byte[] buffer, int offset, int count, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Louis.IO.ReadOnlyMemoryStream.WriteAsync(byte[],int,int,System.Threading.CancellationToken).buffer'></a>

`buffer` [System\.Byte](https://learn.microsoft.com/en-us/dotnet/api/system.byte 'System\.Byte')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The buffer to write data from\.

<a name='Louis.IO.ReadOnlyMemoryStream.WriteAsync(byte[],int,int,System.Threading.CancellationToken).offset'></a>

`offset` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The zero\-based byte offset in [buffer](Louis.IO.ReadOnlyMemoryStream.md#Louis.IO.ReadOnlyMemoryStream.WriteAsync(byte[],int,int,System.Threading.CancellationToken).buffer 'Louis\.IO\.ReadOnlyMemoryStream\.WriteAsync\(byte\[\], int, int, System\.Threading\.CancellationToken\)\.buffer')
            from which to begin copying bytes to the stream\.

<a name='Louis.IO.ReadOnlyMemoryStream.WriteAsync(byte[],int,int,System.Threading.CancellationToken).count'></a>

`count` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of bytes to write\.

<a name='Louis.IO.ReadOnlyMemoryStream.WriteAsync(byte[],int,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A task that represents the asynchronous write operation\.

#### Exceptions

[System\.NotSupportedException](https://learn.microsoft.com/en-us/dotnet/api/system.notsupportedexception 'System\.NotSupportedException')  
Always thrown,
            because instances of [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream') are read\-only\.

<a name='Louis.IO.ReadOnlyMemoryStream.WriteAsync(System.ReadOnlyMemory_byte_,System.Threading.CancellationToken)'></a>

## ReadOnlyMemoryStream\.WriteAsync\(ReadOnlyMemory\<byte\>, CancellationToken\) Method


Asynchronously writes a sequence of bytes into the current stream,
            advances the current position within this stream by the number of bytes written, and monitors cancellation requests.

Since a [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream') cannot be written to,
            this method will always throw a [System\.NotSupportedException](https://learn.microsoft.com/en-us/dotnet/api/system.notsupportedexception 'System\.NotSupportedException').

```csharp
public override System.Threading.Tasks.ValueTask WriteAsync(System.ReadOnlyMemory<byte> buffer, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Louis.IO.ReadOnlyMemoryStream.WriteAsync(System.ReadOnlyMemory_byte_,System.Threading.CancellationToken).buffer'></a>

`buffer` [System\.ReadOnlyMemory&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlymemory-1 'System\.ReadOnlyMemory\`1')[System\.Byte](https://learn.microsoft.com/en-us/dotnet/api/system.byte 'System\.Byte')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.readonlymemory-1 'System\.ReadOnlyMemory\`1')

The region of memory to write data from\.

<a name='Louis.IO.ReadOnlyMemoryStream.WriteAsync(System.ReadOnlyMemory_byte_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[System\.Threading\.Tasks\.ValueTask](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask 'System\.Threading\.Tasks\.ValueTask')  
A task that represents the asynchronous write operation\.

#### Exceptions

[System\.NotSupportedException](https://learn.microsoft.com/en-us/dotnet/api/system.notsupportedexception 'System\.NotSupportedException')  
Always thrown,
            because instances of [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream') are read\-only\.

### Remarks

This method overrides the corresponding method of [System\.IO\.Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream 'System\.IO\.Stream') on runtimes where it is available
            (.NET Core 2.1 and newer, .NET 5 and newer, .NET Standard 2.1 and newer).
            On older runtimes, this method is present as a method of [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream')
            and depends on the `System.Memory` NuGet package.

<a name='Louis.IO.ReadOnlyMemoryStream.WriteByte(byte)'></a>

## ReadOnlyMemoryStream\.WriteByte\(byte\) Method


Writes a byte to the current stream at the current position.

Since a [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream') cannot be written to,
            this method will always throw a [System\.NotSupportedException](https://learn.microsoft.com/en-us/dotnet/api/system.notsupportedexception 'System\.NotSupportedException').

```csharp
public override void WriteByte(byte value);
```
#### Parameters

<a name='Louis.IO.ReadOnlyMemoryStream.WriteByte(byte).value'></a>

`value` [System\.Byte](https://learn.microsoft.com/en-us/dotnet/api/system.byte 'System\.Byte')

The byte to write\.

#### Exceptions

[System\.NotSupportedException](https://learn.microsoft.com/en-us/dotnet/api/system.notsupportedexception 'System\.NotSupportedException')  
Always thrown,
            because instances of [ReadOnlyMemoryStream](Louis.IO.ReadOnlyMemoryStream.md 'Louis\.IO\.ReadOnlyMemoryStream') are read\-only\.