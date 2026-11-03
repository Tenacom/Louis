// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Globalization;

partial class InterlockedReferenceTests
{
    // Two instances with the same id are equal, so that a test tells reference equality from value equality.
    private sealed class TestItem(int id)
    {
        private readonly int _id = id;

        public override bool Equals(object? obj) => obj is TestItem other && other._id == _id;

        public override int GetHashCode() => _id;

        public override string ToString() => _id.ToString(CultureInfo.InvariantCulture);
    }
}
