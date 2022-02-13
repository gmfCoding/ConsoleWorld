using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    public class DefaultTiles
    {
        public static TileInfo empty = new TileInfo("empty", ' ', 0, ConsoleColor.White, ConsoleColor.Black);
        public static TileInfo water = new TileInfo("water", '≈', 1, ConsoleColor.Blue, ConsoleColor.DarkBlue);
        public static TileInfo sand = new TileInfo("sand", '▓', 2, ConsoleColor.DarkYellow, ConsoleColor.Yellow);
        public static TileInfo stone = new TileInfo("stone", '▓', 3, ConsoleColor.Gray, ConsoleColor.Black);
        public static TileInfo redsand = new TileInfo("redsand", '▓', 4, ConsoleColor.DarkYellow, ConsoleColor.Red);
        public static TileInfo fire = new TileInfo("fire", 'M', 5, ConsoleColor.Blue, ConsoleColor.DarkBlue);


        public static IEnumerable<TileInfo> GetTiles() 
        {
            yield return water;
            yield return sand;
            yield return stone;
            yield return redsand;
            yield return fire;
        }
    }
}
