using Cannon.Useful.PatternScan;
using System;
using System.Drawing;
using System.Net;
using System.Runtime.CompilerServices;

namespace Cannon.Game;

internal class Scanner
{
    internal static unsafe object Function(string pattern, bool addBase = false)
    {
        try
        {
            if (string.IsNullOrEmpty(pattern)) return 0;

            var mask = new ByteMask(pattern);
            if (mask.Offsets.Length <= 0) return 0;

            var match = FindAddress((byte*)(Client.Address), mask);

            if (match <= 0) return 0;
            return !addBase ? match : match + Client.Address.ToInt64();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return 0;
        }
    }

    internal static object Offset(string pattern, bool readBytes)
        => Offset(pattern, 0, 0, readBytes);
    internal static object Offset(string pattern, int index, bool readBytes)
        => Offset(pattern, index, 0, readBytes);
    internal static object Offset(string pattern, int index, int modifier, bool readBytes = false)
    {
        try
        {
            if (string.IsNullOrEmpty(pattern)) return 0;
            var address = (int)(long)Function(pattern);
            if (address == 0) return 0;

            var mask = new ByteMask(pattern);
            if (index < 0 || index >= mask.Offsets.Length) return 0;

            var chunk = mask.Offsets[index];
            var result = Get(address, chunk.Item1, chunk.Item2, modifier, readBytes);
            return result ?? 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return 0;
        }
    }

    private static object? Get(int match, int offset, int size, int modifier = 0, bool isField = false)
    {
        try
        {
            if (match == 0 || size <= 0) return null;
            var address = (match + offset);
            var mod = (isField ? 0 : match + (offset + size)) + modifier;
            return size switch
            {
                >= 5 => Client.Read<int>(address) + mod,
                2 => Client.Read<short>(address) + mod,
                1 => Client.Read<byte>(address) + mod,
                4 => Client.Read<int>(address) + mod,
                _ => null
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
    private static unsafe int FindAddress(byte* bytes, ByteMask mask)
    {
        try
        {
            var iBaseAddress = 0;
            var first = mask.Bytes[0];
            var max = Client.Size - mask.Bytes.Length;

            var newPattern = new byte[mask.Bytes.Length];
            ByteScanner.GenerateWildcardPattern(ref mask, ref newPattern);

            ref var baseAddress = ref bytes[0];
            for (; iBaseAddress < max; ++iBaseAddress, baseAddress = ref Unsafe.Add(ref baseAddress, 1))
            {
                if (baseAddress != first) continue;
                if (ByteScanner.CompareByteArray(ref mask, ref baseAddress, ref newPattern))
                    return iBaseAddress;
            }

            return 0;
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Source} -> {e.Message}");
            return -1;
        }
    }
}