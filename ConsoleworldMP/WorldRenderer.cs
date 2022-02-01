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

        public static void RenderWorld(World world, Cons console)
        {
            int width = world.Width;
            int height = world.Height;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (world.world[y , x] != null)
                    {
                        TileInfo t = world.world[y, x];
                        console.WriteAt(t.character, x, y,t.colour, t.backgroundColour);
                    }
                }
            }
        }
    }
}
