namespace RazzSharp.Warcraft.Scanner;

internal class ByteMask
{
    private string _input;
    internal ByteMask(string input)
        => _input = input;

    public string Mask()
    {
        try
        {
            var szMask = string.Empty;
            var saPattern = _input.Split(' ');

            for (var i = 0; i < saPattern.Length; i++)
                if (IsValidWildcard(saPattern[i])) szMask += "?";
                else szMask += "x";

            return szMask;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return _input;
        }
    }
    internal byte[] Bytes()
    {
        try
        {
            var saPattern = _input.Split(' ');
            for (var i = 0; i < saPattern.Length; i++)
            {
                if (IsValidWildcard(saPattern[i]))
                    saPattern[i] = "0";
            }

            var bPattern = new byte[saPattern.Length];
            for (var i = 0; i < saPattern.Length; i++)
            {
                // Console.WriteLine($"{saPattern[i]}");
                bPattern[i] = Convert.ToByte(saPattern[i], 0x10);
            }

            return bPattern;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Array.Empty<byte>();
        }
    }
    internal int[] Positions()
    {
        try
        {
            var strings = _input.Split(' ');
            if (strings is { Length: <= 0 }) return Array.Empty<int>();

            var list = new List<int>();
            var last = string.Empty;

            for (var i = 0; i < strings.Length; i++)
            {
                if (!IsValidWildcard(last)) // Check that the last string is not a wildcard.
                    if (IsValidWildcard(strings[i])) // Check that the current string IS a wild card.
                        if (i <= strings.Length - 2) // Check that we're not reading the last string.
                            if (IsValidWildcard(strings[i + 1])) // Check that the next string is a wildcard.
                                list.Add(i); // Add position of wildcard to list.

                last = strings[i];
            }

            return list.ToArray();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Array.Empty<int>();
        }
    }

    private bool IsValidWildcard(string input)
    {
        try
        {
            return input switch
            {
                "x" => true,
                "xx" => true,
                "X" => true,
                "XX" => true,
                "?" => true,
                "??" => true,
                _ => false
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}