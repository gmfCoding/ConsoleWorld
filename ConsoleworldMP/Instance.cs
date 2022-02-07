using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    public class Instance
    {
        public static Instance instance;
        public PlayerManager playerManager;
        public Game game;

        public static Instance Get()
        {
            return instance.GetInstance();
        }

        public virtual Instance GetInstance()
        {
            return instance;
        }
    }
}
