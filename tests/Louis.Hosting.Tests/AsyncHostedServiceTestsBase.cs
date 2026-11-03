// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

// Owns the logger and the service of a test. The disposal of a started service waits for it to stop, so the disposal
// of the test releases the gates the test may still hold. A failed test then reports its failure instead of a timeout.
internal abstract class AsyncHostedServiceTestsBase : IAsyncDisposable
{
    protected AsyncHostedServiceTestsBase()
    {
        Logger = new RecordingLogger();
        Service = new TestAsyncHostedService(Logger);
    }

    protected RecordingLogger Logger { get; }

    protected TestAsyncHostedService Service { get; }

    public async ValueTask DisposeAsync()
    {
        var disposeTask = Service.DisposeAsync();
        Service.ReleaseGates();
        await disposeTask;
    }
}
