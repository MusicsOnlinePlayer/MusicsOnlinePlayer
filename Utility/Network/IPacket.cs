using System;
using System.Net.Sockets;

namespace Utility.Network
{
    public interface IPacket
    {
        string SenderUID { get; set; }
        bool IsFromServer { get; set; }
        Token Token { get; set; }
        void Send(Socket socket);
    }

    [Serializable]
    public abstract class Packet : IPacket
    {
        public string SenderUID { get; set; }
        public bool IsFromServer { get; set; }
        public Token Token { get; set; }
        public void Send(Socket socket)
        {
            socket.Send(Function.Serialize(this).Data);
        }
    }
}
