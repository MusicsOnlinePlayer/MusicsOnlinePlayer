using System;
using System.Windows.Forms;
using Musics___Client.API;

namespace Musics___Client.UI
{
    public partial class LoginControl : UserControl
    {
        public event LoginHandler LoginSucces;
        public event LoginHandler LoginFailed;

        public LoginControl()
        {
            InitializeComponent();
        }
        
        private void SignInButton_Click(object sender, EventArgs e)
        {
            LoginServices.Instance.LogIn(credentialControl.User);
        }

        private void LoginControl_Load(object sender, EventArgs e)
        {
            CredentialValidatorBindingSource.DataSource = credentialControl.Validator;
            if (!DesignMode)
            {
                LoginServices.Instance.LoginFailed += LoginServices_LoginFailed;
                LoginServices.Instance.LoginSucces += LoginServices_LoginSucces;
            }
        }

        private void LoginServices_LoginSucces() => LoginSucces?.Invoke();
        private void LoginServices_LoginFailed() => LoginFailed?.Invoke(); 

    }
}
