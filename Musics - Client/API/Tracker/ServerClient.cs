using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Network.Tracker;
using Utility.Network.Tracker.Identity;

namespace Musics___Client.API.Tracker
{
    public class ServerClient : ClientSetup
    {
        public ServerIdentity ServerIdentity { get; set; }

        public TrackerIdentity Provider { get; set; }

        public bool Connect(ServerIdentity si)
        {
            SetupSocket(si.IPEndPoint.Port, 100000000);
            Task<bool> a = Connect(si.IPEndPoint);
            a.Wait(new TimeSpan(0, 1, 0));
            if (!a.Result)
                return false;
            StartReceiving();
            ServerIdentity = si;
            return true;
        }
    }
}
