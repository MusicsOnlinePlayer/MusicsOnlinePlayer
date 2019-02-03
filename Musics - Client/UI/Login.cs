using System;
using Utility.Network.Users;
using System.Windows.Forms;
using Musics___Client.API.Events;

namespace Musics___Client.UI
{
    public partial class Login : UserControl
    {
        public event EventHandler<LoginControlEventArgs> LoginCompleted;
        public virtual void OnLoginCompleted(object sender, LoginControlEventArgs e)
            => LoginCompleted?.Invoke(sender, e);

        public Login()
        {
            InitializeComponent();
        }

        private void UILoginButton_Click(object sender, EventArgs e)
        {
            var uc = new UserCredentials(UILogin.Text, UIPassword.Text);

            if (uc.IsValidCredential)
                OnLoginCompleted(null, new LoginControlEventArgs(new CryptedCredentials(uc)));
            else
                MessageBox.Show("Invalid credentials please retry !");
        }
    }
}
