using Consoleworld;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    public struct ZoneArea : IBinarySerialisation
    {
        public int TopLeft { get; private set; }
        public int BottomRight { get; private set; }

        public void Write(BinaryWriter bw)
        {
            bw.Write(TopLeft);
            bw.Write(BottomRight);
        }

        public void Read(BinaryReader br)
        {
            TopLeft = br.ReadInt32();
            BottomRight = br.ReadInt32();
        }
    }
}
