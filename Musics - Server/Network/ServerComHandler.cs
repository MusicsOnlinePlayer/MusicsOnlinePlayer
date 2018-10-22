using System.Collections.Generic;
using Utility.Network;


namespace Musics___Server.Network
{
    public class ServerComHandler
    {
        public List<ServerClient> _ServersClient { get; private set; }

        public ServerComHandler()
        {
            _ServersClient = new List<ServerClient>();
        }

        public void AddServer(string Ip)
        {
            ServerClient serverClient = new ServerClient();
            serverClient.Connect(Ip);
            serverClient.StartReceive();
            serverClient.ReceivingObject += ServerClient_ReceivingObject;
            _ServersClient.Add(serverClient);            
        }

        private void ServerClient_ReceivingObject(object sender, ReceiveArgs e)
        {
            Program.MyServer.SendData(e.Data, Program.MyServer.Clients.GetSocket(((IPacket)Function.Deserialize(new MessageTCP(e.Data))).SenderUID));
        }

        public void GlobalSend(object obj)
        {
            foreach(var Sc in _ServersClient)
            {
                Sc.Send(obj);
            }
        }
    }
}
