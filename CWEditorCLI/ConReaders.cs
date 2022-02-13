using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    public static class ConReaders
    {
        public static bool StringToString(string strin, out string strout)
        {
            strout = strin;
            return true;
        }

        public static ConValueReader<int> intReader = new ConValueReader<int>("int:", "Unrecognised integer, make sure you're using whole numbers", int.TryParse);
        public static ConValueReader<string> strReader = new ConValueReader<string>("string:", "Make sure the text that you're entering is correct.", StringToString);
    }
}
