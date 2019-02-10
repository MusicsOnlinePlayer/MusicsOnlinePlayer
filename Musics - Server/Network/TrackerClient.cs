using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Utility.Network;
using Utility.Network.Tracker;
using Utility.Network.Tracker.Identity;
using Utility.Network.Tracker.Requests;

namespace Musics___Server.Network
{
    public class TrackerClient
    {
        public List<ClientSocket> _trackerSockets = new List<ClientSocket>();

        public void AddTracker(TrackerIdentity trackerIdentity)
        {
            Program.MyServer.Log.Info($"Connecting to the tracker {trackerIdentity?.IPEndPoint.Address.ToString()}");
            ClientSocket cs = new ClientSocket();
            cs.Packetreceived += Cs_Packetreceived;
            cs.Connect(trackerIdentity);  
            Program.MyServer.Log.Info("Connected to the tracker");
            while (!cs.IsConnected()) { }
            var r = new Register()
            {
                Identity = new ServerIdentity()
            };
            r.Identity.IPEndPoint = new IPEndPoint(IPAddress.Any, Program.MyServer.ServerComunicationSocket.GetConnectSocketPORT());
            cs.Send(Function.Serialize(r).Data);
            _trackerSockets.Add(cs);
        }

        public bool AddTrackerByString(string ipport)
        {
            string[] splittedIp = ipport.Split(':');
            if (!IPAddress.TryParse(splittedIp.First(), out IPAddress iP)) return false;
            if (!int.TryParse(splittedIp[1], out int i)) return false;
            var si = new TrackerIdentity(new IPEndPoint(iP, i));

            AddTracker(si);
            return true;
        }

        public void Init()
        {
            Program.MyServer.Log.Info("Retreiving trackers IP");
            var a = TrackerXml.GetServers();
            Program.MyServer.Log.Info("Done");
            foreach (var t in a)
            {
                AddTracker(t);
            }
        }

        private void Cs_Packetreceived(object sender, Utility.Network.Server.PacketEventArgs a)
        {
            Program.MyServer.Log.Info($"Receiving from tracker ({a.Sender.RemoteEndPoint.ToString()})");
            if (a.Packet is TrackerRequest)
            {
                if(a.Packet is RegisterAck)
                {
                    Program.MyServer.Log.Info("Succefuly Register to the tracker !");
                    TrackerXml.AddServerToXml(new TrackerIdentity(a.Sender.RemoteEndPoint as IPEndPoint));
                }
            }
        }
    }
}
