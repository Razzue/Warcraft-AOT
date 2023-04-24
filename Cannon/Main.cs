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
                    
                    Console.WriteLine($@"----- Offsets -----
Chat: Start             -> {Offsets.Chat.Start:X}
Chat: Open              -> {Offsets.Chat.Open:X}
Chat: Offset            -> {Offsets.Chat.Offset:X}
Chat: Message           -> {Offsets.Chat.Message:X}
Guid: Pet               -> {Offsets.Guids.PetGuid:X}
Guid: Focus             -> {Offsets.Guids.FocusGuid:X}
Guid: Player            -> {Offsets.Guids.PlayerGuid:X}
Guid: Target            -> {Offsets.Guids.TargetGuid:X}
Guid: Mouseover         -> {Offsets.Guids.MouseoverGuid:X}          
Guid: Last Enemy        -> {Offsets.Guids.LastEnemyGuid:X}
Guid: Last Target       -> {Offsets.Guids.LastTargetGuid:X}
Guid: Last Friend       -> {Offsets.Guids.LastFriendlyGuid:X}
Guid: Dialog Window     -> {Offsets.Guids.DialogWindowGuid:X}{(Client.Expansion == 3? 
    $"\r\nRunes: Start            -> {Offsets.Runes.Start:X}" +
    $"\r\nRunes: Finish           -> {Offsets.Runes.Finish:X}" +
    $"\r\nRunes: Base Type        -> {Offsets.Runes.BaseType:X}" +
    $"\r\nRunes: Active Type      -> {Offsets.Runes.ActiveType:X}" : string.Empty)}
Party: Address          -> {Offsets.Group.Address:X}
CVars: Click To Move    -> {Offsets.CVars.ClickToMove:X}
CVars: Auto Loot        -> {Offsets.CVars.AutoLoot:X}
CVars: Offset           -> {Offsets.CVars.Offset:X}
Camera: Address         -> {Offsets.Camera.Address:X}
Camera: Offset          -> {Offsets.Camera.Offset:X}
Spells: Address         -> {Offsets.SpellBook.Address:X}
Spells: Count           -> {Offsets.SpellBook.Count:X}
Spells: Pet Address     -> {Offsets.SpellBook.PetAddress:X}
Spells: Pet Count       -> {Offsets.SpellBook.PetCount:X}
Globals: Status         -> {Offsets.Globals.GameStatus:X}
Globals: Corpse         -> {Offsets.Globals.CorpsePosition:X}
Globals: Frames         -> {Offsets.Globals.UIFrames:X}
Globals: Window         -> {Offsets.Globals.LootWindow:X}
Globals: Message        -> {Offsets.Globals.LastMessage:X}
Globals: Combat Log     -> {Offsets.Globals.CombatLog:X}
Manager: Address        -> {Offsets.ObjectManager.Address:X}
Manager: Player Names   -> {Offsets.ObjectManager.PlayerNames:X}
Manager: Cooldowns      -> {Offsets.ObjectManager.Cooldowns:X}
Manager: Zone ID        -> {Offsets.ObjectManager.ZoneID:X}
Bindings: Address       -> {Offsets.Bindings.Address:X}
");

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