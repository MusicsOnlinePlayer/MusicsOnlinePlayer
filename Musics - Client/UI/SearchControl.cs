using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Musics___Client.API.Events;
using Utility.Musics;

namespace Musics___Client.UI
{
    public partial class SearchControl : UserControl
    {
        public SearchControl()
        {
            InitializeComponent();
        }

        #region Events
        public event EventHandler<SearchEventArgs> SearchEvent;
        protected virtual void OnSearchEvent(SearchEventArgs e) => SearchEvent?.Invoke(this, e);

        public event EventHandler<EventArgs> ClearEvent;
        protected virtual void OnClearEvent(EventArgs e) => ClearEvent?.Invoke(this, e);

        public event EventHandler<EventArgs> UploadEvent;
        protected virtual void OnUploadEvent(EventArgs e) => UploadEvent?.Invoke(this, e);

        public event EventHandler<PlayEventArgs> PlayEvent;
        protected virtual void OnPlayEvent(PlayEventArgs e) => PlayEvent?.Invoke(this, e);

        public event EventHandler<EventArgs> AddPlaylistEvent;
        protected virtual void OnAddPlaylistEvent(EventArgs e) => AddPlaylistEvent?.Invoke(this, e);

        public event EventHandler<RateEventArgs> RateEvent;
        protected virtual void OnRateEvent(RateEventArgs e) => RateEvent?.Invoke(this, e);

        public event EventHandler<PathClickedEventArgs> PathClicked;
        protected virtual void OnPathClicked(PathClickedEventArgs e) => PathClicked?.Invoke(this, e);

        public event EventHandler<EditMusicEventArgs> EditMusic;
        protected virtual void OnEditMusic(EditMusicEventArgs e) => EditMusic?.Invoke(this, e);

        public event EventHandler<PlaylistSavedEventArgs> PlaylistSaved;
        protected virtual void OnPlaylistSaved(PlaylistSavedEventArgs e) => PlaylistSaved?.Invoke(this, e);
        #endregion

