using System;
using System.Collections.Generic;

namespace Utility.Musics
{
    [Serializable]
    public class Author : Element
    {
        //public ElementType Type { get; } = ElementType.Author;

        public override string Name { get; set; }
        public int Rating = 0;

        //public string MID { get; set; }
        public List<Album> Albums { get; set; }
        public string ServerPath { get; set; }

        public Author(string name)
        {
            Name = name;
            Albums = new List<Album>();
            MID = Hash.SHA256Hash(Name + ElementType.Author);
            Type = ElementType.Author;
        }
        public Author(string name, string Path)
        {
            Name = name;
            Albums = new List<Album>();
            MID = Hash.SHA256Hash(Name + ElementType.Author);
            ServerPath = Path;
            Type = ElementType.Author;
        }
    }
}
