using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    interface INetworkable
    {
        void NetWrite(BinaryWriter bw);
        void NetRead(BinaryReader br);
    }
}
