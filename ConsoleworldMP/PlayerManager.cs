using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleworld
{
    public class PlayerManager
    {
        public BiDict<string, PlayerAuth> loginSecurity = new BiDict<string, PlayerAuth>();

        public BiDict<ushort, Guid> playerGuids = new BiDict<ushort, Guid>();

        public Dictionary<ushort, Player> players = new Dictionary<ushort, Player>();
        public BiDict<ushort, string> playerNames = new BiDict<ushort, string>();

        public string GetPlayerName(ushort playerID)
        {
            return playerNames[playerID];
        }
    }
}
