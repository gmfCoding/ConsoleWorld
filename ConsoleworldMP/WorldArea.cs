using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    class WorldArea : IBinarySerialisation
    {
        int worldAreaID;
        int sizeX;
        int sizeY;
        char[,] tiles;

        public WorldArea()
        {
            
        }

        public void Read(BinaryReader br)
        {
            worldAreaID = br.ReadInt32();
            int sizeX = br.ReadInt32();
            int sizeY = br.ReadInt32();
            Initialise(sizeX, sizeY);

            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    tiles[i, j] = br.ReadChar();
                }
            }
        }

        public void Initialise(int sizeX, int sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            tiles = new char[sizeX, sizeY];
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(worldAreaID);
            bw.Write(sizeX);
            bw.Write(sizeY);

            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    bw.Write(tiles[i, j]);
                }
            }
        }
    }
}
