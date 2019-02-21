using Musics___Client.API.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utility.Network.Tracker.Identity;
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
                OnEditAccountDone(new EditAccountEventArgs(UIEditPassword2.Text,GetSelectedIdentity() ,UIEditName.Text));
            else
                OnEditAccountDone(new EditAccountEventArgs(UIEditPassword2.Text, GetSelectedIdentity()));
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

        public Dictionary<ServerIdentity, User> ServersUsers = new Dictionary<ServerIdentity, User>();

        public void AddServer(ServerIdentity serverIdentity,User user)
        {
            Invoke((MethodInvoker)delegate
            {
                UIServerSelector.Items.Add(serverIdentity.ToString());
                ServersUsers.Add(serverIdentity, user);
            });
        }

        public void RemoveServer(ServerIdentity serverIdentity)
        {
            Invoke((MethodInvoker)delegate
            {

                UIServerSelector.Items.Remove(serverIdentity);
                ServersUsers.Remove(serverIdentity);
            }); 
        }

        public void ModifyUser(User user, ServerIdentity serverIdentity)
        {
            Invoke((MethodInvoker)delegate
            {
                ServersUsers[serverIdentity] = user;
                UpdateAccountDetails();
            });
        }

        private void UIServerSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAccountDetails();
        }

        private void UpdateAccountDetails()
        {
            User SelectedUser = GetSelectedUser();
            UIAccountName.Text = SelectedUser.Name;
            UIRank.Text = SelectedUser.Rank.ToString();
            UIAccountId.Text = SelectedUser.UID;
        }

        private User GetSelectedUser()
        {
            if (UIServerSelector.SelectedItem == null) return null;
            return ServersUsers[GetSelectedIdentity()];
        }

        private ServerIdentity GetSelectedIdentity()
        {
            if (UIServerSelector.SelectedItem == null) return null;
            return ServersUsers.Where(x => x.Key.ToString() == UIServerSelector.SelectedItem.ToString()).SingleOrDefault().Key;
        }
    }
}
