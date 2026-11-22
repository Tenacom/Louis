// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

namespace Louis.Diagnostics.Internal;

// CA1062 takes a parameter with an attribute of this name as checked for null, whatever the namespace of the attribute.
[AttributeUsage(AttributeTargets.Parameter)]
internal sealed class ValidatedNotNullAttribute : Attribute;
