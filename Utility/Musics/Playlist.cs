using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Utility.Network.Users;

namespace Utility.Musics
{
    [Serializable]
    public class Playlist
    {
        public User Creator { get; set; }
        public string Name { get; set; }
        public List<Music> musics = new List<Music>();
        public bool Private { get; set; }
        public int Rating { get; set; }
        public string MID { get; set; }

        public Playlist(User creator, string name, List<Music> Musics, bool IsPrivate)
        {
            Creator = creator;
            Name = name;
            musics = Musics;
            Private = IsPrivate;
            MID = Hash.SHA256Hash(Name + Private + Element.Playlist.ToString());
        }
        public Playlist(User creator, string name)
        {
            Creator = creator;
            Name = name;
            MID = Hash.SHA256Hash(Name + Private + Element.Playlist.ToString());
        }
    }

    public static class Hash
    {
        public static string SHA256Hash(string value)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                return String.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(value)));
            }
        }
    }

}
