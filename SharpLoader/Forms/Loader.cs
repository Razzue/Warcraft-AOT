using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpLoader.Injection;
using SharpLoader.Properties;

namespace SharpLoader.Forms
{
    public partial class Loader : Form
    {
        private Needle? _needle;
        private NeedleResult _response;

        public Loader()
            => InitializeComponent();

        private void Loader_Load(object sender, EventArgs e)
        {
            button_Inject.MouseDown += ButtonMouseDown;
            button_Inject.MouseMove += ButtoMouseMove;
            button_Inject.MouseUp += ButtoMouseUp;
        }

        private int LastID { get; set; }
        private bool IsDown { get; set; }
        private void ButtonMouseDown(object? sender, EventArgs args)
        {
            LastID = 0;
            IsDown = true;

            using var sr = new MemoryStream(Resources.Red);
            Cursor.Current = new Cursor(sr);
        }
        private void ButtoMouseMove(object? sender, EventArgs args)
        {
            try
            {
                if (!IsDown) return;

                Usefuls.GetCursorPos(out var p);
                if (p.IsEmpty) return;

                var ptr = Usefuls.WindowFromPoint(p);
                if (ptr == IntPtr.Zero) return;

                Usefuls.GetWindowThreadProcessId(ptr, out var id);
                if (id == 0 || id == LastID) return;

                LastID = id;
                var proc = Process.GetProcessById(LastID);
                var name = proc.MainModule?.ModuleName ?? string.Empty;

                if (name.Contains("Wow"))
                    using (var g = new MemoryStream(Resources.Green))
                        Cursor.Current = new Cursor(g);
                else
                    using (var r = new MemoryStream(Resources.Red))
                        Cursor.Current = new Cursor(r);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void ButtoMouseUp(object? sender, EventArgs args)
        {
            try
            {
                IsDown = false;
                Cursor.Current = Cursors.Default;

                if (LastID == 0) return;
                _needle = new Needle(LastID);
                _response = _needle.Inject();

                Console.WriteLine($"Injection Result: {_response}");

                button_Offsets.Enabled = _response == NeedleResult.Success;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void button_Offsets_Click(object sender, EventArgs e)
        {
            _needle?.ExecuteUnmanaged(0x7ED60);
        }



        //private void button2_Click(object sender, EventArgs e)
        //{
        //    var ptr = needle.FunctionPointer();
        //    Console.WriteLine($"ptr : {ptr.ToInt64():X}");
        //    // var del = (LoadOffsets)Marshal.GetDelegateForFunctionPointer(ptr, typeof(LoadOffsets));
        //    // del.Invoke();
        //}
    }
}
