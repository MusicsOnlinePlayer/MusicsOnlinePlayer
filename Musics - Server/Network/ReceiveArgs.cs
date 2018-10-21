using System;

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
