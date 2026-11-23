// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;
using Microsoft.Extensions.Time.Testing;

/// <summary>
/// Holds the tests that the two <c>WaitAsync</c> methods of <see cref="Louis.Threading.TaskExtensions"/> share.
/// A derived class says which of the two methods <see cref="WaitAsync"/> calls.
/// </summary>
[Timeout(10_000)]
internal abstract class TaskExtensionsDeadlineTestsBase
{
    [Test]
    public async Task WaitAsync_OnANullTask_ThrowsArgumentNullException(CancellationToken cancellationToken)
    {
        // ! Null on purpose: testing null detection
        void Act() => _ = WaitAsync(null!, Deadline.Eternal, cancellationToken);

        await Assert.That(Act).Throws<ArgumentNullException>().WithParameterName("this");
    }

    [Test]
    public async Task WaitAsync_CompletesWhenTheTaskCompletes(CancellationToken cancellationToken)
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);
        var source = new TaskCompletionSource<int>();

        var wait = WaitAsync(source.Task, deadline, cancellationToken);
        clock.Advance(TimeSpan.FromSeconds(3));

        await Assert.That(wait.IsCompleted).IsFalse();

        source.SetResult(42);
        await wait;
    }

    [Test]
    public async Task WaitAsync_UntilEternal_CompletesWhenTheTaskCompletes(CancellationToken cancellationToken)
    {
        var source = new TaskCompletionSource<int>();

        var wait = WaitAsync(source.Task, Deadline.Eternal, cancellationToken);

        await Assert.That(wait.IsCompleted).IsFalse();

        source.SetResult(42);
        await wait;
    }

    [Test]
    public async Task WaitAsync_WhenTheTaskFails_ThrowsItsException(CancellationToken cancellationToken)
    {
        const string Message = "The operation failed.";

        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);
        var source = new TaskCompletionSource<int>();

        var wait = WaitAsync(source.Task, deadline, cancellationToken);
        source.SetException(new InvalidOperationException(Message));

        await Assert.That(() => wait).Throws<InvalidOperationException>().WithMessage(Message, StringComparison.Ordinal);
    }

    [Test]
    public async Task WaitAsync_WhenTheTaskIsCanceled_ThrowsOperationCanceledException(CancellationToken cancellationToken)
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);
        var source = new TaskCompletionSource<int>();

        var wait = WaitAsync(source.Task, deadline, cancellationToken);
        _ = source.TrySetCanceled(CancellationToken.None);

        _ = await Assert.That(() => wait).Throws<OperationCanceledException>();
        await Assert.That(wait.IsCanceled).IsTrue();
    }

    [Test]
    public async Task WaitAsync_WhenTheDeadlineExpiresBeforeTheTaskCompletes_ThrowsTimeoutException(
        CancellationToken cancellationToken)
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);
        var source = new TaskCompletionSource<int>();

        var wait = WaitAsync(source.Task, deadline, cancellationToken);
        clock.Advance(TimeSpan.FromMilliseconds(4_999));

        await Assert.That(wait.IsCompleted).IsFalse();

        clock.Advance(TimeSpan.FromMilliseconds(1));

        _ = await Assert.That(() => wait).Throws<TimeoutException>();
    }

    // Each row: the ticks to the deadline, and the milliseconds after which the wait gives up.
    [Test]
    [Arguments(1L, 1)]
    [Arguments(9_999L, 1)]
    [Arguments(10_000L, 1)]
    [Arguments(10_001L, 2)]
    [Arguments(50_000L, 5)]
    public async Task WaitAsync_RoundsTheRemainingTimeUpToAMillisecond(
        long ticks,
        int expectedMilliseconds,
        CancellationToken cancellationToken)
    {
        var oneTick = new TimeSpan(1);
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(new TimeSpan(ticks), clock);
        var source = new TaskCompletionSource<int>();

        var wait = WaitAsync(source.Task, deadline, cancellationToken);
        clock.Advance(TimeSpan.FromMilliseconds(expectedMilliseconds) - oneTick);

        await Assert.That(wait.IsCompleted).IsFalse();

        clock.Advance(oneTick);

        _ = await Assert.That(() => wait).Throws<TimeoutException>();
    }

    [Test]
    public async Task WaitAsync_WithInt32MaxValueMillisecondsRemaining_ThrowsTimeoutExceptionWhenTheDeadlineExpires(
        CancellationToken cancellationToken)
    {
        var duration = TimeSpan.FromMilliseconds(int.MaxValue);
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(duration, clock);
        var source = new TaskCompletionSource<int>();

        var wait = WaitAsync(source.Task, deadline, cancellationToken);
        clock.Advance(duration);

        _ = await Assert.That(() => wait).Throws<TimeoutException>();
    }

    [Test]
    public async Task WaitAsync_WithMoreThanInt32MaxValueMillisecondsRemaining_WaitsForTheTaskAfterTheDeadlineExpires(
        CancellationToken cancellationToken)
    {
        var duration = TimeSpan.FromMilliseconds(int.MaxValue) + new TimeSpan(1);
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(duration, clock);
        var source = new TaskCompletionSource<int>();

        var wait = WaitAsync(source.Task, deadline, cancellationToken);
        clock.Advance(TimeSpan.FromDays(60));

        await Assert.That(deadline.HasExpired).IsTrue();
        await Assert.That(wait.IsCompleted).IsFalse();

        source.SetResult(42);
        await wait;
    }

    [Test]
    public async Task WaitAsync_UntilExpired_ThrowsTimeoutException(CancellationToken cancellationToken)
    {
        var source = new TaskCompletionSource<int>();

        var wait = WaitAsync(source.Task, Deadline.Expired, cancellationToken);

        await Assert.That(wait.IsFaulted).IsTrue();
        _ = await Assert.That(() => wait).Throws<TimeoutException>();
    }

    // Each row: the seconds to the deadline, and the seconds the clock advances before the call.
    [Test]
    [Arguments(0, 0)]
    [Arguments(5, 5)]
    [Arguments(5, 8)]
    public async Task WaitAsync_UntilADeadlineThatHasExpiredOnAClock_ThrowsTimeoutException(
        int seconds,
        int elapsedSeconds,
        CancellationToken cancellationToken)
    {
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(seconds), clock);
        var source = new TaskCompletionSource<int>();
        clock.Advance(TimeSpan.FromSeconds(elapsedSeconds));

        var wait = WaitAsync(source.Task, deadline, cancellationToken);

        await Assert.That(wait.IsFaulted).IsTrue();
        _ = await Assert.That(() => wait).Throws<TimeoutException>();
    }

    [Test]
    public async Task WaitAsync_WhenTheTokenIsCanceledBeforeTheWaitEnds_ThrowsOperationCanceledException(
        CancellationToken cancellationToken)
    {
        using var tokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        var clock = new FakeTimeProvider();
        var deadline = Deadline.SetIn(TimeSpan.FromSeconds(5), clock);
        var source = new TaskCompletionSource<int>();

        var wait = WaitAsync(source.Task, deadline, tokenSource.Token);
        clock.Advance(TimeSpan.FromSeconds(3));

        await Assert.That(wait.IsCompleted).IsFalse();

        await CancelAsync(tokenSource);

        _ = await Assert.That(() => wait).Throws<OperationCanceledException>();
        await Assert.That(wait.IsCanceled).IsTrue();
    }

    [Test]
    public async Task WaitAsync_WithACanceledToken_ReturnsACanceledTask(CancellationToken cancellationToken)
    {
        var clock = new FakeTimeProvider();
        var canceledToken = new CancellationToken(canceled: true);
        var source = new TaskCompletionSource<int>();

        var waitUntilEternal = WaitAsync(source.Task, Deadline.Eternal, canceledToken);
        var waitOnClock = WaitAsync(source.Task, Deadline.SetIn(TimeSpan.FromSeconds(5), clock), canceledToken);

        await Assert.That(waitUntilEternal.IsCanceled).IsTrue();
        await Assert.That(waitOnClock.IsCanceled).IsTrue();
    }

    [Test]
    public async Task WaitAsync_UntilAnExpiredDeadline_WithACanceledToken_ReturnsACanceledTask(
        CancellationToken cancellationToken)
    {
        var clock = new FakeTimeProvider();
        var canceledToken = new CancellationToken(canceled: true);
        var source = new TaskCompletionSource<int>();

        var waitUntilExpired = WaitAsync(source.Task, Deadline.Expired, canceledToken);
        var waitOnClock = WaitAsync(source.Task, Deadline.SetIn(TimeSpan.Zero, clock), canceledToken);

        await Assert.That(waitUntilExpired.IsCanceled).IsTrue();
        await Assert.That(waitOnClock.IsCanceled).IsTrue();
    }

    [Test]
    public async Task WaitAsync_OnACompletedTask_ReturnsACompletedTask(CancellationToken cancellationToken)
    {
        var canceledToken = new CancellationToken(canceled: true);
        var task = Task.FromResult(42);

        var wait = WaitAsync(task, Deadline.Expired, canceledToken);

        await Assert.That(wait.Status).IsEqualTo(TaskStatus.RanToCompletion);
    }

    /// <summary>
    /// Calls the method under test on a task.
    /// </summary>
    /// <param name="task">The task to wait for. A derived class passes it as the type that its method extends.</param>
    /// <param name="deadline">The deadline at which the wait gives up.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that, when signaled, ends the wait.</param>
    /// <returns>The task that the method under test returns.</returns>
    protected abstract Task WaitAsync(Task<int> task, Deadline deadline, CancellationToken cancellationToken);

    private static Task CancelAsync(CancellationTokenSource tokenSource)
    {
#if NETFRAMEWORK
        // .NET Framework has no CancellationTokenSource.CancelAsync.
        tokenSource.Cancel();
        return Task.CompletedTask;
#else
        return tokenSource.CancelAsync();
#endif
    }
}
