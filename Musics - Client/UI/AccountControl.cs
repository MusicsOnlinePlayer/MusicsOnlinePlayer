using Musics___Client.API.Events;
using System;
using System.Windows.Forms;
using Utility.Network.Users;

namespace Musics___Client.UI
{
    public partial class AccountControl : UserControl
    {
        public AccountControl()
        {
            InitializeComponent();
        }

        public event EventHandler<EditAccountEventArgs> EditAccountDone;
        protected virtual void OnEditAccountDone(EditAccountEventArgs e) => EditAccountDone?.Invoke(this, e);


        private void UIAccountEdit_Click(object sender, EventArgs e)
        {
            if (UIEditName != null)
                OnEditAccountDone(new EditAccountEventArgs(UIEditPassword2.Text, UIEditName.Text));
            else
                throw new NotImplementedException();
                OnEditAccountDone(new EditAccountEventArgs(UIEditPassword2.Text));
        }

        private void UIEditName_TextChanged(object sender, EventArgs e)
            => UIAccountEdit.Enabled = UIEditName.Text == null ? true : true;


        private void UIEditPassword1_TextChanged(object sender, EventArgs e)
            => UIAccountEdit.Enabled = CheckSyntax();

        private void UIEditPassword2_TextChanged(object sender, EventArgs e)
            => UIAccountEdit.Enabled = CheckSyntax();

        public bool CheckSyntax()
        {
            return (UIEditPassword1.Text != null && UIEditPassword1.Text == UIEditPassword2.Text);
        }

        public void EditAccountDetails(User Me)
        {
            UIAccountName.Text = Me.Name;
            UIAccountId.Text = Me.UID;
            UIRank.Text = Me.Rank.ToString();
        }
            
        public void TellError(string Error)
            => Invoke((MethodInvoker)delegate {  UIEditError.Text = "Username use by another person !";});
    }
}
