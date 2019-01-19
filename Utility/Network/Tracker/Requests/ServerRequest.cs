using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Network.Tracker.Identity;

namespace Utility.Network.Tracker.Requests
{
    [Serializable]
    public class ServerRequest : TrackerRequest
    {

    }

    [Serializable]
    public class ServerRequestAnswer : TrackerRequest
    {
        public ServerRequestAnswer(ServerIdentity[] serverIdentities)
        {
            ServerIdentities = serverIdentities;
        }

        ServerIdentity[] ServerIdentities { get; set; }
    }
}
