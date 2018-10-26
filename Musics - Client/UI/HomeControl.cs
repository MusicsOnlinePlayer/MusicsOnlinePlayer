using System;
using static Musics___Client.Client;
using System.Windows.Forms;
using ControlLibrary.Network;
using Utility.Network.Dialog;
using Utility.Musics;

namespace Musics___Client.UI
{
    public partial class HomeControl : UserControl
    {
        public HomeControl()
        {
            InitializeComponent();
        }

        private void UIHomeSearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {               
                Tabs.SelectedIndex = 1;
                if (UIHomeAlbum.Checked)
                {
                    NetworkClient.SendObject(new Request(UIHomeSearchBar.Text, ElementType.Album));
                    return;
                }
                if (UIHomeArtist.Checked)
                {
                    NetworkClient.SendObject(new Request(UIHomeSearchBar.Text, ElementType.Author));
                    return;
                }
                if (UIHomeMusic.Checked)
                {
                    NetworkClient.SendObject(new Request(UIHomeSearchBar.Text, ElementType.Music));
                    return;
                }
                if (UIHomePlaylist.Checked)
                {
                    NetworkClient.SendObject(new Request(UIHomeSearchBar.Text, ElementType.Playlist));
                    return;
                }
            }
        }
    }
}
