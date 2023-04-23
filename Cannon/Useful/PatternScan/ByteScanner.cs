using System.Collections;
using System.Runtime.CompilerServices;

namespace Cannon.Useful.PatternScan;

internal class ByteScanner
{
    private const int Wildcard = 0xCC;
    private static ref T GetArrayDataReference<T>(IEnumerable array)
        => ref Unsafe.As<byte, T>(ref Unsafe.As<RawArrayData>(array).Data);
    internal static void GenerateWildcardPattern(ref ByteMask mask, ref byte[] newPattern)
    {
        var mskLen = mask.Mask.Length;
        Buffer.BlockCopy(mask.Bytes, 0, newPattern, 0, mask.Bytes.Length);
        for (var i = 0; i < mskLen; i++)
            if (mask.Mask[i] != 'x')
                newPattern[i] = Wildcard;
    }
    internal static bool CompareByteArray(ref ByteMask mask, ref byte data, ref byte[] newPattern)
    {
        var iSignature = 1;
        data = ref Unsafe.Add(ref data, 1);
        ref var signature = ref Unsafe.Add(ref GetArrayDataReference<byte>(newPattern), 1);

        for (; iSignature < mask.Bytes.Length; ++iSignature,
             data = ref Unsafe.Add(ref data, 1),
             signature = ref Unsafe.Add(ref signature, 1))
        {
            if (signature == Wildcard) continue;
            if (data == signature) continue;
            return false;
        }
        return true;
    }

    sealed class RawArrayData
    {
        public uint Length;
        public uint Padding;
        public byte Data;
    }
}