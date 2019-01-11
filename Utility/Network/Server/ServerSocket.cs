using System;
using System.Net;
using System.Net.Sockets;

namespace Utility.Network.Server
{
    public abstract class ServerSocket
    {
        protected Socket Socket;
        protected int BUFFER_SIZE;
        protected int PORT;
        protected byte[] buffer;
        public abstract void SetupSocket(int PORT, int BUFFER_SIZE);
        public abstract void TryBindSocket(IPEndPoint IpAddress);
        public abstract void TryListen();
    }

    public class ServerSetup : ServerSocket
    {
        public override void SetupSocket(int PORT, int BUFFER_SIZE)
        {
            this.Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                SendBufferSize = BUFFER_SIZE
            };
            this.PORT = PORT;
            this.BUFFER_SIZE = BUFFER_SIZE;
            this.buffer = new byte[BUFFER_SIZE];

        }

        public override void TryBindSocket(IPEndPoint IpAddress)
        {
            try
            {
                this.Socket.Bind(IpAddress);
            }
            catch (SocketException SckEx)
            {
                switch (SckEx.SocketErrorCode)
                {
                    case SocketError.InvalidArgument:
                        throw new ServerSocketException(ServerSocketErrors.AddressAlreadyTaken);
                }
            }
        }


        public override void TryListen()
        {
            try
            {
                this.Socket.Listen(0);
            }
            catch (SocketException SckEx)
            {
                switch (SckEx.SocketErrorCode)
                {
                    case SocketError.ConnectionAborted:
                    case SocketError.ConnectionRefused:
                    case SocketError.ConnectionReset:
                        throw new ServerSocketException(ServerSocketErrors.ConnectionStopped);
                }
            }
        }

        public int GetConnectSocketPORT()
            => PORT;
    }

    public enum ServerSocketErrors
    {
        AddressIncorrect,
        AddressAlreadyTaken,
        ConnectionStopped
    }

    public class ServerSocketException : Exception
    {
        public ServerSocketErrors ExceptionType { get; set; }

        public ServerSocketException(ServerSocketErrors exceptionType)
        {
            ExceptionType = exceptionType;
        }
    }
}
