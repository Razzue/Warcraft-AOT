using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using RazzSharp.Utility;
using RazzSharp.Warcraft;

namespace RazzSharp
{
    class Main
    {
        private const uint Proccess_Attach = 1;
        private const uint Thread_Attach = 2;

        private static ConsoleWin? _console;

        [UnmanagedCallersOnly(EntryPoint = "DllMain", CallConvs = new[] { typeof(CallConvStdcall) })]
        private static bool DllMain(IntPtr hModule, uint ul_reason_for_call, IntPtr lpReserved)
        {
            switch (ul_reason_for_call)
            {
                case Proccess_Attach:
                    Task.Run(() => { DoTheTask(); });
                    break;

                case Thread_Attach:
                    break;
            }

            return true;
        }
        private static void DoTheTask()
        {
            _console ??= new();
            _console.Open();

            Console.WriteLine($@"[System] Attached to {Client.WindowName} v{Client.FileVersion}");
        }


        [UnmanagedCallersOnly(EntryPoint = "LoadOffsets", CallConvs = new[] { typeof(CallConvStdcall) })]
        private static void LoadOffsets() => Client.LoadOffsets();
    }
}