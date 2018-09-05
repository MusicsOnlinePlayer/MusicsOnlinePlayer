using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Musics___Server.Authentification;
using Musics___Server.Usersinfos;
using Musics___Server.MusicsInformation;
using Musics___Server.MusicsManagement;
using Musics___Server.Network;
using Musics___Server.MusicsManagement.ClientSearch;
using Utility.Network.Users;
using Utility.Network;
using Utility.Network.Dialog;
using Utility.Musics;
using Utility.Network.Dialog.Rating;
using Utility.Network.Dialog.Edits;
using Utility.Network.Dialog.Uploads;
using Utility.Network.Dialog.Authentification;

namespace Musics___Server
{
    class Program
    {
        public static Server MyServer = new Server();

        static void Main(string[] args)
        {
            MyServer.Setup();

            MyServer.AuthService.SetupAuth();
            MusicsInfo.SetupMusics();

            Console.Write("~ Indexation of all musics....  ");
            Console.WriteLine(Indexation.DoIndexation() + "Musics");
            Console.WriteLine("~ Indexation done.");

            Indexation.SaveAllInfos();

            //Manager.RefreshTrending();

            string entry = "";

            while (entry != "-quit")
            {
                entry = Console.ReadLine();
                Commands.Commands.Do(entry);
            }
            Console.Write("~ Saving music info ... ");
            Indexation.SaveAllInfos();
            Console.WriteLine("Done.");
        }

        public static void PromoteUser(string UID, Rank rank)
        {
            UsersInfos.SetRankOfUser(UID, rank);

            User tmpUser = MyServer.Clients.GetUser(UID);
            if (tmpUser != null)
            {
                tmpUser.Userrank = rank;
                Socket tmpSocket = MyServer.Clients.GetSocket(UID);
                MyServer.Clients.List.Remove(tmpSocket);
                MyServer.Clients.AddUser(tmpUser, tmpSocket);
                MyServer.SendObject(new EditUserReport(true, MyServer.Clients.GetUser(UID)), MyServer.Clients.GetSocket(UID));
            }
        }

