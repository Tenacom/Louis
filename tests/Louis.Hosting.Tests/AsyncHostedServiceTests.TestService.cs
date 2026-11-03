// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Hosting;
using Microsoft.Extensions.Logging;

partial class AsyncHostedServiceTests
{
    private sealed class TestService(ILogger logger) : AsyncHostedService(logger)
    {
        protected override Task ExecuteAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
