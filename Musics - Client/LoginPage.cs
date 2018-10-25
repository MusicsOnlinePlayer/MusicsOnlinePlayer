using ControlLibrary.Network;
using Musics___Client.AppSettings;
using System;
using System.Net;
using System.Windows.Forms;
using Utility.Network.Dialog.Authentification;
using Utility.Network.Users;

namespace Musics___Client
{
    public partial class LoginPage : Form
    {
        readonly Settings settingsForm = new Settings();

        public LoginPage()
        {
            InitializeComponent();
          
            NetworkClient.ip = IPAddress.Parse(AppSettings.ApplicationSettings.Get().ServerIp);

            ApplicationSettings.Setup();
        }

        Client ClientForm = new Client();
        
        private void LoginPage_Load(object sender, EventArgs e)
        {
            NetworkClient.ip = IPAddress.Parse(AppSettings.ApplicationSettings.Get().ServerIp);
            NetworkClient.Connect();
            ClientForm.LoginInfoReceived += ClientForm_LoginInfoReceived;
            settingsForm.FormClosing += SettingsForm_FormClosing;
        }

        private void ClientForm_LoginInfoReceived(object sender, EventArgs e)
        {
            if (ClientForm.authInfo.IsAccepted)
            {
                ClientForm.Me = RequestedUser;
                ClientForm.Me.Rank = ClientForm.authInfo.RankofAuthUser;

                Invoke((MethodInvoker)delegate
                {
                    Hide();
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
                NetworkClient.Connect();
               // RequestedUser = new User(UILogin.Text, UIPassword.Text);
                NetworkClient.SendObject(new Login(RequestedUser,false));
            }
            else
            {
                UIErrorLogin.Text = "Please enter your username and password";
            }
        }

        void UIGoSignin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        void UIGoLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void UISigninButton_Click(object sender, EventArgs e)
        {
            if (UIUserNameSign.Text != null && UIPasswordSign.Text != null && UIPasswordSign.Text == UISecondPasswordSign.Text)
            {
               //RequestedUser = new User(UIUserNameSign.Text, UIPasswordSign.Text);
                NetworkClient.SendObject(new Login(RequestedUser, true));
            }
            else
            {
                UIErrorSignin.Text = "Please enter your username and password";
            }
        }

        void UILogin_TextChanged(object sender, EventArgs e)
        {
            UIErrorLogin.Text = "";
        }

        void UIPassword_TextChanged(object sender, EventArgs e)
        {
            UIErrorLogin.Text = "";
        }

        void UIUserNameSign_TextChanged(object sender, EventArgs e)
        {
            UIErrorLogin.Text = "";
        }

        void UIPasswordSign_TextChanged(object sender, EventArgs e)
        {
            UIErrorLogin.Text = "";
        }

        void UISecondPasswordSign_TextChanged(object sender, EventArgs e)
        {
            UIErrorLogin.Text = "";
        } 

        void UISettings_Click(object sender, EventArgs e)
        {   
            settingsForm.ShowDialog();            
        }

        void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
         //   ClientForm = new Client();
        /*    NetworkClient.ip = settingsForm.result;
             ApplicationSettings.Save(new AppSettings.Settings(null, null, settingsForm.result.ToString()));*/
            NetworkClient.Connect();
          //  ClientForm.LoginInfoReceived += ClientForm_LoginInfoReceived;
        }

        [Obsolete]
        private void UIPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (UILogin.Text != null && UIPassword.Text != null)
                {
                    NetworkClient.Connect();
                  //  RequestedUser = new User(UILogin.Text, UIPassword.Text);
                    NetworkClient.SendObject(new Login(RequestedUser, false));
                }
                else
                {
                    UIErrorLogin.Text = "Please enter your username and password";
                }
            }
        }
    }
}
