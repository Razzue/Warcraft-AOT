using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Cannon.Warcraft.Structs;

[StructLayout(LayoutKind.Explicit)]
internal struct Matrix3x3
{
    [FieldOffset(0x0)]
    internal Vector3 X;

    [FieldOffset(0xC)]
    internal Vector3 Y;

    [FieldOffset(0x18)]
    internal Vector3 Z;
}

[StructLayout(LayoutKind.Explicit)]
internal struct Matrix4x4
{
    [FieldOffset(0x0)]
    internal Vector4 X;

    [FieldOffset(0x10)]
    internal Vector4 Y;

    [FieldOffset(0x20)]
    internal Vector4 Z;

    [FieldOffset(0x30)]
    internal Vector4 W;
}