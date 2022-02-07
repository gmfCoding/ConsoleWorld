using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWEditorCLI;

namespace Consoleworld
{
    public static class UpdateTileFiles
    {
        public static void LoadTiles()
        {
            List<TileInfo> tiles = Resources.LoadTileDefinitions();

            for (int i = 0; i < tiles.Count; i++)
            {
                tiles[i].TileID = (byte)(i + 2);
            }

            Resources.SaveTileDefinitions(tiles);
        }

    }
}
