using System;
using System.Collections.Generic;
using Utility.Network;
using Utility.Network.Dialog.Rating;

namespace Musics___Server.Network
{
    public class ServerComHandler
    {
        public List<ServerClient> _ServersClient { get; private set; }

        public ServerComHandler()
        {            
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
