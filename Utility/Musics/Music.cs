using System;

namespace Utility.Musics
{
    [Serializable]
    public class Music : IElement
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
        public Music(string title, Author author,Album album, byte[] Filebinary)
        {
            Title = title;
            Author = author;
            FileBinary = Filebinary;
            Album = album;
            MID = Hash.SHA256Hash(Title + author.Name + Album.Name);
        }
        public Music(string title, Author author, Album album, string Path)
        {
            Title = title;
            Author = author;
            ServerPath = Path;
            Album = album;
            MID = Hash.SHA256Hash(Title + author.Name + Album.Name);
        }
        public Music(string title, Author author, Album album, string Path, int rating)
        {
            Title = title;
            Author = author;
            ServerPath = Path;
            Album = album;
            MID = Hash.SHA256Hash(Title + author.Name + Album.Name);
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
