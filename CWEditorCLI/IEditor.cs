using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    interface IEditor
    {
        string GetName();

        void Open();
    }
}
