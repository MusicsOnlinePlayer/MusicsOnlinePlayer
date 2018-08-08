using System;
using System.Net;
using System.Windows.Forms;

namespace Musics___Client
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            UISettingsIp.Text = AppSettings.ApplicationSettings.Get().ServerIp;
        }

        public IPAddress result;

        private void UISettingsApply_Click(object sender, EventArgs e)
        {
            if(IPAddress.TryParse(UISettingsIp.Text,out result))
            {
                this.Close();
            }
            else
            {
                UIError.Visible = true;
            }
        }

        private void UISettingsIp_TextChanged(object sender, EventArgs e)
        {
            UIError.Visible = false;
        }
    }
}
