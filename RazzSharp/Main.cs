using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using RazzSharp.Usefuls;

namespace RazzSharp
{
    class Main
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr CreateRemoteThread(
            IntPtr hProcess,
            IntPtr lpThreadAttribute,
            IntPtr dwStackSize,
            IntPtr lpStartAddress,
            IntPtr lpParameter,
            uint dwCreationFlags,
            IntPtr lpThreadId);

        private static ConsoleWin? _console;

        private const uint Proccess_Detach = 0;
        private const uint Proccess_Attach = 1;
        private const uint Thread_Attach = 2;
        private const uint Thread_Detach = 3;

        [UnmanagedCallersOnly(EntryPoint = "DllMain", CallConvs = new[] { typeof(CallConvStdcall) })]
        private static bool DllMain(IntPtr hModule, uint ul_reason_for_call, IntPtr lpReserved)
        {
            switch (ul_reason_for_call)
            {
                case Proccess_Attach:
                    MessageBox(IntPtr.Zero, "We have attached to a process!", "Razz-Sharp", 0);
                    _console ??= new();
                    _console.Open();

                    Task.Run(() => { DoTheTask(); });
                    break;

                case Thread_Attach:
                    Console.WriteLine($@"[{DateTime.Now}] Attached to thread.");
                    break;
            }
            return true;
        }

        private static void DoTheTask()
        {
            var maximum = 50000;
            for (var i = 0; i < maximum; i++)
            {
                Console.WriteLine($@"[{DateTime.Now}] {i:X}");
                Thread.Sleep(new Random().Next(250, 500));
            }
        }
    }
}