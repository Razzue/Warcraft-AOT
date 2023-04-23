using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Cannon.Game;

internal class Window
{
    internal static bool IsOpen
        => GetConsoleWindow() != IntPtr.Zero;

    private delegate int FreeConsoleDelegate();
    private static int FreeConsole()
    {
        try
        {
            var mod = Client.Module("KERNEL32");
            var address = Client.ProcAddress(mod, "FreeConsole");
            Console.WriteLine($@"FreeConsole: {mod.BaseAddress.ToInt64():X} -> {address.ToInt64():X}");
            var del = Marshal.GetDelegateForFunctionPointer<FreeConsoleDelegate>(address);

            return del();
        }
        catch (Exception) { return -1; }
    }

    private delegate int AllocConsoleDelegate();
    private static int AllocConsole()
    {
        try
        {
            var mod = Client.Module("KERNEL32");
            var address = Client.ProcAddress(mod, "AllocConsole");
            Console.WriteLine($@"AllocConsole: {mod.BaseAddress.ToInt64():X} -> {address.ToInt64():X}");
            var del = Marshal.GetDelegateForFunctionPointer<AllocConsoleDelegate>(address);

            return del();
        }
        catch (Exception) { return -1; }
    }

    private delegate IntPtr GetConsoleWindowDelegate();
    private static IntPtr GetConsoleWindow()
    {
        try
        {
            var mod = Client.Module("KERNEL32");
            var address = Client.ProcAddress(mod, "GetConsoleWindow");
            Console.WriteLine($@"GetConsoleWindow: {mod.BaseAddress.ToInt64():X} -> {address.ToInt64():X}");
            var del = Marshal.GetDelegateForFunctionPointer<GetConsoleWindowDelegate>(address);

            return del();
        }
        catch (Exception) { return IntPtr.Zero; }
    }

    private delegate bool PostMessageDelegate(IntPtr ptr, uint message, IntPtr wParam, IntPtr lParam);
    private static bool PostMessage(uint message)
    {
        try
        {
            var mod = Client.Module("USER32");
            var address = Client.ProcAddress(mod, "PostMessage");
            Console.WriteLine($@"FreeConsole: {mod.BaseAddress.ToInt64():X} -> {address.ToInt64():X}");
            var del = Marshal.GetDelegateForFunctionPointer<PostMessageDelegate>(address);

            return del(GetConsoleWindow(), message, IntPtr.Zero, IntPtr.Zero);
        }
        catch (Exception) { return false; }
    }

    // Need to investigate.
    // Sadly this doesn't like being called using a delegate atm
    [DllImport("kernel32.dll", EntryPoint = "CreateFileW", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    private static extern IntPtr CreateFileW(string lpFileName,
        uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes,
        uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

    internal static bool HasConsole
        => GetConsoleWindow() != IntPtr.Zero;

    internal static bool Open()
    {
        try
        {
            if (AllocConsole() == 0) return false;
            InitializeOutStream();
            InitializeInStream();
            return IntPtr.Zero != GetConsoleWindow();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
    internal static bool Close()
    {
        try
        {
            return FreeConsole() != 0
                   && PostMessage(0x10); // Post message may need a touch up.
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    private static void InitializeOutStream()
    {
        var fs = CreateFileStream("CONOUT$", GENERIC_WRITE, FILE_SHARE_WRITE, FileAccess.Write);
        var writer = new StreamWriter(fs) { AutoFlush = true };
        Console.SetOut(writer);
        Console.SetError(writer);
    }
    private static void InitializeInStream()
    {
        var fs = CreateFileStream("CONIN$", GENERIC_READ, FILE_SHARE_READ, FileAccess.Read);
        Console.SetIn(new StreamReader(fs));
    }
    private static FileStream CreateFileStream(string name, uint win32DesiredAccess, uint win32ShareMode, FileAccess dotNetFileAccess)
    {
        var file = new SafeFileHandle(CreateFileW(name, win32DesiredAccess, win32ShareMode, IntPtr.Zero, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero), true);
        if (file.IsInvalid) return null!;
        var fs = new FileStream(file, dotNetFileAccess);
        return fs;
    }

    private const UInt32 FILE_SHARE_READ = 0x00000001;
    private const UInt32 FILE_SHARE_WRITE = 0x00000002;
    private const UInt32 OPEN_EXISTING = 0x00000003;
    private const UInt32 ERROR_ACCESS_DENIED = 0x00000005;
    private const UInt32 FILE_ATTRIBUTE_NORMAL = 0x00000080;
    private const UInt32 GENERIC_WRITE = 0x40000000;
    private const UInt32 GENERIC_READ = 0x80000000;
}