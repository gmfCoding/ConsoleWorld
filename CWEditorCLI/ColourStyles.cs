using FastConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    public class ColourStyles
    {
        // The colour when you're asked something
        public static ColourPair ask = new ColourPair(ConsoleColor.Yellow);
        // The colour you reply with
        public static ColourPair reply = new ColourPair(ConsoleColor.DarkYellow);

        public static ColourPair say = new ColourPair(ConsoleColor.DarkCyan);

        public static ColourPair command = new ColourPair(ConsoleColor.Cyan);

        public static ColourPair editor = new ColourPair(ConsoleColor.Yellow);

        public static ColourPair world => command;


        public static ColourPair variable = new ColourPair(ConsoleColor.DarkYellow);
        public static ColourPair warning = new ColourPair(ConsoleColor.DarkRed);
        public static ColourPair error = new ColourPair(ConsoleColor.Red);


        public static ColourPair yes = new ColourPair(ConsoleColor.Green, ConsoleColor.Black);
        public static ColourPair no = new ColourPair(ConsoleColor.Red, ConsoleColor.Black);



    }
}
