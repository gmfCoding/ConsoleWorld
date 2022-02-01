using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    struct CSaveCursorCon
    {
        public int x;
        public int y;
        public CSaveCursorCon(bool save = false)
        {
            x = 0;
            y = 0;
            if (save)
                Save();

        }

        public void Save()
        {
            x = Console.CursorLeft;
            y = Console.CursorTop;
        }

        public void Load(bool keep = true)
        {
            if (keep)
                Console.SetCursorPosition(x, y);
        }
    }
}
