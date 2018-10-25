using System;

namespace Utility.Network
{
    public interface IPacket
    {
        string SenderUID { get; set; }
        bool IsFromServer { get; set; }
    }

    [Serializable]
    public abstract class Packet : IPacket
    {
        public string SenderUID { get; set; }
        public bool IsFromServer { get; set; }
    }
}
