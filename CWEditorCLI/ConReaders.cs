using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    public static class ConReaders
    {
        public static ConValueReader<int> widthReader = new ConValueReader<int>("Width:", "Unrecognised integer, make sure you're using whole numbers", int.TryParse);
        public static ConValueReader<int> heightReader = new ConValueReader<int>("Height:", "Unrecognised integer, make sure you're using whole numbers", int.TryParse);
    }
}
