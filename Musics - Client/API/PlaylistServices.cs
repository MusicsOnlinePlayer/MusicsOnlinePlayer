using ControlLibrary.Network;
using System.Collections.Generic;
using Utility.Musics;
using Utility.Network.Dialog.Uploads;
using Utility.Network.Users;

namespace Musics___Client.API
{
    public class PlaylistServices
    {
        public void SubmitPlaylist(User me,string PlaylistName,List<Music> PlaylistData,bool IsPrivate)
        {
            NetworkClient.SendObject(new SavePlaylist(me.UID, new Playlist(me, PlaylistName, PlaylistData, IsPrivate)));
        }
    }
}
