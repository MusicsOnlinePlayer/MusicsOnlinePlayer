using Musics___Server.MusicsInformation;
using Musics___Server.MusicsManagement;
using Musics___Server.Usersinfos;
using System.Net.Sockets;
using Utility.Musics;
using Utility.Network.Dialog;
using Utility.Network.Dialog.Rating;
using Utility.Network.Server;
using Utility.Network.Users;

namespace Musics___Server.Services
{
    public class RatesServices
    {
        public RatesServices()
        {
            Program.MyServer.OnPacketreceived += MyServer_OnPacketreceived;
        }

        private void MyServer_OnPacketreceived(object sender, PacketEventArgs a)
        {
            if (a.Packet is Rate)
                Handle(a.Packet as Rate, sender as Socket);
        }

        public static void Handle(Rate temp, Socket socket)
        {
            bool VoteExist = UsersInfos.VoteExist(temp.MusicRatedMID, Program.MyServer.Clients[socket]);
            UsersInfos.AddVoteMusic(temp.MusicRatedMID, Program.MyServer.Clients[socket]);

            if (temp.Type == ElementType.Music)
            {
                //var m = Indexation.GetMusicByID(temp.MusicRatedMID);
                if(Indexation.TryGetMusicByID(temp.MusicRatedMID,out Music m))
                {
                    if (VoteExist)
                        m.Rating--;
                    else
                    {
                        m.Rating++;

                        Program.MyServer.Clients.TryGetValue(socket, out string uid);
                        new RequestAnswer(UsersInfos.GetLikedMusics(uid)).Send(socket);
                    }
                    new RateReport(true, temp.MusicRatedMID, m.Rating).Send(socket);
                    MusicsInfo.SaveMusicInfo(m);
                }
            }
            else
            {
                UsersInfos.RatePlaylist(temp.MusicRatedMID, !VoteExist);
                new RateReport(true, temp.MusicRatedMID, UsersInfos.GetPlaylist(temp.MusicRatedMID).Rating).Send(socket);
            }
        }
    }
}
