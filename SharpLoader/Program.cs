using System.Diagnostics;
using SharpLoader.Forms;

namespace SharpLoader
{
    internal static class Program
    {
        private static Loader _loader = new();
        
        [STAThread]
        static void Main()
        {
            var wow = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = @"D:\Blizzard\World of Warcraft\_classic_\",
                    FileName = "D:\\Blizzard\\World of Warcraft\\_classic_\\WowClassic.exe"
                }
            };

            if (File.Exists($@"D:\Blizzard\World of Warcraft\_classic_\WowClassic.exe"))
                wow.Start();


            ApplicationConfiguration.Initialize();
            var dr = _loader.ShowDialog();
            wow.Kill(true);
        }
    }
}