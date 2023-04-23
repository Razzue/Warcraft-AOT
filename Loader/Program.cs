using System.Diagnostics;
using System.Text.RegularExpressions;

using Loader.Injection.LoadLibrary;

var loop = true;
Needle? needle = null;

here:
Console.WriteLine("Target a process for injection by id.");
var line = Console.ReadLine();

if (string.IsNullOrEmpty(line)) Console.WriteLine("Nothing was entered.");
else
{
    line = Regex.Replace(line, "[^0-9]", string.Empty);
    if (!int.TryParse(line, out var id)) Console.WriteLine("Could not parse input.");
    else
    {
        Process? p = null;
        try { p = Process.GetProcessById(id) ?? null; }
        catch
        {
            // ignored
        }

        if (p == null) Console.WriteLine("No process with requested id exists.");
        else
        {
            needle ??= new Needle(p.Id);
            Console.WriteLine($"Attempting to attach to {p.ProcessName}");

            var result = needle.Inject($@"{Environment.CurrentDirectory}\Cannon.dll");
            if (result == NResult.Success) loop = false;
            else Console.WriteLine($"Result: {result}");
        }
    }
}

if (loop)
{
    Console.WriteLine("Press any key to continue.");
    Console.ReadKey(true);
    goto here;
}

Console.WriteLine("Press any key to exit.");
Console.ReadKey(true);