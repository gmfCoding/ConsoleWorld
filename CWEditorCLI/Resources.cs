using Consoleworld;
using FastConsole;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    public static class Resources
    {
        static string tileDir => Path.Combine(Environment.CurrentDirectory, "tiles");
        public static void SaveTileDefinition(TileInfo tile, string path = null)
        {
            if (path == null)
                path = tileDir;

            using (MemoryStream ms = new MemoryStream(8))
            {
                byte[] bytes;
                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                    tile.Write(bw);
                    bytes = new byte[bw.BaseStream.Length];
                    Array.Copy(ms.GetBuffer(), bytes, bytes.Length);
                }
                
                try
                {
                    if (Directory.Exists(path) == false)
                    {
                        Directory.CreateDirectory(path);
                    }

                    using (var stream = File.Create(Path.Combine(path, tile.Name + ".tile")))
                    {
                        stream.Write(bytes, 0, bytes.Length);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static void SaveTileDefinitions(List<TileInfo> tiles, string path = null)
        {
            if (path == null)
                path = tileDir;

            foreach (var item in tiles)
            {
                try
                {
                    SaveTileDefinition(item);
                }
                catch (Exception)
                {
                    FConsole.WriteLine($"Couldn't save : {Path.Combine(path, item.Name)}.tile");
                }
            }
        }

        public static List<TileInfo> LoadTileDefinitions(string path = null)
        {
            if (path == null)
                path = tileDir;
            List<TileInfo> tiles = new List<TileInfo>();
            foreach (var item in Directory.GetFiles(path))
            {
                try
                {
                    tiles.Add(LoadTileDefinition(item));
                }
                catch (Exception)
                {   
                    FConsole.WriteLine($"Couldn't load {Path.GetFullPath(item)}");
                }
            }

            return tiles;
        }

        public static TileInfo LoadTileDefinition(string filePath)
        {
            try
            {
                var tile = new TileInfo();
                using (var stream = File.OpenRead(filePath))
                {
                    using (BinaryReader br = new BinaryReader(stream))
                    {
                        tile.Read(br);
                    }
                }

                return tile;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
