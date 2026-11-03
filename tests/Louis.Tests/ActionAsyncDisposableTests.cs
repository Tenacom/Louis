// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis;

#pragma warning disable CA1849 // Call async methods when in an async method - the synchronous Dispose is the method under test
internal sealed class ActionAsyncDisposableTests
{
    [Test]
    public async Task Constructor_WithNullCallback_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            using var disposable = new ActionAsyncDisposable(null!);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("onDisposeAsync");
    }

    [Test]
    public async Task Dispose_WaitsForCallbackCompletion()
    {
        var completed = false;
        var disposable = new ActionAsyncDisposable(async () =>
        {
            await Task.Yield();
            completed = true;
        });

        disposable.Dispose();

        await Assert.That(completed).IsTrue();
    }

    [Test]
    public async Task Dispose_WhenCalledAgain_DoesNothing()
    {
        var callCount = 0;
        var disposable = new ActionAsyncDisposable(() =>
        {
            callCount++;
            return default;
        });
        disposable.Dispose();

        disposable.Dispose();

        await Assert.That(callCount).IsEqualTo(1);
    }

    [Test]
    public async Task Dispose_AfterDisposeAsync_DoesNothing()
    {
        var callCount = 0;
        var disposable = new ActionAsyncDisposable(() =>
        {
            callCount++;
            return default;
        });
        await disposable.DisposeAsync();

        disposable.Dispose();

        await Assert.That(callCount).IsEqualTo(1);
    }

    [Test]
    public async Task DisposeAsync_ReturnsCallbackTask()
    {
        var completion = new TaskCompletionSource<bool>();
        var disposable = new ActionAsyncDisposable(() => new ValueTask(completion.Task));

        var task = disposable.DisposeAsync();

        await Assert.That(task.IsCompleted).IsFalse();
        completion.SetResult(true);
        await task;
    }

    [Test]
    public async Task DisposeAsync_WhenCalledAgain_DoesNothing()
    {
        var callCount = 0;
        var disposable = new ActionAsyncDisposable(() =>
        {
            callCount++;
            return default;
        });
        await disposable.DisposeAsync();

        var task = disposable.DisposeAsync();

        await Assert.That(task.IsCompletedSuccessfully).IsTrue();
        await Assert.That(callCount).IsEqualTo(1);
    }

    [Test]
    public async Task DisposeAsync_AfterDispose_DoesNothing()
    {
        var callCount = 0;
        var disposable = new ActionAsyncDisposable(() =>
        {
            callCount++;
            return default;
        });
        disposable.Dispose();

        var task = disposable.DisposeAsync();

        await Assert.That(task.IsCompletedSuccessfully).IsTrue();
        await Assert.That(callCount).IsEqualTo(1);
    }
}
