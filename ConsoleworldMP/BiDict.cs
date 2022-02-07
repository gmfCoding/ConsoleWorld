using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    public class BiDict<T1, T2>
    {
        private Dictionary<T1, T2> _forward = new Dictionary<T1, T2>();
        private Dictionary<T2, T1> _reverse = new Dictionary<T2, T1>();

        public void Add(T1 t1, T2 t2)
        {
            _forward.Add(t1, t2);
            _reverse.Add(t2, t1);
        }

        public T1 this[T2 index]
        {
            get { return _reverse[index]; }
            set { _reverse[index] = value; }
        }


        public T2 this[T1 index]
        {
            get { return _forward[index]; }
            set { _forward[index] = value; }
        }
    }
}
