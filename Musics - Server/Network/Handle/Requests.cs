using Musics___Server.MusicsManagement;
using Musics___Server.Usersinfos;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Utility.Musics;
using Utility.Network.Dialog;
using Utility.Network.Dialog.Requests;
using Utility.Network.Users;

namespace Musics___Server.Network.Handle
{
    static class Requests
    {
        public static void Handle(Request request, Socket socket)
        {
            switch (request.RequestsType)
            {
                case RequestsTypes.Search:
                    Console.WriteLine("Request by client :" + (request as RequestSearch).Name);
                    MusicsManagement.ClientSearch.SearchAnswer.Do(request as RequestSearch, socket);
                    break;

                case RequestsTypes.MusicsBinaries:
                    var m = Indexation.GetMusicByID((request as RequestBinairies).RequestedBinaries.MID);
                    Music answer = new Music(m.Title, new Author(m.Author.Name), m.Album, Indexation.GetFileBinary(m))
                    {
                        Format = m.Format,
                        Rating = m.Rating
                    };
                    Program.MyServer.SendObject(new RequestAnswer(answer), socket);
                    break;
                case RequestsTypes.Favorites:
                    List<Music> tmp = UsersInfos.GetLikedMusics((request as RequestFavorites).UserID);
                    Program.MyServer.SendObject(new RequestAnswer(tmp), socket);
                    break;
                case RequestsTypes.Users:
                    if (Program.MyServer.Clients.GetUser(socket).Rank != Rank.Viewer)
                    {
                        Program.MyServer.SendObject(new RequestAnswer(UsersInfos.SearchUser((request as RequestUser).Username), true), socket);
                    }
                    else
                    {
                        Program.MyServer.SendObject(new RequestAnswer(null, false), socket);
                    }
                    break;
            }
        }
    }
}
