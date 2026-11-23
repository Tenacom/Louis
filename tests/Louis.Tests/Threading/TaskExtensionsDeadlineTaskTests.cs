// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;

[InheritsTests]
internal sealed class TaskExtensionsDeadlineTaskTests : TaskExtensionsDeadlineTestsBase
{
    protected override Task WaitAsync(Task<int> task, Deadline deadline, CancellationToken cancellationToken)
        => ((Task)task).WaitAsync(deadline, cancellationToken);
}
