// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

internal sealed partial class AsyncHostedServiceTests
{
    [Test]
    public async Task Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        static void Act()
        {
            // ! Null on purpose: testing null detection
            using var service = new TestService(null!);
        }

        var exception = Assert.Throws<ArgumentNullException>(Act);
        await Assert.That(exception.ParamName).IsEqualTo("logger");
    }
}
