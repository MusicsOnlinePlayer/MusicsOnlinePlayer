using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.SignInButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.iCredentialsBindingSource, "IsValidCredential", true));
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            if (credentialControl.IsValidCredential)
            {
                NetworkClient.SendObject(new Login(credentialControl.User, false));
            }
            else
            {
                //   UIErrorLogin.Text = "Please enter your username and password";
            }
        }
    }
}
