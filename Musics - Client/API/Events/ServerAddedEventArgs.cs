using System;
using Utility.Network.Tracker.Identity;

namespace Musics___Client.API.Events
{
    public class ServerAddedEventArgs : EventArgs
    {
        public ServerAddedEventArgs(ServerIdentity serverIdentity, TrackerIdentity provider)
        {
            ServerIdentity = serverIdentity;
            Provider = provider;
        }

        public ServerIdentity ServerIdentity { get; set; }
        public TrackerIdentity Provider { get; set; }
    }
}
