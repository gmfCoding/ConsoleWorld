using Consoleworld;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    public struct Zone : IBinarySerialisation
    {
        public int zoneID { get; private set; }
        public List<ZoneArea> areas { get; private set; }

        public void Read(BinaryReader br)
        {
            zoneID = br.ReadInt32();
            int areaListSize = br.ReadInt32();
            areas = new List<ZoneArea>(areaListSize);
            for (int i = 0; i < areaListSize; i++)
            {
                var za = new ZoneArea();
                za.Read(br);
                areas.Add(za);
            }
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(zoneID);
            bw.Write(areas != null ? areas.Count() : 0);
            foreach (var item in areas)
            {
                item.Write(bw);
            }
        }
    }
}
