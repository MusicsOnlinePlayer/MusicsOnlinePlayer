using System.Windows.Forms;

using Utility.Network.Users;

namespace Musics___Client.UI
{
    public partial class CredentialControl : UserControl
    {
        public CredentialControl()
        {
            InitializeComponent();
            CredentialBindingSource.DataSource = new UserCredentials("", "");
        }

        public User User => new User(CredentialBindingSource.DataSource as ICredentials);
        public bool IsValidCredential => (CredentialBindingSource.DataSource as ICredentialValidator).IsValidCredential;
    }
}
