using System;
using Utility.Musics;
using Utility.Network.Users;

namespace Utility.Network.Dialog
{
    [Serializable]
    public class Request : IPacket
    {
        public string SenderUID { get; set; }
        public bool IsFromServer { get; set; }


        public RequestsTypes RequestsTypes { get; set; }

        //Search
        public string Name { get; set; }
        public ElementType Requested { get; set; }

        //Binaries
        public Music RequestedBinaries { get; set; }

        //Favorites
        public string UserID { get; set; }

        //User
        public string Username { get; set; }

        //Trending
        public ElementType Type { get; set; }
        public string Genre { get; set; }

        //Search
        public Request(string name, ElementType requested)
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

        //Genre
        public Request(ElementType type, string genre)
        {
            Type = type;
            Genre = genre;
            RequestsTypes = RequestsTypes.Genres;
        }
    }
    public enum RequestsTypes
    {
        Search,
        MusicsBinaries,
        Favorites,
        Users,
        Genres
    }
}
