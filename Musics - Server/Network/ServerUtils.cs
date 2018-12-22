using CodeCraft.Logger;
using Musics___Server.Authentification;
using System;
using System.Net;
using System.Net.Sockets;
using Utility.Network;
using Utility.Network.Users;

namespace Musics___Server.Network
{
    public class ServerUtils
    {
        public ClientList Clients = new ClientList();
        public TokenList Tokenlist = new TokenList();
        public AuthentificationService AuthService = new AuthentificationService();

        public ConsoleLogger Log { get; } = new ConsoleLogger();

        protected bool CheckTokenValidity(Packet packet, Socket socket)
        {
            if (!Tokenlist.CheckTokenValidity((packet as Packet).Token, socket))
            {
                Log.Warn($"Client Token not valid (THash : {(packet as Packet).Token?.THash})");
                return false;
            }
            return true;
        }

        protected void DisconnectSocket(Socket socket)
        {
            Tokenlist.RemoveToken(socket);
            Log.Warn("Client disconnected =(");
            Clients.Remove(socket);
        }

        protected void AddUserFromSocket(Socket socket)
        {
            Clients.AddUser(new User(), socket);
            IPEndPoint ipep = socket.RemoteEndPoint as IPEndPoint;
            Log.Info("Client connected with ip : " + ipep.Address.ToString());
        }
    }
}
