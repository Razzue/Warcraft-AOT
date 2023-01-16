using System.Diagnostics;
using SharpLoader.Forms;

namespace SharpLoader
{
    internal static class Program
    {
        private static Loader _loader = new();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

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