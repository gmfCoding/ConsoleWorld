using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    public static class Conlog
    {
        static ConsoleColor fgprev;
        static ConsoleColor bgprev;

        static ConsoleColor fgcurr;
        static ConsoleColor bgcurr;
        static string BufferLine;

        static Conlog()
        {
            BufferLine = new string(' ', Console.BufferWidth - 1);
        }
        public static void Write(string str, ConsoleColor? fg = null, ConsoleColor? bg = null, bool save = false)
        {
            Set(fg, bg);

            if (save)
                SaveCurr();

            Console.Write(str);
        }

        public static void WriteLine(string str, ConsoleColor? fg = null, ConsoleColor? bg = null, bool save = false)
        {
            Set(fg, bg);

            if (save)
                SaveCurr();

            Console.WriteLine(str);
        }

        public static void Set(ConsoleColor? fg = null, ConsoleColor? bg = null)
        {
            if (bg.HasValue)
            {
                Console.BackgroundColor = bg.Value;
            }
            if (fg.HasValue)
            {
                Console.ForegroundColor = fg.Value;
            }
        }

        public static void SavePrev()
        {
            fgprev = Console.ForegroundColor;
            bgprev = Console.BackgroundColor;
        }

        public static void SaveCurr()
        {
            fgcurr = Console.ForegroundColor;
            bgcurr = Console.BackgroundColor;
        }

        public static void LoadPrev()
        {
            Console.ForegroundColor = fgprev;
            Console.BackgroundColor = bgprev;
        }

        public static void LoadCurr()
        {
            Console.ForegroundColor = fgcurr;
            Console.BackgroundColor = bgcurr;
        }

        public static void Clear()
        {
            CSaveCursorCon cs = new CSaveCursorCon(true);
            Console.CursorVisible = false;
            int height = Console.WindowHeight;
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(BufferLine);
            }
            cs.Load();
        }
    }
}
