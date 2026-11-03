// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

partial class ExceptionExtensionsIsCriticalErrorTests
{
#pragma warning disable CA1032 // Implement standard exception constructors - a test fake needs the parameterless one alone
    private sealed class TestCriticalException : Exception, ICriticalError;
#pragma warning restore CA1032 // Implement standard exception constructors
}
