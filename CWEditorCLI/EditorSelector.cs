using Consoleworld;
using FastConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CWEditorCLI
{
    class EditorSelector
    {
        EditorInstance editor => EditorInstance.Get();

        public InputPossiblities possiblities = new InputPossiblities(true, true, PrintHelp);

        private static void PrintHelp(IEnumerable<InputPossiblity> possiblities)
        {
            FConsole.WriteLine("Commands:", ColourStyles.command);
            InputPossiblities.PrintHelp(possiblities.Where(x => !(x.extra is PossiblityType) || (x.extra is PossiblityType pt && pt == PossiblityType.Command)));
            FConsole.WriteLine("Editors:", ColourStyles.editor);
            InputPossiblities.PrintHelp(possiblities.Where(x => x.extra is PossiblityType pt && pt == PossiblityType.Editor));
            FConsole.WriteLine();
        }
        
        public EditorSelector()
        {
            possiblities.Add(new InputPossiblity("world", "Open the world editor, for editing/viewing maps.", editor.world.Open, ConsoleColor.Yellow, PossiblityType.Editor));
            possiblities.Add(new InputPossiblity("tile", "Open the tile editor, for editing/viewing tile definitions.", editor.tile.Open, ConsoleColor.Yellow, PossiblityType.Editor));
        }

        public void Input()
        {
            possiblities.PrintHelp();
            possiblities.Input();
        }
    }
}
