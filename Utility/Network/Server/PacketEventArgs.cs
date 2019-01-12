using System;
using System.Net.Sockets;
using Utility.Network;

namespace Utility.Network.Server
{
    public class PacketEventArgs :EventArgs
    {
        public IPacket Packet { get; set; }

        public Socket Sender { get; set; }

        public PacketEventArgs(IPacket packet)
        {
            Packet = packet;
        }

        public PacketEventArgs(IPacket packet, Socket sender)
        {
            Packet = packet;
            Sender = sender;
        }
    }
}
