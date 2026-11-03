// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Hosting;
using Microsoft.Extensions.Logging;

// An AsyncHostedService that overrides the phases alone, so that StartAsync reads the default
// FailOnSetupNotStarted and FailOnSetupUnsuccessful. SetupAsync returns the value the constructor received.
internal sealed class MinimalAsyncHostedService(ILogger logger, bool setupResult) : AsyncHostedService(logger)
{
    protected override ValueTask<bool> SetupAsync(CancellationToken cancellationToken) => new(setupResult);

    protected override Task ExecuteAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
