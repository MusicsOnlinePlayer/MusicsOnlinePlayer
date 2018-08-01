using System;

namespace Utility.Network
{
    [Serializable]
    public class MessageTCP : Function
    {
        public byte[] Data { get; set; }
        public MessageTCP() { }
        public MessageTCP(byte[] bytes)
        {
            Data = bytes;
        }
    }
}
