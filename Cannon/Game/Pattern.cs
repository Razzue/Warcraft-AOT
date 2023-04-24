using System;

namespace Cannon.Game;

internal class Pattern
{
    private static Wrath _wrath = new();
    internal class Wrath
    {
        internal readonly string f_playerName = @"x33\xC0\x48\x8D\x0D\x00\x00\x00\x00\x38\x05\x00\x00\x00\x00\x48\x0F\x45\xC1";

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

        internal readonly string wowBindings = @"x48\x8B\x0D\x00\x00\x00\x00\x33\xDB\x89\x1D\x00\x00\x00\x00\xF6\xC1";

        internal readonly string activeParty = @"x4C\x8D\x35\x00\x00\x00\x00\x41\x8B\xDC";
        internal readonly string runeBase = @"x8B\x84\x08\x00\x00\x00\x00\xC3\x8B\x84\x08";

        internal readonly string macroBase = @"x48\x8B\x05\x00\x00\x00\x00\xA8\x00\x75\x00\x48\x85\xC0\x74\x00\x33\xC9\xEB\x00\xB9\x00\x00\x00\x00\x33\xDB\x85\xC9\x48\x0F\x44\xD8\xF6\xC3\x00\x75\x00\x48\x85\xDB\x74\x00\x48\x63\x05";

        internal readonly string globalMessage = @"x48\x8D\x0D\x00\x00\x00\x00\x41\xB8\x00\x00\x00\x00\x48\x8D\x95\x00\x00\x00\x00\x0F\x1F\x40";
        internal readonly string lootWindow = @"x0F\xB6\x15\x00\x00\x00\x00\x48\x3B\xC1\x0F\x42\xC8\xE8\x00\x00\x00\x00\xC7\x05";
        internal readonly string corpsePosition = @"x8B\x05\x00\x00\x00\x00\x89\x06\x8B\x05\x00\x00\x00\x00\x89\x07\xB0";
        internal readonly string frameBase = @"x48\x8B\x0D\x00\x00\x00\x00\xE8\x00\x00\x00\x00\x33\xD2\x48\x8B\xCB";
        internal readonly string gameStatus = @"x88\x05\x00\x00\x00\x00\x48\x8D\x0D\x00\x00\x00\x00\x48\x8D\x05";
        internal readonly string combatLog = @"x48\x8B\x15\x00\x00\x00\x00\x33\xDB\x4C\x63\xC0";
    }

    private static Dragon _dragon = new();
    internal class Dragon
    {
        internal readonly string f_playerName = @"x33\xC0\x48\x8D\x0D\x00\x00\x00\x00\x38\x05\x00\x00\x00\x00\x48\x0F\x45\xC1";

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

        internal readonly string wowBindings = @"x48\x8B\x0D\x00\x00\x00\x00\x33\xDB\x89\x1D\x00\x00\x00\x00\xF6\xC1";

        internal readonly string activeParty = @"x48\x8B\x1D\x00\x00\x00\x00\x48\x85\xDB\x74\x00\x0F\xB6\x93";
        internal readonly string runeBase = @"x48\x63\xC1\x48\x8D\x0D\x00\x00\x00\x00\x8B\x04\x81\xC3\xCC\xCC\x40\x53";

        internal readonly string macroBase = @"x48\x8B\x05\x00\x00\x00\x00\xA8\x00\x75\x00\x48\x85\xC0\x74\x00\x33\xC9\xEB\x00\xB9\x00\x00\x00\x00\x33\xDB\x85\xC9\x48\x0F\x44\xD8\xF6\xC3\x00\x75\x00\x48\x85\xDB\x74\x00\x48\x63\x05";

        internal readonly string globalMessage = @"x48\x8D\x0D\x00\x00\x00\x00\x41\xB8\x00\x00\x00\x00\x48\x8D\x95\x00\x00\x00\x00\x0F\xB6\x02";
        internal readonly string corpsePosition = @"x8B\x05\x00\x00\x00\x00\x89\x06\x8B\x05\x00\x00\x00\x00\x89\x07\xB0";
        internal readonly string frameBase = @"x48\x8B\x0D\x00\x00\x00\x00\xE8\x00\x00\x00\x00\x33\xD2\x48\x8B\xCB";
        internal readonly string combatLog = @"x48\x8B\x15\x00\x00\x00\x00\x33\xDB\x4C\x63\xC0";
        internal readonly string gameStatus = @"x66\x89\x0D\x00\x00\x00\x00\x48\x8D\x05";
        internal readonly string lootWindow = @"x88\x05\x00\x00\x00\x00\x85\xDB";
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
            10 => _dragon.f_playerName,
            3 => _wrath.f_playerName,
            _ => string.Empty
        };

    #endregion

    #region Bindings

    internal static string UserBindings
        => Client.Expansion switch
        {
            10 => _dragon.wowBindings,
            3 => _wrath.wowBindings,
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

    #region Globals

    internal static string CorpsePosition
        => Client.Expansion switch
        {
            10 => _dragon.corpsePosition,
            3 => _wrath.corpsePosition,
            _ => string.Empty
        };

    internal static string LootWindow
        => Client.Expansion switch
        {
            10 => _dragon.lootWindow,
            3 => _wrath.lootWindow,
            _ => string.Empty
        };

    internal static string CombatLog
        => Client.Expansion switch
        {
            10 => _dragon.combatLog,
            3 => _wrath.combatLog,
            _ => string.Empty
        };

    internal static string UIFrames
        => Client.Expansion switch
        {
            10 => _dragon.frameBase,
            3 => _wrath.frameBase,
            _ => string.Empty
        };

    internal static string Message
        => Client.Expansion switch
        {
            10 => _dragon.globalMessage,
            3 => _wrath.globalMessage,
            _ => string.Empty
        };

    internal static string Status
        => Client.Expansion switch
        {
            10 => _dragon.gameStatus,
            3 => _wrath.gameStatus,
            _ => string.Empty
        };

    #endregion

    #region Macros

    internal static string MacroBase
        => Client.Expansion switch
        {
            10 => _dragon.macroBase,
            3 => _wrath.macroBase,
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

    #region Runes

    internal static string PlayerRunes
        => Client.Expansion switch
        {
            10 => _dragon.runeBase,
            3 => _wrath.runeBase,
            _ => string.Empty
        };

    #endregion

    #region Group

    internal static string ActiveParty
        => Client.Expansion switch
        {
            10 => _dragon.activeParty,
            3 => _wrath.activeParty,
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
            3 => _wrath.playerGuid,
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