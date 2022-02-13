using Consoleworld;
using FastConsole;
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
        public static Dictionary<byte, TileInfo> tileIDs = new Dictionary<byte, TileInfo>();
        
        public static TileInfo empty = new TileInfo("empty", ' ', 1, ConsoleColor.Black, ConsoleColor.Black) {  };


        public static TileInfo GetTileInfo(byte id)
        {
            if (tileIDs.ContainsKey(id))
            {
                return tileIDs[id];
            }
            return null;
        }

        static TileManager()
        {
            RegisterTile(DefaultTiles.empty);
        }

        public static void RegisterTile(TileInfo tile)
        {
            tiles.Add(tile.Name, tile);
            tileIDs.Add(tile.TileID, tile);
        }

        public static void LoadTilesFromPath()
        {
            foreach (var item in LoadTilesFromPath(IOPaths.tiles))
            {
                RegisterTile(item);
            }
        }

        public static List<TileInfo> LoadTilesFromPath(string path = null)
        {
            if (path == null)
                path = IOPaths.tiles;
            List<TileInfo> retList = new List<TileInfo>();

            foreach (var file in Directory.GetFiles(path))
            {
                string ext = Path.GetExtension(file);
                if (ext == ".tile")
                {
                    try
                    {
                        var tile = SaveLoadUtil.LoadTile(file);
                        retList.Add(tile);
                    }
                    catch (Exception)
                    {
                        FConsole.WriteLine($"Couldn't load tile:{file.Remove(0, path.Length)}");
                    }
                }
            }

            return retList;
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
