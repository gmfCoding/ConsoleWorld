using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    public class ListSerialiser<T> : IBinarySerialisation where T : IBinarySerialisation, new()
    {
        List<T> list;

        public ListSerialiser(List<T> list)
        {
            this.list = list;
        }

        public void Write(BinaryWriter bw)
        {
            int count = list != null ? list.Count : 0;
            bw.Write(count);
            for (int i = 0; i < count; i++)
            {
                list[i].Write(bw);
            }
        }

        public void Read(BinaryReader br)
        {
            int count = br.Read();
            for (int i = 0; i < count; i++)
            {
                T t = new T();
                t.Read(br);
                list.Add(t);
            }
        }
    }
}
