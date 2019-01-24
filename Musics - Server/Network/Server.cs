.using System;
using System.Net;
using System.Net.Sockets;
using Utility.Network;
using Utility.Network.Dialog.Authentification;
using Utility.Network.Server;

namespace Musics___Server.Network
{
    public class Server : ServerUtils
    {
        public ServerComunication ServerComunicationSocket = new ServerComunication();

        public delegate void PacketReceivedEvent(object sender, PacketEventArgs a);
        public delegate void PacketReceivedHandler(object sender, PacketEventArgs a);
        public event PacketReceivedHandler OnPacketreceived;

        public void Setup(IPEndPoint ip)
        {
            ServerComunicationSocket.SetupSocket(ip.Port, 100000000);
            BindAndListenSocket(ip);
            StartAcceptingAndReceiveClients();
            AuthService.SetupAuth();
        }

        public void BindAndListenSocket(IPEndPoint iPEndPoint)
        {
            try
            {
                ServerComunicationSocket.TryBindSocket(iPEndPoint);
                ServerComunicationSocket.TryListen();
                Log.Info($"Bind finiched at port {iPEndPoint.Port}");
            }
            catch(ServerSocketException ex)
            {
                switch (ex.ExceptionType)
                {
                    case ServerSocketErrors.AddressAlreadyTaken:
                        iPEndPoint.Port++;
                        Log.Critical($"Address already on port {ServerComunicationSocket.GetConnectSocketPORT()} retrying with {iPEndPoint.Port}");
                        BindAndListenSocket(iPEndPoint);
                        break;
                    case ServerSocketErrors.ConnectionStopped:
                        Log.Critical($"Listening has been stopped for an uknown reason !");
                        break;
                }
            }
        }

        public void StartAcceptingAndReceiveClients()
        {
            ServerComunicationSocket.SocketConnected += ServerComunicationSocket_OnSocketConnected;
            ServerComunicationSocket.DataReceived += ServerComunicationSocket_OnDataReceived;
            ServerComunicationSocket.SocketDisconnected += ServerComunicationSocket_SocketDisconnected;
            ServerComunicationSocket.BeginAcceptConnection();
        }

        private void ServerComunicationSocket_SocketDisconnected(object sender, SocketConnectedEventArgs args)
        {
            Log.Info($"Client disconnected");
            Clients.Remove(args.SocketConnected);
            Tokenlist.RemoveToken(args.SocketConnected);
        }

        private void ServerComunicationSocket_OnSocketConnected(object sender, SocketConnectedEventArgs args)
            => AddUserFromSocket(args.SocketConnected);


        private void ServerComunicationSocket_OnDataReceived(object sender, DataReceivedFromSocketArgs args)
        {
            IPacket PacketRec;
            try
            {
                PacketRec = (IPacket)Function.Deserialize(new MessageTCP(args.DataReceived));
                var a = Clients.GetUser(args.SocketConnected) != null;
                if (!(PacketRec is Login))
                    if(!CheckTokenValidity((Packet)PacketRec, args.SocketConnected))
                        return;
            }
            catch { return; }

           

            if (PacketRec is Disconnect)
                DisconnectSocket(args.SocketConnected);

            OnPacketreceived(args.SocketConnected, new PacketEventArgs(PacketRec));
        }
    }

}
