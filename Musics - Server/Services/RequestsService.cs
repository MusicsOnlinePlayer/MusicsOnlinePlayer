using Musics___Server.MusicsManagement;
using Musics___Server.Usersinfos;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Utility.Musics;
using Utility.Network.Dialog;
using Utility.Network.Dialog.Requests;
using Utility.Network.Server;
using Utility.Network.Users;

namespace Musics___Server.Services
{
    public  class RequestsService
    {
        public RequestsService()
        {
            Program.MyServer.OnPacketreceived += MyServer_OnPacketreceived;
        }

        private void MyServer_OnPacketreceived(object sender, PacketEventArgs a)
        {
            if (a.Packet is Request)
                Handle(a.Packet as Request, sender as Socket);
        }
        public void Handle(Request request, Socket socket)
        {
            switch (request.RequestsType)
            {
                case RequestsTypes.Search:
                    Console.WriteLine("Request by client :" + (request as RequestSearch).Name);
                    MusicsManagement.ClientSearch.SearchAnswer.Do(request as RequestSearch, socket);
                    break;

                case RequestsTypes.MusicsBinaries:
                    if(Indexation.TryGetMusicByID((request as RequestBinairies).RequestedBinaries.MID,out Music m)){
                        Music answer = new Music(m.Title, new Author(m.Author.Name), m.Album, Indexation.GetFileBinary(m))
                        {
                            Format = m.Format,
                            Rating = m.Rating
                        };
                        new RequestAnswer(answer).Send(socket);
                    }
                    break;
                case RequestsTypes.Favorites:
                    List<Music> tmp = UsersInfos.GetLikedMusics((request as RequestFavorites).UserID);
                    new RequestAnswer(tmp).Send(socket);
                    break;
                case RequestsTypes.Users:
                    if (Program.MyServer.Clients.GetUser(socket).Rank != Rank.Viewer)
                    {
                        new RequestAnswer(UsersInfos.SearchUser((request as RequestUser).Username), true).Send(socket);
                    }
                    else
                    {
                        new RequestAnswer(null, false).Send(socket);
                    }
                    break;
            }
        }
    }
}
