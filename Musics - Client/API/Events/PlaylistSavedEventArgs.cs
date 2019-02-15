using System;
using Utility.Network.Tracker.Identity;

namespace Musics___Client.API.Events
{
    public class PlaylistSavedEventArgs : EventArgs
    {
        public PlaylistSavedEventArgs(string playlistName, bool isPrivate,ServerIdentity SaveServer)
        {
            PlaylistName = playlistName;
            IsPrivate = isPrivate;
            SaveServerId = SaveServer;
        }

        public ServerIdentity SaveServerId { get; set; }
        public string PlaylistName { get; set; }
        public bool IsPrivate { get; set; }
    }
}
