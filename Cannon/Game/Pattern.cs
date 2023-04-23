using System;

namespace Cannon.Game;

internal class Pattern
{
    private static Wrath _wrath = new();
    internal class Wrath
    {
        internal readonly string playerName = @"x33\xC0\x48\x8D\x0D\x00\x00\x00\x00\x38\x05\x00\x00\x00\x00\x48\x0F\x45\xC1";

        internal readonly string activeCamera = @"x48\x8B\x05\x00\x00\x00\x00\x48\x8B\x88\x00\x00\x00\x00\x48\x8B\x43";

        internal readonly string petSpellbook = @"x4C\x8B\x0D\x00\x00\x00\x00\x90\x49\x8B\x0C\xD1\x8B\x41";
        internal readonly string playerSpellbook = @"x44\x8B\x15\x00\x00\x00\x00\x33\xD2\x8B\xCA";

        internal readonly string autoLoot = @"x48\x8B\x05\x00\x00\x00\x00\x48\x8D\x0D\x00\x00\x00\x00\x8B\x58\x00\xE8\x00\x00\x00\x00\x85\xDB\x0F\x95\xC1\x32\xC1\x48\x83\xC4\x00\x5B\xC3\x29\x80";
        internal readonly string clickToMove = @"x48\x8B\x05\x00\x00\x00\x00\x83\x78\x00\x00\x74\x00\xF6\x81\x00\x00\x00\x00\x00\x75\x00\xB0";

        internal readonly string objectManager = @"x48\x8B\x1D\x00\x00\x00\x00\x48\x85\xDB\x74\x00\x80\x3D\x00\x00\x00\x00\x00\x74\x00\x48\x8D\x0D";
        internal readonly string cooldownList = @"x48\x8D\x15\x00\x00\x00\x00\x48\x1B\xC9\x81\xE1\x00\x00\x00\x00\x48\x03\xCA\x8B\x53";
        internal readonly string playerNames = @"x48\x8D\x0D\x00\x00\x00\x00\x45\x8D\x41\x00\xE8\x00\x00\x00\x00\x41\xB9";
        internal readonly string zoneId = @"x89\x05\x00\x00\x00\x00\x84\xC9\x74";

        internal readonly string chatMain = @"x48\x8D\x15\x00\x00\x00\x00\x4C\x8D\x05\x00\x00\x00\x00\x80\xBA\x00\x00\x00\x00\x00\x74\x00\x8B\x01\x39\x82\x00\x00\x00\x00\x74\x00\x48\x81\xC2\x00\x00\x00\x00\x49\x3B\xD0\x75\x00\x32\xC0";
        internal readonly string chatOpen = @"x44\x39\x25\x00\x00\x00\x00\x0F\x8E";

        internal readonly string playerGuid = @"x48\x8D\x0D\x00\x00\x00\x00\xE8\x00\x00\x00\x00\x48\x83\xBC\x24\x00\x00\x00\x00\x00\x7C\x00\x48\x8B\x8C\x24\x00\x00\x00\x00\x48\x8D\x15\x00\x00\x00\x00\x45\x33\xC9\x45\x8D\x41\x00\xE8\x00\x00\x00\x00\x48\x81\xC4";
        internal readonly string unitsGuid = @"x48\x8B\x0D\x00\x00\x00\x00\x48\x85\xC0\x48\x8B\xC1";
        internal readonly string petGuid = @"x48\x8B\x05\x00\x00\x00\x00\x33\xDB\x45\x8B\xE1";
        internal readonly string mouseGuid = @"x0F\x11\x05\x00\x00\x00\x00\x0F\x10\x07";
    }

    private static Dragon _dragon = new();
    internal class Dragon
    {
        internal readonly string playerName = @"x33\xC0\x48\x8D\x0D\x00\x00\x00\x00\x38\x05\x00\x00\x00\x00\x48\x0F\x45\xC1";
        internal readonly string activeCamera = @"x48\x8B\x05\x00\x00\x00\x00\x48\x8B\x88\x00\x00\x00\x00\x48\x8B\x43";

        internal readonly string petSpellbook = @"x4C\x8B\x0D\x00\x00\x00\x00\x90\x49\x8B\x0C\xD1\x8B\x41";
        internal readonly string playerSpellbook = @"x44\x8B\x1D\x00\x00\x00\x00\x41\xF7\xD9";

        internal readonly string autoLoot = @"x48\x8B\x05\x00\x00\x00\x00\x48\x8D\x0D\x00\x00\x00\x00\x8B\x58\x00\xE8\x00\x00\x00\x00\x85\xDB\x0F\x95\xC1\x32\xC1\x48\x83\xC4\x00\x5B\xC3\x71";
        internal readonly string clickToMove = @"x48\x8B\x05\x00\x00\x00\x00\x83\x78\x00\x00\x74\x00\xF6\x81\x00\x00\x00\x00\x00\x75\x00\xB0";

        internal readonly string objectManager = @"x48\x8B\x1D\x00\x00\x00\x00\x48\x85\xDB\x74\x00\x80\x3D\x00\x00\x00\x00\x00\x74\x00\x48\x8D\x0D";
        internal readonly string cooldownList = @"x48\x8D\x15\x00\x00\x00\x00\x48\x1B\xC9\x81\xE1\x00\x00\x00\x00\x48\x03\xCA\x8B\x53";
        internal readonly string playerNames = @"x48\x8D\x0D\x00\x00\x00\x00\x45\x8D\x41\x00\xE8\x00\x00\x00\x00\x41\xB9";
        internal readonly string zoneId = @"x89\x05\x00\x00\x00\x00\x84\xC9\x74";

