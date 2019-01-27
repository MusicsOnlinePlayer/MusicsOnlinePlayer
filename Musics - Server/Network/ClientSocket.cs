using Utility.Network.Tracker;
using Utility.Network.Tracker.Identity;

namespace Musics___Server.Network
{
    public class ClientSocket : ClientSetup
    {
        public async void Connect(TrackerIdentity trackeridentity)
        {
            SetupSocket(trackeridentity.IPEndPoint.Port, 1000);
            await Connect(trackeridentity.IPEndPoint);
            StartReceiving();
        }
    }
}
