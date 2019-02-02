using Musics___Client.API.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utility.Network;
using Utility.Network.Tracker;
using Utility.Network.Tracker.Identity;
using Utility.Network.Tracker.Requests;

namespace Musics___Client.API.Tracker
{
    public class TrackersClientService
    {
        static private readonly Lazy<TrackersClientService> instance = new Lazy<TrackersClientService>(() => new TrackersClientService());
        public static TrackersClientService Instance { get => instance.Value; }

        private List<TrackerClientService> TrackersSocket = new List<TrackerClientService>();

        public event EventHandler Registered;
        public virtual void OnRegister(object sender, EventArgs e)
            => Registered?.Invoke(sender, e);

        public event EventHandler ClientDisconnected;
        public virtual void OnDisconnection(object sender, EventArgs e)
            => ClientDisconnected?.Invoke(sender, e);

        public event EventHandler<ServersReceivedFromTrackerEventArgs> ServersReceived;
        public virtual void OnServersReceived(object sender, ServersReceivedFromTrackerEventArgs serversReceivedFromTrackerEventArgs)
            => ServersReceived.Invoke(sender, serversReceivedFromTrackerEventArgs);

        public void Init()
        {
            TrackerXml.Setup();
            var a = TrackerXml.GetServers();
            foreach (var t in a)
                AddTracker(t);
        }

        public void AddTracker(TrackerIdentity trackerIdentity)
        {
            TrackerClientService cs = new TrackerClientService();
            cs.Packetreceived += Cs_Packetreceived;
            cs.Disconnected += Cs_Disconnected;
            try {
                if (!cs.Connect(trackerIdentity)) return;
            }
            catch
            {
                throw new Exception();
            }
            
            //while (!cs.IsConnected()) { }
            var r = new Register()
            {
                Identity = new ClientIdentity()
            };
            cs.Send(Function.Serialize(r).Data);
            TrackersSocket.Add(cs);
        }

        private void Cs_Disconnected(object sender, EventArgs e)
        {
            OnDisconnection(sender, new EventArgs());
        }

        private void Cs_Packetreceived(object sender, Utility.Network.Server.PacketEventArgs a)
        {
            if (a.Packet is TrackerRequest)
            {
                if (a.Packet is RegisterAck)
                {
                    TrackerXml.AddServerToXml(new TrackerIdentity(a.Sender.RemoteEndPoint as IPEndPoint));
                    OnRegister(a.Sender.RemoteEndPoint, new EventArgs());
                    a.Sender.Send(Function.Serialize(new ServerRequest()).Data);
                }

                if(a.Packet is ServerRequestAnswer)
                {
                    ServerRequestAnswer serverRequestAnswer = a.Packet as ServerRequestAnswer;
                    OnServersReceived(sender, new ServersReceivedFromTrackerEventArgs(serverRequestAnswer.ServerIdentities, TrackersSocket.Where(x => x.ConnectionEndPoint.ToString() == ((IPEndPoint)a.Sender.RemoteEndPoint).ToString()).First().Trackeridentity));
                }
            }
        }
       

        public List<TrackerIdentity> RetreiveActiveTrackers()
            => TrackersSocket.Select(t => t.Trackeridentity).ToList();
    }
}
