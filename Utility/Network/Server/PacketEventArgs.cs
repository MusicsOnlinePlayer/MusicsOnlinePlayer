using System;
using System.Net.Sockets;
using Utility.Network;
using Utility.Network.Tracker.Identity;

namespace Utility.Network.Server
{
    public class PacketEventArgs : EventArgs
    {
        public IPacket Packet { get; set; }

        public Socket Sender { get; set; }

        public TrackerIdentity TrackerIdentity {get;set;}

        public PacketEventArgs(IPacket packet)
        {
            Packet = packet;
        }

        public PacketEventArgs(IPacket packet, Socket sender)
        {
            Packet = packet;
            Sender = sender;
        }

        public PacketEventArgs(IPacket packet, Socket sender, TrackerIdentity trackerIdentity)
        {
            Packet = packet;
            Sender = sender;
            TrackerIdentity = trackerIdentity;
        }
    }
}
