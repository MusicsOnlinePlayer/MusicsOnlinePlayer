using System;
using Utility.Musics;
using Utility.Network.Users;

namespace Utility.Network.Dialog
{
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
    public enum RequestsTypes
    {
        Search,
        MusicsBinaries,
        Favorites,
        Users,
        Trending
    }
}
