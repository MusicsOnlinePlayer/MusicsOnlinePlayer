using System;
using Utility.Network.Tracker.Identity;

namespace Musics___Client.API.Events
{
    public class PlaylistSavedEventArgs : EventArgs
    {
        public PlaylistSavedEventArgs(string playlistName, bool isPrivate)
        {
            PlaylistName = playlistName;
            IsPrivate = isPrivate;
        }
        public string PlaylistName { get; set; }
        public bool IsPrivate { get; set; }
    }
}
