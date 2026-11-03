// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Microsoft.Extensions.Logging;

// One entry a RecordingLogger recorded. Two entries are equal when every member is equal,
// and the exception compares by reference, so an expected entry names the exception instance a test threw.
// ReSharper disable NotAccessedPositionalProperty.Global // A test compares whole entries, so no member is read on its own
internal sealed record LogEntry(int EventId, LogLevel Level, string Message, Exception? Exception = null);
// ReSharper restore NotAccessedPositionalProperty.Global
