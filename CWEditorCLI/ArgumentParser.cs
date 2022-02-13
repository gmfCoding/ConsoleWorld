using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastConsole
{
    public class ArgumentParser
    {
        public string[] arguments;

        public ArgumentParser(string[] arguments)
        {
            this.arguments = arguments;
        }

        public bool TryGetValue<T>(string key, out T val)
        {
            bool nextIsValue = false;
            val = default(T);
            foreach (var item in arguments)
            {
                if (nextIsValue)
                {
                    val = (T)Convert.ChangeType(item, typeof(T));
                    return true;
                }

                if (item.StartsWith("-"+key))
                {
                    nextIsValue = true;
                    continue;                    
                }
            }
            return false;
        }


        public bool TryGetValue(string key)
        {
            foreach (var item in arguments)
            {
                if (item.StartsWith("-" + key))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
