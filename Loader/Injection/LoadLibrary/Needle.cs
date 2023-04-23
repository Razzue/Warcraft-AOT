using System.Text;
using System.Diagnostics;

namespace Loader.Injection.LoadLibrary;

internal class Needle
{
    private Process? _process;
    private NResult _result;

    internal Needle(int pid)
        => _process = Process.GetProcessById(pid);
    internal Needle(string name, int index = 0)
    {
        try
        {
            var procs = Process.GetProcessesByName(name);
            if (procs is { Length: <= 0 } || index >= procs.Length)
                throw new ArgumentOutOfRangeException();

            _process = procs[index];
        }
        catch (Exception e)
        {
            Console.WriteLine($"[Needle.Init] {e.Message}");
        }
    }

    internal NResult Inject(string file)
    {
        try
        {
            if (null == _process) return NResult.NoClient;
            Console.WriteLine($"Process      -> {_process.Id}: {_process.MainModule?.BaseAddress.ToInt64():X}");

            if (string.IsNullOrEmpty(file) || !File.Exists(file)) return NResult.MissingFile;
            Console.WriteLine($"Library      -> {file}");

            var handle = Imports.OpenProcess(1082U, 1, (uint)_process.Id);
            if (handle.ToInt64() == 0) return NResult.NoHandle;
            Console.WriteLine($"Handle       -> {handle.ToInt64():X}");

            var libAddress = Imports.GetModuleHandle("kernel32.dll");
            if (libAddress.ToInt64() == 0) return NResult.NoLibrary;
            Console.WriteLine($"Kernel32     -> {libAddress.ToInt64():X}");

            var procAddress = Imports.GetProcAddress(libAddress, "LoadLibraryA");
            if (procAddress.ToInt64() == 0) return NResult.NoProcedure;
            Console.WriteLine($"LoadLibraryA -> {procAddress.ToInt64():X}");

            var bytes = Encoding.ASCII.GetBytes(file);
            var allocated = Imports.VirtualAllocEx(handle, IntPtr.Zero, new IntPtr(bytes.Length), 12288U, 64U);
            if (allocated.ToInt64() == 0) return NResult.NoAllocation;
            Console.WriteLine($"Allocated    -> {allocated.ToInt64():X}");

            if (Imports.WriteProcessMemory(handle, allocated, bytes, (uint)bytes.Length, 0) == 0)
                throw new Exception("Was unable to write library location into allocated memory.");

            var thread = Imports.CreateRemoteThread(handle, IntPtr.Zero, IntPtr.Zero, procAddress, allocated, 0U, IntPtr.Zero);
            if (thread.ToInt64() == 0) throw new Exception("Was unable to create a remote thread.");
            Console.WriteLine($"Thread       -> {thread.ToInt64():X}");

            Imports.CloseHandle(handle);
            return NResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NResult.Error;
        }
    }
    internal void ExecuteUnmanaged(int offset)
    {
        if (null == _process) return;
        _process = Process.GetProcessById(_process.Id);

        var handle = Imports.OpenProcess(
            1082U,
            1,
            (uint)_process.Id);
        if (handle.ToInt64() == 0) return;

        ProcessModule? mod = _process.Modules
            .Cast<object>()
            .Where(module =>
            ((ProcessModule)module).FileName.Contains("Cannon"))
            .Cast<ProcessModule>()
            .FirstOrDefault();
        if (null == mod) return;

        var thread = Imports.CreateRemoteThread(
            handle,
            IntPtr.Zero,
            IntPtr.Zero,
            mod.BaseAddress + offset,
            IntPtr.Zero,
            0U,
            IntPtr.Zero);
    }
}

internal enum NResult : int
{
    Error = -1,
    Success,
    NoClient,
    NoHandle,
    NoLibrary,
    NoProcedure,
    MissingFile,
    NoAllocation,
}