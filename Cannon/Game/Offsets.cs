using System;

namespace Cannon.Game;

internal class Offsets
{
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

    internal class Spellbook
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