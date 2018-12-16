using Musics___Server.Usersinfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Utility.Network.Dialog.Uploads;

namespace Musics___Server.Services
{
    public class PlaylistService
    {
        public PlaylistService()
        {
            Program.MyServer.OnPacketreceived += MyServer_OnPacketreceived;
        }

        private void MyServer_OnPacketreceived(object sender, EventsArgs.PacketEventArgs a)
        {
            if (a.Packet is SavePlaylist)
                TreatSavePlayList(a.Packet as SavePlaylist);
        }

        private static void TreatSavePlayList(SavePlaylist savePlayList)
        {
            UsersInfos.SaveUserPlaylist(savePlayList.UID, savePlayList.Playlist);
            Program.MyServer.Log.Info($"The playlist {savePlayList.Playlist.Name} has been created");
        }
    }
}
