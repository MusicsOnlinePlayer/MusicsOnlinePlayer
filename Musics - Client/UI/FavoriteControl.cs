using Musics___Client.API.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utility.Musics;

namespace Musics___Client.UI
{
    public partial class FavoriteControl : UserControl
    {
        public FavoriteControl()
        {
            InitializeComponent();
        }

        public List<Music> LikedMusics = new List<Music>();
        public List<Music> SelectedFavorites = new List<Music>();

        public event EventHandler<RequestBinairiesEventArgs> SearchEvent;
        protected virtual void OnSearchEvent(RequestBinairiesEventArgs e) => SearchEvent?.Invoke(this, e);

        public event EventHandler<PlayEventArgs> PlayAllEvent;
        protected virtual void OnPlayAllEvent(PlayEventArgs e) => PlayAllEvent?.Invoke(this, e);

        public void UpdateSelectedFavorites()
        {
            SelectedFavorites.Clear();
            SelectedFavorites = (from val in LikedMusics
                                 where val.Genre.First() == UILikedMusicsList.SelectedItem.ToString()
                                 select val).ToList();
            UILikedMusicsList.Items.Clear();
            foreach (var m in SelectedFavorites)
            {
                UILikedMusicsList.Items.Add(m.Title);
            }
        }

        private void UILikedMusicsList_DoubleClick(object sender, EventArgs e)
        {
            if (UILikedMusicsList.SelectedItem != null && SelectedFavorites.Count == 0)
            {
                UpdateSelectedFavorites();
            }
            else if (UILikedMusicsList.SelectedItem != null)
            {
                OnSearchEvent(new RequestBinairiesEventArgs(SelectedFavorites[UILikedMusicsList.SelectedIndex]));
            }
        }

        public void UpdateFavorites(List<Music> Favorites)
        {
            Invoke((MethodInvoker)delegate
            {
                UILikedMusicsList.Items.Clear();
                foreach (var m in (from val in Favorites select val.Genre.First()).Cast<string>().Distinct().ToList())
                    UILikedMusicsList.Items.Add(m);
                var tmp = Favorites;
                LikedMusics = tmp;
            });    
        }

        public void ClearAll()
        {
            LikedMusics.Clear();
            UILikedMusicsList.Items.Clear();
            SelectedFavorites.Clear();
        }

        private void UIFavoritesBack_Click(object sender, EventArgs e)
        {
            SelectedFavorites.Clear();
            UpdateFavorites(LikedMusics);
        }

        private void UIPlayFavorites_Click(object sender, EventArgs e)
        {
            if (LikedMusics.Count >= 1)
                OnPlayAllEvent(new PlayEventArgs(new Album(new Author(""), "", LikedMusics.ToArray())));
        }
    }
}
