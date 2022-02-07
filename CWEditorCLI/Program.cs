using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using FastConsole;
using System.Windows.Interop;
using Consoleworld;

namespace CWEditorCLI
{
    class Program
    {

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);


        static void Main(string[] args)
        {
            MoveWindow(Process.GetCurrentProcess().MainWindowHandle, 0, 0, 550, 900, true);
            Console.CursorVisible = false;

            //Cons console = new Cons(0, 0, 50, 50);


            //WorldBrush wb = new WorldBrush(tileEditor, 50, 50, world);
            //wb.Update();

            TileEditor tileEditor = new TileEditor();
            tileEditor.LoadFromPath();

            WorldEditor worldEditor = new WorldEditor();
            EditorSelector edsel = new EditorSelector();

            References.AddReference("tile_editor", tileEditor);
            References.AddReference("world_editor", worldEditor);
            References.AddReference("editor_selector", edsel);

            edsel.Register("tile", () => tileEditor);
            edsel.Register("world", () => worldEditor);

            edsel.Selection();

            Console.ReadLine();
        }
    }
}
