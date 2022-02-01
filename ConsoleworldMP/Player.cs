using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    class Player : IBinarySerialisation
    {
        PlayerAuth auth;

        string name;
        Guid playerUUID;
        int playerID;

        int areaID;
        int x, y;

        public void Read(BinaryReader br)
        {

        }

        public void Write(BinaryWriter bw)
        {
            throw new NotImplementedException();
        }
    }
}
