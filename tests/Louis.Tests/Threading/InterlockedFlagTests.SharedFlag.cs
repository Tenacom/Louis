// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;

partial class InterlockedFlagTests
{
    // A class, so that the parallel calls of a test reach one flag instead of copies of it.
    private sealed class SharedFlag
    {
        private InterlockedFlag _flag;

        public bool Value => _flag.Value;

        public bool TrySet() => _flag.TrySet();
    }
}
