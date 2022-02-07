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

        public InputPossiblities(bool cancel, bool help)
        {
            if (cancel)
            {
                Add(new InputPossiblity(() => { this.done = true; }, "returns.", "back", "return", "exit"));
            }

            if (help)
            {
                Add(new InputPossiblity(PrintHelp, "returns.", "help", "?"));
            }
        }

        public void PrintHelp()
        {
            foreach (var item in possiblities)
            {
                Console.WriteLine('"' + string.Join(", ", item.aliases) + "\" : " + item.description); 
            }
        }

        public void Add(InputPossiblity possibility)
        {
            possiblities.Add(possibility);

            foreach (var item in possibility.aliases)
            {
                if (possiblityDict.ContainsKey(item) == false)
                    possiblityDict.Add(item, possibility);
            }
        }


        public void Input()
        {
            
            while (!done)
            {
                var cv = new CursorVisibility(true);
                string read = Console.ReadLine();

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
        public readonly List<string> aliases;
        public readonly string description;
        public readonly Action act;

        public InputPossiblity(Action act, string description, params string[] aliases)
        {
            this.aliases = aliases.ToList();
            this.description = description;
            this.act = act;
        }
    }
}
