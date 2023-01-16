namespace RazzSharp.Warcraft.Scanner.Events
{
    internal class PatternMatchedArgs : EventArgs
    {
        internal string? Name;
        internal object? Value;
        internal double Elapsed;
        internal DateTime Fired;

        internal PatternMatchedArgs(object? value, string? name, double elapsed = 0)
        {
            Name = name;
            Value = value;
            Elapsed = elapsed;
            Fired = DateTime.Now;
        }
    }
}
