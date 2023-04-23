using System.Globalization;

namespace Cannon.Useful.PatternScan;

internal class ByteMask
{
    private readonly string? _pattern;
    internal ByteMask(string value) => _pattern = value;

    private string? _mask;
    internal string Mask
    {
        get
        {
            if (!string.IsNullOrEmpty(_mask))
                return _mask;

            var strings = _pattern?.Split('\\');
            for (var i = 0; i < strings?.Length; i++)
                _mask += strings[i] != "x00" ? "x" : "?";

            return _mask ?? string.Empty;
        }
    }

    private byte[]? _bytes;
    internal byte[] Bytes
    {
        get
        {
            try
            {
                if (_bytes is { Length: > 0 }) return _bytes;
                var strings = _pattern?.Split('\\');
                _bytes = new byte[strings?.Length ?? 0];
                for (var i = 0; i < _bytes.Length; i++)
                    if (!byte.TryParse(strings?[i].Replace("x", string.Empty),
                            NumberStyles.HexNumber, null, out _bytes[i]))
                        return Array.Empty<byte>();

                return _bytes;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Array.Empty<byte>();
            }
        }
    }

    internal Tuple<int, int>[] Offsets
    {
        get
        {
            try
            {
                var tuples = new List<Tuple<int, int>>();
                var strings = _pattern?.Split('\\');

                var start = 0;
                var length = 0;

                for (var i = 0; i < strings?.Length; i++)
                {
                    var isCarded = strings[i] == "x00";
                    var isLastByte = i == strings.Length - 1;

                    if (isCarded && !isLastByte)
                    {
                        if (start == 0)
                            start = i + 1;
                        length++;
                    }
                    else
                    {
                        if (start == 0) continue;
                        tuples.Add(new Tuple<int, int>(start - 1, length));
                        length = 0;
                        start = 0;
                    }
                }

                return tuples.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Array.Empty<Tuple<int, int>>();
            }
        }
    }
}