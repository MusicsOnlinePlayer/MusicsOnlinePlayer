using System;
using Utility.Network;

namespace Musics___Server.Services.EventsArgs
{
    public class PacketEventArgs : EventArgs
    {
        public IPacket Packet { get; set; }

        public PacketEventArgs(IPacket packet)
        {
            Packet = packet;
        }
    }
}