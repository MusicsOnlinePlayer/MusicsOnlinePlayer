using System;
using Utility.Musics;

namespace Utility.Network.Dialog.Uploads
{
    [Serializable]
    public class SavePlaylist : IPacket
    {
        public string SenderUID { get; set; }
        public bool IsFromServer { get; set; }

        public string UID { get; set; }
        public Playlist Playlist { get; set; }

        public SavePlaylist(string UserId, Playlist UserPlaylist)
        {
            UID = UserId;
            Playlist = UserPlaylist;
        }
    }
}
