using System;

namespace Utility.Musics
{
    [Serializable]
    public class Music : Element
    {
        //public ElementType Type { get; } = ElementType.Music;

        public string Title { get; set; }
        public Author Author { get; set; }
        public Album Album { get; set; }
        public string Format { get; set; }
        public string ServerPath { get; set; }
        //public string MID { get; set; }
        public string[] Genre { get; set; } 
        public int Rating = 0;
        public byte[] FileBinary { get; set; }
        public uint N { get; set; }
        public override string Name { get => Title; set => Title = value; }
        public Tags.Tag[] Tags { get; set; }

        public Music() { }
        public Music(string title, Author author,Album album, byte[] Filebinary)
        {
            Title = title;
            Author = author;
            FileBinary = Filebinary;
            Album = album;
            MID = GenerateHash();
            Type = ElementType.Music;
        }
        public Music(string title, Author author, Album album, string Path)
        {
            Title = title;
            Author = author;
            ServerPath = Path;
            Album = album;
            MID = GenerateHash();
            Type = ElementType.Music;
        }
        public Music(string title, Author author, Album album, string Path, int rating)
        {
            Title = title;
            Author = author;
            ServerPath = Path;
            Album = album;
            MID = GenerateHash();
            Type = ElementType.Music;
            Rating = rating;
        }

        protected override string KeyToHash() => Author.Name + Album.Name + Title;
    }
    public enum ElementType
    {
        Author,
        Album,
        Music,
        Playlist
    }
}
