using System;
using System.Collections.Generic;

namespace Utility.Musics
{
    [Serializable]
    public class Author : IElement
    {
        public Element Type { get; } = Element.Author;

        public string Name { get; set; }
        public int Rating = 0;

        public string MID { get; set; }
        public List<Album> Albums { get; set; }
        public string ServerPath { get; set; }

        public Author(string name)
        {
            Name = name;
            Albums = new List<Album>();
            MID = Hash.SHA256Hash(Name + Element.Author);
        }
        public Author(string name, string Path)
        {
            Name = name;
            Albums = new List<Album>();
            MID = Hash.SHA256Hash(Name + Element.Author);
            ServerPath = Path;
        }
    }
}
