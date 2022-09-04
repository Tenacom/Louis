﻿// ---------------------------------------------------------------------------------------
// Copyright (C) Tenacom and L.o.U.I.S. contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.
//
// Part of this file may be third-party code, distributed under a compatible license.
// See the THIRD-PARTY-NOTICES file in the project root for third-party copyright notices.
// ---------------------------------------------------------------------------------------

using System;
using Microsoft.Extensions.Logging;

namespace Louis.Logging;

/// <summary>
/// Provides extension methods for the <see cref="ILogger"/> interface.
/// </summary>
public static partial class LoggerExtensions
{
    private static readonly EventId NullEventId = 0;
    private static readonly Func<string?, Exception?, string> StaticMessageFormatter = static (s, _) => s ?? "(null)";
}