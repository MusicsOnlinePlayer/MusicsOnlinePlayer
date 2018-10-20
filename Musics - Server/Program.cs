using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Musics___Server.Usersinfos;
using Musics___Server.MusicsManagement;
using Musics___Server.Network;
using Musics___Server.Commands;
using Utility.Network.Users;
using Utility.Network;
using Utility.Network.Dialog;
using Utility.Musics;
using Utility.Network.Dialog.Rating;
using Utility.Network.Dialog.Edits;
using Utility.Network.Dialog.Uploads;
using Utility.Network.Dialog.Authentification;
using CodeCraft.Logger;



namespace Musics___Server
{
    class Program
    {
        public static Server MyServer = new Server();
        public static ServerComHandler ServerCom = new ServerComHandler();   

        static void Main(string[] args)
        {
            MyServer.Setup();

            MyServer.AuthService.SetupAuth();
            Indexation.InitRepository();

            MyServer.Log.Info("Indexation of all musics....  ");
            MyServer.Log.Info(Indexation.Do(Properties.Settings.Default.UseMultiThreading) + "Musics");
            MyServer.Log.Info("Indexation done.");
            Indexation.SaveAllInfos();

            //Manager.RefreshTrending();

            string entry = "";
            CommandLineInterpreter.Instance.Start();

            while (entry != "-quit")
            {
                entry = Console.ReadLine();
                Commands.Commands.Do(entry);
            }
            MyServer.Log.Info("Saving music info ... ");
            Indexation.SaveAllInfos();
            MyServer.Log.Info("Done.");
        }

        public static void PromoteUser(string UID, Rank rank)
        {
            UsersInfos.SetRankOfUser(UID, rank);

            User tmpUser = MyServer.Clients.GetUser(UID);
            if (tmpUser != null)
            {
                tmpUser.Userrank = rank;
                Socket tmpSocket = MyServer.Clients.GetSocket(UID);
                MyServer.Clients.Remove(tmpSocket);
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
                    MyServer.Log.Warn("Client disconnected =(");
                    MyServer.Clients.Remove(socket);
                }
                if (received is EditUser)
                {
                    EditUser tmp = received as EditUser;
                    if (MyServer.AuthService.EditUser(tmp.UIDOld, tmp.NewUser))
                    {
                        MyServer.SendObject(new EditUserReport(true, tmp.NewUser), socket);

                        MyServer.Clients.Remove(socket);
                        MyServer.Clients.AddUser(tmp.NewUser, socket);
                        MyServer.Log.Warn($"User {tmp.NewUser} has been edited");
                        return;
                    }
                    else
                    {
                        MyServer.Log.Warn($"Editing the user {tmp.NewUser} failed !");
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
                                MyServer.Log.Warn($"User promoted { tmp.UserToEdit} to " + tmp.NewRankOfUser.ToString());
                            }
                            else
                            {
                                MyServer.Log.Warn($"Promoting the user {tmp.UserToEdit} to {tmp.NewRankOfUser.ToString()} failed !");
                            }
                            break;
                        case TypesEdit.Musics:
                            if ((int)MyServer.Clients.GetUser(socket).Userrank > 1)
                            {
                                Indexation.ModifyElement(tmp.ObjectToEdit as Element, tmp.NewName ,tmp.NewGenres);
                                MyServer.Log.Warn($"The musics {tmp.NewName} has been edited !");
                            }
                            else
                            {
                                MyServer.Log.Warn($"The musics {tmp.NewName } couldn't be edited");
                            }
                            break;
                    }
                }
                if (received is SavePlaylist)
                {
                    SavePlaylist tmp = received as SavePlaylist;
                    UsersInfos.SaveUserPlaylist(tmp.UID, tmp.Playlist);
                    MyServer.Log.Info($"The playlist {tmp.Playlist.Name} has been created");
                }
                if(received is UploadMusic)
                {
                    UploadMusic tmp = received as UploadMusic;
                    if (Indexation.AddElement(tmp) && (int)MyServer.Clients.GetUser(socket).Userrank > 1)
                    {
                        MyServer.SendObject(new UploadReport(null, true),socket);
                        MyServer.Log.Warn($"The music { tmp.MusicPart.Name } has been upload");
                    }
                    else
                    {
                        MyServer.SendObject(new UploadReport(null, false), socket);
                        MyServer.Log.Warn($"The music { tmp.MusicPart.Name } has been upload");
                        MyServer.Log.Warn("Upload completed with success");
                    }
                }
            }
            else
            {
                if (received is Login)
                {
                    Login auth = received as Login;

                    MyServer.Log.Warn("Client try to login");

                    if (auth.IsSignup)
                    {
                        MyServer.AuthService.SignupUser(auth.LoginInfo);
                        MyServer.Clients.Remove(socket);
                        MyServer.Clients.AddUser(auth.LoginInfo, socket);
                        MyServer.SendObject(new AuthInfo(true, Rank.Viewer), socket);
                    }
                    else
                    {
                       // if (MyServer.AuthService.SigninUser(auth.LoginInfo) && !MyServer.Clients.Contains(auth.LoginInfo.UID))
                       if(true)
                        {
                            Rank RankUser = UsersInfos.GetRankOfUser(auth.LoginInfo.UID);
                            MyServer.SendObject(new AuthInfo(true, RankUser), socket);
                            MyServer.Clients.Remove(socket);
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