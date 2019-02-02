using System;

using Utility.Network.Tracker.Identity;

namespace Musics___Client.API.Events
{
    public class AddingTrackerEventArgs : EventArgs
    {
        public AddingTrackerEventArgs(TrackerIdentity ti)
        {
            Ti = ti;
        }

        public TrackerIdentity Ti { get; set; }
    }
}
