using FastConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    public static class WorldRenderer
    {

        public static void RenderWorld(World world, FastConsoleInstance console)
        {
            int width = world.Width;
            int height = world.Height;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (world.world[y , x] != 0x0b)
                    {
                        TileInfo t = TileManager.GetTileInfo(world.world[y, x]);
                        console.WriteAt(t.Character, x, y, new ColourPair(t.Colour, t.BackgroundColour));
                    }
                }
            }
        }
    }
}
