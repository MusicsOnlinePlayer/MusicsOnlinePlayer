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

        public Playlist(User creator, string name, List<Music> Musics, bool IsPrivate)
        {
            Creator = creator;
            Name = name;
            musics = Musics;
            Private = IsPrivate;
        }
        public Playlist(User creator, string name)
        {
            Creator = creator;
            Name = name;
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
