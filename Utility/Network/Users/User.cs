using System;
using Utility.Musics;

namespace Utility.Network.Users
{
    [Serializable]
    public class User
    {
        public string UID { get; set; }
        public Rank Userrank { get; set; }

        private string Password { get; set; }
        public String Name { get; set; }
        public bool Connected { get; set; }

        public User() { }

        public User(string UserName)
        {
            Name = UserName;
        }

        public User(string name, string UserPassword)
        {
            Name = name;
            Password = UserPassword;
            UID = Hash.SHA256Hash(name + UserPassword);
        }

        public User(string name, string UserPassword, Rank RankOf)
        {
            Name = name;
            Userrank = RankOf;
            Password = UserPassword;
            UID = Hash.SHA256Hash(name + UserPassword);
        }
    }

    public enum Rank
    {
        Viewer = 0,
        User = 1,
        Admin = 2,
        Creator = 3
    }
}
