using System;
using System.Windows.Forms;
using Utility.Network.Dialog.Authentification;
using ControlLibrary.Network;

namespace Musics___Client.UI
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
            CredentialValidatorBindingSource.DataSource = credentialControl.Validator;
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
          
                NetworkClient.SendObject(new Login(credentialControl.User, false));
           
        }
    }
}
