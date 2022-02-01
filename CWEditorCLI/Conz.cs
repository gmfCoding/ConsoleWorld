using System;
using System.Collections.Generic;

namespace CWEditorCLI
{
    public static class Conz
    {
        static Stack<ConsoleColor> colors = new Stack<ConsoleColor>();
        static ConsoleColor fgprev;
        static ConsoleColor bgprev;

        static ConsoleColor fgcurr;
        static ConsoleColor bgcurr;

        public static void Write(string str, ConsoleColor? fg = null, ConsoleColor? bg = null, bool noKeep = false, bool once = false)
        {
            if (once)
            {
                Push();
                if (bg.HasValue)
                {
                    Console.BackgroundColor = bg.Value;
                }
                if (fg.HasValue)
                {
                    Console.ForegroundColor = fg.Value;
                }
            }
            else
            {
                Set(fg, bg);
            }

            Console.Write(str);

            if (once)
                Pop();
        }

        public static void WriteLine(string str, ConsoleColor? fg = null, ConsoleColor? bg = null, bool once = false)
        {
            
            if (once)
            {
                Push();
                if (bg.HasValue)
                {
                    Console.BackgroundColor = bg.Value;
                }
                if (fg.HasValue)
                {
                    Console.ForegroundColor = fg.Value;
                }
            }
            else
            {
                Set(fg, bg);
            }

            Console.WriteLine(str);

            if (once)
                Pop();
        }

        public static void Set(ConsoleColor? fg = null, ConsoleColor? bg = null, bool push = false)
        {
            bgprev = bgcurr;
            fgprev = fgcurr;

            if (fg.HasValue)
            {
                fgcurr = fg.Value;
            }
                

            if (bg.HasValue)
            {
                bgcurr = bg.Value;
            }
                

            SetCurr();

            if (push)
            {
                Push();
            }
        }


        public static void SetPrev()
        {
            Console.ForegroundColor = fgprev;
            Console.BackgroundColor = bgprev;
        }

        public static void SetCurr()
        {
            Console.ForegroundColor = fgcurr;
            Console.BackgroundColor = bgcurr;
        }

        public static void Push()
        {
            colors.Push(Console.ForegroundColor);
            colors.Push(Console.BackgroundColor);
        }

        public static void Pop()
        {
            Console.BackgroundColor = colors.Pop();
            Console.ForegroundColor = colors.Pop();
        }

        public static void PopAll()
        {
            for (int i = 0; colors.Count > 2; i++)
            {
                colors.Pop();
            }

            if (colors.Count >= 2)
            {
                Console.BackgroundColor = colors.Pop();
                Console.ForegroundColor = colors.Pop();
            }
            else
            {
                colors.Clear();
            }
        }

    }
}
