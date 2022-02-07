using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    class CursorVisibility
    {
        public bool visible { get; private set; }

        public CursorVisibility(bool? set = null)
        {
            Push();
            Console.CursorVisible = set.HasValue ? set.Value : visible;
        }

        public void Push()
        {
            visible = Console.CursorVisible;
        }

        public void Pop()
        {
            Console.CursorVisible = visible;
        }
    }
}
