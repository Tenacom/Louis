// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections;
using Louis.Collections;

#pragma warning disable CA2000 // Dispose objects before losing scope - the method under test disposes every item
internal sealed class EnumerableExtensionsDisposeAllAsyncTests
{
    [Test]
    public async Task DisposeAllAsync_WithNullEnumerable_ThrowsArgumentNullException()
    {
        static async Task Act()
        {
            // ! Null on purpose: testing null detection
            await ((IEnumerable)null!).DisposeAllAsync();
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task DisposeAllAsync_WithNonDisposableItems_DoesNothing()
    {
        object?[] items = [null, new object(), "text"];

        async Task Act() => await items.DisposeAllAsync();

        await Assert.That(Act).ThrowsNothing();
    }

    [Test]
    public async Task DisposeAllAsync_WithDisposable_CallsDispose()
    {
        var disposable = new DisposableItem();
        object[] items = [disposable];

        await items.DisposeAllAsync();

        await Assert.That(disposable.DisposeCallCount).IsEqualTo(1);
    }

    [Test]
    public async Task DisposeAllAsync_WithAsyncDisposable_WaitsForDisposeAsyncCompletion()
    {
        var asyncDisposable = new AsyncDisposableItem();
        object[] items = [asyncDisposable];

        await items.DisposeAllAsync();

        await Assert.That(asyncDisposable.DisposeAsyncCallCount).IsEqualTo(1);
        await Assert.That(asyncDisposable.DisposeAsyncCompleted).IsTrue();
    }

    [Test]
    public async Task DisposeAllAsync_WithBothInterfaces_PrefersDisposeAsync()
    {
        var dualDisposable = new DualDisposableItem();
        object[] items = [dualDisposable];

        await items.DisposeAllAsync();

        await Assert.That(dualDisposable.DisposeAsyncCallCount).IsEqualTo(1);
        await Assert.That(dualDisposable.DisposeCallCount).IsEqualTo(0);
    }

    [Test]
    public async Task DisposeAllAsync_WhenDisposeThrows_ThrowsAggregateException()
    {
        Exception exception = new InvalidOperationException();
        object[] items = [new DisposableItem(exception)];

        async Task Act() => await items.DisposeAllAsync();

        await Assert.That(Act).Throws<AggregateException>()
            .WithInnerExceptions(inner => inner.IsEquivalentTo([exception], EqualityComparer<Exception>.Default));
    }

    [Test]
    public async Task DisposeAllAsync_WhenDisposeThrows_DisposesRemainingItems()
    {
        var disposable = new DisposableItem();
        object[] items = [new DisposableItem(new InvalidOperationException()), disposable];

        async Task Act() => await items.DisposeAllAsync();

        await Assert.That(Act).Throws<AggregateException>();
        await Assert.That(disposable.DisposeCallCount).IsEqualTo(1);
    }

    [Test]
    public async Task DisposeAllAsync_WhenSeveralDisposeCallsThrow_CollectsEveryException()
    {
        Exception first = new InvalidOperationException("first");
        Exception second = new InvalidOperationException("second");
        object[] items = [new DisposableItem(first), new DisposableItem(second)];

        async Task Act() => await items.DisposeAllAsync();

        await Assert.That(Act).Throws<AggregateException>()
            .WithInnerExceptions(inner => inner.IsEquivalentTo([first, second], EqualityComparer<Exception>.Default));
    }

    [Test]
    public async Task DisposeAllAsync_WhenDisposeAsyncThrows_ThrowsAggregateException()
    {
        Exception exception = new InvalidOperationException();
        object[] items = [new AsyncDisposableItem(exception)];

        async Task Act() => await items.DisposeAllAsync();

        await Assert.That(Act).Throws<AggregateException>()
            .WithInnerExceptions(inner => inner.IsEquivalentTo([exception], EqualityComparer<Exception>.Default));
    }

    [Test]
    public async Task DisposeAllAsync_WhenSeveralDisposeAsyncCallsThrow_CollectsEveryException()
    {
        Exception first = new InvalidOperationException("first");
        Exception second = new InvalidOperationException("second");
        object[] items = [new AsyncDisposableItem(first), new AsyncDisposableItem(second)];

        async Task Act() => await items.DisposeAllAsync();

        await Assert.That(Act).Throws<AggregateException>()
            .WithInnerExceptions(inner => inner.IsEquivalentTo([first, second], EqualityComparer<Exception>.Default));
    }

    [Test]
    public async Task DisposeAllAsync_WhenDisposeThrowsAndDisposeAsyncIsPending_ThrowsAggregateException()
    {
        Exception exception = new InvalidOperationException();
        var asyncDisposable = new AsyncDisposableItem();
        object[] items = [new DisposableItem(exception), asyncDisposable];

        async Task Act() => await items.DisposeAllAsync();

        await Assert.That(Act).Throws<AggregateException>()
            .WithInnerExceptions(inner => inner.IsEquivalentTo([exception], EqualityComparer<Exception>.Default));
        await Assert.That(asyncDisposable.DisposeAsyncCompleted).IsTrue();
    }

    [Test]
    public async Task DisposeAllAsync_WhenDisposeAndDisposeAsyncThrow_CollectsEveryException()
    {
        Exception first = new InvalidOperationException("first");
        Exception second = new InvalidOperationException("second");
        object[] items = [new DisposableItem(first), new AsyncDisposableItem(second)];

        async Task Act() => await items.DisposeAllAsync();

        await Assert.That(Act).Throws<AggregateException>()
            .WithInnerExceptions(inner => inner.IsEquivalentTo([first, second], EqualityComparer<Exception>.Default));
    }

    [Test]
    public async Task DisposeAllAsync_WhenDisposeThrowsCriticalError_ThrowsIt()
    {
        object[] items = [new DisposableItem(new InvalidProgramException())];

        async Task Act() => await items.DisposeAllAsync();

        await Assert.That(Act).Throws<InvalidProgramException>();
    }

    [Test]
    public async Task DisposeAllAsync_WhenDisposeAsyncThrowsCriticalError_ThrowsIt()
    {
        object[] items = [new AsyncDisposableItem(new InvalidProgramException())];

        async Task Act() => await items.DisposeAllAsync();

        await Assert.That(Act).Throws<InvalidProgramException>();
    }
}
