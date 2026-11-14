// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

#if NET5_0_OR_GREATER

using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Louis.Processes;

partial class ConsoleUtility
{
    private static class NativeMethods
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [SupportedOSPlatform("windows")]
        internal static extern uint GetOEMCP();
    }
}

#endif
