using System;
using Utility.Musics;

namespace Utility.Network.Dialog.Uploads
{
    [Serializable]
    public class SavePlaylist : Packet
    {
        public string UID { get; set; }
        public Playlist Playlist { get; set; }

        public SavePlaylist(string UserId, Playlist UserPlaylist)
        {
            UID = UserId;
            Playlist = UserPlaylist;
        }
    }
}
