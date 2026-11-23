// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

partial class ThrowNewAttributeTests
{
    private sealed partial class TestException : Exception
    {
        [ThrowNew]
        public TestException()
        {
        }

        [ThrowNew]
        public TestException(string message)
            : base(message)
        {
        }

        [ThrowNew]
        public TestException(string message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}
