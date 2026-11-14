// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using Louis.Text.Internal;

namespace Louis.Text;

partial class StringExtensions
{
    /// <summary>
    /// Computes the length of the <see href="https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#quoted-string-literals">quoted literal</see>
    /// representation of a string.
    /// </summary>
    /// <param name="this">The <see langword="string"/> on which this method is called.</param>
    /// <returns>The length of the string that would result from calling
    /// <see cref="ToQuotedLiteral"/> on <paramref name="this"/>.</returns>
    public static int ComputeQuotedLiteralLength(this string? @this)
        => @this is null ? InternalConstants.QuotedNullLength : @this.AsSpan().ComputeQuotedLiteralLength();

    /// <summary>
    /// Computes the length of the <see href="https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#verbatim-string-literals">verbatim literal</see>
    /// representation of a string.
    /// </summary>
    /// <param name="this">The <see langword="string"/> on which this method is called.</param>
    /// <returns>The length of the string that would result from calling
    /// <see cref="ToVerbatimLiteral"/> on <paramref name="this"/>.</returns>
    public static int ComputeVerbatimLiteralLength(this string? @this)
        => @this is null ? InternalConstants.QuotedNullLength : @this.AsSpan().ComputeVerbatimLiteralLength();

    /// <summary>
    /// Computes the length of the representation of a string as a string literal.
    /// </summary>
    /// <param name="this">The <see langword="string"/> on which this method is called.</param>
    /// <param name="literalKind">A <see cref="StringLiteralKind"/> constant specifying
    /// the kind of string literal that would be built.</param>
    /// <returns>The length of the string that would result from calling
    /// <see cref="ToLiteral"/> on <paramref name="this"/>
    /// with <paramref name="literalKind"/> as last parameter.</returns>
    /// <exception cref="ArgumentException"><paramref name="literalKind"/> is neither <see cref="StringLiteralKind.Quoted"/>
    /// nor <see cref="StringLiteralKind.Verbatim"/>.</exception>
    public static int ComputeLiteralLength(this string? @this, StringLiteralKind literalKind)
    {
        InternalGuard.IsDefinedStringLiteralKind(literalKind);

        return @this is null ? InternalConstants.QuotedNullLength : @this.AsSpan().ComputeLiteralLength(literalKind);
    }
}
