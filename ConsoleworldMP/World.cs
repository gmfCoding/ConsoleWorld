using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consoleworld;
using FastConsole;

namespace Consoleworld
{
    public class World : IBinarySerialisation
    {
        public int Width => world.GetLength(1);
        public int Height => world.GetLength(0);

        public string worldName { get; private set; }
        public TileInfo[,] world { get; private set; }

        public List<Zone> zones;


        public void Init(string worldName, int width, int height)
        {
            this.worldName = worldName;
            world = new TileInfo[height, width];
        }

        public List<Zone> GetZones()
        {
            return zones.ToList();
        }

        public void Randomise()
        {
            List<TileInfo> tiles = TileManager.tiles.Values.ToList();
            Random r = new Random();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    world[y, x] = tiles.ElementAt(r.Next(0, tiles.Count));
                }
            }
        }

        public void Fill(TileInfo tile)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    world[y, x] = tile;
                }
            }
        }


        // worldName
        // uniqueCount
        // uniqueList
        // worldWidth
        // worldHeight
        // for height for width; worldtiles converted to unique indices
        // zoneCount
        // zoneList



        public void Read(BinaryReader br)
        {
            worldName = br.ReadString();
            int uniqueTileCount = br.ReadInt32();
            Dictionary<ushort, TileInfo> unique = new Dictionary<ushort, TileInfo>();

            for (ushort i = 0; i < uniqueTileCount; i++)
            {
                unique.Add(i, TileManager.Get(br.ReadString()));
            }


            int width = br.ReadInt32();
            int height = br.ReadInt32();
            world = new TileInfo[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    ushort tid = br.ReadUInt16();
                    TileInfo tile = TileManager.empty;

                    if (unique.ContainsKey(tid))
                        tile = unique[tid];
                    else
                        Console.WriteLine($"Tile: {tid} doesn't exist in unique tile map");
                    world[y, x] = tile;
                }
            }
            zones = new List<Zone>();
            var lsZone = new ListSerialiser<Zone>(zones);
            lsZone.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(worldName);
            Dictionary<string, ushort> unique = new Dictionary<string, ushort>();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    TileInfo t = world[y, x];
                    if (unique.ContainsKey(t.name) == false)
                    {
                        unique.Add(t.name, (ushort)unique.Count);
                    }
                }
            }

            bw.Write(unique.Count);
            for (int i = 0; i < unique.Count; i++)
            {
                bw.Write(unique.ElementAt(i).Key);
            }

            bw.Write(Width);
            bw.Write(Height);

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    bw.Write(unique[world[y, x].name]);
                }
            }

            var lsZone = new ListSerialiser<Zone>(zones);
            lsZone.Write(bw);
        }
    }
}
