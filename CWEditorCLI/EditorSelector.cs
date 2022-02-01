using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    class EditorSelector
    {

        public Dictionary<string, Func<IEditor>> editors = new Dictionary<string, Func<IEditor>>();

        public void Register(string name, Func<IEditor> creator)
        {
            editors.Add(name, creator);
        }

        public void Selection()
        {
            PrintEditors();
            bool exit = false;
            while (!exit)
            {
                Com.WriteModeInfo("#selection - The editor to open.");
                Com.WriteMode("selection:");
                string selection = Console.ReadLine().ToLower();
                if (selection == "help")
                {
                    PrintEditors();
                }
                OpenEditor(selection);
            }
        }

        void PrintEditors()
        {
            Com.WriteEditor("Editors:");
            foreach (var item in editors.Keys)
            {
                Com.WriteCommand(item);
            }
        }

        void OpenEditor(string name)
        {
            if (editors.TryGetValue(name, out Func<IEditor> creator))
            {
                creator.Invoke().Open();
            }
        }
    }
}
