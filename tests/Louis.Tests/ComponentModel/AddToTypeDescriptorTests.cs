// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.ComponentModel;
using Louis.ComponentModel;

// TypeDescriptor.AddAttributes changes process-global state, and each test registers a converter for a type of its own.
[NotInParallel]
internal sealed partial class AddToTypeDescriptorTests
{
    [Test]
    public async Task AddToTypeDescriptor_WithConverterType_RegistersConverter()
    {
        SimpleStringConverter.AddToTypeDescriptor<TestValue, TestValueConverter>();

        await Assert.That(TypeDescriptor.GetConverter(typeof(TestValue))).IsTypeOf<TestValueConverter>();
    }

#if NET7_0_OR_GREATER

    [Test]
    public async Task AddToTypeDescriptor_WithParsableType_RegistersParsableStringConverter()
    {
        SimpleStringConverter.AddToTypeDescriptor<TestParsable>();

        await Assert.That(TypeDescriptor.GetConverter(typeof(TestParsable))).IsTypeOf<ParsableStringConverter<TestParsable>>();
    }

#endif
}
