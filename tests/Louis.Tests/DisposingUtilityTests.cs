// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis;

#pragma warning disable CA1849 // Call async methods when in an async method - the synchronous Dispose overloads are the methods under test
internal sealed class DisposingUtilityTests
{
    [Test]
    public async Task DisposeAsync_WithNull_ReturnsCompletedTask()
    {
        var task = DisposingUtility.DisposeAsync((object?)null);

        await Assert.That(task.IsCompletedSuccessfully).IsTrue();
    }

    [Test]
    public async Task DisposeAsync_WithNonDisposable_ReturnsCompletedTask()
    {
        var task = DisposingUtility.DisposeAsync(new object());

        await Assert.That(task.IsCompletedSuccessfully).IsTrue();
    }

    [Test]
    public async Task DisposeAsync_WithDisposable_CallsDispose()
    {
        using var disposable = new TestDisposable();

        var task = DisposingUtility.DisposeAsync(disposable);

        await Assert.That(task.IsCompletedSuccessfully).IsTrue();
        await Assert.That(disposable.DisposeCallCount).IsEqualTo(1);
    }

    [Test]
    public async Task DisposeAsync_WithAsyncDisposable_ReturnsDisposeAsyncTask()
    {
        await using var disposable = new TestAsyncDisposable();

        await DisposingUtility.DisposeAsync(disposable);

        await Assert.That(disposable.DisposeAsyncCallCount).IsEqualTo(1);
        await Assert.That(disposable.DisposeAsyncCompleted).IsTrue();
    }

    [Test]
    public async Task DisposeAsync_WithBothInterfaces_PrefersDisposeAsync()
    {
        await using var disposable = new TestDualDisposable();

        await DisposingUtility.DisposeAsync(disposable);

        await Assert.That(disposable.DisposeAsyncCallCount).IsEqualTo(1);
        await Assert.That(disposable.DisposeCallCount).IsEqualTo(0);
    }

    [Test]
    public async Task Dispose_WithNull_DoesNothing()
    {
        static void Act() => DisposingUtility.Dispose((object?)null);

        await Assert.That(Act).ThrowsNothing();
    }

    [Test]
    public async Task Dispose_WithNonDisposable_DoesNothing()
    {
        static void Act() => DisposingUtility.Dispose(new object());

        await Assert.That(Act).ThrowsNothing();
    }

    [Test]
    public async Task Dispose_WithDisposable_CallsDispose()
    {
        using var disposable = new TestDisposable();

        DisposingUtility.Dispose(disposable);

        await Assert.That(disposable.DisposeCallCount).IsEqualTo(1);
    }

    [Test]
    public async Task Dispose_WithAsyncDisposable_WaitsForDisposeAsyncCompletion()
    {
        await using var disposable = new TestAsyncDisposable();

        DisposingUtility.Dispose(disposable);

        await Assert.That(disposable.DisposeAsyncCallCount).IsEqualTo(1);
        await Assert.That(disposable.DisposeAsyncCompleted).IsTrue();
    }

    [Test]
    public async Task Dispose_WithBothInterfaces_PrefersDispose()
    {
        await using var disposable = new TestDualDisposable();

        DisposingUtility.Dispose(disposable);

        await Assert.That(disposable.DisposeCallCount).IsEqualTo(1);
        await Assert.That(disposable.DisposeAsyncCallCount).IsEqualTo(0);
    }

    [Test]
    public async Task DisposeAsync_WithNullArray_ThrowsArgumentNullException()
    {
        static async Task Act()
        {
            // ! Null on purpose: testing null detection
            await DisposingUtility.DisposeAsync(null!);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("items");
    }

    [Test]
    public async Task DisposeAsync_WithMixedItems_DisposesEveryItem()
    {
        using var disposable = new TestDisposable();
        await using var asyncDisposable = new TestAsyncDisposable();
        await using var dualDisposable = new TestDualDisposable();

        await DisposingUtility.DisposeAsync(null, new object(), disposable, asyncDisposable, dualDisposable);

        await Assert.That(disposable.DisposeCallCount).IsEqualTo(1);
        await Assert.That(asyncDisposable.DisposeAsyncCompleted).IsTrue();
        await Assert.That(dualDisposable.DisposeAsyncCallCount).IsEqualTo(1);
        await Assert.That(dualDisposable.DisposeCallCount).IsEqualTo(0);
    }

    [Test]
    public async Task Dispose_WithNullArray_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            DisposingUtility.Dispose(null!);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("items");
    }

    [Test]
    public async Task Dispose_WithMixedItems_DisposesEveryItem()
    {
        using var disposable = new TestDisposable();
        await using var asyncDisposable = new TestAsyncDisposable();
        await using var dualDisposable = new TestDualDisposable();

        DisposingUtility.Dispose(null, new object(), disposable, asyncDisposable, dualDisposable);

        await Assert.That(disposable.DisposeCallCount).IsEqualTo(1);
        await Assert.That(asyncDisposable.DisposeAsyncCompleted).IsTrue();
        await Assert.That(dualDisposable.DisposeCallCount).IsEqualTo(1);
        await Assert.That(dualDisposable.DisposeAsyncCallCount).IsEqualTo(0);
    }
}
