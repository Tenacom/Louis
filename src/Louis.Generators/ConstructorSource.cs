// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace Louis.Generators;

/// <summary>
/// Holds the <c>ThrowNew</c> methods of one constructor, and the source file they go in.
/// </summary>
/// <param name="HintName">The name of the source file, unique within the compilation.</param>
/// <param name="Opening">The text of the source file before the methods.</param>
/// <param name="Closing">The text of the source file after the methods.</param>
/// <param name="ParameterCount">The number of parameters of the constructor.</param>
/// <param name="Signature">The parameter list of the constructor.</param>
/// <param name="Text">The C# text of the methods.</param>
/// <remarks>
/// <para>An instance holds strings and a number alone, and no symbol, so that two instances compare by value.
/// The compiler then runs a step of the source generator again only when the text it works on changes.</para>
/// </remarks>
internal sealed record ConstructorSource(
    string HintName,
    string Opening,
    string Closing,
    int ParameterCount,
    string Signature,
    string Text);
