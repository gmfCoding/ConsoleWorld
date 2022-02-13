using FastConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    public class ConValueReader<T>
    {
        public delegate bool TryParseDelegate<U>(string input, out U output);

        string defaultAsk;
        private readonly string errorText;
        TryParseDelegate<T> parser;

        public ConValueReader(string defaultAsk, string errorText, TryParseDelegate<T> parser)
        {
            this.defaultAsk = defaultAsk;
            this.errorText = errorText;
            this.parser = parser;
        }

        public T Read(string ask = null, bool allowExit = false)
        {
            if (ask == null)
            {
                ask = defaultAsk;
            }

            T result = default(T);
            int attempts = 5;

            while (attempts > 0 || !allowExit)
            {
                attempts--;

                var str = Conio.AskLine(ask);
                if (parser(str, out result))
                {
                    return result;
                }
                else
                {
                    FConsole.WriteLine(errorText, ColourStyles.error);
                }

                if (attempts <= 0 && allowExit)
                {

                    FConsole.WriteLine("Input is wrong, would you like more attempts?");
                    bool invalid = true;
                    while (invalid)
                    {
                        FConsole.Write("\ry/n:");
                        char ch = FConsole.ReadKey().KeyChar;
                        if (ch == 'y' || ch == 'Y')
                        {
                            //FConsole.NewLine();
                            invalid = false;
                            attempts = 5;
                        }
                        else if ( ch == 'n' || ch == 'N')
                        {
                            invalid = false;
                        }
                    }
                }
            }

            return result;
        }
    }
}
