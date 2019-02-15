using Musics___Client.API.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Network.Server;
using Utility.Network;
using Utility.Network.Dialog.Authentification;
using Utility.Network.Tracker.Identity;
using Utility.Network.Users;
using Utility.Network.Tracker;
using System.Net;

namespace Musics___Client.API.Tracker
{
    public class ServerManagerService
    {
        static private readonly Lazy<ServerManagerService> instance = new Lazy<ServerManagerService>(() => new ServerManagerService());
        public static ServerManagerService Instance { get => instance.Value; }

        public List<ServerClient> ServerClients = new List<ServerClient>();

        public CryptedCredentials Me { get; set; }

        public event EventHandler<ServerAddedEventArgs> ServerAdded;
        public virtual void OnServerAdded(object sender, ServerAddedEventArgs e)
            => ServerAdded?.Invoke(sender, e);

        public event EventHandler<PacketEventArgs> PacketReceived;

        public event EventHandler<ServerAddedEventArgs> ServerDisconnected;
        public virtual void OnServerDisconnected(object sender, ServerAddedEventArgs e)
            => ServerDisconnected?.Invoke(sender, e);

        public void AddServer(ServerIdentity si,TrackerIdentity provider)
        {
            if (ServerClients.Exists(x => x.ServerIdentity.IPEndPoint.ToString() == si.IPEndPoint.ToString()))
                return;
            ServerClient serverClient = new ServerClient();
            serverClient.Provider = provider;
            serverClient.Disconnected += ServerClient_Disconnected;
            serverClient.Packetreceived += ServerClient_Packetreceived;
            if (!serverClient.Connect(si))
                return;
            
            serverClient.Send(Function.Serialize(new Login(Me, true)).Data);
            ServerClients.Add(serverClient);

            OnServerAdded(serverClient, new ServerAddedEventArgs(si, provider));
        }

        public void AddMultipleServer(ServerIdentity[] serverIdentities,TrackerIdentity provider)
        {
            foreach (var si in serverIdentities)
                AddServer(si,provider);
        }

        private void ServerClient_Packetreceived(object sender, PacketEventArgs a)
        {
            PacketReceived?.Invoke(sender, new PacketEventArgs(a.Packet, a.Sender));
        }

        private void ServerClient_Disconnected(object sender, EventArgs e)
        {
            var sv = ServerClients.Where(x => x.GetConnectedEndPoint() == ((IClient)sender).GetConnectedEndPoint()).FirstOrDefault();
            OnServerDisconnected(sender, new ServerAddedEventArgs(sv.ServerIdentity, sv.Provider));
            ServerClients.Remove(sv);
        }

        public void SendObject(IPacket packet)
        {
            foreach (var si in ServerClients)
                si.Send(Function.Serialize(packet).Data);
        }

        public void SendToServer(IPacket packet,ServerIdentity serverIdentity)
        {
            ServerClients.Where(x => x.ServerIdentity.IPEndPoint.ToString() == serverIdentity.IPEndPoint.ToString()).FirstOrDefault().Send(Function.Serialize(packet).Data);
        }

        public bool TryGetServerIdentityByEndPoint(IPEndPoint ip, out ServerIdentity serverIdentity)
        {
            serverIdentity = ServerClients.Where(x => x.GetConnectedEndPoint().ToString() == ip.ToString()).First().ServerIdentity;

            return serverIdentity != null;
        }
    }
}
