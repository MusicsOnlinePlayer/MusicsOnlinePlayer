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

        private void LoginControl_LoginSucces() =>  Invoke((MethodInvoker)delegate { Close(); });

        private void LoginControl_LoginFailed() => MessageBox.Show("incorrect Login");
    }
}
