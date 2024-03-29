﻿// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Diagnostics;
using Louis.Diagnostics;

namespace Louis.Collections;

partial class EnumerableExtensions
{
    /// <summary>
    /// <para>Asynchronously disposes all items that implement either <see cref="IAsyncDisposable"/> or <see cref="IDisposable"/>.</para>
    /// <para>If an item implements both, only <see cref="IAsyncDisposable"/> is considered.</para>
    /// </summary>
    /// <param name="this">The <see cref="IEnumerable"/> interface on which this method is called.</param>
    /// <returns>A <see cref="ValueTask"/> that represents the ongoing operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="this"/> is <see langword="null"/>.</exception>
    /// <exception cref="AggregateException">
    /// One or more exceptions were raised by the <see cref="IAsyncDisposable.DisposeAsync"/>
    /// and/or <see cref="IDisposable.Dispose"/> methods of items.</exception>
    /// <remarks>
    /// <para>This method will not dispose
    /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/ref-struct">disposable ref structs</see>.</para>
    /// </remarks>
    public static async ValueTask DisposeAllAsync(this IEnumerable @this)
    {
        Guard.IsNotNull(@this);

        List<Exception>? exceptions = null;
        List<Task>? pendingTasks = null;
        foreach (var item in @this)
        {
            switch (item)
            {
                case IAsyncDisposable asyncDisposable:
                    var valueTask = asyncDisposable.DisposeAsync();
                    if (!valueTask.IsCompletedSuccessfully)
                    {
#pragma warning disable SA1010 // Opening square brackets should be spaced correctly - False positive, see https://github.com/DotNetAnalyzers/StyleCopAnalyzers/issues/3687
                        pendingTasks ??= [];
#pragma warning restore SA1010 // Opening square brackets should be spaced correctly
                        pendingTasks.Add(valueTask.AsTask());
                    }

                    break;
                case IDisposable disposable:
                    try
                    {
                        disposable.Dispose();
                    }
                    catch (Exception e) when (!e.IsCriticalError())
                    {
#pragma warning disable SA1010 // Opening square brackets should be spaced correctly - False positive, see https://github.com/DotNetAnalyzers/StyleCopAnalyzers/issues/3687
                        exceptions ??= [];
#pragma warning restore SA1010 // Opening square brackets should be spaced correctly
                        exceptions.Add(e);
                    }

                    break;
            }
        }

        if (pendingTasks is null)
        {
            if (exceptions is not null)
            {
                throw new AggregateException(exceptions);
            }

            return;
        }

        try
        {
            await Task.WhenAll(pendingTasks).ConfigureAwait(false);
        }
        catch (AggregateException e)
        {
            if (exceptions is null)
            {
                throw;
            }

            exceptions.AddRange(e.InnerExceptions);
            throw new AggregateException(exceptions);
        }
    }

    /// <summary>
    /// <para>Disposes all items that implement either <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/>.</para>
    /// <para>If an item implements both, only <see cref="IDisposable"/> is considered.</para>
    /// </summary>
    /// <param name="this">The <see cref="IEnumerable"/> interface on which this method is called.</param>
    /// <exception cref="ArgumentNullException"><paramref name="this"/> is <see langword="null"/>.</exception>
    /// <exception cref="AggregateException">
    /// One or more exceptions were raised by the <see cref="IDisposable.Dispose"/>
    /// and/or <see cref="IAsyncDisposable.DisposeAsync"/> methods of items.</exception>
    /// <remarks>
    /// <para>This method will not dispose
    /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/ref-struct">disposable ref structs</see>.</para>
    /// </remarks>
    public static void DisposeAll(this IEnumerable @this)
    {
        Guard.IsNotNull(@this);

        List<Exception>? exceptions = null;
        List<Task>? pendingTasks = null;
        foreach (var item in @this)
        {
            switch (item)
            {
                case IDisposable disposable:
                    try
                    {
                        disposable.Dispose();
                    }
                    catch (Exception e) when (!e.IsCriticalError())
                    {
#pragma warning disable SA1010 // Opening square brackets should be spaced correctly - False positive, see https://github.com/DotNetAnalyzers/StyleCopAnalyzers/issues/3687
                        exceptions ??= [];
#pragma warning restore SA1010 // Opening square brackets should be spaced correctly
                        exceptions.Add(e);
                    }

                    break;
                case IAsyncDisposable asyncDisposable:
                    var valueTask = asyncDisposable.DisposeAsync();
                    if (!valueTask.IsCompletedSuccessfully)
                    {
#pragma warning disable SA1010 // Opening square brackets should be spaced correctly - False positive, see https://github.com/DotNetAnalyzers/StyleCopAnalyzers/issues/3687
                        pendingTasks ??= [];
#pragma warning restore SA1010 // Opening square brackets should be spaced correctly
                        pendingTasks.Add(valueTask.AsTask());
                    }

                    break;
            }
        }

        if (pendingTasks is null)
        {
            if (exceptions is not null)
            {
                throw new AggregateException(exceptions);
            }

            return;
        }

        try
        {
            Task.WhenAll(pendingTasks).GetAwaiter().GetResult();
        }
        catch (AggregateException e)
        {
            if (exceptions is null)
            {
                throw;
            }

            exceptions.AddRange(e.InnerExceptions);
            throw new AggregateException(exceptions);
        }
    }
}
