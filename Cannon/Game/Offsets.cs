using System;

namespace Cannon.Game;

internal class Offsets
{
    internal class Chat
    {
        private static int chatOpen;
        internal static int Open
        {
            get
            {
                try
                {
                    if (chatOpen > 0) return chatOpen;
                    chatOpen = (int)Scanner.Offset(Pattern.ChatOpen,false);
                    return chatOpen;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        private static int chatStart;
        internal static int Start
        {
            get
            {
                try
                {
                    if (chatStart > 0) return chatStart;
                    chatStart = (int)Scanner.Offset(Pattern.ChatStart, false);
                    return chatStart;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        private static int chatOffset;
        internal static int Offset
        {
            get
            {
                try
                {
                    if (chatOffset > 0) return chatOffset;
                    chatOffset = (int)Scanner.Offset(Pattern.ChatMessage, 6, 0, true);
                    return chatOffset;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        private static int chatMessage;
        internal static int Message
        {
            get
            {
                try
                {
                    if (chatMessage > 0) return chatMessage;
                    chatMessage = (int)Scanner.Offset(Pattern.ChatMessage, 2, 0, true);
                    return chatMessage;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }
    }

    internal class Guids
    {
        private static int target;
        internal static int TargetGuid
        {
            get
            {
                try
                {
                    if (target > 0) return target;
                    target = (int)Scanner.Offset(Pattern.UnitGuid, 0, -0x8, false);
                    return target;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        private static int lastTarget;
        internal static int LastTargetGuid
        {
            get
            {
                try
                {
                    if (lastTarget > 0) return lastTarget;
                    lastTarget = (int)Scanner.Offset(Pattern.UnitGuid, 0, -0x8 + 0x10, false);
                    return lastTarget;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        private static int previousAlly;
        internal static int LastFriendlyGuid
        {
            get
            {
                try
                {
                    if (previousAlly > 0) return previousAlly;
                    previousAlly = (int)Scanner.Offset(Pattern.UnitGuid, 0, -0x8 + 0x20, false);
                    return previousAlly;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        private static int previousEnemy;
        internal static int LastEnemyGuid
        {
            get
            {
                try
                {
                    if (previousEnemy > 0) return previousEnemy;
                    previousEnemy = (int)Scanner.Offset(Pattern.UnitGuid, 0, -0x8 + 0x30, false);
                    return previousEnemy;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        private static int focus;
        internal static int FocusGuid
        {
            get
            {
                try
                {
                    if (focus > 0) return focus;
                    focus = (int)Scanner.Offset(Pattern.UnitGuid, 0, -0x8 + 0x40, false);
                    return focus;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        private static int dialogWindow;
        internal static int DialogWindowGuid
        {
            get
            {
                try
                {
                    if (dialogWindow > 0) return dialogWindow;
                    dialogWindow = (int)Scanner.Offset(Pattern.UnitGuid, 0, -0x8 + 0x50, false);
                    return dialogWindow;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        private static int mouseGuid;
        internal static int MouseoverGuid
        {
            get
            {
                try
                {
                    if (mouseGuid > 0) return mouseGuid;
                    mouseGuid = (int)Scanner.Offset(Pattern.MouseoverGuid, false);
                    return mouseGuid;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        private static int playerGuid;
        internal static int PlayerGuid
        {
            get
            {
                try
                {
                    if (playerGuid > 0) return playerGuid;
                    playerGuid = (int)Scanner.Offset(Pattern.PlayerGuid, false);
                    return playerGuid;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        private static int petGuid;
        internal static int PetGuid
        {
            get
            {
                try
                {
                    if (petGuid > 0) return petGuid;
                    petGuid = (int)Scanner.Offset(Pattern.PetGuid, false);
                    return petGuid;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }
    }

    internal class CVars
    {
        private static int clickToMove;
        internal static int ClickToMove
        {
            get
            {
                try
                {
                    if (clickToMove > 0) return clickToMove;
                    clickToMove = (int)Scanner.Offset(Pattern.ClickToMoveVar, 0, 0x8, false);
                    return clickToMove;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        private static int autoLoot;
        internal static int AutoLoot
        {
            get
            {
                try
                {
                    if (autoLoot > 0) return autoLoot;
                    autoLoot = (int)Scanner.Offset(Pattern.AutoLootVar, false);
                    return autoLoot;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        private static int cvarOffset;
        internal static int Offset
        {
            get
            {
                try
                {
                    if (cvarOffset > 0) return cvarOffset;
                    cvarOffset = (int)Scanner.Offset(Pattern.CVarOffset, 2, 0, true);
                    return cvarOffset;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }
    }

    internal class Camera
    {
        private static int _address;
        internal static int Address
        {
            get
            {
                try
                {
                    if (_address > 0) return _address;
                    _address = (int)Scanner.Offset(Pattern.ActiveCamera, false);
                    return _address;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        private static int _offset;
        internal static int Offset
        {
            get
            {
                try
                {
                    if (_offset > 0) return _offset;
                    _offset = (int)Scanner.Offset(Pattern.ActiveCamera, 1, 0, true);
                    return _offset;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }
    }

    internal class SpellBook
    {
        private static int playerBase;
        internal static int Address
        {
            get
            {
                try
                {
                    if (playerBase > 0) return playerBase;
                    playerBase = (int)Scanner.Offset(Pattern.PlayerSpellbook, 0, 0x8, false); 
                    return playerBase;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        private static int playerCount;
        internal static int Count
        {
            get
            {
                try
                {
                    if (playerCount > 0) return playerCount;
                    playerCount = (int)Scanner.Offset(Pattern.PlayerSpellbook, false);
                    return playerCount;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        private static int petBase;
        internal static int PetAddress
        {
            get
            {
                try
                {
                    if (petBase > 0) return petBase;
                    petBase = (int)Scanner.Offset(Pattern.PetSpellbook, 0, 0x8, false);
                    return petBase;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        private static int petCount;
        internal static int PetCount
        {
            get
            {
                try
                {
                    if (petCount > 0) return petCount;
                    petCount = (int)Scanner.Offset(Pattern.PetSpellbook, false);
                    return petCount;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }
    }

    internal class ObjectManager
    {
        private static int managerBase;
        internal static int Address
        {
            get
            {
                try
                {
                    if (managerBase > 0) return managerBase;
                    managerBase = (int)Scanner.Offset(Pattern.ObjectManager,false);
                    return managerBase;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        private static int playerNames;
        internal static int PlayerNames
        {
            get
            {
                try
                {
                    if (playerNames > 0) return playerNames;
                    playerNames = (int)Scanner.Offset(Pattern.PlayerNames, false);
                    return playerNames;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        private static int cooldownArray;
        internal static int Cooldowns
        {
            get
            {
                try
                {
                    if (cooldownArray > 0) return cooldownArray;
                    cooldownArray = (int)Scanner.Offset(Pattern.Cooldowns, false);
                    return cooldownArray;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }

        private static int zoneId;
        internal static int ZoneID
        {
            get
            {
                try
                {
                    if (zoneId > 0) return zoneId;
                    zoneId = (int)Scanner.Offset(Pattern.ZoneID, false);
                    return zoneId;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }
    }

    internal class Functions
    {
        private static long playerName;
        internal static long PlayerName
        {
            get
            {
                try
                {
                    if (playerName > 0) return playerName;
                    playerName = (long)Scanner.Function(Pattern.PlayerName, true);
                    return playerName;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }
    }
}