        internal readonly string chatMain = @"x48\x8D\x15\x00\x00\x00\x00\x4C\x8D\x05\x00\x00\x00\x00\x80\xBA\x00\x00\x00\x00\x00\x74\x00\x8B\x01\x39\x82\x00\x00\x00\x00\x74\x00\x48\x81\xC2\x00\x00\x00\x00\x49\x3B\xD0\x75\x00\x32\xC0";
        internal readonly string chatOpen = @"x44\x39\x25\x00\x00\x00\x00\x0F\x8E";

        internal readonly string playerGuid = @"x48\x8D\x0D\x00\x00\x00\x00\xE8\x00\x00\x00\x00\x48\x83\xBC\x24\x00\x00\x00\x00\x00\x7C\x00\x48\x8B\x8C\x24\x00\x00\x00\x00\x48\x8D\x15\x00\x00\x00\x00\x45\x33\xC9\x45\x8D\x41\x00\xE8\x00\x00\x00\x00\x48\x81\xC4";
        internal readonly string unitsGuid = @"x0F\x11\x05\x00\x00\x00\x00\x48\x89\x44\x24\x00\xE8\x00\x00\x00\x00\x40\x84\xFF"; 
        internal readonly string petGuid = @"x48\x8B\x05\x00\x00\x00\x00\x33\xDB\x45\x8B\xE1"; 
        internal readonly string mouseGuid = @"x0F\x11\x05\x00\x00\x00\x00\x0F\x10\x07";
    }

    #region Object Manager

    internal static string ObjectManager
        => Client.Expansion switch
        {
            10 => _dragon.objectManager,
            3 => _wrath.objectManager,
            _ => string.Empty
        };
    internal static string PlayerNames
        => Client.Expansion switch
        {
            10 => _dragon.playerNames,
            3 => _wrath.playerNames,
            _ => string.Empty
        };
    internal static string Cooldowns
        => Client.Expansion switch
        {
            10 => _dragon.cooldownList,
            3 => _wrath.cooldownList,
            _ => string.Empty
        };
    internal static string ZoneID
        => Client.Expansion switch
        {
            10 => _dragon.zoneId,
            3 => _wrath.zoneId,
            _ => string.Empty
        };

    #endregion

    #region Functions

    internal static string PlayerName
        => Client.Expansion switch
        {
            10 => _dragon.playerName,
            3 => _wrath.playerName,
            _ => string.Empty
        };

    #endregion

    #region General

    internal static string ActiveCamera
        => Client.Expansion switch
        {
            10 => _dragon.activeCamera,
            3 => _wrath.activeCamera,
            _ => string.Empty
        };

    #endregion

    #region Spells

    internal static string PetSpellbook
        => Client.Expansion switch
        {
            10 => _dragon.petSpellbook,
            3 => _wrath.petSpellbook,
            _ => string.Empty
        };
    internal static string PlayerSpellbook
        => Client.Expansion switch
        {
            10 => _dragon.playerSpellbook,
            3 => _wrath.playerSpellbook,
            _ => string.Empty
        };

    #endregion

    #region Guids

    internal static string MouseoverGuid
        => Client.Expansion switch
        {
            10 => _dragon.mouseGuid,
            3 => _wrath.mouseGuid,
            _ => string.Empty
        };
    internal static string PlayerGuid
        => Client.Expansion switch
        {
            10 => _dragon.playerGuid,
            3 => _wrath.petGuid,
            _ => string.Empty
        };
    internal static string UnitGuid
        => Client.Expansion switch
        {
            10 => _dragon.unitsGuid,
            3 => _wrath.unitsGuid,
            _ => string.Empty
        };
    internal static string PetGuid
        => Client.Expansion switch
        {
            10 => _dragon.petGuid,
            3 => _wrath.petGuid,
            _ => string.Empty
        };

    #endregion

    #region CVars

    internal static string ClickToMoveVar
        => Client.Expansion switch
        {
            10 => _dragon.clickToMove,
            3 => _wrath.clickToMove,
            _ => string.Empty
        };

    internal static string AutoLootVar
        => Client.Expansion switch
        {
            10 => _dragon.autoLoot,
            3 => _wrath.autoLoot,
            _ => string.Empty
        };
    internal static string CVarOffset
        => Client.Expansion switch
        {
            10 => _dragon.autoLoot,
            3 => _wrath.autoLoot,
            _ => string.Empty
        };

    #endregion

    #region Chat

    internal static string ChatOpen
        => Client.Expansion switch
        {
            10 => _dragon.chatOpen,
            3 => _wrath.chatOpen,
            _ => string.Empty
        };

    internal static string ChatStart
        => Client.Expansion switch
        {
            10 => _dragon.chatMain,
            3 => _wrath.chatMain,
            _ => string.Empty
        };

    internal static string ChatOffset
        => Client.Expansion switch
        {
            10 => _dragon.chatMain,
            3 => _wrath.chatMain,
            _ => string.Empty
        };

    internal static string ChatMessage
        => Client.Expansion switch
        {
            10 => _dragon.chatMain,
            3 => _wrath.chatMain,
            _ => string.Empty
        };

    #endregion
}