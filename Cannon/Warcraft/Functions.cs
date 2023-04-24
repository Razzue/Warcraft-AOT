using System.Runtime.InteropServices;

using Cannon.Game;
using Cannon.Useful;

namespace Cannon.Warcraft;

internal class Functions
{
    internal static unsafe string? GetPlayerName()
    {
        try
        {
            var getName =
                Marshal.GetDelegateForFunctionPointer<Delegates.D_GetPlayerName>(
                    new IntPtr(Offsets.Functions.PlayerName));
            return Marshal.PtrToStringAnsi((IntPtr)getName());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return string.Empty;
        }
    }

    internal static unsafe uint GetRuneCooldown(int index)
    {
        try
        {
            var getCooldownStart =
                Marshal.GetDelegateForFunctionPointer<Delegates.GetRuneStart>((IntPtr)Offsets.Functions.RuneStart);
            return (uint)getCooldownStart(index);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return 0;
        }
    }
}