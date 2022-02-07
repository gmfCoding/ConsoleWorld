using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    public struct Tile
    {
        byte tileType;

        public static implicit operator byte(Tile d) => d.tileType;
        public static implicit operator Tile(byte b) => new Tile() {  tileType = b };
    }
}
