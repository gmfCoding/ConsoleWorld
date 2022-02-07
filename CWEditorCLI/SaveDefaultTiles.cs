using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consoleworld;

namespace CWEditorCLI
{
    public static class SaveDefaultTiles
    {
        public static void Save()
        {
            foreach (var item in DefaultTiles.GetTiles())
            {
                Resources.SaveTileDefinition(item);
            }
        }

    }
}
