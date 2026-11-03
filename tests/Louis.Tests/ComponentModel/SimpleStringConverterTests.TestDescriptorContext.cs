// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.ComponentModel;

partial class SimpleStringConverterTests
{
    private sealed class TestDescriptorContext : ITypeDescriptorContext
    {
        public IContainer? Container => null;

        public object? Instance => null;

        public PropertyDescriptor? PropertyDescriptor => null;

        public bool OnComponentChanging() => false;

        public void OnComponentChanged()
        {
        }

        public object? GetService(Type serviceType) => null;
    }
}
