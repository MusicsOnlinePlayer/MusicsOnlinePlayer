using System;
using Utility.Network;

namespace ControlLibrary.Network
{
    public class PacketEventArgs :EventArgs
    {
        public IPacket Packet { get; set; }

        public PacketEventArgs(IPacket packet)
        {
            Packet = packet;
        }
    }
}
