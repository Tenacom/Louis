// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;
using Microsoft.Extensions.Time.Testing;

[InheritsTests]
internal sealed class TaskExtensionsDeadlineGenericTaskTests : TaskExtensionsDeadlineTestsBase
{
    [Test]
    public async Task WaitAsync_ReturnsTheResultOfTheTask(CancellationToken cancellationToken)
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);
        var source = new TaskCompletionSource<int>();

        var wait = source.Task.WaitAsync(deadline, cancellationToken);
        source.SetResult(42);

        await Assert.That(await wait).IsEqualTo(42);
    }

    protected override Task WaitAsync(Task<int> task, Deadline deadline, CancellationToken cancellationToken)
        => task.WaitAsync(deadline, cancellationToken);
}
