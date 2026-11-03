// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.ComponentModel;
using System.Globalization;
using Louis.ComponentModel;

partial class AddToTypeDescriptorTests
{
#pragma warning disable CA1812 // Avoid uninstantiated internal classes - TypeDescriptor instantiates the converter through reflection
    private sealed class TestValueConverter() : SimpleStringConverter<TestValue>(Parse, null)
    {
        private static TestValue Parse(ITypeDescriptorContext? context, CultureInfo? culture, string value) => new();
    }
#pragma warning restore CA1812 // Avoid uninstantiated internal classes
}
