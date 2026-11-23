// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

// ReSharper disable once CheckNamespace // ReSharper looks for the attribute in this namespace, unless a setting names another.
namespace JetBrains.Annotations;

// ReSharper takes an argument for a parameter with this attribute as not enumerated by the call.
// Without it, a sequence that is checked and then enumerated gets a PossibleMultipleEnumeration warning.
// ReSharper reads the attribute from the assembly too, so the code that calls Louis gets no such warning either.
[AttributeUsage(AttributeTargets.Parameter)]
internal sealed class NoEnumerationAttribute : Attribute;
