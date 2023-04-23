using System.Runtime.InteropServices;

namespace Cannon.Warcraft.Structs;

[StructLayout(LayoutKind.Explicit)]
internal struct Camera
{
    [FieldOffset(0x10)]
    internal Vector3 Location;

    [FieldOffset(0x1C)]
    internal Matrix3x3 Matrix;

    [FieldOffset(0x40)]
    internal float Fov;
}