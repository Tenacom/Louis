// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;

internal sealed class ValueTaskUtilityTests
{
    [Test]
    public async Task WhenAll_WithNullArray_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static async Task Act() => await ValueTaskUtility.WhenAll(null!);

        var exception = await Assert.That(Act).Throws<ArgumentNullException>();
        await Assert.That(exception?.ParamName).IsEqualTo("valueTasks");
    }

    [Test]
    public async Task WhenAll_WithNullEnumerable_ThrowsArgumentNullException()
    {
        // ! Null on purpose: testing null detection
        static async Task Act() => await ValueTaskUtility.WhenAll((IEnumerable<ValueTask>)null!);

        var exception = await Assert.That(Act).Throws<ArgumentNullException>();
        await Assert.That(exception?.ParamName).IsEqualTo("valueTasks");
    }

    [Test]
    public async Task WhenAll_WithNoTasks_CompletesSynchronously()
    {
        var result = ValueTaskUtility.WhenAll();

        await Assert.That(result.IsCompletedSuccessfully).IsTrue();
        await result;
    }

    [Test]
    public async Task WhenAll_WithEmptyEnumerable_CompletesSynchronously()
    {
        var result = ValueTaskUtility.WhenAll(Enumerable.Empty<ValueTask>());

        await Assert.That(result.IsCompletedSuccessfully).IsTrue();
        await result;
    }

    [Test]
    public async Task WhenAll_WithCompletedTasks_CompletesSynchronously()
    {
        var result = ValueTaskUtility.WhenAll(default, new ValueTask(Task.CompletedTask));

        await Assert.That(result.IsCompletedSuccessfully).IsTrue();
        await result;
    }

    [Test]
    public async Task WhenAll_WithPendingTasks_CompletesWhenAllComplete()
    {
        var first = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var second = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        var result = ValueTaskUtility.WhenAll(new ValueTask(first.Task), default, new ValueTask(second.Task)).AsTask();

        await Assert.That(result.IsCompleted).IsFalse();

        first.SetResult(true);

        await Assert.That(result.IsCompleted).IsFalse();

        second.SetResult(true);
        await result;
    }

    [Test]
    public async Task WhenAll_WithPendingEnumerable_CompletesWhenAllComplete()
    {
        var first = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var second = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        ValueTask[] valueTasks = [new ValueTask(first.Task), default, new ValueTask(second.Task)];

        var result = ValueTaskUtility.WhenAll(valueTasks.AsEnumerable()).AsTask();

        await Assert.That(result.IsCompleted).IsFalse();

        first.SetResult(true);
        second.SetResult(true);
        await result;
    }

    [Test]
    public async Task WhenAll_WithFaultedTask_Faults()
    {
        var exception = new InvalidOperationException("Task failed.");
        var faulted = new ValueTask(Task.FromException(exception));

        var thrown = await Assert.That(async () => await ValueTaskUtility.WhenAll(default, faulted)).Throws<InvalidOperationException>();

        await Assert.That(thrown).IsSameReferenceAs(exception);
    }
}
