using Consoleworld;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    public static class TileManager
    {
        public static Dictionary<string, TileInfo> tiles = new Dictionary<string, TileInfo>();

        public static TileInfo empty = new TileInfo() { character = ' ', name = "empty", backgroundColour = ConsoleColor.Black, colour = ConsoleColor.Black };

        static TileManager()
        {
            tiles.Add(empty.name, empty);
        }

        public static void LoadTilesFromPath(string path = null)
        {
            if (path == null)
                path = IOPaths.tiles;

            foreach (var file in Directory.GetFiles(path))
            {
                string ext = Path.GetExtension(file);
                if (ext == ".tile")
                {
                    try
                    {
                        var tile = SaveLoadUtil.LoadTile(file);
                        tiles.Add(tile.name, tile);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"Couldn't load tile:{file.Remove(0, path.Length)}");
                    }
                }
            }
        }

        public static TileInfo Get(string name)
        {
            if (tiles.ContainsKey(name))
            {
                return tiles[name];
            }

            return empty;
        }
    }
}
