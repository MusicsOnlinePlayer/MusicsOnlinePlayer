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
        public Author(string name,string Path)
        {
            Name = name;
            Albums = new List<Album>();
            MID = Hash.SHA256Hash(Name + Element.Author);
            ServerPath = Path;
        }
    }
    [Serializable]
    public class Music
    {
        public Element type = Element.Music;

        public string Title { get; set; }
        public Author Author { get; set; }
        public Album Album { get; set; }
        public string Format { get; set; }
        public string ServerPath { get; set; }
        public string MID { get; set; }
        public string[] Genre { get; set; }


        public int Rating = 0;
        public byte[] FileBinary { get; set; }

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

        public string MID { get; set; }

        public string Name { get; set; }
        public Author Author { get; set; }
        public int Rating { get; set; }
        public List<Music> Musics { get; set; }
        public string ServerPath { get; set; }

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

        public Album(Author author, string name, Music[] musics)
        {
            Author = author;
            Name = name;
            Musics = new List<Music>();
            MID = Hash.SHA256Hash(Name + Element.Album.ToString());
            Musics = musics.ToList();
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
        public User Creator { get; set; }
        public string Name { get; set; }
        public List<Music> musics = new List<Music>();
        public bool Private { get; set; }

        public Playlist(User creator,string name,List<Music> Musics,bool IsPrivate)
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

    [Serializable]
    public class User
    {
        public string UID { get; set; }
        public Rank Userrank { get; set; }

        private string Password { get; set; }
        public String Name { get; set; }
        public bool Connected { get; set; }

        public User(){}

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
        Users,
        Trending
    }


    [Serializable]
    public class Request
    {
        public RequestsTypes RequestsTypes { get; set; }

        //Search
        public string Name { get; set; }
        public Element Requested { get; set; }

        //Binaries
        public Music RequestedBinaries { get; set; }

        //Favorites
        public string UserID { get; set; }

        //User
        public string Username { get; set; }

        //Trending

        //Search
        public Request(string name, Element requested)
        {
            Requested = requested;
            Name = name;
            RequestsTypes = RequestsTypes.Search;
        }

        //Binaries
        public Request(Music requested)
        {
            RequestedBinaries = requested;
            RequestsTypes = RequestsTypes.MusicsBinaries;
        }

        //Favorites
        public Request(string UIDFavorites)
        {
            UserID = UIDFavorites;
            RequestsTypes = RequestsTypes.Favorites;
        }

        //User
        public Request(User SearchUser)
        {
            Username = SearchUser.Name;
            RequestsTypes = RequestsTypes.Users;
        }

        //User
        public Request()
        {
            RequestsTypes = RequestsTypes.Trending;
        }
    }

    [Serializable] 
    public class RequestAnswer
    {
        public RequestsTypes RequestsTypes { get; set; }

        public object AnswerList { get; set; }
        public Element Requested { get; set; }

        public Music Binaries { get; set; }

        public List<Music> Favorites = new List<Music>();

        public List<User> Users = new List<User>();

        public bool IsAccepted { get; set; }

        public List<Music[]> Trending = new List<Music[]>();

        public RequestAnswer(object answerlist, Element requested)
        {
            Requested = requested;
            AnswerList = answerlist;
            RequestsTypes = RequestsTypes.Search;
        }

        public RequestAnswer(Music requested)
        {
            Binaries = requested;
            RequestsTypes = RequestsTypes.MusicsBinaries;
        }

        public RequestAnswer(List<Music> favorites)
        {
            Favorites = favorites;
            RequestsTypes = RequestsTypes.Favorites;
        }

        public RequestAnswer(List<User> AnswerUsers,bool IsRequestAccepted)
        {
            IsAccepted = IsRequestAccepted;
            Users = AnswerUsers;
            RequestsTypes = RequestsTypes.Users;
        }

        public RequestAnswer(List<Music[]> Servertrending)
        {
            Trending = Servertrending;
            RequestsTypes = RequestsTypes.Trending;
        }
    }

    [Serializable]
    public class SavePlaylist
    {
        public string UID { get; set; }
        public Playlist Playlist { get; set; }

        public SavePlaylist(string UserId, Playlist UserPlaylist)
        {
            UID = UserId;
            Playlist = UserPlaylist;
        }
    }

    [Serializable]
    public class Login{

        
        public User LoginInfo { get; set; }
        public bool IsSignup { get; set; }

        public Login(User Logininfo,bool Signup)
        {
            LoginInfo = Logininfo;
            IsSignup = Signup;
        }

    }

    [Serializable]
    public class EditUser
    {
        public string UIDOld { get; set; }
        public User NewUser { get; set; }

        public EditUser(string UserIdOld,User Newuser)
        {
            UIDOld = UserIdOld;
            NewUser = Newuser;
        }
    }

    [Serializable]
    public class EditUserReport
    {
        public bool IsApproved { get; set; }
        public User NewUser { get; set; }

        public EditUserReport(bool Approved, User Newuser)
        {
            IsApproved = Approved;
            NewUser = Newuser;
        }
    }

    [Serializable]
    public class AuthInfo
    {
        public bool IsAccepted { get; set; }
        public Rank RankofAuthUser { get; set; }

        public AuthInfo(bool Accepted,Rank RankOfUser)
        {
            IsAccepted = Accepted;
            RankofAuthUser = RankOfUser;
        }
    }

    [Serializable]
    public class Rate
    {
        public string MusicRatedMID { get; set; }

        public Rate(string RatedMusicMID)
        {
            MusicRatedMID = RatedMusicMID;
        }
    }

    [Serializable]
    public class RateReport
    {
        public bool ReportOk { get; set; }
        public string MID { get; set; }
        public int UpdatedRating { get; set; }

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
        public TypesEdit TypeOfEdit { get; set; }

        public string UserToEdit { get; set; }
        public Rank NewRankOfUser { get; set; }

        public object ObjectToEdit { get; set; }
        public string NewName { get; set; }
        public Element TypeOfObject { get; set; }

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

    [Serializable]
    public class UploadMusic
    {
        public Album MusicPart { get; set; }

        public UploadMusic(Album Part)
        {
            MusicPart = Part;
        }
    }
}
