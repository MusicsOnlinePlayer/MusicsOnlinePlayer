using ControlLibrary.Network;
using System.Windows.Forms;

namespace Musics___Client
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            LoginControl.LoginFailed += LoginControl_LoginFailed;
            LoginControl.LoginSucces += LoginControl_LoginSucces;
        }

        /// <summary>
        /// Event fired when login failed
        /// </summary>
        private void LoginControl_LoginFailed() => MessageBox.Show("Invalid Login/password");

        Client ClientForm;

        /// <summary>
        /// Event fired when login success.
        /// </summary>
        private void LoginControl_LoginSucces()
        {
            //     NetworkClient.CloseSocket();
            /*    new Thread(delegate ()
                {
                    Application.Run(new Client());
                }).Start();*/

            ThreadSafeClose();

            NetworkClient.NetworkError += NetworkClient_NetworkError;
            //Invoke((MethodInvoker)delegate
            //{
                ClientForm = new Client();
                ClientForm.ShowDialog();
            //});
        }

        private void NetworkClient_NetworkError(object sender, NetworkEventArgs a)
        {     
            Invoke((MethodInvoker)delegate { ClientForm.Close();  ShowDialog(); });
        }

        /// <summary>
        /// Close current control in this correct thread.
        /// </summary>
        private void ThreadSafeClose() => Invoke((MethodInvoker)delegate { Hide(); });


    }
}
