using Musics___Server.MusicsManagement;
using Musics___Server.Usersinfos;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Utility.Musics;
using Utility.Network.Dialog;
using Utility.Network.Users;

namespace Musics___Server.Network.Handle
{
    static class Requests
    {
        public static void Handle(Request request,Socket socket)
        {
            switch (request.RequestsTypes)
            {
                case RequestsTypes.Search:
                    Console.WriteLine("Request by client :" + request.Name);
                    MusicsManagement.ClientSearch.SearchAnswer.Do(request, socket);
                    break;

                case RequestsTypes.MusicsBinaries:

                    foreach (Author a in Indexation.ServerMusics)
                    {
                        foreach (Album al in a.Albums)
                        {
                            foreach (Music m in al.Musics)
                            {
                                if (m.MID == request.RequestedBinaries.MID)
                                {
                                    Music answer = new Music(m.Title, new Author(m.Author.Name), Indexation.GetFileBinary(m))
                                    {
                                        Format = m.Format,
                                        Rating = m.Rating
                                    };
                                    Console.Write("Sending binaries for " + m.Title);

                                    Program.MyServer.SendObject(new RequestAnswer(answer), socket);
                                    return;
                                }
                            }
                        }
                    }
                    break;
                case RequestsTypes.Favorites:
                    List<Music> tmp = UsersInfos.GetLikedMusics(request.UserID);
                    Program.MyServer.SendObject(new RequestAnswer(tmp), socket);
                    break;
                case RequestsTypes.Users:
                    if (Program.MyServer.Clients.GetUser(socket).Userrank != Rank.Viewer)
                    {
                        Program.MyServer.SendObject(new RequestAnswer(UsersInfos.SearchUser(request.Username), true), socket);
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
