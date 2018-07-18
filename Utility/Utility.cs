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
        public Element type = Element.Author;

        public string Name;
        public int Rating = 0;

        public string MID;
        public List<Album> albums;
        public string ServerPath;

        public Author(string name)
        {
            Name = name;
            albums = new List<Album>();
            MID = Hash.SHA256Hash(Name + Element.Author);
        }
        public Author(string name,string Path)
        {
            Name = name;
            albums = new List<Album>();
            MID = Hash.SHA256Hash(Name + Element.Author);
            ServerPath = Path;
        }
    }
    [Serializable]
    public class Music
    {
        public Element type = Element.Music;

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
        public Element type = Element.Album;

        public string MID;

        public string Name;
        public Author Author;
        public int Rating = 0;
        public List<Music> Musics;
        public string ServerPath;

        public Album(Author author, string name)
        {
            Author = author;
            Name = name;
            Musics = new List<Music>();
            MID = Hash.SHA256Hash(Name + Element.Album.ToString());
        }
        public Album(Author author, string name,string Path)
        {
            Author = author;
            Name = name;
            Musics = new List<Music>();
            MID = Hash.SHA256Hash(Name + Element.Album.ToString());
            ServerPath = Path;
        }
        public Album(string name)
        {
            Name = name;
            MID = Hash.SHA256Hash(Name + Element.Album.ToString());
        }

        public void Add(Music music)
        {
            Musics.Add(music);
        }
    }

    [Serializable]
    public class Playlist
    {
        public User Creator;
        public string Name;
        public List<Music> musics = new List<Music>();

        public Playlist(User creator,string name,List<Music> Musics)
        {
            Creator = creator;
            Name = name;
            musics = Musics;
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

    [Serializable]
    public class User
    {
        public User(){}

        public User(string UserName)
        {
            Name = UserName;
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
        Viewer = 0,
        User = 1,
        Admin = 2,
        Creator = 3
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

        public Socket GetSocket(string UID)
        {
            foreach (var p in List)
            {
                if (p.Value.UID == UID)
                {
                    return p.Key;
                }
            }
            return null;
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

    public enum RequestsTypes
    {
        Search,
        MusicsBinaries,
        Favorites,
        Users
    }


    [Serializable]
    public class Request
    {
        public RequestsTypes requestsTypes;

        //Search
        public string Name;
        public Element Requested;

        //Binaries
        public Music RequestedBinaries;

        //Favorites
        public string UserID;

        //User
        public string Username;

        //Search
        public Request(string name, Element requested)
        {
            Requested = requested;
            Name = name;
            requestsTypes = RequestsTypes.Search;
        }

        //Binaries
        public Request(Music requested)
        {
            RequestedBinaries = requested;
            requestsTypes = RequestsTypes.MusicsBinaries;
        }

        //Favorites
        public Request(string UIDFavorites)
        {
            UserID = UIDFavorites;
            requestsTypes = RequestsTypes.Favorites;
        }

        //User
        public Request(User SearchUser)
        {
            Username = SearchUser.Name;
            requestsTypes = RequestsTypes.Users;
        }
    }

    [Serializable] 
    public class RequestAnswer
    {
        public RequestsTypes requestsTypes;

        public object AnswerList;
        public Element Requested;

        public Music Binaries;

        public List<Music> Favorites = new List<Music>();

        public List<User> Users = new List<User>();

        public bool IsAccepted;

        public RequestAnswer(object answerlist, Element requested)
        {
            Requested = requested;
            AnswerList = answerlist;
            requestsTypes = RequestsTypes.Search;
        }

        public RequestAnswer(Music requested)
        {
            Binaries = requested;
            requestsTypes = RequestsTypes.MusicsBinaries;
        }

        public RequestAnswer(List<Music> favorites)
        {
            Favorites = favorites;
            requestsTypes = RequestsTypes.Favorites;
        }

        public RequestAnswer(List<User> AnswerUsers,bool IsRequestAccepted)
        {
            IsAccepted = IsRequestAccepted;
            Users = AnswerUsers;
            requestsTypes = RequestsTypes.Users;
        }
    }

    [Serializable]
    public class SavePlaylist
    {
        public string UID;
        public Playlist playlist;

        public SavePlaylist(string UserId, Playlist Playlist)
        {
            UID = UserId;
           playlist = Playlist;
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
    public class EditUser
    {
        public string UIDOld;
        public User NewUser;

        public EditUser(string UserIdOld,User Newuser)
        {
            UIDOld = UserIdOld;
            NewUser = Newuser;
        }
    }

    [Serializable]
    public class EditUserReport
    {
        public bool IsApproved;
        public User NewUser;

        public EditUserReport(bool Approved, User Newuser)
        {
            IsApproved = Approved;
            NewUser = Newuser;
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

    public enum TypesEdit{
        Users,
        Musics
    }

    public enum Element
    {
        Author,
        Album,
        Music,
        Playlist
    }

    [Serializable]
    public class EditRequest
    {
        public TypesEdit TypeOfEdit;

        public string UserToEdit;
        public Rank NewRankOfUser;

        public object ObjectToEdit;
        public string NewName;
        public Element TypeOfObject;

        public EditRequest(string UIDToEdit,Rank NewRank)
        {
            UserToEdit = UIDToEdit;
            NewRankOfUser = NewRank;
            TypeOfEdit = TypesEdit.Users;
        }

        public EditRequest(object ToEdit,string NewTitle,Element TypeOf)
        {
            ObjectToEdit = ToEdit;
            NewName = NewTitle;
            TypeOfObject = TypeOf;
            TypeOfEdit = TypesEdit.Musics;
        }
    }

}
