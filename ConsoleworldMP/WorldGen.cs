using Consoleworld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    public class WorldGen
    {
        public void Fill(World world, TileInfo tile)
        {
            for (int y = 0; y < world.Height; y++)
            {
                for (int x = 0; x < world.Width; x++)
                {
                    world.Set(x, y, tile.TileID);
                }
            }
        }
    }
}
