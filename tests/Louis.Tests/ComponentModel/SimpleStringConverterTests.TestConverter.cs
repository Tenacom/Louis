// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.ComponentModel;
using System.Globalization;
using Louis.ComponentModel;

partial class SimpleStringConverterTests
{
    private sealed class TestConverter(
        Func<ITypeDescriptorContext?, CultureInfo?, string, int>? convertFromString,
        Func<ITypeDescriptorContext?, CultureInfo?, int, string>? convertToString)
        : SimpleStringConverter<int>(convertFromString, convertToString);
}
