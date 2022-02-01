using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    class IOPaths
    {
        public static string FullPath(string str)
        {
            return Path.Combine(Environment.CurrentDirectory, str);
        }
        public static string tiles => FullPath("tiles");
    }
}
