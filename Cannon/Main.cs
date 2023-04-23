using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

using Cannon.Game;
using Cannon.Warcraft;
using Cannon.Warcraft.Structs;

namespace Cannon;
class Main
{
    [UnmanagedCallersOnly(EntryPoint = "DllMain", CallConvs = new[] { typeof(CallConvStdcall) })]
    private static unsafe bool DllMain(IntPtr hModule, uint ul_reason_for_call, IntPtr lpReserved)
    {
        switch (ul_reason_for_call)
        {
            case 1: // ProcessAttach
                if (!Window.IsOpen)
                    Window.Open();

                Task.Run(() => { WorkerThread(); });
                break;

            case 2: // ThreadAttach
                break;
        }

        return true;
    }

    [UnmanagedCallersOnly(EntryPoint = "DllExit", CallConvs = new[] { typeof(CallConvStdcall) })]
    private static bool DllExit()
    { 
        // Will be used to clean up.
        return true;
    }

    private static readonly Commands Commands = new();
    private static void WorkerThread()
    {
        while (Client.IsRunning)
        {
            var text = Console.ReadLine(); 
            Commands.ClearLine();

            if (!Commands.IsValid(text))
                Console.WriteLine($"{text} is not a valid command.");
            else
            {
                var index = Commands.Index(text);
                if(index <= -1) 
                    Console.WriteLine($"Invalid command index.");
                else DoTask(index);
            }

            Thread.Yield();
        }
    }

    private static unsafe void DoTask(int index)
    {
        try
        {
            switch (index)
            {
                case 0: 
                    Commands.PrintHelp();
                    break;

                case 1:
                    Console.WriteLine($"Player Name: {Functions.GetPlayerName()}");
                    var camera = (Camera*)*(IntPtr*)(*(IntPtr*)(Client.Address + Offsets.Camera.Address) + Offsets.Camera.Offset);
                    Console.WriteLine($"Camera Location: {camera->Location}");
                    break;

                case 2:
                    Client.Abort();
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}

internal class Commands
{
    private readonly string[] _full =
    {
        "-help",
        "-dump", 
        "-exit"
    };
    private readonly string[] _short =
    {
        "-h",
        "-d",
        "-e"
    };

    internal bool IsValid(string text)
    {
        try
        {
            if (string.IsNullOrEmpty(text)) return false;
            return _short.Contains(text.ToLower()) ||
                   _full.Contains(text.ToLower());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    internal int Index(string input)
    {
        try
        {
            if (string.IsNullOrEmpty(input))
                return -1;

            for (var i = 0; i < _short.Length; i++)
            {
                var txt = input.ToLower();
                if (_short[i] == txt) return i;
                if (_full[i] == txt) return i;
            }

            return -1;
        }
        catch (Exception) { return -1; }
    }
    internal void ClearLine()
    {
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.Write(new string(' ', Console.BufferWidth));
        Console.SetCursorPosition(0, Console.CursorTop - 1);
    }

    internal void PrintHelp()
    {
        Console.WriteLine($@"-h | -help       -> Display this help text.
-d | -dump       -> Dump game offsets.
-e | -exit       -> Close everything.");
        Console.WriteLine("Waiting for user input...");
    }
}