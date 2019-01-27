using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utility.Network;
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

        public void Init()
        {
            var a = TrackerXml.GetServers();
            foreach (var t in a)
                AddTracker(t);
        }

        public void AddTracker(TrackerIdentity trackerIdentity)
        {
            TrackerClientService cs = new TrackerClientService();
            cs.Packetreceived += Cs_Packetreceived;
            cs.Connect(trackerIdentity);
            while (!cs.IsConnected()) { }
            var r = new Register()
            {
                Identity = new ClientIdentity()
            };
            cs.Send(Function.Serialize(r).Data);
            TrackersSocket.Add(cs);
        }

        private void Cs_Packetreceived(object sender, Utility.Network.Server.PacketEventArgs a)
        {
            if (a.Packet is TrackerRequest)
            {
                if (a.Packet is RegisterAck)
                {
                    TrackerXml.AddServerToXml(new TrackerIdentity(a.Sender.RemoteEndPoint as IPEndPoint));
                    OnRegister(a.Sender.RemoteEndPoint, new EventArgs());
                }
            }
        }

        public List<TrackerIdentity> RetreiveActiveTrackers()
            => TrackersSocket.Select(t => t.Trackeridentity).ToList();
    }
}
