using System.Collections.Generic;
using System.Net.Sockets;
using System.Linq;
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



namespace Musics___Server
{
    class Program
    {
        public static Server MyServer { get; } = new Server();
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

            CommandLineInterpreter.Instance.Start();

            MyServer.Log.Info("Saving music info ... ");
            Indexation.SaveAllInfos();
            MyServer.Log.Info("Done.");
        }

        public static void PromoteUser(string UID, Rank rank)
        {
            UsersInfos.SetRankOfUser(UID, rank);
            if (MyServer.Clients.IsConnected(UID))
            {
                var userUpdated = UsersInfos.GetUser(UID);
                MyServer.SendObject(new EditUserReport(true, userUpdated), MyServer.Clients.GetSocket(UID));
            }

            //User tmpUser = MyServer.Clients.GetUser(UID);
            //if (tmpUser != null)
            //{
            //    tmpUser.Rank = rank;
            //    Socket tmpSocket = MyServer.Clients.GetSocket(UID);
            //    MyServer.Clients.Remove(tmpSocket);
            //    MyServer.Clients.AddUser(tmpUser, tmpSocket);
            //    MyServer.SendObject(new EditUserReport(true, MyServer.Clients.GetUser(UID)), MyServer.Clients.GetSocket(UID));
            //}
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
                switch (received)
                {
                    case Request request:
                        TreatRequest(socket, request);
                        break;

                    case Rate rate:
                        TreatRate(socket, rate);
                        break;

                    case Disconnect disconnect:
                        TreatDisconnect(socket);
                        break;

                    case EditUser editUser:
                        TreatEditUser(socket, editUser);
                        break;

                    case EditRequest editRequest:
                        TreatEditRequest(socket, editRequest);
                        break;

                    case SavePlaylist savePlayList:
                        TreatSavePlayList(savePlayList);
                        break;

                    case UploadMusic uploadMusic:
                        TreatUploadMusic(socket, uploadMusic);
                        break;
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
                        MyServer.SendObject(new AuthInfo(false, Rank.Viewer), socket);
                    }
                    else
                    {
                        // if (MyServer.AuthService.SigninUser(auth.LoginInfo) && !MyServer.Clients.Contains(auth.LoginInfo.UID))
                        if (true)
                        {
                            var foundUser = UsersInfos.GetAllUsers().SingleOrDefault(u => u.UID == auth.LoginInfo.UID);
                            var isRegister = foundUser != null;
                            if (isRegister)
                            {
                               // MyServer.Clients.Remove(socket);
                                MyServer.Clients.AddUser(auth.LoginInfo, socket);
                            }
                            MyServer.SendObject(new AuthInfo(isRegister, Rank.Viewer,foundUser), socket);
                        }
                        else
                        {
                            MyServer.SendObject(new AuthInfo(false, Rank.Viewer), socket);
                        }
                    }
                }
            }
        }

        private static void TreatUploadMusic(Socket socket, UploadMusic uploadMusic)
        {
            if (Indexation.AddElement(uploadMusic) && (int)MyServer.Clients.GetUser(socket).Rank > 1)
            {
                MyServer.SendObject(new UploadReport(null, true), socket);
                MyServer.Log.Warn($"The music { uploadMusic.MusicPart.Name } has been upload");
            }
            else
            {
                MyServer.SendObject(new UploadReport(null, false), socket);
                MyServer.Log.Warn($"The music { uploadMusic.MusicPart.Name } has been upload");
                MyServer.Log.Warn("Upload completed with success");
            }
        }

        private static void TreatSavePlayList(SavePlaylist savePlayList)
        {
            UsersInfos.SaveUserPlaylist(savePlayList.UID, savePlayList.Playlist);
            MyServer.Log.Info($"The playlist {savePlayList.Playlist.Name} has been created");
        }

        private static void TreatEditRequest(Socket socket, EditRequest editRequest)
        {
            switch (editRequest.TypeOfEdit)
            {
                case TypesEdit.Users:
                    if (UsersInfos.GetRankOfUser(MyServer.Clients.GetUser(socket).UID) > editRequest.NewRankOfUser && UsersInfos.GetRankOfUser(MyServer.Clients.GetUser(socket).UID) > UsersInfos.GetRankOfUser(editRequest.UserToEdit))
                    {
                        PromoteUser(editRequest.UserToEdit, editRequest.NewRankOfUser);
                        List<User> tmpU = new List<User>
                                {
                                    UsersInfos.GetUser(editRequest.UserToEdit)
                                };
                        MyServer.SendObject(new RequestAnswer(tmpU, true), socket);
                        MyServer.Log.Warn($"User promoted { editRequest.UserToEdit} to " + editRequest.NewRankOfUser.ToString());
                    }
                    else
                    {
                        MyServer.Log.Warn($"Promoting the user {editRequest.UserToEdit} to {editRequest.NewRankOfUser.ToString()} failed !");
                    }
                    break;
                case TypesEdit.Musics:
                    if (MyServer.Clients.GetUser(socket).Rank > Rank.User)
                    {
                        Indexation.ModifyElement(editRequest.ObjectToEdit as Element, editRequest.NewName, editRequest.NewGenres);
                        MyServer.Log.Warn($"The musics {editRequest.NewName} has been edited !");
                    }
                    else
                    {
                        MyServer.Log.Warn($"The musics {editRequest.NewName } couldn't be edited");
                    }
                    break;
            }
        }

        private static void TreatEditUser(Socket socket, EditUser editUser)
        {
            if (MyServer.AuthService.EditUser(editUser.UIDOld, editUser.NewUser))
            {
                MyServer.SendObject(new EditUserReport(true, editUser.NewUser), socket);

                MyServer.Clients.Remove(socket);
                MyServer.Clients.AddUser(editUser.NewUser, socket);
                MyServer.Log.Warn($"User {editUser.NewUser.Name} has been edited");
            }
            else
            {
                MyServer.Log.Warn($"Editing the user {editUser.NewUser.Name} failed !");
                MyServer.SendObject(new EditUserReport(false, editUser.NewUser), socket);
            }
        }

        private static void TreatDisconnect(Socket socket)
        {
            MyServer.Log.Warn("Client disconnected =(");
            MyServer.Clients.Remove(socket);
        }

        private static void TreatRate(Socket socket, Rate rate) => Network.Handle.Rates.Handle(rate, socket);
        private static void TreatRequest(Socket socket, Request request) => Network.Handle.Requests.Handle(request, socket);
    }
}