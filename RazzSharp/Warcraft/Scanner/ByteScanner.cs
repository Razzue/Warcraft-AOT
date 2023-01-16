using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace RazzSharp.Warcraft.Scanner
{
    internal class ByteScanner
    {
        private const int Wildcard = 0xCC;
        internal int FindPattern(byte[] cbMemory, ByteMask byteMask)
        {
            var bytes = byteMask.Bytes();
            var mask = byteMask.Mask();

            var iBaseAddress = 0;
            var first = bytes[0];
            var max = cbMemory.Length - bytes.Length;

            var newPattern = new byte[bytes.Length];
            var signatureLength = newPattern.Length;

            GenerateWildcardPattern(in bytes, ref newPattern, mask);

            ref var baseAddress = ref cbMemory[0];
            for (; iBaseAddress < max; ++iBaseAddress, baseAddress = ref Unsafe.Add(ref baseAddress, 1))
            {
                if (baseAddress != first) continue;
                if (CompareByteArray(ref baseAddress, ref newPattern, signatureLength))
                    return iBaseAddress;
            }

            return 0;
        }
        private bool CompareByteArray(ref byte data, ref byte[] newPattern, int signatureLength)
        {
            var iSignature = 1;
            data = ref Unsafe.Add(ref data, 1);
            ref var signature = ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(newPattern), 1);

            for (; iSignature < signatureLength; ++iSignature, data = ref Unsafe.Add(ref data, 1), signature = ref Unsafe.Add(ref signature, 1))
            {
                if (signature == Wildcard)
                    continue;
                if (data != signature)
                    return false;
            }
            return true;
        }
        private void GenerateWildcardPattern(in byte[] cbPattern, ref byte[] newPattern, string szMask)
        {
            var mskLen = szMask.Length;
            Buffer.BlockCopy(cbPattern, 0, newPattern, 0, cbPattern.Length);
            for (var i = 0; i < mskLen; i++) if (szMask[i] != 'x') newPattern[i] = Wildcard;
        }
    }
}