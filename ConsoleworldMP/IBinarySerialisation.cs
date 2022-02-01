using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    public interface IBinarySerialisation
    {
        void Write(BinaryWriter bw);

        void Read(BinaryReader br);

    }
}
