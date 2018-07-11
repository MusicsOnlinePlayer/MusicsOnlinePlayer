using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Function
    {

        public static MessageTCP Serialize(object anySerializableObject)
        {
            using (var memoryStream = new MemoryStream())
            {
                (new BinaryFormatter()).Serialize(memoryStream, anySerializableObject);
                return new MessageTCP { Data = memoryStream.ToArray() };
            }
        }

        public static object Deserialize(MessageTCP message)
        {
            using (var memoryStream = new MemoryStream(message.Data))
            {
                return (new BinaryFormatter()).Deserialize(memoryStream);
            }

        }
    }

    [Serializable]
    public class MessageTCP : Function
    {
        public byte[] Data { get; set; }
        public MessageTCP() { }
        public MessageTCP(byte[] bytes)
        {
            Data = bytes;
        }
    }
    [Serializable]
    public class Author
    {
        public string Name;
        public int Rating = 0;

        public List<Album> albums;

        public Author(string name)
        {
            Name = name;
            albums = new List<Album>();
        }
    }
    [Serializable]
    public class Music
    {
        public string Title;
        public Author Author;
        public Album Album;
        public string Format;
        public string ServerPath;
        public string MID;

        public int Rating = 0;
        public byte[] FileBinary;

        public Music()
        {

        }

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
        public Music(string title, Author author, string Path,int rating)
        {
            Title = title;
            Author = author;
            ServerPath = Path;
            MID = Hash.SHA256Hash(Title + author.Name);
            Rating = rating;
        }
    }
    [Serializable]
    public class Album
    {
        public string Name;
        public Author Author;
        public int Rating = 0;
        public List<Music> Musics;

        public Album(Author author, string name)
        {
            Author = author;
            Name = name;
            Musics = new List<Music>();
        }
        public Album(string name)
        {
            Name = name;
        }
        public void Add(Music music)
        {
            Musics.Add(music);
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

    [Serializable]
    public class User
    {
        public User()
        {

        }
        public User(string name, string Password)
        {
            Name = name;
            password = Password;
            UID = Hash.SHA256Hash(name + password);
        }


        public User(string name, string Password, Rank RankOf)
        {
            Name = name;
            rank = RankOf;
            password = Password;
            UID = Hash.SHA256Hash(name + password);
        }

        public string UID;
        public Rank rank;

        private string password;
        public String Name;
        public bool Connected;
    }
    public enum Rank{
        Viewer,
        AdvancedUser,
        Admin,
        Creator
    };


    public class ClientList
    {
        public Dictionary<Socket, User> List = new Dictionary<Socket, User>();

        public bool Contains(string UID)
        {
            foreach (var p in List)
            {
                if (p.Value.UID == UID)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetIndex(string UID)
        {
            int a = 0;
            foreach (var p in List)
            {

                if (p.Value.UID == UID)
                {
                    return a;
                }
                a++;
            }
            return -1;
        }

        public User GetUser(string UID)
        {
            foreach (var p in List.Values)
            {
                if (p.UID == UID)
                {
                    return p;
                }
            }
            return null;
        }
        public User GetUser(Socket socket)
        {
            foreach (var p in List)
            {
                if (p.Key == socket)
                {
                    return p.Value;
                }
            }
            return null;
        }

        public List<User> GetPeople(string Name)
        {
            List<User> a = new List<User>();
            foreach (var p in List.Values)
            {
                try
                {
                    if (p.Name.Contains(Name))
                    {
                        a.Add(p);
                    }
                }
                catch
                {
                    Console.WriteLine("No client Error");
                }
            }
            return a;
        }

        public int Count()
        {
            return List.Count;

        }

        private bool Contains(User User)
        {
            foreach (var p in List)
            {
                if (User.UID == p.Value.UID)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddUser(User User, Socket socket)
        {
            if (Contains(User))

                return;
            List.Add(socket, User);

        }

    }

    [Serializable]
    public class RequestSearch
    {
        public string Name;
        public object Requested;

        public RequestSearch(string name, object requested)
        {
            Requested = requested;
            Name = name;
        }
    }

    [Serializable]
    public class RequestMusic
    {
        public Music Requested;

        public RequestMusic(Music requested)
        {
            Requested = requested;
        }
    }

    [Serializable]
    public class RequestMusicAnswer
    {
        public Music Requested;

        public RequestMusicAnswer(Music requested)
        {
            Requested = requested;
        }
    }


    [Serializable]
    public class RequestSearchAnswer
    {
        public object answerList;
        public object Requested;

        public RequestSearchAnswer(object answer, object requested)
        {
            answerList = answer;
            Requested = requested;
        }
    }

    [Serializable]
    public class Login{

        
        public User LoginInfo;
        public bool IsSignup;

        public Login(User Logininfo,bool Signup)
        {
            LoginInfo = Logininfo;
            IsSignup = Signup;
        }

    }

    [Serializable]
    public class AuthInfo
    {
        public bool IsAccepted;
        public Rank rankofAuthUser;

        public AuthInfo(bool Accepted,Rank RankOfUser)
        {
            IsAccepted = Accepted;
            rankofAuthUser = RankOfUser;
        }
    }

    [Serializable]
    public class Rate
    {
        public string MusicRatedMID;

        public Rate(string RatedMusicMID)
        {
            MusicRatedMID = RatedMusicMID;
        }
    }

    [Serializable]
    public class RateReport
    {
        public bool ReportOk;
        public string MID;
        public int UpdatedRating;

        public RateReport(bool Reportok,string MusicID, int NewRating)
        {
            ReportOk = Reportok;
            MID = MusicID;
            UpdatedRating = NewRating;

        }
    }
}
