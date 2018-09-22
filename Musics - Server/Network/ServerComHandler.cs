using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musics___Server.Network
{
    public class ServerComHandler
    {
        public IEnumerable<ServerClient> ServersClient { get; private set; }

        public ServerComHandler()
        {
        }
    }
}
