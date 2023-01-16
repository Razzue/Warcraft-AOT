namespace RazzSharp.Warcraft.Scanner.Events
{
    internal class ScanStartedArgs : EventArgs
    {
        internal string Name;
        internal DateTime Fired;

        internal ScanStartedArgs(string name)
        {
            Name = name;
            Fired = DateTime.Now;
        }
    }
}