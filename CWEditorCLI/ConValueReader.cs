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

        string askText;
        private readonly string errorText;
        TryParseDelegate<T> parser;

        public ConValueReader(string askText, string errorText, TryParseDelegate<T> parser)
        {
            this.askText = askText;
            this.errorText = errorText;
            this.parser = parser;
        }

        public T Read()
        {
            T result = default(T);
            int attempts = 5;

            while (attempts > 0)
            {
                attempts--;

                Console.Write(askText);
                var str = Console.ReadLine();
                if (parser(str, out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine(errorText);
                }

                if (attempts <= 0)
                {
                    Console.WriteLine("Input is wrong, would you like more attempts?");
                    Console.WriteLine("y/n");
                    bool invalid = true;
                    while (invalid)
                    {
                        char ch = Console.ReadKey().KeyChar;
                        if (ch == 'y' || ch == 'Y')
                        {
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
