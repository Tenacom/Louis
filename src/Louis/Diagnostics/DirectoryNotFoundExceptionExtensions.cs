// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.IO;

namespace Louis.Diagnostics;

/// <summary>
/// Provides <c>ThrowNew</c> extension methods for <see cref="DirectoryNotFoundException"/>.
/// </summary>
/// <remarks>
/// <para>Each public constructor of the exception type has two methods, with the parameters of the constructor.
/// Call them on the exception type, as in <c>DirectoryNotFoundException.ThrowNew(message)</c>.</para>
/// <para>The first method returns no value. Call it as a statement.</para>
/// <para>The second method has a type parameter, which is also its return type.
/// Call it where the code needs an expression of that type.</para>
/// <para>The methods with a <c>directoryPath</c> parameter are not available in the <c>netstandard</c>, .NET Framework,
/// and .NET 10 builds of Louis, because the constructors with that parameter arrived with .NET 11.</para>
/// </remarks>
/// <seealso cref="ThrowNewForAttribute"/>
[ThrowNewFor(typeof(DirectoryNotFoundException), Public = true)]
public static partial class DirectoryNotFoundExceptionExtensions;
