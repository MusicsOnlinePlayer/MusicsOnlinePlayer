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

        public async void Connect(TrackerIdentity ti)
        {
            SetupSocket(ti.IPEndPoint.Port, 1000);
            await Connect(ti.IPEndPoint);
            StartReceiving();
            Trackeridentity = ti;
        }
    }
}