        public static void TreatRequest(byte[] Buffer, Socket socket)
        {
            object received;
            try
            {
                received = Function.Deserialize(new MessageTCP(Buffer));
            }
            catch
            {
                return;
            }

            bool ClientLogin;

            try
            {
                ClientLogin = MyServer.Clients.GetUser(socket).UID != null;
            }
            catch
            {
                ClientLogin = false;
            }

            if (ClientLogin)
            {
                if (received is Request)
                {
                    Request request = received as Request;

                    switch (request.RequestsTypes)
                    {
                        case RequestsTypes.Search:
                            Console.WriteLine("Request by client :" + request.Name);
                            SearchAnswer.Do(request, socket);
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

                                            MyServer.SendObject(new RequestAnswer(answer), socket);
                                            return;
                                        }
                                    }
                                }
                            }
                            break;
                        case RequestsTypes.Favorites:
                            List<Music> tmp = UsersInfos.GetLikedMusics(request.UserID);
                            MyServer.SendObject(new RequestAnswer(tmp), socket);
                            break;
                        case RequestsTypes.Users:
                            if (MyServer.Clients.GetUser(socket).Userrank != Rank.Viewer)
                            {
                                MyServer.SendObject(new RequestAnswer(UsersInfos.SearchUser(request.Username), true), socket);
                            }
                            else
                            {
                                MyServer.SendObject(new RequestAnswer(null, false), socket);
                            }
                            break;
                    }
                }
                if (received is Rate)
                {
                    Rate temp = received as Rate;

                    bool VoteExist = UsersInfos.VoteExist(temp.MusicRatedMID, MyServer.Clients.List[socket].UID);
                    UsersInfos.AddVoteMusic(temp.MusicRatedMID, MyServer.Clients.List[socket].UID);
                    
                    if(temp.Type == Element.Music)
                    {
                        foreach (var a in Indexation.ServerMusics)
                        {
                            foreach (var al in a.Albums)
                            {
                                foreach (var m in al.Musics)
                                {
                                    if (m.MID == temp.MusicRatedMID)
                                    {
                                        if (VoteExist)
                                        {
                                            m.Rating--;
                                        }
                                        else
                                        {
                                            m.Rating++;

                                            MyServer.Clients.List.TryGetValue(socket, out User value);
                                            MyServer.SendObject(new RequestAnswer(UsersInfos.GetLikedMusics(value.UID)), socket);
                                        }
                                        MyServer.SendObject(new RateReport(true, temp.MusicRatedMID, m.Rating), socket);
                                        MusicsInfo.SaveMusicInfo(m);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        UsersInfos.RatePlaylist(temp.MusicRatedMID, !VoteExist);
                        MyServer.SendObject(new RateReport(true, temp.MusicRatedMID, UsersInfos.GetPlaylist(temp.MusicRatedMID).Rating),socket);
                    }
                }
                if(received is Disconnect)
                {
                    Console.WriteLine("Client disconnected =(");
                    MyServer.Clients.List.Remove(socket);
                }
                if (received is EditUser)
                {
                    EditUser tmp = received as EditUser;
                    if (MyServer.AuthService.EditUser(tmp.UIDOld, tmp.NewUser))
                    {
                        MyServer.SendObject(new EditUserReport(true, tmp.NewUser), socket);

                        MyServer.Clients.List.Remove(socket);
                        MyServer.Clients.AddUser(tmp.NewUser, socket);
                        return;
                    }
                    else
                    {
                        MyServer.SendObject(new EditUserReport(false, tmp.NewUser), socket);
                    }
                }
                if (received is EditRequest)
                {
                    EditRequest tmp = received as EditRequest;

                    switch (tmp.TypeOfEdit)
                    {
                        case TypesEdit.Users:
                            if ((int)UsersInfos.GetRankOfUser(MyServer.Clients.GetUser(socket).UID) > (int)tmp.NewRankOfUser && (int)UsersInfos.GetRankOfUser(MyServer.Clients.GetUser(socket).UID) > (int)UsersInfos.GetRankOfUser(tmp.UserToEdit))
                            {
                                PromoteUser(tmp.UserToEdit, tmp.NewRankOfUser);
                                List<User> tmpU = new List<User>
                                {
                                    UsersInfos.GetUser(tmp.UserToEdit)
                                };
                                MyServer.SendObject(new RequestAnswer(tmpU, true), socket);
                                Console.WriteLine("~ User promoted " + tmp.UserToEdit + " to " + tmp.NewRankOfUser.ToString());
                            }
                            break;
                        case TypesEdit.Musics:
                            if ((int)MyServer.Clients.GetUser(socket).Userrank > 1)
                            {
                                Indexation.ModifyElement(tmp.ObjectToEdit, tmp.NewName ,tmp.NewGenres);
                            }
                            break;
                    }
                }
                if (received is SavePlaylist)
                {
                    SavePlaylist tmp = received as SavePlaylist;
                    UsersInfos.SaveUserPlaylist(tmp.UID, tmp.Playlist);
                }
                if(received is UploadMusic)
                {
                    UploadMusic tmp = received as UploadMusic;
                    if (Indexation.AddElement(tmp) && (int)MyServer.Clients.GetUser(socket).Userrank > 1)
                    {
                        MyServer.SendObject(new UploadReport(null, true),socket);
                    }
                    else
                    {
                        MyServer.SendObject(new UploadReport(null, false), socket);
                    }
                }
            }
            else
            {
                if (received is Login)
                {
                    Login auth = received as Login;

                    Console.Write("~ Client try to login");

                    if (auth.IsSignup)
                    {
                        MyServer.AuthService.SignupUser(auth.LoginInfo);
                        MyServer.Clients.List.Remove(socket);
                        MyServer.Clients.AddUser(auth.LoginInfo, socket);
                        MyServer.SendObject(new AuthInfo(true, Rank.Viewer), socket);
                    }
                    else
                    {
                        if (MyServer.AuthService.SigninUser(auth.LoginInfo) && !MyServer.Clients.Contains(auth.LoginInfo.UID))
                        {
                            Rank RankUser = UsersInfos.GetRankOfUser(auth.LoginInfo.UID);
                            MyServer.SendObject(new AuthInfo(true, RankUser), socket);
                            MyServer.Clients.List.Remove(socket);
                            auth.LoginInfo.Userrank = RankUser;
                            MyServer.Clients.AddUser(auth.LoginInfo, socket);
                        }
                        else
                        {
                            MyServer.SendObject(new AuthInfo(false, Rank.Viewer), socket);
                        }
                    }
                }
            }
        }
    }
}