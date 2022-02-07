using Consoleworld;
using FastConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    public static class RenderUtil
    {
        public static void RenderWorld(TileInfo[,] world, Cons console)
        {
            int width = world.GetLength(0);
            int height = world.GetLength(1);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (world[i, j] != null)
                    {
                        console.WriteAt(world[i, j].Character, i, j, world[i, j].Colour, world[i, j].BackgroundColour);
                    }
                }
            }
        }
    }
}
