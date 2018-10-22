using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace ControlLibrary.Network
{
    static class Network
    {
        private static Thread recevoir;

        public static Socket _clientSocket { get; set; }

        public static void Connect(IPAddress iPAddress)
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
    }
}
