using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    class ConcolStack
    {
        Stack<ConsoleColor> colors = new Stack<ConsoleColor>();
        ConsoleColor bgl;
        ConsoleColor fgl;
        public ConcolStack(bool pushNow = true, ConsoleColor? fg = null, ConsoleColor? bg = null)
        {
            if (pushNow)
            {
                Push();
            }

            if (fg.HasValue || bg.HasValue)
            {
                Set(fg, bg);
            }
        }

        public void Set(ConsoleColor? fg = null, ConsoleColor? bg = null, bool push = false)
        {
            if (fg.HasValue)
            {
                Console.ForegroundColor = fg.Value;
            }

            if (bg.HasValue)
            {
                Console.BackgroundColor = bg.Value;
            }

            if (push)
            {
                Push();
            }
        }

        public void Push()
        {
            fgl = Console.ForegroundColor;
            bgl = Console.BackgroundColor;
            colors.Push(fgl);
            colors.Push(bgl);
        }

        public void Pop()
        {
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

        public void PopAll()
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
