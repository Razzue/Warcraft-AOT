using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using RazzSharp.Warcraft.Scanner;
using RazzSharp.Warcraft.Scanner.Events;

namespace RazzSharp.Warcraft
{
    // ToDo : Clean up code and comments

    internal class Pattern
    {
        private byte[] _bytes;

        internal Pattern()
        {
            _bytes = Memory.ReadArray<byte>(Client.Address, Client.Size) ?? Array.Empty<byte>();
            byteScan = new();
        }

        private ByteScanner byteScan;

        internal EventHandler<ScanStartedArgs>? OnScanStarted;
        internal EventHandler<PatternMatchedArgs> OnMatchFound;

        /// <summary>
        /// Return the match location of the input pattern.
        /// </summary>
        /// <typeparam name="T">Type of value to read. Only primitive types supported.</typeparam>
        /// <param name="name">Variable identifier. Only used for events.</param>
        /// <param name="pattern">Value to search for.</param>
        /// <returns></returns>
        internal T? Scan1<T>(string name, string pattern)
        {
            var sw = new Stopwatch();
            sw.Restart();

            try
            {
                var data = new ByteMask(pattern);
                if (_bytes is { Length: <= 0 }) throw new Exception("Process memory has not been loaded.");
                if (string.IsNullOrEmpty(pattern)) throw new Exception("Can not scan for an empty pattern.");
                if (data.Positions().Length <= 0) throw new Exception("Could not locate pattern wildcards.");

                OnScanStarted?.Invoke(this, new ScanStartedArgs(name));
                var match = byteScan.FindPattern(_bytes, data);
                if (match == 0) throw new Exception($"Could not find pattern for {name}.");

                OnMatchFound?.Invoke(this, new PatternMatchedArgs(match, name, sw.Elapsed.TotalMilliseconds));
                return (T)Convert.ChangeType(match, typeof(T));
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Scanner] {e.Message}");
                return default;
            }
        }

        internal T? Scan2<T>(string name, string pattern, int location = 0, bool readBytes = false)
        {
            var sw = new Stopwatch();
            sw.Restart();

            try
            {
                var data = new ByteMask(pattern);
                if (_bytes is { Length: <= 0 }) throw new Exception("Process memory has not been loaded.");
                if (string.IsNullOrEmpty(pattern)) throw new Exception("Can not scan for an empty pattern.");
                if (data.Positions().Length <= 0) throw new Exception("Could not locate pattern wildcards.");

                OnScanStarted?.Invoke(this, new ScanStartedArgs(name));
                var match = byteScan.FindPattern(_bytes, data);
                if (match == 0) throw new Exception($"Could not find pattern for {name}.");

                var result = readBytes
                    ? ReadField<T>(match, data.Positions(), location)
                    : ReadValue<T>(match, data.Positions(), location);

                if(null == result) return default;
                OnMatchFound?.Invoke(this, new PatternMatchedArgs(result, name, sw.Elapsed.TotalMilliseconds));
                return (T)Convert.ChangeType(result, typeof(T));
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Scanner] {e.Message}");
                return default;
            }
        }
        private T? ReadField<T>(int matched, int[] positions, int location)
        {
            try
            {
                if (matched == 0) return default;
                if (location >= positions.Length) location = 0;
                var position = positions[location];
                var address = Client.Address;

                var offset = matched + position;
                var size = typeof(T) != typeof(bool) ? Marshal.SizeOf<T>() : 1;
                var array = Memory.ReadArray<byte>(address + offset, size);

                var s = string.Empty;
                for (var i = array.Length - 1; i >= 0; i--)
                    s += array[i].ToString("X");

                if (!int.TryParse(s, NumberStyles.HexNumber, null, out var result))
                    return default;

                return (T)Convert.ChangeType(result, typeof(T));
            }
            catch (Exception e)
            {
                Console.WriteLine($@"[Scanner] {e.Message}");
                return default;
            }
        }
        private T? ReadValue<T>(int matched, int[] positions, int location)
        {
            try
            {
                if (matched == 0) return default;
                if (location >= positions.Length) location = 0;
                var position = positions[location];
                var address = Client.Address;

                var size = typeof(T) != typeof(bool)? Marshal.SizeOf<T>() : 1;
                var value = Memory.Read<int>(address + (matched + position));
                var valueAddress = (address + (matched + (position + size))) + value;

                var result = valueAddress.ToInt64() - address.ToInt64();
                return (T)Convert.ChangeType(result, typeof(T));
            }
            catch (Exception e)
            {
                Console.WriteLine($@"[Scanner] {e.Message}");
                return default;
            }
        }
    }
}