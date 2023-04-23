using System;

namespace Cannon.Game;

internal class Pattern
{
    private static Wrath _wrath = new();
    internal class Wrath
    {
        internal readonly string playerName = @"x33\xC0\x48\x8D\x0D\x00\x00\x00\x00\x38\x05\x00\x00\x00\x00\x48\x0F\x45\xC1";
        internal readonly string activeCamera = @"x48\x8B\x05\x00\x00\x00\x00\x48\x8B\x88\x00\x00\x00\x00\x48\x8B\x43";

        internal readonly string playerSpellbook = @"x44\x8B\x15\x00\x00\x00\x00\x33\xD2\x8B\xCA";
    }

    private static Dragon _dragon = new();
    internal class Dragon
    {
        internal readonly string playerName = @"x33\xC0\x48\x8D\x0D\x00\x00\x00\x00\x38\x05\x00\x00\x00\x00\x48\x0F\x45\xC1";
        internal readonly string activeCamera = @"x48\x8B\x05\x00\x00\x00\x00\x48\x8B\x88\x00\x00\x00\x00\x48\x8B\x43";

        internal readonly string playerSpellbook = @"x44\x8B\x1D\x00\x00\x00\x00\x41\xF7\xD9";
    }

    internal static string PlayerName
        => Client.Expansion switch
        {
            10 => _dragon.playerName,
            3 => _wrath.playerName,
            _ => string.Empty
        };
    internal static string ActiveCamera
        => Client.Expansion switch
        {
            10 => _dragon.activeCamera,
            3 => _wrath.activeCamera,
            _ => string.Empty
        };

    internal static string PlayerSpellbook 
        => Client.Expansion switch
    {
        10 => _dragon.playerSpellbook,
        3 => _wrath.playerSpellbook,
        _ => string.Empty
    };
}