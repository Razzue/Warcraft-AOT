using System.Runtime.InteropServices;

using RazzSharp.Useful;

namespace RazzSharp.Utility
{
    internal class Imports
    {
        internal class User
        {
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            internal static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("user32.dll")]
            internal static extern bool PostMessage(IntPtr WindowHandle, uint Msg, int wParam, int lParam);
        }

        internal class Kernel
        {
            
        }

        internal class Native
        {
            [DllImport("ntdll.dll", SetLastError = true)]
            internal static extern NtStatus NtReadVirtualMemory(IntPtr ProcessHandle, IntPtr BaseAddress, IntPtr Buffer, IntPtr NumberOfBytesToRead, IntPtr NumberOfBytesRead);

            [DllImport("ntdll.dll", SetLastError = true)]
            static extern uint NtWriteVirtualMemory(IntPtr ProcessHandle, IntPtr BaseAddress, IntPtr Buffer, UInt32 NumberOfBytesToWrite, ref UInt32 NumberOfBytesWritten);
        }
    }
}