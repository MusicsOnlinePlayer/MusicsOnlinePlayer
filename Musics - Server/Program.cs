using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Utility;
using Musics___Server.Authentification;
using Musics___Server.Usersinfos;
using Musics___Server.MusicsInformation;
using Musics___Server.MusicsManagement;
using Musics___Server.MusicsManagement.ClientSearch;
using Musics___Server.MusicsManagement.Trending;
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
        private static readonly Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private const int BUFFER_SIZE = 100000000;
        private static readonly int PORT = 2003;
        private static byte[] buffer = new byte[BUFFER_SIZE];

        public static ClientList Clients = new ClientList();
        private static AuthentificationService AuthService = new AuthentificationService();

        static void Main(string[] args)
        {
            SetupServer();
            //serverSocket.SendBufferSize = BUFFER_SIZE;

            AuthService.SetupAuth();
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
                if (entry == "-init")
                {
                    Indexation.InitRepository();
                }
                else if (entry == "-index")
                {
                    Console.Write("~ Indexation of all musics....  ");
                    Console.WriteLine(Indexation.DoIndexation() + "Musics");
                    Console.WriteLine("~ Indexation done.");
                }
                else if (entry == "-save")
                {
                    Console.Write("~ Saving music info ... ");
                    Indexation.SaveAllInfos();
                    Console.WriteLine("Done.");
                }
                else if (entry == "-users")
                {
                    Console.WriteLine("~ Getting all connected users");
                    foreach (User u in Clients.List.Values)
                    {
                        Console.WriteLine(" - " + u.Name + " " + u.Userrank.ToString() + " " + u.UID);
                    }
                    Console.WriteLine("End.");
                }
                else if (entry == "-users -all")
                {
                    Console.WriteLine("~ Getting all users");
                    foreach (User u in UsersInfos.GetAllUsers())
                    {
                        Console.WriteLine(" - " + u.Name + " " + u.Userrank.ToString() + " " + u.UID);
                    }
                    Console.WriteLine("End.");
                }
                else if (entry.Contains("-promote"))
                {
                    string UID = entry.Split('-')[2].Replace(" ", "");
                    if (Enum.TryParse(entry.Split('-')[3], out Rank rank))
                    {
                        Console.WriteLine("~ Promote " + UID + " to " + rank.ToString());
                        PromoteUser(UID, rank);

                        Console.WriteLine("Ok.");
                    }
                    else
                    {
                        Console.WriteLine("~ Syntax not correct, please use -promote -UID -Rank");
                    }
                }
            }
            Console.Write("~ Saving music info ... ");
            Indexation.SaveAllInfos();
            Console.WriteLine("Done.");
        }

        public static void PromoteUser(string UID, Rank rank)
        {
            UsersInfos.SetRankOfUser(UID, rank);

            User tmpUser = Clients.GetUser(UID);
            if (tmpUser != null)
            {
                tmpUser.Userrank = rank;
                Socket tmpSocket = Clients.GetSocket(UID);
                Clients.List.Remove(tmpSocket);
                Clients.AddUser(tmpUser, tmpSocket);
                SendObject(new EditUserReport(true, Clients.GetUser(UID)), Clients.GetSocket(UID));
            }
        }

        public static void SetupServer()
        {
            try
            {
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, PORT));
                Console.WriteLine("Setup server Ok");
            }
            catch
            {
                Console.WriteLine("Erreur Setup");
            }
            serverSocket.SendBufferSize = BUFFER_SIZE;
            serverSocket.Listen(0);
            serverSocket.BeginAccept(AcceptCallback, null);
        }

        private static void AcceptCallback(IAsyncResult ar)
        {
            Socket socket;

            try
            {
                socket = serverSocket.EndAccept(ar);
                socket.SendTimeout = 600000;
                socket.ReceiveTimeout = 600000;
            }
            catch (ObjectDisposedException)
            {
                return;
            }

            socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.Partial, ReceiveCallback, socket);
            Clients.AddUser(new User(), socket);
            Console.WriteLine("Client connected with ip : " + socket.RemoteEndPoint.ToString());
            serverSocket.BeginAccept(AcceptCallback, null);
        }
        private static void ReceiveCallback(IAsyncResult ar)
        {
            Socket current = (Socket)ar.AsyncState;
            int received = 0;

            try
            {
                received = current.EndReceive(ar);
            }
            catch
            {
                Console.WriteLine("Client disconnected =(");
                Clients.List.Remove(current);
            }

            byte[] recBuf = new byte[received];
            Array.Copy(buffer, recBuf, received);

            TreatRequest(recBuf, current);
            recBuf = new byte[BUFFER_SIZE];

            try
            {
                current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.Partial, ReceiveCallback, current);
            }
            catch
            {
                Console.WriteLine("Client disconnected =(");
                Clients.List.Remove(current);
            }
        }

        public static void SendObject(object obj, Socket socket)
        {
            //buffer = new byte[BUFFER_SIZE];
            var msg = Function.Serialize(obj);

            try
            {
                socket.Send(msg.Data, 0, msg.Data.Length, SocketFlags.Partial);
            }
            catch
            {
            }
        }

        private static void TreatRequest(byte[] Buffer, Socket socket)
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
                ClientLogin = Clients.GetUser(socket).UID != null;
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
                                        if (m.Title == request.RequestedBinaries.Title)
                                        {
                                            Music answer = new Music(m.Title, new Author(m.Author.Name), Indexation.GetFileBinary(m))
                                            {
                                                Format = m.Format,
                                                Rating = m.Rating
                                            };
                                            Console.Write("Sending binaries for " + m.Title);

                                            SendObject(new RequestAnswer(answer), socket);
                                            return;
                                        }
                                    }
                                }
                            }
                            break;
                        case RequestsTypes.Favorites:
                            SendObject(new RequestAnswer(UsersInfos.GetLikedMusics(request.UserID)), socket);
                            break;
                        case RequestsTypes.Users:
                            if (Clients.GetUser(socket).Userrank != Rank.Viewer)
                            {
                                SendObject(new RequestAnswer(UsersInfos.SearchUser(request.Username), true), socket);
                            }
                            else
                            {
                                SendObject(new RequestAnswer(null, false), socket);
                            }
                            break;
                        case RequestsTypes.Trending:
                            SendObject(new RequestAnswer(Manager.GenreTrending), socket);
                            break;
                    }
                }
                if (received is Rate)
                {
                    Rate temp = received as Rate;

                    bool VoteExist = UsersInfos.VoteExist(temp.MusicRatedMID, Clients.List[socket].UID);
                    UsersInfos.AddVoteMusic(temp.MusicRatedMID, Clients.List[socket].UID);
                    //VoteExist = UsersInfos.VoteExist(temp.MusicRatedMID, Clients.List[socket].UID);

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

                                        Clients.List.TryGetValue(socket, out User value);
                                        SendObject(new RequestAnswer(UsersInfos.GetLikedMusics(value.UID)), socket);
                                    }
                                    SendObject(new RateReport(true, temp.MusicRatedMID, m.Rating), socket);
                                }
                            }
                        }
                    }
                }
                if(received is Disconnect)
                {
                    Console.WriteLine("Client disconnected =(");
                    Clients.List.Remove(socket);
                }
                if (received is EditUser)
                {
                    EditUser tmp = received as EditUser;
                    if (AuthService.EditUser(tmp.UIDOld, tmp.NewUser))
                    {
                        SendObject(new EditUserReport(true, tmp.NewUser), socket);

                        Clients.List.Remove(socket);
                        Clients.AddUser(tmp.NewUser, socket);
                        return;
                    }
                    else
                    {
                        SendObject(new EditUserReport(false, tmp.NewUser), socket);
                    }
                }
                if (received is EditRequest)
                {
                    EditRequest tmp = received as EditRequest;

                    switch (tmp.TypeOfEdit)
                    {
                        case TypesEdit.Users:
                            if ((int)UsersInfos.GetRankOfUser(Clients.GetUser(socket).UID) > (int)tmp.NewRankOfUser && (int)UsersInfos.GetRankOfUser(Clients.GetUser(socket).UID) > (int)UsersInfos.GetRankOfUser(tmp.UserToEdit))
                            {
                                PromoteUser(tmp.UserToEdit, tmp.NewRankOfUser);
                                List<User> tmpU = new List<User>
                                {
                                    UsersInfos.GetUser(tmp.UserToEdit)
                                };
                                SendObject(new RequestAnswer(tmpU, true), socket);
                                Console.WriteLine("~ User promoted " + tmp.UserToEdit + " to " + tmp.NewRankOfUser.ToString());
                            }
                            break;
                        case TypesEdit.Musics:
                            if ((int)Clients.GetUser(socket).Userrank > 1)
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
                    if (Indexation.AddElement(tmp) && (int)Clients.GetUser(socket).Userrank > 1)
                    {
                        SendObject(new UploadReport(null, true),socket);
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
                        AuthService.SignupUser(auth.LoginInfo);
                        Clients.List.Remove(socket);
                        Clients.AddUser(auth.LoginInfo, socket);
                        SendObject(new AuthInfo(true, Rank.Viewer), socket);
                    }
                    else
                    {
                        if (AuthService.SigninUser(auth.LoginInfo) && !Clients.Contains(auth.LoginInfo.UID))
                        {
                            Rank RankUser = UsersInfos.GetRankOfUser(auth.LoginInfo.UID);
                            SendObject(new AuthInfo(true, RankUser), socket);
                            Clients.List.Remove(socket);
                            auth.LoginInfo.Userrank = RankUser;
                            Clients.AddUser(auth.LoginInfo, socket);
                        }
                        else
                        {
                            SendObject(new AuthInfo(false, Rank.Viewer), socket);
                        }
                    }
                }
            }
        }
    }
}