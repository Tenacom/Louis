// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis;

internal sealed class AsyncDisposableExtensionsTests
{
    [Test]
    public async Task DisposeSynchronously_WithNullThis_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            AsyncDisposableExtensions.DisposeSynchronously(null!);
        }

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task DisposeSynchronously_WaitsForDisposeAsyncCompletion()
    {
        await using var disposable = new TestAsyncDisposable();

        disposable.DisposeSynchronously();

        await Assert.That(disposable.DisposeAsyncCallCount).IsEqualTo(1);
        await Assert.That(disposable.DisposeAsyncCompleted).IsTrue();
    }
}
