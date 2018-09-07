using System;
using System.Collections.Generic;
using System.Linq;

namespace Utility.Musics
{
    [Serializable]
    public class Album
    {
        public Element Type { get; } = Element.Album;

        public string MID { get; set; }

        public string Name { get; set; }
        public Author Author { get; set; }
        public int Rating { get; set; }
        public List<Music> Musics { get; set; }
        public string ServerPath { get; set; }

        public Album(Author author, string name)
        {
            Author = author;
            Name = name;
            Musics = new List<Music>();
            MID = Hash.SHA256Hash(Name + Element.Album.ToString());
        }
        public Album(Author author, string name, Music[] musics)
        {
            Author = author;
            Name = name;
            Musics = musics.ToList();
            MID = Hash.SHA256Hash(Name + Element.Album.ToString());
        }
        public Album(Author author, string name, string Path)
        {
            Author = author;
            Name = name;
            Musics = new List<Music>();
            MID = Hash.SHA256Hash(Name + Element.Album.ToString());
            ServerPath = Path;
        }
        public Album(string name)
        {
            Name = name;
            Musics = new List<Music>();
            MID = Hash.SHA256Hash(Name + Element.Album.ToString());
        }

        public void Add(Music music)
        {
            Musics.Add(music);
        }
    }
}
