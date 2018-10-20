using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
