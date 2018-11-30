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
            throw new NotImplementedException();
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
    }
}
