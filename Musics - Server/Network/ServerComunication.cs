using System;
using System.Net.Sockets;

namespace Musics___Server.Network
{
    public class ServerComunication : ServerSetup
    {
        public delegate void SocketConnectedHandler(object sender, SocketConnectedEventArgs args);
        public event SocketConnectedHandler SocketConnected;

        public delegate void DataReceivedHandler(object sender, DataReceivedFromSocketArgs args);
        public event DataReceivedHandler DataReceived;

        public delegate void SocketDisconnectedHandler(object sender, SocketConnectedEventArgs args);
        public event SocketDisconnectedHandler SocketDisconnected;

        public void BeginAcceptConnection()
        {
            this.Socket.BeginAccept(AcceptCallback, null);
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            Socket socket = this.Socket.EndAccept(ar);
            OnSocketConnected(new SocketConnectedEventArgs(socket));
            socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.Partial, ReceiveCallback, socket);
            BeginAcceptConnection();
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            Socket current = (Socket)ar.AsyncState;
            int Datalength;
            try
            {
                Datalength = current.EndReceive(ar);
            }
            catch
            {
                OnSocketDisconnected(current, new SocketConnectedEventArgs(current));
                return;
            }

            byte[] recBuf = new byte[Datalength];
            Array.Copy(buffer, recBuf, Datalength);
            OnDataReceived(new DataReceivedFromSocketArgs(current, buffer));
            current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.Partial, ReceiveCallback, current);
        }
        public void OnSocketConnected(SocketConnectedEventArgs args)
            => SocketConnected?.Invoke(null, args);
        public void OnDataReceived(DataReceivedFromSocketArgs args)
            => DataReceived?.Invoke(null, args);
        public void OnSocketDisconnected(object sender,SocketConnectedEventArgs args)
            => SocketDisconnected?.Invoke(sender, args);
    }
}
