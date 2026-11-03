// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;
using TUnit.Assertions.Enums;

[Timeout(10_000)]
internal sealed class AsyncServiceStopTests : AsyncServiceTestsBase
{
    [Test]
    public async Task Stop_BeforeStart_PreventsStartAndReturnsFalse(CancellationToken cancellationToken)
    {
        var result = Service.Stop();

        await Assert.That(result).IsFalse();
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        var setupResult = await Service.WaitUntilStartedAsync();
        await Assert.That(setupResult).IsEqualTo(AsyncServiceSetupResult.NotStarted);
        await Assert.That(Service.WaitUntilStoppedAsync().IsCompleted).IsTrue();
        string[] expectedCalls = ["LogStateChanged(Created, Stopped)", "LogStopRequested(Created, Stopped, False)"];
        await Assert.That(Service.Calls).IsEquivalentTo(expectedCalls, CollectionOrdering.Matching);
    }

    [Test]
    public async Task Stop_DuringSetup_CancelsSetupTokenAndReturnsTrue(CancellationToken cancellationToken)
    {
        var runTask = Service.RunAsync(cancellationToken);
        await Service.SetupEntered;

        var result = Service.Stop();

        await Assert.That(result).IsTrue();
        await Assert.That(Service.SetupToken.IsCancellationRequested).IsTrue();
        await Assert.That(Service.Calls).Contains("LogStopRequested(Starting, Starting, True)");

        Service.SetupGate.SetException(new OperationCanceledException(Service.SetupToken));
        await runTask;

        var setupResult = await Service.WaitUntilStartedAsync();
        await Assert.That(setupResult).IsEqualTo(AsyncServiceSetupResult.Canceled);
        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
    }

    [Test]
    public async Task Stop_DuringExecution_CancelsExecuteTokenAndReturnsTrue(CancellationToken cancellationToken)
    {
        Service.SetupGate.SetResult(true);
        Service.TeardownGate.SetResult(true);
        var runTask = Service.RunAsync(cancellationToken);
        await Service.ExecuteEntered;

        var result = Service.Stop();

        await Assert.That(result).IsTrue();
        await Assert.That(Service.ExecuteToken.IsCancellationRequested).IsTrue();
        await Assert.That(Service.Calls).Contains("LogStopRequested(Running, Running, True)");

        Service.ExecuteGate.SetException(new OperationCanceledException(Service.ExecuteToken));
        await runTask;

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
        await Assert.That(Service.Calls).Contains("LogExecuteCanceled");
    }

    [Test]
    public async Task Stop_DuringTeardown_ReturnsTrue(CancellationToken cancellationToken)
    {
        Service.SetupGate.SetResult(true);
        Service.ExecuteGate.SetResult(true);
        var runTask = Service.RunAsync(cancellationToken);
        await Service.TeardownEntered;

        var result = Service.Stop();

        await Assert.That(result).IsTrue();
        await Assert.That(Service.Calls).Contains("LogStopRequested(Stopping, Stopping, True)");

        Service.TeardownGate.SetResult(true);
        await runTask;

        await Assert.That(Service.State).IsEqualTo(AsyncServiceState.Stopped);
    }

    [Test]
    public async Task Stop_AfterServiceStopped_ReturnsFalse(CancellationToken cancellationToken)
    {
        Service.SetupGate.SetResult(true);
        Service.ExecuteGate.SetResult(true);
        Service.TeardownGate.SetResult(true);
        await Service.RunAsync(cancellationToken);

        var result = Service.Stop();

        await Assert.That(result).IsFalse();
        await Assert.That(Service.Calls).Contains("LogStopRequested(Stopped, Stopped, False)");
    }

    [Test]
    public async Task Stop_AfterDispose_ReturnsFalse(CancellationToken cancellationToken)
    {
        await Service.DisposeAsync();

        var result = Service.Stop();

        await Assert.That(result).IsFalse();
        await Assert.That(Service.Calls).Contains("LogStopRequested(Disposed, Disposed, False)");
    }
}
