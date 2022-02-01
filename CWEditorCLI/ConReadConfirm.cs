using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    class ConReadConfirm
    {
        public static string Read(string ask)
        {
            while (true)
            {
                Console.Write(ask);
                string str = Console.ReadLine();
                Console.WriteLine($"Are you happy with:{str}");
                Console.WriteLine("y/n");

                bool invalid = true;
                while (invalid)
                {
                    char ch = Console.ReadKey().KeyChar;
                    if (ch == 'y' || ch == 'Y')
                    {
                        return str;
                    }
                    else if (ch == 'n' || ch == 'N')
                    {
                        invalid = false;
                        Console.WriteLine("Retrying:");
                    }
                }
            }
        }
    }
}
