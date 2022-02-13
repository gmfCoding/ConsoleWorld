using FastConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    class CommandSelection
    {
        Dictionary<string, Action> commands = new Dictionary<string, Action>();
        public bool exit { get; private set; }
        public CommandSelection(bool doDefaults)
        {
            commands.Add("exit", Exit);
            commands.Add("help", Help);
        }

        public void RegisterCommand(string commandName, Action command)
        {
            commands.Add(commandName, command);
        }

        public void Run(string command)
        {
            if (commands.ContainsKey(command))
            {
                commands[command].Invoke();
            }
        }

        public void ReadLine(string str, ConsoleColor col)
        {
            FConsole.Write(str, col);
            string command = FConsole.ReadLine();
            if (commands.ContainsKey(command))
            {
                commands[command].Invoke();
            }
        }

        public void Loop()
        {
            while (!exit)
            {
                string command = FConsole.ReadLine();
                if (commands.ContainsKey(command))
                {
                    commands[command].Invoke();
                }
            }
        }

        public void Exit()
        {
            exit = true;
        }

        public void Help()
        {
            foreach (var item in commands.Keys)
            {
                if (item != "help" && item != "exit")
                {
                    FConsole.WriteLine(item, ConsoleColor.Green);
                }
            }
        }
    }
}
