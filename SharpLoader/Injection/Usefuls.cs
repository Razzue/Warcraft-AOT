using System.Runtime.InteropServices;

namespace SharpLoader.Injection
{
    internal class Usefuls
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr GetModuleHandle(
            string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr GetProcAddress(
            IntPtr hModule, 
            string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr OpenProcess(
            uint dwDesiredAccess, 
            int bInheritHandle, 
            uint dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr VirtualAllocEx(
            IntPtr hProcess, 
            IntPtr lpAddress, 
            IntPtr dwSize, 
            uint flAllocationType, 
            uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int WriteProcessMemory(
            IntPtr hProcess, 
            IntPtr lpBaseAddress, 
            byte[] buffer, 
            uint size, 
            int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr CreateRemoteThread(
            IntPtr hProcess, 
            IntPtr lpThreadAttribute, 
            IntPtr dwStackSize, 
            IntPtr lpStartAddress, 
            IntPtr lpParameter, 
            uint dwCreationFlags, 
            IntPtr lpThreadId);
    }

    enum NeedleResult : int
    {
        Error    = -1,
        Success,
        NoClient,
        NoHandle,
        NoLibrary,
        NoProcedure,
        MissingFile,
        NoAllocation,
    }
}