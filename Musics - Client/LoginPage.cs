using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;

namespace Musics___Client
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }


        Client ClientForm = new Client();
        

        private void LoginPage_Load(object sender, EventArgs e)
        {
            ClientForm.Connect();
            ClientForm.LoginInfoReceived += ClientForm_LoginInfoReceived;
            settingsForm.FormClosing += SettingsForm_FormClosing;
        }

        private void ClientForm_LoginInfoReceived(object sender, EventArgs e)
        {
            if (ClientForm.authInfo.IsAccepted)
            {
                ClientForm.Me = RequestedUser;
                ClientForm.Me.rank = ClientForm.authInfo.rankofAuthUser;

                Invoke((MethodInvoker)delegate
                {
                    this.Hide();
                });
                ClientForm.ShowDialog();
                
                
            }
            else
            {
                Invoke((MethodInvoker)delegate
                {
                    UIErrorLogin.Text = "Wrong password !";
                });
                
            }
        }

        User RequestedUser;

        private void UILoginButton_Click(object sender, EventArgs e)
        {
            if(UILogin.Text != null && UIPassword.Text != null)
            {
                RequestedUser = new User(UILogin.Text, UIPassword.Text);
                ClientForm.SendObject(new Login(RequestedUser,false));
            }
            else
            {
                UIErrorLogin.Text = "Please enter your username and password";
            }
        }

        private void UIGoSignin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void UIGoLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void UISigninButton_Click(object sender, EventArgs e)
        {
            if (UIUserNameSign.Text != null && UIPasswordSign.Text != null && UIPasswordSign.Text == UISecondPasswordSign.Text)
            {
                RequestedUser = new User(UIUserNameSign.Text, UIPasswordSign.Text);
                ClientForm.SendObject(new Login(RequestedUser, true));
            }
            else
            {
                UIErrorSignin.Text = "Please enter your username and password";
            }
        }

        private void UILogin_TextChanged(object sender, EventArgs e)
        {
            UIErrorLogin.Text = "";
        }

        private void UIPassword_TextChanged(object sender, EventArgs e)
        {
            UIErrorLogin.Text = "";
        }

        private void UIUserNameSign_TextChanged(object sender, EventArgs e)
        {
            UIErrorLogin.Text = "";
        }

        private void UIPasswordSign_TextChanged(object sender, EventArgs e)
        {
            UIErrorLogin.Text = "";
        }

        private void UISecondPasswordSign_TextChanged(object sender, EventArgs e)
        {
            UIErrorLogin.Text = "";
        }
        Settings settingsForm = new Settings();

        private void UISettings_Click(object sender, EventArgs e)
        {   
            settingsForm.ShowDialog();
            
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClientForm = new Client
            {
                ip = settingsForm.result
            };
            Properties.Settings.Default.ServerIp = settingsForm.result.ToString();
            Properties.Settings.Default.Save();
            ClientForm.Connect();
            ClientForm.LoginInfoReceived += ClientForm_LoginInfoReceived;
        }
    }
}
