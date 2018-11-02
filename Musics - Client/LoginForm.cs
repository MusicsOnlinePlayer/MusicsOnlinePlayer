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
            var ClientForm = new Client();
            ClientForm.ShowDialog();
        }

        /// <summary>
        /// Close current control in this correct thread.
        /// </summary>
        private void ThreadSafeClose() => Invoke((MethodInvoker)delegate { Hide(); });


    }
}
