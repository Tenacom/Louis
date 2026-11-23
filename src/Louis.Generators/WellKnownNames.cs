// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace Louis.Generators;

/// <summary>
/// Holds the names that the generator and the analyzers look for, and the names that the generator writes.
/// </summary>
internal static class WellKnownNames
{
    /// <summary>
    /// The name of the methods that the generator adds, and that <see cref="ThrowNewCallAnalyzer"/> looks for.
    /// </summary>
    public const string ThrowNew = "ThrowNew";

    /// <summary>
    /// The short name of the attribute that goes on a constructor of an exception class.
    /// </summary>
    public const string ThrowNewAttributeName = "ThrowNewAttribute";

    /// <summary>
    /// The short name of the attribute that goes on a static class, and names an exception type.
    /// </summary>
    public const string ThrowNewForAttributeName = "ThrowNewForAttribute";

    /// <summary>
    /// The metadata name of the attribute that goes on a constructor of an exception class.
    /// </summary>
    public const string ThrowNewAttribute = $"Louis.Diagnostics.{ThrowNewAttributeName}";

    /// <summary>
    /// The metadata name of the attribute that goes on a static class, and names an exception type.
    /// </summary>
    public const string ThrowNewForAttribute = $"Louis.Diagnostics.{ThrowNewForAttributeName}";

    /// <summary>
    /// The metadata name of the base class of every exception type.
    /// </summary>
    public const string Exception = "System.Exception";

    /// <summary>
    /// The metadata name of the attribute that tells the compiler that a method does not return.
    /// </summary>
    public const string DoesNotReturnAttribute = "System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute";

    /// <summary>
    /// The metadata name of the attribute that keeps a method out of a stack trace.
    /// </summary>
    public const string StackTraceHiddenAttribute = "System.Diagnostics.StackTraceHiddenAttribute";
}
