
namespace RazzSharp.Warcraft;

internal class Offsets
{
    internal Scripts Scripts { get; set; } = new();
    internal Functions Functions { get; set; } = new();

    internal CameraOffsets Camera { get; set; } = new();
    internal CombatLogOffsets CombatLog { get; set; } = new();
    internal ObjectManagerOffsets ObjectManager { get; set; } = new();
}

#region Script and function offsets

internal class Scripts
{
    private int _targetUnit;
    internal int TargetUnit
    {
        get
        {
            try
            {
                if (_targetUnit != 0) return _targetUnit;
                _targetUnit = Client.Scanner.Scan1<int>("Script_TargetUnit",
                    "48 89 5C 24 ? 57 48 83 EC ? 45 33 C0 48 8B D9 41 8D 50 ? E8 ? ? ? ? BA ? ? ? ?");
                return _targetUnit;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
    }

    private int _targetNearest;
    internal int TargetNearest
    {
        get
        {
            try
            {
                if (_targetNearest != 0) return _targetNearest;
                _targetNearest = Client.Scanner.Scan1<int>("Script_TargetNearest",
                    "48 83 EC ? 48 83 3D ? ? ? ? ? 74 ? F6 05 ? ? ? ? ? 74 ? BA ? ? ? ? E8 ? ? ? ? 44 8B C0 48 8D 54 24 ? 41 B9 ? ? ? ? 48 8D 0D ? ? ? ? E8 ? ? ? ? 83 25 ? ? ? ? ? 33 C0 48 83 C4 ? C3 86 05 ? ? ? ?");
                return _targetNearest;
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
    // void __fastcall sub_E395C0(__int64 a1, __int64 a2, unsigned int a3)
    private int _netClientSend1;
    internal int NetClientSend1
    {
        get
        {
            try
            {
                if (_netClientSend1 != 0) return _netClientSend1;
                _netClientSend1 = Client.Scanner.Scan1<int>("NetClient::Send1",
                    "4C 8B DC 49 89 5B ? 49 89 6B ? 49 89 73 ? 57 48 83 EC ? 33 C0 48 8D 2D ? ? ? ?");
                return _netClientSend1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
    }

    // void __fastcall sub_E39350(__int64 a1, __int64 a2, unsigned int a3)
    private int _netClientSend2;
    internal int NetClientSend2
    {
        get
        {
            try
            {
                if (_netClientSend2 != 0) return _netClientSend2;
                _netClientSend2 = Client.Scanner.Scan1<int>("NetClient::Send2",
                    "40 53 57 41 55 48 81 EC ? ? ? ? 48 8D 41 ?");
                return _netClientSend2;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
    }

    // _QWORD *__fastcall sub_12DC700(_QWORD *a1, char a2)
    private int _netClientProcessMessage;
    internal int NetClientProcessMessage
    {
        get
        {
            try
            {
                if (_netClientProcessMessage != 0) return _netClientProcessMessage;
                _netClientProcessMessage = Client.Scanner.Scan1<int>("NetClient::ProcessMessage",
                    "48 89 5C 24 ? 48 89 74 24 ? 57 48 83 EC ? 48 8D 05 ? ? ? ? 48 8B F1 48 89 01 8B FA 48 83 C1 ? E8 ? ? ? ? 48 8D 4E ? E8 ? ? ? ? 48 8B CE E8 ? ? ? ? 40 F6 C7 ? 74 ? BA ? ? ? ? 48 8B CE E8 ? ? ? ? 48 8B 5C 24 ? 48 8B C6 48 8B 74 24 ? 48 83 C4 ? 5F C3 ? ? 41 B8 ? ? ? ?");
                return _netClientProcessMessage;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
    }
}

#endregion

#region Game Offsets

internal class CameraOffsets
{
    private int _address;
    internal int Address
    {
        get
        {
            try
            {
                if (_address != 0) return _address;
                _address = Client.Scanner.Scan2<int>(
                    "Address",
                    "48 8B 05 ?? ?? ?? ?? 48 8B 88 ?? ?? ?? ?? 48 8B 43 ?? 48 39 81 ?? ?? ?? ??");
                return _address;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
    }

    private int _offset;
    internal int Offset
    {
        get
        {
            try
            {
                if (_offset != 0) return _offset;
                _offset = Client.Scanner.Scan2<int>(
                    "Offset",
                    "48 8B 05 ?? ?? ?? ?? 48 8B 88 ?? ?? ?? ?? 48 8B 43 ?? 48 39 81 ?? ?? ?? ??",
                    1,
                    true);
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

internal class CombatLogOffsets
{
    private int _address;
    internal int Address
    {
        get
        {
            try
            {
                if (_address != 0) return _address;
                _address = Client.Scanner.Scan2<int>(
                    "Address",
                    "48 8B 15 ?? ?? ?? ?? 33 DB 4C 63 C0");
                return _address;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
    }

    private int _typeOffset;
    internal int TypeOffset
    {
        get
        {
            try
            {
                if (_typeOffset != 0) return _typeOffset;
                _typeOffset = Client.Scanner.Scan2<short>(
                    "Type Offset",
                    "83 79 ? ? 48 8B 79 ? 75 ?", 0, true);
                return _typeOffset;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
    }
}

internal class ObjectManagerOffsets
{
    private int _address;
    internal int Address
    {
        get
        {
            try
            {
                if (_address != 0) return _address;
                _address = Client.Scanner.Scan2<int>(
                    "Address",
                    "48 8B 1D ?? ?? ?? ?? 48 85 DB 74 ?? 80 3D ?? ?? ?? ?? ?? 74 ?? 48 8D 0D ?? ?? ?? ??");
                return _address;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
    }

    private int _zoneId;
    internal int ZoneId
    {
        get
        {
            try
            {
                if (_zoneId != 0) return _zoneId;
                _zoneId = Client.Scanner.Scan2<int>(
                    "Zone Id",
                    "89 05 ?? ?? ?? ?? 84 C9 74 ?? 4C 8D 4C 24 ??");
                return _zoneId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
    }

    private int _nameCache;
    internal int NameCache
    {
        get
        {
            try
            {
                if (_nameCache != 0) return _nameCache;
                _nameCache = Client.Scanner.Scan2<int>(
                    "Name Cache",
                    "48 8D 0D ?? ?? ?? ?? 45 8D 41 ?? E8 ?? ?? ?? ?? 41 B9 ?? ?? ?? ??");
                return _nameCache;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
    }
}

#endregion

internal class Fields
{

}