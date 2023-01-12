using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using RazzSharp.Usefuls;

namespace RazzSharp
{
    class Main
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        private static ConsoleWin? _console;
        
        private const uint Proccess_Attach = 1;
        private const uint Thread_Attach = 2;

        [UnmanagedCallersOnly(EntryPoint = "DllMain", CallConvs = new[] { typeof(CallConvStdcall) })]
        private static bool DllMain(IntPtr hModule, uint ul_reason_for_call, IntPtr lpReserved)
        {
            switch (ul_reason_for_call)
            {
                case Proccess_Attach:
                    Task.Run(DoTheTask);
                    break;

                case Thread_Attach:
                    Task.Run(RespondToThread);
                    break;
            }
            return true;
        }

        private static void DoTheTask()
        {
            MessageBox(IntPtr.Zero, "We have attached to a process!", "Razz-Sharp", 0);
            _console ??= new();
            _console.Open();
        }

        private static void RespondToThread()
        {
            Console.WriteLine($@"[{DateTime.Now}] A thread has used us! The horrors.");
        }
    }
}