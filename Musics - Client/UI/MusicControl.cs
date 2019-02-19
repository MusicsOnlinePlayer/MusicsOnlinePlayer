using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility.Musics;
using System.IO;

namespace Musics___Client.UI
{
    public partial class MusicControl : UserControl
    {
        public Element Element { get; set; }

        public MusicControl()
        {
            InitializeComponent();
        }

        public MusicControl UpdateControl(Element element)
        {
            Element = element;
            switch (Element.Type)
            {
                case ElementType.Music: ChangeControlMusic(); break;
                case ElementType.Album: ChangeControlAlbum(); break;
                case ElementType.Author: ChangeControlAuthor(); break;
                case ElementType.Playlist: ChangeControlPlaylist(); break;
            }
            return this;
        }

        private void ChangeControlPlaylist()
        {
            Playlist Pl = (Playlist)Element;
            UIArtistName.Text = Pl.Creator.Name;
            UIMusicname.Text = Pl.Name;
        }

        private void ChangeControlAuthor()
        {
            Author Author = (Author)Element;
            UIArtistName.Text = Author.Name;
            UIMusicname.Text = Author.Name;
            GetElementImage(Author);
        }

        private void ChangeControlAlbum()
        {
            Album Album = (Album)Element;
            UIArtistName.Text = Album.Author.Name;
            UIMusicname.Text = Album.Name;
            GetElementImage(Album);
        }

        private void ChangeControlMusic()
        {
            Music music = (Music)Element;
            UIArtistName.Text = music.Author.Name;
            UIMusicname.Text = music.Name;
            GetElementImage(music);
        }

        private void GetElementImage(Element music)
        {
            if (music.Image != null)
            {
                using (var ms = new MemoryStream(music.Image))
                {
                    UIMusicImage.BackgroundImage = Image.FromStream(ms);
                }
            }
        }

        public void MergePlaylist(Playlist playlist)
        {
            if (!(Element is Playlist)) throw new ArgumentException("Element invalid");
            //if (playlist.musics == null) throw new ArgumentNullException("Playlist empty");
            if (playlist.MID != (Element as Playlist).MID) throw new ArgumentException("Playlists MID differents");

            ((Playlist)Element).musics.AddRange(playlist.musics);   

            //((Playlist)Element).musics = ((Playlist)Element).musics.OrderBy(x => x.N).ToList();
        }
    }
}
