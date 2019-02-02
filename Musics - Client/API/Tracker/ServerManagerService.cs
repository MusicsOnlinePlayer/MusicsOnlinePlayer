using Musics___Client.API.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Network.Tracker.Identity;

namespace Musics___Client.API.Tracker
{
    public class ServerManagerService
    {
        static private readonly Lazy<ServerManagerService> instance = new Lazy<ServerManagerService>(() => new ServerManagerService());
        public static ServerManagerService Instance { get => instance.Value; }

        public List<ServerClient> ServerClients = new List<ServerClient>();

        public event EventHandler<ServerAddedEventArgs> ServerAdded;
        public virtual void OnServerAdded(object sender, ServerAddedEventArgs e)
            => ServerAdded?.Invoke(sender, e);

        public void AddServer(ServerIdentity si,TrackerIdentity provider)
        {
            ServerClient serverClient = new ServerClient();
            serverClient.Provider = provider;
            serverClient.Disconnected += ServerClient_Disconnected;
            serverClient.Packetreceived += ServerClient_Packetreceived;
            if (!serverClient.Connect(si))
                return;
            OnServerAdded(serverClient, new ServerAddedEventArgs(si, provider));

            ServerClients.Add(serverClient);
        }

        public void AddMultipleServer(ServerIdentity[] serverIdentities,TrackerIdentity provider)
        {
            foreach (var si in serverIdentities)
                AddServer(si,provider);
        }

        private void ServerClient_Packetreceived(object sender, Utility.Network.Server.PacketEventArgs a)
        {
            throw new NotImplementedException();
        }

        private void ServerClient_Disconnected(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
