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

        public static EditorInstance instance;
        static void Main(string[] args)
        {
            FConsole.ProcessColours = true;

            // Args to skip console size setup: -w 550 -h 900 -acceptSize
            ArgumentParser arguments = new ArgumentParser(args);
            
            if (arguments.TryGetValue<int>("h", out int h))
            {
                if (arguments.TryGetValue<int>("w", out int w))
                {
                    MoveWindow(Process.GetCurrentProcess().MainWindowHandle, 400, 250, w, h, true);
                }
            }

            
            if (!arguments.TryGetValue("acceptSize"))
            {
                FConsole.WriteLine("<red>Please set the size of the window before continuing then press enter...");
                FConsole.ReadLine();
                FConsole.LockSize();
            }

            FConsole.QueueInput("world");
            FConsole.QueueInput("create");
            FConsole.QueueInput("example");

            FConsole.QueueInput("10");


            Console.CursorVisible = false;


            instance = new EditorInstance();
            EditorInstance.instance = instance;

            instance.tile = new TileEditor();
            instance.tile.LoadFromPath();

            instance.world = new WorldEditor();

            EditorSelector selector = new EditorSelector();
            selector.Input();

            FConsole.ReadLine();
        }
    }
}
