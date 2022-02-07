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
        public string Name { get; private set; }
        public char Character { get; private set; }
        public Tile TileID { get; set; }
        public ConsoleColor Colour { get; private set; }
        public ConsoleColor BackgroundColour { get; private set; } = ConsoleColor.Black;

        public TileInfo()
        {

        }

        public TileInfo(string name, char character, byte tileID, ConsoleColor colour, ConsoleColor backgroundColour)
        {
            Name = name;
            Character = character;
            TileID = tileID;
            Colour = colour;
            BackgroundColour = backgroundColour;
        }

        public void Read(BinaryReader br)
        {
            Name = br.ReadString();
            TileID = br.ReadByte();
            Character = br.ReadChar();
            Colour = (ConsoleColor)br.ReadByte();
            BackgroundColour = (ConsoleColor)br.ReadByte();
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(Name);
            bw.Write(TileID);
            bw.Write(Character);
            bw.Write((byte)Colour);
            bw.Write((byte)BackgroundColour);
        }

        public static implicit operator Tile(TileInfo d) => d.TileID;
    }

    unsafe struct TileStruct
    {
        string name;
        char character;
        ConsoleColor colour;
        ConsoleColor backgroundColour;
    }
}
