// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

// The source generator of Louis adds public ThrowNew methods for RankException to this class.
[ThrowNewFor(typeof(RankException), Public = true)]
internal static partial class RankExceptionExtensions;
