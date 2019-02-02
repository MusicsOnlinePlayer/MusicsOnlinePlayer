using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Network.Tracker;
using Utility.Network.Tracker.Identity;

namespace Musics___Client.API.Tracker
{
    public class TrackerClientService : ClientSetup
    {
        public TrackerIdentity Trackeridentity { get; protected set; }

        public bool Connect(TrackerIdentity ti)
        {
            SetupSocket(ti.IPEndPoint.Port, 1000);
            Task<bool> a = Connect(ti.IPEndPoint);
            a.Wait(new TimeSpan(0,1,0));
            if (!a.Result)
                return false;
            StartReceiving();
            Trackeridentity = ti;
            return true;
        }
    }
}
