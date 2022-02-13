using FastConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    class ConReadConfirm
    {
        public static string Read(string ask, ColourPair? colour = null)
        {
            ColourPair col = colour ?? ColourStyles.ask;

            while (true)
            {
                FConsole.Write(ask, col);
                string str = FConsole.ReadLine(ColourStyles.reply);
                FConsole.WriteLine($"<{col.Foreground}>Confirm<white>:<{ColourStyles.reply.Foreground}>{str}");
                FConsole.Write("<green>y<red>n<white>:");

                bool invalid = true;
                while (invalid)
                {
                    char ch = FConsole.ReadKey(false).KeyChar;
                    if (ch == 'y' || ch == 'Y')
                    {
                        FConsole.WriteLine(ch.ToString(), ColourStyles.yes);
                        return str;
                    }
                    else if (ch == 'n' || ch == 'N')
                    {
                        invalid = false;
                        FConsole.WriteLine(ch.ToString(), ColourStyles.no);
                        FConsole.WriteLine("Retrying", ColourStyles.warning);
                    }
                }
            }
        }
    }
}
