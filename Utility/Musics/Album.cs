using System;
using System.Collections.Generic;

namespace Utility.Musics
{
    [Serializable]
    public class Album : Element
    {
        //public ElementType Type { get; } = ElementType.Album;

        //public string MID { get; set; }

        public override string Name { get; set; }
        public Author Author { get; set; }
        public int Rating { get; set; }
        private readonly  List<Music> musics = new List<Music>();
        public IEnumerable<Music> Musics
        {
            get => musics;
            set
            {
                musics.Clear();
                musics.AddRange(value);
            }
        }
        public string ServerPath { get; set; }

        public Album(Author author, string name)
        {
            Author = author;
            Name = name; 
            Type = ElementType.Album;
            MID = GenerateHash();
        }
        public Album(Author author, string name, Music[] musics)
        {
            Author = author;
            Name = name; 
            Type = ElementType.Album;
            Musics = musics;
            MID = GenerateHash();
        }
        public Album(Author author, string name, string Path)
        {
            Author = author;
            Name = name; 
            Type = ElementType.Album;
            MID = GenerateHash();
            ServerPath = Path;
        }
        public Album(string name)
        {
            Name = name; 
            Type = ElementType.Album;
            MID = GenerateHash();
        }

        public void Add(Music music)
        {
            musics.Add(music);
        }

        protected override string KeyToHash() => Author.Name +  Name;
    }
}
