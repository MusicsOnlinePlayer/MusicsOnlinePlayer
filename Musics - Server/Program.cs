using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Musics___Server.Usersinfos;
using Musics___Server.MusicsInformation;
using Musics___Server.MusicsManagement;
using Musics___Server.Network;
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
            Console.WriteLine(Indexation.DoIndexation(Properties.Settings.Default.UseMultiThreading) + "Musics");
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
                    Network.Handle.Requests.Handle(received as Request,socket);
                }
                if (received is Rate)
                {
                    Network.Handle.Rates.Handle(received as Rate, socket);
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
                                Indexation.ModifyElement(tmp.ObjectToEdit as IElement, tmp.NewName ,tmp.NewGenres);
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