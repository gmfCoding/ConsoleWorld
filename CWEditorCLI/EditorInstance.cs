using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    public class EditorInstance
    {
        public static EditorInstance instance;

        /// <summary>
        /// World editor instance.
        /// </summary>
        public WorldEditor world;
        /// <summary>
        /// Tile editor instance.
        /// </summary>
        public TileEditor tile;

        public static EditorInstance Get()
        {
            return instance.GetInstance();
        }

        public virtual EditorInstance GetInstance()
        {
            return instance;
        }
    }
}
