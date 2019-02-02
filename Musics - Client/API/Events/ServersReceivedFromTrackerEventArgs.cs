using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Network.Tracker.Identity;

namespace Musics___Client.API.Events
{
    public class ServersReceivedFromTrackerEventArgs
    {
        public ServersReceivedFromTrackerEventArgs(ServerIdentity[] serverIdentities)
        {
            ServerIdentities = serverIdentities;
        }

        public ServersReceivedFromTrackerEventArgs(ServerIdentity[] serverIdentities, TrackerIdentity provider)
        {
            ServerIdentities = serverIdentities;
            Provider = provider;
        }

        public ServerIdentity[] ServerIdentities { get; set; }

        public TrackerIdentity Provider { get; set; }
    }
}
