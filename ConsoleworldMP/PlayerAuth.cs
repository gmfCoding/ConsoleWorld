using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    public class PlayerAuth : IBinarySerialisation
    {
        public string userName { get; private set; }
        public int passwordHash { get; private set; }
        public Guid playerGuid { get; private set; }

        public void Write(BinaryWriter bw)
        {
            bw.Write(userName);
            bw.Write(passwordHash);
            bw.Write(playerGuid.ToByteArray());
        }

        public void Read(BinaryReader br)
        {
            userName = br.ReadString();
            passwordHash = br.ReadInt32();
            playerGuid = new Guid(br.ReadBytes(16));
        }
    }
}
