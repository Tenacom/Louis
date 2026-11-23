// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;

namespace Louis.Diagnostics;

/// <summary>
/// Provides the checks of a chain that starts with <see cref="Param.Check{T}(T, string)"/>,
/// or with one of the <c>CheckNotNull</c> methods of <see cref="Param"/>.
/// </summary>
/// <remarks>
/// <para>A check throws an exception if the value of the parameter is not valid.
/// Otherwise, it returns a <see cref="Param{T}"/>, so that another check can follow.</para>
/// <para>Every check takes an optional message for the exception it throws.
/// The message is a composite format string,
/// that <see cref="string.Format(IFormatProvider, string, object[])"/> processes only if the check fails.
/// The format item <c>{0}</c> is the name of the parameter, and <c>{1}</c> is its value.
/// The format items from <c>{2}</c> on are the arguments of the check, in their order.
/// A check that tests a property of the value, such as the length of a string, adds that property as the last format item.
/// The description of the <c>message</c> parameter of each check lists its format items.
/// <see cref="ExceptionHelper.FormatObject"/> converts each value to text.
/// A message that is not a valid composite format string is used as it is.</para>
/// </remarks>
/// <example>
/// <para>The following code checks the arguments of a constructor:</para>
/// <code>
/// public Connection(string host, int port, TimeSpan timeout)
/// {
///     Host = Param.NotNullOrWhiteSpace(host);
///     Port = Param.Check(port).BetweenOrEqualTo(1, 65535, "{0} must be a port number, and {1} is not.").Value;
///     Timeout = Param.Check(timeout).GreaterThan(TimeSpan.Zero).Value;
/// }
/// </code>
/// </example>
// The runtime honors StackTraceHiddenAttribute in the builds for .NET 6 and later alone.
// In the other builds the attribute is the type that src/Louis/Polyfills declares, which no runtime looks for.
// On older runtimes, StackTraceHiddenAttribute can only be detected by a custom stack trace formatter
// that looks for it by name.
[StackTraceHidden]
public static partial class ParamExtensions
{
}
