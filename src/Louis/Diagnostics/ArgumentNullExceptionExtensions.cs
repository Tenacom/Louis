// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

namespace Louis.Diagnostics;

/// <summary>
/// Provides <c>ThrowNew</c> extension methods for <see cref="ArgumentNullException"/>.
/// </summary>
/// <remarks>
/// <para>Each public constructor of the exception type has two methods, with the parameters of the constructor.
/// Call them on the exception type, as in <c>ArgumentNullException.ThrowNew(paramName)</c>.</para>
/// <para>The first method returns no value. Call it as a statement.</para>
/// <para>The second method has a type parameter, which is also its return type.
/// Call it where the code needs an expression of that type.</para>
/// </remarks>
/// <seealso cref="ThrowNewForAttribute"/>
[ThrowNewFor(typeof(ArgumentNullException), Public = true)]
public static partial class ArgumentNullExceptionExtensions;
