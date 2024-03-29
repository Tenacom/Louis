﻿// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Runtime.Serialization;

namespace Louis.Diagnostics;

/// <summary>
/// <para>The exception that is thrown by methods of the <see cref="SelfCheck"/> class
/// to signal a condition most probably caused by an internal error in a library
/// or application.</para>
/// <para>Do not use this class directly; use the methods of the <see cref="SelfCheck"/> class instead.</para>
/// </summary>
[Serializable]
public class InternalErrorException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InternalErrorException"/> class.
    /// </summary>
    public InternalErrorException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InternalErrorException"/> class
    /// with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public InternalErrorException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InternalErrorException"/> class
    /// with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception,
    /// or a <see langword="null"/> reference (<c>Nothing</c> in Visual Basic) if no inner exception is specified.</param>
    public InternalErrorException(string message, Exception? innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InternalErrorException"/> class
    /// with serialized data.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data
    /// about the exception being thrown.</param>
    /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information
    /// about the source or destination.</param>
#if NET8_0_OR_GREATER
    [Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
#endif
    protected InternalErrorException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
