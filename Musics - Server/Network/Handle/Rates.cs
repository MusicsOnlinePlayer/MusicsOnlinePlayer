using Musics___Server.MusicsInformation;
using Musics___Server.MusicsManagement;
using Musics___Server.Usersinfos;
using System.Net.Sockets;
using Utility.Musics;
using Utility.Network.Dialog;
using Utility.Network.Dialog.Rating;
using Utility.Network.Users;

namespace Musics___Server.Network.Handle
{
    public static class Rates
    {
        public static void Handle(Rate temp, Socket socket)
        {
            bool VoteExist = UsersInfos.VoteExist(temp.MusicRatedMID, Program.MyServer.Clients.List[socket].UID);
            UsersInfos.AddVoteMusic(temp.MusicRatedMID, Program.MyServer.Clients.List[socket].UID);

            if (temp.Type == ElementType.Music)
            {
                var m = Indexation.GetMusic(temp.MusicRatedMID);
                if (m != null)
                {
                    if (VoteExist)
                        m.Rating--;
                    else
                    {
                        m.Rating++;

                        Program.MyServer.Clients.List.TryGetValue(socket, out User value);
                        Program.MyServer.SendObject(new RequestAnswer(UsersInfos.GetLikedMusics(value.UID)), socket);
                    }
                    Program.MyServer.SendObject(new RateReport(true, temp.MusicRatedMID, m.Rating), socket);
                    MusicsInfo.SaveMusicInfo(m);
                }
            }
            else
            {
                UsersInfos.RatePlaylist(temp.MusicRatedMID, !VoteExist);
                Program.MyServer.SendObject(new RateReport(true, temp.MusicRatedMID, UsersInfos.GetPlaylist(temp.MusicRatedMID).Rating), socket);
            }
        }
    }
}
