using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Cannon.Game;

internal class Client
{
    #region Imports

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

    #endregion

    /// <summary>
    /// Get the process we're currently injected into.
    /// </summary>
    private static Process _self = Process.GetCurrentProcess();

    internal static bool IsRunning => !_self.HasExited;

    /// <summary>
    /// Get the size of the games main module, in bytes.
    /// </summary>
    internal static int Size
        => _self?.MainModule?.ModuleMemorySize ?? 0;

    /// <summary>
    /// Get the games 'file private part'.
    /// </summary>
    internal static int Build
        => _self.MainModule?.FileVersionInfo.FilePrivatePart ?? 0;

    /// <summary>
    /// Get the games 'file major part'.
    /// </summary>
    internal static int Expansion
        => _self.MainModule?.FileVersionInfo.FileMajorPart ?? 0;

    /// <summary>
    /// Get the base address of the games main module.
    /// </summary>
    internal static IntPtr Address
        => _self.MainModule?.BaseAddress ?? IntPtr.Zero;

    /// <summary>
    /// Attempt to get a process module by name from the game.
    /// </summary>
    /// <param name="name">Name of the module to find. Is case sensitive.</param>
    /// <returns>ProcessModule if found, null otherwise.</returns>
    internal static ProcessModule? Module(string name)
    {
        try
        {
            if (string.IsNullOrEmpty(name)) return null;
            var mods = _self.Modules;
            if (mods is { Count: <= 0 }) return null;

            for (var i = 0; i < mods.Count; i++)
                if (mods[i].ModuleName.Contains(name))
                    return (ProcessModule)mods[i];

            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    /// <summary>
    /// Attempt to get the address of a module function by name.
    /// </summary>
    /// <param name="module">Module to search in.</param>
    /// <param name="name">Name of function to locate.</param>
    /// <returns>A value if found, IntPtr.Zero otherwise.</returns> 
    internal static IntPtr ProcAddress(ProcessModule? module, string name)
    {
        try
        {
            if (null == module || string.IsNullOrEmpty(name)) return IntPtr.Zero;
            var function = GetProcAddress(module.BaseAddress, name);
            return function;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return IntPtr.Zero;
        }
    }

    internal static unsafe T Read<T>(int offset) where T : unmanaged
        => *(T*)(Address + offset);
    internal static unsafe T? SafeRead<T>(int offset) where T : unmanaged
    {
        try
        {
            if (offset == 0 || Address.ToInt64() == 0) return default;
            var address = Address + offset;

            var size = typeof(T) == typeof(bool) ? 1 : Marshal.SizeOf(typeof(T));
            var bytes = new byte[size];

            if(size <= 0 || bytes is {Length: <= 0}) return default;
            Marshal.Copy(address, bytes, 0, size);

            fixed (byte* bytePtr = bytes)
                return Marshal.PtrToStructure<T>((IntPtr)bytePtr);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return default;
        }
    }

    internal static void Exit() => _self.Close();
    internal static void Abort() => Environment.Exit(0);
}