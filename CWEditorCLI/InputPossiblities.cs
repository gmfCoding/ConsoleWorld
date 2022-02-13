using Consoleworld;
using FastConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    class InputPossiblities
    {
        List<InputPossiblity> possiblities = new List<InputPossiblity>();
        Dictionary<string, InputPossiblity> possiblityDict = new Dictionary<string, InputPossiblity>();
        bool done = false;

        Action<IEnumerable<InputPossiblity>> printHelp;

        public InputPossiblities(bool cancel, bool help, Action<IEnumerable<InputPossiblity>> printHelp = null)
        {
            if (printHelp == null)
            {
                this.printHelp = PrintHelp;
            }
            else
            {
                this.printHelp += printHelp;
            }

            if (cancel)
            {
                Add(new InputPossiblity("exit", "Returns.", () => { this.done = true;}));
            }

            if (help)
            {
                Add(new InputPossiblity("help", "Displays this help menu.", () => this.printHelp(possiblities)));
            }
        }

        public static void PrintHelp(IEnumerable<InputPossiblity> inputPossiblities)
        {
            int i = 0;
            foreach (var item in inputPossiblities)
            {
                i++;
                FConsole.WriteLine($"<{item.colour}>" + item.name + $"<white> : <white>" + item.description);
            }
        }

        public void PrintHelp()
        {
            printHelp(possiblities);
        }

        public void Add(InputPossiblity possibility)
        {
            possiblities.Add(possibility);
            possiblityDict.Add(possibility.name, possibility);
        }

        public void Input()
        {
            while (!done)
            {
                var cv = new CursorVisibility(true);
                string read = Conio.Ask();

                if (possiblityDict.ContainsKey(read))
                {
                    possiblityDict[read].act();
                }

                cv.Pop();
            }
        }
    }

    public class InputPossiblity
    {
        public object extra;
        public ConsoleColor colour;
        public readonly string name;
        public readonly string description;
        public readonly Action act;

        public const ConsoleColor defaultColour = ConsoleColor.Cyan;

        public InputPossiblity(string name, string description, Action act, ConsoleColor aliasColour = defaultColour, object obj = null)
        {
            this.colour = aliasColour;
            this.name = name;
            this.description = description;
            this.act = act;
            this.extra = obj;
        }
    }
}
