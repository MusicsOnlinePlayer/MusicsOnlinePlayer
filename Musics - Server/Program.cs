using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Utility;
using Musics___Server.MusicManagement;
using Musics___Server.Authentification;
using Musics___Server.Usersinfos;
using Musics___Server.MusicsInformation;

namespace Musics___Server
{
    class Program
    {
        private static readonly Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private const int BUFFER_SIZE = 100000000;
        private static readonly int PORT = 2003;
        private static readonly byte[] buffer = new byte[BUFFER_SIZE];

        private static ClientList Clients = new ClientList();
        private static AuthentificationService AuthService = new AuthentificationService();

        static void Main(string[] args)
        {
            SetupServer();
            //serverSocket.SendBufferSize = BUFFER_SIZE;

            AuthService.SetupAuth();
            MusicsInfo.SetupMusics();

            Console.Write("|| Indexation of all musics....  ");
            Console.WriteLine(Indexation.DoIndexation() + "Musics");
            Console.WriteLine("|| Indexation done.");

            Indexation.SaveAllInfos();

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
                    Console.Write("|| Indexation of all musics....  ");
                    Console.WriteLine(Indexation.DoIndexation() + "Musics");
                    Console.WriteLine("|| Indexation done.");
                }
                else if (entry == "-save")
                {
                    Console.Write("|| Saving music info ... ");
                    Indexation.SaveAllInfos();
                    Console.WriteLine("Done.");
                }
            }
            Console.Write("|| Saving music info ... ");
            Indexation.SaveAllInfos();
            Console.WriteLine("Done.");

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

            }
            catch (ObjectDisposedException)
            {
                return;
            }

            socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, socket);
            Clients.AddUser(new User(), socket);
            Console.WriteLine("Client connected =)");
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
                current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, current);
            }
            catch
            {
                Console.WriteLine("Client disconnected =(");
                Clients.List.Remove(current);
            }
        }

        private static void SendObject(object obj, Socket socket)
        {

            var msg = Function.Serialize(obj);
            try
            {
                socket.Send(msg.Data, 0, msg.Data.Length, SocketFlags.None);

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
            catch { return; }

            if (Clients.GetUser(socket).UID != null)
            {

                if (received is RequestSearch)
                {
                    RequestSearch requestSearch = received as RequestSearch;
                    Console.WriteLine("Request by client :" + requestSearch.Name);
                    TreatSearch(requestSearch, socket);


                }
                if (received is RequestMusic)
                {
                    RequestMusic requestMusic = received as RequestMusic;
                    foreach (Author a in Indexation.ServerMusics)
                    {
                        foreach (Album al in a.albums)
                        {
                            foreach (Music m in al.Musics)
                            {
                                if (m.Title == requestMusic.Requested.Title)
                                {
                                    Music answer = new Music(m.Title, new Author(m.Author.Name), Indexation.GetFileBinary(m))
                                    {
                                        Format = m.Format,
                                        Rating = m.Rating
                                    };

                                    SendObject(new RequestMusicAnswer(answer), socket);
                                    return;
                                }
                            }

                        }
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
                        foreach (var al in a.albums)
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
                                    }
                                    SendObject(new RateReport(true, temp.MusicRatedMID, m.Rating), socket);
                                }
                            }
                        }
                    }

                }
            }
            else
            {
                if (received is Login)
                {
                    Login auth = received as Login;

                    if (auth.IsSignup)
                    {
                        AuthService.SignupUser(auth.LoginInfo);
                        Clients.List.Remove(socket);
                        Clients.AddUser(auth.LoginInfo, socket);
                        SendObject(new AuthInfo(true), socket);
                    }
                    else
                    {
                        if (AuthService.SigninUser(auth.LoginInfo) && !Clients.Contains(auth.LoginInfo.UID))
                        {
                            SendObject(new AuthInfo(true), socket);
                            Clients.List.Remove(socket);
                            Clients.AddUser(auth.LoginInfo, socket);
                        }
                        else
                        {
                            SendObject(new AuthInfo(false), socket);
                        }
                    }
                }
            }


        }

        private static void TreatSearch(RequestSearch requestSearch, Socket asker)
        {
            if (Clients.GetUser(asker).UID != null)
            {
                Console.WriteLine("Sending to the client :");

                if (requestSearch.Requested is Author)
                {
                    List<Author> answer = new List<Author>();

                    foreach (Author a in Indexation.ServerMusics)
                    {
                        if (a.Name.Contains(requestSearch.Name))
                        {
                            Author author = new Author(a.Name);
                            foreach (var al in a.albums)
                            {
                                author.albums.Add(new Album(new Author(a.Name), al.Name));
                                foreach (var m in al.Musics)
                                {
                                    Music temp = new Music(m.Title, author, "")
                                    {
                                        Rating = m.Rating
                                    };
                                    author.albums.Last().Add(temp);
                                }
                            }
                            answer.Add(author);
                            Console.WriteLine("  " + a.Name);
                        }
                    }

                    SendObject(new RequestSearchAnswer(answer, new Author(null)), asker);

                }
                if (requestSearch.Requested is Album)
                {
                    List<Album> answer = new List<Album>();

                    foreach (Author a in Indexation.ServerMusics)
                    {
                        foreach (Album al in a.albums)
                        {
                            if (al.Name.Contains(requestSearch.Name))
                            {
                                Album tmp = new Album(new Author(al.Author.Name), al.Name);
                                foreach (var z in al.Musics)
                                {
                                    Music temp = new Music(z.Title, new Author(z.Author.Name), "")
                                    {
                                        Rating = z.Rating
                                    };
                                    tmp.Add(temp);
                                }
                                answer.Add(tmp);
                                Console.WriteLine("  " + al.Name);
                            }
                        }
                    }
                    SendObject(new RequestSearchAnswer(answer, new Album(null, null)), asker);
                }
                if (requestSearch.Requested is Music)
                {
                    List<Music> answer = new List<Music>();

                    foreach (Author a in Indexation.ServerMusics)
                    {
                        foreach (Album al in a.albums)
                        {
                            foreach (Music m in al.Musics)
                            {
                                if (m.Title.Contains(requestSearch.Name))
                                {
                                    Music temp = new Music(m.Title, new Author(a.Name), "")
                                    {
                                        Rating = m.Rating
                                    };

                                    answer.Add(temp);
                                    Console.WriteLine("  " + m.Title);
                                }
                            }

                        }
                    }
                    SendObject(new RequestSearchAnswer(answer, new Music()), asker);
                }

            }
        }

    }
}
