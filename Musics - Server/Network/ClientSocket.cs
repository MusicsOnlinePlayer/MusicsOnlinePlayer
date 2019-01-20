using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.Network;
using Utility.Network.Server;
using Utility.Network.Tracker.Identity;

namespace Musics___Server.Network
{
    public class ClientSocket
    {
        public Socket _Socket { get; set; }

        public delegate void PacketReceivedEvent(object sender, PacketEventArgs a);
        public delegate void PacketReceivedHandler(object sender, PacketEventArgs a);
        public event PacketReceivedHandler Packetreceived;

        public Thread recevoir;

        public void Connect(TrackerIdentity trackeridentity)
        {
            try
            {
                _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _Socket.BeginConnect(trackeridentity.IPEndPoint, new AsyncCallback(ConnectCallback), _Socket);
            }
            catch(Exception ex) {
                Program.MyServer.Log.Critical(ex.Message);
                throw ex;
            }
        }

        private static int Bufferlgth = 10000;
        byte[] recbuffer = new byte[Bufferlgth];

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                _Socket = (Socket)ar.AsyncState;
                _Socket.EndConnect(ar);
                recevoir = new Thread(new ThreadStart(Receive));
                recevoir.Start();
                
            }
            catch (Exception ex)
            {
                Program.MyServer.Log.Critical(ex.Message);
                throw ex;
            }
        }

        public void Receive()
        {
            _Socket.BeginReceive(recbuffer, 0, Bufferlgth, SocketFlags.Partial,
                    new AsyncCallback(ReceiveCallback), _Socket);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                _Socket.EndReceive(ar);
            }
            catch
            {

            }

            OnPacketReceived(new PacketEventArgs((IPacket)Function.Deserialize(new MessageTCP(recbuffer)),_Socket));

            try
            {
                _Socket.BeginReceive(recbuffer, 0, recbuffer.Length, SocketFlags.Partial,
                new AsyncCallback(ReceiveCallback), _Socket);
            }
            catch(Exception ex) {
                Program.MyServer.Log.Critical(ex.Message);
                throw ex;
            }
        }

        public void OnPacketReceived(PacketEventArgs e)
           => Packetreceived?.Invoke(null, e);
    }
}
