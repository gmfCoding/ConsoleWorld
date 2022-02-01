using Consoleworld;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    class SaveLoadUtil
    {
        /// <summary>
        /// Loads and reads (BinaryReader) a tile file at the specified path.
        /// </summary>
        /// <param name="filePath">The file path of the tile to load.</param>
        /// <returns> The loaded tile object that was at filePath</returns>
        /// <remarks>Can throw exceptions, please handle.</remarks>
        /// <inheritdoc cref="System.IO.File.OpenRead(string)"/>
        public static TileInfo LoadTile(string filePath)
        {
            try
            {
                var tile = new TileInfo();
                using (var stream = File.OpenRead(filePath))
                {
                    using (BinaryReader br = new BinaryReader(stream))
                    {
                        tile.Read(br);
                    }
                }

                return tile;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
