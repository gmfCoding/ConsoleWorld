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
        public Tile[,] world { get; private set; }

        public List<Zone> zones;


        public void Init(string worldName, int width, int height)
        {
            this.worldName = worldName;
            world = new Tile[height, width];
        }

        public List<Zone> GetZones()
        {
            return zones.ToList();
        }

        public void Fill(TileInfo tile)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    world[y, x] = tile.TileID;
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

        public Tile Get(int x, int y)
        {
            if (Inside(x,y))
            {
                return world[y, x];
            }

            return DefaultTiles.empty;
        }


        public bool Set(int x, int y, Tile tile)
        {
            if (Inside(x, y))
            {
                world[y, x] = tile;
                return true;
            }
            return false;
        }

        public bool Inside(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        public void Read(BinaryReader br)
        {
            worldName = br.ReadString();

            int width = br.ReadInt32();
            int height = br.ReadInt32();
            world = new Tile[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    world[y, x] = br.ReadByte();
                }
            }

            zones = new List<Zone>();
            var lsZone = new ListSerialiser<Zone>(zones);
            lsZone.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(worldName);

            bw.Write(Width);
            bw.Write(Height);

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    bw.Write(world[y, x]);
                }
            }

            var lsZone = new ListSerialiser<Zone>(zones);
            lsZone.Write(bw);
        }
    }
}
