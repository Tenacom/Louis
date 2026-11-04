// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;

[Timeout(10_000)]
internal sealed class AsyncServiceDisposeTests : AsyncServiceTestsBase
{
    [Test]
    public async Task Dispose_BeforeStart_DisposesResources(CancellationToken cancellationToken)
    {
#pragma warning disable CA1849 // Call async methods when in an async method - Dispose is the method under test
        Service.Dispose();
#pragma warning restore CA1849 // Call async methods when in an async method

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Disposed);
        await Assert.That(Service.DisposeResourcesCalls).IsEqualTo(1);
        await Assert.That(Service.Calls).Contains("DisposeResourcesAsync");
    }

    [Test]
    public async Task Dispose_WhileRunning_StopsServiceAndWaitsForIt(CancellationToken cancellationToken)
    {
        Service.SetupGate.SetResult(true);
        Service.TeardownGate.SetResult(true);
        var runTask = Service.RunAsync(cancellationToken);
        await Service.ExecuteEntered;

        // Dispose blocks the test thread, so the stop request itself opens the execution gate.
        var executeGate = Service.ExecuteGate;
        var executeToken = Service.ExecuteToken;
        void CancelExecution() => _ = executeGate.TrySetException(new OperationCanceledException(executeToken));

#if NETSTANDARD2_1 || NETCOREAPP
        // CancellationTokenRegistration has no DisposeAsync before .NET Standard 2.1
        await
#endif
        using var registration = executeToken.Register(CancelExecution);

#pragma warning disable CA1849 // Call async methods when in an async method - Dispose is the method under test
        Service.Dispose();
#pragma warning restore CA1849 // Call async methods when in an async method

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Disposed);
        await Assert.That(Service.DisposeResourcesCalls).IsEqualTo(1);
        await Assert.That(Service.Calls).Contains("LogExecuteCanceled");
        await Assert.That(Service.Calls).Contains("LogTeardownCompleted");
        await runTask;
    }

    [Test]
    public async Task Dispose_ThenDisposeAsync_DisposesResourcesOnce(CancellationToken cancellationToken)
    {
#pragma warning disable CA1849 // Call async methods when in an async method - Dispose is the method under test
        Service.Dispose();
#pragma warning restore CA1849 // Call async methods when in an async method

        await Service.DisposeAsync();

        await Assert.That(Service.DisposeResourcesCalls).IsEqualTo(1);
    }
}
