using CodeCraft.Logger;
using Musics___Server.Authentification;
using System;
using System.Net;
using System.Net.Sockets;
using Utility.Network;
using Utility.Network.Users;

namespace Musics___Server.Network
{
    class Server
    {
        public static readonly Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public const int BUFFER_SIZE = 100000000;
        public static readonly int PORT = 2003;
        public static byte[] buffer = new byte[BUFFER_SIZE];

        public ClientList Clients = new ClientList();
        public TokenList Tokenlist = new TokenList();
        public AuthentificationService AuthService = new AuthentificationService();

        public ConsoleLogger Log { get; } = new ConsoleLogger();

        public void Setup()
        {
            try
            {
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, PORT));
                Log.Info("Setup server Ok");
            }
            catch(Exception ex)
            {
                Log.Info("Setup Failed");
            }
            serverSocket.SendBufferSize = BUFFER_SIZE;
            serverSocket.Listen(0);
            serverSocket.BeginAccept(AcceptCallback, null);
        }

        private void AcceptCallback(IAsyncResult ar)
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
            Log.Info("Client connected with ip : " + socket.RemoteEndPoint.ToString());
            serverSocket.BeginAccept(AcceptCallback, null);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            Socket current = (Socket)ar.AsyncState;
            int received = 0;

            try
            {
                received = current.EndReceive(ar);
            }
            catch
            {
                Log.Info("Client disconnected =(");
                Clients.Remove(current);
            }

            byte[] recBuf = new byte[received];
            Array.Copy(buffer, recBuf, received);

            Program.TreatRequest(recBuf, current);
            //recBuf = new byte[BUFFER_SIZE];

            try
            {
                current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.Partial, ReceiveCallback, current);
            }
            catch
            {
                Log.Info("Client disconnected =(");
                Clients.Remove(current);
            }
        }

        public void SendObject(object obj, Socket socket)
        {
            var msg = Function.Serialize(obj);

            try
            {
                socket.Send(msg.Data, 0, msg.Data.Length, SocketFlags.Partial);
            }
            catch
            {
                Log.Error("Failed to send object");
            }
        }

        public void SendData(byte[] data, Socket socket)
        {
            try
            {
                socket.Send(data, 0, data.Length, SocketFlags.Partial);
            }
            catch
            {
                Log.Error("Failed to send data");
            }
        }
    }
}
