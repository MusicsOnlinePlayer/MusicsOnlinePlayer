using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Utility.Network.Server;

namespace Utility.Network.Tracker
{
    public abstract class SocketClient
    {
        protected Socket _Socket;
        protected int BUFFER_SIZE;
        protected int PORT;
        protected byte[] buffer;
        public abstract Task<bool> Connect(IPEndPoint ip);
        public abstract void SetupSocket(int PORT, int BUFFER_SIZE);
    }

    public class ClientSetup : SocketClient
    {
        public delegate void PacketReceivedEvent(object sender, PacketEventArgs a);
        public delegate void PacketReceivedHandler(object sender, PacketEventArgs a);
        public event PacketReceivedHandler Packetreceived;

        public event EventHandler Disconnected;

        public IPEndPoint ConnectionEndPoint;

        private Thread recevoir;

        public override void SetupSocket(int PORT, int BUFFER_SIZE)
        {
            this._Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                SendBufferSize = BUFFER_SIZE
            };
            this.PORT = PORT;
            this.BUFFER_SIZE = BUFFER_SIZE;
            this.buffer = new byte[BUFFER_SIZE];
        }

        public override Task<bool> Connect(IPEndPoint ip)
        {
            try
            {
                _Socket.Connect(ip);
                ConnectionEndPoint = ip;
                return Task.FromResult(_Socket.Connected);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }


        public void StartReceiving()
        {
            recevoir = new Thread(new ThreadStart(Receive));
            recevoir.Start();
        }

        public void Receive()
        {
            try { 
            _Socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.Partial,
                    new AsyncCallback(ReceiveCallback), _Socket);
            }
            catch
            {
                OnDisconnection(new EventArgs());
                return;
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {

            try
            {
                _Socket.EndReceive(ar);
            }
            catch
            {
                OnDisconnection(new EventArgs());
                return;
            }

            OnPacketReceived(new PacketEventArgs((IPacket)Function.Deserialize(new MessageTCP(buffer)), _Socket));

            try
            {
                _Socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.Partial,
                new AsyncCallback(ReceiveCallback), _Socket);
            }
            catch (Exception ex)
            {
                OnDisconnection(new EventArgs());
                return;
            }
        }

        public void OnPacketReceived(PacketEventArgs e)
               => Packetreceived?.Invoke(null, e);

        public void OnDisconnection(EventArgs e)
            => Disconnected?.Invoke(this, e);

        public bool IsConnected()
            => _Socket.Connected;

        public void Send(byte[] data)
            => _Socket.Send(data);
    }


    public class ClientSocketException : Exception
    {
        public ClientSocketException(string exType)
        {
            ExType = exType;
        }

        public string ExType { get; set; }
        SocketError SocketError { get; set; }

    }

}
