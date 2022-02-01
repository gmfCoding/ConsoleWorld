using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    public static class ColourConsole
    {
        public static Dictionary<string, ConsoleColor> colours = new Dictionary<string, ConsoleColor>();

        static ColourConsole()
        {
            for (int i = 0; i <= (int)ConsoleColor.White; i++)
            {
                colours.Add($"<b:{((ConsoleColor)i).ToString().ToLower()}>", (ConsoleColor)i);
                colours.Add($"<{((ConsoleColor)i).ToString().ToLower()}>", (ConsoleColor)i);
            }
        }

        public static void Write(string str)
        {
            ConsoleColor fprevCol = Console.ForegroundColor;
            ConsoleColor bprevCol = Console.BackgroundColor;
            ConsoleColor current;
            bool mdMode = false;
            StringBuilder mdStr = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                if (ch == '<')
                {
                    mdStr.Append(ch);
                    mdMode = true;
                }
                else if (ch == '>' && mdMode)
                {
                    mdStr.Append(ch);
                    mdMode = false;
                    ConsoleColor col;
                    if (colours.TryGetValue(mdStr.ToString(), out col))
                    {
                        current = col;
                        if (mdStr.ToString().Contains("b:"))
                        {
                            Console.BackgroundColor = col;
                        }
                        else
                        {
                            Console.ForegroundColor = col;
                        }
                        mdStr.Clear();
                    }
                }
                else if (mdMode)
                {
                    mdStr.Append(ch);
                }
                else
                {
                    Console.Write(ch);
                }
            }


            Console.ForegroundColor = fprevCol;
            Console.BackgroundColor = bprevCol;
        }

        public static void WriteLine(string str)
        {
            Write(str);
            Console.Write(Environment.NewLine);
        }
    }
}
