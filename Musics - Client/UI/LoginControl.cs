using System;
using System.Windows.Forms;
using ControlLibrary.Network;
using Musics___Client.API;

namespace Musics___Client.UI
{
    public partial class LoginControl : UserControl
    {
        public event LoginHandler LoginSucces;
        public event LoginHandler LoginFailed;

        public Settings SettingsForm;

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
            InitControl();
        }

        public void InitControl()
        {
            ShowStatus(LoginServices.Instance.Connect());
            CredentialValidatorBindingSource.DataSource = credentialControl.Validator;
            if (!DesignMode)
            {
                LoginServices.Instance.LoginFailed += LoginServices_LoginFailed;
                LoginServices.Instance.LoginSucces += LoginServices_LoginSucces;
            }
        }

        public void ShowStatus(bool st)
        {
            if (st)
                ShowConnected();
            else
                ShowDisconnected();
        }

        public void ShowConnected()
        {
            UIClientStatus.Text = "Connected";
            UIClientStatus.ForeColor = System.Drawing.Color.Green;
        }

        public void ShowDisconnected()
        {
            UIClientStatus.Text = "Not Connected !";
            UIClientStatus.ForeColor = System.Drawing.Color.Red;
        }

        private void LoginServices_LoginSucces() => LoginSucces?.Invoke();
        private void LoginServices_LoginFailed() => LoginFailed?.Invoke();

        private void UIButtonSettings_Click(object sender, EventArgs e)
        {
            SettingsForm = new Settings();
            SettingsForm.FormClosed += SettingsForm_FormClosing;
            SettingsForm.ShowDialog();
        }

        private void SettingsForm_FormClosing(object sender, FormClosedEventArgs e)
        {
            InitControl();
        }
    }
}
