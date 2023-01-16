using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using RazzSharp.Useful;
using RazzSharp.Utility;
using System.Net;
using System.Reflection;
using RazzSharp.Warcraft.Scanner.Events;

namespace RazzSharp.Warcraft;

internal class Client
{
    internal static Process Game => Process.GetCurrentProcess();

    internal static int ProcessId => Game.Id;
    internal static IntPtr Handle => Game.Handle;
    internal static int Size => Game.MainModule?.ModuleMemorySize ?? 0;
    internal static IntPtr Address => Game.MainModule?.BaseAddress ?? IntPtr.Zero;

    internal static string WindowName => Game.MainWindowTitle;
    internal static IntPtr WindowHandle => Game.MainWindowHandle;

    internal static string FileVersion => Game.MainModule?.FileVersionInfo.FileVersion ?? string.Empty;
    internal static bool IsRetail => FileVersion.Split('.').FirstOrDefault() == "10";
    internal static bool IsClassic => FileVersion.Split('.').FirstOrDefault() == "3";
    internal static bool IsSeason => FileVersion.Split('.').FirstOrDefault() == "1";

    internal static Pattern? Scanner;

    internal static Offsets? Offsets;
    public static void LoadOffsets()
    {
        Scanner ??= new();
        Console.WriteLine("Attempting to load the offsets.");

        Task.Run(() =>
        {
            void Received(object sender, PatternMatchedArgs args)
                => Console.WriteLine($@"[{args.Value switch
                {
                    ulong ul => ul.ToString("X"),
                    long l => l.ToString("X"),

                    uint ui => ui.ToString("X"),
                    int i => i.ToString("X"),

                    ushort us => us.ToString("X"),
                    short s => s.ToString("X"),

                    sbyte sb => sb.ToString("X"),
                    byte b => b.ToString("X"),

                    _ => "0"
                }}] {args.Name} | {args.Elapsed} ms.");
            Scanner.OnMatchFound += Received;

            Offsets = new Offsets();
            var classes = typeof(Offsets).GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            for (var i = 0; i < classes.Length; i++)
            {
                var entry = classes[i].GetValue(Offsets, null) ?? null;
                Console.WriteLine($"----- {classes[i].Name} -----");
                var values = GetProperties(entry);

                if (values is { Length: > 0 })
                {
                    for (var x = 0; x < values.Length; x++)
                        values[x].GetValue(entry, null);
                }
            }
            Scanner.OnMatchFound -= Received;
        });
    }
    private static PropertyInfo[] GetProperties(object input)
        => input switch
        {
            Scripts => typeof(Scripts).GetProperties(BindingFlags.NonPublic | BindingFlags.Instance),
            Functions => typeof(Functions).GetProperties(BindingFlags.NonPublic | BindingFlags.Instance),

            CameraOffsets => typeof(CameraOffsets).GetProperties(BindingFlags.NonPublic | BindingFlags.Instance),
            CombatLogOffsets => typeof(CombatLogOffsets).GetProperties(BindingFlags.NonPublic | BindingFlags.Instance),
            ObjectManagerOffsets => typeof(ObjectManagerOffsets).GetProperties(BindingFlags.NonPublic | BindingFlags.Instance),

            _ => Array.Empty<PropertyInfo>()
        };

    internal static Fields Fields = new();
    internal static void LoadFields()
    {
        Scanner ??= new();
        Console.WriteLine("Attempting to load the offsets.");

        Task.Run(() =>
        {

        });
    }
}
internal class Memory
{
    internal static unsafe T? Read<T>(int offset)
    {
        try
        {
            try
            {
                var size = typeof(T) == typeof(bool) ? 1 : Marshal.SizeOf<T>();
                fixed (byte* bytes = new byte[size])
                {
                    if (NtStatus.Success != Imports.Native.NtReadVirtualMemory(Client.Handle, Client.Address + offset, (IntPtr)bytes, (IntPtr)size, IntPtr.Zero))
                        return default;

                    var result = Marshal.PtrToStructure((IntPtr)bytes, typeof(T));
                    return null != result ? (T)result : default;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return default;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return default;
        }
    }
    internal static unsafe T? Read<T>(IntPtr address)
    {
        try
        {
            var size = typeof(T) == typeof(bool) ? 1 : Marshal.SizeOf<T>();
            fixed (byte* bytes = new byte[size])
            {
                if(NtStatus.Success != Imports.Native.NtReadVirtualMemory(Client.Handle, address, (IntPtr)bytes, (IntPtr)size, IntPtr.Zero))
                    return default;

                var result = Marshal.PtrToStructure((IntPtr)bytes, typeof(T));
                return null != result ? (T)result : default;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return default;
        }
    }

    internal static unsafe T[]? ReadArray<T>(int offset, int size)
    {
        try
        {
            if (size == 0) return Array.Empty<T>();
            if (offset == 0) return Array.Empty<T>();
            // Console.WriteLine($@"Reading {typeof(T)} array from [{(Client.Handle):X}]{(address.ToInt64()):X}[{size}]");

            var arr = new T[size];
            GCHandle handle = GCHandle.Alloc(arr, GCHandleType.Pinned);
            IntPtr pointer = handle.AddrOfPinnedObject();
            // Console.WriteLine($@"Handle Pointer -> {(pointer.ToInt64()):X}");

            var status = Imports.Native.NtReadVirtualMemory(Client.Handle, Client.Address + offset, pointer, (IntPtr)size, default);
            // Console.WriteLine($@"{status} -> Length: {arr.Length}");
            handle.Free();

            if (NtStatus.Success != status)
                throw new Exception($"{status}");
            return arr;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Array.Empty<T>();
        }
    }
    internal static unsafe T[]? ReadArray<T>(IntPtr address, int size)
    {
        try
        {
            if (size == 0) return Array.Empty<T>();
            if (address.ToInt64() == 0) return Array.Empty<T>();
            // Console.WriteLine($@"Reading {typeof(T)} array from [{(Client.Handle):X}]{(address.ToInt64()):X}[{size}]");

            var arr = new T[size];
            GCHandle handle = GCHandle.Alloc(arr, GCHandleType.Pinned);
            IntPtr pointer = handle.AddrOfPinnedObject();
            // Console.WriteLine($@"Handle Pointer -> {(pointer.ToInt64()):X}");

            var status = Imports.Native.NtReadVirtualMemory(Client.Handle, address, pointer, (IntPtr)size, default);
            // Console.WriteLine($@"{status} -> Length: {arr.Length}");
            handle.Free();

            if (NtStatus.Success != status) 
                throw new Exception($"{status}");
            return arr;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Array.Empty<T>();
        }
    }
    internal static unsafe T? ReadChain<T>(IntPtr address, int[] offsets)
    {
        try
        {
            return default;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return default;
        }
    }

    internal static string ReadString(int offset, int size = 15, Encoding? enc = null)
    {
        try
        {
            return default;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return default;
        }
    }
    internal static string ReadString(IntPtr address, int size = 15, Encoding? enc = null)
    {
        try
        {
            return default;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return default;
        }
    }
    internal static string ReadString(IntPtr address, int[] offsets, int size = 15, Encoding? enc = null)
    {
        try
        {
            return default;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return default;
        }
    }
}
