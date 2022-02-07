using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    public class Player : IBinarySerialisation
    {
        // The unique server-game persisting player id.
        ushort playerID;
        // The area that the player is in.
        int areaID;
        // The tile coordinates the player is at.
        short x, y;

        public string GetName()
        {
            return Instance.Get().playerManager.GetPlayerName(playerID);
        }

        public void Read(BinaryReader br)
        {
            playerID = br.ReadUInt16();
            areaID = br.ReadInt32();
            x = br.ReadInt16();
            y = br.ReadInt16();
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(playerID);
            bw.Write(areaID);
            bw.Write(x);
            bw.Write(y);
        }
    }
}
