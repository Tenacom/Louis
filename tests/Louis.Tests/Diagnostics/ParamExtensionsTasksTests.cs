// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

// No test passes a task to Assert.That, which would await it.
internal sealed class ParamExtensionsTasksTests
{
    [Test]
    [Arguments(TaskStatus.RanToCompletion)]
    [Arguments(TaskStatus.Faulted)]
    [Arguments(TaskStatus.Canceled)]
    public async Task Completed_WithCompletedTask_ReturnsSameParam(TaskStatus status)
    {
        var task = TaskWithStatus(status);

        var param = Param.Check(task).Completed();

        await Assert.That(ReferenceEquals(param.Value, task)).IsTrue();
        await Assert.That(param.Name).IsEqualTo("task");
    }

    [Test]
    public async Task Completed_WithPendingTask_ThrowsArgumentException()
    {
        static void Act(Task task) => Param.Check(task).Completed();

        await Assert.That(() => Act(TaskWithStatus(TaskStatus.WaitingForActivation)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("task must be completed, and its status is WaitingForActivation.", StringComparison.Ordinal)
            .And.WithParameterName("task");
    }

    [Test]
    public async Task Completed_WithMessage_FormatsMessage()
    {
        static void Act(Task task) => Param.Check(task).Completed("{0} is still {2}.");

        await Assert.That(() => Act(TaskWithStatus(TaskStatus.WaitingForActivation)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("task is still WaitingForActivation.", StringComparison.Ordinal);
    }

    [Test]
    public async Task NotCompleted_WithPendingTask_ReturnsSameParam()
    {
        var task = TaskWithStatus(TaskStatus.WaitingForActivation);

        var param = Param.Check(task).NotCompleted();

        await Assert.That(ReferenceEquals(param.Value, task)).IsTrue();
        await Assert.That(param.Name).IsEqualTo("task");
    }

    [Test]
    [Arguments(TaskStatus.RanToCompletion)]
    [Arguments(TaskStatus.Faulted)]
    [Arguments(TaskStatus.Canceled)]
    public async Task NotCompleted_WithCompletedTask_ThrowsArgumentException(TaskStatus status)
    {
        static void Act(Task task) => Param.Check(task).NotCompleted();

        await Assert.That(() => Act(TaskWithStatus(status)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"task must not be completed, and its status is {status}.", StringComparison.Ordinal)
            .And.WithParameterName("task");
    }

    [Test]
    public async Task NotCompleted_WithMessage_FormatsMessage()
    {
        static void Act(Task task) => Param.Check(task).NotCompleted("{0} is already {2}.");

        await Assert.That(() => Act(TaskWithStatus(TaskStatus.Canceled)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("task is already Canceled.", StringComparison.Ordinal);
    }

    [Test]
    public async Task CompletedSuccessfully_WithTaskRunToCompletion_ReturnsSameParam()
    {
        var task = TaskWithStatus(TaskStatus.RanToCompletion);

        var param = Param.Check(task).CompletedSuccessfully();

        await Assert.That(ReferenceEquals(param.Value, task)).IsTrue();
        await Assert.That(param.Name).IsEqualTo("task");
    }

    [Test]
    [Arguments(TaskStatus.WaitingForActivation)]
    [Arguments(TaskStatus.Faulted)]
    [Arguments(TaskStatus.Canceled)]
    public async Task CompletedSuccessfully_WithAnyOtherTask_ThrowsArgumentException(TaskStatus status)
    {
        static void Act(Task task) => Param.Check(task).CompletedSuccessfully();

        await Assert.That(() => Act(TaskWithStatus(status)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"task must be completed successfully, and its status is {status}.", StringComparison.Ordinal)
            .And.WithParameterName("task");
    }

    [Test]
    public async Task CompletedSuccessfully_WithMessage_FormatsMessage()
    {
        static void Act(Task task) => Param.Check(task).CompletedSuccessfully("{0} is {2}.");

        await Assert.That(() => Act(TaskWithStatus(TaskStatus.Faulted)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("task is Faulted.", StringComparison.Ordinal);
    }

    [Test]
    [Arguments(TaskStatus.WaitingForActivation)]
    [Arguments(TaskStatus.Faulted)]
    [Arguments(TaskStatus.Canceled)]
    public async Task NotCompletedSuccessfully_WithAnyOtherTask_ReturnsSameParam(TaskStatus status)
    {
        var task = TaskWithStatus(status);

        var param = Param.Check(task).NotCompletedSuccessfully();

        await Assert.That(ReferenceEquals(param.Value, task)).IsTrue();
        await Assert.That(param.Name).IsEqualTo("task");
    }

    [Test]
    public async Task NotCompletedSuccessfully_WithTaskRunToCompletion_ThrowsArgumentException()
    {
        static void Act(Task task) => Param.Check(task).NotCompletedSuccessfully();

        await Assert.That(() => Act(TaskWithStatus(TaskStatus.RanToCompletion)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("task must not be completed successfully.", StringComparison.Ordinal)
            .And.WithParameterName("task");
    }

    [Test]
    public async Task NotCompletedSuccessfully_WithMessage_FormatsMessage()
    {
        static void Act(Task task) => Param.Check(task).NotCompletedSuccessfully("{0} is {2}.");

        await Assert.That(() => Act(TaskWithStatus(TaskStatus.RanToCompletion)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("task is RanToCompletion.", StringComparison.Ordinal);
    }

    [Test]
    public async Task Faulted_WithFaultedTask_ReturnsSameParam()
    {
        var task = TaskWithStatus(TaskStatus.Faulted);

        var param = Param.Check(task).Faulted();

        await Assert.That(ReferenceEquals(param.Value, task)).IsTrue();
        await Assert.That(param.Name).IsEqualTo("task");
    }

    [Test]
    [Arguments(TaskStatus.WaitingForActivation)]
    [Arguments(TaskStatus.RanToCompletion)]
    [Arguments(TaskStatus.Canceled)]
    public async Task Faulted_WithAnyOtherTask_ThrowsArgumentException(TaskStatus status)
    {
        static void Act(Task task) => Param.Check(task).Faulted();

        await Assert.That(() => Act(TaskWithStatus(status)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"task must be faulted, and its status is {status}.", StringComparison.Ordinal)
            .And.WithParameterName("task");
    }

    [Test]
    public async Task Faulted_WithMessage_FormatsMessage()
    {
        static void Act(Task task) => Param.Check(task).Faulted("{0} is {2}.");

        await Assert.That(() => Act(TaskWithStatus(TaskStatus.Canceled)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("task is Canceled.", StringComparison.Ordinal);
    }

    [Test]
    [Arguments(TaskStatus.WaitingForActivation)]
    [Arguments(TaskStatus.RanToCompletion)]
    [Arguments(TaskStatus.Canceled)]
    public async Task NotFaulted_WithAnyOtherTask_ReturnsSameParam(TaskStatus status)
    {
        var task = TaskWithStatus(status);

        var param = Param.Check(task).NotFaulted();

        await Assert.That(ReferenceEquals(param.Value, task)).IsTrue();
        await Assert.That(param.Name).IsEqualTo("task");
    }

    [Test]
    public async Task NotFaulted_WithFaultedTask_ThrowsArgumentException()
    {
        static void Act(Task task) => Param.Check(task).NotFaulted();

        await Assert.That(() => Act(TaskWithStatus(TaskStatus.Faulted)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("task must not be faulted.", StringComparison.Ordinal)
            .And.WithParameterName("task");
    }

    [Test]
    public async Task NotFaulted_WithMessage_FormatsMessage()
    {
        static void Act(Task task) => Param.Check(task).NotFaulted("{0} is {2}.");

        await Assert.That(() => Act(TaskWithStatus(TaskStatus.Faulted)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("task is Faulted.", StringComparison.Ordinal);
    }

    [Test]
    public async Task Canceled_WithCanceledTask_ReturnsSameParam()
    {
        var task = TaskWithStatus(TaskStatus.Canceled);

        var param = Param.Check(task).Canceled();

        await Assert.That(ReferenceEquals(param.Value, task)).IsTrue();
        await Assert.That(param.Name).IsEqualTo("task");
    }

    [Test]
    [Arguments(TaskStatus.WaitingForActivation)]
    [Arguments(TaskStatus.RanToCompletion)]
    [Arguments(TaskStatus.Faulted)]
    public async Task Canceled_WithAnyOtherTask_ThrowsArgumentException(TaskStatus status)
    {
        static void Act(Task task) => Param.Check(task).Canceled();

        await Assert.That(() => Act(TaskWithStatus(status)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining($"task must be canceled, and its status is {status}.", StringComparison.Ordinal)
            .And.WithParameterName("task");
    }

    [Test]
    public async Task Canceled_WithMessage_FormatsMessage()
    {
        static void Act(Task task) => Param.Check(task).Canceled("{0} is {2}.");

        await Assert.That(() => Act(TaskWithStatus(TaskStatus.Faulted)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("task is Faulted.", StringComparison.Ordinal);
    }

    [Test]
    [Arguments(TaskStatus.WaitingForActivation)]
    [Arguments(TaskStatus.RanToCompletion)]
    [Arguments(TaskStatus.Faulted)]
    public async Task NotCanceled_WithAnyOtherTask_ReturnsSameParam(TaskStatus status)
    {
        var task = TaskWithStatus(status);

        var param = Param.Check(task).NotCanceled();

        await Assert.That(ReferenceEquals(param.Value, task)).IsTrue();
        await Assert.That(param.Name).IsEqualTo("task");
    }

    [Test]
    public async Task NotCanceled_WithCanceledTask_ThrowsArgumentException()
    {
        static void Act(Task task) => Param.Check(task).NotCanceled();

        await Assert.That(() => Act(TaskWithStatus(TaskStatus.Canceled)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("task must not be canceled.", StringComparison.Ordinal)
            .And.WithParameterName("task");
    }

    [Test]
    public async Task NotCanceled_WithMessage_FormatsMessage()
    {
        static void Act(Task task) => Param.Check(task).NotCanceled("{0} is {2}.");

        await Assert.That(() => Act(TaskWithStatus(TaskStatus.Canceled)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("task is Canceled.", StringComparison.Ordinal);
    }

    [Test]
    [Arguments(TaskStatus.WaitingForActivation)]
    [Arguments(TaskStatus.RanToCompletion)]
    [Arguments(TaskStatus.Faulted)]
    [Arguments(TaskStatus.Canceled)]
    public async Task HasStatusEqualTo_WithTaskOfThatStatus_ReturnsSameParam(TaskStatus status)
    {
        var task = TaskWithStatus(status);

        var param = Param.Check(task).HasStatusEqualTo(status);

        await Assert.That(ReferenceEquals(param.Value, task)).IsTrue();
        await Assert.That(param.Name).IsEqualTo("task");
    }

    [Test]
    public async Task HasStatusEqualTo_WithTaskOfAnotherStatus_ThrowsArgumentException()
    {
        static void Act(Task task) => Param.Check(task).HasStatusEqualTo(TaskStatus.Faulted);

        await Assert.That(() => Act(TaskWithStatus(TaskStatus.RanToCompletion)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("task must have the status Faulted, and its status is RanToCompletion.", StringComparison.Ordinal)
            .And.WithParameterName("task");
    }

    [Test]
    public async Task HasStatusEqualTo_WithMessage_FormatsMessage()
    {
        static void Act(Task task) => Param.Check(task).HasStatusEqualTo(TaskStatus.Faulted, "{0}|{2}|{3}");

        await Assert.That(() => Act(TaskWithStatus(TaskStatus.RanToCompletion)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("task|Faulted|RanToCompletion", StringComparison.Ordinal);
    }

    [Test]
    [Arguments(TaskStatus.WaitingForActivation)]
    [Arguments(TaskStatus.Faulted)]
    [Arguments(TaskStatus.Canceled)]
    public async Task HasStatusNotEqualTo_WithTaskOfAnotherStatus_ReturnsSameParam(TaskStatus status)
    {
        var task = TaskWithStatus(status);

        var param = Param.Check(task).HasStatusNotEqualTo(TaskStatus.RanToCompletion);

        await Assert.That(ReferenceEquals(param.Value, task)).IsTrue();
        await Assert.That(param.Name).IsEqualTo("task");
    }

    [Test]
    public async Task HasStatusNotEqualTo_WithTaskOfThatStatus_ThrowsArgumentException()
    {
        static void Act(Task task) => Param.Check(task).HasStatusNotEqualTo(TaskStatus.RanToCompletion);

        await Assert.That(() => Act(TaskWithStatus(TaskStatus.RanToCompletion)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("task must not have the status RanToCompletion.", StringComparison.Ordinal)
            .And.WithParameterName("task");
    }

    [Test]
    public async Task HasStatusNotEqualTo_WithMessage_FormatsMessage()
    {
        static void Act(Task task) => Param.Check(task).HasStatusNotEqualTo(TaskStatus.RanToCompletion, "{0}|{2}|{3}");

        await Assert.That(() => Act(TaskWithStatus(TaskStatus.RanToCompletion)))
            .ThrowsExactly<ArgumentException>()
            .WithMessageContaining("task|RanToCompletion|RanToCompletion", StringComparison.Ordinal);
    }

    [Test]
    public async Task TaskChecks_OnDerivedType_KeepTypeOfChain()
    {
        static Task<int> Check(Task<int> task) => Param.Check(task).Completed().CompletedSuccessfully().NotFaulted().Value;

        var task = Task.FromResult(42);

        var result = Check(task);

        await Assert.That(ReferenceEquals(result, task)).IsTrue();
    }

    private static Task TaskWithStatus(TaskStatus status)
        => status switch {
            TaskStatus.RanToCompletion => Task.CompletedTask,
            TaskStatus.Faulted => FaultedTask(),
            TaskStatus.Canceled => Task.FromCanceled(new CancellationToken(canceled: true)),
            TaskStatus.WaitingForActivation => new TaskCompletionSource<bool>().Task,
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, "No test needs a task of this status."),
        };

    private static Task FaultedTask()
    {
        var task = Task.FromException(new InvalidOperationException("A test needs a faulted task."));

        // Reading the exception marks it as observed, so that the finalizer of the task does not report it.
        _ = task.Exception;
        return task;
    }
}
