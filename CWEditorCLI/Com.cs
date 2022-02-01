using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    /// <summary>
    /// Common Console Stuff
    /// </summary>
    public static class Com
    {
        public static void WriteEditor(string str)
        {
            Conlog.WriteLine(str, ConsoleColor.Yellow);
        }

        public static void WriteModeInfo(string str)
        {
            Conlog.WriteLine(str, ConsoleColor.Gray);
        }

        public static void WriteMode(string str)
        {
            Conlog.Write(str, ConsoleColor.DarkCyan);
            Conlog.Set(ConsoleColor.Cyan);
        }

        public static void WriteCommand(string str)
        {
            Conlog.WriteLine(str, ConsoleColor.DarkGreen);
        }

    }
}
