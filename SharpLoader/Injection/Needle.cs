using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLoader.Injection
{
    internal class Needle
    {
        private Process? _process;
        private NeedleResult _result;
        
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

        private readonly string _library = $@"{Environment.CurrentDirectory}\RazzSharp.dll";
        internal NeedleResult Inject()
        {
            try
            {
                if (null == _process) return NeedleResult.NoClient;
                if (!File.Exists(_library)) return NeedleResult.MissingFile;

                var handle = Usefuls.OpenProcess(1082U, 1, (uint)_process.Id);
                if (handle.ToInt64() == 0) return NeedleResult.NoHandle;

                var libAddress = Usefuls.GetModuleHandle("kernel32.dll");
                if (libAddress.ToInt64() == 0) return NeedleResult.NoLibrary;

                var procAddress = Usefuls.GetProcAddress(libAddress, "LoadLibraryA");
                if (procAddress.ToInt64() == 0) return NeedleResult.NoProcedure;

                var bytes = Encoding.ASCII.GetBytes(_library);
                var allocated = Usefuls.VirtualAllocEx(handle, IntPtr.Zero, new IntPtr(bytes.Length), 12288U, 64U);
                if (allocated.ToInt64() == 0) return NeedleResult.NoAllocation;

                if (Usefuls.WriteProcessMemory(handle, allocated, bytes, (uint)bytes.Length, 0) == 0)
                    throw new Exception("Was unable to write library location into allocated memory.");

                var thread = Usefuls.CreateRemoteThread(handle, IntPtr.Zero, IntPtr.Zero, procAddress, allocated, 0U, IntPtr.Zero);
                if (thread.ToInt64() == 0) throw new Exception("Was unable to create a remote thread.");

                Usefuls.CloseHandle(handle);
                return NeedleResult.Success;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NeedleResult.Error;
            }
           
        }
    }
}
