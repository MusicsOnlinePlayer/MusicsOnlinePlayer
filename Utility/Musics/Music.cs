using System;

namespace Utility.Musics
{
    [Serializable]
    public class Music
    {
        public Element Type { get; } = Element.Music;

        public string Title { get; set; }
        public Author Author { get; set; }
        public Album Album { get; set; }
        public string Format { get; set; }
        public string ServerPath { get; set; }
        public string MID { get; set; }
        public string[] Genre { get; set; }

        public int Rating = 0;
        public byte[] FileBinary { get; set; }
        public uint N { get; set; }

        public Music() { }
        public Music(string title, Author author, byte[] Filebinary)
        {
            Title = title;
            Author = author;
            FileBinary = Filebinary;
            MID = Hash.SHA256Hash(Title + author.Name);
        }
        public Music(string title, Author author, string Path)
        {
            Title = title;
            Author = author;
            ServerPath = Path;
            MID = Hash.SHA256Hash(Title + author.Name);
        }
        public Music(string title, Author author, string Path, int rating)
        {
            Title = title;
            Author = author;
            ServerPath = Path;
            MID = Hash.SHA256Hash(Title + author.Name);
            Rating = rating;
        }
    }
    public enum Element
    {
        Author,
        Album,
        Music,
        Playlist
    }
}
