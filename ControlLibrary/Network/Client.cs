using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Utility.Network;

namespace ControlLibrary.Network
{
    public static class NetworkClient
    {
        public static Socket _clientSocket { get; set; }
        public static IPAddress ip = IPAddress.Loopback;

        public static Thread recevoir;

        public static Token MyToken;

        private static readonly int Bufferlgth = 100000000;

        static byte[] recbuffer = new byte[Bufferlgth];

      //  public static EventHandler<PacketEventArgs> PacketReceived = delegate { };

        public delegate void PacketReceivedEvent(object sender, PacketEventArgs a);
        public delegate void PacketReceivedHandler(object sender, PacketEventArgs a);
        public static event PacketReceivedHandler Packetreceived;
        public static void Connect()
        {
            if (IPAddress.TryParse(AppSettings.ApplicationSettings.Get().ServerIp, out IPAddress iPAddress))
            {
                IPEndPoint ip = new IPEndPoint(iPAddress, 2003);
                try
                {
                    _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                    {
                        SendTimeout = 600000,
                        ReceiveTimeout = 600000
                    };
                    _clientSocket.BeginConnect(ip, new AsyncCallback(ConnectCallBack), null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void ConnectCallBack(IAsyncResult ar)
        {
            try
            {
                _clientSocket.EndConnect(ar);

                recevoir = new Thread(new ThreadStart(Receive));
                recevoir.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Receive()
        {
            _clientSocket.BeginReceive(recbuffer, 0, Bufferlgth, SocketFlags.Partial,
                    new AsyncCallback(ReceiveCallback), null);
        }

        private static void ReceiveCallback(IAsyncResult AR)
        {
            try
            {
                _clientSocket.EndReceive(AR);
                // Array.Resize(ref recbuffer, ren + 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            OnPacketReceived(new PacketEventArgs((IPacket)Function.Deserialize(new MessageTCP(recbuffer))));
        
            recbuffer = new byte[Bufferlgth];

            try
            {
                _clientSocket.BeginReceive(recbuffer, 0, recbuffer.Length, SocketFlags.Partial,
                new AsyncCallback(ReceiveCallback), null);
            }
            catch { }
        }

        public static void SendObject(object obj, bool UseToken = true)
        {
            Packet ObjWithToken = (obj as Packet);
            ObjWithToken.Token = UseToken ? MyToken : null;

            var msg = Function.Serialize(obj);
            try
            {
                _clientSocket.BeginSend(msg.Data, 0, msg.Data.Length, SocketFlags.Partial, new AsyncCallback(SendCallback), null);
            }
            catch
            {
                MessageBox.Show("Can't send message. Check your connection", "Connection exception");
            }
        }

        public static void CloseSocket()
        {
            _clientSocket.Shutdown(SocketShutdown.Both);
            _clientSocket.Close(1000);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                _clientSocket.EndSend(ar);
            }
            catch { }
        }

        public static void OnPacketReceived(PacketEventArgs e)
           => Packetreceived?.Invoke(null, e);
    }
}
