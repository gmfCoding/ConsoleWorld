using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    public class TileInfo : IBinarySerialisation
    {
        public string name;
        public char character;
        public ConsoleColor colour;
        public ConsoleColor backgroundColour = ConsoleColor.Black;

        public void Read(BinaryReader br)
        {
            name = br.ReadString();
            character = br.ReadChar();
            colour = (ConsoleColor)br.ReadByte();
            backgroundColour = (ConsoleColor)br.ReadByte();
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(name);
            bw.Write(character);
            bw.Write((byte)colour);
            bw.Write((byte)backgroundColour);
        }
    }

    unsafe struct TileStruct
    {
        string name;
        char character;
        ConsoleColor colour;
        ConsoleColor backgroundColour;
    }
}