        private void UITextboxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (UIRadioAlbum.Checked)
                {
                    OnSearchEvent(new SearchEventArgs(UITextboxSearch.Text, ElementType.Album));
                    return;
                }
                if (UIRadioArtist.Checked)
                {
                    OnSearchEvent(new SearchEventArgs(UITextboxSearch.Text, ElementType.Author));
                    return;
                }
                if (UIRadioMusic.Checked)
                {
                    OnSearchEvent(new SearchEventArgs(UITextboxSearch.Text, ElementType.Music));
                    return;
                }
                if (UIRadioPlaylist.Checked)
                {
                    OnSearchEvent(new SearchEventArgs(UITextboxSearch.Text, ElementType.Playlist));
                    return;
                }
            }
        }

        public IElement selected;
        public List<object> SearchlistboxItems = new List<object>();

        public void ClearSearchListBoxes()
            => Invoke((MethodInvoker)delegate { ClearSearchListBoxesThreadSafe(); });
        
        private void ClearSearchListBoxesThreadSafe()
        {
            UISearchListbox.Items.Clear();
            SearchlistboxItems.Clear();
        }

        public void FillSearchListBoxes(IEnumerable<IElement> elements)
            => Invoke((MethodInvoker)delegate { FillSearchListBoxesThreadSafe(elements);});
        
        private void FillSearchListBoxesThreadSafe(IEnumerable<IElement> elements)
        {
            UISearchListbox.Items.AddRange(elements.Select(a => a.Name).ToArray());
            SearchlistboxItems.AddRange(elements);
        }

        public object GetSelectedItemListBox()
            => UISearchListbox.SelectedItem;

        public object GetSelectedListbox()
            => SearchlistboxItems[UISearchListbox.SelectedIndex];

        private void UIUpload_Click(object sender, EventArgs e)
            => OnUploadEvent(new EventArgs());

        public void EnableUpload(bool enabled)
            => UIUpload.Visible = enabled;
            
        public void SetPlaylistIndex(int Index)
            => UIPlaylist.SelectedIndex = Index;

        public void ClearPlaylist()
            => UIPlaylist.Items.Clear();

        public void AddToPlaylist(string Name)
            => UIPlaylist.Items.Add(Name);

        #region Description
        public void ChangeDescription(IElement element)
        {
            switch (element)
            {
                case Music music: ChangeDescription(music); break;
                case Album album: ChangeDescription(album); break;
                case Author author: ChangeDescription(author); break;
                case Playlist playlist: ChangeDescription(playlist); break;
               // default: throw new InvalidCastException();
            }
        }

        private void ChangeDescription(Playlist playlist)
        {
            UISelectedname.Text = playlist.Name;
            UIselectedartist.Text = playlist.Creator.Name;
            UISelectedRating.Text = $"Rating : {playlist.Rating}";
            UIPathAuthor.Text = string.Empty;
            UIPathAlbum.Text = string.Empty;
            UIPathMusic.Text = string.Empty;
            UIThumbup.Visible = true;

            ClearPlaylist();
            UIPlaylist.Items.AddRange(playlist.musics.Select(x => x.Title).ToArray());
        }

        private void ChangeDescription(Author author)
        {
            UISelectedname.Text = author.Name;
            UIselectedartist.Text = string.Empty;
            UISelectedRating.Text = "Rating : ";

            UIPathAuthor.Text = author.Name;
            UIPathAlbum.Text = string.Empty;
            UIPathMusic.Text = string.Empty;
            UIThumbup.Visible = false;
        }

        private void ChangeDescription(Album album)
        {
            UISelectedname.Text = album.Name;
            UIselectedartist.Text = album.Author.Name;
            UISelectedRating.Text = "Rating : ";
            UISelectedGenres.Text = $"Genres : {string.Join(" ", album.Musics.First().Genre)}";

            UIPathAuthor.Text = album.Author.Name;
            UIPathAlbum.Text = album.Name;
            UIPathMusic.Text = string.Empty;
            UIThumbup.Visible = false;
        }

        private void ChangeDescription(Music music)
        {
            UISelectedname.Text = music.Title;
            UIselectedartist.Text = music.Author.Name;
            UISelectedRating.Text = $"Rating : {music.Rating}";
            UISelectedGenres.Text = $"Genres :  {string.Join(" ", music.Genre)}";
            UIThumbup.Visible = true;

            UIPathAuthor.Text = music.Author.Name;
            UIPathAlbum.Text = music.Album.Name;
            UIPathMusic.Text = music.Title;
        }

        #endregion

        private void UIPlayBis_Click(object sender, EventArgs e)
            => OnPlayEvent(new PlayEventArgs(selected));

        private void UISearchListbox_DoubleClick(object sender, EventArgs e)
        {
            if(GetSelectedItemListBox() != null)
            {
                switch (GetSelectedListbox())
                {
                    case Author author:
                        ClearSearchListBoxesThreadSafe();
                        FillSearchListBoxesThreadSafe(author.Albums);
                        break;
                    case Album album:
                        ClearSearchListBoxesThreadSafe();
                        FillSearchListBoxesThreadSafe(album.Musics);
                        break;
                    case Music music:
                        OnPlayEvent(new PlayEventArgs(selected));
                        break;
                    //case Playlist playlist:
                    //    uPlayer1.Playlist.Clear();
                    //    uPlayer1.PlaylistIndex = 0;
                    //    UIPlaylist.Items.Clear();
                    //    foreach (var m in (selected as Playlist).musics)
                    //    {
                    //        uPlayer1.Playlist.Add(m);
                    //        UIPlaylist.Items.Add(m.Title);
                    //    }
                    //    NetworkClient.SendObject(new Request(uPlayer1.Playlist.First()));
                       // break;
                    default: throw new InvalidCastException();
                }
            }
        }

        private void UIAddPlaylistUnder_Click(object sender, EventArgs e)
            => OnAddPlaylistEvent(new EventArgs());

        private void UIThumbup_Click(object sender, EventArgs e)
        {
            if (SearchlistboxItems[UISearchListbox.SelectedIndex] != null)
                OnRateEvent(new RateEventArgs(selected.MID, selected.Type));           
        }

        private void UIPathAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            => OnPathClicked(new PathClickedEventArgs(UIPathAuthor.Name, ElementType.Author));

        private void UIPathAlbum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
           => OnPathClicked(new PathClickedEventArgs(UIPathAuthor.Name, ElementType.Album));


        public void EditMusicDone()
        {
            UIEditMusicName.Visible = false;
            UIEditMusicGenres.Visible = false;
        }

        private void UIEditMusic_Click(object sender, EventArgs e)
        {
            if (selected != null && !(selected is Playlist))
            {
                UIEditMusicName.Visible = true;
                UIEditMusicName.Text = UISelectedname.Text;

                if (selected is Music)
                {
                    UIEditMusicGenres.Text = string.Join(";", (selected as Music).Genre);
                    UIEditMusicGenres.Visible = true;
                }
            }
        }

        private void UIEditMusicName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OnEditMusic(new EditMusicEventArgs(selected, UIEditMusicName.Text, UIEditMusicGenres.Text.Split(';')));
            }
        }

        private void UISavePlaylist_Click(object sender, EventArgs e)
        {
            if (true)//uPlayer1.Playlist.Count != 0
            {
                UIEditPlaylist.Visible = true;
                UIPlaylistName.Visible = true;
            }
        }

        private void UIPlaylistName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UIEditPlaylist.Visible = false;
                UIPlaylistName.Visible = false;
                OnPlaylistSaved(new PlaylistSavedEventArgs(UIPlaylistName.Text, UIPlaylistPrivate.Checked));
            }
        }

        private void UIPlaylistClear_LinkClicked(object sender, EventArgs e)
        {
            ClearPlaylist();
            OnClearEvent(new EventArgs());
        }

        private void UISearchListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = (IElement)SearchlistboxItems[UISearchListbox.SelectedIndex];
            Invoke((MethodInvoker)delegate{
                ChangeDescription(selected);
            });
        }
    }
}
