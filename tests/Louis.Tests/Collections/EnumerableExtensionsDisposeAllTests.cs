// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections;
using Louis.Collections;

#pragma warning disable CA1849 // Call async methods when in an async method - the synchronous DisposeAll is the method under test
#pragma warning disable CA2000 // Dispose objects before losing scope - the method under test disposes every item
internal sealed class EnumerableExtensionsDisposeAllTests
{
    [Test]
    public async Task DisposeAll_WithNullEnumerable_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static void Act() => ((IEnumerable)null!).DisposeAll();

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task DisposeAll_WithNonDisposableItems_DoesNothing()
    {
        object?[] items = [null, new object(), "text"];

        void Act() => items.DisposeAll();

        await Assert.That(Act).ThrowsNothing();
    }

    [Test]
    public async Task DisposeAll_WithDisposable_CallsDispose()
    {
        var disposable = new DisposableItem();
        object[] items = [disposable];

        items.DisposeAll();

        await Assert.That(disposable.DisposeCallCount).IsEqualTo(1);
    }

    [Test]
    public async Task DisposeAll_WithAsyncDisposable_WaitsForDisposeAsyncCompletion()
    {
        var asyncDisposable = new AsyncDisposableItem();
        object[] items = [asyncDisposable];

        items.DisposeAll();

        await Assert.That(asyncDisposable.DisposeAsyncCallCount).IsEqualTo(1);
        await Assert.That(asyncDisposable.DisposeAsyncCompleted).IsTrue();
    }

    [Test]
    public async Task DisposeAll_WithBothInterfaces_PrefersDispose()
    {
        var dualDisposable = new DualDisposableItem();
        object[] items = [dualDisposable];

        items.DisposeAll();

        await Assert.That(dualDisposable.DisposeCallCount).IsEqualTo(1);
        await Assert.That(dualDisposable.DisposeAsyncCallCount).IsEqualTo(0);
    }

    [Test]
    public async Task DisposeAll_WhenDisposeThrows_ThrowsAggregateException()
    {
        Exception exception = new InvalidOperationException();
        object[] items = [new DisposableItem(exception)];

        void Act() => items.DisposeAll();

        await Assert.That(Act).Throws<AggregateException>()
            .WithInnerExceptions(inner => inner.IsEquivalentTo([exception], EqualityComparer<Exception>.Default));
    }

    [Test]
    public async Task DisposeAll_WhenDisposeThrows_DisposesRemainingItems()
    {
        var disposable = new DisposableItem();
        object[] items = [new DisposableItem(new InvalidOperationException()), disposable];

        void Act() => items.DisposeAll();

        await Assert.That(Act).Throws<AggregateException>();
        await Assert.That(disposable.DisposeCallCount).IsEqualTo(1);
    }

    [Test]
    public async Task DisposeAll_WhenSeveralDisposeCallsThrow_CollectsEveryException()
    {
        Exception first = new InvalidOperationException("first");
        Exception second = new InvalidOperationException("second");
        object[] items = [new DisposableItem(first), new DisposableItem(second)];

        void Act() => items.DisposeAll();

        await Assert.That(Act).Throws<AggregateException>()
            .WithInnerExceptions(inner => inner.IsEquivalentTo([first, second], EqualityComparer<Exception>.Default));
    }

    [Test]
    public async Task DisposeAll_WhenDisposeAsyncThrows_ThrowsAggregateException()
    {
        Exception exception = new InvalidOperationException();
        object[] items = [new AsyncDisposableItem(exception)];

        void Act() => items.DisposeAll();

        await Assert.That(Act).Throws<AggregateException>()
            .WithInnerExceptions(inner => inner.IsEquivalentTo([exception], EqualityComparer<Exception>.Default));
    }

    [Test]
    public async Task DisposeAll_WhenSeveralDisposeAsyncCallsThrow_CollectsEveryException()
    {
        Exception first = new InvalidOperationException("first");
        Exception second = new InvalidOperationException("second");
        object[] items = [new AsyncDisposableItem(first), new AsyncDisposableItem(second)];

        void Act() => items.DisposeAll();

        await Assert.That(Act).Throws<AggregateException>()
            .WithInnerExceptions(inner => inner.IsEquivalentTo([first, second], EqualityComparer<Exception>.Default));
    }

    [Test]
    public async Task DisposeAll_WhenDisposeThrowsAndDisposeAsyncIsPending_ThrowsAggregateException()
    {
        Exception exception = new InvalidOperationException();
        var asyncDisposable = new AsyncDisposableItem();
        object[] items = [new DisposableItem(exception), asyncDisposable];

        void Act() => items.DisposeAll();

        await Assert.That(Act).Throws<AggregateException>()
            .WithInnerExceptions(inner => inner.IsEquivalentTo([exception], EqualityComparer<Exception>.Default));
        await Assert.That(asyncDisposable.DisposeAsyncCompleted).IsTrue();
    }

    [Test]
    public async Task DisposeAll_WhenDisposeAndDisposeAsyncThrow_CollectsEveryException()
    {
        Exception first = new InvalidOperationException("first");
        Exception second = new InvalidOperationException("second");
        object[] items = [new DisposableItem(first), new AsyncDisposableItem(second)];

        void Act() => items.DisposeAll();

        await Assert.That(Act).Throws<AggregateException>()
            .WithInnerExceptions(inner => inner.IsEquivalentTo([first, second], EqualityComparer<Exception>.Default));
    }

    [Test]
    public async Task DisposeAll_WhenDisposeThrowsCriticalError_ThrowsIt()
    {
        object[] items = [new DisposableItem(new InvalidProgramException())];

        void Act() => items.DisposeAll();

        await Assert.That(Act).Throws<InvalidProgramException>();
    }

    [Test]
    public async Task DisposeAll_WhenDisposeAsyncThrowsCriticalError_ThrowsIt()
    {
        object[] items = [new AsyncDisposableItem(new InvalidProgramException())];

        void Act() => items.DisposeAll();

        await Assert.That(Act).Throws<InvalidProgramException>();
    }
}
