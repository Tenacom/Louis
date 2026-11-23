// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Diagnostics;
using System.Runtime.CompilerServices;
using Louis.Diagnostics;
using Louis.Diagnostics.Internal;

namespace Louis.Text.Internal;

// Holds the chain checks that the members of Louis.Text need, and that Louis.Diagnostics.ParamExtensions does not have.
// The runtime honors StackTraceHiddenAttribute in the builds for .NET 6 and later alone.
// In the other builds the attribute is the type that src/Louis/Polyfills declares, which no runtime looks for.
// On older runtimes, StackTraceHiddenAttribute can only be detected by a custom stack trace formatter
// that looks for it by name.
[StackTraceHidden]
internal static class ParamExtensions
{
    extension(Param<StringLiteralKind> @this)
    {
        // Throws an ArgumentException if the value of a parameter is not a constant of StringLiteralKind.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Param<StringLiteralKind> Defined()
        {
            if (@this.Value is not (StringLiteralKind.Quoted or StringLiteralKind.Verbatim))
            {
                ParamThrow.Invalid(@this.Name, @this.Value, "{0} ({1}) is not a valid StringLiteralKind.");
            }

            return @this;
        }
    }
}
