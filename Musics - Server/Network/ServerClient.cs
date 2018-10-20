using System;
using System.Net.Sockets;
using System.Threading;
using Utility.Network;

namespace Musics___Server.Network
{
    public class ServerClient
    {
        public volatile Socket _ServerClientSocket;
        public Thread ReceivingThread { get; private set; }
        private byte[] recBuffer;

        public event EventHandler<ReceiveArgs> ReceivingObject;

        public ServerClient()
        {
            _ServerClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public bool Connect(string IpAddress)
        {
            try
            {
                _ServerClientSocket.Connect(IpAddress, 2003);
            }
            catch { return false; }
            return true;
        }

        public bool Send(object obj)
        {
            try
            {
                var msg = Function.Serialize(obj);
                _ServerClientSocket.Send(msg.Data);
                return true;
            }
            catch { return false; }
        }

        public void StartReceive()
        {
            ReceivingThread = new Thread(new ThreadStart(Receive));
        }

        public void Receive()
        {
            try
            {
                _ServerClientSocket.BeginReceive(recBuffer, 0, 100000000, SocketFlags.Partial,
                   new AsyncCallback(ReceiveCallback), null);
            }
            catch
            {
                throw new NotSupportedException("Start Receive Exception At Network/ServerClient");
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                _ServerClientSocket.EndReceive(ar);
            }
            catch
            {
                throw new NotSupportedException("End Receive Exception At Network/ServerClient");
            }

            OnReceivingObject(new ReceiveArgs(recBuffer));

            recBuffer = new byte[100000000];

            try
            {
                _ServerClientSocket.BeginReceive(recBuffer, 0, 100000000, SocketFlags.Partial,
                   new AsyncCallback(ReceiveCallback), null);
            }
            catch
            {
                throw new NotSupportedException("Start Receive Exception At Network/ServerClient");
            }
        }

        protected virtual void OnReceivingObject(ReceiveArgs e)
        {
            ReceivingObject?.Invoke(this, e);
        }
    }
}
