using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace Cannon;

public class Main
{
    [UnmanagedCallersOnly(EntryPoint = "DllMain", CallConvs = new[] { typeof(CallConvStdcall) })]
    private static unsafe bool DllMain(IntPtr hModule, uint ul_reason_for_call, IntPtr lpReserved)
    {
        switch (ul_reason_for_call)
        {
            case 1: // ProcessAttach
                break;

            case 2: // ThreadAttach
                break;
        }

        return true;
    }
}