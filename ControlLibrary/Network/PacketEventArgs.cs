using System;

namespace ControlLibrary.Network
{
    public class PacketEventArgs :EventArgs
    {
        public object Packet { get; set; }

        public PacketEventArgs(object packet)
        {
            Packet = packet;
        }
    }
}
