using System.Runtime.InteropServices;

namespace Cannon.Warcraft.Structs;

[StructLayout(LayoutKind.Explicit)]
internal struct Vector3
{
    [FieldOffset(0x0)] 
    internal float X;

    [FieldOffset(0x4)] 
    internal float Y;

    [FieldOffset(0x8)] 
    internal float Z;

    public override string ToString()
        => $"{{{X}, {Y}, {Z}}}";
}

[StructLayout(LayoutKind.Explicit)]
internal struct Vector4
{
    [FieldOffset(0x0)]
    internal float X;

    [FieldOffset(0x4)]
    internal float Y;

    [FieldOffset(0x8)]
    internal float Z;

    [FieldOffset(0xC)]
    internal float W;
}