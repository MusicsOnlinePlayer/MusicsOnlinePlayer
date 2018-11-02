using ControlLibrary.Network;
using System;
using System.Collections.Generic;
using Utility.Musics;
using Utility.Network.Dialog.Uploads;
using Utility.Network.Users;

namespace Musics___Client.API
{
    public class PlaylistServices
    {
        static private readonly Lazy<PlaylistServices> instance = new Lazy<PlaylistServices>(() => new PlaylistServices());
        static public PlaylistServices Instance { get => instance.Value; }

        private PlaylistServices() { }

        public void SubmitPlaylist(User me,string PlaylistName,List<Music> PlaylistData,bool IsPrivate)
        {
            NetworkClient.SendObject(new SavePlaylist(me.UID, new Playlist(me, PlaylistName, PlaylistData, IsPrivate)));
        }
    }
}
