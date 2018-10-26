using System;
using System.Windows.Forms;
using ControlLibrary.Network;
using Utility.Network.Dialog;
using Utility.Musics;
using Musics___Client.API.Events;

namespace Musics___Client.UI
{
    public partial class HomeControl : UserControl
    {
        public HomeControl()
        {
            InitializeComponent();
        }

        public event EventHandler<SearchEventArgs> SearchEvent;

        protected virtual void OnSearchEvent(SearchEventArgs e) =>  SearchEvent?.Invoke(this, e);
        
        private void UIHomeSearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {               
                if (UIHomeAlbum.Checked)
                {
                    OnSearchEvent(new SearchEventArgs(UIHomeSearchBar.Text, ElementType.Album));
                    return;
                }
                if (UIHomeArtist.Checked)
                {
                    OnSearchEvent(new SearchEventArgs(UIHomeSearchBar.Text, ElementType.Author));
                    return;
                }
                if (UIHomeMusic.Checked)
                {
                    OnSearchEvent(new SearchEventArgs(UIHomeSearchBar.Text, ElementType.Music));
                    return;
                }
                if (UIHomePlaylist.Checked)
                {
                    OnSearchEvent(new SearchEventArgs(UIHomeSearchBar.Text, ElementType.Playlist));
                    return;
                }
            }
        }
    }
}
