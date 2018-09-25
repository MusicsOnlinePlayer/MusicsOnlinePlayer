using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musics___Server.Network
{
    public class ReceiveArgs : EventArgs
    {
        public byte[] Data { get; set; }

        public ReceiveArgs(byte[] data)
        {
            Data = data;
        }
    }
}
