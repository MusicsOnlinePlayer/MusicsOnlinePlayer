using System;
using Utility.Musics;

namespace Utility.Network.Users
{
    [Serializable]
    public class User
    {
        public string UID { get; set; }
        public Rank Rank { get; set; }

        public string Name { get; set; }
        public bool Connected { get; set; }

        public User() { }

        public User(string UserName)
        {
            Name = UserName;
        }

        public User(string name, string UserPassword)
        {
            Name = name;
            UID = Hash.SHA256Hash(name + UserPassword);
        }

        public User(string name, string UserPassword, Rank RankOf)
        {
            Name = name;
            Rank = RankOf;
            UID = Hash.SHA256Hash(name + UserPassword);
        }
    }
}
