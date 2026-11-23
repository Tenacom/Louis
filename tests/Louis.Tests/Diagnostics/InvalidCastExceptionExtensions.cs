// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

// The source generator of Louis adds internal ThrowNew methods for InvalidCastException to this class.
[ThrowNewFor(typeof(InvalidCastException))]
internal static partial class InvalidCastExceptionExtensions;
